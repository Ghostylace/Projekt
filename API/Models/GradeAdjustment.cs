using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("NOTENANPASSUNG_ANTRAG")]
public class GradeAdjustment : BaseModel
{
    [PrimaryKey("AntragID")]
    public int Id { get; set; }

    [Column("LehrpersonID")]
    public int TeacherId { get; set; }

    [Column("ProrektorID")]
    public int ProrectorId { get; set; }

    [Column("LernenderID")]
    public int StudentId { get; set; }

    [Column("ModulID")]
    public int ModuleId { get; set; }

    [Column("AlteNote")]
    public decimal? OldGrade { get; set; }

    [Column("NeueNote")]
    public decimal NewGrade { get; set; }

    [Column("Antragsdatum")]
    public DateTime CreatedAt { get; set; }

    [Column("Bemerkungen")]
    public string? Remarks { get; set; }

    [Column("Status")]
    public string Status { get; set; }

    [Column("Pruefungsdatum")]
    public DateTime? ReviewedAt { get; set; }

    [Column("Ablehnungsgrund")]
    public string? RejectionReason { get; set; }
}
