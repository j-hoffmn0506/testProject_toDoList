using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProject_toDoList
{
    //Данные пользователя 
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Task> Tasks { get; set; } //Навигация
    }

    //Данные о задачах
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

    //Контекст базы данных
    public class TaskContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //Путь к файлу БД
            options.UseSqlite("Data Souce = tasks.db");
        }
    }
}
