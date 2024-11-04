using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
namespace MongoApi.Model

{
    public class Supplier
    {
        public ObjectId Id { get; set; }
        public String? NIT { get; set; }
        public String? RazonSocial { get; set; }
        public String? Direccion { get; set; }
        public String? Ciudad { get; set; }
        public String? Departamento { get; set; }
        public String? Email { get; set; }
        public DateTime FechaCreacion { get; set; }
        public String? NombreContacto { get; set; }
        public String? EmailContacto { get; set; }
        public bool Activo { get; set; }
    }
}
