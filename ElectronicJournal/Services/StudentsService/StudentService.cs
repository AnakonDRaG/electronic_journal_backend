using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicJournal.Services.StudentsService
{
    public class StudentService : IStudentService
    {
        private readonly IFullRepository<Student> _repository;
        public StudentService(IFullRepository<Student> repository)
        {
            _repository = repository;
        }

        public void AddStudent (Human human)
        {
            var student = new Student() { Human = human };
            _repository.Add(student);
        }

        public Student GetStudentByUserId(int id)
        {
            return _repository.GetOneOrDefault(s => s.Human.UserId == id); 
        }

        public Student GetStudentById(int? id)
        {
            if (id is null)
                return null;

            var studentId = (int)id;
            return _repository.GetOneWithObjects(studentId);
        }
    }
}
