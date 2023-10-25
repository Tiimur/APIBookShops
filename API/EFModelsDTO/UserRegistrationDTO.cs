using API.Converters;
using API.EFModels;
using Newtonsoft.Json;

namespace API.EFModelsDTO
{
    public class UserRegistrationDTO
    {
        public int UserId { get; set; }
        public string UserSurname { get; set; } = "";
        public string UserName { get; set; } = "";
        public string UserPatronymic { get; set; } = "";
        public string UserNumPhone { get; set; } = "";
        public string? UserLogin { get; set; }
        public string UserPassword { get; set; } = "";
        public string? UserEmail { get; set; }

        [JsonConverter(typeof(DateOnlyConverter))]
        public string? UserDateBirth { get; set; }

        public static User UserConverter(UserRegistrationDTO userRegistrationDTO)
        {
            User user = new()
            {
                UserName = userRegistrationDTO.UserName,
                UserSurname = userRegistrationDTO.UserSurname,
                UserPatronymic = userRegistrationDTO.UserPatronymic,
                UserNumPhone = userRegistrationDTO.UserNumPhone,
                UserLogin = userRegistrationDTO.UserLogin,
                UserPassword = userRegistrationDTO.UserPassword,
                UserEmail = userRegistrationDTO.UserEmail,
                UserDateBirth = DateOnly.FromDateTime(Convert.ToDateTime(userRegistrationDTO.UserDateBirth)),
                UserIdRole = 3
            };
            return user;
        }

        public static UserRegistrationDTO UserConverter(User user)
        {
            UserRegistrationDTO userRegistrationDTO = new()
            {
                UserId = user.UserId,
                UserSurname = user.UserSurname,
                UserName = user.UserName,
                UserPatronymic = user.UserPatronymic,
                UserNumPhone = user.UserNumPhone,
                UserLogin = user.UserLogin,
                UserPassword = user.UserPassword,
                UserEmail = user.UserEmail,
                UserDateBirth = user.UserDateBirth.ToString(),
            };

            return userRegistrationDTO;
        }
    }
}
