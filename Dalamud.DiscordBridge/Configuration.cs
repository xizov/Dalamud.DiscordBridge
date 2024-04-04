﻿using System.Collections.Generic;
using Dalamud.Configuration;
using Dalamud.DiscordBridge.Model;
using Dalamud.Game.Text;
using Dalamud.Plugin;
using Newtonsoft.Json;

namespace Dalamud.DiscordBridge
{
    public class Configuration : IPluginConfiguration
    {
        public int Version { get; set; }

        public long DuplicateCheckMS { get; set; } = 5000;

        [JsonIgnore] private DalamudPluginInterface pluginInterface;

        public string DiscordToken { get; set; } = string.Empty;
        public string DiscordOwnerName { get; set; } = string.Empty;
        public string DiscordMentionId { get; set; } = string.Empty;
        public string DiscordBotPrefix { get; set; } = "xl!";

        public string DefaultAvatarURL = Constant.LogoLink;
        public Dictionary<XivChatType, string> ChatTypeAvatarURL { get; set; } = new Dictionary<XivChatType, string>();

        public Dictionary<ulong, DiscordChannelConfig> ChannelConfigs { get; set; } = new Dictionary<ulong, DiscordChannelConfig>();
        public Dictionary<XivChatType, string> PrefixConfigs { get; set; } = new Dictionary<XivChatType, string>();

        public Dictionary<XivChatType, string> CustomSlugsConfigs { get; set; } = new Dictionary<XivChatType, string>();
        public string CFPrefixConfig { get; set; } = "";
        public bool ForceDefaultNameAvatar { get; set; } = false;
        public bool ForceEmbedFallbackMode { get; set; } = false;
        public bool SenderInMessage { get; set; } = false;
        

        public void Initialize(DalamudPluginInterface pluginInterface)
        {
            this.pluginInterface = pluginInterface;
        }

        public void Save()
        {
            this.pluginInterface.SavePluginConfig(this);
        }
    }
}
