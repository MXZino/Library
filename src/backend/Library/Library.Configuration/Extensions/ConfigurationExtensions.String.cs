namespace Library.Configuration.Extensions;

using Microsoft.Extensions.Configuration;

/// <summary>
/// Configuration extensions partial class
/// </summary>
public static partial class ConfigurationExtensions
{
    public static string GetString(this IConfiguration configuration, string section) =>
        configuration.GetSection(section).Get<string>()!;
}