using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Unum.Data.Models
{
    public class Answers
    {
        [Key]
        public int AnswerId { get; set; }
        public string AnswerDescription { get; set; }
        public int? Points { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsValid { get; set; }        

        public ICollection<QuestionAnswerMapping> QuestionAnswerMapping { get; set; }
        public ICollection<UserResponse> UserResponse { get; set; }
    }
}
