
namespace parcial1.Models
{
    using System.Data.Entity;
    public class DataContext :DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<parcial1.Models.Gonzales> Gonzales { get; set; }
    }
}