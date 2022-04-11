using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutenticaçãoApi.Data
{
    public class UserDbContext: IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UserDbContext(DbContextOptions<UserDbContext> opts):base(opts)
        {
            
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
            //definir como os modelos serão criados
        //}

        //Define quais modelos serão persistidos
        //public DbSet<Usuarios> Usuarios { get; set;} 
    }
}
