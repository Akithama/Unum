using System;
using System.Collections.Generic;
using System.Text;
using Unum.Data.Models;

namespace Unum.Common
{
    public class QuestionAnswerDto
    {
        public int QuestionAnswerMappingId { get; set; }

        public int QuestionId { get; set; }
        public string Description { get; set; }
        public bool? IsValid { get; set; }

        public IEnumerable<Answers> Answers { get; set; }


    }
}
