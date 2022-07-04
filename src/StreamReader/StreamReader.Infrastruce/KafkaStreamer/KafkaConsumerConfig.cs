using Confluent.Kafka;

namespace StreamReader.Infrastruce.KafkaStreamer
{
    public class KafkaConsumerConfig<Tk, Tv> : ConsumerConfig
    {
        public string Topic { get; set; }
        public KafkaConsumerConfig()
        {
            AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
            EnableAutoOffsetStore = false;
        }
    }
}