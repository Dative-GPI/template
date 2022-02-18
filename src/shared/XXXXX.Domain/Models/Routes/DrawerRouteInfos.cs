using System;
using System.Collections.Generic;

namespace XXXXX.Domain.Models
{
	public class DrawerRouteInfos
	{
		public Guid Id { get; set; }
		public Guid ExtensionId { get; set; }
		public string ExtensionLabel { get; set; }
		public string Path { get; set; }
		public string Uri { get; set; }
		public string Name { get; set; }
		public string Icon { get; set; }
		public string Code { get; set; }

		#region Translated properties
		public string Label { get; set; }
		#endregion
		public List<TranslationDrawerRoute> Translations { get; set; }
	}
}
