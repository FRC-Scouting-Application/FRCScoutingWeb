using FRCScouting_API.Services;
using FRCScouting_API.Services.Interfaces;
using Models.Dbo;

namespace FRCScouting_API.Data
{
    public class SeedExampleData
    {

        private readonly IAppDataRepository _repo;

        public SeedExampleData(IAppDataRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> SeedTemplates()
        {
            List<Template> templates = new List<Template>()
            {
                new()
                {
                    Id = "notes_example",
                    Version = 1,
                    Type = "notes",
                    Name = "Notes Example",
                    DefaultTemplate = true,
                    Data = ReadTemplate("notes_example.json")
                },
                new()
                {
                    Id = "pit_example",
                    Version = 1,
                    Type = "pit",
                    Name = "Pit Example",
                    DefaultTemplate = true,
                    Data = ReadTemplate("pit_example.json")
                }
            };

            return await _repo.AddTemplatesAsync(templates);
        }


        private string? ReadTemplate(string fileName)
        {
            string path = Path.Join(Directory.GetCurrentDirectory(), "Data", "Templates", fileName);
            return File.ReadAllText(path);
        }
    }
}
