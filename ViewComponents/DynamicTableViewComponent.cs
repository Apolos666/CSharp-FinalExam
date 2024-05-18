using CSharp_FinalExam.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.ViewComponents;

public class DynamicTableViewComponent : ViewComponent
{
    public Task<IViewComponentResult> InvokeAsync(IEnumerable<object> modelViewComponent, List<string> propertiesViewComponent)
    {
        var viewModel = new DynamicTableViewModel
        {
            Items = modelViewComponent,
            Properties = propertiesViewComponent
        };
        
        return Task.FromResult<IViewComponentResult>(View(viewModel));
    }
}