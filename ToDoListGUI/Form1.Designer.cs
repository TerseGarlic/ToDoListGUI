using System.Media;
using System.Windows.Forms;

namespace ToDoListGUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Task Controls
        private System.Windows.Forms.ListBox listBoxTasks;
        private System.Windows.Forms.TextBox textBoxInput;

        // Action Buttons
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.Button buttonRemoveTask;
        private System.Windows.Forms.Button buttonMarkComplete;
        private System.Windows.Forms.Button buttonSaveTasks;
        private System.Windows.Forms.Button buttonLoadTasks;
        private System.Windows.Forms.Button buttonClearCompleted;

        // Theme Toggle
        private System.Windows.Forms.CheckBox buttonToggleTheme;

        /// <summary>
        /// Dispose any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.listBoxTasks = new System.Windows.Forms.ListBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonToggleTheme = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBoxTasks
            // 
            this.listBoxTasks.Location = new System.Drawing.Point(12, 12);
            this.listBoxTasks.Name = "listBoxTasks";
            this.listBoxTasks.Size = new System.Drawing.Size(714, 238);
            this.listBoxTasks.TabIndex = 0;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(12, 265);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(714, 26);
            this.textBoxInput.TabIndex = 1;
            // 
            // buttonToggleTheme
            // 
            this.buttonToggleTheme.AutoSize = true;
            this.buttonToggleTheme.Location = new System.Drawing.Point(656, 305);
            this.buttonToggleTheme.Name = "buttonToggleTheme";
            this.buttonToggleTheme.Size = new System.Drawing.Size(79, 17);
            this.buttonToggleTheme.TabIndex = 8;
            this.buttonToggleTheme.Text = "Dark Mode";
            this.buttonToggleTheme.CheckedChanged += new System.EventHandler(this.ButtonToggleTheme_CheckedChanged);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(738, 341);
            this.Controls.Add(this.listBoxTasks);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.buttonToggleTheme);
            this.Name = "Form1";
            this.Text = "To-Do List";
            // Add Task
            this.buttonAddTask = CreateButton("Add", 12, 300, ButtonAddTask_Click);
            this.Controls.Add(this.buttonAddTask);

            // Remove Task
            this.buttonRemoveTask = CreateButton("Remove", 118, 300, ButtonRemoveTask_Click);
            this.Controls.Add(this.buttonRemoveTask);

            // Mark Complete
            this.buttonMarkComplete = CreateButton("Complete", 224, 300, ButtonMarkComplete_Click);
            this.Controls.Add(this.buttonMarkComplete);

            // Save Tasks
            this.buttonSaveTasks = CreateButton("Save", 330, 300, ButtonSaveTasks_Click);
            this.Controls.Add(this.buttonSaveTasks);

            // Load Tasks
            this.buttonLoadTasks = CreateButton("Load", 436, 300, ButtonLoadTasks_Click);
            this.Controls.Add(this.buttonLoadTasks);

            // Clear Completed
            this.buttonClearCompleted = CreateButton("Clear Completed", 542, 300, ButtonClearCompleted_Click);
            this.Controls.Add(this.buttonClearCompleted);

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button CreateButton(string text, int x, int y, System.EventHandler onClick)
        {
            var btn = new System.Windows.Forms.Button();
            btn.Text = text;
            btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new System.Drawing.Size(100, 30);
            btn.UseVisualStyleBackColor = true;
            btn.Click += onClick;
            return btn;
        }

        #endregion
    }
}
