using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastraUsuarioService
    {
        private readonly IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public CadastraUsuarioService(IMapper mapper, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CadastraAsync(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            IdentityResult identityResult = await _userManager.CreateAsync(usuario, dto.Password);

            if (!identityResult.Succeeded)
                throw new ApplicationException("Falha ao cadastrar usuário.");
        }
    }
}
