
using CommunityToolkit.Mvvm.ComponentModel;

namespace ServiceApplikationnew.MVVM.Core;

public partial class NavigationStore : ObservableObject
{
    [ObservableProperty]
    private ObservableObject? currentViewModel;


    public void NavigateTo(ObservableObject? viewModel) 
    {
        CurrentViewModel = viewModel;

    }
}
