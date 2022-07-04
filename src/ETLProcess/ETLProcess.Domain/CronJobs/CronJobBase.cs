using Microsoft.Extensions.Hosting;
using Cronos;
using HBUC.Logging;
using Timer = System.Timers.Timer;
using Microsoft.Extensions.Configuration;

namespace ETLProcess.Domain.CronJobs
{
    public class CronJobBase : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly CronExpression _expression;
        private readonly TimeZoneInfo _timeZoneInfo;  
        public CronJobBase(string expression)
        {
            _expression = CronExpression.Parse(expression);
            _timeZoneInfo = TimeZoneInfo.Local;
        }
        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            await ScheduleJob(cancellationToken);
        }
        protected virtual async Task ScheduleJob(CancellationToken cancellationToken)
        {
            var next = _expression.GetNextOccurrence(DateTimeOffset.Now, _timeZoneInfo);
            if (!next.HasValue)
                return;

            var delay = next.Value - DateTimeOffset.Now;
            if (delay.TotalMilliseconds <= 0)   // prevent non-positive values from being passed into Timer
            {
                await ScheduleJob(cancellationToken);
                return;
            }
            _timer = new Timer(delay.TotalMilliseconds);
            _timer.Elapsed += async (sender, args) =>
            {
                _timer.Dispose();  // reset and dispose timer
                _timer = null;

                if (!cancellationToken.IsCancellationRequested)
                {
                    await DoWork(cancellationToken);
                }

                if (!cancellationToken.IsCancellationRequested)
                {
                    await ScheduleJob(cancellationToken);    // reschedule next
                }
            };
            _timer.Start();
        }

        public virtual async Task DoWork(CancellationToken cancellationToken)
        {
            await Task.Delay(5000, cancellationToken);
        }
        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Stop();
            await Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
