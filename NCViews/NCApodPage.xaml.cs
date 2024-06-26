using NIcolasCasamenAPI.NCViewModels;

namespace NIcolasCasamenAPI.NCViews;

public partial class NCApodPage : ContentPage
{
	public NCApodPage()
	{
        InitializeComponent();
        BindingContext = new NCApodViewModel();
    }
}