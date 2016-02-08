<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ファイルToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.新規ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.開くToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.保存SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.別名で保存AToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.書き出しEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.閉じるToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.終了XToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.編集ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.元へ戻すToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.コピーToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.切り取りToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.貼り付けToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.選択されたテキストの削除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.テキスト選択解除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ヘルプHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.まんがスケッチについてToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ヒントToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.PenMenu = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ElaserMenu = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ComboBox_Font = New System.Windows.Forms.ToolStripComboBox()
        Me.ComboBox_size = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.HorizButton = New System.Windows.Forms.ToolStripButton()
        Me.VertButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ZoomOutButton = New System.Windows.Forms.ToolStripButton()
        Me.ZoomInButton = New System.Windows.Forms.ToolStripButton()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Timer_Export = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ExportWorker = New System.ComponentModel.BackgroundWorker()
        Me.SaveWorker = New System.ComponentModel.BackgroundWorker()
        Me.ContextTextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.削除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.サイズToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextTextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルToolStripMenuItem, Me.編集ToolStripMenuItem, Me.ヘルプHToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(767, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ファイルToolStripMenuItem
        '
        Me.ファイルToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.新規ToolStripMenuItem, Me.開くToolStripMenuItem, Me.ToolStripMenuItem2, Me.保存SToolStripMenuItem, Me.別名で保存AToolStripMenuItem, Me.書き出しEToolStripMenuItem, Me.ToolStripMenuItem3, Me.閉じるToolStripMenuItem, Me.終了XToolStripMenuItem})
        Me.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem"
        Me.ファイルToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ファイルToolStripMenuItem.Text = "ファイル(&F)"
        '
        '新規ToolStripMenuItem
        '
        Me.新規ToolStripMenuItem.Name = "新規ToolStripMenuItem"
        Me.新規ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.新規ToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.新規ToolStripMenuItem.Text = "新規(&N)..."
        '
        '開くToolStripMenuItem
        '
        Me.開くToolStripMenuItem.Name = "開くToolStripMenuItem"
        Me.開くToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.開くToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.開くToolStripMenuItem.Text = "開く(&O)..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(225, 6)
        '
        '保存SToolStripMenuItem
        '
        Me.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem"
        Me.保存SToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.保存SToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.保存SToolStripMenuItem.Text = "保存(&S)"
        '
        '別名で保存AToolStripMenuItem
        '
        Me.別名で保存AToolStripMenuItem.Name = "別名で保存AToolStripMenuItem"
        Me.別名で保存AToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.別名で保存AToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.別名で保存AToolStripMenuItem.Text = "別名で保存(&A)..."
        '
        '書き出しEToolStripMenuItem
        '
        Me.書き出しEToolStripMenuItem.Name = "書き出しEToolStripMenuItem"
        Me.書き出しEToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.書き出しEToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.書き出しEToolStripMenuItem.Text = "画像書き出し(&E)..."
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(225, 6)
        '
        '閉じるToolStripMenuItem
        '
        Me.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem"
        Me.閉じるToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.閉じるToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.閉じるToolStripMenuItem.Text = "閉じる(&C)"
        '
        '終了XToolStripMenuItem
        '
        Me.終了XToolStripMenuItem.Name = "終了XToolStripMenuItem"
        Me.終了XToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.終了XToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.終了XToolStripMenuItem.Text = "終了(&X)"
        '
        '編集ToolStripMenuItem
        '
        Me.編集ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.元へ戻すToolStripMenuItem, Me.ToolStripMenuItem1, Me.コピーToolStripMenuItem, Me.切り取りToolStripMenuItem, Me.貼り付けToolStripMenuItem, Me.ToolStripMenuItem4, Me.選択されたテキストの削除ToolStripMenuItem, Me.テキスト選択解除ToolStripMenuItem})
        Me.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem"
        Me.編集ToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.編集ToolStripMenuItem.Text = "編集(&E)"
        '
        '元へ戻すToolStripMenuItem
        '
        Me.元へ戻すToolStripMenuItem.Name = "元へ戻すToolStripMenuItem"
        Me.元へ戻すToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.元へ戻すToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.元へ戻すToolStripMenuItem.Text = "元へ戻す"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(216, 6)
        '
        'コピーToolStripMenuItem
        '
        Me.コピーToolStripMenuItem.Name = "コピーToolStripMenuItem"
        Me.コピーToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.コピーToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.コピーToolStripMenuItem.Text = "コピー"
        '
        '切り取りToolStripMenuItem
        '
        Me.切り取りToolStripMenuItem.Name = "切り取りToolStripMenuItem"
        Me.切り取りToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.切り取りToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.切り取りToolStripMenuItem.Text = "切り取り"
        '
        '貼り付けToolStripMenuItem
        '
        Me.貼り付けToolStripMenuItem.Name = "貼り付けToolStripMenuItem"
        Me.貼り付けToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.貼り付けToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.貼り付けToolStripMenuItem.Text = "貼り付け"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(216, 6)
        '
        '選択されたテキストの削除ToolStripMenuItem
        '
        Me.選択されたテキストの削除ToolStripMenuItem.Name = "選択されたテキストの削除ToolStripMenuItem"
        Me.選択されたテキストの削除ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.選択されたテキストの削除ToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.選択されたテキストの削除ToolStripMenuItem.Text = "選択されたテキストの削除"
        '
        'テキスト選択解除ToolStripMenuItem
        '
        Me.テキスト選択解除ToolStripMenuItem.Name = "テキスト選択解除ToolStripMenuItem"
        Me.テキスト選択解除ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.テキスト選択解除ToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.テキスト選択解除ToolStripMenuItem.Text = "テキスト選択解除"
        '
        'ヘルプHToolStripMenuItem
        '
        Me.ヘルプHToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.まんがスケッチについてToolStripMenuItem, Me.ヒントToolStripMenuItem})
        Me.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem"
        Me.ヘルプHToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)"
        '
        'まんがスケッチについてToolStripMenuItem
        '
        Me.まんがスケッチについてToolStripMenuItem.Name = "まんがスケッチについてToolStripMenuItem"
        Me.まんがスケッチについてToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.まんがスケッチについてToolStripMenuItem.Text = "まんがスケッチについて(&A)..."
        '
        'ヒントToolStripMenuItem
        '
        Me.ヒントToolStripMenuItem.Name = "ヒントToolStripMenuItem"
        Me.ヒントToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.ヒントToolStripMenuItem.Text = "ヒント(&?)..."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.PenMenu, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripLabel5, Me.ElaserMenu, Me.ToolStripLabel6, Me.ToolStripSeparator4, Me.ToolStripLabel4, Me.ComboBox_Font, Me.ComboBox_size, Me.ToolStripLabel3, Me.ToolStripSeparator3, Me.HorizButton, Me.VertButton, Me.ToolStripSeparator1, Me.ZoomOutButton, Me.ZoomInButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(767, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripLabel2.Text = "ペン:"
        '
        'PenMenu
        '
        Me.PenMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PenMenu.Name = "PenMenu"
        Me.PenMenu.Size = New System.Drawing.Size(75, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(27, 22)
        Me.ToolStripLabel1.Text = "mm"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(48, 22)
        Me.ToolStripLabel5.Text = "消しゴム:"
        '
        'ElaserMenu
        '
        Me.ElaserMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ElaserMenu.Name = "ElaserMenu"
        Me.ElaserMenu.Size = New System.Drawing.Size(75, 25)
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(27, 22)
        Me.ToolStripLabel6.Text = "mm"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel4.Text = "フォント:"
        '
        'ComboBox_Font
        '
        Me.ComboBox_Font.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Font.Name = "ComboBox_Font"
        Me.ComboBox_Font.Size = New System.Drawing.Size(200, 25)
        '
        'ComboBox_size
        '
        Me.ComboBox_size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_size.Items.AddRange(New Object() {"9", "11", "12", "14", "18", "20", "24", "30", "36", "48", "60", "128"})
        Me.ComboBox_size.Name = "ComboBox_size"
        Me.ComboBox_size.Size = New System.Drawing.Size(75, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(18, 22)
        Me.ToolStripLabel3.Text = "Pt"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'HorizButton
        '
        Me.HorizButton.CheckOnClick = True
        Me.HorizButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HorizButton.Image = CType(resources.GetObject("HorizButton.Image"), System.Drawing.Image)
        Me.HorizButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HorizButton.Name = "HorizButton"
        Me.HorizButton.Size = New System.Drawing.Size(23, 22)
        Me.HorizButton.Text = "VertButton"
        Me.HorizButton.ToolTipText = "縦書き"
        '
        'VertButton
        '
        Me.VertButton.Checked = True
        Me.VertButton.CheckOnClick = True
        Me.VertButton.CheckState = System.Windows.Forms.CheckState.Checked
        Me.VertButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.VertButton.Image = CType(resources.GetObject("VertButton.Image"), System.Drawing.Image)
        Me.VertButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.VertButton.Name = "VertButton"
        Me.VertButton.Size = New System.Drawing.Size(23, 22)
        Me.VertButton.Text = "HorizButton"
        Me.VertButton.ToolTipText = "横書き"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ZoomOutButton
        '
        Me.ZoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ZoomOutButton.Image = CType(resources.GetObject("ZoomOutButton.Image"), System.Drawing.Image)
        Me.ZoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ZoomOutButton.Name = "ZoomOutButton"
        Me.ZoomOutButton.Size = New System.Drawing.Size(23, 22)
        Me.ZoomOutButton.Text = "ToolStripButton3"
        Me.ZoomOutButton.ToolTipText = "ズームアウト"
        '
        'ZoomInButton
        '
        Me.ZoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ZoomInButton.Image = CType(resources.GetObject("ZoomInButton.Image"), System.Drawing.Image)
        Me.ZoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ZoomInButton.Name = "ZoomInButton"
        Me.ZoomInButton.Size = New System.Drawing.Size(23, 22)
        Me.ZoomInButton.Text = "ToolStripButton4"
        Me.ZoomInButton.ToolTipText = "ズームイン"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AllowDrop = True
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 49)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(767, 457)
        Me.FlowLayoutPanel1.TabIndex = 0
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Title = "保存"
        '
        'Timer_Export
        '
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ExportWorker
        '
        Me.ExportWorker.WorkerReportsProgress = True
        Me.ExportWorker.WorkerSupportsCancellation = True
        '
        'SaveWorker
        '
        Me.SaveWorker.WorkerReportsProgress = True
        Me.SaveWorker.WorkerSupportsCancellation = True
        '
        'ContextTextMenu
        '
        Me.ContextTextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.削除ToolStripMenuItem, Me.サイズToolStripMenuItem, Me.ToolStripMenuItem5})
        Me.ContextTextMenu.Name = "ContextTextMenu"
        Me.ContextTextMenu.Size = New System.Drawing.Size(136, 54)
        '
        '削除ToolStripMenuItem
        '
        Me.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem"
        Me.削除ToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.削除ToolStripMenuItem.Text = "ページ削除..."
        '
        'サイズToolStripMenuItem
        '
        Me.サイズToolStripMenuItem.Name = "サイズToolStripMenuItem"
        Me.サイズToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.サイズToolStripMenuItem.Text = "ページ追加..."
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(132, 6)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 506)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.MangaSketch.My.MySettings.Default, "Location", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = Global.MangaSketch.My.MySettings.Default.Location
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "まんがスケッチ"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextTextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ファイルToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 新規ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 開くToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents 保存SToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 別名で保存AToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 書き出しEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents 終了XToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 編集ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 元へ戻すToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents コピーToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 切り取りToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 貼り付けToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents PenMenu As ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ComboBox_Font As ToolStripComboBox
    Friend WithEvents ComboBox_size As ToolStripComboBox
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents VertButton As ToolStripButton
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Timer_Export As Timer
    Friend WithEvents ZoomOutButton As ToolStripButton
    Friend WithEvents ZoomInButton As ToolStripButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents 閉じるToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents SaveWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents HorizButton As ToolStripButton
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents 選択されたテキストの削除ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents テキスト選択解除ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextTextMenu As ContextMenuStrip
    Friend WithEvents 削除ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents サイズToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
    Friend WithEvents ヘルプHToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents まんがスケッチについてToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ヒントToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents ElaserMenu As ToolStripComboBox
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
End Class
