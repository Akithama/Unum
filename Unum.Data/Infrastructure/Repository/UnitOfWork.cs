using System;
using System.Collections.Generic;
using System.Text;
using Unum.Data.Infrastructure.Interfaces;
using Unum.Data.Models;
using Unum.DataAccess.Infrastructure.Interfaces;

namespace Unum.DataAccess.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        private IQuestion _Question;
        private IAnswer _Answer;
        private IQuestionAnswer _QuestionAnswer;
        private ISurvey _Survey;
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

        public IQuestion Question
        {
            get
            {
                if (_Question == null)
                {
                    _Question = new QuestionRepository(_context);
                }

                return _Question;
            }
        }

        public IQuestionAnswer QuestionAnswer
        {
            get
            {
                if (_QuestionAnswer == null)
                {
                    _QuestionAnswer = new QuestionAnswerRepository(_context);
                }

                return _QuestionAnswer;
            }
        }

        public IAnswer Answer
        {
            get
            {
                if (_Answer == null)
                {
                    _Answer = new AnswerRepository(_context);
                }

                return _Answer;
            }
        }

        public ISurvey Survey
        {
            get
            {
                if (_Survey == null)
                {
                    _Survey = new SurveyRepository(_context);
                }

                return _Survey;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
