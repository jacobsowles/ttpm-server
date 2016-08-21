namespace TinyTwoProjectManager.Web.ViewModels
{
    public class TaskListTaskTableModuleViewModel : ContentModuleViewModel
    {
        public TaskListViewModel TaskList { get; set; }
        public TaskViewModel NewTask { get; set; }

        public TaskListTaskTableModuleViewModel()
        {
            Width = 12;
        }
    }
}