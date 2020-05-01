using System.Windows.Media;

namespace HashComparator.Settings
{
	public static class ColorSettings
	{
		public class Button
		{
			public Brush DefaultBorder { get { return Brushes.Gainsboro; } }
			public Brush DefaultBackground { get { return Brushes.White; } }
			public Brush Loaded { get { return Brushes.DeepSkyBlue; } }
			public Brush Match { get { return Brushes.LimeGreen; } }
			public Brush NotMatch { get { return Brushes.OrangeRed; } }
		}
	}
}
