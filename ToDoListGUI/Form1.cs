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
        private List<TaskItem> tasks = new List<TaskItem>();
        private string filePath = "tasks.txt";

        public Form1()
        {
            InitializeComponent();
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

// Form1.Designer.cs
