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
            Title = "Completion";
            Width = 4;
            CompletedTaskCount = taskList.Tasks.Count(t => t.Complete);
            TotalTaskCount = taskList.Tasks.Count();
            CompletionPercentage = TotalTaskCount == 0 ? 0 : (CompletedTaskCount / TotalTaskCount) * 100;
        }
    }
}