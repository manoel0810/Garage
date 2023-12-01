using Clients.Infrastructure.Interfaces;
using Clients.Models;
using System.Text.Json;

namespace Clients.Data.Init
{
    public class InitClientTable : IInit
    {
        private readonly ApplicationDbContext _db;

        public InitClientTable(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Init()
        {
            IEnumerable<Pass> passes = _db.Passes;
            if (!passes.Any())
            {
                if (File.Exists("Files\\Passagens.json"))
                {
                    string json = File.ReadAllText("Files\\Passagens.json");
                    PassStruct? passJson = JsonSerializer.Deserialize<PassStruct>(json);

                    if (passJson != null && passJson.Passagens.Count > 0)
                    {
                        foreach (var pass in passJson.Passagens)
                        {
                            if (pass != null)
                                _db.Passes.Add(pass);
                        }

                        _db.SaveChanges();
                    }
                }
            }
        }
    }
}
