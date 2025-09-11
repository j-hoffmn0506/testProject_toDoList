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
        public MainForm()
        {
            InitializeComponent();
            _taskManager = new TaskManager();
            LoadTasks();
            comboStatus.Items.AddRange(new[] { "Выполнить", "В процессе", "Готово" });
        }

        private void LoadTasks()
        {
            dataGridViewTasks.DataSource = _taskManager.GetTaskByUser(_currentUserId);

            //Скрывает ненужные столбцы
            if (dataGridViewTasks.Columns["ID"] != null)
                dataGridViewTasks.Columns["ID"].Visible = false;
            if (dataGridViewTasks.Columns["UserID"] != null)
                dataGridViewTasks.Columns["UserID"].Visible = false;

            if (dataGridViewTasks.Columns["Title"] != null)
                dataGridViewTasks.Columns["Title"].HeaderText = "Название";
            if (dataGridViewTasks.Columns["Description"] != null)
                dataGridViewTasks.Columns["Description"].HeaderText = "Описание";
            if (dataGridViewTasks.Columns["Status"] != null)
                dataGridViewTasks.Columns["Status"].HeaderText = "Статус";
            if (dataGridViewTasks.Columns["User"] != null)
                dataGridViewTasks.Columns["User"].HeaderText = "Пользователь";
            if (dataGridViewTasks.Columns["DueDate"] != null)
            {
                dataGridViewTasks.Columns["DueDate"].HeaderText = "Срок выполнения";
                dataGridViewTasks.Columns["DueDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
                
            
            _editingTaskId = null;
            btnAdd.Enabled = true;
            
        }

        private void ClearInputs()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            comboStatus.SelectedIndex = 0;
            datePickerDueDate.Value = DateTime.Now;
        }

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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string status = comboStatus.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(status))
            {
                dataGridViewTasks.DataSource = _taskManager.FilterTasksByStatus(_currentUserId, status);
            }
        }

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

    }
}
