using FinalProject_HRsystem.Models.TaskINFO;

namespace FinalProject_HRsystem.Services
{
    public interface ITaskLayer
    {
        void Add(ProjectTask task);
        List<ProjectTask> All();
        void Delete(int id);
        void Edit(ProjectTask task);
        ProjectTask GetOneTask(int id);
        public void DeleteAll();
    }
}