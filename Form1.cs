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
        public MainForm()
        {
            InitializeComponent();
            _taskManager = new TaskManager();
            LoadTasks();
            comboStatus.Items.AddRange(new[] { "ToDo", "InProgress", "Done" });
        }

        private void LoadTasks()
        {
            dataGridViewTasks.DataSource = _taskManager.GetTaskByUser( _currentUserId );
        }

        private void ClearInputs()
        {
            txtTitle.Clear();
            txtDescrition.Clear();
            comboStatus.SelectedIndex = 0;
            datePickerDueDate.Value = DateTime.Now;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Task task = new Task();

            task.Title = txtTitle.Text;
            task.Description = txtDescrition.Text;
            task.Status = comboStatus.SelectedItem?.ToString() ?? "ToDo";
            task.DueDate = datePickerDueDate.Value;
            task.UserID = _currentUserId;

            _taskManager.AddTask( task );
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

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string status = comboStatus.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(status))
            {
                dataGridViewTasks.DataSource = _taskManager.FilterTasksByStatus(_currentUserId, status);
            }
        }

        private void labelDate_Click(object sender, EventArgs e)
        {

        }
    }
}
