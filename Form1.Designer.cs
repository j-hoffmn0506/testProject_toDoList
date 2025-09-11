namespace testProject_toDoList
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.datePickerDueDate = new System.Windows.Forms.DateTimePicker();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDes = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelDate = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTasks
            // 
            this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTasks.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewTasks.Name = "dataGridViewTasks";
            this.dataGridViewTasks.Size = new System.Drawing.Size(576, 308);
            this.dataGridViewTasks.TabIndex = 0;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(12, 338);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(576, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // comboStatus
            // 
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Location = new System.Drawing.Point(388, 463);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(121, 21);
            this.comboStatus.TabIndex = 2;
            // 
            // datePickerDueDate
            // 
            this.datePickerDueDate.Location = new System.Drawing.Point(388, 437);
            this.datePickerDueDate.Name = "datePickerDueDate";
            this.datePickerDueDate.Size = new System.Drawing.Size(200, 20);
            this.datePickerDueDate.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 375);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(576, 56);
            this.txtDescription.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 437);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 38);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить";
            this.toolTip1.SetToolTip(this.btnAdd, "Добавить задачу");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(174, 438);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 37);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Изменить";
            this.toolTip1.SetToolTip(this.btnEdit, "Изменить задачу (не работает)");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(93, 438);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 37);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Удалить";
            this.toolTip1.SetToolTip(this.btnDelete, "Удалить выделенную задачу");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(93, 481);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 37);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Фильтр";
            this.toolTip1.SetToolTip(this.btnFilter, "Выберите статус задачи для фильтрации по нему");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(12, 323);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(57, 13);
            this.labelTitle.TabIndex = 9;
            this.labelTitle.Text = "Название";
            // 
            // labelDes
            // 
            this.labelDes.AutoSize = true;
            this.labelDes.Location = new System.Drawing.Point(12, 359);
            this.labelDes.Name = "labelDes";
            this.labelDes.Size = new System.Drawing.Size(57, 13);
            this.labelDes.TabIndex = 10;
            this.labelDes.Text = "Описание";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(285, 443);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(97, 13);
            this.labelDate.TabIndex = 11;
            this.labelDate.Text = "Срок выполнения";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(303, 471);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(79, 13);
            this.labelStatus.TabIndex = 12;
            this.labelStatus.Text = "Статус задачи";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 528);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelDes);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.datePickerDueDate);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.dataGridViewTasks);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(616, 567);
            this.MinimumSize = new System.Drawing.Size(616, 567);
            this.Name = "MainForm";
            this.Text = "Список задач";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTasks;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.DateTimePicker datePickerDueDate;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDes;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelStatus;
    }
}

