using ElectronicJournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicJournal.Services.StudentsService
{
    public interface IStudentService
    {
        void AddStudent(Human human);

        Student GetStudentByUserId(int id);
       
    }
}
