using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Unum.Data.Modelss;

namespace Unum.Data.Models
{
    public class Survey
    {
        [Key]
        public int SurveyId { get; set; }
        public string SurvayName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsValid { get; set; }

        public ICollection<UserResponse> UserResponse { get; set; }
    }
}
