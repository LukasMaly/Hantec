using Xamarin.Forms;

namespace Hantec
{
	public partial class MainPage : TabbedPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnCurrentPageChanged()
		{
			base.OnCurrentPageChanged();

			App.IsHantecToCestina = !App.IsHantecToCestina;
		}
	}
}

