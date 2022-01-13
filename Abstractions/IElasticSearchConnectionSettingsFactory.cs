using Nest;

namespace Abstractions
{
    public interface IElasticSearchConnectionSettingsFactory
    {
        ConnectionSettings GetSettings();
    }
}