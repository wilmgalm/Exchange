using System;
using System.Collections.Generic;
using System.Text;

namespace DolarExchange.Model.ConfigurationModel
{
    public class ConnectionStrings : IConnectionStrings
    {
        public string MongoConectionstring { get; set; }
        public string MongoDatabaseName { get; set; }
    }
}
