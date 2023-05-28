namespace ContactsApp.Model
{
    using System;
    using Newtonsoft.Json;
    using System.IO;

    /// <summary>
    /// Менеджер проекта.
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        /// Путь к системной папке AppData.
        /// </summary>
        private static string _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// Имя файла.
        /// </summary>
        private static string _fileName = "\\data.json";

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        private static string _patch = $@"{_appData}\FedorovAnton\ContactApp\";


        /// <summary>
        /// Возвращает путь к файлу.
        /// </summary>
        public string Patch { get { return _patch; } }

        /// <summary>
        /// Возвращает имя файла.
        /// </summary>
        public string FileName { get { return _fileName; } }

        /// <summary>
        /// Запись контактов в файл.
        /// </summary>
        /// <param name="project">Список контактов.</param>
        public void SaveToFile(Project project)
        {
            if (!Directory.Exists(Patch))
            {
                Directory.CreateDirectory(Patch);
            }
            string json = JsonConvert.SerializeObject(project, Formatting.Indented);
            File.WriteAllText(Patch + FileName, json);
        }

        /// <summary>
        /// Загрузка контакта из файла.
        /// </summary>
        /// <returns>Список контактов.</returns>
        public Project LoadFromFile()
        {
            try
            {
                Project project;
                string json = File.ReadAllText(Patch + FileName);
                project = JsonConvert.DeserializeObject<Project>(json);
                return project ?? new Project();
            }
            catch (Exception)
            {
                return new Project();
            }
        }
    }
}
