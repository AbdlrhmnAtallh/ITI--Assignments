using FinalProject_HRsystem.Models.TaskINFO;

namespace FinalProject_HRsystem.Services
{
    public class TaskLayer : ITaskLayer
    {
        public List<ProjectTask> Tasks = new List<ProjectTask>();

        public void Add(ProjectTask task)
        {
            try
            {
                Tasks.Add(task);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Add a New Task ", ex);
            }

        }
        public void Edit(ProjectTask task)
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
            catch (Exception ex)
            {
                throw new Exception("Can't Update Task.", ex);
            }
        }
        public void Delete(int id)
        {
            var DeletedTask = Tasks.FirstOrDefault(t => t.Id == id);
            try
            {
                Tasks.Remove(DeletedTask);
                if (DeletedTask == null)
                {
                    throw new Exception("Task Not Foud");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Add Task. ", ex);
            }
        }
        public List<ProjectTask> All()
        {
            return Tasks.ToList();
        }
        public ProjectTask GetOneTask(int id)
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
