using FluentValidation;

namespace Api.Services.Models;

public class GetLanguagesModel
{
    public Guid Uid { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
}
