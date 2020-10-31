using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Unum.BusinessLogic.Service.Interfaces;
using Unum.Common;
using Unum.Web.Models;

namespace Unum.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQuestionnaireService _QuestionnaireService;

        public HomeController(ILogger<HomeController> logger, IQuestionnaireService QuestionnaireService)
        {
            _logger = logger;
            _QuestionnaireService = QuestionnaireService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetQuestion(int questionId = 1)
        {
            QuestionAnswerDto question = null;
            if (questionId != 0)
            {
                question = question1(questionId);
            }
            else
            {
                question = question1(questionId);
            }
            return View("Index", question);

        }

        [HttpPost]
        public IActionResult SaveAnswer(QuestionAnswerDto questionAnswerDto)
        {
            //save logic
            //sessions, keep list<QuestionAnswerDto>

            QuestionAnswerDto question = question1(2);
            return View("Index", question);
        }


        public QuestionAnswerDto question1(int questionId)
        {
            return _QuestionnaireService.PullQuestions().Where(x => x.QuestionId == questionId).First();
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
