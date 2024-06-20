using System;
using System.Collections.Generic;
using System.Linq;
using LXP.Common.Entities;
using LXP.Data.IRepository;

namespace LXP.Data.Repository
{
    public class FeedbackResponseRepository : IFeedbackResponseRepository
    {
        private readonly LXPDbContext _context;

        public FeedbackResponseRepository(LXPDbContext context)
        {
            _context = context;
        }

        public Quizfeedbackquestion GetQuizFeedbackQuestion(Guid quizFeedbackQuestionId)
        {
            return _context.Quizfeedbackquestions.FirstOrDefault(q =>
                q.QuizFeedbackQuestionId == quizFeedbackQuestionId
            );
        }

        public Topicfeedbackquestion GetTopicFeedbackQuestion(Guid topicFeedbackQuestionId)
        {
            return _context.Topicfeedbackquestions.FirstOrDefault(q =>
                q.TopicFeedbackQuestionId == topicFeedbackQuestionId
            );
        }

        public Learner GetLearner(Guid learnerId)
        {
            return _context.Learners.FirstOrDefault(l => l.LearnerId == learnerId);
        }

        public Feedbackresponse GetExistingQuizFeedbackResponse(
            Guid quizFeedbackQuestionId,
            Guid learnerId
        )
        {
            return _context.Feedbackresponses.FirstOrDefault(r =>
                r.QuizFeedbackQuestionId == quizFeedbackQuestionId && r.LearnerId == learnerId
            );
        }

        public Feedbackresponse GetExistingTopicFeedbackResponse(
            Guid topicFeedbackQuestionId,
            Guid learnerId
        )
        {
            return _context.Feedbackresponses.FirstOrDefault(r =>
                r.TopicFeedbackQuestionId == topicFeedbackQuestionId && r.LearnerId == learnerId
            );
        }

        public void AddFeedbackResponse(Feedbackresponse feedbackResponse)
        {
            _context.Feedbackresponses.Add(feedbackResponse);
            _context.SaveChanges();
        }

        public void AddFeedbackResponses(IEnumerable<Feedbackresponse> feedbackResponses)
        {
            _context.Feedbackresponses.AddRange(feedbackResponses);
            _context.SaveChanges();
        }

        //public LearnerProfile GetLearnerProfile(Guid learnerId)
        //{
        //    return _context.LearnerProfiles.FirstOrDefault(p => p.LearnerId == learnerId);
        //}

        public Guid? GetOptionIdByText(Guid questionId, string optionText)
        {
            var option =
                _context.Feedbackquestionsoptions.FirstOrDefault(o =>
                    o.QuizFeedbackQuestionId == questionId
                    && o.OptionText.ToLower() == optionText.ToLower()
                )
                ?? _context.Feedbackquestionsoptions.FirstOrDefault(o =>
                    o.TopicFeedbackQuestionId == questionId
                    && o.OptionText.ToLower() == optionText.ToLower()
                );

            return option?.FeedbackQuestionOptionId;
        }

        //new bug fix
        public void DeleteFeedbackResponsesByQuizQuestionId(Guid quizFeedbackQuestionId)
        {
            var responses = _context
                .Feedbackresponses.Where(r => r.QuizFeedbackQuestionId == quizFeedbackQuestionId)
                .ToList();
            _context.Feedbackresponses.RemoveRange(responses);
            _context.SaveChanges();
        }

        public void DeleteFeedbackResponsesByTopicQuestionId(Guid topicFeedbackQuestionId)
        {
            var responses = _context
                .Feedbackresponses.Where(r => r.TopicFeedbackQuestionId == topicFeedbackQuestionId)
                .ToList();
            _context.Feedbackresponses.RemoveRange(responses);
            _context.SaveChanges();
        }

        public IEnumerable<Guid> GetQuizIdsForLearner(Guid learnerId)
        {
            // Query to get quiz IDs for the learner
            return _context
                .Quizfeedbackquestions.Where(q =>
                    q.Feedbackresponses.Any(r => r.LearnerId == learnerId)
                )
                .Select(q => q.QuizId)
                .Distinct()
                .ToList();
        }

        public IEnumerable<Guid> GetTopicIdsForLearner(Guid learnerId)
        {
            // Query to get topic IDs for the learner
            return _context
                .Topicfeedbackquestions.Where(q =>
                    q.Feedbackresponses.Any(r => r.LearnerId == learnerId)
                )
                .Select(q => q.TopicId)
                .Distinct()
                .ToList();
        }

        public bool IsQuizFeedbackGivenByLearner(Guid learnerId, Guid quizId)
        {
            var quizFeedbackQuestions = _context
                .Quizfeedbackquestions.Where(q => q.QuizId == quizId)
                .Select(q => q.QuizFeedbackQuestionId)
                .ToList();

            var learnerResponses = _context
                .Feedbackresponses.Where(r =>
                    r.LearnerId == learnerId
                    && quizFeedbackQuestions.Contains(r.QuizFeedbackQuestionId.Value)
                )
                .ToList();

            return learnerResponses.Count == quizFeedbackQuestions.Count;
        }

        public bool IsTopicFeedbackGivenByLearner(Guid learnerId, Guid topicId)
        {
            var topicFeedbackQuestions = _context
                .Topicfeedbackquestions.Where(q => q.TopicId == topicId)
                .Select(q => q.TopicFeedbackQuestionId)
                .ToList();

            var learnerResponses = _context
                .Feedbackresponses.Where(r =>
                    r.LearnerId == learnerId
                    && topicFeedbackQuestions.Contains(r.TopicFeedbackQuestionId.Value)
                )
                .ToList();

            return learnerResponses.Count == topicFeedbackQuestions.Count;
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using LXP.Common.Entities;
//using LXP.Data.IRepository;

//namespace LXP.Data.Repository
//{
//    public class FeedbackResponseRepository : IFeedbackResponseRepository
//    {
//        private readonly LXPDbContext _context;

//        public FeedbackResponseRepository(LXPDbContext context)
//        {
//            _context = context;
//        }

//        public Quizfeedbackquestion GetQuizFeedbackQuestion(Guid quizFeedbackQuestionId)
//        {
//            return _context.Quizfeedbackquestions.FirstOrDefault(q =>
//                q.QuizFeedbackQuestionId == quizFeedbackQuestionId
//            );
//        }

//        public Topicfeedbackquestion GetTopicFeedbackQuestion(Guid topicFeedbackQuestionId)
//        {
//            return _context.Topicfeedbackquestions.FirstOrDefault(q =>
//                q.TopicFeedbackQuestionId == topicFeedbackQuestionId
//            );
//        }

//        public Learner GetLearner(Guid learnerId)
//        {
//            return _context.Learners.FirstOrDefault(l => l.LearnerId == learnerId);
//        }

//        public Feedbackresponse GetExistingQuizFeedbackResponse(
//            Guid quizFeedbackQuestionId,
//            Guid learnerId
//        )
//        {
//            return _context.Feedbackresponses.FirstOrDefault(r =>
//                r.QuizFeedbackQuestionId == quizFeedbackQuestionId && r.LearnerId == learnerId
//            );
//        }

//        public Feedbackresponse GetExistingTopicFeedbackResponse(
//            Guid topicFeedbackQuestionId,
//            Guid learnerId
//        )
//        {
//            return _context.Feedbackresponses.FirstOrDefault(r =>
//                r.TopicFeedbackQuestionId == topicFeedbackQuestionId && r.LearnerId == learnerId
//            );
//        }

//        public void AddFeedbackResponse(Feedbackresponse feedbackResponse)
//        {
//            _context.Feedbackresponses.Add(feedbackResponse);
//            _context.SaveChanges();
//        }

//        public void AddFeedbackResponses(IEnumerable<Feedbackresponse> feedbackResponses)
//        {
//            _context.Feedbackresponses.AddRange(feedbackResponses);
//            _context.SaveChanges();
//        }

//        //public LearnerProfile GetLearnerProfile(Guid learnerId)
//        //{
//        //    return _context.LearnerProfiles.FirstOrDefault(p => p.LearnerId == learnerId);
//        //}

//        public Guid? GetOptionIdByText(Guid questionId, string optionText)
//        {
//            var option =
//                _context.Feedbackquestionsoptions.FirstOrDefault(o =>
//                    o.QuizFeedbackQuestionId == questionId
//                    && o.OptionText.ToLower() == optionText.ToLower()
//                )
//                ?? _context.Feedbackquestionsoptions.FirstOrDefault(o =>
//                    o.TopicFeedbackQuestionId == questionId
//                    && o.OptionText.ToLower() == optionText.ToLower()
//                );

//            return option?.FeedbackQuestionOptionId;
//        }

//        //new bug fix
//        public void DeleteFeedbackResponsesByQuizQuestionId(Guid quizFeedbackQuestionId)
//        {
//            var responses = _context
//                .Feedbackresponses.Where(r => r.QuizFeedbackQuestionId == quizFeedbackQuestionId)
//                .ToList();
//            _context.Feedbackresponses.RemoveRange(responses);
//            _context.SaveChanges();
//        }

//        public void DeleteFeedbackResponsesByTopicQuestionId(Guid topicFeedbackQuestionId)
//        {
//            var responses = _context
//                .Feedbackresponses.Where(r => r.TopicFeedbackQuestionId == topicFeedbackQuestionId)
//                .ToList();
//            _context.Feedbackresponses.RemoveRange(responses);
//            _context.SaveChanges();
//        }



//        public bool HasGivenFeedbackForAllQuizQuestions(Guid quizId, Guid learnerId)
//        {
//            var quizQuestions = _context.Quizfeedbackquestions.Where(q => q.QuizId == quizId).ToList();
//            var quizQuestionIds = quizQuestions.Select(q => q.QuizFeedbackQuestionId).ToList();
//            var responses = _context.Feedbackresponses
//                .Where(r => r.LearnerId == learnerId && quizQuestionIds.Contains(r.QuizFeedbackQuestionId))
//                .ToList();

//            return quizQuestions.Count() == responses.Count;
//        }

//        public bool HasGivenFeedbackForAllTopicQuestions(Guid topicId, Guid learnerId)
//        {
//            var topicQuestions = _context.Topicfeedbackquestions.Where(q => q.TopicId == topicId).ToList();
//            var topicQuestionIds = topicQuestions.Select(q => q.TopicFeedbackQuestionId).ToList();
//            var responses = _context.Feedbackresponses
//                .Where(r => r.LearnerId == learnerId && topicQuestionIds.Contains(r.TopicFeedbackQuestionId))
//                .ToList();

//            return topicQuestions.Count() == responses.Count;
//        }


//        //public bool HasGivenFeedbackForAllQuizQuestions(Guid quizId, Guid learnerId)
//        //{
//        //    var quizQuestions = _context.Quizfeedbackquestions.Where(q => q.QuizId == quizId).ToList();
//        //    var quizQuestionIds = quizQuestions.Select(q => q.QuizFeedbackQuestionId).ToList();
//        //    var responses = _context.Feedbackresponses
//        //        .Where(r => r.LearnerId == learnerId && quizQuestionIds.Contains(r.QuizFeedbackQuestionId))
//        //        .ToList();

//        //    return quizQuestions.Count == responses.Count;
//        //}

//        //public bool HasGivenFeedbackForAllTopicQuestions(Guid topicId, Guid learnerId)
//        //{
//        //    var topicQuestions = _context.Topicfeedbackquestions.Where(q => q.TopicId == topicId).ToList();
//        //    var topicQuestionIds = topicQuestions.Select(q => q.TopicFeedbackQuestionId).ToList();
//        //    var responses = _context.Feedbackresponses
//        //        .Where(r => r.LearnerId == learnerId && topicQuestionIds.Contains(r.TopicFeedbackQuestionId))
//        //        .ToList();

//        //    return topicQuestions.Count == responses.Count;
//        //}
//    }
//}



































//using FluentValidation;
//using LXP.Common.ViewModels.FeedbackResponseViewModel;
//using LXP.Data.IRepository;
//using LXP.Common.Validators;
//using LXP.Common.Entities;
//using LXP.Common.Constants;

//namespace LXP.Data.Repository
//{
//    public class FeedbackResponseRepository : IFeedbackResponseRepository
//    {
//        private readonly LXPDbContext _context;
//        private readonly IValidator<QuizFeedbackResponseViewModel> _quizFeedbackValidator;
//        private readonly IValidator<TopicFeedbackResponseViewModel> _topicFeedbackValidator;

//        public FeedbackResponseRepository(LXPDbContext context)
//        {
//            _context = context;
//            _quizFeedbackValidator = new QuizFeedbackResponseViewModelValidator();
//            _topicFeedbackValidator = new TopicFeedbackResponseViewModelValidator();
//        }

//        public void SubmitFeedbackResponse(QuizFeedbackResponseViewModel feedbackResponse)
//        {
//            var validationResult = _quizFeedbackValidator.Validate(feedbackResponse);
//            if (!validationResult.IsValid)
//            {
//                throw new ValidationException(validationResult.Errors);
//            }

//            if (feedbackResponse == null)
//                throw new ArgumentNullException(nameof(feedbackResponse));

//            var question = _context.Quizfeedbackquestions
//                .FirstOrDefault(q => q.QuizFeedbackQuestionId == feedbackResponse.QuizFeedbackQuestionId);

//            if (question == null)
//                throw new ArgumentException("Invalid feedback question ID.", nameof(feedbackResponse.QuizFeedbackQuestionId));

//            var learner = _context.Learners
//                .FirstOrDefault(l => l.LearnerId == feedbackResponse.LearnerId);

//            if (learner == null)
//                throw new ArgumentException("Invalid learner ID.", nameof(feedbackResponse.LearnerId));

//            var existingResponse = _context.Feedbackresponses
//                .FirstOrDefault(r => r.QuizFeedbackQuestionId == feedbackResponse.QuizFeedbackQuestionId &&
//                                     r.LearnerId == feedbackResponse.LearnerId);

//            if (existingResponse != null)
//                throw new InvalidOperationException("User has already submitted a response for this question.");

//            Guid? optionId = null;

//            if (question.QuestionType == FeedbackQuestionTypes.MultiChoiceQuestion.ToUpper())
//            {
//                if (string.IsNullOrEmpty(feedbackResponse.OptionText))
//                    throw new ArgumentException("Option text must be provided for MCQ responses.");

//                optionId = GetOptionIdByText(feedbackResponse.QuizFeedbackQuestionId, feedbackResponse.OptionText);
//                if (optionId == null)
//                    throw new ArgumentException("Invalid option text provided.", nameof(feedbackResponse.OptionText));

//                feedbackResponse.Response = null;
//            }

//            var response = new Feedbackresponse
//            {
//                QuizFeedbackQuestionId = feedbackResponse.QuizFeedbackQuestionId,
//                LearnerId = feedbackResponse.LearnerId,
//                Response = feedbackResponse.Response,
//                OptionId = optionId,
//                GeneratedAt = DateTime.UtcNow,
//                GeneratedBy = "User"
//            };

//            _context.Feedbackresponses.Add(response);
//            _context.SaveChanges();
//        }

//        public void SubmitFeedbackResponse(TopicFeedbackResponseViewModel feedbackResponse)
//        {
//            var validationResult = _topicFeedbackValidator.Validate(feedbackResponse);
//            if (!validationResult.IsValid)
//            {
//                throw new ValidationException(validationResult.Errors);
//            }

//            if (feedbackResponse == null)
//                throw new ArgumentNullException(nameof(feedbackResponse));

//            var question = _context.Topicfeedbackquestions
//                .FirstOrDefault(q => q.TopicFeedbackQuestionId == feedbackResponse.TopicFeedbackQuestionId);

//            if (question == null)
//                throw new ArgumentException("Invalid feedback question ID.", nameof(feedbackResponse.TopicFeedbackQuestionId));

//            var learner = _context.Learners
//                .FirstOrDefault(l => l.LearnerId == feedbackResponse.LearnerId);

//            if (learner == null)
//                throw new ArgumentException("Invalid learner ID.", nameof(feedbackResponse.LearnerId));

//            var existingResponse = _context.Feedbackresponses
//                .FirstOrDefault(r => r.TopicFeedbackQuestionId == feedbackResponse.TopicFeedbackQuestionId &&
//                                     r.LearnerId == feedbackResponse.LearnerId);

//            if (existingResponse != null)
//                throw new InvalidOperationException("User has already submitted a response for this question.");

//            Guid? optionId = null;

//            if (question.QuestionType == TopicFeedbackQuestionTypes.MultiChoiceQuestion.ToUpper())
//            {
//                if (string.IsNullOrEmpty(feedbackResponse.OptionText))
//                    throw new ArgumentException("Option text must be provided for MCQ responses.");

//                optionId = GetOptionIdByText(feedbackResponse.TopicFeedbackQuestionId, feedbackResponse.OptionText);
//                if (optionId == null)
//                    throw new ArgumentException("Invalid option text provided.", nameof(feedbackResponse.OptionText));

//                feedbackResponse.Response = null;
//            }

//            var response = new Feedbackresponse
//            {
//                TopicFeedbackQuestionId = feedbackResponse.TopicFeedbackQuestionId,
//                LearnerId = feedbackResponse.LearnerId,
//                Response = feedbackResponse.Response,
//                OptionId = optionId,
//                GeneratedAt = DateTime.UtcNow,
//                GeneratedBy = "User"
//            };

//            _context.Feedbackresponses.Add(response);
//            _context.SaveChanges();
//        }

//        private Guid? GetOptionIdByText(Guid questionId, string optionText)
//        {
//            var option = _context.Feedbackquestionsoptions
//                .FirstOrDefault(o => o.QuizFeedbackQuestionId == questionId && o.OptionText.ToLower() == optionText.ToLower()) ??
//                          _context.Feedbackquestionsoptions
//                .FirstOrDefault(o => o.TopicFeedbackQuestionId == questionId && o.OptionText.ToLower() == optionText.ToLower());

//            return option?.FeedbackQuestionOptionId;
//        }
//    }
//}

//using System;
//using System.Linq;
//using LXP.Common.ViewModels.FeedbackResponseViewModel;
//using LXP.Data.DBContexts;
//using LXP.Data.IRepository;

//namespace LXP.Data.Repository
//{
//    public class FeedbackResponseRepository : IFeedbackResponseRepository
//    {
//        private readonly LXPDbContext _context;

//        public FeedbackResponseRepository(LXPDbContext context)
//        {
//            _context = context;
//        }

//        public void SubmitFeedbackResponse(QuizFeedbackResponseViewModel feedbackResponse)
//        {
//            if (feedbackResponse == null)
//                throw new ArgumentNullException(nameof(feedbackResponse));

//            var question = _context.Quizfeedbackquestions
//                .FirstOrDefault(q => q.QuizFeedbackQuestionId == feedbackResponse.QuizFeedbackQuestionId);

//            if (question == null)
//                throw new ArgumentException("Invalid feedback question ID.", nameof(feedbackResponse.QuizFeedbackQuestionId));

//            var learner = _context.Learners
//                .FirstOrDefault(l => l.LearnerId == feedbackResponse.LearnerId);

//            if (learner == null)
//                throw new ArgumentException("Invalid learner ID.", nameof(feedbackResponse.LearnerId));

//            var existingResponse = _context.Feedbackresponses
//                .FirstOrDefault(r => r.QuizFeedbackQuestionId == feedbackResponse.QuizFeedbackQuestionId &&
//                                     r.LearnerId == feedbackResponse.LearnerId);

//            if (existingResponse != null)
//                throw new InvalidOperationException("User has already submitted a response for this question.");

//            Guid? optionId = null;

//            if (question.QuestionType == FeedbackQuestionTypes.MultiChoiceQuestion.ToUpper())
//            {
//                if (string.IsNullOrEmpty(feedbackResponse.OptionText))
//                    throw new ArgumentException("Option text must be provided for MCQ responses.");

//                optionId = GetOptionIdByText(feedbackResponse.QuizFeedbackQuestionId, feedbackResponse.OptionText);
//                if (optionId == null)
//                    throw new ArgumentException("Invalid option text provided.", nameof(feedbackResponse.OptionText));

//                feedbackResponse.Response = null;
//            }

//            var response = new Feedbackresponse
//            {
//                QuizFeedbackQuestionId = feedbackResponse.QuizFeedbackQuestionId,
//                LearnerId = feedbackResponse.LearnerId,
//                Response = feedbackResponse.Response,
//                OptionId = optionId,
//                GeneratedAt = DateTime.UtcNow,
//                GeneratedBy = "User"
//            };

//            _context.Feedbackresponses.Add(response);
//            _context.SaveChanges();
//        }

//        public void SubmitFeedbackResponse(TopicFeedbackResponseViewModel feedbackResponse)
//        {
//            if (feedbackResponse == null)
//                throw new ArgumentNullException(nameof(feedbackResponse));

//            var question = _context.Topicfeedbackquestions
//                .FirstOrDefault(q => q.TopicFeedbackQuestionId == feedbackResponse.TopicFeedbackQuestionId);

//            if (question == null)
//                throw new ArgumentException("Invalid feedback question ID.", nameof(feedbackResponse.TopicFeedbackQuestionId));

//            var learner = _context.Learners
//                .FirstOrDefault(l => l.LearnerId == feedbackResponse.LearnerId);

//            if (learner == null)
//                throw new ArgumentException("Invalid learner ID.", nameof(feedbackResponse.LearnerId));

//            var existingResponse = _context.Feedbackresponses
//                .FirstOrDefault(r => r.TopicFeedbackQuestionId == feedbackResponse.TopicFeedbackQuestionId &&
//                                     r.LearnerId == feedbackResponse.LearnerId);

//            if (existingResponse != null)
//                throw new InvalidOperationException("User has already submitted a response for this question.");

//            Guid? optionId = null;

//            if (question.QuestionType == TopicFeedbackQuestionTypes.MultiChoiceQuestion.ToUpper())
//            {
//                if (string.IsNullOrEmpty(feedbackResponse.OptionText))
//                    throw new ArgumentException("Option text must be provided for MCQ responses.");

//                optionId = GetOptionIdByText(feedbackResponse.TopicFeedbackQuestionId, feedbackResponse.OptionText);
//                if (optionId == null)
//                    throw new ArgumentException("Invalid option text provided.", nameof(feedbackResponse.OptionText));

//                feedbackResponse.Response = null;
//            }

//            var response = new Feedbackresponse
//            {
//                TopicFeedbackQuestionId = feedbackResponse.TopicFeedbackQuestionId,
//                LearnerId = feedbackResponse.LearnerId,
//                Response = feedbackResponse.Response,
//                OptionId = optionId,
//                GeneratedAt = DateTime.UtcNow,
//                GeneratedBy = "User"
//            };

//            _context.Feedbackresponses.Add(response);
//            _context.SaveChanges();
//        }

//        private Guid? GetOptionIdByText(Guid questionId, string optionText)
//        {
//            var option = _context.Feedbackquestionsoptions
//                .FirstOrDefault(o => o.QuizFeedbackQuestionId == questionId && o.OptionText.ToLower() == optionText.ToLower()) ??
//                          _context.Feedbackquestionsoptions
//                .FirstOrDefault(o => o.TopicFeedbackQuestionId == questionId && o.OptionText.ToLower() == optionText.ToLower());

//            return option?.FeedbackQuestionOptionId;
//        }
//    }
//}
