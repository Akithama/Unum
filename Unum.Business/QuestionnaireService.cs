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

        public IEnumerable<QuestionAnswerDto> PullQuestions()
        {
            var ssss = _unitOfWork.QuestionAnswer.GetAllBySurveyId(1);


            List<QuestionAnswerDto> QuestionAnswerList = new List<QuestionAnswerDto>();

            List<Questions> questionList = new List<Questions>();
            var questions = _unitOfWork.Question.GetAll();

            foreach (var item in questions)
            {
                var QuestionAnswersList = _unitOfWork.QuestionAnswer.GetAllByQuestionId(item.QuestionId);
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

                QuestionAnswerDto questionDto = new QuestionAnswerDto()
                {
                    QuestionId = item.QuestionId,
                    Description = item.Description,
                    IsValid = item.IsValid,
                    Answers = answerDtoList
                };

                QuestionAnswerList.Add(questionDto);
            }
            return QuestionAnswerList;
        }

    }
}
