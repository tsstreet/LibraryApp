using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.GradeTypeService
{
    public interface IGradeTypeService
    {
        Task<List<GradeType>> GetGradeTypes();

        Task<GradeType> GetGradeTypeById(int id);

        Task<GradeType> AddGradeType(GradeType gradeType);

        Task<GradeType> UpdateGradeType(int id, GradeType gradeType);

        Task<GradeType> DeleteGradeType(int id);

        Task<List<GradeType>> Search(string searchString);
    }
}
