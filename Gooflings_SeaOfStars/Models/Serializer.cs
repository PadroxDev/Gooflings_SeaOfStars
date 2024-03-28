using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gooflings.Models
{
    public struct GameData
    {
        [JsonInclude] public int PlrPosX;
        [JsonInclude] public int PlrPosY;
        [JsonInclude] public List<GooflingData> Party;
    }

    public static class Serializer
    {
        private static string SAVE_LOCATION = "Gooflings";
        private static string SAVE_FILENAME = "Goofling_Data.json";

        public static void Save(Player plr)
        {
            string filePath = GetSaveFolderPath();

            GameData data = new();
            data.PlrPosX = plr.posX;
            data.PlrPosY = plr.posY;
            data.Party = new();

            foreach(var goofling in plr.Party.Members)
            {
                GooflingData gooflingData = Resources.Instance.GetGooflingData(goofling.GooflingType);
                gooflingData.Level = goofling.Level;
                gooflingData.Exp = goofling.Exp;

                data.Party.Add(gooflingData);
            }

            var content = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, content);
        }

        public static void Load(Player plr)
        {
            string filePath = GetSaveFolderPath();
            if (!File.Exists(filePath)) return;

            string content = File.ReadAllText(filePath);
            GameData data = JsonSerializer.Deserialize<GameData>(content);

            plr.posX = data.PlrPosX;
            plr.posY = data.PlrPosY;
            foreach(GooflingData gooflingData in data.Party)
            {
                Goofling goofling = new Goofling(gooflingData);
                plr.Party.Members.Add(goofling);
            }
        }

        private static string GetSaveFolderPath()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), SAVE_LOCATION);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return Path.Combine(path, SAVE_FILENAME);
        }
    }
}
