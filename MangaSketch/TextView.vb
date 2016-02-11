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
        Dim fmt As StringFormat
        Dim pixSize As Double = size * 150 / 72 / sf
        Dim hFont As New Font(fontname, pixSize, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim CharSize As SizeF = g.MeasureString("鬱", hFont, 100, StringFormat.GenericTypographic)
        Dim cWidth = CharSize.Width
        Dim cHeight = pixSize
        'g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim origin As Point = New Point(x / sf, y / sf)
        Dim format As StringFormat
        If vertical Then
            'Dim tSize As SizeF = g.MeasureString(GaijiConvert(Text), font, origin, format)
            Dim tsize As SizeF = myMeasureString(g, sf)
            Dim oSize As Size = New Size(tSize.Width, tSize.Height)
            Dim rorigin As Point = New Point(origin.X - tSize.Width, origin.Y)
            bounds = New Rectangle(rorigin, oSize)
            bounds.Width += cWidth / 2
            fmt = New StringFormat(StringFormatFlags.DirectionVertical Or StringFormatFlags.DirectionRightToLeft)
        Else
            fmt = New StringFormat
            format = New StringFormat()
            Dim tSize As SizeF = g.MeasureString(GaijiConvert(RemoveRuby(Text)), hFont)
            Dim oSize As Size = New Size(tSize.Width, tSize.Height)
            bounds = New Rectangle(origin, oSize)
            bounds.Height += cHeight / 2
            bounds.Offset(0, -cHeight / 2)
        End If
        If r.IntersectsWith(bounds) And noDraw Is Nothing Then
            If noDraw IsNot Me Then
                g.FillRectangle(New SolidBrush(Color.FromArgb(196, 255, 255, 255)), bounds)
                If vertical Then
                    MyDrawString(g, GaijiConvert(Text), origin, sf, fmt)
                Else
                    MyDrawString(g, GaijiConvert(Text), origin, sf, fmt)
                    'g.DrawString(GaijiConvert(Text), hFont, Brushes.Black, origin)
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
        fmt.Dispose()
        hFont.Dispose()
    End Sub
    Private Function myMeasureString(g As Graphics, sf As Double) As Size
        Dim fmt As StringFormat = StringFormat.GenericTypographic
        Dim pixSize As Double = size * 150 / 72 / sf
        Dim hFont As New Font(fontname, pixSize, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim CharSize As SizeF = g.MeasureString("鬱", hFont)
        Dim cWidth = CharSize.Width
        Dim cHeight = pixSize
        Dim text2 = GaijiConvert(Text)
        Dim testheight As Single = 0
        Dim testwidth As Single = 0
        Dim testx = 0
        Dim testy = 0
        Dim hankaku As Boolean
        Dim ruby As Boolean
        testwidth = cWidth
        For Each c As Char In text2
            If c = "｜" Then

            ElseIf c = "《" Then
                ruby = True

            ElseIf c = "》" Then
                ruby = False

            ElseIf c >= " " And c <= "~" Then
                hankaku = True

            Else
                If hankaku Then
                    hankaku = False
                    If Not ruby Then
                        testy += cHeight
                    End If

                End If
                If c = vbCr Then
                    'skip CR
                ElseIf c = vbLf Then
                    testwidth += cWidth
                    If testy > testheight Then testheight = testy
                    testy = 0
                Else
                    If Not ruby Then
                        testy += cHeight
                    End If

                End If

            End If
        Next
        If hankaku Then
            hankaku = False
            testy += cHeight
        End If
        If testy > testheight Then testheight = testy
        hFont.Dispose()
        testheight += cHeight * 0.2
        Return New Size(testwidth, testheight)
    End Function
    Private Sub MyDrawString(g As Graphics, s As String, loc As Point, sf As Double, fmt As StringFormat)
        Dim fontSuffix As String = ""
        Dim pixSize As Double = size * 150 / 72 / sf
        Dim hFont As New Font(fontname, pixSize, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim rubyFont As New Font(fontname, pixSize / 2, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim CharSize As SizeF = g.MeasureString("鬱", hFont)
        Dim CharSize2 As SizeF = g.MeasureString("鬱", hFont, 0, StringFormat.GenericTypographic)
        Dim cWidth = CharSize.Width
        Dim cWidth2 = CharSize2.Width
        Dim lHeight = CharSize.Height
        Dim pad As Single = (cWidth - cWidth2) / 2
        Dim cHeight = pixSize
        Dim text2 = GaijiConvert(Text)
        Dim testheight As Single = 0
        Dim testwidth As Single = 0
        Dim testy = 0
        Dim hankaku As Boolean
        Dim hanstr As String = ""
        Dim rStart As Integer = 0
        Dim rStop As Integer = 0
        Dim ruby As Boolean = False
        Dim rubyStr As String = ""
        Dim dloc As New Point(loc.X, loc.Y)

        For Each c As Char In text2
            If c = "｜" Then
                If vertical Then
                    rStart = dloc.Y
                Else
                    rStart = dloc.X
                End If

            ElseIf c = "《" Then
                ruby = True
                If vertical Then
                    rStop = dloc.Y
                Else
                    rStop = dloc.X
                End If
                c = ""
            ElseIf c = "》" Then
                ruby = False
                Dim rSize As SizeF = g.MeasureString(rubyStr, rubyFont, 0, fmt)

                If vertical Then

                    Dim startOffset = ((rStop - rStart) - rSize.Height) / 2
                    Dim rLoc As New Point(dloc.X + cWidth2 / 2 - pad / 2, rStart + startOffset)
                    g.DrawString(rubyStr, rubyFont, Brushes.Black, rLoc, fmt)
                Else
                    Dim startOffset = ((rStop - rStart) - rSize.Width) / 2
                    Dim rLoc As New Point(rStart + startOffset, dloc.Y - cHeight / 2 + pad / 2)
                    g.DrawString(rubyStr, rubyFont, Brushes.Black, rLoc, fmt)
                End If
                rubyStr = ""
            ElseIf c >= " " And c <= "~" Then
                hankaku = True
                hanstr += c
            Else
                If hankaku Then
                    hankaku = False
                    If Not ruby Then
                        'draw hanstr here
                        drawHankakuStr(g, hanstr, hFont, cWidth2, cWidth, cHeight, dloc)

                        hanstr = ""
                        If vertical Then
                            dloc.Y += cHeight
                        Else
                            dloc.X += cWidth2
                        End If
                    End If


                End If
                If c = vbCr Then
                    'skip CR
                ElseIf c = vbLf Then

                    If vertical Then
                        dloc.X -= cWidth
                        dloc.Y = loc.Y
                    Else
                        dloc.Y += lHeight
                        dloc.X = loc.X
                    End If

                Else
                    If Not ruby Then
                        g.DrawString(c, hFont, Brushes.Black, dloc, fmt)
                        If vertical Then
                            dloc.Y += cHeight
                        Else
                            dloc.X += cWidth2
                        End If
                    End If


                End If

            End If
            If ruby Then rubyStr += c
        Next
        If hankaku Then
            hankaku = False
            If Not ruby Then
                drawHankakuStr(g, hanstr, hFont, cWidth2, cWidth, cHeight, dloc)
                hanstr = ""
                If vertical Then
                    dloc.Y += cHeight
                Else
                    dloc.X += cWidth2
                End If
            End If

        End If
        hFont.Dispose()
        fmt.Dispose()
    End Sub
    Private Sub drawHankakuStr(g As Graphics, hanstr As String, hfont As Font, cWidth2 As Single, cWidth As Single, cheight As Single, ByRef dLoc As Point)
        Dim hansize As SizeF = g.MeasureString(hanstr, hfont, 0, StringFormat.GenericTypographic)
        Dim hansize2 As SizeF = g.MeasureString(hanstr, hfont)
        Dim hScale As Single = cWidth2 / hansize.Width
        Dim pad As Single = (cWidth - cWidth2) / 2.0F
        If vertical Then
            g.ScaleTransform(hScale, 1)
            Dim hloc = New Point((dLoc.X - cWidth + pad) / hScale, dLoc.Y + cheight * 0.1)
            g.DrawString(hanstr, hfont, Brushes.Black, hloc)
            g.ResetTransform()
        Else
            g.DrawString(hanstr, hfont, Brushes.Black, dLoc)
            dLoc.X += hansize.Width - cWidth2 + pad
        End If

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
    Public Function RemoveRuby(Str As String) As String
        Dim result As String
        result = System.Text.RegularExpressions.Regex.Replace(Str, "《.*?》", "")
        result = result.Replace("｜", "")
        Return result
    End Function

    ''' <summary>
    ''' 青空形式のルビを括弧書きに変換
    ''' </summary>
    ''' <param name="str">入力文字列</param>
    ''' <returns>返還後の文字列</returns>
    Public Function ConvertRuby(str As String) As String
        Dim result As String
        result = str.Replace("｜", "")
        result = result.Replace("《", "（")
        result = result.Replace("》", "）")
        Return result
    End Function
End Class
