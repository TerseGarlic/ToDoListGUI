// Refactored To-Do List GUI - Main Form Logic
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ToDoListGUI
{
    public partial class Form1 : Form
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private bool isDarkMode = false;
        private TaskService taskService;

        public Form1()
        {
            InitializeComponent();
            ConfigureFormEvents();
            taskService = new TaskService("tasks.txt");
            tasks = taskService.LoadTasks();
            UpdateTaskList();
        }                                                                           // Form1

        // Configuration
        private void ConfigureFormEvents()
        {
            textBoxInput.KeyDown += HandleEnterKey;
            listBoxTasks.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxTasks.DrawItem += DrawTaskItem;
            listBoxTasks.DoubleClick += ListBoxTasks_DoubleClick;
            FormClosing += SaveTasksOnClose;
        }                                                   // ConfigureFormEvents

        // UI Event Handlers
        private void ButtonAddTask_Click(object sender, EventArgs e)
        {
            var result = ShowAddTaskDialog();
            if (result != null)
            {
                string desc = result.Item1;
                string priority = result.Item2;
                DateTime? dueDate = result.Item3;
                tasks.Add(new TaskItem(desc, priority, dueDate));
                UpdateTaskList();
            }

        }                           // ButtonAddTask

        private void ButtonRemoveTask_Click(object sender, EventArgs e) => RemoveSelectedTask(); // ButtonRemoveTask

        private void ButtonMarkComplete_Click(object sender, EventArgs e) => MarkSelectedTaskAsCompleted(); // ButtonMarkComplete

        private void ButtonSaveTasks_Click(object sender, EventArgs e) => SaveTasks();              // ButtonSaveTasks

        private void ButtonLoadTasks_Click(object sender, EventArgs e)
        {
            LoadTasks();
            UpdateTaskList();
        }                           // ButtonLoadTasks

        private void ButtonClearCompleted_Click(object sender, EventArgs e)
        {
            tasks.RemoveAll(t => t.IsCompleted);
            UpdateTaskList();
        }                       // ButtonClearCompleted

        private void ButtonToggleTheme_CheckedChanged(object sender, EventArgs e)
        {
            isDarkMode = buttonToggleTheme.Checked;
            ApplyTheme();
        }                   // ButtonToggleTheme_CheckedChanged          

        // Core Logic

        private void RemoveSelectedTask()
        {
            int index = listBoxTasks.SelectedIndex;
            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                UpdateTaskList();
            }
        }                                                            // RemoveSelectedTask

        private void MarkSelectedTaskAsCompleted()
        {
            int index = listBoxTasks.SelectedIndex;
            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].IsCompleted = true;
                UpdateTaskList();
            }
        }                                                   // MarkSelectedTaskAsCompleted

        private void UpdateTaskList()
        {
            listBoxTasks.Items.Clear();
            foreach (var task in tasks)
            {
                string status = task.IsCompleted ? "[X]" : "[ ]";
                listBoxTasks.Items.Add(task.ToString());
            }
        }                                                              // UpdateTaskList

        // Persistence
        private void LoadTasks()
        {
            tasks = taskService.LoadTasks();
        }                                                                   // LoadTasks

        private void SaveTasks() => taskService.SaveTasks(tasks);                                       // SaveTasks

        private void SaveTasksOnClose(object sender, FormClosingEventArgs e) => SaveTasks();        // SaveTasksOnClose

        // Drawing Logic
        private void DrawTaskItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= tasks.Count) return;

            var task = tasks[e.Index];
            string status = task.IsCompleted ? "[X]" : "[ ]";
            string display = $"{status} {task.Description}";
            Color textColor = task.IsCompleted ? Color.Gray : (isDarkMode ? Color.White : Color.Black);

            using (var brush = new SolidBrush(textColor))
            {
                e.DrawBackground();
                e.Graphics.DrawString(display, e.Font, brush, e.Bounds);
                e.DrawFocusRectangle();
            }
        }                          // DrawTaskItem                                  

        private void HandleEnterKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonAddTask_Click(sender, e); // trigger fill add task dialog
                e.SuppressKeyPress = true;
            }
        }                                   // HandleEnterKey

        // Theme
        private void ApplyTheme()
        {
            Color backColor = isDarkMode ? Color.FromArgb(30, 30, 30) : SystemColors.Control;
            Color foreColor = isDarkMode ? Color.White : SystemColors.ControlText;

            this.BackColor = backColor;
            textBoxInput.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.White;
            textBoxInput.ForeColor = foreColor;

            listBoxTasks.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.White;
            listBoxTasks.ForeColor = foreColor;

            foreach (Control ctrl in Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = isDarkMode ? Color.FromArgb(45, 45, 45) : SystemColors.Control;
                    btn.ForeColor = foreColor;
                }
            }

            buttonToggleTheme.Text = isDarkMode ? "Light Mode" : "Dark Mode";
        }                                                                 // ApplyTheme

        private Tuple<string, string, DateTime?> ShowAddTaskDialog()
        {
            using (var form = new Form())
            {
                form.Text = "Add New Task";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.Width = 400;
                form.Height = 250;

                var labelWidth = 80;

                var descriptionLabel = new Label() { Left = 10, Top = 13, Width = labelWidth, Text = "Description" };
                var descriptionBox = new TextBox()
                {
                    Left = 100,
                    Top = 10,
                    Width = 250,
                    Height = 20,
                };

                var priorityLabel = new Label() { Left = 10, Top = 50, Width = labelWidth, Text = "Priority" };
                var priorityBox = new ComboBox()
                {
                    Left = 100,
                    Top = 50,
                    Width = 150,
                };

                priorityBox.Items.AddRange(new[] { "High", "Medium", "Low" });
                priorityBox.SelectedIndex = 1;

                var dueDateLabel = new Label() { Left = 10, Top = 90, Width = labelWidth, Text = "Due Date" };
                var dueDatePicker = new DateTimePicker()
                {
                    Left = 100,
                    Top = 90,
                    Width = 150,
                };
                dueDatePicker.Format = DateTimePickerFormat.Short;
                dueDatePicker.Checked = false;
                dueDatePicker.ShowCheckBox = true;

                var okButton = new Button() { Text = "OK", Left = 100, Width = 100, Top = 130, DialogResult = DialogResult.OK };
                form.Controls.AddRange(new Control[] { descriptionLabel, descriptionBox, priorityLabel, priorityBox, dueDateLabel, dueDatePicker, okButton });
                form.AcceptButton = okButton;

                if (form.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(descriptionBox.Text))
                {
                    string desc = descriptionBox.Text;
                    string priority = priorityBox.SelectedItem.ToString();
                    DateTime? due = dueDatePicker.Checked ? dueDatePicker.Value.Date : (DateTime?)null;
                    return Tuple.Create(desc, priority, due);
                }
                else
                {
                    return null;
                }

            }
        }                               // ShowAddTaskDialog

        private void ListBoxTasks_DoubleClick(object sender, EventArgs e)
        {
            int index = listBoxTasks.SelectedIndex;
            if (index < 0 || index >= tasks.Count) return;

            var task = tasks[index];

            string message = $"Description: {task.Description}\n" +
                             $"Priority: {task.Priority}\n" +
                             $"Completed: {(task.IsCompleted ? "Yes" : "No")}\n" +
                             (task.DueDate.HasValue ? $"Due Date: {task.DueDate.Value.ToShortDateString()}" : "No Due Date");

            MessageBox.Show(message, "Task Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }                           // ListBoxTasks_DoubleClick
    }
}
