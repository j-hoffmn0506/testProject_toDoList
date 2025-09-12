using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using testProject_toDoList;

namespace testProject_toDoList
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    /// <summary>
    /// CRUD-операции и фильтрация
    /// </summary>
    public class TaskManager
    {
        private readonly TaskContext _taskContext;

        public TaskManager()
        {
            _taskContext = new TaskContext();
            _taskContext.Database.EnsureCreated(); //Создает БД и таблицы (если их нет)
            EnsureTestUserExists();
        }

        /// <summary>
        /// Создает тестового пользователя
        /// </summary>
        private void EnsureTestUserExists()
        {
            if (!_taskContext.Users.Any(u => u.ID == 1))
            {
                User testUser = new User();
                testUser.ID = 1;
                testUser.Name = "Test User";
                testUser.Email = "blabla@example.com";
                _taskContext.Users.Add(testUser);
                _taskContext.SaveChanges();
            }
        }
        /// <summary>
        /// Добавление задачи
        /// </summary>
        /// <param name="task">Экземпляр класса Task</param>
        public void AddTask(Task task)
        {
            _taskContext.Tasks.Add(task);
            _taskContext.SaveChanges();
        }
        /// <summary>
        /// Получение задач пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns></returns>
        public List<Task> GetTasksByUser(int userId)
        {
            return _taskContext.Tasks
                .Where(t => t.UserID == userId)
                .ToList();
        }
        /// <summary>
        /// Обновление задачи
        /// </summary>
        /// <param name="task">Экземпляр класса Task</param>
        public void UpdateTask(Task task)
        {
            _taskContext.Tasks.Update(task);
            _taskContext.SaveChanges();
        }
        /// <summary>
        /// Удаление задач
        /// </summary>
        /// <param name="taskId">ID задания</param>
        public void DeleteTask(int taskId)
        {
            var task = _taskContext.Tasks.Find(taskId);
            if (task != null)
            {
                _taskContext.Tasks.Remove(task);
                _taskContext.SaveChanges();
            }
        }
        /// <summary>
        /// Фильтр задач по статусу задачи
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="status">Сатус задания</param>
        /// <returns></returns>
        public List<Task> FilterTasksByStatus(int userId, string status)
        {
            return _taskContext.Tasks
                .Where(t => t.UserID == userId && t.Status == status)
                .ToList();
        }
    }
}
