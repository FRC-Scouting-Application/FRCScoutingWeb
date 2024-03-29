﻿namespace FRCScouting_API.Models
{
    public class ApiSettings
    {
        public string? ConfigurationDataContext { get; set; } // keep in appsettings.json
        public string? ConfigurationDataContextCredentials { get; set; } // keep in secrets

        public string? TbaApiUrl { get; set; }
        public string? TbaApiKey { get; set; }
    }
}
