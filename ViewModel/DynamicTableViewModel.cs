namespace CSharp_FinalExam.ViewModel;

public class DynamicTableViewModel
{
    public IEnumerable<object> Items { get; set; }
    public List<string> Properties { get; set; }
    public string UpdateAction { get; set; }
    public string DeleteAction { get; set; }
    public string Controller { get; set; }
}