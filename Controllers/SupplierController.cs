using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoApi.Data;
using MongoApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly DBContext dbContext;
        public SupplierController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
            // GET all entrega una lista de todos los proveedores
            [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            return dbContext.Supplier.ToList(); //new string[] { "value1", "value2" };
        }

        // GET busca provedor por NIT
        [HttpGet("{id}")]
        public Supplier Get(string id)
        {
            return dbContext.Supplier.FirstOrDefault(c => c.NIT == id); ;
        }

        // POST crea un nuevo proveedor
        [HttpPost]
        public void Post(Supplier supplier)
        {
            //SupplierAdd newSupplier = new SupplierAdd(supplier.Supplier.NIT, supplier.Supplier.RazonSocial);

            dbContext.Supplier.Add(supplier);
            dbContext.SaveChanges();
            Ok();
        }

        // PUT edita un provedor por NIT
        [HttpPut("{id}")]
        public void Put(Supplier supplier, string id)
        {
            dbContext.Supplier.Update(supplier);
            dbContext.SaveChanges();
        }

        // DELETE elimina un probedor
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
