using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Configuration;
using API.Models;
using API.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.DTOs.Teacher;
using Supabase;
using static Supabase.Postgrest.Constants;

namespace API.Services;

public class LehrerService : ILehrerService
{
    private readonly Client _supabase;
    

    public LehrerService(Client supabase)
    {
        _supabase = supabase;
        
    }
    public async Task<TeacherDTO?> GetTeacherByEmail(string email)
    {
        Supabase.Postgrest.Responses.ModeledResponse<Teacher> response = await _supabase.From<Teacher>().Filter("lehrperson.e_mail", Operator.Equals, $"{email}").Get();
        HttpResponseMessage? resp = response.ResponseMessage;

        if (resp.IsSuccessStatusCode)
        {
            TeacherDTO teacher = await resp.Content.ReadFromJsonAsync<TeacherDTO>() ?? new();
            return teacher;
        }
        else
        {
            return null;
        }
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