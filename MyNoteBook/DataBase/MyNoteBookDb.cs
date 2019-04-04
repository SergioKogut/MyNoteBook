namespace MyNoteBook.DataBase
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyNoteBookDb : DbContext
    {
        // Контекст настроен для использования строки подключения "MyNoteBookDb" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "MyNoteBook.DataBase.MyNoteBookDb" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "MyNoteBookDb" 
        // в файле конфигурации приложения.
        public MyNoteBookDb()
            : base("name=MyNoteBookDb")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyNoteBookDb>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyNoteBookDb>());
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<NoteBook> NoteBooks { get; set; }
        public virtual DbSet<NoteMessage> NoteMessages { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}