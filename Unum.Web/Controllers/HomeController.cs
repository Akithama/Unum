using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Unum.BusinessLogic.Service.Interfaces;
using Unum.Common;
using Unum.Data.Models;
using Unum.DataAccess.Infrastructure.Interfaces;
using Unum.Web.Extensions;
using Unum.Web.Models;

namespace Unum.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQuestionnaireService _QuestionnaireService;
        private IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IQuestionnaireService QuestionnaireService,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _QuestionnaireService = QuestionnaireService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetQuestion()
        {
            QuestionAnswerDto question = null;
            List<QuestionAnswerDto> questionAnswerList = _QuestionnaireService.PullQuestions().OrderBy(x=>x.SurveyId).ToList();

            question = questionAnswerList.First();
            questionAnswerList.Remove(question);
            HttpContext.Session.Set("QuestionAnswerDto", questionAnswerList);

            HttpContext.Session.Set("CurrentQuestionId", question.QuestionId);
            HttpContext.Session.Set("CurrentSurveyId", question.SurveyId);

            return View("Index", question);
        }

        [HttpPost]
        public IActionResult SaveAnswer(QuestionAnswerDto questionAnswerDto)
        {
            //save logic
            int questionId = HttpContext.Session.Get<int>("CurrentQuestionId");
            int surveyId = HttpContext.Session.Get<int>("CurrentSurveyId");

            UserResponse userResponse = new UserResponse()
            {
                SurveyId = surveyId,
                AnswerId = questionAnswerDto.SelectedAnswer,
                QuestionId = questionId,
                UserId = 1,
                IsValid = true
            };

            _unitOfWork.UserResponse.Add(userResponse);
            _unitOfWork.Save();

            //Get Question From Session
            List<QuestionAnswerDto> questionAnswerList = HttpContext.Session.Get<List<QuestionAnswerDto>>("QuestionAnswerDto");
            if (questionAnswerList.Count != 0)
            {
                QuestionAnswerDto question = questionAnswerList.FirstOrDefault();
                questionAnswerList.Remove(question);

                HttpContext.Session.Set("QuestionAnswerDto", questionAnswerList);
                HttpContext.Session.Set("CurrentQuestionId", question.QuestionId);
                HttpContext.Session.Set("CurrentSurveyId", question.SurveyId);

                return View("Index", question);
            }

            return View("Privacy");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
