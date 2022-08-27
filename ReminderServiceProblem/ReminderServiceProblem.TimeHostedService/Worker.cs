using ReminderServiceProblem.DataAccess;
using ReminderServiceProblem.Domain;
using System.Diagnostics;

namespace ReminderServiceProblem.TimeHostedService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IReminderRepo _reminderRepo;
        private readonly ITaskReminderProcessor _taskReminderProcessor;
        private Timer? _timer = null;

        public Worker(ILogger<Worker> logger, IReminderRepo repo, ITaskReminderProcessor taskReminderProcessor)
        {
            _logger = logger;
            _reminderRepo = repo;
            _taskReminderProcessor = taskReminderProcessor;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(ProcessReminders, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(1));

            await Task.CompletedTask;
        }

        private void ProcessReminders(object? state)
        {
            Debug.WriteLine(DateTime.Now);
            var currentDateTime = DateTime.Now;
            var tasks = _reminderRepo.GetAll().GetAwaiter().GetResult();
            Debug.WriteLine("Total tasks: " + tasks.Count());
            var currentTasks = tasks.Where(x => x.ReminderTime.Date == currentDateTime.Date && x.ReminderTime.Hour == currentDateTime.Hour &&
                                     x.ReminderTime.Minute == currentDateTime.Minute && x.ReminderTime.Second == currentDateTime.Second).ToList();
            if (currentTasks.Any())
            {
                Debug.WriteLine("Total current tasks: " + currentTasks.Count());
                _taskReminderProcessor.AddTasksToQueue(currentTasks).GetAwaiter().GetResult();
            }

        }
    }    
}