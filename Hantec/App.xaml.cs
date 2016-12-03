using Xamarin.Forms;

namespace Hantec
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}

		static WordItemDatabase database;

		public static WordItemDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new WordItemDatabase();
				}
				return database;
			}
		}

		static bool isHantecToCestina;

		public static bool IsHantecToCestina
		{
			get { return isHantecToCestina; }
			set { isHantecToCestina = value; }
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

