//using AutoMapper;
using LXP.Common.Entities;
using LXP.Common.ViewModels;
using LXP.Core.IServices;
using LXP.Data.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace LXP.Core.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly ILearnerRepository _learnerRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        //private Mapper _enrollMapper;//Mapper1

        public EnrollmentService(
            IEnrollmentRepository enrollmentRepository,
            ILearnerRepository learnerRepository,
            ICourseRepository courseRepository,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _enrollmentRepository = enrollmentRepository;
            _learnerRepository = learnerRepository;
            _courseRepository = courseRepository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            //var _configEnrollment = new MapperConfiguration(cfg => cfg.CreateMap<Enrollment, EnrollmentViewModel>().ReverseMap());//mapper 2
            //_enrollMapper = new Mapper(_configEnrollment); //mapper 3
        }

        public async Task<bool> Addenroll(EnrollmentViewModel enrollment)
        {
            bool isEnrolledExists = _enrollmentRepository.AnyEnrollmentByLearnerAndCourse(
                enrollment.LearnerId,
                enrollment.CourseId
            );

            if (!isEnrolledExists)
            {
                Learner learner = _learnerRepository.GetLearnerDetailsByLearnerId(
                    enrollment.LearnerId
                );

                Course course = _courseRepository.GetCourseDetailsByCourseId(enrollment.CourseId);

                Enrollment newEnrollment = new Enrollment
                {
                    EnrollmentId = Guid.NewGuid(),
                    LearnerId = enrollment.LearnerId,
                    CourseId = enrollment.CourseId,
                    EnrollmentDate = DateTime.Now,
                    EnrollStatus = true,
                    CompletedStatus = 0,
                    CreatedBy = "Admin",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = "Admin"
                };

                _enrollmentRepository.Addenroll(newEnrollment);

                return true;
            }
            else
            {
                return false;
            }
        }

        public object GetCourseandTopicsByLearnerId(Guid learnerId)
        {
            return _enrollmentRepository.GetCourseandTopicsByLearnerId(learnerId);
        }

        public IEnumerable<EnrolledUserViewModel> GetEnrolledUsers(Guid courseId)
        {
            return _enrollmentRepository.GetEnrolledUser(courseId);
        }

        public IEnumerable<EnrollmentReportViewModel> GetEnrollmentsReport()
        {
            return _enrollmentRepository.GetEnrollmentReport();
        }

        public IEnumerable<EnrollmentReportViewModel> GetEnrolledCompletedLearnerbyCourseId(
            Guid courseId
        )
        {
            return _enrollmentRepository.GetEnrolledCompletedLearnerbyCourseId(courseId);
        }

        public IEnumerable<EnrollmentReportViewModel> GetEnrolledInprogressLearnerbyCourseId(
            Guid courseId
        )
        {
            return _enrollmentRepository.GetEnrolledInprogressLearnerbyCourseId(courseId);
        }

        public async Task<bool> DeleteEnrollment(Guid enrollmentId)
        {
            var enrollment = _enrollmentRepository.FindEnrollmentId(enrollmentId);
            if (enrollment != null)
            {
                _enrollmentRepository.DeleteEnrollment(enrollment);
                return true;
            }
            return false;
        }

        public object GetCourseandTopicsByCourseId(Guid courseId, Guid learnerId)
        {
            return _enrollmentRepository.GetCourseandTopicsByCourseIdAndLearnerId(
                courseId,
                learnerId
            );
        } //2106
    }
}
