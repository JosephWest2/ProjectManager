using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models;
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

}

