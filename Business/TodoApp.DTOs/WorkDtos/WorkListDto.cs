using TodoApp.DTOs.Interfaces;

namespace TodoApp.DTOs.WorkDtos;

public class WorkListDto : IDto
{
    public int Id { get; set; }
    
    public string Definition { get; set; }
    
    public bool IsCompleted { get; set; }
}