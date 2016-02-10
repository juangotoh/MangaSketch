Imports System.Drawing.Drawing2D
Public Class TextView
    Dim Parent As Page
    Public x, y As Integer
    Dim Text As String
    Dim vertical As Boolean = True
    Dim fontname As String = "ＭＳ ゴシック"
    Dim size As Single = 11
    Public bounds As Rectangle
    Public selected As Boolean = False
    Public Sub New(parent_ As Page, inx As Integer, iny As Integer, inText As String, fname As String, fSize As Integer, isvertical As Boolean)
        Parent = parent_
        x = inx
        y = iny
        Text = inText
        fontname = fname
        size = fSize
        vertical = isvertical
    End Sub
    Public Function GetLocation() As Point
        Return New Point(x, y)
    End Function
    Public Sub SetFont(name As String)
        fontname = name
    End Sub
    Public Function GetFont() As String
        Return fontname
    End Function
    Public Sub SetSize(s As Single)
        size = s
    End Sub
    Public Function GetSize() As Single
        Return size
    End Function
    Public Sub SetText(Str As String)
        Text = Str
    End Sub
    Public Function GetText() As String
        Return Text
    End Function
    Public Sub SetDirection(vert As Boolean)
        vertical = vert

    End Sub
    Public Function GetDirection() As String
        If vertical Then
            Return "vertical"
        Else
            Return "horizontal"
        End If
    End Function
    Public Function IsVertical() As Boolean
        Return vertical
    End Function


    Public Sub Draw(g As Graphics, sf As Double, r As Rectangle, noDraw As TextView)
        g.PageUnit = GraphicsUnit.Pixel
        Dim fontSuffix As String = ""
        Dim pixSize As Double = size * 150 / 72 / sf
        If vertical Then fontSuffix = "@"
        Dim font As New Font(fontSuffix + fontname, pixSize, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim hFont As New Font(fontname, pixSize, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim CharSize As SizeF = g.MeasureString("鬱", hFont, 100, StringFormat.GenericTypographic)
        Dim cWidth = CharSize.Width
        Dim cHeight = pixSize
        'g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim origin As Point = New Point(x / sf, y / sf)
        Dim format As StringFormat
        If vertical Then

            format = New StringFormat(StringFormatFlags.DirectionRightToLeft Or StringFormatFlags.DirectionVertical)
            'Dim tSize As SizeF = g.MeasureString(GaijiConvert(Text), font, origin, format)
            Dim tsize As SizeF = myMeasureString(g, sf)
            Dim oSize As Size = New Size(tSize.Width, tSize.Height)
            Dim rorigin As Point = New Point(origin.X - tSize.Width, origin.Y)
            bounds = New Rectangle(rorigin, oSize)

        Else
            format = New StringFormat()
            Dim tSize As SizeF = g.MeasureString(GaijiConvert(Text), font)
            Dim oSize As Size = New Size(tSize.Width, tSize.Height)
            bounds = New Rectangle(origin, oSize)

        End If
        If r.IntersectsWith(bounds) And noDraw Is Nothing Then
            If noDraw IsNot Me Then
                g.FillRectangle(New SolidBrush(Color.FromArgb(196, 255, 255, 255)), bounds)
                If vertical Then
                    MyDrawString(g, GaijiConvert(Text), origin, sf)
                Else
                    g.DrawString(GaijiConvert(Text), font, Brushes.Black, origin, format)
                End If
                If selected Then
                    If Parent IsNot Nothing Then
                        If Not Parent.form.Exporting Then
                            g.DrawRectangle(Pens.Cyan, bounds)
                        End If
                    End If

                End If
            End If

        End If
        format.Dispose()
        font.Dispose()
        hFont.Dispose()
    End Sub
    Private Function myMeasureString(g As Graphics, sf As Double) As Size
        Dim fontSuffix As String = ""
        Dim pixSize As Double = size * 150 / 72 / sf
        If vertical Then fontSuffix = "@"
        Dim font As New Font(fontSuffix + fontname, pixSize, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim hFont As New Font(fontname, pixSize, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim CharSize As SizeF = g.MeasureString("鬱", hFont, 100)
        Dim cWidth = CharSize.Width
        Dim cHeight = pixSize
        Dim text2 = GaijiConvert(Text)
        Dim testheight As Single = 0
        Dim testwidth As Single = 0
        Dim testy = 0
        Dim hankaku As Boolean
        testwidth = cWidth
        For Each c As Char In text2
            If c >= " " And c <= "~" Then
                hankaku = True

            Else
                If hankaku Then
                    hankaku = False
                    testy += cHeight
                End If
                If c = vbCr Then
                    'skip CR
                ElseIf c = vbLf Then
                    testwidth += cWidth
                    If testy > testheight Then testheight = testy
                    testy = 0
                Else
                    testy += cHeight
                End If

            End If
        Next
        If hankaku Then
            hankaku = False
            testy += cHeight
        End If
        If testy > testheight Then testheight = testy
        font.Dispose()
        hFont.Dispose()
        Return New Size(testwidth, testheight)
    End Function
    Private Sub MyDrawString(g As Graphics, s As String, loc As Point, sf As Double)
        Dim fontSuffix As String = ""
        Dim pixSize As Double = size * 150 / 72 / sf
        If vertical Then fontSuffix = "@"
        Dim font As New Font(fontSuffix + fontname, pixSize, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim hFont As New Font(fontname, pixSize, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim CharSize As SizeF = g.MeasureString("鬱", hFont, 100)
        Dim cWidth = CharSize.Width
        Dim cHeight = pixSize
        Dim text2 = GaijiConvert(Text)
        Dim testheight As Single = 0
        Dim testwidth As Single = 0
        Dim testy = 0
        Dim hankaku As Boolean
        Dim hanstr As String = ""
        Dim dloc As New Point(loc.X - cWidth, loc.Y)

        For Each c As Char In text2
            If c >= " " And c <= "~" Then
                hankaku = True
                hanstr += c
            Else
                If hankaku Then
                    hankaku = False
                    'draw hanstr here
                    Dim hansize As SizeF = g.MeasureString(hanstr, hFont)
                    Dim hScale As Single = cWidth / hansize.Width
                    g.ScaleTransform(hScale, 1)
                    Dim hloc = New Point(dloc.X / hScale, dloc.Y)
                    g.DrawString(hanstr, hFont, Brushes.Black, hloc)
                    g.ResetTransform()
                    hanstr = ""
                    dloc.Y += cHeight
                End If
                If c = vbCr Then
                    'skip CR
                ElseIf c = vbLf Then
                    dloc.X -= cWidth
                    dloc.Y = loc.Y
                Else
                    g.DrawString(c, font, Brushes.Black, dloc)
                    dloc.Y += cHeight
                End If

            End If
        Next
        If hankaku Then
            hankaku = False
            Dim hansize As SizeF = g.MeasureString(hanstr, hFont)
            Dim hScale As Single = cWidth / hansize.Width
            g.ScaleTransform(hScale, 1)
            Dim hloc = New Point(dloc.X / hScale, dloc.Y)
            g.DrawString(hanstr, hFont, Brushes.Black, hloc)
            g.ResetTransform()
            hanstr = ""
            dloc.Y += cHeight
        End If
        font.Dispose()
        hFont.Dispose()
    End Sub

    Public Function GaijiConvert(text As String) As String
        Dim result As String = text
        Dim Iwa() As String = {"", "", "", "", ""}
        Dim Ryo() As String = {"", "", "", "", ""}
        If fontname = "I-OTFアンチックStd B" Or
            fontname = "IWAアンチックB" Or
            fontname = "IWApアンチックB" Then
            result = result.Replace("!!!", Iwa(2))
            result = result.Replace("!!", Iwa(1))
            result = result.Replace("!?", Iwa(3))
            result = result.Replace("!", Iwa(0))
            result = result.Replace("～", Iwa(4))
            If vertical Then
                result = result.Replace(Iwa(4), "")
            End If
        ElseIf fontname.IndexOf("リョービ アンチック") >= 0 Or
                fontname.IndexOf("リョービ フキダシック") >= 0 Or
                fontname.IndexOf("リョービ ミダシック") >= 0 Or
                fontname.IndexOf("リョービ レタリック") >= 0 Or
               fontname.IndexOf("TBアンチック") >= 0 Or
               fontname.IndexOf("TBフキダシック") >= 0 Or
               fontname.IndexOf("TBミダシック") >= 0 Or
               fontname.IndexOf("TBレタリック") >= 0 Then
            result = result.Replace("!!!", Ryo(2))
            result = result.Replace("!!", Ryo(1))
            result = result.Replace("!?", Ryo(3))
            result = result.Replace("!", Ryo(0))
            result = result.Replace("～", Ryo(4))
            If vertical Then
                result = result.Replace(Ryo(4), "")
            End If
        End If
        Return result
    End Function
End Class
