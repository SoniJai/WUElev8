using ReminderServiceProblem.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderServiceProblem.Domain
{
    public interface ITaskReminderProcessor
    {
        Task<List<TaskReminder>> GetAllTasks();
        Task AddTasksToQueue(List<TaskReminder> taskReminders);
    }
}
