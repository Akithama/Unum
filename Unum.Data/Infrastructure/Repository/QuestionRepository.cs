using System;
using System.Collections.Generic;
using System.Text;
using Unum.Data.Infrastructure.Interfaces;
using Unum.Data.Infrastructure.Repository;
using Unum.Data.Models;

namespace Unum.DataAccess.Infrastructure.Repository
{
    public class QuestionRepository: Repository<Questions>, IQuestion
    {
        public QuestionRepository(ApplicationDBContext context) : base(context) { }
    }
}
