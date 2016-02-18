# まんがスケッチ（略してまんスケ)
漫画のネーム作業を軽快に行うためのツール。

## 説明
余計な機能が一切ない、ネーム作成を軽快に行うためのWindowsアプリケーションです。

## 動作環境
Windows Vista以降(.NET 4.5以上が必要)
WACOMタブレット(タブレットがないと全く使えません)

#ヒント
線を消すにはスタイラスペンのお尻のイレイサーボタンでこする。  
ページ上でContril+クリックすれは新しい台詞が作成されます。  
テキストの移動はControl+ドラッグ  
テキストの再編集はControl+ダブルクリック  
テキストの削除はDelまたはBS  
テキストの選択解除はControl+DまたはEsc  
テキスト編集中、確定するにはShit+Enter  

#ビルド時の注意点
2つのDLL、 WinTabDotnet.dll と、 BitMiracle.LibJpeg.NET.dll を参照していますが、64bit版と32bit版(Any CPU)でそれぞれDLLも使い分ける必要があります。ビルドターゲットを変更する場合、手動で参照の設定を変更してください。

必要なDLLの入手先。
* WintabDotnet.dll → https://osdn.jp/projects/wintabdotnet/
* BitMiracle.LibJpeg.NET.dll → http://bitmiracle.com/libjpeg/

64bit版DLLは、これらのソースから64bitターゲットでコンパイルしなおしたものを使用しました。
