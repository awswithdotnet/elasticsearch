using Abstractions;
using Nest;

namespace Elasticsearch
{
    public class ElasticSearchClientFactory : IElasticSearchClientFactory
    {
        private readonly IElasticSearchConnectionSettingsFactory _connectionSettingsFactory;

        public ElasticSearchClientFactory(IElasticSearchConnectionSettingsFactory connectionSettingsFactory)
        {
            _connectionSettingsFactory = connectionSettingsFactory;
        }      

        public IElasticClient GetClient()
        {
            ConnectionSettings settings = _connectionSettingsFactory.GetSettings();

            IElasticClient client = new ElasticClient(settings);

            return client;
        }
    }
}
