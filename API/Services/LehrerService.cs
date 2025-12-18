using API.Models;
using API.Services.Abstract;
using Shared.DTOs.Teacher;
using Supabase;
using Supabase.Postgrest.Responses;
using static Supabase.Postgrest.Constants;

namespace API.Services;

public class LehrerService : ILehrerService
{
    private readonly Client _supabase;
    

    public LehrerService(Client supabase)
    {
        _supabase = supabase;
        
    }

    public async Task<List<TeacherDTO>?> GetAllTeachers()
    {
        ModeledResponse<Teacher> response = await _supabase.From<Teacher>().Get();

        if (response.ResponseMessage.IsSuccessStatusCode)
        {
            List<TeacherDTO> outP = await ConvertList(response.Models);
            return outP;
        }
        else
        {
            return null;
        }
    }

    public async Task<List<TeacherDTO>?> GetTeacherByEmail(string email)
    {
        ModeledResponse<Teacher> response = await _supabase.From<Teacher>().Filter("lehrperson.e_mail", Operator.Equals, $"{email}").Get();

        if (response.ResponseMessage.IsSuccessStatusCode)
        {
            List<TeacherDTO> outP = await ConvertList(response.Models);
            return outP;
        }
        else
        {
            return null;
        }
    }
    
    private async Task<List<TeacherDTO>> ConvertList(List<Teacher> input)
    {
        List<TeacherDTO> toReturn = [];

        foreach(var teacher in input)
        {
            toReturn.Add(new TeacherDTO()
            {
                Id = teacher.Id,
                Vorname = teacher.Vorname,
                Nachname = teacher.Nachname,
                Email = teacher.Email,
            });
        }
        return toReturn;
    }

    //public async Task<List<TeacherDTO>?> AddTeacher(Teacher teacher)
    //{
    //    await _supabase.From<Teacher>().Insert(teacher);
    //    ModeledResponse<Teacher> response = await _supabase.From<Teacher>().Get();
    //    HttpResponseMessage? resp = response.ResponseMessage;

    //    if (resp.IsSuccessStatusCode)
    //    {
    //        List<TeacherDTO> content = await resp.Content.ReadFromJsonAsync<List<TeacherDTO>>() ?? [];
    //        return content;
    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}
}