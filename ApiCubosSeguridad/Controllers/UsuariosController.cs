using ApiCubosSeguridad.Models;
using ApiCubosSeguridad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Newtonsoft.Json;


namespace ApiCubosSeguridad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        RepositoryUsuarios repo;
        public UsuariosController(RepositoryUsuarios repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<CompraCubo>>> PedidosUsuario()
        {
            Usuario user = await this.GetUser();
            return await this.repo.PedidosUsuarioAsync(user.IdUsuario);
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult<Usuario>> PerfilUsuario()
        {
            Usuario user = await this.GetUser();
            return await this.repo.FindUsuarioAsync(user.IdUsuario);
        }

        private async Task<Usuario> GetUser()
        {
            Claim claimUser = HttpContext.User.Claims
                .SingleOrDefault(x => x.Type == "UserData");
            string jsonUser = claimUser.Value;
            Usuario user = JsonConvert.DeserializeObject<Usuario>(jsonUser);
            return user;
        }

    }
}
