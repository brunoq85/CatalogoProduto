using CatalogoProdutoServico.Entities;
using MongoDB.Driver;

namespace CatalogoProdutoServico.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("CatalogoProduto");
        }

        public IMongoCollection<Produto> Produtos => _database.GetCollection<Produto>("Produtos");
    }
}
