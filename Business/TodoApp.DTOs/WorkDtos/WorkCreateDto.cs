using System.ComponentModel.DataAnnotations;
using TodoApp.DTOs.Interfaces;

namespace TodoApp.DTOs.WorkDtos;

public class WorkCreateDto : IDto
{
    public string Definition { get; set; }
    
    public bool IsCompleted { get; set; }
}