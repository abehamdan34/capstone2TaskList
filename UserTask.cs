using System;
using System.Collections.Generic;
using System.Text;

namespace CapStone2TaskList
{
    class UserTask
    {
        public string Name { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completion { get; set; }
        public UserTask()
        {

        }
        public UserTask(string _name, string _taskDescription, DateTime _dueDate, bool _completion = false)
        {
            Name = _name;
            TaskDescription = _taskDescription;
            DueDate = _dueDate;
            Completion = _completion;

        }

        public void CompleteTask()
        {
            Completion = true;
        }

        public override string ToString()
        {
            return $"Team Member Name: {Name}\n   Task Description: {TaskDescription}\n   Due Date: {DueDate}\n   Completed: {Completion}";
        }
    }
}
