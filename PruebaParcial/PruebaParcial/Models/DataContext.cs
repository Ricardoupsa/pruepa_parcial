
namespace PruebaParcial.Models
{
    using System.Data.Entity;
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<PruebaParcial.Models.Gonzales> Gonzales { get; set; }
    }
}