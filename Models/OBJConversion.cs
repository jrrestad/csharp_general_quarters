using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace General_Quarters.Models
{
    public class OBJConversion
    {
        public string OBJSerialize(Player aplayer)
        {
            string JsonPlayer;
            JsonPlayer = JsonSerializer.Serialize(aplayer);
            return  JsonPlayer;
        }
    }
}