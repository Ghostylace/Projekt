namespace Shared.DTOs
{
    public class CreateGradeAdjustmentRequest
    {
        public int TeacherId { get; set; }
        public int ProrectorId { get; set; }
        public int StudentId { get; set; }
        public int ModuleId { get; set; }

        public decimal? OldGrade { get; set; }
        public decimal NewGrade { get; set; }

        public string? Remarks { get; set; }
    }
}
