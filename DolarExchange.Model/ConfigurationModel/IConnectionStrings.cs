using System;
using System.Collections.Generic;
using System.Text;

namespace DolarExchange.Model.ConfigurationModel
{
    public interface IConnectionStrings
    {
        string MongoConectionstring { get; set; }
        string MongoDatabaseName { get; set; }
    }
}
