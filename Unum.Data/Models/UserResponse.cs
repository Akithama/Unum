using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Unum.Data.Models;

namespace Unum.Data.Modelss
{
    public class UserResponse
    {
        [Key]
        public int UserResponseId { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int SurveyId { get; set; }
        public bool? IsValid { get; set; }

        public Answers Answer { get; set; }
        public Questions Question { get; set; }
        public Survey Survey { get; set; }
        public User User { get; set; }
    }
}
