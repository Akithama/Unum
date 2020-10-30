using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unum.Data.Infrastructure.Repository;
using Unum.Data.Models;
using Unum.DataAccess.Infrastructure.Interfaces;

namespace Unum.DataAccess.Infrastructure.Repository
{
    public class QuestionAnswerRepository : Repository<QuestionAnswerMapping>, IQuestionAnswer
    {
        public QuestionAnswerRepository(ApplicationDBContext context) : base(context) { }

        public IEnumerable<QuestionAnswerMapping> GetAllByAnswerId(int questionId)
        {
            return Context.QuestionAnswerMapping.Where(x => x.QuestionId == questionId).ToList();
        }

        public IEnumerable<QuestionAnswerMapping> GetAllByQuestionId(int questionId)
        {
            return Context.QuestionAnswerMapping.Where(x => x.QuestionId == questionId).ToList();
           // var sss = Context.QuestionAnswerMapping
           //     .GroupBy(x => x.QuestionId)                
           //     .ToList();

           // var qqqq = Context.QuestionAnswerMapping.Where(x => x.QuestionId == questionId)
           //     .GroupBy(x => x.QuestionId)
           //     .Select(a => a.ToList().AsEnumerable()).ToList();
            
           //return qqqq;                                    
        }

        ///items.GroupBy(item => item.Order.Customer).Select(group => new { Customer = group.Key, Items = group.ToList()}).ToList()

        public IEnumerable<QuestionAnswerMapping> GetAllBySurveyId(int surveyId)
        {
            return Context.QuestionAnswerMapping.Where(x => x.SurveyId == surveyId).ToList();
        }
    }
}
