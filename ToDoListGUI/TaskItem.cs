using System;

namespace ToDoListGUI
{
    public class TaskItem
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string Priority { get; set; }
        public DateTime? DueDate { get; set; }

        public TaskItem(string description)
        {
            Description = description;
            Priority = "Medium";
            DueDate = null;
            IsCompleted = false;
        }

        public TaskItem(string description, string priority, DateTime? dueDate)
        {
            Description = description;
            Priority = priority;
            DueDate = dueDate;
            IsCompleted = false;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "[X]" : "[ ]";
            string date = DueDate.HasValue ? $" (Due: {DueDate.Value:MM/dd/yyyy})" : "";
            return $"{status} [{Priority}] {Description}{date}";
        }
    }
}
