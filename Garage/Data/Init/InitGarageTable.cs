using Garage.Infrastructure.Interfaces;
using Garage.Models;
using System.Text.Json;

namespace Garage.Data.Init
{
    public class InitGarageTable : IInit
    {
        private readonly ApplicationDbContext _db;

        public InitGarageTable(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Init()
        {
            IEnumerable<GarageFormModel> garages = _db.Garages;
            if (!garages.Any())
            {
                if (File.Exists("Files\\Garagens.json"))
                {
                    string json = File.ReadAllText("Files\\Garagens.json");
                    GarageStruct? garagesJson = JsonSerializer.Deserialize<GarageStruct>(json);

                    if (garagesJson != null && garagesJson.Garagens.Count > 0)
                    {
                        foreach (var g in garagesJson.Garagens)
                        {
                            if (g != null)
                                _db.Garages.Add(g);
                        }

                        _db.SaveChanges();
                    }
                }
            }
        }
    }
}
