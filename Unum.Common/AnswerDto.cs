using System;
using System.Collections.Generic;
using System.Text;

namespace Unum.Common
{
    public class AnswerDto
    {
        public int AnswerId { get; set; }
        public string AnswerDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Points { get; set; }
    }
}
