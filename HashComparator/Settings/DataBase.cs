using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HashComparator.Settings
{
	public class FileDatas
	{
		//色設定
		private ColorSettings.Button buttonColors = new ColorSettings.Button();

		//状態関連
		public enum FileLoadStatus { NoSelect, Selected, Error }				//ファイル状態列挙
		public FileLoadStatus Status { get; set; }								//ファイル状態

		//ファイルアイコンボタン関連
		public Button FileIconButton { get; set; }								//ボタンの実体
		public Image FileImage { get; set; }									//ボタンのアイコン画像
		public bool ViewFileNameFlag { get; set; }								//ファイル名の表示方法(フルパス:true, 名前のみ:false)
		public TextBlock FileNameTextBlock { get; set; }						//ファイル名テキストブロック

		//パス関連
		public string FilePath { get; set; }                                    //フルパス
		public bool IsFile { get { return File.Exists(FilePath); } }			//ファイルかどうか, または存在するか
		private string FileName { get { return Path.GetFileName(FilePath); } }	//ファイル名

		//ハッシュ値表示用
		public IDictionary<string, Button> HashButtons = new Dictionary<string, Button>();

		//コンストラクタ
		public FileDatas()
		{
			FilePath = "";
			ViewFileNameFlag = false;
		}

		//状態設定
		public void SetStatus(FileLoadStatus status)
		{
			Status = status;

			switch(status)
			{
				case FileLoadStatus.Selected:	//選択済み
					FileImage.Source = new BitmapImage(new Uri("../images/ok.png", UriKind.Relative));

					break;
				case FileLoadStatus.NoSelect:	//未選択
					FileImage.Source = new BitmapImage(new Uri("../images/add.png", UriKind.Relative));

					break;
				case FileLoadStatus.Error:		//エラー
					break;
			}
		}

		//ファイル名の設定
		public void SetFileNameLabel()
		{
			if (FilePath == null || FilePath.Length == 0)							//ファイル未選択時
				FileNameTextBlock.Text = "ファイルをドロップ";
			else																	//ファイル選択済時
				FileNameTextBlock.Text = ViewFileNameFlag ? FilePath : FileName;	//表示方法切替に従い表示
		}

		//ハッシュリストを初期化
		public void InitHashList()
		{
			foreach (var item in HashButtons.Values)
			{
				item.Content = "";
				item.Background = buttonColors.DefaultBackground;
				item.BorderBrush = buttonColors.DefaultBorder;
			}
		}

		//ハッシュ値の取得
		public string GetHashValue(string key)
		{
			return HashButtons[key].Content.ToString();
		}

		//ファイル名の取得
		public string GetFileName()
		{
			if (FileName != null && FileName.Length != 0 && IsFile)				//設定されているパスがファイルなら名前を返す
				return FileName;
			else
				return null;
		}
	}
}
