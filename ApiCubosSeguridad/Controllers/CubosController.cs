using ApiCubosSeguridad.Models;
using ApiCubosSeguridad.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCubosSeguridad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubosController : ControllerBase
    {
        RepositoryCubos repo;
        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cubo>>> Cubos()
        {
            return await this.repo.GetCubosAsync();
        }

        [HttpGet]
        [Route("{marca}")]
        public async Task<ActionResult<Cubo>> CubosByMarca(string marca)
        {
            var marcas = await this.repo.GetCubosByMarcaAsync(marca);
            return Ok(marcas);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<string>>> MarcasCubo()
        {
            return await this.repo.GetMarcasCubo();
        }
    }
}
