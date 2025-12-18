namespace Shared.DTOs
{
    public class UpdateGradeAdjustmentStatusRequest
    {
        public string Status { get; set; } = null!;
        public string? RejectionReason { get; set; }
    }
}
