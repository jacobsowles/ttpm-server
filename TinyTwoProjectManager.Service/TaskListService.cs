using System.Linq;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public interface ITaskListService
    {
        void CreateTaskList(TaskList taskList);

        void DeleteTaskList(TaskList taskList);

        TaskList GetTaskList(int id);

        IQueryable<TaskList> GetTaskLists(int projectId = 0);

        void SaveTaskList();
    }

    public class TaskListService : ITaskListService
    {
        private readonly ITaskListRepository _taskListRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TaskListService(ITaskListRepository taskListRepository, IUnitOfWork unitOfWork)
        {
            _taskListRepository = taskListRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateTaskList(TaskList taskList)
        {
            _taskListRepository.Add(taskList);
        }

        public void DeleteTaskList(TaskList taskList)
        {
            _taskListRepository.Delete(taskList);
        }

        public TaskList GetTaskList(int id)
        {
            return _taskListRepository.GetById(id);
        }

        public IQueryable<TaskList> GetTaskLists(int projectId = 0)
        {
            var taskLists = _taskListRepository.GetAll();
            
            return
                projectId == 0
                ? taskLists
                : taskLists.Where(tl => tl.ProjectId == projectId);
        }

        public void SaveTaskList()
        {
            _unitOfWork.Commit();
        }
    }
}