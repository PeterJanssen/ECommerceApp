using System.Threading.Tasks;
using API.DTO.AccountDTO;
using API.Extensions;
using AutoMapper;
using Core.Entities.AccountEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AccountControllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/account/[controller]")]
    public class AddressController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AddressController(
            UserManager<AppUser> userManager,
            IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        /// <response code="200">Returns the current logged in user's address</response>
        /// <response code="204">Returns if the current logged in user does not have an address</response>
        /// <response code="401">Returns if the User is not logged in</response>
        [Authorize]
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AddressDTO>> getUserAddress()
        {
            var user = await _userManager.FindUserByClaimsPrincipleWithAddressAsync(User);

            return _mapper.Map<Address, AddressDTO>(user.Address);
        }

        /// <response code="200">Returns the current logged in user's updated address</response>
        /// <response code="401">Returns if the User is not logged in</response>
        [Authorize]
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AddressDTO>> UpdateUserAddress(AddressDTO addressDTO)
        {
            var user = await _userManager.FindUserByClaimsPrincipleWithAddressAsync(User);
            user.Address = _mapper.Map<AddressDTO, Address>(addressDTO);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok(_mapper.Map<Address, AddressDTO>(user.Address));
            }

            return BadRequest("Updating user failed");
        }

    }
}