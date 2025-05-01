using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoListGUI
{
    public class TaskService
    {
        private readonly string filePath;

        public TaskService(string filePath)
        {
            this.filePath = filePath;
        }

        public List<TaskItem> LoadTasks()
        {
            var tasks = new List<TaskItem>();
            if (!File.Exists(filePath)) return tasks;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                string desc = parts[0];
                bool done = parts.Length > 1 && bool.TryParse(parts[1], out var b) ? b : false;
                string priority = parts.Length > 2 ? parts[2] : "Medium";
                DateTime? due = (parts.Length > 3 && DateTime.TryParse(parts[3], out var dt)) ? dt : (DateTime?)null;
                var task = new TaskItem(desc, priority, due) { IsCompleted = done };
                tasks.Add(task);
            }

            return tasks;
        }

        public void SaveTasks(List<TaskItem> tasks)
        {
            var lines = new List<string>();
            foreach (var task in tasks)
            {
                string due = task.DueDate.HasValue ? task.DueDate.Value.ToString("o") : "";
                lines.Add($"{task.Description}|{task.IsCompleted}|{task.Priority}|{due}");
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
