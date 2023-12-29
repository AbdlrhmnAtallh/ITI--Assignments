using FinalProject_HRsystem.Models.TaskINFO;

namespace FinalProject_HRsystem.Services
{
    public class TaskLayer
    {
        public List<Taskk> Tasks= new List<Taskk>();

        public void Add(Taskk task)
        {
            try
            {
                Tasks.Add(task);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Add New Task ", ex);
            }
         
        }
        public void Update(Taskk task)
        {
            try
            {
                var TempTask = Tasks.FirstOrDefault(t => t.Id == task.Id);
                if (TempTask != null)
                {
                    TempTask.Name = task.Name;
                    TempTask.CreatedAt = task.CreatedAt;
                    TempTask.DueDate = task.CreatedAt;
                    TempTask.Description = task.Description;
                    TempTask.IsCompleted = task.IsCompleted;
                    TempTask.Priority = task.Priority;
                    TempTask.Employees = task.Employees;
                }
                else
                    throw new Exception("Task Not Found.");
            }
            catch(Exception ex)
            {
                throw new Exception("Can't Update Task.", ex);
            }
        }
        public void Delete(Taskk task)
        {
            Tasks.Remove(task);
        }
        public List<Taskk> All()
        {
            return Tasks.ToList();
        }
        public Taskk GetOneTask(int id)
        {
            try
            {
                var task = Tasks.FirstOrDefault(e => e.Id == id);
                if (task != null)
                {
                    return task;
                }
                else
                    throw new Exception("Task Not Found.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error Csn't Read Task .", ex);
            }
        }

    }
}
