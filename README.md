# HashComparator
### 特徴
- 2つのファイルにおけるハッシュ値を比較
- 直感的 - ドラッグアンドドロップでファイル指定できる操作
- 視覚的 - ひと目で一致しているか確認できる
- 実用的 - ワンクリックでハッシュ値をコピー
### ハッシュアルゴリズム
- MD5
- SHA256
- SHA384
- SHA512
### 動作環境
- Windows10 1703以降
- .Net Framework 4.7.2
# キャプチャ
[![http://img.youtube.com/vi/X3eGcqHz2HQ/0.jpg](https://img.youtube.com/vi/X3eGcqHz2HQ/0.jpg)](https://www.youtube.com/watch?v=X3eGcqHz2HQ)
# 操作・表示説明
### ファイルを読み込む
ファイルをドラッグアンドドロップするか、ファイルアイコンをクリックして読み込みます。
ファイルは2つまで同時に読み込むことができます。
ファイル以外を読み込むことはできません。
### ハッシュ値の表示
読み込みに成功すると、各アルゴリズム別にハッシュ値が表示されます。
ハッシュ値が見切れている場合は、ウインドウサイズを変更してみてください。
### ハッシュ値のコピー
コピーしたいハッシュ値をクリックすると、クリップボードにコピーされます。
クリックしたハッシュ値が見切れていても、問題なく正常にコピーされます。
### ファイルのフルパスを表示
表示されているファイル名をクリックすると、`フルパス`と`ファイル名`の表示を切り替えられます。
### ハッシュ値の枠色と意味
|色|意味|
|---|---|
|灰|ファイルが読み込まれていません。|
|青|ファイルを読み込みましたが、比較対象が読み込まれていません。|
|緑|2つのファイルにおいて、同じハッシュアルゴリズムの**ハッシュ値が一致しました**。|
|赤|2つのファイルにおいて、同じハッシュアルゴリズムの**ハッシュ値が一致しませんでした**。|
# リリースノート
### 1.0.0.5
- ダイアログ経由でファイルを読み込むとハッシュ値が行われないバグを修正
- ポップアップ表示中にメインウインドウを操作できてしまうバグを修正
### 1.0.0.4
- 2つのファイルを同時に読み込むとハッシュ値比較が行われないバグを修正
### 1.0.0.3
- 軽微なロジックの修正
### 1.0.0.2
- 右側にファイルを2つドロップすると1つめのファイルのみが左右に配置されるバグを修正
### 1.0.0.1
- 特定条件でアプリケーションが強制終了するバグを修正
### 1.0.0.0
- 初回リリース