﻿namespace Utilities.Model
{
    public class AppSettingsModel
    {
        public ConnectionStringsModel? ConnectionStrings { get; set; }
        public CommonSettings? CommonSettings { get; set; }
        public ImageSettings? ImageSettings { get; set; }
    }
    public class ConnectionStringsModel
    {
        public string? DefaultConnection { get; set; }
    }
    public class CommonSettings
    {
        public string? APIBaseUrl { get; set; }
        public string? CorsPolicyName { get; set; }
        public string? CorsAllowedUrls { get; set; }
    }
    public class ImageSettings
    {
        public string? Products { get; set; }
    }
}
