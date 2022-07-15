namespace EasyChoresApi.DTO;

public class ReminderDto
{
    public string? Body { get; set; }
    public DateTime ReminderTime { get; set; }
    public bool? Status { get; set; }
    public ICollection<MemberDto> Users { get; set; }
}