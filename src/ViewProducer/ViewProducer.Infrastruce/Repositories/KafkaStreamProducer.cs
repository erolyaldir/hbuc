using Confluent.Kafka;

namespace ViewProducer.Infrastruce
{
    public class KafkaStreamProducer : IStreamProducer
    {
        public ProducerConfig ProducerConfig { get; set; }
        public IProducer<string, string> producer;
        public KafkaStreamProducer(string kafkaUrl)
        {

            ProducerConfig = new ProducerConfig() { BootstrapServers = kafkaUrl };
            Connect();
        }
        public void Connect()
        {
            var producerBuilder = new ProducerBuilder<string, string>(ProducerConfig);
            producer = producerBuilder.Build();
        }

        public async Task<string> WriteToStream(string topicName, string text)
        {
            Message<string, string> message = new Message<string, string> { Value = text };
            var result = await producer.ProduceAsync(topicName, message);
            return result.TopicPartitionOffset.ToString();
        }


    }
}
