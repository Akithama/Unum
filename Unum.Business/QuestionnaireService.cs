using System;
using System.Collections;
using System.Collections.Generic;
using Unum.BusinessLogic.Service.Interfaces;
using Unum.Common;
using Unum.Data.Models;
using Unum.DataAccess.Infrastructure.Interfaces;
using System.Linq;

namespace Unum.Business
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private IUnitOfWork _unitOfWork;

        public QuestionnaireService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public QuestionDto GetQuestionById(int questionId)
        {
            var quest = _unitOfWork.Question.GetById(questionId);
            QuestionDto questionDto = new QuestionDto()
            {
                QuestionId = quest.QuestionId,
                Description = quest.Description,
                IsValid = quest.IsValid
            };

            return questionDto;
        }

        public IEnumerable<QuestionAnswerDto> PullQuestions()
        {
            List<QuestionAnswerDto> QuestionAnswerList = new List<QuestionAnswerDto>();
            List<QuestionAnswerMapping> questionAnswerMapping = _unitOfWork.QuestionAnswer.GetAll().Where(x =>(x.SurveyId == 1) || (x.SurveyId == 2)).ToList();

            var QuestionList= questionAnswerMapping.GroupBy(x => x.QuestionId).Select(a => a.FirstOrDefault()).ToList();

            foreach (var question in QuestionList)
            {
                var QuestionAnswersList = _unitOfWork.QuestionAnswer.GetAllByQuestionId(question.QuestionId);
                List<Answers> answerDtoList = new List<Answers>();
                foreach (var ques in QuestionAnswersList)
                {
                    Answers answerDto = new Answers()
                    {
                        AnswerId = ques.AnswerId,
                        AnswerDescription = _unitOfWork.Answer.GetById(ques.AnswerId).AnswerDescription,
                        Points = _unitOfWork.Answer.GetById(ques.AnswerId).Points
                    };
                    answerDtoList.Add(answerDto);
                }

                var quest = _unitOfWork.Question.GetById(question.QuestionId);

                QuestionAnswerDto questionDto = new QuestionAnswerDto()
                {
                    QuestionId = quest.QuestionId,
                    Description = quest.Description,
                    IsValid = quest.IsValid,
                    Answers = answerDtoList,
                    SurveyId = question.SurveyId
                };
                QuestionAnswerList.Add(questionDto);
            }
            return QuestionAnswerList;
        }
    }
}
