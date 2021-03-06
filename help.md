# まんがスケッチ　マニュアル

![AppIcon.png](.\img\AppIcon.png)


まんがスケッチは、漫画のネームを手軽に描くことだけを考えたお絵かきソフトです。
## スクリーンショット
![manskeTop.jpg](.\img\manskeTop.jpg)

#動作条件
Windows Vista以降。.NETフレームワーク4.5.2以上の環境が必要です。

# 使い方
## 新規作成
ファイルメニューの「新規...」で新規ネームを作成します。
ページ数とページ進行方向、見開きのどちら側から始まるかを設定します。
![newDocument.jpg](.\img\newDocument.jpg)
見開き単位で上から下に繋がったネーム用紙が作成されます。どのページにでも即座に書き込めます。

![newpages.jpg](.\img\newpages.jpg)

## 絵を描く
見開き単位でネーム用紙が表示されるので、ペンでどんどん描きます。ペンは筆圧に応じて濃さが変わるので、鉛筆のような感触で作業ができます。
画面のスクロールはスクロールバーの他に、Space+ドラッグでも可能です。
ズームイン、ズームアウトは画面上部のズームボタンの他に、Ctrl+"+"、Ctrl+"-"でも可能です。
## ペンと消しゴム
タブレットペンの先端を使うとペン。お尻を使うと消しゴムになります。消しゴムも筆圧に対応しています

![pen.jpg](.\img\pen.jpg)

## 文字入力
文字の打ち込みは、ページ上の任意の点でCtrl+クリックです。その場にテキスト編集ウィンドウが開きます。OKボタンをクリックするか、Shift+Enterで確定します。
![text01.jpg](.\img\text01.jpg)

クリックした位置が、文字の右肩（縦書きの場合）。または文字の左肩（横書きの場合）になります。
![text03.jpg](.\img\text03.jpg)
## 文字の編集
すでに存在するテキストを再編集する場合は、そのテキスト上で Ctrl+ダブルクリックです。
また、テキストの移動はCtrl+ドラッグで可能です。
フォントやサイズ、縦横の切り替えといった操作は現在選択されているテキストに適用されます。
選択されているテキストは青い線で囲まれています。任意のテキストを選択するには、選択したいテキストの上でCtrl+クリックします。
選択を解除するにはEscです。

## ルビ
ルビを付ける場合、つけたい部分をエディタ上で選択して「ルビ」ボタンをクリックします。
![rubi01.jpg](.\img\rubi01.jpg)
すると編集中のテキストに青空文庫方式のルビが挿入されます。
![rubi02.jpg](.\img\rubi02.jpg)
ルビはルビ範囲の中心付近にセンタリングして表示されます。均等割付などはできません。
![rubi03.jpg](.\img\rubi03.jpg)

##縦中横
縦書きの場合、半角英数記号は日本語一文字の幅に圧縮して強制的に縦中横で表示します。
![text05.jpg](.\img\text05.jpg)

##漫画用外字の自動適用
「コミックフォントで外字を使用」にチェックが付いている場合、特定のフォントで「!」「!!」「!!!」「!?」「??」「～」が漫画用外字に置き換えて表示されます。
![text06.jpg](.\img\text06.jpg)

「外字の「!」を傾ける」にチェックが入っている場合、エクスクラメーションマークの3つまでの連続を、傾いたものに置き換えます。
![text07.jpg](.\img\text07.jpg)
「外字の「!」を傾ける」にチェックが入っていない場合、エクスクラメーションマークの3つまでの連続を、成立したものに置き換えます。ただし、正立バージョンは外字に含まれないものがありますので、その場合通常の全角「！」や、半角「!」に置き換えます。
![text08.jpg](.\img\text08.jpg)
少年ジャンプなど、エクスクラメーションマークが傾いた写植を伝統的に使っている雑誌が多いですが、かならずしも傾いてるわけではないので、このへんはお好みで使用してください。まあ、所詮ネームなので拘る必要もあまり感じられません。

外字が適用されるフォントは、イワタアンチック体、もしくはリョービコミックフォントシリーズのみです。
イワタアンチック体
* I-OTFアンチックStd B (CLIP STUDIO PAINT同梱フォント)
* IWApアンチックB
* IWAアンチックB

リョービコミックフォント
* Rgリョービアンチック-B
* Rgリョービフキダシック-B
* Rgリョービミダシック-E
* Rgリョービレタリック-B
* TBアンチック-B
* TBフキダシック-B
* TBミダシック-E
* TBレタリック-B
(TBアンチック-B以下は、旧リョービコミックフォントシリーズのタイプバンク移籍版です。未所有のため検証はしていません。)

## テキストの背景を隠す
「テキストの背景を隠す」にチェックが入っていると、テキストの背景を、うっすらと下の絵が見えて、かつ文字が読みにくくならない程度に白で塗りつぶします。
![text04.jpg](.\img\text04.jpg)

# 保存
ファイルメニューの「保存」からネーム書類を保存します。拡張子は.nameです。

#JPEG画像書き出し
ファイルメニューの「画像書き出し...」からJPEG形式での画像書き出しが行えます。全ページ一度に書き出しますので、保存場所をちゃんと選んでください。また、同じ名前のファイルがそこにあっても現在の仕様では確認無しで上書きするので気をつけてください。
![export01.jpg](.\img\export01.jpg)
「☑テキスト書き出し」にチェックが入っていると、ネームの中のテキストをページ毎にまとめ、画像と同じファイル名で拡張子が.txtなテキストファイルとして同時に出力します。
「☑コミック外字使用」にチェックが入っていると、テキスト出力時に、画面上と同じ外字を使用します。外字を使った部分はメモ帳などで開くと文字化けしますが、ネーム記述時と同じフォント設定でCLIP STUDIO PAINTなどにコピー＆ペーストすれば元に戻ります。チェックを外せば外字に置き換えない「!」「!!」「!!!」「!?」「??」「～」が出力されます。このチェックボックスは、編集メニューの「コミックフォントで外字を使用」にチェックが入っていない場合無効になります。
「☑ルビを書き出す」にチェックが入っていると、テキスト書き出し時、ルビも書き出します。現在のところ、こうして出力したルビをCLIP STUDIO PAINTで自動的に使用するのは無理なので、通常はチェックを外してルビを出力しないほうがいいでしょう。出力する場合、青空文庫形式または、括弧書きでルビを表現したテキストが書き出されます。

解像度は150dpi～1200dpiまで選べますが、高解像度に設定するとそれなりに時間がかかります。
CLIP STUDIO PAINTで600dpi、同人サイズの漫画を描くとして、そのネームとしてページ毎に読み込ませたいという場合は、解像度600dpi、用紙サイズ：余白付きB5原寸（A4用紙）または余白なしB5原寸（B5用紙）に設定すれば大きさの調整も必要なく読み込めます。
投稿サイズの原稿のネームとして読み込むなら、余白なし投稿サイズ（A4用紙）または余白付き投稿サイズ（B4用紙）で書き出してください。どの場合でも書き出し時に解像度を完成原稿の解像度に合わせる必要があります。