using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListGUI
{
    public partial class Form1 : Form
    {

        private void ButtonAddTask_Click(object sender, EventArgs e)
        {
            AddTask(textBoxInput.Text);
            textBoxInput.Clear();
        }

        private void ButtonRemoveTask_Click(object sender, EventArgs e)
        {
            RemoveSelectedTask();
        }

        private void ButtonMarkComplete_Click(object sender, EventArgs e)
        {
            MarkSelectedTaskAsCompleted();
        }

        private void ButtonSaveTasks_Click(object sender, EventArgs e)
        {
            SaveTasks();
        }

        private void ButtonLoadTasks_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private List<TaskItem> tasks = new List<TaskItem>();
        private string filePath = "tasks.txt";

        public Form1()
        {
            InitializeComponent();
            LoadTasks();
            textBoxInput.KeyDown += TextBoxInput_KeyDown;
            listBoxTasks.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxTasks.DrawItem += ListBoxTasks_DrawItem;
            this.FormClosing += Form1_FormClosing;
        }

        private void AddTask(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                tasks.Add(new TaskItem(description));
                UpdateTaskList();
            }
        }

        private void UpdateTaskList()
        {
            listBoxTasks.Items.Clear();
            foreach (var task in tasks)
            {
                string status = task.IsCompleted ? "[X]" : "[ ]";
                listBoxTasks.Items.Add($"{status} {task.Description}");
            }
        }

        private void MarkSelectedTaskAsCompleted()
        {
            int index = listBoxTasks.SelectedIndex;
            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].IsCompleted = true;
                UpdateTaskList();
            }
        }

        private void RemoveSelectedTask()
        {
            int index = listBoxTasks.SelectedIndex;
            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                UpdateTaskList();
            }
        }

        private void SaveTasks()
        {
            List<string> lines = new List<string>();
            foreach (var task in tasks)
                lines.Add($"{task.Description}|{task.IsCompleted}");
            File.WriteAllLines(filePath, lines);
        }

        private void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                tasks.Clear();
                foreach (var line in File.ReadAllLines(filePath))
                {
                    string[] parts = line.Split('|');
                    var task = new TaskItem(parts[0]);
                    if (parts.Length > 1 && bool.TryParse(parts[1], out bool done))
                        task.IsCompleted = done;
                    tasks.Add(task);
                }
                UpdateTaskList();
            }
        }

        private void ListBoxTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= tasks.Count)
                return;

            var task = tasks[e.Index];
            string status = task.IsCompleted ? "[X]" : "[ ]";
            string display = $"{status} {task.Description}";

            Color textColor;
            if (isDarkMode)
                textColor = task.IsCompleted ? Color.DarkGray : Color.White;
            else
                textColor = task.IsCompleted ? Color.Gray : Color.Black;

            e.DrawBackground();
            using (Brush brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(display, e.Font, brush, e.Bounds);
            }
            e.DrawFocusRectangle();
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save tasks when closing the form
            SaveTasks();
        }

        private void TextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddTask(textBoxInput.Text);
                textBoxInput.Clear();
                e.SuppressKeyPress = true; // Prevent the "ding" sound
            }
        }

        private void ButtonClearCompleted_Click(object sender, EventArgs e)
        {
            tasks.RemoveAll(t => t.IsCompleted);
            UpdateTaskList();
        }

        private void ButtonToggleTheme_CheckedChanged(object sender, EventArgs e)
{
    isDarkMode = buttonToggleTheme.Checked;

    Color backColor = isDarkMode ? Color.FromArgb(30, 30, 30) : SystemColors.Control;
    Color foreColor = isDarkMode ? Color.White : SystemColors.ControlText;

    this.BackColor = backColor;
    textBoxInput.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.White;
    textBoxInput.ForeColor = foreColor;

    listBoxTasks.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.White;
    listBoxTasks.ForeColor = foreColor;

    foreach (Control ctrl in this.Controls)
    {
        if (ctrl is Button btn)
        {
            btn.BackColor = isDarkMode ? Color.FromArgb(45, 45, 45) : SystemColors.Control;
            btn.ForeColor = foreColor;
        }
    }

    buttonToggleTheme.Text = isDarkMode ? "Light Mode" : "Dark Mode";
}

        private bool isDarkMode = false;
    }
}
public class TaskItem
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public TaskItem(string description)
    {
        Description = description;
        IsCompleted = false;
    }
}