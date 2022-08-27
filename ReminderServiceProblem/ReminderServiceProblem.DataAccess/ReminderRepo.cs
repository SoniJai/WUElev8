namespace ReminderServiceProblem.DataAccess
{
    public class ReminderRepo : IReminderRepo
    {
        private static readonly List<TaskReminder> _tasks = new List<TaskReminder>() { 
            new TaskReminder
            {
                Name = "A", ReminderTime = DateTime.Now.AddSeconds(5)
            },
            new TaskReminder
            {
                Name = "B", ReminderTime = DateTime.Now.AddSeconds(10)
            },
            new TaskReminder
            {
                Name = "C", ReminderTime = DateTime.Now.AddSeconds(15)
            },
            new TaskReminder
            {
                Name = "D", ReminderTime = DateTime.Now.AddSeconds(20)
            },
            new TaskReminder
            {
                Name = "E", ReminderTime = DateTime.Now.AddSeconds(25)
            },
            new TaskReminder
            {
                Name = "F", ReminderTime = DateTime.Now.AddSeconds(30)
            },
            new TaskReminder
            {
                Name = "G", ReminderTime = DateTime.Now.AddMinutes(1)
            },
            new TaskReminder
            {
                Name = "H", ReminderTime = DateTime.Now.AddMinutes(2)
            }
        };

        private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public async Task Create(TaskReminder taskReminder)
        {
            await _semaphore.WaitAsync();
            try
            {
                _tasks.Add(taskReminder);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task Remove(TaskReminder taskReminder)
        {
            await _semaphore.WaitAsync();
            try
            {
                _tasks.Remove(taskReminder);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<List<TaskReminder>> GetAll()
        {
            await Task.CompletedTask;
            return _tasks;
        }
    }
}