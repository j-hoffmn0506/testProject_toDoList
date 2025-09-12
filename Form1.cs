using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testProject_toDoList
{
    public partial class MainForm : Form
    {

        private readonly TaskManager _taskManager;
        private readonly int _currentUserId = 1;
        private int? _editingTaskId = null;
        /// <summary>
        /// Инициализация формы и некоторых копонентов
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _taskManager = new TaskManager();
            LoadTasks();
            comboStatus.Items.AddRange(new[] { "Выполнить", "В процессе", "Готово" });
        }
        /// <summary>
        /// Загружает задачи текущего пользователя
        /// </summary>
        private void LoadTasks()
        {
            dataGridViewTasks.DataSource = _taskManager.GetTasksByUser(_currentUserId);

            //Скрывает ненужные столбцы
            if (dataGridViewTasks.Columns["ID"] != null)
                dataGridViewTasks.Columns["ID"].Visible = false;
            if (dataGridViewTasks.Columns["UserID"] != null)
                dataGridViewTasks.Columns["UserID"].Visible = false;
            if (dataGridViewTasks.Columns["User"] != null)
                dataGridViewTasks.Columns["User"].Visible = false;

            if (dataGridViewTasks.Columns["Title"] != null)
                dataGridViewTasks.Columns["Title"].HeaderText = "Название";
            if (dataGridViewTasks.Columns["Description"] != null)
                dataGridViewTasks.Columns["Description"].Width = 233;
                dataGridViewTasks.Columns["Description"].HeaderText = "Описание";
            if (dataGridViewTasks.Columns["Status"] != null)
                dataGridViewTasks.Columns["Status"].HeaderText = "Статус";
            if (dataGridViewTasks.Columns["DueDate"] != null)
            {
                dataGridViewTasks.Columns["DueDate"].HeaderText = "Срок выполнения";
                dataGridViewTasks.Columns["DueDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
                
            
            _editingTaskId = null;
            btnAdd.Enabled = true;
            btnCancel.Enabled = false;
            btnResetFilter.Enabled = false;
        }

        /// <summary>
        /// Очистка инпутов
        /// </summary>
        private void ClearInputs()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            comboStatus.SelectedIndex = 0;
            datePickerDueDate.Value = DateTime.Now;
        }

        /// <summary>
        /// Кнопка добавления задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Task task = new Task();

            task.Title = txtTitle.Text;
            task.Description = txtDescription.Text;
            task.Status = comboStatus.SelectedItem?.ToString() ?? "Выполнить";
            task.DueDate = datePickerDueDate.Value;
            task.UserID = _currentUserId;

            _taskManager.AddTask(task);
            LoadTasks();
            ClearInputs();
            MessageBox.Show("Задача добавлена");
        }

        /// <summary>
        /// Кнопка удаления задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                int taskId = (int)dataGridViewTasks.SelectedRows[0].Cells["ID"].Value;
                _taskManager.DeleteTask(taskId);
                LoadTasks();
                MessageBox.Show("Задача удалена");
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления");
            }
        }

        /// <summary>
        /// Кнопка фильтрации по статусу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            string status = comboStatus.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(status))
            {
                dataGridViewTasks.DataSource = _taskManager.FilterTasksByStatus(_currentUserId, status);
            }
            btnResetFilter.Enabled = true;
        }

        /// <summary>
        /// Кнопка редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите задачу для редактирования");
                return;
            }

            if (_editingTaskId == null)
            {
                var selecteRow = dataGridViewTasks.SelectedRows[0];
                _editingTaskId = (int)selecteRow.Cells["ID"].Value;

                txtTitle.Text = selecteRow.Cells["Title"].Value.ToString();
                txtDescription.Text = selecteRow.Cells["Description"].Value.ToString();
                comboStatus.Text = selecteRow.Cells["Status"].Value.ToString();
                datePickerDueDate.Value = selecteRow.Cells["DueDate"].Value != null
                    ? Convert.ToDateTime(selecteRow.Cells["DueDate"].Value)
                    : DateTime.Now;

                btnAdd.Enabled = false;
                btnCancel.Enabled = true;
                btnEdit.Text = "Сохранить";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Выберите задачу для редактирования");
                    return;
                }

                _taskManager.DeleteTask(_editingTaskId.Value);

                Task task = new Task();
                {
                    task.Title = txtTitle.Text;
                    task.Description = txtDescription.Text;
                    task.Status = comboStatus.SelectedItem?.ToString() ?? "Выполнить";
                    task.DueDate = datePickerDueDate.Value;
                    task.UserID = _currentUserId;
                }
                _taskManager.UpdateTask(task);
                LoadTasks();
                ClearInputs();
                btnEdit.Text = "Изменить";
                MessageBox.Show("Задача обновлена");
            }
        }

        /// <summary>
        /// Кнопка отмены редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputs();
            _editingTaskId = null;
            MessageBox.Show("Редактирование отменено");
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnEdit.Text = "Изменить";
        }

        /// <summary>
        /// Кнопка сброса фильтров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            comboStatus.SelectedIndex = 0;
            LoadTasks();
            btnResetFilter.Enabled = false;
            MessageBox.Show("Фильтр сброшен\nВидны все задачи");
        }

        /// <summary>
        /// Кнопка запускающая тесты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTests_Click(object sender, EventArgs e)
        {
            try
            {
                var tests = new TaskTests();
                string results = tests.RunTests();
                MessageBox.Show(results, "Результаты тестов", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запуске тестов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadTasks();
            ClearInputs();
        }
    }
}
