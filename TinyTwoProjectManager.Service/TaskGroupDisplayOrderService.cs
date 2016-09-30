using System.Collections.Generic;
using System.Linq;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public interface ITaskGroupDisplayOrderService
    {
        void AddTaskToBottomOfTaskGroups(IEnumerable<int> taskGroupIds, int taskId);

        void DeleteTaskGroupDisplayOrder(TaskGroupDisplayOrder taskGroupDisplayOrder);

        TaskGroupDisplayOrder GetTaskGroupDisplayOrder(int id);

        IQueryable<TaskGroupDisplayOrder> GetDisplayOrderForTaskGroup(int taskGroupId);

        void SaveTaskGroupDisplayOrder();

        void UpdateTaskGroupDisplayOrder(TaskGroupDisplayOrder taskGroupDisplayOrder);
    }

    public class TaskGroupDisplayOrderService : ITaskGroupDisplayOrderService
    {
        private readonly ITaskGroupDisplayOrderRepository _taskGroupDisplayOrderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TaskGroupDisplayOrderService(ITaskGroupDisplayOrderRepository taskGroupDisplayOrderRepository, IUnitOfWork unitOfWork)
        {
            _taskGroupDisplayOrderRepository = taskGroupDisplayOrderRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddTaskToBottomOfTaskGroups(IEnumerable<int> taskGroupIds, int taskId)
        {
            foreach (var taskGroupId in taskGroupIds)
            {
                var maxDisplayOrder = GetDisplayOrderForTaskGroup(taskGroupId).Max(tgdo => tgdo.DisplayOrder);

                _taskGroupDisplayOrderRepository.Add(new TaskGroupDisplayOrder
                {
                    TaskId = taskId,
                    TaskGroupId = taskGroupId,
                    DisplayOrder = maxDisplayOrder + 1
                });

                SaveTaskGroupDisplayOrder();
            }
        }

        public void DeleteTaskGroupDisplayOrder(TaskGroupDisplayOrder taskGroupDisplayOrder)
        {
            _taskGroupDisplayOrderRepository.Delete(taskGroupDisplayOrder);
        }

        public TaskGroupDisplayOrder GetTaskGroupDisplayOrder(int id)
        {
            return _taskGroupDisplayOrderRepository.GetById(id);
        }

        public IQueryable<TaskGroupDisplayOrder> GetDisplayOrderForTaskGroup(int taskGroupId)
        {
            return _taskGroupDisplayOrderRepository.GetMany(tgdo => tgdo.TaskGroupId == taskGroupId);
        }

        public void SaveTaskGroupDisplayOrder()
        {
            _unitOfWork.Commit();
        }

        public void UpdateTaskGroupDisplayOrder(TaskGroupDisplayOrder taskGroupDisplayOrder)
        {
            _taskGroupDisplayOrderRepository.Update(taskGroupDisplayOrder);
        }
    }
}