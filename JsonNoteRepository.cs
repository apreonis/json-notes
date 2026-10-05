using System.Text.Json;

namespace ConsoleApp1
{
    public class JsonNoteRepository : INoteRepository
    {
        private List<Note> _note = new();
        public JsonNoteRepository()
        {
            if (File.Exists("notes.json"))
            {
                string json = File.ReadAllText("notes.json"); 
                _note = JsonSerializer.Deserialize<List<Note>>(json) ?? new List<Note>();
            }
            else
            {
                _note = new List<Note>();
            }
        }
        public Task<List<Note>> GetAllAsync() => Task.FromResult(_note.ToList());
        public async Task<Note> AddAsync(Note jsonvalue)
        {
             _note.Add(jsonvalue);
             await SaveAsync();
             return jsonvalue;
        }
        public async Task DeleteAsync(Guid ID)
        {
                _note.RemoveAll(x => x.ID == ID);
                await SaveAsync();
        }
        public async Task SaveAsync()
        {
            await using var savestream = new FileStream("notes.json",FileMode.Create);
            await JsonSerializer.SerializeAsync(savestream, _note, new JsonSerializerOptions { WriteIndented = true }); 
        }

    }

}
