using Banking.Operation.Receipt.Consumer.Domain.Receipt.Parameters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Banking.Operation.Receipt.Consumer.CrossCutting.Ioc.Modules
{
    public static class MongoDbModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var mongoParameters = configuration.GetSection("MongoDatabase").Get<MongoParameters>();

            services.AddScoped<IMongoClient>(x => new MongoClient(mongoParameters.ConnectionString));
            services.AddScoped(x => x.GetService<IMongoClient>().GetDatabase(mongoParameters.DatabaseName));

            BsonSerializer.RegisterSerializer(typeof(decimal), new DecimalSerializer(BsonType.Decimal128));
            BsonSerializer.RegisterSerializer(typeof(decimal?), new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Decimal128)));
        }
    }
}