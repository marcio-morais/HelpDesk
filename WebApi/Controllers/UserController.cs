using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(UserManager<ApplicationUser> userManager
                            , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AdicionarUsuario")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.senha))
                return Ok("Dados insuficiente.");

            var user = new ApplicationUser
            {
                Email = login.email
            };

            var result = await _userManager.CreateAsync(user, login.senha);

            if (result.Errors.Any())
                return Ok(result.Errors);

            //geracao de confirmaçao caso precise
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            //retorno do email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var response_retorn = await _userManager.ConfirmEmailAsync(user, code);

            if (response_retorn.Succeeded)
                return Ok("Usuário adicionado");

            return Ok("Falha ao criar o usuáiro.");
        }
    }
}