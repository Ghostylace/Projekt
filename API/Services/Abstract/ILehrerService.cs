using Shared.DTOs.Teacher;

namespace API.Services.Abstract
{
    public interface ILehrerService
    {
        Task<TeacherDTO?> GetTeacherByEmail(string email);
    }
}