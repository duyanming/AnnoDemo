using System;
using Elasticsearch.Net;
using Nest;

namespace Anno.Es
{
    public static class EsInstance
    {
        private static ElasticClient _esClient;

        public static ElasticClient EsClient
        {
            get
            {
                if (_esClient != null)
                {
                    return _esClient;
                }
                else
                {
                    var pool = new StaticConnectionPool(EsConfiguration.Uris);
                    var settings = new ConnectionSettings(pool);
                    _esClient = new ElasticClient(settings);

                    return _esClient;
                }
            }
        }
    }
}
