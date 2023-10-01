namespace Library.Configuration.SectionNames;

/// <summary>
/// Class for configuration sections
/// </summary>
public static partial class SectionNames
{
    /// <summary>
    /// Gets database sections.
    /// </summary>
    public static class Database
    {
        /// <summary>
        /// Gets connection string.
        /// </summary>
        public static string ConnectionString => "Database:ConnectionString";
    }
}