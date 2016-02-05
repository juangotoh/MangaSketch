<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewDocumentDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_ltr = New System.Windows.Forms.RadioButton()
        Me.RadioButton_rtl = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_PageNum = New System.Windows.Forms.TextBox()
        Me.RadioButton_startLeft = New System.Windows.Forms.RadioButton()
        Me.RadioButtonStartRight = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(88, 182)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton_ltr)
        Me.GroupBox1.Controls.Add(Me.RadioButton_rtl)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 69)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ページ進行"
        '
        'RadioButton_ltr
        '
        Me.RadioButton_ltr.AutoSize = True
        Me.RadioButton_ltr.Location = New System.Drawing.Point(16, 40)
        Me.RadioButton_ltr.Name = "RadioButton_ltr"
        Me.RadioButton_ltr.Size = New System.Drawing.Size(110, 16)
        Me.RadioButton_ltr.TabIndex = 2
        Me.RadioButton_ltr.TabStop = True
        Me.RadioButton_ltr.Text = "左綴じ（左から右）"
        Me.RadioButton_ltr.UseVisualStyleBackColor = True
        '
        'RadioButton_rtl
        '
        Me.RadioButton_rtl.AutoSize = True
        Me.RadioButton_rtl.Location = New System.Drawing.Point(16, 18)
        Me.RadioButton_rtl.Name = "RadioButton_rtl"
        Me.RadioButton_rtl.Size = New System.Drawing.Size(110, 16)
        Me.RadioButton_rtl.TabIndex = 0
        Me.RadioButton_rtl.TabStop = True
        Me.RadioButton_rtl.Text = "右綴じ（右から左）"
        Me.RadioButton_rtl.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ページ数:"
        '
        'TextBox_PageNum
        '
        Me.TextBox_PageNum.Location = New System.Drawing.Point(67, 6)
        Me.TextBox_PageNum.Name = "TextBox_PageNum"
        Me.TextBox_PageNum.Size = New System.Drawing.Size(71, 19)
        Me.TextBox_PageNum.TabIndex = 3
        Me.TextBox_PageNum.Text = "16"
        '
        'RadioButton_startLeft
        '
        Me.RadioButton_startLeft.AutoSize = True
        Me.RadioButton_startLeft.Location = New System.Drawing.Point(12, 18)
        Me.RadioButton_startLeft.Name = "RadioButton_startLeft"
        Me.RadioButton_startLeft.Size = New System.Drawing.Size(35, 16)
        Me.RadioButton_startLeft.TabIndex = 5
        Me.RadioButton_startLeft.TabStop = True
        Me.RadioButton_startLeft.Text = "左"
        Me.RadioButton_startLeft.UseVisualStyleBackColor = True
        '
        'RadioButtonStartRight
        '
        Me.RadioButtonStartRight.AutoSize = True
        Me.RadioButtonStartRight.Location = New System.Drawing.Point(74, 18)
        Me.RadioButtonStartRight.Name = "RadioButtonStartRight"
        Me.RadioButtonStartRight.Size = New System.Drawing.Size(35, 16)
        Me.RadioButtonStartRight.TabIndex = 6
        Me.RadioButtonStartRight.TabStop = True
        Me.RadioButtonStartRight.Text = "右"
        Me.RadioButtonStartRight.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton_startLeft)
        Me.GroupBox2.Controls.Add(Me.RadioButtonStartRight)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 115)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 48)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "開始ページ"
        '
        'NewDocumentDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(246, 220)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TextBox_PageNum)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewDocumentDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "新規作成"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton_rtl As RadioButton
    Friend WithEvents RadioButton_ltr As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_PageNum As TextBox
    Friend WithEvents RadioButton_startLeft As RadioButton
    Friend WithEvents RadioButtonStartRight As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
End Class
