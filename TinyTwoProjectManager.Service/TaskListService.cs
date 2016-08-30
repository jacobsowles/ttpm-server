using System.Collections.Generic;
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

        IEnumerable<TaskList> GetTaskLists(int projectId);

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
            var taskList = _taskListRepository.GetById(id);
            return taskList;
        }

        public IEnumerable<TaskList> GetTaskLists(int projectId)
        {
            var taskLists = _taskListRepository.GetAll().Where(tl => tl.ProjectId == projectId);
            return taskLists;
        }

        public void SaveTaskList()
        {
            _unitOfWork.Commit();
        }
    }
}