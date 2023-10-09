using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using LibraryApp.Services.DocumentService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services.ExamService
{
    public class ExamService : IExamService
    {

        private readonly DataContext _context;

        public ExamService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Exam>> GetExams()
        {
            //return await _context.Exams.ToListAsync();

            return await _context.Exams
                .Include(e => e.MultipleChoiceQuestions)
                .Include(e => e.Essays)
                .ToListAsync();
        }

        public async Task<Exam> GetExamById(int id)
        {
            //var exam = await _context.Exams.FindAsync(id);
            //return exam;

            var exam =  await _context.Exams
                .Include(e => e.MultipleChoiceQuestions)
                .Include(e => e.Essays)
                .FirstOrDefaultAsync(e => e.ExamId == id);

            return exam;
        }

        public async Task<Exam> CreateExam(ExamDto exam)
        {
            var newExam = new Exam
            {
                Name = exam.Name,
                Creator = exam.Creator,
                DepartmentId = exam.DepartmentId,
                Form = exam.Form,
                Status = "waiting",
                Duration = exam.Duration,
                SubjectId = exam.SubjectId,
                DateSubmit = exam.DateSubmit,

                IsApproved = false,
            };

            if (exam.MultipleChoiceQuestions != null)
            {
                newExam.MultipleChoiceQuestions = exam.MultipleChoiceQuestions.Select(mcq => new MultipleChoiceQuestion
                {
                    Question = mcq.Question,
                    CorrectAnswer = mcq.CorrectAnswer,
                    Exam = newExam,
                    Choices = mcq.Choices?.Select(c => new Choice { Value = c.Value }).ToList()
                }).ToList();
            }

            if (exam.Essays != null)
            {
                newExam.Essays = exam.Essays.Select(e => new Essay
                {
                    Question = e.Question,
                    AnswerType = e.AnswerType
                }).ToList();
            }

            _context.Exams.Add(newExam);
            await _context.SaveChangesAsync();

            return newExam;
        }

        public async Task<Exam> UpdateExam(int id, Exam exam)
        {
            var existingExam = await _context.Exams.FindAsync(id);
            if (existingExam == null)
            {
                throw new Exception("Exam not found");
            }

            existingExam.Name = exam.Name;
            existingExam.DepartmentId = exam.DepartmentId;
            existingExam.SubjectId = exam.SubjectId;
            existingExam.Duration = exam.Duration;
            existingExam.Form = exam.Form;
            existingExam.MultipleChoiceQuestions = exam.MultipleChoiceQuestions;
            existingExam.Essays = exam.Essays;
            existingExam.Status = exam.Status;

            await _context.SaveChangesAsync();

            return existingExam;
        }

        public async Task<Exam> DeleteExam(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                throw new Exception("Exam not found");
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();

            return exam;
        }
    

        public async Task<List<Exam>> Search(string searchString)
        {
        var exam = from s in _context.Exams
                   select s;

        if (!String.IsNullOrEmpty(searchString))
        {
            exam = exam.Where(s => s.Name.ToLower().Contains(searchString.ToLower()) || s.Form.ToLower().Contains(searchString.ToLower()));
        }

        return await exam.ToListAsync();
        }

        public async Task<Exam> Approve(int id)
        {
            // Phê duyệt tài liệu
            var exam = _context.Exams.FirstOrDefault(d => d.ExamId == id);

            exam.IsApproved = true;
            exam.Status = "Approved";

            await _context.SaveChangesAsync();

            return exam;
        }

        public async Task<Exam> UnApprove(int id)
        {
            var exam = _context.Exams.FirstOrDefault(d => d.ExamId == id);

            exam.IsApproved = false;
            exam.Status = "Not Approved";

            await _context.SaveChangesAsync();

            return exam;
        }
    }
}

