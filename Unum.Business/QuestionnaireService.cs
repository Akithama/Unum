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
        private IEnumerable<QuestionAnswerDto> questionList;

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

            this.questionList = QuestionAnswerList; // for one question request without db call
            return QuestionAnswerList;
        }

        public QuestionAnswerDto GetQuestion(int questionId)
        {
            return questionList.Where(x => x.QuestionId == questionId).First();
        }
    }
}






//List<QuestionAnswerDto> QuestionAnswerList = new List<QuestionAnswerDto>();
//var surveyList = _unitOfWork.Survey.GetAll();

//            foreach (var survey in surveyList)
//            {
//                List<Answers> AnswerList = new List<Answers>();
//var questionsMapperList = _unitOfWork.QuestionAnswer.GetAllBySurveyId(survey.SurveyId);
//                foreach (var question in questionsMapperList)
//                {
//                    //var questionsList= _unitOfWork.QuestionAnswer.GetAllByQuestionId(question.QuestionId);
//                    Answers answer = new Answers()
//                    {
//                        AnswerId = question.AnswerId,
//                        AnswerDescription = _unitOfWork.Answer.GetById(question.AnswerId).AnswerDescription,
//                        Points = _unitOfWork.Answer.GetById(question.AnswerId).Points
//                    };
//AnswerList.Add(answer);

//                    QuestionAnswerDto questionAnswerList = new QuestionAnswerDto()
//                    {
//                        QuestionAnswerMappingId = question.QuestionAnswerMappingId,
//                        QuestionId = question.QuestionId,
//                        Description = _unitOfWork.Question.GetById(question.QuestionId).Description,
//                        Answers = AnswerList
//                    };
//QuestionAnswerList.Add(questionAnswerList);
//                }                
//            }

//            return QuestionAnswerList;