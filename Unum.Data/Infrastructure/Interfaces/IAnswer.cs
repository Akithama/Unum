using System;
using System.Collections.Generic;
using System.Text;
using Unum.Data.Infrastructure.Interfaces;
using Unum.Data.Models;

namespace Unum.DataAccess.Infrastructure.Interfaces
{
    public interface IAnswer : IRepository<Answers>
    {
        //List<Answers> GetAllBySurveyId(int surveyId);
    }
}
