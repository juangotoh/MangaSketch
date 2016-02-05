<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportOption
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TextBox_Quality = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonGray = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Color = New System.Windows.Forms.RadioButton()
        Me.ComboBox_dpi = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_name = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_Path = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox_PaperSelect = New System.Windows.Forms.ComboBox()
        Me.TextExportCheck = New System.Windows.Forms.CheckBox()
        Me.UseGaijiCheck = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(215, 212)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 27)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 21)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 21)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "キャンセル"
        '
        'TextBox_Quality
        '
        Me.TextBox_Quality.Location = New System.Drawing.Point(176, 27)
        Me.TextBox_Quality.Name = "TextBox_Quality"
        Me.TextBox_Quality.Size = New System.Drawing.Size(59, 19)
        Me.TextBox_Quality.TabIndex = 1
        Me.TextBox_Quality.Text = "100"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(139, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "品質:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButtonGray)
        Me.GroupBox1.Controls.Add(Me.RadioButton_Color)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(111, 61)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "形式"
        '
        'RadioButtonGray
        '
        Me.RadioButtonGray.AutoSize = True
        Me.RadioButtonGray.Location = New System.Drawing.Point(6, 39)
        Me.RadioButtonGray.Name = "RadioButtonGray"
        Me.RadioButtonGray.Size = New System.Drawing.Size(89, 16)
        Me.RadioButtonGray.TabIndex = 4
        Me.RadioButtonGray.TabStop = True
        Me.RadioButtonGray.Text = "グレースケール"
        Me.RadioButtonGray.UseVisualStyleBackColor = True
        '
        'RadioButton_Color
        '
        Me.RadioButton_Color.AutoSize = True
        Me.RadioButton_Color.Checked = True
        Me.RadioButton_Color.Location = New System.Drawing.Point(6, 18)
        Me.RadioButton_Color.Name = "RadioButton_Color"
        Me.RadioButton_Color.Size = New System.Drawing.Size(50, 16)
        Me.RadioButton_Color.TabIndex = 0
        Me.RadioButton_Color.TabStop = True
        Me.RadioButton_Color.Text = "カラー"
        Me.RadioButton_Color.UseVisualStyleBackColor = True
        '
        'ComboBox_dpi
        '
        Me.ComboBox_dpi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_dpi.FormattingEnabled = True
        Me.ComboBox_dpi.Items.AddRange(New Object() {"150", "200", "300", "600", "1200"})
        Me.ComboBox_dpi.Location = New System.Drawing.Point(188, 50)
        Me.ComboBox_dpi.Name = "ComboBox_dpi"
        Me.ComboBox_dpi.Size = New System.Drawing.Size(68, 20)
        Me.ComboBox_dpi.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(139, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "解像度:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(262, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "dpi"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "ファイル名:"
        '
        'TextBox_name
        '
        Me.TextBox_name.Location = New System.Drawing.Point(70, 147)
        Me.TextBox_name.Name = "TextBox_name"
        Me.TextBox_name.Size = New System.Drawing.Size(186, 19)
        Me.TextBox_name.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "保存場所:"
        '
        'TextBox_Path
        '
        Me.TextBox_Path.Location = New System.Drawing.Point(70, 175)
        Me.TextBox_Path.Name = "TextBox_Path"
        Me.TextBox_Path.Size = New System.Drawing.Size(205, 19)
        Me.TextBox_Path.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(283, 173)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(54, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "探す..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 12)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "用紙サイズ:"
        '
        'ComboBox_PaperSelect
        '
        Me.ComboBox_PaperSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_PaperSelect.FormattingEnabled = True
        Me.ComboBox_PaperSelect.Items.AddRange(New Object() {"余白なしB5原寸(B5用紙)", "余白付きB5原寸(A4用紙)", "余白なし投稿サイズ(A4用紙)", "余白付き投稿サイズ(B4用紙)"})
        Me.ComboBox_PaperSelect.Location = New System.Drawing.Point(77, 115)
        Me.ComboBox_PaperSelect.Name = "ComboBox_PaperSelect"
        Me.ComboBox_PaperSelect.Size = New System.Drawing.Size(172, 20)
        Me.ComboBox_PaperSelect.TabIndex = 13
        '
        'TextExportCheck
        '
        Me.TextExportCheck.AutoSize = True
        Me.TextExportCheck.Location = New System.Drawing.Point(18, 79)
        Me.TextExportCheck.Name = "TextExportCheck"
        Me.TextExportCheck.Size = New System.Drawing.Size(102, 16)
        Me.TextExportCheck.TabIndex = 14
        Me.TextExportCheck.Text = "テキスト書き出し"
        Me.ToolTip1.SetToolTip(Me.TextExportCheck, "JPEGファイルと同じ場所にページごとのテキストファイルを保存します")
        Me.TextExportCheck.UseVisualStyleBackColor = True
        '
        'UseGaijiCheck
        '
        Me.UseGaijiCheck.AutoSize = True
        Me.UseGaijiCheck.Location = New System.Drawing.Point(126, 79)
        Me.UseGaijiCheck.Name = "UseGaijiCheck"
        Me.UseGaijiCheck.Size = New System.Drawing.Size(102, 16)
        Me.UseGaijiCheck.TabIndex = 15
        Me.UseGaijiCheck.Text = "コミック外字使用"
        Me.ToolTip1.SetToolTip(Me.UseGaijiCheck, "CLIP STUDIO PAINT同梱のイワタアンチックフォントなどで使える外字をテキストに含めます。メモ帳などで文字化けします")
        Me.UseGaijiCheck.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(262, 150)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 12)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "_001.jpg"
        '
        'ExportOption
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(373, 250)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.UseGaijiCheck)
        Me.Controls.Add(Me.TextExportCheck)
        Me.Controls.Add(Me.ComboBox_PaperSelect)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox_Path)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox_name)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox_dpi)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox_Quality)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ExportOption"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "JPEG書き出しオプション"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TextBox_Quality As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButtonGray As RadioButton
    Friend WithEvents RadioButton_Color As RadioButton
    Friend WithEvents ComboBox_dpi As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox_name As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox_Path As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox_PaperSelect As ComboBox
    Friend WithEvents TextExportCheck As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents UseGaijiCheck As CheckBox
    Friend WithEvents Label7 As Label
End Class
