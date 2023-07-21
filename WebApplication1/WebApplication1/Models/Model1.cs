using System.Data.Entity;

namespace WebApplication1.Models
{
    public class Model1:DbContext
    {
        public Model1() : base("Server=192.1.168.245\\SQL2019;Database=StudentCRUD;User Id=sa;Password=1475;Encrypt=false;MultipleActiveResultSets=true;Encrypt=false;")
        {

        }
        public virtual DbSet<Ogrenci> MyEntities { get; set; }
    }
}
