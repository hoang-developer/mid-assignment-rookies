using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using API.Data.Entities;

namespace API.Data.Entities
{
   
        public class UserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
