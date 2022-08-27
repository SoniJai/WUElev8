namespace ReminderServiceProblem.DataAccess
{
    public interface IReminderRepo
    {
        Task Create(TaskReminder taskReminder);
        Task Remove(TaskReminder taskReminder);
        Task<List<TaskReminder>> GetAll();
    }    

}