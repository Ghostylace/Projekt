using API.Models;
using API.Services.Interfaces;
using Shared.DTOs;
using Supabase;

namespace API.Services
{
    public class GradeAdjustmentService : IGradeAdjustmentService
    {
        private readonly Client _supabase;

        public GradeAdjustmentService(Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<GradeAdjustment> CreateAsync(CreateGradeAdjustmentRequest request)
        {
            var entity = new GradeAdjustment
            {
                TeacherId = request.TeacherId,
                ProrectorId = request.ProrectorId,
                StudentId = request.StudentId,
                ModuleId = request.ModuleId,
                OldGrade = request.OldGrade,
                NewGrade = request.NewGrade,
                Remarks = request.Remarks,
                Status = "EINGEREICHT",
                CreatedAt = DateTime.UtcNow
            };

            var result = await _supabase
                .From<GradeAdjustment>()
                .Insert(entity);

            return result.Models.First();
        }

        public async Task<List<GradeAdjustment>> GetAllAsync()
        {
            var response = await _supabase
                .From<GradeAdjustment>()
                .Select("*")
                .Get();

            return response.Models;
        }

        public async Task UpdateStatusAsync(int id, UpdateGradeAdjustmentStatusRequest request)
        {
            var updateEntity = new GradeAdjustment
            {
                Id = id,
                Status = request.Status,
                RejectionReason = request.RejectionReason,
                ReviewedAt = DateTime.UtcNow
            };

            await _supabase
                .From<GradeAdjustment>()
                .Where(x => x.Id == id)
                .Update(updateEntity);
        }

    }
}
