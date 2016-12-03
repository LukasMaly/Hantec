using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hantec
{
	class MyDataTemplateSelector : Xamarin.Forms.DataTemplateSelector
	{
		public MyDataTemplateSelector()
		{
			// Retain instances!
			this.HantecToCestinaDataTemplate = new DataTemplate(typeof(HantecToCestinaViewCell));
			this.CestinaToHantecDataTemplate = new DataTemplate(typeof(CestinaToHantecViewCell));
		}

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			return App.IsHantecToCestina ? this.HantecToCestinaDataTemplate : this.CestinaToHantecDataTemplate;
		}

		private readonly DataTemplate HantecToCestinaDataTemplate;
		private readonly DataTemplate CestinaToHantecDataTemplate;
	}
}
