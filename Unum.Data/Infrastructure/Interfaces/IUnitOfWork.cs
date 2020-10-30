using System;
using System.Collections.Generic;
using System.Text;
using Unum.Data.Infrastructure.Interfaces;

namespace Unum.DataAccess.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IQuestion Question { get; }

        IAnswer Answer { get; }

        IQuestionAnswer QuestionAnswer { get; }

        ISurvey Survey { get; }

        void Save();
    }
}
