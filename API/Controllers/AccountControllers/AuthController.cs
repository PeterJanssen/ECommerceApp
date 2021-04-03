using AutoMapper;
using Core.Entities.AccountEntities;
using Core.Interfaces.Services.AccountServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AccountControllers
{
    [Produces("application/json")]
    public class AuthController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signingManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signingManager,
            ITokenService tokenService,
            IMapper mapper)
        {
            _signingManager = signingManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _userManager = userManager;
        }
    }
}