using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Unum.Data.Models;

namespace Unum.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public int MoodleUserId { get; set; }

        public ICollection<UserResponse> UserResponse { get; set; }
    }
}
