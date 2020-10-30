using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Unum.Data.Models
{
    public class QuestionAnswerMapping
    {
        [Key]
        public int QuestionAnswerMappingId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int SurveyId { get; set; }
        public bool IsValid { get; set; }

        public Answers Answer { get; set; }
        public Questions Question { get; set; }
        public Survey Survey { get; set; }
    }
}
