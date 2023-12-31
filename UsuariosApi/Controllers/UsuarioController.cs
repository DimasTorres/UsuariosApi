﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastro")]
        [Authorize]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            await _usuarioService.CadastraAsync(dto);
            return Ok("Usuário cadastrado com sucesso!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDto dto)
        {
            var token = await _usuarioService.LoginAsync(dto);
            return Ok(token);
        }
    }
}
