using System;
using System.Threading.Tasks;
using Abstractions;
using Domain;
using Nest;
using Elasticsearch;

namespace DataCreate
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IElasticSearchConnectionSettingsFactory elasticSearchConnectionSettingsFactory = new ElasticSearchStaticConnectionSettingsFactory();
            IElasticSearchClientFactory elasticSearchClientFactory = new ElasticSearchClientFactory(elasticSearchConnectionSettingsFactory);

            IElasticClient client = elasticSearchClientFactory.GetClient();

            Vehicle vehicle = new Vehicle{
                Id = Guid.NewGuid(),
                Year = 2020,
                Make = "BMW",
                Model = "330i"
            };

            IndexResponse asyncIndexResponse = await client.IndexDocumentAsync(vehicle);

            Console.WriteLine("Id: " + asyncIndexResponse.Id);

            Console.ReadLine();

        }
    }
}
