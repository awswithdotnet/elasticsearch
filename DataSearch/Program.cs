using System;
using System.Linq;
using System.Threading.Tasks;
using Abstractions;
using Domain;
using Nest;
using Elasticsearch;

namespace DataSearch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IElasticSearchConnectionSettingsFactory elasticSearchConnectionSettingsFactory = new ElasticSearchStaticConnectionSettingsFactory();
            IElasticSearchClientFactory elasticSearchClientFactory = new ElasticSearchClientFactory(elasticSearchConnectionSettingsFactory);

            IElasticClient client = elasticSearchClientFactory.GetClient();
            
            var searchRequest = new SearchRequest<Vehicle>()
            {
                From = 0,
                Size = 1,
                Query = new MatchQuery
                {
                    Field = Infer.Field<Vehicle>(f => f.Make),
                    Query = "BMW"
                }
            };

            ISearchResponse<Vehicle> searchResponse = await client.SearchAsync<Vehicle>(searchRequest);

            Vehicle vehicle = searchResponse.Documents.FirstOrDefault();

            Console.WriteLine("Vehicle Id: " + vehicle.Id);
            Console.WriteLine("Year: " + vehicle.Year);
            Console.WriteLine("Make: " + vehicle.Make);
            Console.WriteLine("Model: " + vehicle.Model);

            Console.ReadLine();

        }
    }
}
