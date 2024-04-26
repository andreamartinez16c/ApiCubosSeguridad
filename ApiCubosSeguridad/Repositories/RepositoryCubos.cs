using ApiCubosSeguridad.Data;
using ApiCubosSeguridad.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiCubosSeguridad.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;
        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }

        public async Task<int> MaxIdCuboAsync()
        {
            if (this.context.Cubos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Cubos.Max(x => x.IdCubo) + 1;
            }
        }

        public async Task<List<Cubo>> GetCubosAsync()
        {
            return await this.context.Cubos.ToListAsync();
        }

        public async Task<List<Cubo>> GetCubosByMarcaAsync(string marca)
        {
            var response = from datos in this.context.Cubos
                           where datos.Marca == marca
                           select datos;
            return await response.ToListAsync();
        }

        public async Task<List<string>> GetMarcasCubo()
        {
            var response = (from datos in this.context.Cubos
                            select datos.Marca).Distinct();

            return await response.ToListAsync();

        }
    }
}
