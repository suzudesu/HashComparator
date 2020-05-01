using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HashComparator.Settings
{
	public static class ColorSettings
	{
		public class Button
		{
			public Brush DefaultBorder { get { return Brushes.LightGray; } }
			public Brush DefaultBackground { get { return Brushes.White; } }
			public Brush MatchBackground { get { return Brushes.LightSeaGreen; } }
			public Brush NotMatchBackground { get { return Brushes.Salmon; } }
		}
	}
}
