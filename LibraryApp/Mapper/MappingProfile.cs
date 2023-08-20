namespace LibraryApp.Mapper;
using LibraryApp.Data.Model;
using AutoMapper;
using System;
using LibraryApp.Data.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClassDto, Class>();
        CreateMap<SubjectDto, Subject>();
        CreateMap<ScheduleDto, Schedule>();
        CreateMap<DepartmentDto, Department>();
        CreateMap<AcademicYearDto, AcademicYear>();
        CreateMap<FalcutyDto, Falcuty>();
        CreateMap<StudentDto, Student>();
        CreateMap<Register, Student>();
        CreateMap<Student, StudentDto>();
        CreateMap<TeacherDto, Teacher>();
        CreateMap<SubjectGradeDto, SubjectGrade>();
    }
}
