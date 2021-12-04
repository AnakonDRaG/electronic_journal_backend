using AutoMapper;
using ElectronicJournal.Domain;
using ElectronicJournal.DTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.DTO
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            MapEntityToDTO();
            //MapDtoToEntity();
            CreateMap<HumanAddDto, Human>()
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(y => y.LastName))
                .ForMember(x => x.BirthDate, opt => opt.MapFrom(y => y.BirthDate));
        }

        private void MapEntityToDTO()
        {
            CreateMap<User, UsersDTO>();
            CreateMap<Human, HumansDTO>()
                .ForMember(humanDto => humanDto.FirstName, opt => opt.MapFrom(human => human.Name))
                .ForMember(humanDto => humanDto.UserName, opt => opt.MapFrom(human => human.User.UserName))
                .ForMember(humanDto => humanDto.Role, opt => opt.MapFrom(human => human.User.Role));

            CreateMap<Class, ClassesDTO>()
                .ForMember(classDto => classDto.JournalId, opt => opt.MapFrom(c => c.CurrentJournal.Id))
                .ForMember(c => c.ClassroomTeacher, opt => opt.MapFrom(c => c.ClassroomTeacher));

            CreateMap<Class, ClassWithStudentDto>()
                .ForMember(classDto => classDto.JournalId, opt => opt.MapFrom(c => c.CurrentJournal.Id))
                .ForMember(c => c.Students, opt => opt.MapFrom(d => d.Students));

            CreateMap<Journal, JournalsDTO>()
                .ForMember(entityDto => entityDto.Class, opt => opt.MapFrom(e => e.Class));
            CreateMap<SubjectInJournal, SubjectsInJournalsDTO>();
            CreateMap<Subject, SubjectsDTO>();

            CreateMap<Teacher, TeachersDTO>()
                .ForMember(entityDto => entityDto.FirstName, opt => opt.MapFrom(e => e.Human.Name))
                .ForMember(entityDto => entityDto.CurrentClass, opt => opt.MapFrom(e => e.CurrentClass));
            
            CreateMap<Student, StudentsDTO>()
                .ForMember(entityDto => entityDto.FirstName, opt => opt.MapFrom(e => e.Human.Name))
                .ForMember(entityDto => entityDto.LastName, opt => opt.MapFrom(e => e.Human.LastName))
                .ForMember(entityDto => entityDto.Id, opt => opt.MapFrom(e => e.Human.Id))
                .ForMember(entityDto => entityDto.BirthDate, opt => opt.MapFrom(e => e.Human.BirthDate));

            CreateMap<Lesson, LessonsDTO>()
                .ForMember(entityDto => entityDto.LessonScores,
                    opt => opt.MapFrom(e => e.LessonScores.Select(l => l.Score).ToList()));
            CreateMap<LessonScore, LessonScoresDTO>();
        }

        private void MapDtoToEntity()
        {
            CreateMap<HumanAddDto, Human>()
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.FirstName));
            CreateMap<Human, HumanAddDto>();
        }
    }
}