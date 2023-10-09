namespace LibraryApp.Mapper;
using LibraryApp.Data.Model;
using AutoMapper;
using System;
using LibraryApp.Data.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SubjectDto, Subject>();
        CreateMap<StudentDto, Student>();
        CreateMap<Register, Student>();
        CreateMap<Student, StudentDto>();
        CreateMap<TeacherDto, Teacher>();
        CreateMap<DocumentDto, Document>();
        CreateMap<LectureDto, Lecture>();

        CreateMap<ExamDto, Exam>();
        CreateMap<TopicDto, Topic>();

    }
}
