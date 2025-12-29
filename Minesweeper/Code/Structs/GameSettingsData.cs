using Newtonsoft.Json;

namespace Minesweeper
{
    struct GameSettingsData
    {
        [JsonConstructor]
        public GameSettingsData(string description, bool defaultValue)
        {
            Description = description;
            DefaultValue = defaultValue;
        }

        public string Description { get; }
        public bool DefaultValue { get; }
    }
}
