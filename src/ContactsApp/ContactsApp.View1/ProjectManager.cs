namespace ContactsApp.Model
{
    using System;

    /// <summary>
    /// Менеджер проекта.
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        /// Путь к файлу, включая папку Rouming
        /// </summary>
        private static string _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        private static string _patch = $@"{_appData}\FedorovAnton\ContactApp\data.json";
    }
}
