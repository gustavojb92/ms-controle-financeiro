
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ms_controle_financeiro.Interfaces;
using ms_controle_financeiro.Model.DTOs.User;


namespace ms_controle_financeiro.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static IUser _iUser;

        public UserController(IUser user)
        {
            _iUser = user;
        }

        public static IEnumerable<String> messageException(Result result)
        {
            return result.Reasons.Select(reason => reason.Message);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _iUser.GetAll();
            return users == null ? NotFound("Não foram encontrados usuários cadastrados") : Ok(users);
        }

        [HttpGet("{ID}")]
        public IActionResult Get(int ID)
        {
            var user = _iUser.GetById(ID);
            return user == null ? BadRequest(error: "Não encontrado") : Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddUserDTO userDTO)
        {
            var user = _iUser.Post(userDTO);
            return user == null ?
            BadRequest("Não foi possivel salvar")
            : Ok(user);

        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] UserLoginDTO userDTO)
        {
            var user = _iUser.Login(userDTO);
            return user ?
             Ok()
            :
            BadRequest("Login Inválido");

        }



        [HttpPut("{ID}")]
        public IActionResult Put(int ID, AddUserDTO userDto)
        {

            var user = _iUser.Put(ID, userDto);

            if (user == null)
            {
                return BadRequest("Falha ao atualizar usuário.");
            }
            return Ok(user);

        }

        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            var user = _iUser.Delete(ID);
            return user ? NoContent() : BadRequest(error: "Não encontrado");
        }
    }
}