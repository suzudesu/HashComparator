using System.Windows.Media;

namespace HashComparator.Settings
{
	/// <summary>
	/// 色設定管理クラス
	/// </summary>
	public static class ColorSettings
	{
		/// <summary>
		/// ボタンの色
		/// </summary>
		public class Button
		{
			public Brush DefaultBorder { get { return Brushes.Gainsboro; } }    //標準ボタン枠
			public Brush DefaultBackground { get { return Brushes.White; } }	//標準ボタン背景
			public Brush Loaded { get { return Brushes.DeepSkyBlue; } }			//読み込み完了枠
			public Brush Match { get { return Brushes.LimeGreen; } }			//一致枠
			public Brush NotMatch { get { return Brushes.OrangeRed; } }			//不一致枠
		}
	}
}
