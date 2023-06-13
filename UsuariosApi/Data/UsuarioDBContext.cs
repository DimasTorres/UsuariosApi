using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models;

namespace UsuariosApi.Data
{
    public class UsuarioDBContext : IdentityDbContext<Usuario>
    {
        public UsuarioDBContext(DbContextOptions<UsuarioDBContext> options) : base(options) { }
    }
}
