using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProject_toDoList
{
    /// <summary>
    /// Данные о пользователе
    /// </summary>
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Task> Tasks { get; set; } //Навигация
    }

    /// <summary>
    /// Данные о задачах
    /// </summary>
    public class Task
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } //Статус задания (ToDo, InProgress, Done)
        public DateTime? DueDate { get; set; }
        public int UserID { get; set; }
        public User User { get; set; } //Навигация
    }

    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class TaskContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        /// <summary>
        /// Метод для создания файла базы данных
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            string dbFolder = Path.Combine(projectRoot, "database"); //Относительный путь (папка database в корне проекта)
            Directory.CreateDirectory(dbFolder); //Создает папку, если не существует
            string dbPath = Path.Combine(dbFolder, "tasks.db"); //Путь к самому файлу БД
            optionsBuilder.UseSqlite($"Data Source = {dbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(t => t.User)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
