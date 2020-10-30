using System;
using System.Collections.Generic;
using System.Text;
using Unum.Data.Infrastructure.Interfaces;
using Unum.Data.Models;

namespace Unum.DataAccess.Infrastructure.Interfaces
{
    public interface IQuestionAnswer : IRepository<QuestionAnswerMapping>
    {
        IEnumerable<QuestionAnswerMapping> GetAllBySurveyId(int surveyId);
        IEnumerable<QuestionAnswerMapping> GetAllByQuestionId(int questionId);
        IEnumerable<QuestionAnswerMapping> GetAllByAnswerId(int questionId);
    }
}
