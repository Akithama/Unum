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
        private IUser _user;
        private IUserResponse _userResponse;

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
        public IUser User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }

                return _user;
            }
        }

        public IUserResponse UserResponse
        {
            get
            {
                if (_userResponse == null)
                {
                    _userResponse = new UserResponseRepository(_context);
                }

                return _userResponse;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
