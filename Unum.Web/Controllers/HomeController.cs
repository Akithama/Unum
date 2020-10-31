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
        public IActionResult GetQuestion()
        {
            QuestionAnswerDto question = null;
            var questionAnswerList = _QuestionnaireService.PullQuestions();
            //TempData["QuestionAnswerList"] = questionAnswerList;  not working
            //var QuestionAnswerListT = TempData.Peek("Message");

            //need to add Extention
            //https://stackoverflow.com/questions/56833328/how-to-store-list-object-in-session-variable-using-asp-net-core-and-how-to-fetc
            question = questionAnswerList.First();

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
