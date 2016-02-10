Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.IO.Compression
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports WinTabDotnet
Imports System.Threading
Imports System.ComponentModel

Public Class Form1
    Public vertical As Boolean
    Public penOK As Boolean
    Public thePage As Page
    Public pagenum As Integer = 0
    Dim mihiraki As Integer = 0
    Dim startLeft As Boolean = True
    Dim rtl As Boolean = True
    Dim toppest, leftest, bottomest, rightest As Integer
    Dim curX As Integer
    Dim curY As Integer
    Dim oldX As Integer
    Dim oldY As Integer
    Dim drawing As Boolean
    Dim tool As Integer
    Public PressureMax As Integer = 0
    Dim pFactor As Double
    Const Pencil As Integer = 0
    Const Eraser As Integer = 1
    Private m_wtMessenger As WinTabMessenger
    Private m_wtContext As WinTabContext
    Const BMP_WIDTH As Integer = 2150
    Const BMP_HEIGHT As Integer = 1517
    Dim times() As Double = {8, 4, 3, 2, 1.5, 1, 0.5} ' 1/8, 1/4. 1/2 1
    Dim pensizes() As Double = {0.2, 0.4, 0.6, 0.8, 1.0, 2.0, 5.0, 10.0}
    Dim esizes() As Double = {1, 3, 5, 10, 20, 30, 50}
    Dim esize As Integer = 3
    Dim mul As Integer = 2
    Dim pensize As Integer = 1
    Dim mmpen As Double = 0.4
    Dim note As List(Of Page) = New List(Of Page)
    Public fontname As String = "ＭＳ ゴシック"
    Public fontSize As Integer = 12

    Public key As Integer = 0
    Public keyPressed As Char = Nothing
    Dim oldLoc As Point
    Public mouseStillDown As Boolean = False
    Dim filename As String = "名称未設定"
    Dim filePath As String = ""
    Dim exportText As Boolean = True
    Dim GaijiSave As Boolean = True
    Public isDirty As Boolean = False
    Public HandCursor As Cursor
    Public DotCursor As Cursor
    Dim MenuDropping As Boolean = False
    Dim packets As Queue(Of Integer())
    Public Exporting As Boolean
    Public noDrawOperation As Boolean
    Public undoList As New List(Of Undo)
    Public undoIndex As Integer
    Public tmpBuf As Bitmap
    Public UndoAble As Boolean = False
    Public redoAble As Boolean = False

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub
    Protected Overrides Sub WndProc(ByRef m As Message)
        Try
            If m_wtMessenger Is Nothing Then
                MyBase.WndProc(m)
            ElseIf Not m_wtMessenger.WndProc(m) Then
                MyBase.WndProc(m)
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public xTabletScale As Double
    Public yTabletScale As Double
    Public offScale As Double
    Dim xmax As Integer
    Dim ymax As Integer
    Dim scWidth As Integer
    Dim scheight As Integer
    Dim scLeft As Integer
    Dim scTop As Integer
    Public Function TabletXtoScreen(x As Integer) As Integer
        Return x * scWidth / xmax + scLeft
    End Function
    Public Function TabletYtoScreen(y As Integer) As Integer
        Return y * scheight / ymax + scTop
    End Function
    Public Function ScreenXtoTablet(x As Integer) As Integer
        Return (x - scLeft) * xmax / scWidth
    End Function
    Public Function ScreenYtoTablet(y As Integer) As Integer
        Return (y - scTop) * ymax / scheight
    End Function
    Public Function TabletXtoOff(x As Integer) As Integer
        Return (x * scWidth / xmax * times(mul)) + (scLeft * times(mul))
    End Function
    Public Function TabletYtOff(y As Integer) As Integer
        Return (y * scheight / ymax * times(mul)) + (scTop * times(mul))
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not WinTab.LoadWinTab() Then
                MessageBox.Show("ペンタブレットが見つかりません(WinTab32.dllが見つかりません)。", "WinTab.NET")
                Throw New WinTabException("WinTab.NETの初期化に失敗しました")
            End If
            m_wtMessenger = New WinTabMessenger
            m_wtContext = New WinTabContext
            AddHandler m_wtMessenger.CursorMove, AddressOf Form1_CursorMove
            AddHandler m_wtMessenger.NPressureChange, AddressOf Form1_NPressureChange
            AddHandler m_wtMessenger.CursorChange, AddressOf Form1_CursorChange
            AddHandler m_wtMessenger.ButtonDown, AddressOf Form1_ButtonDown
            AddHandler m_wtMessenger.ButtonUp, AddressOf Form1_ButtonUp

            xmax = WinTab.DeviceX.axMax + 1
            ymax = WinTab.DeviceY.axMax + 1
            Dim xmin = WinTab.DeviceX.axMin
            Dim ymin = WinTab.DeviceY.axMin
            Dim vr As Rectangle = SystemInformation.VirtualScreen
            scTop = vr.Top
            scLeft = vr.Left
            scWidth = vr.Width
            scheight = vr.Height
            yTabletScale = ymax / scheight
            xTabletScale = xmax / scWidth
            offScale = yTabletScale / times(mul)

            'm_wtContext.Open(Handle, True, ScreenXtoTablet(vr.Left), ScreenYtoTablet(vr.Top), xmax, ymax, ContextOption.DEFAULT, RelativeField.None)
            m_wtContext.Open(Handle, True, xmin, ymin, xmax, ymax, ContextOption.DEFAULT, RelativeField.None)
            'm_wtContext.Open(Me.Handle, True)
            Debug.WriteLine("xMax=" + xmax.ToString)
            Debug.WriteLine("yMax=" + ymax.ToString)
            PressureMax = WinTab.DeviceNPressure.axMax
            Debug.WriteLine("Pressure Max=" + PressureMax.ToString)
        Catch ex As Exception
            MessageBox.Show("タブレットが正常に動作していません")
            PressureMax = 255
        End Try
        packets = New Queue(Of Integer())
        Dim myLoc = IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly().Location)

        HandCursor = New Cursor(myLoc + "\" + "Resources\Hand.cur")
        DotCursor = New Cursor(myLoc + "\" + "Resources\Dot_00.cur")
        Me.ClientSize = My.Settings.MyClientSize
        fontname = My.Settings.font
        fontSize = My.Settings.size
        vertical = My.Settings.Vertical
        rtl = My.Settings.RTL
        startLeft = My.Settings.StartLeft



        pFactor = PressureMax / 255.0
        buildFontMenu()
        buildPenMenu()
        selectPenMenu(pensizes(pensize))
        selectEmenu(esizes(esize))
        selectFontMenu(fontname)
        selectSizeMenu(fontSize)
        note = New List(Of Page)
        Dim dummyPanel As New Panel()
        dummyPanel.Width = 0
        dummyPanel.Height = 1000

        Me.WindowState = My.Settings.WindowState

        FlowLayoutPanel1.Controls.Add(dummyPanel)
        If My.Application.CommandLineArgs IsNot Nothing Then
            If My.Application.CommandLineArgs.Count > 0 Then
                Dim f As String = My.Application.CommandLineArgs(0)

                If File.Exists(f) Then
                    If IO.Path.GetExtension(f) = ".name" Then
                        closeDocument()
                        LoadDocument(f)
                    End If
                End If
            End If
        End If

    End Sub
    Public Sub selectPage(p As Page)
        If thePage IsNot Nothing Then
            If p IsNot thePage Then
                thePage.unselectAllText()
                'thePage.CopyToGray()

                'p.CreateColorBits()

            End If
        Else
            'p.CreateColorBits()

        End If
        thePage = p
    End Sub
    Private Sub SetFont(font_ As String)
        fontname = font_
        If thePage IsNot Nothing Then
            Dim v As TextView = thePage.FindSelectedText()
            If v IsNot Nothing Then
                AddUndo(New Undo(thePage, v, v.GetFont, v.GetSize, v.GetDirection))
                v.SetFont(font_)
                Refresh()
            End If
        End If
    End Sub
    Private Sub setSize(size_ As Integer)
        fontSize = size_
        If thePage IsNot Nothing Then
            Dim v As TextView = thePage.FindSelectedText()
            If v IsNot Nothing Then
                AddUndo(New Undo(thePage, v, v.GetFont, v.GetSize, v.IsVertical()))
                v.SetSize(size_)
                Refresh()
            End If
        End If
    End Sub
    Public Sub selectDirectionButton(direction As Boolean)
        VertButton.Checked = direction
        HorizButton.Checked = Not direction
    End Sub
    Public Sub selectFontMenu(name As String)
        Dim num As Integer = ComboBox_Font.Items.Count
        For i As Integer = 0 To num - 1
            If ComboBox_Font.Items.Item(i).ToString = name Then
                ComboBox_Font.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub
    Public Sub selectSizeMenu(size As Integer)
        Dim num As Integer = ComboBox_size.Items.Count
        For i As Integer = 0 To num - 1
            If Integer.Parse(ComboBox_size.Items.Item(i).ToString) = size Then
                ComboBox_size.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub
    Private Sub selectPenMenu(size As Double)
        Dim num As Integer = PenMenu.Items.Count
        For i As Integer = 0 To num - 1
            If Double.Parse(PenMenu.Items.Item(i).ToString) = size Then
                PenMenu.SelectedIndex = i
                Exit For
            End If
        Next

    End Sub
    Private Sub selectEmenu(size As Integer)
        Dim num As Integer = ElaserMenu.Items.Count
        For i As Integer = 0 To num - 1
            If Integer.Parse(ElaserMenu.Items.Item(i).ToString) = size Then
                ElaserMenu.SelectedIndex = i
            End If
        Next
    End Sub
    Private Sub Form1_ButtonUp(e As PacketEventArgs)


    End Sub

    Private Sub Form1_ButtonDown(e As PacketEventArgs)

    End Sub
    Public Sub ClearRedo()
        If undoList.Count > 0 Then
            undoList.RemoveRange(undoIndex + 1, undoList.Count - undoIndex - 1)
        End If
    End Sub
    Private Sub Form1_CursorMove(e As PacketEventArgs)
        Dim pk As Integer() = {e.pkts.pkX, e.pkts.pkY, e.pkts.pkNormalPressure}

        Dim size As Double
        'Label1.Text = TabletXtoScreen(e.pkts.pkX).ToString + ":" + TabletYtoScreen(e.pkts.pkY).ToString
        If e.pkts.pkNormalPressure > 0 And drawing Then
            If (Control.ModifierKeys And Keys.Control = Keys.Control) Or
            noDrawOperation Or
            MenuDropping Then Return
            If e.pkts.pkStatus And &H10 Then
                tool = Eraser
                size = esizes(esize)

            Else
                tool = Pencil
                size = mmpen

            End If
            Dim pss(4)() As Integer
            Dim tmpx = 0, tmpy = 0, tmpPressure = 0



            curX = e.pkts.pkX
            curY = e.pkts.pkY
            'Label1.Text = curX.ToString + " : " + curY.ToString
            Dim curPoint As Point = New Point(curX, curY)
            Dim oldPoint As Point = New Point(oldX, oldY)

            Dim penPixel As Integer = mmToPixel(size)

            Dim pr As Integer = e.pkts.pkNormalPressure / pFactor
            'Dim pr As Integer = tmpPressure / 5 / pFactor
            If pr > 255 Then
                pr = 255
            End If
            'thePage.draw(tool, curPoint, oldPoint, penPixel, pr)
            thePage.draw(tool, curPoint, oldPoint, penPixel, e.pkts.pkNormalPressure)
            If curPoint.X < leftest Then
                leftest = curPoint.X
            ElseIf curPoint.X > rightest Then
                rightest = curPoint.X
            End If
            If curPoint.Y < toppest Then
                toppest = curPoint.Y
            ElseIf curPoint.Y > bottomest Then
                bottomest = curPoint.Y
            End If

            oldX = curX
            oldY = curY


        End If
    End Sub
    Dim bitLocked As Boolean = False
    Private Sub Form1_NPressureChange(e As PacketEventArgs)
        Dim size As Double
        If e.pkts.pkNormalPressure > 0 And Not drawing Then
            toppest = SystemInformation.VirtualScreen.Bottom
            leftest = SystemInformation.VirtualScreen.Right
            bottomest = SystemInformation.VirtualScreen.Top
            rightest = SystemInformation.VirtualScreen.Left

            oldX = e.pkts.pkX
            oldY = e.pkts.pkY
            curX = e.pkts.pkX
            curY = e.pkts.pkY
            Dim curPoint As Point = New Point(curX, curY)
            Dim oldPoint As Point = New Point(oldX, oldY)
            Dim screenPoint As Point = New Point(TabletXtoScreen(curX), TabletYtoScreen(curY))
            Dim localPoint = FlowLayoutPanel1.PointToClient(screenPoint)
            Dim c As Control = FlowLayoutPanel1.GetChildAtPoint(localPoint)
            If c IsNot Nothing Then
                If TypeName(c) = "Page" Then
                    Dim curPage As Page = c
                    selectPage(curPage)
                    drawing = True
                    tmpBuf = curPage.buf.Clone()
                    'bitLocked = True
                    'curPage.LockPixels()
                End If
            End If
            'Timer1.Start()
            Debug.WriteLine("Drawing")
        End If
        If e.pkts.pkNormalPressure = 0 And drawing Then
            Debug.WriteLine("Stop Drawing")
            Dim pixSize As Integer
            If e.pkts.pkStatus And &H10 Then
                tool = Eraser
                size = esizes(esize)
            Else
                tool = Pencil
                size = mmpen
            End If
            pixSize = mmToPixel(size)
            leftest -= pixSize
            toppest -= pixSize
            rightest += pixSize
            bottomest += pixSize
            leftest = TabletXtoScreen(leftest)
            toppest = TabletYtoScreen(toppest)
            bottomest = TabletYtoScreen(bottomest)
            rightest = TabletXtoScreen(rightest)
            Dim p As Point = New Point(leftest, toppest)
            'If bitLocked Then
            '    thePage.UnlockPixels()
            '    bitLocked = False
            'End If
            p = thePage.PointToClient(p)
            Dim r As Rectangle = New Rectangle(p.X, p.Y, rightest - leftest + 1, bottomest - toppest + 1)
            r.Inflate(10, 10)
            Debug.WriteLine(r.ToString)
            thePage.Invalidate(r)
            drawing = False

            AddUndo(New Undo(thePage, tmpBuf, thePage.buf.Clone()))

            'Timer1.Stop()
        End If
        If e.pkts.pkNormalPressure = 0 Then

        End If
    End Sub

    Private Sub Form1_CursorChange(e As PacketEventArgs)
        Debug.WriteLine("Cursor" + e.pkts.pkCursor.ToString)


    End Sub

    Public Sub AddUndo(undo_ As Undo)
        ClearRedo()
        undoList.Add(undo_)
        UndoAble = True
        redoAble = False
        undoIndex = undoList.Count - 1
        If undoIndex > 10 Then
            undoList.RemoveAt(0)
            undoIndex -= 1
        End If
    End Sub
    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub 新規ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新規ToolStripMenuItem.Click
        If closeDocument() Then
            Dim nd As New NewDocumentDialog()
            nd.RadioButton_rtl.Checked = My.Settings.RTL
            nd.RadioButton_ltr.Checked = Not My.Settings.RTL
            nd.RadioButton_startLeft.Checked = My.Settings.StartLeft
            If nd.ShowDialog(Me) = DialogResult.OK Then
                Try
                    pagenum = Integer.Parse(nd.TextBox_PageNum.Text)
                Catch ex As Exception
                    pagenum = 2
                End Try
                mihiraki = pagenum \ 2 + (pagenum Mod 2)
                If nd.RadioButton_rtl.Checked Then
                    rtl = True
                Else
                    rtl = False
                End If
                If nd.RadioButton_startLeft.Checked Then
                    startLeft = True
                Else
                    startLeft = False
                End If
                My.Settings.RTL = rtl
                My.Settings.StartLeft = startLeft

                CreateDocument(pagenum, rtl, startLeft)
                SetTitle()
            End If
        End If
    End Sub
    Private Sub CreateDocument(pagenum_ As Integer, rtl_ As Boolean, startLeft_ As Boolean)

        pagenum = pagenum

        mihiraki = pagenum \ 2 + (pagenum Mod 2)
        rtl = rtl_
        startLeft = startLeft_
        If (rtl And startLeft) Or (Not rtl And Not startLeft) Then
            Dim tp As Integer = pagenum + 1
            mihiraki = tp \ 2 + (tp Mod 2)
        Else

        End If
        CreatePages(mihiraki)

    End Sub
    Private Function closeDocument() As Boolean
        If isDirty Then
            '書類を保存するかどうか聞いて適切に処理
            SaveOrNot.Label1.Text = """" + filename + """" + "を保存しますか？"
            SaveOrNot.ShowDialog()
            If SaveOrNot.DialogResult = DialogResult.Cancel Then Return False
            If SaveOrNot.DialogResult = DialogResult.OK Then
                If filePath.Length > 0 Then
                    Save(filePath)
                Else
                    Save(GetSaveFileName())
                End If
            End If
        End If
        pagenum = 0
        mihiraki = 0
        Dim i As Integer
        For i = 0 To note.Count - 1
            FlowLayoutPanel1.Controls.RemoveAt(1)
            note(i).DeleteData()
        Next
        note.Clear()
        isDirty = False
        filename = "名称未設定"
        filePath = ""
        SetTitle()
        Return True
    End Function
    Private Sub CreatePages(pages As Integer)
        'Dim length = BMP_WIDTH * BMP_HEIGHT
        'Dim buf As Bitmap = New Bitmap(BMP_WIDTH, BMP_HEIGHT, PixelFormat.Format8bppIndexed)
        'Dim palette As ColorPalette = buf.Palette
        'Dim img_data(length) As Byte
        'Dim i As Integer
        'For i = 0 To length - 1
        '    img_data(i) = 255
        'Next

        'For i = 0 To 255
        '    palette.Entries(i) = Color.FromArgb(i, i, i)
        'Next
        'buf.Palette = palette
        'Dim bmpData As BitmapData = buf.LockBits(New Rectangle(0, 0, BMP_WIDTH, BMP_HEIGHT), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed)
        'Marshal.Copy(img_data, 0, bmpData.Scan0, length)
        'Erase img_data
        'buf.UnlockBits(bmpData)
        'buf.SetResolution(150, 150)
        For i = 0 To pages - 1
            note.Add(New Page(Me, times(mul), rtl, startLeft, i))

            FlowLayoutPanel1.Controls.Add(note(i))
            note(i).Centering()
        Next
        FlowLayoutPanel1.ScrollControlIntoView(note(0))
    End Sub
    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        m_wtContext.Overlap(True)
    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        m_wtContext.Overlap(False)
    End Sub

    Function mmToPixel(mm As Double) As Integer
        Dim result As Integer = (mm * 150 * 0.0393701)
        Return result
    End Function
    Private Sub DeselectText()
        If thePage IsNot Nothing Then
            thePage.unselectAllText()
            Refresh()
        End If
    End Sub
    Private Sub DeleteSelectedText()
        If thePage IsNot Nothing Then
            Dim v As TextView = thePage.FindSelectedText()
            thePage.texts.Remove(v)
            AddUndo(New Undo(thePage, v, Undo.CMD_DelText))
            Refresh()
        End If
    End Sub


    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        key = e.KeyCode
        If e.Control Then
            FlowLayoutPanel1.Cursor = Cursors.Arrow
        End If
        If e.Control And (e.KeyCode = Keys.Oemplus Or e.KeyCode = Keys.Add) Then
            zoomin()
        ElseIf e.Control And (e.KeyCode = Keys.OemMinus Or e.KeyCode = Keys.Subtract) Then
            zoomout()
        End If
        If e.KeyCode = Keys.Enter Then
            'If thePage IsNot Nothing And Not thePage.Editor.Visible Then

            '    thePage.Edit(Nothing, thePage.lastPoint)
            'End If
        End If
        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then
            DeleteSelectedText()
        End If
        If e.KeyCode = Keys.Escape Then
            DeselectText()
        End If
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        key = 0
        keyPressed = Nothing
        noDrawOperation = False
        FlowLayoutPanel1.Cursor = DotCursor
    End Sub

    Private Sub zoomout()
        If note.Count = 0 Then Return
        mul = mul - 1
        If mul < 0 Then
            mul = 0
            Return
        End If
        Dim i As Integer
        For i = 0 To note.Count - 1
            note(i).setSize(times(mul))
            note(i).Centering()
        Next
        FlowLayoutPanel1.ScrollControlIntoView(thePage)
        SetTitle()
    End Sub

    Private Sub zoomin()
        Dim oldScale = times(mul)

        If note.Count = 0 Then Return
        mul = mul + 1

        If mul > times.Length - 1 Then
            mul = times.Length - 1
            Return
        End If
        Dim i As Integer
        For i = 0 To note.Count - 1
            note(i).setSize(times(mul))
            note(i).Centering()
        Next
        FlowLayoutPanel1.ScrollControlIntoView(thePage)
        SetTitle()
        Debug.WriteLine(FlowLayoutPanel1.Bounds)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        penOK = True
    End Sub

    Private Sub 書き出しEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 書き出しEToolStripMenuItem.Click
        Dim QualityStr As String = 100
        Dim dpis() As Integer = {150, 200, 300, 600, 1200}
        Dim dpi As Integer = 0
        Dim isGray As Boolean = False
        Dim paper As Integer = 1
        Dim name As String = IO.Path.GetFileNameWithoutExtension(filename)
        Dim path As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory)
        If pagenum = 0 Then Return
        ExportOption.TextBox_Path.Text = path
        ExportOption.TextBox_Quality.Text = QualityStr
        ExportOption.TextBox_name.Text = name
        ExportOption.RadioButton_Color.Checked = My.Settings.ExportColor
        ExportOption.RadioButtonGray.Checked = Not My.Settings.ExportColor

        ExportOption.ComboBox_dpi.SelectedIndex = My.Settings.ExportDpi
        ExportOption.ComboBox_PaperSelect.SelectedIndex = My.Settings.ExpoerPaper
        If My.Settings.ExportFolder.Length > 0 Then
            ExportOption.TextBox_Path.Text = My.Settings.ExportFolder
        End If
        ExportOption.TextExportCheck.Checked = exportText
        ExportOption.UseGaijiCheck.Checked = GaijiSave
        If ExportOption.ShowDialog() = DialogResult.OK Then
            Exporting = True
            My.Settings.ExportDpi = ExportOption.ComboBox_dpi.SelectedIndex
            My.Settings.ExpoerPaper = ExportOption.ComboBox_PaperSelect.SelectedIndex
            My.Settings.ExportFolder = ExportOption.TextBox_Path.Text
            My.Settings.ExportColor = ExportOption.RadioButton_Color.Checked
            Dim Quality As Integer
            Dim outdpi As Integer
            QualityStr = ExportOption.TextBox_Quality.Text
            dpi = ExportOption.ComboBox_dpi.SelectedIndex
            name = ExportOption.TextBox_name.Text
            path = ExportOption.TextBox_Path.Text
            If name.Length = 0 Then name = IO.Path.GetFileNameWithoutExtension(filename)
            outdpi = dpis(dpi)
            Quality = Integer.Parse(QualityStr)
            isGray = ExportOption.RadioButtonGray.Checked
            If Quality < 0 Then Quality = 0
            If Quality > 100 Then Quality = 100
            paper = ExportOption.ComboBox_PaperSelect.SelectedIndex
            exportText = ExportOption.TextExportCheck.Checked
            GaijiSave = ExportOption.UseGaijiCheck.Checked
            SaveProg.setMaximun(100)
            SaveProg.setMinimum(0)
            SaveProg.setStep(1)
            SaveProg.Label1.Text = "JPEG書き出し中..."
            SaveProg.SetValue(0)
            SaveProg.StartPosition = FormStartPosition.CenterParent

            SaveProg.Show(Me)
            Dim l As New List(Of Object)
            l.Add(path + "/" + name)
            l.Add(Quality)
            l.Add(outdpi)
            l.Add(isGray)
            l.Add(paper)
            l.Add(exportText)
            l.Add(GaijiSave)
            l.Add(mihiraki)
            ExportWorker.RunWorkerAsync(l)

        End If


    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub

    Private Sub Timer_Export_Tick(sender As Object, e As EventArgs) Handles Timer_Export.Tick

    End Sub
    Private Sub buildFontMenu()
        Dim installedFontCollection As New InstalledFontCollection()
        Dim fontFamilies() As FontFamily
        fontFamilies = installedFontCollection.Families
        Dim j As Integer
        Dim count As Integer = fontFamilies.Length
        Dim familyName As String
        While j < count
            familyName = fontFamilies(j).Name
            ComboBox_Font.Items.Add(familyName)
            j += 1
        End While
    End Sub
    Private Sub buildPenMenu()
        For Each s As Double In pensizes
            PenMenu.Items.Add(s.ToString("0.0"))
        Next
        For Each s As Integer In esizes
            ElaserMenu.Items.Add(s.ToString)
        Next
    End Sub


    Private Sub ComboBox_Font_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Font.SelectedIndexChanged
        SetFont(ComboBox_Font.SelectedItem.ToString)
        Debug.WriteLine(fontname)
    End Sub

    Private Sub ComboBox_size_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_size.SelectedIndexChanged
        Dim sizeStr = ComboBox_size.SelectedItem.ToString
        Dim size As Integer
        If Integer.TryParse(sizeStr, size) Then
            fontSize = size
        Else
            fontSize = 12
        End If
        setSize(size)
        Debug.WriteLine(fontSize.ToString)
    End Sub

    Private Sub ComboBox_size_TextUpdate(sender As Object, e As EventArgs) Handles ComboBox_size.TextUpdate
        Dim sizeStr = ComboBox_size.SelectedText
        Dim size As Integer
        If Integer.TryParse(sizeStr, size) Then
            fontSize = size
        Else
            fontSize = 12
        End If

    End Sub

    Private Sub 保存SToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存SToolStripMenuItem.Click
        If filePath.Length > 0 Then
            Save(filePath)
        Else
            Save(GetSaveFileName())
        End If
    End Sub

    Private Sub 別名で保存AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 別名で保存AToolStripMenuItem.Click
        Save(GetSaveFileName())
    End Sub

    Private Sub 開くToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 開くToolStripMenuItem.Click

        closeDocument()

        Dim path As String = ""
        OpenFileDialog1.Filter = "まんがスケッチ書類(*.name)|*.name|すべてのファイル(*.*)|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim fname As String = OpenFileDialog1.FileName
            LoadDocument(fname)
        End If
    End Sub
    Private Function GetSaveFileName()
        Dim name As String = filename
        SaveFileDialog1.Filter = "まんがスケッチ書類(*.name)|*.name|すべてのファイル(*.*)|*.*"
        SaveFileDialog1.FileName = filename
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            name = SaveFileDialog1.FileName
            name = IO.Path.ChangeExtension(name, ".name")
        Else
            name = ""
        End If
        Return name
    End Function
    Public Sub Save(path As String)
        Dim save As Boolean = True
        If path.Length = 0 Then Return
        filename = System.IO.Path.GetFileName(path)
        filePath = path
        SetTitle()
        SaveProg.setMaximun(100)
        SaveProg.setMinimum(0)
        SaveProg.setStep(1)
        SaveProg.SetValue(0)
        SaveProg.Label1.Text = "保存中..."
        SaveProg.Show(Me)
        SaveWorker.RunWorkerAsync(path)
    End Sub
    Private Sub ファイルToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ファイルToolStripMenuItem.Click
        Dim dimm As Boolean
        If note Is Nothing Then
            dimm = True
        ElseIf note.Count = 0 Then
            dimm = True
        End If

        If dimm Then
            保存SToolStripMenuItem.Enabled = False
            別名で保存AToolStripMenuItem.Enabled = False
            書き出しEToolStripMenuItem.Enabled = False
            閉じるToolStripMenuItem.Enabled = False
        Else
            保存SToolStripMenuItem.Enabled = True
            別名で保存AToolStripMenuItem.Enabled = True
            書き出しEToolStripMenuItem.Enabled = True
            閉じるToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub 終了XToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了XToolStripMenuItem.Click
        If closeDocument() Then
            Close()
        End If
    End Sub

    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        closeDocument()
    End Sub
    Private Sub SetTitle()
        Dim fn As String = ""
        Dim d As Decimal = 1D / times(mul)
        If note.Count > 0 Then
            fn = " - " + filename + " (" + d.ToString("0.#%") + ")"
        End If
        Me.Text = My.Application.Info.Title + fn
    End Sub

    Private Sub ExportWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ExportWorker.DoWork
        Dim l As List(Of Object) = e.Argument
        Dim Path As String = l(0)
        Debug.WriteLine("Path=" + Path)
        Dim Quality As Integer = l(1)
        Dim outdpi As Integer = l(2)
        Dim paper As Integer = l(4)
        Dim isGray As Boolean = l(3)
        Dim exportText As Boolean = l(5)
        Dim GaijiSave As Boolean = l(6)
        Dim mihiraki As Integer = l(7)

        For i As Integer = 0 To mihiraki - 1
            note(i).exportImage(Path, Quality, outdpi, isGray, paper, exportText, GaijiSave)


            SaveProg.performStep()
            If ExportWorker.CancellationPending Then
                Exit For
            End If
            ExportWorker.ReportProgress(i * 100 / (mihiraki - 1))
        Next
        ExportWorker.ReportProgress(100)
        Thread.Sleep(500)
    End Sub

    Private Sub ExportWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles ExportWorker.ProgressChanged
        SaveProg.SetValue(e.ProgressPercentage)
    End Sub

    Private Sub ExportWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ExportWorker.RunWorkerCompleted
        SaveProg.Hide()
        Exporting = False
    End Sub

    Private Sub SaveWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles SaveWorker.DoWork
        Dim path As String = e.Argument
        If path.Length = 0 Then Return
        Dim saveDir = IO.Path.GetDirectoryName(path)
        Dim tmpname As String = saveDir + "\" + IO.Path.GetRandomFileName()
        Try
            Using zipToOpen As FileStream = New FileStream(tmpname, FileMode.Create)
                Using archive As ZipArchive = New ZipArchive(zipToOpen, ZipArchiveMode.Create)
                    Dim info As ZipArchiveEntry = archive.CreateEntry("info.txt")
                    Dim documentVersion As String = "1"
                    Using writer As StreamWriter = New StreamWriter(info.Open())
                        writer.WriteLine("DocumentVersion=" + documentVersion)
                        writer.WriteLine("Page Right to Left=" + rtl.ToString)
                        writer.WriteLine("Start Left=" + startLeft.ToString)
                        writer.WriteLine("Page=" + pagenum.ToString)
                    End Using
                    Dim num As Integer = 0
                    Dim i As Integer
                    Dim max As Integer = note.Count - 1
                    For Each p As Page In note

                        SaveWorker.ReportProgress(num * 100 / max)
                        Thread.Yield()
                        Dim folder As String = num.ToString + "\"
                        Dim imgEntry As ZipArchiveEntry = archive.CreateEntry(folder + "image.raw")
                        Using writer As New BinaryWriter(imgEntry.Open())
                            Dim b As Byte() = p.GetRawImage()
                            writer.Write(b, 0, b.Length - 1)
                            Erase b
                        End Using
                        i = 0
                        For Each v As TextView In p.texts
                            SaveWorker.ReportProgress(num * 100 / max)
                            Dim txtEntry As ZipArchiveEntry = archive.CreateEntry(folder + i.ToString + ".txt")
                            Using writer As StreamWriter = New StreamWriter(txtEntry.Open())
                                writer.WriteLine(v.GetFont())
                                writer.WriteLine(v.GetSize().ToString)
                                Dim loc As Point = v.GetLocation
                                writer.WriteLine(loc.X.ToString)
                                writer.WriteLine(loc.Y.ToString)
                                writer.WriteLine(v.GetDirection())
                                writer.WriteLine("end")
                                writer.Write(v.GetText())
                            End Using
                            i += 1
                        Next

                        num += 1

                    Next
                End Using
            End Using
            If IO.File.Exists(path) Then
                File.Delete(path)

            End If

            File.Move(tmpname, path)
        Catch ex As Exception
            MessageBox.Show("ファイルの保存に失敗しました")
        End Try

        SaveWorker.ReportProgress(100)
        Thread.Sleep(500)
    End Sub

    Private Sub SaveWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles SaveWorker.ProgressChanged
        SaveProg.SetValue(e.ProgressPercentage)
    End Sub

    Private Sub SaveWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveWorker.RunWorkerCompleted
        'SaveProg.SetValue(100)
        SaveProg.Close()
        isDirty = False
    End Sub
    Private Sub LoadDocument(path As String)
        If note.Count > 0 Then
            If Not closeDocument() Then Return
        End If
        If File.Exists(path) Then
            Using zipToOpen As FileStream = New FileStream(path, FileMode.Open)
                Using archive As ZipArchive = New ZipArchive(zipToOpen, ZipArchiveMode.Read)
                    Dim info As ZipArchiveEntry = archive.GetEntry("info.txt")
                    Using reader As StreamReader = New StreamReader(info.Open())
                        Do While reader.Peek() >= 0
                            Dim s = reader.ReadLine()
                            Dim arr As String() = s.Split("="c)
                            Dim key = arr(0)
                            Dim value = arr(1)
                            If key = "DocumentVersion" Then
                                If value <> "1" Then
                                    Return
                                End If
                            ElseIf key = "Page Right to Left" Then
                                If value = "True" Then
                                    rtl = True
                                Else
                                    rtl = False
                                End If
                            ElseIf key = "Start Left" Then
                                If value = "True" Then
                                    startLeft = True
                                Else
                                    startLeft = False
                                End If
                            ElseIf key = "Page" Then
                                pagenum = Integer.Parse(value)
                            End If
                        Loop
                    End Using
                    Dim num As Integer = 0
                    Dim pages As List(Of Page) = New List(Of Page)
                    Do
                        Dim folder As String = num.ToString + "\"
                        Dim image As ZipArchiveEntry = archive.GetEntry(folder + "image.raw")
                        If image Is Nothing Then Exit Do
                        Dim p As Page = Nothing
                        Using reader As BinaryReader = New BinaryReader(image.Open())
                            Dim b(image.Length) As Byte
                            reader.Read(b, 0, image.Length)
                            p = New Page(Me, 2, rtl, startLeft, num)
                            p.SetImage(b)
                            pages.Add(p)

                            Erase b
                        End Using
                        Dim i As Integer = 0
                        Do
                            Dim text As ZipArchiveEntry = archive.GetEntry(folder + i.ToString + ".txt")
                            If text Is Nothing Then
                                Exit Do
                            End If
                            Using reader As StreamReader = New StreamReader(text.Open)

                                Dim s As String
                                Dim font_ As String

                                Dim size_ As Integer
                                Dim x_ As Integer
                                Dim y_ As Integer
                                Dim direction_ As Boolean
                                Dim text_ As String

                                font_ = reader.ReadLine()
                                s = reader.ReadLine()
                                size_ = Integer.Parse(s)
                                s = reader.ReadLine()
                                x_ = Integer.Parse(s)
                                s = reader.ReadLine()
                                y_ = Integer.Parse(s)
                                s = reader.ReadLine()
                                If s = "vertical" Then
                                    direction_ = True
                                Else
                                    direction_ = False

                                End If
                                s = reader.ReadLine()
                                If s = "end" Then
                                    text_ = reader.ReadToEnd()
                                Else
                                    text_ = " "
                                End If
                                Dim v As TextView = New TextView(p, x_, y_, text_, font_, size_, direction_)
                                p.texts.Add(v)
                            End Using
                            i = i + 1
                        Loop
                        num += 1
                    Loop
                    mihiraki = num
                    note.Clear()
                    note = pages
                    For Each p As Page In note
                        p.setSize(times(mul))

                        FlowLayoutPanel1.Controls.Add(p)
                        p.Centering()
                    Next
                    FlowLayoutPanel1.ScrollControlIntoView(note(1))
                End Using
            End Using
            filePath = path
            filename = IO.Path.GetFileNameWithoutExtension(path)
            SetTitle()
        End If

    End Sub

    Private Sub ZoomOutButton_Click(sender As Object, e As EventArgs) Handles ZoomOutButton.Click
        zoomout()
    End Sub

    Private Sub ZoomInButton_Click(sender As Object, e As EventArgs) Handles ZoomInButton.Click
        zoomin()
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Debug.WriteLine(e.KeyChar.ToString)
        keyPressed = e.KeyChar
        If keyPressed = "　"c Or keyPressed = " "c Then
            FlowLayoutPanel1.Cursor = HandCursor
            noDrawOperation = True
        End If
    End Sub

    Private Sub PenMenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PenMenu.SelectedIndexChanged
        mmpen = Double.Parse(PenMenu.SelectedItem.ToString)
        Debug.WriteLine("pensize=" + mmpen.ToString)
    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd

    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If note.Count > 0 Then
            For Each p As Page In note
                p.Centering()
            Next
        End If
    End Sub

    Private Sub 選択されたテキストの削除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 選択されたテキストの削除ToolStripMenuItem.Click
        DeleteSelectedText()
    End Sub

    Private Sub テキスト選択解除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles テキスト選択解除ToolStripMenuItem.Click
        DeselectText()
    End Sub

    Private Sub ComboBox_Font_DropDown(sender As Object, e As EventArgs) Handles ComboBox_Font.DropDown
        MenuDropping = True
    End Sub

    Private Sub ComboBox_size_DropDown(sender As Object, e As EventArgs) Handles ComboBox_size.DropDown
        MenuDropping = True
    End Sub

    Private Sub PenMenu_DropDown(sender As Object, e As EventArgs) Handles PenMenu.DropDown
        MenuDropping = True
    End Sub

    Private Sub ComboBox_Font_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBox_Font.DropDownClosed
        MenuDropping = False

    End Sub

    Private Sub PenMenu_DropDownClosed(sender As Object, e As EventArgs) Handles PenMenu.DropDownClosed
        MenuDropping = False
    End Sub

    Private Sub ComboBox_size_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBox_size.DropDownClosed
        MenuDropping = False
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not closeDocument() Then
            e.Cancel = True
        Else
            My.Settings.MyClientSize = Me.ClientSize
            My.Settings.font = fontname
            My.Settings.size = fontSize
            My.Settings.RTL = rtl
            My.Settings.StartLeft = startLeft
            My.Settings.Vertical = vertical
            My.Settings.WindowState = Me.WindowState
            My.Settings.restoreBounds = Me.RestoreBounds
        End If

    End Sub

    Private Sub まんがスケッチについてToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles まんがスケッチについてToolStripMenuItem.Click
        AboutBox1.ShowDialog()

    End Sub

    Private Sub ヒントToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ヒントToolStripMenuItem.Click
        Tips.ShowDialog()
    End Sub

    Private Sub SelectVertical(vert As Boolean)
        If vert Then
            vertical = True
            VertButton.Checked = True
            HorizButton.Checked = False
        Else
            vertical = False
            VertButton.Checked = False
            HorizButton.Checked = True

        End If
        If thePage IsNot Nothing Then
            Dim v As TextView = thePage.FindSelectedText()
            If v IsNot Nothing Then
                AddUndo(New Undo(thePage, v, v.GetFont, v.GetSize, v.IsVertical))
                v.SetDirection(vert)
                Dim g As Graphics = thePage.CreateGraphics()
                Refresh()

                'thePage.DrawGuides(g, thePage.sizeFactor, New Rectangle(0, 0, BMP_WIDTH, BMP_HEIGHT), Nothing)
            End If
        End If
    End Sub

    Private Sub FlowLayoutPanel1_DragDrop(sender As Object, e As DragEventArgs) Handles FlowLayoutPanel1.DragDrop
        Dim fileName As String() = CType(
        e.Data.GetData(DataFormats.FileDrop, False),
        String())
        Dim f As String = fileName(0)
        If IO.Path.GetExtension(f) = ".name" Then
            LoadDocument(f)
        End If

    End Sub

    Private Sub FlowLayoutPanel1_DragEnter(sender As Object, e As DragEventArgs) Handles FlowLayoutPanel1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ElaserMenu_DropDownClosed(sender As Object, e As EventArgs) Handles ElaserMenu.DropDownClosed
        esize = ElaserMenu.SelectedIndex
    End Sub

    Private Sub 元へ戻すToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 元へ戻すToolStripMenuItem.Click
        If UndoAble Then
            undoList(undoIndex).Undo()
            undoIndex -= 1
            If undoIndex <= 0 Then
                undoIndex = 0
                UndoAble = False

            End If
            redoAble = True
        End If

    End Sub

    Private Sub やり直しRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles やり直しRToolStripMenuItem.Click
        If redoAble Then
            If undoIndex + 1 < undoList.Count Then
                undoList(undoIndex + 1).Redo()
                undoIndex += 1
                If undoIndex > undoList.Count Then
                    redoAble = False
                End If
                UndoAble = True
            End If
        End If


    End Sub

    Private Sub 編集ToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles 編集ToolStripMenuItem.DropDownOpening
        If UndoAble Then
            元へ戻すToolStripMenuItem.Enabled = True
        Else
            元へ戻すToolStripMenuItem.Enabled = False
        End If
        If redoAble Then
            やり直しRToolStripMenuItem.Enabled = True
        Else
            やり直しRToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub HorizButton_Click(sender As Object, e As EventArgs) Handles HorizButton.Click
        SelectVertical(False)
    End Sub

    Private Sub VertButton_Click(sender As Object, e As EventArgs) Handles VertButton.Click
        SelectVertical(True)
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.MyClientSize = Me.ClientSize
    End Sub
End Class
