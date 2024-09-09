using CatalogoProdutoServico.Context;
using CatalogoProdutoServico.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CatalogoProdutoServico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _sqlContext;
        private readonly MongoDbContext _mongoContext;

        public ProdutosController(AppDbContext sqlContext, MongoDbContext mongoContext)
        {
            _sqlContext = sqlContext;
            _mongoContext = mongoContext;
        }

        [HttpGet("Todos")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await _mongoContext.Produtos.Find(_ => true).ToListAsync();
            return Ok(produtos);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto(int id)
        {
            var filter = Builders<Produto>.Filter.Eq(p => p.Id, id);
            var result = await _mongoContext.Produtos.Find(filter).FirstOrDefaultAsync();

            if (result != null)
                return Ok(result);
            else
                return NotFound("Documento não encontrado");
        }

        [HttpPost("Inserir")]
        public async Task<ActionResult<Produto>> InsertProduto([FromBody] Produto produto)
        {
            _sqlContext.Produtos.Add(produto);
            await _sqlContext.SaveChangesAsync();

            await _mongoContext.Produtos.InsertOneAsync(produto);

            return CreatedAtAction(nameof(GetProdutos), new { id = produto.Id }, produto);
        }

        [HttpPut("Alterar")]
        public async Task<ActionResult> UpdateProduto([FromBody] Produto produto, int id)
        {
            if (id != produto.Id) BadRequest();

            _sqlContext.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _sqlContext.SaveChangesAsync();

            var filter = Builders<Produto>.Filter.Eq(p => p.Id, id);
            await _mongoContext.Produtos.ReplaceOneAsync(filter, produto);

            return NoContent();
        }

        [HttpDelete("Excluir")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            var produto = await _sqlContext.Produtos.FindAsync(id);

            if (produto == null) return NotFound();

            _sqlContext.Produtos.Remove(produto);
            await _sqlContext.SaveChangesAsync();

            var filter = Builders<Produto>.Filter.Eq(p => p.Id, id);
            await _mongoContext.Produtos.DeleteOneAsync(filter);

            return NoContent();
        }
    }
}
