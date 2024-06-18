using LXP.Common.Entities;
using LXP.Common.ViewModels.FeedbackResponseViewModel;
using LXP.Data.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LXP.Data.Repository
{
    public class FeedbackResponseDetailsRepository : IFeedbackResponseDetailsRepository
    {
        private readonly LXPDbContext _context;

        public FeedbackResponseDetailsRepository(LXPDbContext context)
        {
            _context = context;
        }

        public List<QuizFeedbackResponseDetailsViewModel> GetQuizFeedbackResponses(Guid quizId)
        {
            return _context.Feedbackresponses
                .Include(r => r.QuizFeedbackQuestion)
                .Include(r => r.QuizFeedbackQuestion.Feedbackquestionsoptions)
                .Where(r => r.QuizFeedbackQuestion.QuizId == quizId)
                .Select(r => new QuizFeedbackResponseDetailsViewModel
                {
                    QuizFeedbackQuestionId = r.QuizFeedbackQuestionId ?? Guid.Empty,
                    LearnerId = r.LearnerId,
                    Question = r.QuizFeedbackQuestion.Question,
                    QuestionType = r.QuizFeedbackQuestion.QuestionType,
                    Response = r.Response,
                    OptionText = r.OptionId.HasValue
                        ? r.QuizFeedbackQuestion.Feedbackquestionsoptions
                            .FirstOrDefault(o => o.FeedbackQuestionOptionId == r.OptionId.Value).OptionText
                        : null
                })
                .ToList();
        }

        public List<TopicFeedbackResponseDetailsViewModel> GetTopicFeedbackResponses(Guid topicId)
        {
            return _context.Feedbackresponses
                .Include(r => r.TopicFeedbackQuestion)
                .Include(r => r.TopicFeedbackQuestion.Feedbackquestionsoptions)
                .Where(r => r.TopicFeedbackQuestion.TopicId == topicId)
                .Select(r => new TopicFeedbackResponseDetailsViewModel
                {
                    TopicFeedbackQuestionId = r.TopicFeedbackQuestionId ?? Guid.Empty,
                    LearnerId = r.LearnerId,
                    Question = r.TopicFeedbackQuestion.Question,
                    QuestionType = r.TopicFeedbackQuestion.QuestionType,
                    Response = r.Response,
                    OptionText = r.OptionId.HasValue
                        ? r.TopicFeedbackQuestion.Feedbackquestionsoptions
                            .FirstOrDefault(o => o.FeedbackQuestionOptionId == r.OptionId.Value).OptionText
                        : null
                })
                .ToList();
        }

        public List<QuizFeedbackResponseDetailsViewModel> GetQuizFeedbackResponsesByLearner(Guid quizId, Guid learnerId)
        {
            return _context.Feedbackresponses
                .Include(r => r.QuizFeedbackQuestion)
                .Include(r => r.QuizFeedbackQuestion.Feedbackquestionsoptions)
                .Where(r => r.QuizFeedbackQuestion.QuizId == quizId && r.LearnerId == learnerId)
                .Select(r => new QuizFeedbackResponseDetailsViewModel
                {
                    QuizFeedbackQuestionId = r.QuizFeedbackQuestionId ?? Guid.Empty,
                    LearnerId = r.LearnerId,
                    Question = r.QuizFeedbackQuestion.Question,
                    QuestionType = r.QuizFeedbackQuestion.QuestionType,
                    Response = r.Response,
                    OptionText = r.OptionId.HasValue
                        ? r.QuizFeedbackQuestion.Feedbackquestionsoptions
                            .FirstOrDefault(o => o.FeedbackQuestionOptionId == r.OptionId.Value).OptionText
                        : null
                })
                .ToList();
        }

        public List<TopicFeedbackResponseDetailsViewModel> GetTopicFeedbackResponsesByLearner(Guid topicId, Guid learnerId)
        {
            return _context.Feedbackresponses
                .Include(r => r.TopicFeedbackQuestion)
                .Include(r => r.TopicFeedbackQuestion.Feedbackquestionsoptions)
                .Where(r => r.TopicFeedbackQuestion.TopicId == topicId && r.LearnerId == learnerId)
                .Select(r => new TopicFeedbackResponseDetailsViewModel
                {
                    TopicFeedbackQuestionId = r.TopicFeedbackQuestionId ?? Guid.Empty,
                    LearnerId = r.LearnerId,
                    Question = r.TopicFeedbackQuestion.Question,
                    QuestionType = r.TopicFeedbackQuestion.QuestionType,
                    Response = r.Response,
                    OptionText = r.OptionId.HasValue
                        ? r.TopicFeedbackQuestion.Feedbackquestionsoptions
                            .FirstOrDefault(o => o.FeedbackQuestionOptionId == r.OptionId.Value).OptionText
                        : null
                })
                .ToList();
        }
    }
}