using CardBattle.Application.Services;
using CardBattle.Application.ViewModels;
using CardBattle.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CardBattle.Controllers
{
    [Route("api/v1/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersRepository _playersRepository;

        public PlayersController(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository ?? throw new ArgumentNullException(nameof(playersRepository));
        }

        [Authorize]
        [HttpPost]
        [Route("RegisterPlayer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> RegisterPlayer([FromBody] PlayersViewModel playersViewModel)
        {
            try
            {
                var player = new Players(playersViewModel.NomeDeUsuario, playersViewModel.Senha, playersViewModel.Email, playersViewModel.NomeDoPersonagem);

                _playersRepository.Add(player);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            var user = new Players(loginViewModel.Email, loginViewModel.Senha);

            var result = _playersRepository.Get(user);

            if (result == null)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }

            var token = TokenService.GenerateToken(new Players());
            return Ok(token);
        }



    }
}
