using Todo.Entities.Domains.BaseEntities;

namespace Todo.Entities.Domains;

public class Work : BaseEntity
{
    public string Definition { get; set; }
    
    public bool IsCompleted { get; set; }
}