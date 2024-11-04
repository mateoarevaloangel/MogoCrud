namespace MongoApi.Model
{
    public class SupplierAdd
    {
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
        public SupplierAdd(string NIT, string RazonSocial) 
        {
            this.NIT = NIT;
            this.RazonSocial = RazonSocial;
            this.Direccion = "asd";
            this.Ciudad = "asd";
            this.Departamento = "asd";
            this.Email = "ssad";
            this.FechaCreacion = DateTime.Parse("2020/02/20");
            this.NombreContacto = "asda";
            this.EmailContacto = "email";
            this.Activo = true;
        }
    }
}
