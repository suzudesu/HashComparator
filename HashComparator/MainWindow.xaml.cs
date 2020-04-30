using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HashComparator
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			PropertiesInit();			//プロパティ初期化
		}

		//表示されるプロパティ関連の初期化
		private void PropertiesInit()
		{
			//ファイルアイコン初期化
			FileAImage.Source = new BitmapImage(new Uri("images/drop.png", UriKind.Relative));
			FileBImage.Source = new BitmapImage(new Uri("images/drop.png", UriKind.Relative));
			//ファイル名初期化
			FileANameLabel.Content = "ファイルをドロップ";
			FileBNameLabel.Content = "ファイルをドロップ";
		}
	}
}
