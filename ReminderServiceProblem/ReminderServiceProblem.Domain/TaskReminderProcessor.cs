using ReminderServiceProblem.DataAccess;

namespace ReminderServiceProblem.Domain
{
    public class TaskReminderProcessor : ITaskReminderProcessor
    {
        private static readonly List<TaskReminder> _tasks = new List<TaskReminder>();
        private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public async Task AddTasksToQueue(List<TaskReminder> taskReminders)
        {
            if (taskReminders.Any())
            {
                Console.WriteLine($"New tasks:{taskReminders.Count()} found. Adding {taskReminders.Count()} to queue");
                await _semaphore.WaitAsync();
                try
                {
                    _tasks.AddRange(taskReminders);
                    Console.WriteLine("\r\n");
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("\r\n");
                    Console.WriteLine("currentTime: " + DateTime.Now);
                    taskReminders.ForEach(x => Console.WriteLine($"Added Task:{x.Name}, time:{x.ReminderTime}"));
                    Console.WriteLine($"tasks added. Total tasks: {_tasks.Count()}");
                    Console.WriteLine("\r\n");
                }
                finally
                {
                    _semaphore.Release();
                }
            }
        }

        public async Task<List<TaskReminder>> GetAllTasks()
        {
            var currentDateTime = DateTime.Now;
            await Task.CompletedTask;
            return _tasks.Where(x => x.ReminderTime.Date == currentDateTime.Date && x.ReminderTime.Hour == currentDateTime.Hour &&
                                     x.ReminderTime.Minute == currentDateTime.Minute && x.ReminderTime.Second == currentDateTime.Second).ToList();
        }
    }
}
