
namespace ServiceApplikationnew.MVVM.Core;

public class NavigationStore : ObservalbeObject
{
    private ObservalbeObject? _currentViewModel;
    public ObservalbeObject? CurrentViewModel 
    { 
        get => _currentViewModel;
        set => SetValue(ref _currentViewModel, value); 
    }

    public void NavigateTo(ObservalbeObject? viewModel) 
    {
        CurrentViewModel = viewModel;

    }
}
