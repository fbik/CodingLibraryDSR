using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Razor;

namespace CodingLibraryDSR.Data.Entity;

public class Problems : BaseEntity
{
    public string Name { get; set; }
    public  string Description { get; set; }
    public string Solution { get; set; }
    public string DifficultIndex { get; set; }
    
}