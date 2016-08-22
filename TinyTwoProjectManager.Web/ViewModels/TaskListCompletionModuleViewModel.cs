using System.Linq;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Web.ViewModels
{
    public class TaskListCompletionModuleViewModel : ContentModuleViewModel
    {
        public int CompletedTaskCount { get; set; }
        public int TotalTaskCount { get; set; }
        public double CompletionPercentage { get; set; }

        public TaskListCompletionModuleViewModel(TaskList taskList)
        {
            Title = "Task Completion";
            Width = 3;
            CompletedTaskCount = taskList.Tasks.Count(t => t.Complete);
            TotalTaskCount = taskList.Tasks.Count();
            CompletionPercentage = TotalTaskCount == 0 ? 0 : ((double)CompletedTaskCount / (double)TotalTaskCount);
        }
    }
}