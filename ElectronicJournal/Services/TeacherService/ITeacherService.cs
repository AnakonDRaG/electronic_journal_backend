using ElectronicJournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicJournal.Services.TeacherService
{
    public interface ITeacherService
    {
        Teacher AddTeacher(Human human);

        Teacher GetTeacherByUserId(int id);
        Teacher GetTeacherById(int id);

        Teacher AddTeacher(int humanId);
    }
}
