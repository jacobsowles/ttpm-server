using System.Linq;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public interface ITaskGroupDisplayOrderService
    {
        void CreateTaskGroupDisplayOrder(TaskGroupDisplayOrder taskGroupDisplayOrder);

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

        public void CreateTaskGroupDisplayOrder(TaskGroupDisplayOrder taskGroupDisplayOrder)
        {
            _taskGroupDisplayOrderRepository.Add(taskGroupDisplayOrder);
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