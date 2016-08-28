using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TinyTwoProjectManager.Web.ViewModels
{
    public class TaskViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int TaskId { get; set; }
        
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Complete { get; set; }

        public string RowClass
        {
            get { return Complete ? "task-complete" : ""; }
        }
    }
}