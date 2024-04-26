using ApiCubosSeguridad.Data;
using ApiCubosSeguridad.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


namespace ApiCubosSeguridad.Repositories
{
    public class RepositoryUsuarios
    {
        private CubosContext context;
        public RepositoryUsuarios(CubosContext context)
        {
            this.context = context;
        }

        public async Task<Usuario> FindUsuarioAsync(int id)
        {
            return await this.context.Usuarios
                .FirstOrDefaultAsync(x => x.IdUsuario == id);
        }

        public async Task<Usuario> LogInAsync
            (string email, string password)
        {
            return await this.context.Usuarios
                .FirstOrDefaultAsync(x => x.Email == email
                && x.Password == password);
        }


        public async Task<List<CompraCubo>> PedidosUsuarioAsync(int id)
        {
            return await this.context.CompraCubos
                .Where(x => x.IdUsuario == id).ToListAsync();
        }


    }
}
