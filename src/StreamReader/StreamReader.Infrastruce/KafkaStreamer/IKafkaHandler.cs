using System.Threading.Tasks;

namespace StreamReader.Infrastruce.KafkaStreamer
{
    public interface IKafkaHandler<Tk, Tv>
    {
        Task HandleAsync(Tk key, Tv value);
    }
}