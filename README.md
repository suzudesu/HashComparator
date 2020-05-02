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
### 動作保証環境
- Windows10 1703以降
- .Net Framework 4.7.2
# 操作・表示説明
### ファイルを読み込む
ファイルをドラッグアンドドロップするか、ファイルアイコンをクリックして読み込みます。
ファイルは2つまで同時に読み込むことができます。
ファイル以外を読み込むことはできません。
### ハッシュ値のコピー
コピーしたいハッシュ値をクリックすると、クリップボードにコピーされます。
### ファイルのフルパスを表示
表示されているファイル名をクリックすると、`フルパス`と`ファイル名`の表示を切り替えられます。
### ハッシュ値の枠色と意味
|色|意味|
|---|---|
|灰|ファイルが読み込まれていません。|
|青|ファイルを読み込みましたが、比較対象が読み込まれていません。|
|緑|2つのファイルにおいて、同じハッシュアルゴリズムの**ハッシュ値が一致しました**。|
|赤|2つのファイルにおいて、同じハッシュアルゴリズムの**ハッシュ値が一致しませんでした**。|
