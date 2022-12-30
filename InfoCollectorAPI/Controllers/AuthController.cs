using InfoCollectorAPI.Models;
using InfoCollectorAPI.MongoDB;
using Microsoft.AspNetCore.Mvc;
using BC = BCrypt.Net.BCrypt;

namespace InfoCollectorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMongoRepository<User> _userRepository;

        public AuthController(IMongoRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost(Name = "Login")]
        public async Task<UserLoginModel> Login([FromBody]LoginModel model)
        {
            var result = new UserLoginModel {  Username = model.Username };
            var user = await _userRepository.FindOneAsync(x => x.Username == model.Username);

            if (user != null && BC.Verify(model.Password, user.Password))
            {
                byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                byte[] key = Guid.NewGuid().ToByteArray();
                result.Token = Convert.ToBase64String(time.Concat(key).ToArray());
            }
            return result;
        }
    }
}
