using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unum.Common;

namespace Unum.BusinessLogic.Service.Interfaces
{
    public interface IQuestionnaireService
    {
        IEnumerable<QuestionAnswerDto> PullQuestions();
    }
}
