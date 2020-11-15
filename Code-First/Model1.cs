namespace Code_First
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        // Контекст настроен для использования строки подключения "GameCS" из файла конфигурации  
        // приложения (App.config).
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "GameCS" 
        // в файле конфигурации приложения.
        public Model1() : base("Model1") { }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.
        public DbSet<client> clients { get; set; }
        public DbSet<worker> sorkers { get; set; }
    }


}