using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProject_toDoList
{
    public class TaskTests
    {
        private readonly TaskManager _taskManager;

        public TaskTests()
        {
            _taskManager = new TaskManager();
        }

        /// <summary>
        /// Запускает все тесты
        /// </summary>
        /// <returns>Возвращает общий результат в string</returns>
        public string RunTests()
        {
            string results = "=== Результаты тестов TaskManager ===\n";
            results += TestAddTask() + "\n";
            results += TestGetTasksByUser() + "\n";
            results += TestDeleteTask() + "\n";
            results += TestFilterTasksByStatus() + "\n";
            results += TestEditTask() + "\n";
            results += TestFilterReset() + "\n";
            results += "=== Тесты завершены ===\n";
            return results;
        }

        /// <summary>
        /// Тест добавления задач
        /// </summary>
        /// <returns>Возвращает результат в string</returns>
        private string TestAddTask()
        {
            try
            {
                var task = new Task
                {
                    Title = "Тестовая задача",
                    Description = "Описание тестовой задачи",
                    Status = "Выполнить",
                    DueDate = DateTime.Now,
                    UserID = 1
                };
                _taskManager.AddTask(task);
                var tasks = _taskManager.GetTasksByUser(1);
                if (tasks.Any(t => t.Title == "Тестовая задача"))
                {
                    return "Тест 1: Добавление задачи - ✓ Успех: Задача добавлена";
                }
                else
                {
                    return "Тест 1: Добавление задачи - ✗ Ошибка: Задача не найдена после добавления";
                }
            }
            catch (Exception ex)
            {
                return $"Тест 1: Добавление задачи - ✗ Ошибка: {ex.Message}";
            }
        }

        /// <summary>
        /// Тест поиска задач пользователя
        /// </summary>
        /// <returns>Возвращает результат в string</returns>
        private string TestGetTasksByUser()
        {
            try
            {
                var tasks = _taskManager.GetTasksByUser(1);
                if (tasks.Count > 0)
                {
                    string taskList = "";
                    foreach (var task in tasks)
                    {
                        taskList += $"  - Задача: {task.Title}, Статус: {task.Status}, Дата: {task.DueDate?.ToString("dd.MM.yyyy")}\n";
                    }
                    return $"Тест 2: Получение задач по UserID - ✓ Успех: Найдено {tasks.Count} задач для UserID=1\n{taskList}";
                }
                else
                {
                    return "Тест 2: Получение задач по UserID - ✗ Ошибка: Задачи не найдены для UserID=1";
                }
            }
            catch (Exception ex)
            {
                return $"Тест 2: Получение задач по UserID - ✗ Ошибка: {ex.Message}";
            }
        }

        /// <summary>
        /// Тест удаления задач
        /// </summary>
        /// <returns>Возвращает результат в string</returns>
        private string TestDeleteTask()
        {
            try
            {
                var task = new Task
                {
                    Title = "Задача для удаления",
                    Description = "Описание",
                    Status = "Выполнить",
                    DueDate = DateTime.Now,
                    UserID = 1
                };
                _taskManager.AddTask(task);
                var tasks = _taskManager.GetTasksByUser(1);
                var taskToDelete = tasks.FirstOrDefault(t => t.Title == "Задача для удаления");
                if (taskToDelete != null)
                {
                    _taskManager.DeleteTask(taskToDelete.ID);
                    tasks = _taskManager.GetTasksByUser(1);
                    if (!tasks.Any(t => t.Title == "Задача для удаления"))
                    {
                        return "Тест 3: Удаление задачи - ✓ Успех: Задача удалена";
                    }
                    else
                    {
                        return "Тест 3: Удаление задачи - ✗ Ошибка: Задача не была удалена";
                    }
                }
                else
                {
                    return "Тест 3: Удаление задачи - ✗ Ошибка: Задача для удаления не создана";
                }
            }
            catch (Exception ex)
            {
                return $"Тест 3: Удаление задачи - ✗ Ошибка: {ex.Message}";
            }
        }

        /// <summary>
        /// Тетс фильтрации задач по статусу
        /// </summary>
        /// <returns>Возвращает результат в string</returns>
        private string TestFilterTasksByStatus()
        {
            try
            {
                var task = new Task
                {
                    Title = "Задача для фильтра",
                    Description = "Описание",
                    Status = "В процессе",
                    DueDate = DateTime.Now,
                    UserID = 1
                };
                _taskManager.AddTask(task);
                var filteredTasks = _taskManager.FilterTasksByStatus(1, "InProgress");
                if (filteredTasks.Any(t => t.Title == "Задача для фильтра"))
                {
                    return "Тест 4: Фильтрация задач по статусу - ✓ Успех: Задачи отфильтрованы по статусу InProgress";
                }
                else
                {
                    return "Тест 4: Фильтрация задач по статусу - ✗ Ошибка: Задачи с InProgress не найдены";
                }
            }
            catch (Exception ex)
            {
                return $"Тест 4: Фильтрация задач по статусу - ✗ Ошибка: {ex.Message}";
            }
        }

        /// <summary>
        /// Тест редактирования задач
        /// </summary>
        /// <returns>Возвращает результат в string</returns>
        private string TestEditTask()
        {
            try
            {
                var task = new Task
                {
                    Title = "Задача до редактирования",
                    Description = "Описание",
                    Status = "Выполнить",
                    DueDate = DateTime.Now,
                    UserID = 1
                };
                _taskManager.AddTask(task);
                var tasks = _taskManager.GetTasksByUser(1);
                var taskToEdit = tasks.FirstOrDefault(t => t.Title == "Задача до редактирования");
                if (taskToEdit != null)
                {
                    _taskManager.DeleteTask(taskToEdit.ID);
                    var newTask = new Task
                    {
                        Title = "Задача после редактирования",
                        Description = "Новое описание",
                        Status = "Готово",
                        DueDate = DateTime.Now.AddDays(1),
                        UserID = 1
                    };
                    _taskManager.AddTask(newTask);
                    tasks = _taskManager.GetTasksByUser(1);
                    if (tasks.Any(t => t.Title == "Задача после редактирования") &&
                        !tasks.Any(t => t.Title == "Задача до редактирования"))
                    {
                        return "Тест 5: Редактирование задачи - ✓ Успех: Задача отредактирована (удалена и добавлена новая)";
                    }
                    else
                    {
                        return "Тест 5: Редактирование задачи - ✗ Ошибка: Редактирование не удалось";
                    }
                }
                else
                {
                    return "Тест 5: Редактирование задачи - ✗ Ошибка: Задача для редактирования не создана";
                }
            }
            catch (Exception ex)
            {
                return $"Тест 5: Редактирование задачи - ✗ Ошибка: {ex.Message}";
            }
        }

        /// <summary>
        /// Тест сброса фильтрации
        /// </summary>
        /// <returns>Возвращает результат в string</returns>
        private string TestFilterReset()
        {
            try
            {
 
                var task1 = new Task
                {
                    Title = "Задача Выполнить",
                    Description = "ToDo задача",
                    Status = "Выполнить",
                    DueDate = DateTime.Now,
                    UserID = 1
                };
                var task2 = new Task
                {
                    Title = "Задача В процессе",
                    Description = "InProgress задача",
                    Status = "В процессе",
                    DueDate = DateTime.Now,
                    UserID = 1
                };
                _taskManager.AddTask(task1);
                _taskManager.AddTask(task2);

                var allTasks = _taskManager.GetTasksByUser(1);
                int allCount = allTasks.Count;

                var filteredTasks = _taskManager.FilterTasksByStatus(1, "Выполнить");
                int filteredCount = filteredTasks.Count;

                var resetTasks = _taskManager.GetTasksByUser(1);
                int resetCount = resetTasks.Count;

                if (allCount > filteredCount && resetCount == allCount)
                {
                    return "Тест 6: Сброс фильтра - ✓ Успех: Фильтр уменьшил список, сброс вернул полный (всего задач: " + allCount + ")";
                }
                else
                {
                    return "Тест 6: Сброс фильтра - ✗ Ошибка: Фильтр или сброс не сработал (всего: " + allCount + ", отфильтровано: " + filteredCount + ", после сброса: " + resetCount + ")";
                }
            }
            catch (Exception ex)
            {
                return $"Тест 6: Сброс фильтра - ✗ Ошибка: {ex.Message}";
            }
        }
    }
}
