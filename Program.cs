using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.Run(new Form1());
        }
    }

    //CRUD-операции и фильтрация
    public class TaskManager
    {
        private readonly TaskContext _taskContext;
        
        public TaskManager()
        {
            _taskContext = new TaskContext();
            _taskContext.Database.EnsureCreated(); //Создает БД и таблицы (если их нет)
        }
        //Добавление задачи
        public void AddTask(Task task)
        {
            _taskContext.Tasks.Add(task);
            _taskContext.SaveChanges();
        }
        //Получение задач пользователя
        public List<Task> GetTaskByUser(int userId)
        {
            return _taskContext.Tasks
                .Where(t => t.UserID == userId)
                .ToList();
        }
        //Обновление задачи
        public void UpdateTask(Task task)
        {
            _taskContext.Tasks.Update(task);
            _taskContext.SaveChanges();
        }
        //Удаление задач
        public void DeleteTask(int taskId)
        {
            var task = _taskContext.Tasks.Find(taskId);
            if (task != null)
            {
                _taskContext.Tasks.Remove(task);
                _taskContext.SaveChanges();
            }
        }
        //Фильтр задач по статусу
        public List<Task> FilterTasksByStatus(int userId, string status)
        {
            return _taskContext.Tasks
                .Where(t => t.UserID == userId && t.Status == status)
                .ToList();
        }
    }
}
