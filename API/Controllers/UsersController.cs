using API.EFModels;
using API.EFModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //POST ByAuthorizatedData(Login, Password), POST Registration by fill blank, PUT Update by UserId
        private readonly BookstoreChainContext LocalContext = new();

        [HttpPost("Registration")]
        public ActionResult<UserRegistrationDTO> UserRegistration(UserRegistrationDTO userReg)
        {
            if (userReg is null) return BadRequest();
            List<User> users = LocalContext.Users.ToList();
            foreach (var userInList in users)
            {
                if (userInList.UserEmail == userReg.UserEmail)
                    return Conflict("Пользователь с такой почтой уже существует.");
                else if (userInList.UserLogin == userReg.UserLogin)
                    return Conflict("Пользователь с таким логином уже существует.");
                else if (userInList.UserNumPhone == userReg.UserNumPhone)
                    return Conflict("Пользователь с таким номером телефона уже существует.");

            }
            LocalContext.Users.Add(UserRegistrationDTO.UserConverter(userReg));
            try
            {
                LocalContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сообщение исключения  {ex.Message}");
                Console.WriteLine($"Внутреннее сообщение исключения {ex.InnerException}");
                return BadRequest("Что-то пошло не так");
            }
            return Ok();
        }

        [HttpPost("Authorization")]
        public ActionResult<UserRegistrationDTO> UserAuthorization(UserDTO userDTO)
        {
            User? user = LocalContext.Users.Where(x=>x.UserLogin == userDTO.UserLogin && x.UserPassword == userDTO.UserPassword).FirstOrDefault();
            return user is null ? NotFound("Неправильный пароль или логин.") : Ok(UserRegistrationDTO.UserConverter(user));
        }

        [HttpPut("EditProfile")]
        public ActionResult<UserRegistrationDTO> UserUpdate(UserRegistrationDTO user)
        {
            if (user is null) return BadRequest();

            var existingUser = LocalContext.Users.FirstOrDefault(x => x.UserId == user.UserId);
            if (existingUser is null) return NotFound("Такого пользователя не существует.");
            existingUser = new User
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserSurname = user.UserSurname,
                UserPatronymic = user.UserPatronymic,
                UserNumPhone = user.UserNumPhone,
                UserLogin = user.UserLogin,
                UserPassword = user.UserPassword,
                UserEmail = user.UserEmail,
                UserDateBirth = DateOnly.FromDateTime(Convert.ToDateTime(user.UserDateBirth))
            };
            try
            {
                LocalContext.SaveChanges();
                return Ok(UserRegistrationDTO.UserConverter(user));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Сообщение исключения {ex.Message}");
                Console.WriteLine($"Внутреннее сообщения исключения {ex.InnerException}");
                return BadRequest("Что-то пошло не так");
            }
        }
        [HttpGet]
        public ActionResult<UserRegistrationDTO> GetById(int idUser)
        {
            var user = LocalContext.Users.FirstOrDefault(x => x.UserId == idUser);
            if (user is null) return NotFound("Такого пользователя не существует.");
            return Ok(UserRegistrationDTO.UserConverter(user));
        }
        [HttpDelete]
        public ActionResult<UserRegistrationDTO> DeleteById(int idUser)
        {
            var user = LocalContext.Users.FirstOrDefault(x => x.UserId == idUser);
            if (user is null) return NotFound("Такого пользователя не существует.");
            LocalContext.Users.Remove(user);
            try
            {
                LocalContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сообщение исключения {ex.Message}");
                Console.WriteLine($"Внутреннее сообщения исключения {ex.InnerException}");
                return BadRequest("Что-то пошло не так");
            }
            return Ok(UserRegistrationDTO.UserConverter(user));
        }

    }
}
