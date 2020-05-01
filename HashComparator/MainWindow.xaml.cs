using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
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
using System.Security.Cryptography;
using HashComparator.Settings;

namespace HashComparator
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		//ボタンの色
		private readonly ColorSettings.Button buttonColors = new ColorSettings.Button();
		//ボタンリスト
		private IDictionary<string, Button> fileAButtonList = new Dictionary<string, Button>();
		private IDictionary<string, Button> fileBButtonList = new Dictionary<string, Button>();
		//画像ファイルのURI
		static Uri addImage = new Uri("images/add.png", UriKind.Relative);
		static Uri okImage = new Uri("images/ok.png", UriKind.Relative);

		public MainWindow()
		{
			InitializeComponent();

			//ファイルAのハッシュ値ボタンリストにボタンを追加
			fileAButtonList.Add("MD5", FileAMD5Button);
			fileAButtonList.Add("SHA256", FileASHA256Button);
			fileAButtonList.Add("SHA384", FileASHA384Button);
			fileAButtonList.Add("SHA512", FileASHA512Button);

			//ファイルBのハッシュ値ボタンリストにボタンを追加
			fileBButtonList.Add("MD5", FileBMD5Button);
			fileBButtonList.Add("SHA256", FileBSHA256Button);
			fileBButtonList.Add("SHA384", FileBSHA384Button);
			fileBButtonList.Add("SHA512", FileBSHA512Button);

			//プロパティ初期化
			PropertiesInit();

			//テスト
			//GetFileHashValues(fileAButtonList, @"D:\working_from_home\dl_rand\images\lfsr16\初期値比較\test.png");
			//GetFileHashValues(fileBButtonList, @"D:\working_from_home\dl_rand\images\lfsr16\初期値比較\1132.png");
		}

		//表示されるプロパティ関連の初期化
		private void PropertiesInit()
		{
			//ファイルアイコン初期化
			FileAImage.Source = new BitmapImage(okImage);
			FileBImage.Source = new BitmapImage(addImage);

			//枠の表示
			FileADropRect.Visibility = Visibility.Hidden;
			FileBDropRect.Visibility = Visibility.Visible;

			//ファイル名初期化
			FileANameLabel.Content = "test.png";
			FileBNameLabel.Content = "ファイルをドロップ";


			//ハッシュ値ボタンを初期化(ファイルA, B)
			foreach (var tmp in fileAButtonList.Keys)
			{
				fileAButtonList[tmp].Background = buttonColors.DefaultBackground;
				fileBButtonList[tmp].Background = buttonColors.DefaultBackground;
				fileAButtonList[tmp].BorderBrush = buttonColors.DefaultBorder;
				fileBButtonList[tmp].BorderBrush = buttonColors.DefaultBorder;
				fileAButtonList[tmp].Content = "";
				fileBButtonList[tmp].Content = "";
			}
		}

		//ハッシュ値の取得
		private void GetFileHashValues(IDictionary<string, Button> list, string filePath)
		{
			//MD5
			using (var md5 = new MD5CryptoServiceProvider())
			{
				try
				{
					using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
					{
						byte[] hash = md5.ComputeHash(stream);
						list["MD5"].Content = GetHashString(hash);
					}
				}
				catch (Exception e)
				{
					list["MD5"].Content = "エラー";
					MessageBox.Show(e.Message, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

			//SHA256
			using (var sha256 = new SHA256CryptoServiceProvider())
			{
				try
				{
					using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
					{
						byte[] hash = sha256.ComputeHash(stream);
						list["SHA256"].Content = GetHashString(hash);
					}
				}
				catch (Exception e)
				{
					list["SHA256"].Content = "エラー";
					MessageBox.Show(e.Message, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

			//SHA384
			using (var sha384 = new SHA384CryptoServiceProvider())
			{
				try
				{
					using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
					{
						byte[] hash = sha384.ComputeHash(stream);
						list["SHA384"].Content = GetHashString(hash);
					}
				}
				catch (Exception e)
				{
					list["SHA384"].Content = "エラー";
					MessageBox.Show(e.Message, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

			//SHA512
			using (var sha512 = new SHA512CryptoServiceProvider())
			{
				try
				{
					using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
					{
						byte[] hash = sha512.ComputeHash(stream);
						list["SHA512"].Content = GetHashString(hash);
					}
				}
				catch (Exception e)
				{
					list["SHA512"].Content = "エラー";
					MessageBox.Show(e.Message, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

			//ハッシュ値の比較
			CompareHash();
		}

		//ハッシュコード化
		private string GetHashString(byte[] hash)
		{
			var stringBuilder = new StringBuilder();

			foreach (var tmp in hash)
			{
				stringBuilder.Append(tmp.ToString("x2"));
			}

			return stringBuilder.ToString();
		}

		//ハッシュ値の比較
		private void CompareHash()
		{
			foreach(var key in fileAButtonList.Keys)
			{
				var fileA = fileAButtonList[key].Content.ToString();
				var fileB = fileBButtonList[key].Content.ToString();

				//ファイルA側が空白でない
				if(fileA.Length != 0)
				{
					if (fileB.Length == 0)      //ファイルB側が空白
						fileAButtonList[key].BorderBrush = buttonColors.Loaded;
					else if (fileA == fileB)    //一致
						fileAButtonList[key].BorderBrush = fileBButtonList[key].BorderBrush = buttonColors.Match;
					else                        //不一致
						fileAButtonList[key].BorderBrush = fileBButtonList[key].BorderBrush = buttonColors.NotMatch;
				}
				//ファイルA側が空白
				else
				{
					fileBButtonList[key].BorderBrush = buttonColors.Loaded;
				}
			}
		}

		//ハッシュ値ボタンクリックイベント
		private void HashValueButtonClicked(object sender, RoutedEventArgs e)
		{
			var name = (Button)sender;
			Console.WriteLine($"{name.Name} Clicked!");
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			//e.Source.GetType().Name
		}
	}
}
