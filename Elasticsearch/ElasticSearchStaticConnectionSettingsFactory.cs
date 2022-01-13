using System;
using Abstractions;
using Domain;
using Elasticsearch.Net;
using Nest;

namespace Elasticsearch
{
    public class ElasticSearchStaticConnectionSettingsFactory : IElasticSearchConnectionSettingsFactory
    {
        public ConnectionSettings GetSettings()
        {
            var elasticUris = new[]{
                new Uri("http://localhost:9200"),               
            };

            var connectionPool = new SingleNodeConnectionPool(elasticUris[0]);            

            var settings = new ConnectionSettings(connectionPool).DefaultMappingFor<Vehicle>(

                m =>
                {
                    m.IndexName("vehicles");
                    m = m.IdProperty("Id");
                    return m;
                }
            );

            return settings;
        }
    }
}
