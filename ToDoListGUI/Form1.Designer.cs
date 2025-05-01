using System.Media;
using System.Windows.Forms;

namespace ToDoListGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Fields for controls (they MUST be private)
        private System.Windows.Forms.ListBox listBoxTasks;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.Button buttonRemoveTask;
        private System.Windows.Forms.Button buttonMarkComplete;
        private System.Windows.Forms.Button buttonSaveTasks;
        private System.Windows.Forms.Button buttonLoadTasks;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonClearCompleted;
        private System.Windows.Forms.CheckBox buttonToggleTheme;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxTasks = new System.Windows.Forms.ListBox();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.buttonRemoveTask = new System.Windows.Forms.Button();
            this.buttonMarkComplete = new System.Windows.Forms.Button();
            this.buttonSaveTasks = new System.Windows.Forms.Button();
            this.buttonLoadTasks = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonClearCompleted = new System.Windows.Forms.Button();
            this.buttonToggleTheme = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBoxTasks
            // 
            this.listBoxTasks.FormattingEnabled = true;
            this.listBoxTasks.Location = new System.Drawing.Point(12, 12);
            this.listBoxTasks.Name = "listBoxTasks";
            this.listBoxTasks.Size = new System.Drawing.Size(714, 238);
            this.listBoxTasks.TabIndex = 0;
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.Location = new System.Drawing.Point(12, 300);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(100, 30);
            this.buttonAddTask.TabIndex = 2;
            this.buttonAddTask.Text = "Add";
            this.buttonAddTask.Click += new System.EventHandler(this.ButtonAddTask_Click);
            // 
            // buttonRemoveTask
            // 
            this.buttonRemoveTask.Location = new System.Drawing.Point(118, 300);
            this.buttonRemoveTask.Name = "buttonRemoveTask";
            this.buttonRemoveTask.Size = new System.Drawing.Size(100, 30);
            this.buttonRemoveTask.TabIndex = 3;
            this.buttonRemoveTask.Text = "Remove";
            this.buttonRemoveTask.Click += new System.EventHandler(this.ButtonRemoveTask_Click);
            // 
            // buttonMarkComplete
            // 
            this.buttonMarkComplete.Location = new System.Drawing.Point(224, 300);
            this.buttonMarkComplete.Name = "buttonMarkComplete";
            this.buttonMarkComplete.Size = new System.Drawing.Size(100, 30);
            this.buttonMarkComplete.TabIndex = 4;
            this.buttonMarkComplete.Text = "Complete";
            this.buttonMarkComplete.Click += new System.EventHandler(this.ButtonMarkComplete_Click);
            // 
            // buttonSaveTasks
            // 
            this.buttonSaveTasks.Location = new System.Drawing.Point(330, 300);
            this.buttonSaveTasks.Name = "buttonSaveTasks";
            this.buttonSaveTasks.Size = new System.Drawing.Size(100, 30);
            this.buttonSaveTasks.TabIndex = 5;
            this.buttonSaveTasks.Text = "Save";
            this.buttonSaveTasks.Click += new System.EventHandler(this.ButtonSaveTasks_Click);
            // 
            // buttonLoadTasks
            // 
            this.buttonLoadTasks.Location = new System.Drawing.Point(436, 300);
            this.buttonLoadTasks.Name = "buttonLoadTasks";
            this.buttonLoadTasks.Size = new System.Drawing.Size(100, 30);
            this.buttonLoadTasks.TabIndex = 6;
            this.buttonLoadTasks.Text = "Load";
            this.buttonLoadTasks.Click += new System.EventHandler(this.ButtonLoadTasks_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(12, 265);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(714, 20);
            this.textBoxInput.TabIndex = 1;
            // 
            // buttonClearCompleted
            // 
            this.buttonClearCompleted.Location = new System.Drawing.Point(542, 300);
            this.buttonClearCompleted.Name = "buttonClearCompleted";
            this.buttonClearCompleted.Size = new System.Drawing.Size(100, 29);
            this.buttonClearCompleted.TabIndex = 7;
            this.buttonClearCompleted.Text = "Clear Completed";
            this.buttonClearCompleted.UseVisualStyleBackColor = true;
            this.buttonClearCompleted.Click += new System.EventHandler(this.ButtonClearCompleted_Click);
            // 
            // buttonToggleTheme
            // 
            this.buttonToggleTheme.AutoSize = true;
            this.buttonToggleTheme.Location = new System.Drawing.Point(646, 307);
            this.buttonToggleTheme.Name = "buttonToggleTheme";
            this.buttonToggleTheme.Size = new System.Drawing.Size(79, 17);
            this.buttonToggleTheme.TabIndex = 8;
            this.buttonToggleTheme.Text = "Dark Mode";
            this.buttonToggleTheme.UseVisualStyleBackColor = true;
            this.buttonToggleTheme.CheckedChanged += new System.EventHandler(this.ButtonToggleTheme_CheckedChanged);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(738, 341);
            this.Controls.Add(this.buttonToggleTheme);
            this.Controls.Add(this.buttonClearCompleted);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.listBoxTasks);
            this.Controls.Add(this.buttonAddTask);
            this.Controls.Add(this.buttonRemoveTask);
            this.Controls.Add(this.buttonMarkComplete);
            this.Controls.Add(this.buttonSaveTasks);
            this.Controls.Add(this.buttonLoadTasks);
            this.Name = "Form1";
            this.Text = "To-Do List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
#endregion