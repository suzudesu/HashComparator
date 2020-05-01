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
		//ファイル状態
		private FileDatas fileA = new FileDatas();
		private FileDatas fileB = new FileDatas();
		//アイコン
		public Uri addImage = new Uri("images/add.png", UriKind.Relative);   //未選択時のアイコン
		public Uri okImage = new Uri("images/ok.png", UriKind.Relative);     //選択済時のアイコン

		public MainWindow()
		{
			InitializeComponent();

			//ファイルアイコンボタンの設定
			fileA.FileIconButton = FileAImageButton;
			fileB.FileIconButton = FileBImageButton;
			
			//ファイルアイコン初期化
			FileAImage.Source = new BitmapImage(okImage);
			FileBImage.Source = new BitmapImage(addImage);

			//枠の表示
			FileADropRect.Visibility = Visibility.Visible;
			FileBDropRect.Visibility = Visibility.Visible;

			//ファイル名初期化
			FileANameLabel.Content = "ファイルをドロップ または クリックして参照";
			FileBNameLabel.Content = "ファイルをドロップ";

			//ファイルAのハッシュ値ボタンリストにボタンを追加
			fileA.HashButtons.Add("MD5", FileAMD5Button);
			fileA.HashButtons.Add("SHA256", FileASHA256Button);
			fileA.HashButtons.Add("SHA384", FileASHA384Button);
			fileA.HashButtons.Add("SHA512", FileASHA512Button);

			//ファイルBのハッシュ値ボタンリストにボタンを追加
			fileB.HashButtons.Add("MD5", FileBMD5Button);
			fileB.HashButtons.Add("SHA256", FileBSHA256Button);
			fileB.HashButtons.Add("SHA384", FileBSHA384Button);
			fileB.HashButtons.Add("SHA512", FileBSHA512Button);

			//ハッシュ値ボタンを初期化(ファイルA, B)
			fileA.InitHashList();
			fileB.InitHashList();

			//テスト
			fileA.FilePath = @"D:\working_from_home\dl_rand\images\lfsr16\初期値比較\test.png";
			fileB.FilePath = @"D:\working_from_home\dl_rand\images\lfsr16\初期値比較\1132.png";

			GetFileHashValues(fileA, fileA.FilePath);
			fileA.Status = FileDatas.FileLoadStatus.Selected;
			//GetFileHashValues(fileBButtonList, fileBPath);
		}

		//ハッシュ値の取得(ループ化する余地あり)
		private void GetFileHashValues(FileDatas data, string filePath)
		{
			//MD5
			using (var md5 = new MD5CryptoServiceProvider())
			{
				try
				{
					using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
					{
						byte[] hash = md5.ComputeHash(stream);
						data.HashButtons["MD5"].Content = GetHashString(hash);
					}
				}
				catch (Exception e)
				{
					data.HashButtons["MD5"].Content = "エラー";
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
						data.HashButtons["SHA256"].Content = GetHashString(hash);
					}
				}
				catch (Exception e)
				{
					data.HashButtons["SHA256"].Content = "エラー";
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
						data.HashButtons["SHA384"].Content = GetHashString(hash);
					}
				}
				catch (Exception e)
				{
					data.HashButtons["SHA384"].Content = "エラー";
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
						data.HashButtons["SHA512"].Content = GetHashString(hash);
					}
				}
				catch (Exception e)
				{
					data.HashButtons["SHA512"].Content = "エラー";
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
				stringBuilder.Append(tmp.ToString("x2"));

			return stringBuilder.ToString();
		}

		//ハッシュ値の比較
		private void CompareHash()
		{
			foreach(var key in fileA.HashButtons.Keys)
			{
				var hashA = fileA.GetHashValue(key);
				var hashB = fileB.GetHashValue(key);


				if (hashA.Length != 0)	//ファイルA側が空白でない
				{
					if (hashB.Length == 0)      //ファイルB側が空白
						fileA.HashButtons[key].BorderBrush = buttonColors.Loaded;
					else if (fileA == fileB)    //一致
						fileA.HashButtons[key].BorderBrush = fileB.HashButtons[key].BorderBrush = buttonColors.Match;
					else                        //不一致
						fileA.HashButtons[key].BorderBrush = fileB.HashButtons[key].BorderBrush = buttonColors.NotMatch;
				}
				else                    //ファイルA側が空白
					fileB.HashButtons[key].BorderBrush = buttonColors.Loaded;
			}
		}

		//ハッシュ値ボタンクリックイベント
		private void HashValueButtonClicked(object sender, RoutedEventArgs e)
		{
			var name = (Button)sender;
			Console.WriteLine($"{name.Name} Clicked!");
		}

		//ファイルアイコンクリックイベント
		private void FileIconImageClicked(object sender, RoutedEventArgs e)
		{
			var select = (Button)sender == fileA.FileIconButton ? fileA : fileB;	//クリックされたボタンがどちらか判定

			if (select.Status != FileDatas.FileLoadStatus.Selected)					//ファイルが選択されていなければ何もしない
				return;

			//ファイルパスを表示
			MessageBox.Show(select.FilePath, $"{select.GetFileName()} のパス",
				MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			//e.Source.GetType().Name
		}
	}
}