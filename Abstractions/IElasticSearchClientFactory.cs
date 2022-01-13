using System;
using Nest;

namespace Abstractions
{
    public interface IElasticSearchClientFactory
    {
        IElasticClient GetClient();
    }
}
