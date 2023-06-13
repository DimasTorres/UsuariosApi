using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private CadastraUsuarioService _cadastraUsuarioService;

        public UsuarioController(CadastraUsuarioService cadastraUsuarioService)
        {
            _cadastraUsuarioService = cadastraUsuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            await _cadastraUsuarioService.CadastraAsync(dto);
            return Ok("Usuário cadastrado com sucesso!");
        }
    }
}
