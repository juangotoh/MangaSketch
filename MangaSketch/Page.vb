Imports System.Drawing.Imaging
Imports WinTabDotnet
Imports System.IO
Imports System.Windows.Media.Imaging
Imports System.Runtime.InteropServices
Imports BitMiracle.LibJpeg
Imports BitMiracle.LibJpeg.Classic
Imports System.Reflection


Public Class Page
    Inherits Panel
    Const BMP_WIDTH As Integer = 2149
    Const BMP_HEIGHT As Integer = 1517
    Dim form As Form1
    Dim rtl As Boolean
    Dim startLeft As Boolean
    Dim mihirakiNum As Integer
    Dim buf As Bitmap
    Dim rects(2) As RectangleF
    Public sizeFactor As Double
    Dim inWidth As Single = 886
    Dim inHeight As Single = 1299
    Dim pWidth As Single
    Dim pHeight As Single
    Dim noPaint(1) As Integer
    Dim bits As BitmapData
    Dim ptr As IntPtr
    Dim pixels As Byte()
    Public Editor As SmallEdit
    Public lastPoint As New Point(100, 100)
    Dim leftNum As Integer = -1
    Dim rightNum As Integer = -1
    Public texts As New List(Of TextView)
    Dim selectedText As Integer = -1
    Dim curFont As String = "ＭＳ ゴシック"
    Dim Dragging As Integer = -1
    Dim oldLoc As Point
    Public mouseStillDown As Boolean = False

    Public Sub DeleteData()
        buf.Dispose()
        Erase pixels
        texts.Clear()

    End Sub
    Public Sub New(ByRef form_ As Form1, ByRef tBits As Bitmap, ByRef sf As Double, isRtl As Boolean, isStartLeft As Boolean, mynum As Integer)
        form = form_
        rtl = isRtl
        startLeft = isStartLeft
        mihirakiNum = mynum
        If tBits IsNot Nothing Then
            buf = tBits.Clone
            setSize(sf)
        End If
        Editor = New SmallEdit
        Editor.Visible = False
        Me.DoubleBuffered = True
        Me.Controls.Add(Editor)
        Me.ImeMode = ImeMode.Alpha
    End Sub
    Public Sub setSize(sf As Double)
        SetBounds(0, 0, buf.Width / sf, buf.Height / sf)
        sizeFactor = sf
        Refresh()
    End Sub
    Public Sub Centering()
        If Parent.Width > Me.Width Then
            Dim pad As Integer = (Parent.Width - Me.Width) / 2
            Dim newPad As Padding = New Padding(pad, 3, pad, 3)
            Me.Margin = newPad
        End If
    End Sub
    Public Sub Edit(v As TextView, p As Point)
        Me.Controls.Add(Editor)
        lastPoint = p
        Dim x As Integer = p.X - (Editor.Width / 2)
        Dim y As Integer = p.Y - (Editor.Height / 2)
        If x + Editor.Width > Width Then
            x = Width - Editor.Width
        End If
        If x < 0 Then x = 0
        If y + Editor.Height > Height Then
            y = Height - Editor.Height
        End If
        If y < 0 Then y = 0
        If v IsNot Nothing Then
            Editor.TextBox1.Text = v.GetText()
        Else
            Editor.TextBox1.Text = ""
        End If
        Editor.Location = New Point(x, y)
        Editor.Show()
    End Sub
    Public Sub EndEdit()
        Dim tv As TextView = FindSelectedText()
        If tv Is Nothing Then
            tv = New TextView(lastPoint.X * sizeFactor, lastPoint.Y * sizeFactor, Editor.TextBox1.Text, Form1.fontname, Form1.fontSize, Form1.vertical)
            texts.Add(tv)
            unselectAllText()
            tv.selected = True
            selectedText = texts.Count - 1
            Refresh()
            Form1.isDirty = True
        Else
            tv.SetText(Editor.TextBox1.Text)
            Refresh()
            Form1.isDirty = True
        End If

        Editor.Hide()
        Editor.TextBox1.ImeMode = ImeMode.Alpha
        'Me.Select()
        Me.ImeMode = ImeMode.Alpha
    End Sub
    Public Sub unselectAllText()
        For Each v As TextView In texts
            If v.selected Then
                v.selected = False
                Dim r As Rectangle = v.bounds
                r = Rectangle.Inflate(r, 5, 5)
                'Clear(r)
                'DrawGuides(CreateGraphics, sizeFactor, r, Nothing)
                Invalidate(r)
            End If

        Next
        selectedText = -1
    End Sub
    Public Function FindSelectedText() As TextView
        For Each v As TextView In texts
            If v.selected Then Return v
        Next
        Return Nothing
    End Function
    Public Sub draw(tool As Integer, p As Point, op As Point, pensize As Integer, pressure As Integer)
        Dim lp As Point
        Dim lop As Point
        lp = PointToClient(p)
        lop = PointToClient(op)
        Dim dx As Integer = form.ScreenXtoTablet(lp.X - p.X)
        Dim dy As Integer = form.ScreenYtoTablet(lp.Y - p.Y)
        lp.X = p.X + dx
        lp.Y = p.Y + dy
        lop.X = op.X + dx
        lop.Y = op.Y + dy
        lastPoint = lp
        Dim x1 As Integer = form.TabletXtoScreen(lp.X)
        Dim y1 As Integer = form.TabletYtoScreen(lp.Y)
        Dim x2 As Integer = form.TabletXtoScreen(lop.X)
        Dim y2 As Integer = form.TabletYtoScreen(lop.Y)
        Dim l, t, r, b As Integer
        If x1 < x2 Then
            l = x1
            r = x2
        Else
            l = x2
            t = x1
        End If
        If y1 < y2 Then
            t = y1
            b = y2
        Else
            t = y2
            b = y1
        End If
        Dim screenRect As New Rectangle(l, r, r - l, b - t)
        Dim g As Graphics = CreateGraphics()
        Dim pn As Pen = New Pen(Color.FromArgb(&H7F000000), pensize)
        'g.DrawLine(pn, lop, lp)

        Debug.WriteLine(lp.X.ToString + ":" + lp.Y.ToString)
        drawBuf(tool, lop, lp, pensize, pressure)
        'DrawGuides(g, sizeFactor, screenRect, Nothing)
        Form1.isDirty = True
    End Sub
    Private Sub drawBuf(tool As Integer, ByRef startPt As Point, ByRef endPt As Point, penSize As Integer, col As Byte)
        If tool = 1 And Not form.penOK Then
            Return
        End If
        If form.penOK Then form.penOK = False
        'Dim x0 As Integer = startPt.X * sizeFactor - (penSize / 2)
        'Dim y0 As Integer = startPt.Y * sizeFactor - (penSize / 2)
        'Dim x1 As Integer = endPt.X * sizeFactor - (penSize / 2)
        'Dim y1 As Integer = endPt.Y * sizeFactor - (penSize / 2)
        'Dim x0 As Integer = startPt.X / form.xTabletScale * sizeFactor - (penSize / 2)
        'Dim y0 As Integer = startPt.Y / form.TabletScale * sizeFactor - (penSize / 2)
        'Dim x1 As Integer = endPt.X / form.xTabletScale * sizeFactor - (penSize / 2)
        'Dim y1 As Integer = endPt.Y / form.TabletScale * sizeFactor - (penSize / 2)
        Dim x0 As Integer = form.TabletXtoOff(startPt.X) - (penSize / 2)
        Dim y0 As Integer = form.TabletYtOff(startPt.Y) - (penSize / 2)
        Dim x1 As Integer = form.TabletXtoOff(endPt.X) - (penSize / 2)
        Dim y1 As Integer = form.TabletYtOff(endPt.Y) - (penSize / 2)
        Dim dx As Integer = Math.Abs(x1 - x0)
        Dim dy As Integer = Math.Abs(y1 - y0)
        Dim sx, sy As Integer
        Dim stp As Integer
        If penSize > 3 Then
            stp = penSize / 2
        Else
            stp = 1
        End If
        If x0 < x1 Then sx = stp Else sx = -stp
        If y0 < y1 Then sy = stp Else sy = -stp
        Dim err = dx - dy
        Dim bits As BitmapData = buf.LockBits(New Rectangle(0, 0, buf.Width, buf.Height), ImageLockMode.ReadWrite, buf.PixelFormat)
        Dim ptr As IntPtr = bits.Scan0
        Dim pixels As Byte() = New Byte(bits.Stride * buf.Height - 1) {}
        System.Runtime.InteropServices.Marshal.Copy(ptr, pixels, 0, pixels.Length)
        Dim e2 As Integer
        Do

            If x0 = x1 And y0 = y1 Then Exit Do
            plot(pixels, bits.Stride, x0, y0, tool, penSize, col)
            e2 = 2 * err
            If e2 > -dy Then
                err = err - dy
                x0 = x0 + sx
                If sx < 0 And x0 < x1 Then x0 = x1
                If sx > 0 And x0 > x1 Then x0 = x1

            End If
            If e2 < dx Then
                err = err + dx
                y0 = y0 + sy
                If sy < 0 And y0 < y1 Then y0 = y1
                If sy > 0 And y0 > y1 Then y0 = y1
            End If
        Loop


        System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptr, pixels.Length)

        buf.UnlockBits(bits)
        Erase pixels
        Dim g As Graphics = CreateGraphics()
        Dim left, top As Integer
        Dim padding As Integer = CInt(sizeFactor)
        Dim rwidth, rheight As Integer
        Dim right, bottom As Integer
        Dim xadd, yadd As Integer
        xadd = 0
        yadd = 0
        If x0 > x1 Then left = x1 Else left = x0
        If y0 > y1 Then top = y1 Else top = y0
        left = left - 10
        top = top - 10
        While left Mod sizeFactor <> 0
            left = left - 1
            xadd = xadd + 1
        End While
        While top Mod sizeFactor <> 0
            top = top - 1
            yadd = yadd + 1
        End While
        right = Math.Abs(dx) + left + penSize + 20 + xadd
        bottom = Math.Abs(dy) + top + penSize + 20 + yadd
        While right Mod sizeFactor <> 0
            right = right + 1
        End While
        While bottom Mod sizeFactor <> 0
            bottom = bottom + 1
        End While
        rwidth = right - left
        rheight = bottom - top

        Dim brect As New Rectangle(left, top, rwidth, rheight)
        Dim drect As New Rectangle(left / sizeFactor, top / sizeFactor, rwidth / sizeFactor, rheight / sizeFactor)
        g.InterpolationMode = Drawing2D.InterpolationMode.High
        g.DrawImage(buf, drect, brect, GraphicsUnit.Pixel)
        g.Dispose()
        Invalidate(drect)
    End Sub
    Private Sub plot(ByRef pixels As Byte(), stride As Integer, x As Integer, y As Integer, tool As Integer, size As Integer, col As Byte)
        If x < 0 Or x > buf.Width Or y < 0 Or y > buf.Height Then Return
        Dim ty As Integer
        Dim tx As Integer
        Dim painted(size * size) As Integer
        Dim index As Integer = 0
        Dim i As Integer
        For ty = y To y + size - 1
            For tx = x To x + size - 1
                Dim pos As Integer = ty * stride + tx
                For i = 0 To noPaint.Length - 1
                    If tool >= 0 And noPaint(i) = pos Then
                        'Return
                        Exit For
                    End If
                Next
                Try
                    If pos < pixels.Length Then
                        Dim pixel As Integer = pixels(pos)
                        If tool = 0 Then
                            pixel = pixel * (255 - col / 2) / 255
                        Else
                            pixel = pixel + col / 3
                            If pixel > 255 Then pixel = 255
                        End If

                        If pixel < 0 Then pixel = 0
                        pixels(pos) = pixel
                        painted(index) = pos
                        index = index + 1
                    End If

                Catch ex As Exception

                End Try

            Next
        Next
        noPaint = painted.Clone
    End Sub
    Public Sub LockPixels()
        bits = buf.LockBits(New Rectangle(0, 0, buf.Width, buf.Height), ImageLockMode.ReadWrite, buf.PixelFormat)
        'Debug.WriteLine("Bitmap Stride=" + bits.Stride.ToString)
        ptr = bits.Scan0
        pixels = New Byte(bits.Stride * buf.Height - 1) {}
        System.Runtime.InteropServices.Marshal.Copy(ptr, pixels, 0, pixels.Length)
    End Sub
    Public Sub UnlockPixels()
        Try
            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptr, pixels.Length)
            buf.UnlockBits(bits)
            Erase pixels
        Catch ex As Exception

        End Try


    End Sub
    Private Sub Page_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        If Not buf Is Nothing Then
            Dim rect As Rectangle = New Rectangle(0, 0, Me.Bounds.Width, Me.Bounds.Height)
            Dim sRect As Rectangle = New Rectangle(0, 0, buf.Width, buf.Height)
            Dim brect As New Rectangle(0, 0, buf.Width, buf.Height)
            Dim drect As New Rectangle(0, 0, buf.Width / sizeFactor, buf.Height / sizeFactor)
            e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.High
            e.Graphics.DrawImage(buf, drect, brect, GraphicsUnit.Pixel)
            'e.Graphics.DrawImage(buf, rect)
            e.Graphics.SetClip(rect)
            DrawGuides(e.Graphics, sizeFactor, sRect, Nothing)
        End If
    End Sub
    ''' <summary>
    ''' ページ区切り線、内枠、ページ番号を表示します。
    ''' </summary>
    ''' <param name="g">表示するGraphics、あらかじめSetClipで画面の大きさを設定する必要あり</param>
    ''' <param name="sf">原稿サイズに対する除数。２であればオフスクリーンビットマップの1/2で表示</param>
    Public Sub DrawGuides(g As Graphics, sf As Double, r As Rectangle, noDraw As TextView)
        Dim p As Pen = New Pen(Color.LightSkyBlue, 1.0)
        Dim pNum As Integer = mihirakiNum * 2
        Dim fontFamily As FontFamily = New FontFamily("Arial")
        Dim font As Font = New Font(fontFamily, 36 / sf)
        Dim leftCenter As Integer = g.ClipBounds.Width / 4
        Dim rightCenter As Integer = g.ClipBounds.Width - (g.ClipBounds.Width / 4)
        Dim leftX, rightX, leftY, rightY As Integer
        Dim leftStr, rightStr As String
        Dim lastPage As Integer = form.pagenum
        Dim rWidth = inWidth / sf
        Dim rHeight = inHeight / sf
        Debug.WriteLine("rWidth=" + rWidth.ToString)
        pWidth = g.ClipBounds.Width / 2.0
        pHeight = g.ClipBounds.Height
        rects(0) = New RectangleF((pWidth - rWidth) / 2.0, (pHeight - rHeight) / 2.0, rWidth, rHeight)
        rects(1) = New RectangleF((pWidth - rWidth) / 2.0 + pWidth, (pHeight - rHeight) / 2.0, rWidth, rHeight)
        For Each tv As TextView In texts
            '台詞描画
            tv.Draw(g, sf, r, noDraw)
        Next
        g.DrawRectangles(p, rects)
        g.DrawLine(p, pWidth, 0, pWidth, pHeight)
        Debug.WriteLine("Lines Draw")
        If rtl Then
            If startLeft Then
                '通常の縦書き左ページ始まり
                If mihirakiNum = 0 Then
                    '右ページにX描画
                    p.Color = Color.Red
                    g.DrawLine(p, pWidth, 0, g.ClipBounds.Width, g.ClipBounds.Height)
                    g.DrawLine(p, pWidth, g.ClipBounds.Height, g.ClipBounds.Width, 0)
                End If

            Else
                '縦書き右ページ始まり
                pNum = pNum + 1

            End If
            leftNum = pNum + 1
            rightNum = pNum
            leftStr = leftNum.ToString
            rightStr = rightNum.ToString
            If rightNum = 0 Then
                rightNum = -1
                rightStr = ""
            End If
            If leftNum > lastPage Then
                leftStr = ""
                leftNum = -1
                p.Color = Color.Red
                g.DrawLine(p, 0, 0, pWidth, g.ClipBounds.Height)
                g.DrawLine(p, 0, g.ClipBounds.Height, pWidth, 0)
            End If
        Else
            If startLeft Then
                '横書き左ページ始まり
                pNum = pNum + 1
            Else
                '横書き右ぺージ始まり
                If mihirakiNum = 0 Then
                    '左ページにX描画
                    p.Color = Color.Red
                    g.DrawLine(p, 0, 0, pWidth, g.ClipBounds.Height)
                    g.DrawLine(p, 0, g.ClipBounds.Height, pWidth, 0)
                End If

            End If
            leftNum = pNum
            rightNum = pNum + 1
            leftStr = leftNum.ToString
            rightNum = rightNum.ToString
            If leftNum = 0 Then
                leftStr = ""
                leftNum = -1
            End If
            rightStr = (pNum + 1).ToString
            rightNum = pNum + 1
            If rightNum > lastPage Then
                rightStr = ""
                rightNum = -1
                p.Color = Color.Red
                g.DrawLine(p, pWidth, 0, g.ClipBounds.Width, g.ClipBounds.Height)
                g.DrawLine(p, pWidth, g.ClipBounds.Height, g.ClipBounds.Width, 0)
            End If
        End If
        Dim leftSize As SizeF = g.MeasureString(leftStr, font)
        Dim rightSize As SizeF = g.MeasureString(rightStr, font)
        leftX = leftCenter - leftSize.Width / 2
        leftY = g.ClipBounds.Height - leftSize.Height
        rightX = rightCenter - rightSize.Width / 2
        rightY = g.ClipBounds.Height - rightSize.Height
        g.DrawString(leftStr, font, Brushes.Black, leftX, leftY)
        g.DrawString(rightStr, font, Brushes.Black, rightX, rightY)


    End Sub

    ''' <summary>
    ''' ページ画像をJPEG形式で書き出し
    ''' </summary>
    ''' <param name="path">出力ファイル名。連番追加して使用</param>
    ''' <param name="Quality">JPEG品質(0~100)</param>
    ''' <param name="dpi">解像度</param>
    ''' <param name="gray">グレイスケールJPEGにするかどうか</param>
    ''' <param name="paper">出力用紙サイズ。０～３（余白なしB5,余白付きB5（A4用紙),余白なし投稿サイズ、余白付き投稿サイズ(B4用紙)</param>
    Public Sub exportImage(path As String, Quality As Integer, dpi As Integer, gray As Boolean, paper As Integer, exportText As Boolean, gaijiSave As Boolean)
        Dim paperWidth() As Integer = {1074, 1240, 1240, 1517}
        Dim paperHeight() As Integer = {1517, 1753, 1753, 2149}
        Dim sizeParam As Integer = dpi / 150
        Dim pageWidth As Integer = buf.Width / 2
        Dim dWidth As Integer = buf.Width * sizeParam
        Dim dstWidth As Integer = dWidth / 2
        Dim dstHeight As Integer = buf.Height * sizeParam
        If paper > 2 Then
            dstWidth = dstWidth * 1.2
            dstHeight = dstHeight * 1.2
        End If
        Dim left As Double = (paperWidth(paper) * sizeParam - dstWidth) / 2
        Dim top As Double = (paperHeight(paper) * sizeParam - dstHeight) / 2
        Dim dRet As Rectangle = New Rectangle(left, top, dstWidth, dstHeight)
        Dim lRect As Rectangle = New Rectangle(0, 0, pageWidth, buf.Height)
        Dim rRect As Rectangle = New Rectangle(pageWidth + 1, 0, pageWidth, buf.Height)
        Dim eb As Bitmap = New Bitmap(buf.Width, buf.Height, PixelFormat.Format24bppRgb)
        Dim sb As Bitmap = New Bitmap(paperWidth(paper) * sizeParam, paperHeight(paper) * sizeParam, PixelFormat.Format24bppRgb)
        Dim sRect As Rectangle = New Rectangle(0, 0, buf.Width, buf.Height)
        Debug.WriteLine("dstWidth=" + dstWidth.ToString)
        Debug.WriteLine("dstHeight=" + dstHeight.ToString)
        sb.SetResolution(dpi, dpi)
        eb.SetResolution(150.0F, 150.0F)
        Dim g As Graphics = Graphics.FromImage(eb)
        Dim sg As Graphics = Graphics.FromImage(sb)
        sg.FillRectangle(Brushes.White, New Rectangle(0, 0, sb.Width, sb.Height))
        g.PageUnit = GraphicsUnit.Pixel
        g.SetClip(buf.GetBounds(GraphicsUnit.Pixel))
        Debug.WriteLine("buf.Width=" + buf.Width.ToString)
        Debug.WriteLine("g.Width=" + g.ClipBounds.Width.ToString)
        Dim brect As New Rectangle(0, 0, buf.Width, buf.Height)
        Dim crect As New Rectangle(0, 0, eb.Width, eb.Height)
        g.DrawImage(buf, crect, brect, GraphicsUnit.Pixel)
        DrawGuides(g, 1, sRect, Nothing)
        eb.SetResolution(dpi, dpi)
        Dim leftTexts As String = ""
        Dim rightTexts As String = ""
        For Each v As TextView In texts
            Dim ll As Integer = v.bounds.Left * sizeFactor
            Dim rr As Integer = v.bounds.Right * sizeFactor
            Dim cx As Integer = ll + (rr - ll) / 2
            If v.x > pageWidth Then
                If rightTexts.Length > 0 Then
                    rightTexts += ControlChars.CrLf + ControlChars.CrLf
                End If
                If gaijiSave Then
                    rightTexts += v.GaijiConvert(v.GetText())
                Else
                    rightTexts += v.GetText()
                End If

            Else
                If leftTexts.Length > 0 Then
                    leftTexts += ControlChars.CrLf + ControlChars.CrLf
                End If
                If gaijiSave Then
                    leftTexts += v.GaijiConvert(v.GetText())
                Else
                    leftTexts += v.GetText()
                End If

            End If
        Next
        '左ページ保存
        If leftNum > 0 Then
            Dim leftName As String = path + String.Format("_{0:D3}", leftNum) + ".jpg"
            If exportText Then
                Dim textname As String = path + String.Format("_{0:D3}", leftNum) + ".txt"
                Dim writer As StreamWriter = New StreamWriter(textname)
                writer.Write(leftTexts)
                writer.Close()
            End If
            sg.DrawImage(eb, dRet, lRect, GraphicsUnit.Pixel)
            saveJPEG(sb, leftName, Quality, gray, dpi)
            'sb.Save(leftName, ImageFormat.Jpeg)
            'SetJPEGdpi(leftName, dpi)
        End If
        '右ページ保存
        If rightNum > 0 Then
            Dim rightName = path + String.Format("_{0:D3}", rightNum) + ".jpg"
            If exportText Then
                Dim textname As String = path + String.Format("_{0:D3}", rightNum) + ".txt"
                Dim writer As StreamWriter = New StreamWriter(textname)
                writer.Write(rightTexts)
                writer.Close()
            End If
            sg.DrawImage(eb, dRet, rRect, GraphicsUnit.Pixel)
            saveJPEG(sb, rightName, Quality, gray, dpi)
            'sb.Save(rightName, ImageFormat.Jpeg)
            'SetJPEGdpi(rightName, dpi)
        End If
        g.Dispose()
        sg.Dispose()
        eb.Dispose()
        sb.Dispose()
        GC.Collect()

    End Sub
    Public Sub saveJPEG(b As Bitmap, name As String, q As Integer, gray As Boolean, dpi As Short)
        Dim rect As New Rectangle(0, 0, b.Width, b.Height)
        Dim bmpData As BitmapData = b.LockBits(rect, Imaging.ImageLockMode.ReadOnly, b.PixelFormat)
        Dim ptr As IntPtr = bmpData.Scan0
        Dim bytes As Integer = bmpData.Stride * b.Height
        Dim rgbValues(bytes - 1) As Byte
        Debug.WriteLine(name)
        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes)
        ' do compress and save
        Dim errorManager As New jpeg_error_mgr()
        Dim cinfo As New jpeg_compress_struct(errorManager)
        Dim output As New FileStream(name, FileMode.Create, FileAccess.Write)

        cinfo.jpeg_stdio_dest(output)
        cinfo.Image_width = b.Width
        cinfo.Image_height = b.Height
        cinfo.Input_components = 3
        cinfo.In_color_space = J_COLOR_SPACE.JCS_RGB
        cinfo.jpeg_set_defaults()
        If gray Then cinfo.jpeg_set_colorspace(J_COLOR_SPACE.JCS_GRAYSCALE)
        cinfo.jpeg_set_quality(q, True)
        cinfo.Density_unit = DensityUnit.DotsInch
        cinfo.X_density = dpi
        cinfo.Y_density = dpi
        Debug.WriteLine("cinfo.X_density_density=" + cinfo.X_density.ToString)
        Dim stride As Integer = cinfo.Image_width * 3
        Dim rowData(1)() As Byte
        rowData(0) = New Byte(stride) {}
        Dim pos As Integer = 0
        Dim curLine As Integer = 0

        cinfo.jpeg_start_compress(True)
        While (cinfo.Next_scanline < cinfo.Image_height)
            pos = curLine * bmpData.Stride
            If curLine < b.Height And pos + 2 < rgbValues.Length Then
                For i As Integer = 0 To (b.Width - 1) * 3 Step 3
                    rowData(0)(i) = rgbValues(pos + 2)
                    rowData(0)(i + 1) = rgbValues(pos + 1)
                    rowData(0)(i + 2) = rgbValues(pos + 0)
                    pos = pos + 3
                Next

            End If
            cinfo.jpeg_write_scanlines(rowData, 1)
            curLine = curLine + 1
        End While
        cinfo.jpeg_finish_compress()
        output.Close()
        b.UnlockBits(bmpData)
        bmpData = Nothing

    End Sub
    Public Function GetRawImage() As Byte()
        Dim rect As Rectangle = New Rectangle(0, 0, buf.Width, buf.Height)
        Dim bmpData As BitmapData = buf.LockBits(rect, Imaging.ImageLockMode.ReadOnly, buf.PixelFormat)
        Dim ptr As IntPtr = bmpData.Scan0
        Dim bytes As Integer = bmpData.Stride * buf.Height
        Dim result(bytes - 1) As Byte

        System.Runtime.InteropServices.Marshal.Copy(ptr, result, 0, bytes)
        buf.UnlockBits(bmpData)
        Return result
    End Function
    Public Sub SetImage(src As Byte())
        If buf Is Nothing Then
            buf = New Bitmap(BMP_WIDTH, BMP_HEIGHT, PixelFormat.Format8bppIndexed)
            Dim palette As ColorPalette = buf.Palette
            For i As Integer = 0 To 255
                palette.Entries(i) = Color.FromArgb(i, i, i)
            Next
            buf.Palette = palette
        End If
        Dim rect As Rectangle = New Rectangle(0, 0, buf.Width, buf.Height)
        Dim bmpData As BitmapData = buf.LockBits(rect, Imaging.ImageLockMode.WriteOnly, buf.PixelFormat)
        Dim ptr As IntPtr = bmpData.Scan0
        Dim bytes As Integer = bmpData.Stride * buf.Height
        System.Runtime.InteropServices.Marshal.Copy(src, 0, ptr, bytes)
        buf.UnlockBits(bmpData)
    End Sub
    <System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")>
    Private Shared Function DeleteObject(ByVal hObject As IntPtr) As Boolean
    End Function
    Public Function ToWPFBitmap(bitmap As System.Drawing.Bitmap) As BitmapSource

        Dim hb As Object = bitmap.GetHbitmap()
        Dim source As BitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hb, IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions())
        DeleteObject(hb)
        source.Freeze()
        Return source

    End Function
    Private Sub SetJPEGdpi(path As String, dpi As Integer)
        Dim jpg = New FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
        Dim br = New BinaryReader(jpg)
        Dim ok As Boolean = br.ReadUInt16() = &HD8FF
        ok = ok And br.ReadUInt16() = &HE0FF
        br.ReadInt16()
        ok = ok And br.ReadUInt32() = &H4649464A
        ok = ok And br.ReadByte() = 0
        ok = ok And br.ReadByte() = &H01
        br.ReadByte()
        Dim density As Byte = br.ReadByte
        ok = ok And (density = 1 Or density = 2)
        If Not ok Then Throw New Exception("Not a valid JPEG file")
        If density = 2 Then dpi = CInt(Math.Round(dpi / 2.56))
        Dim sdpi As Short = dpi
        Dim bigendian() As Byte = BitConverter.GetBytes(sdpi)
        Array.Reverse(bigendian)
        jpg.Write(bigendian, 0, 2)
        jpg.Write(bigendian, 0, 2)
        jpg.Close()
    End Sub
    Private Function FindText(p As Point) As Integer
        Dim index As Integer = texts.Count - 1
        While index >= 0
            If texts(index).bounds.Contains(p) Then
                Return index
            End If
            index -= 1
        End While
        Return -1
    End Function
    Public Sub Clear(r As Rectangle)
        Dim g As Graphics = CreateGraphics()
        Dim left, top As Integer
        Dim padding As Integer = CInt(sizeFactor)
        'Dim padding As Integer = sizeFactor
        Dim rwidth, rheight As Integer
        Dim right, bottom As Integer
        Dim xadd, yadd As Integer
        left = r.Left
        top = r.Top
        right = r.Right
        bottom = r.Bottom

        xadd = 0
        yadd = 0
        If padding > 0 Then
            While left Mod padding <> 0
                left = left - 1
            End While
            While top Mod padding <> 0
                top = top - 1
            End While
            While right Mod padding <> 0
                right = right + 1
            End While
            While bottom Mod padding <> 0
                bottom = bottom + 1
            End While
        End If

        rwidth = right - left
        rheight = bottom - top

        Dim brect As New Rectangle(left, top, rwidth, rheight)
        Dim drect As New Rectangle(left / sizeFactor, top / sizeFactor, rwidth / sizeFactor, rheight / sizeFactor)
        'g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        'g.DrawImage(buf, drect, brect, GraphicsUnit.Pixel)
        'g.Dispose()
        Invalidate(drect)
    End Sub
    Dim localOldLoc As Point
    Private m_PanStartPoint As New Point
    Private Sub Page_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Debug.WriteLine(Form1.key.ToString)
        mouseStillDown = True
        form.thePage = Me
        If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
            Dim i As Integer = FindText(e.Location)
            If i >= 0 Then
                Dim v As TextView = texts(i)


                Dim r As Rectangle = v.bounds
                Dim r2 As Rectangle = New Rectangle(r.Left * sizeFactor, r.Top * sizeFactor, r.Width * sizeFactor, r.Height * sizeFactor)
                Dim g As Graphics = CreateGraphics()
                'debug line
                'g.FillRectangle(Brushes.LightBlue, Me.Bounds)

                Dragging = i
                r2 = Rectangle.Inflate(r2, 1, 1)
                unselectAllText()
                v.selected = True
                form.selectFontMenu(v.GetFont)
                form.selectSizeMenu(v.GetSize)
                form.VertButton.Checked = v.IsVertical()
                form.HorizButton.Checked = Not v.IsVertical()
                form.vertical = v.IsVertical
                'Invalidate(r)
                g.Dispose()
            Else
                unselectAllText()
                Edit(Nothing, e.Location)
            End If
        ElseIf Form1.keyPressed = "　"c Or Form1.keyPressed = " "c Then
            m_PanStartPoint = New Point(e.X, e.Y)
        End If
        oldLoc = e.Location
    End Sub

    Private Sub Page_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        'form.Label1.Text = e.Location.ToString
        If mouseStillDown Then

            If (Form1.keyPressed = "　"c Or Form1.keyPressed = " "c) Then
                Dim deltaX As Integer = (m_PanStartPoint.X - e.X)
                Dim deltaY As Integer = (m_PanStartPoint.Y - e.Y)
                form.FlowLayoutPanel1.AutoScrollPosition = New Drawing.Point((deltaX - form.FlowLayoutPanel1.AutoScrollPosition.X), (deltaY - form.FlowLayoutPanel1.AutoScrollPosition.Y))
            Else
                If Dragging >= 0 Then
                    Dim dx As Integer = (e.X - oldLoc.X) * sizeFactor
                    Dim dy As Integer = (e.Y - oldLoc.Y) * sizeFactor
                    Dim v As TextView = texts(Dragging)
                    Dim r As Rectangle = v.bounds
                    Dim r2 As Rectangle = New Rectangle(r.Left * sizeFactor, r.Top * sizeFactor, r.Width * sizeFactor, r.Height * sizeFactor)
                    Debug.WriteLine("Rect=" + r2.ToString)
                    Dim g As Graphics = CreateGraphics()
                    g.PageUnit = GraphicsUnit.Pixel
                    r2 = Rectangle.Inflate(r2, 4, 4)
                    v.x += dx
                    v.y += dy
                    Clear(r2)
                    'Clear(Me.Bounds)
                    DrawGuides(g, sizeFactor, r2, v)
                    'Refresh()
                    r2.Offset(dx, dy)
                    DrawGuides(g, sizeFactor, r2, Nothing)
                    'v.Draw(g, sizeFactor, r2, Nothing)
                    v.Draw(g, sizeFactor, v.bounds, Nothing)
                    g.Dispose()
                End If
            End If
        End If

        oldLoc = e.Location
    End Sub
    Private Sub Page_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If Dragging >= 0 Then
            Dim dx As Integer = (e.X - oldLoc.X) * sizeFactor
            Dim dy As Integer = (e.Y - oldLoc.Y) * sizeFactor
            Dim v As TextView = texts(Dragging)
            Dim r As Rectangle = v.bounds
            Dim r2 As Rectangle = New Rectangle(r.Left * sizeFactor, r.Top + sizeFactor, r.Width * sizeFactor, r.Height * sizeFactor)
            Dim g As Graphics = CreateGraphics()
            r2 = Rectangle.Inflate(r2, 1, 1)
            v.x += dx
            v.y += dy
            'Invalidate(r)
            r2.Offset(dx, dy)
            v.selected = True
            v.Draw(g, sizeFactor, r2, v)
            g.Dispose()

        End If
        Dragging = -1

        oldLoc = e.Location
        mouseStillDown = False
        Debug.WriteLine("MouseUp")

    End Sub
    Private Sub Page_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick
        If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
            'Contril+ダブルクリック＝テキスト作成もしくは編集
            form.thePage = Me
            Dim i As Integer = FindText(e.Location)
            If i >= 0 Then
                Dim v As TextView = texts(i)
                Edit(v, e.Location)
            Else
                unselectAllText()
                Edit(Nothing, e.Location)
            End If
        End If
    End Sub
    Public Sub DeleteSelectedText()
        Dim needRedraw As Boolean = False
        If texts IsNot Nothing Then
            For i As Integer = 0 To texts.Count - 1
                Dim v As TextView = texts(i)
                If v.selected Then
                    texts.Remove(v)
                    v = Nothing
                    needRedraw = True
                End If
            Next
        End If
        If needRedraw Then Refresh()


    End Sub
    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)

    End Sub
    ' 何もしない
End Class
