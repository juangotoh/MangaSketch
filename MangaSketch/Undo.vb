Public Class Undo
    Public Const CMD_AddText As Integer = 1
    Public Const CMD_DelText As Integer = 2
    Public Const CMD_MovText As Integer = 3
    Public Const CMD_Font As Integer = 4
    Public Const CMD_EditText As Integer = 5
    Dim task As Integer
    Dim page As Page
    Dim undoBits As Bitmap
    Dim redoBits As Bitmap
    Dim text As TextView
    Dim undoX As Integer
    Dim undoY As Integer
    Dim redoX As Integer
    Dim redoY As Integer
    Dim undoFont As String
    Dim redoFont As String
    Dim undoSize As Integer
    Dim redoSize As Integer
    Dim undoDirection As Boolean
    Dim redoDirection As Boolean
    Dim undoText As String
    Dim redoText As String

    ' for draw operation
    Public Sub New(page_ As Page, undoBits_ As Bitmap, redoBits_ As Bitmap)
        page = page_
        undoBits = undoBits_
        redoBits = redoBits_
    End Sub

    'for text operation
    Public Sub New(page_ As Page, text_ As TextView, command As Integer)
        page = page_
        text = text_
        task = command
    End Sub

    ' for text move operation
    Public Sub New(page_ As Page, text_ As TextView, undoX_ As Integer, undoY_ As Integer)

        page = page_
        text = text_
        undoX = undoX_
        undoY = undoY_
        redoX = text.x
        redoY = text.y
        task = CMD_MovText
    End Sub
    ' undo font
    Public Sub New(page_ As Page, text_ As TextView, undoFont_ As String, size_ As Integer, direction_ As Boolean)
        page = page_
        text = text_
        undoFont = undoFont_
        redoFont = text.GetFont()
        undoSize = size_
        redoSize = text.GetSize()
        undoDirection = direction_
        redoDirection = text.IsVertical()
        task = CMD_Font
    End Sub

    ' undo edit text
    Public Sub New(page_ As Page, text_ As TextView, undoText_ As String)
        page = page_
        text = text_
        undoText = undoText_
        redoText = text.GetText()
    End Sub

    Public Sub Undo()
        If undoBits IsNot Nothing Then
            page.buf = undoBits
            page.Refresh()
        ElseIf text IsNot Nothing Then
            Select Case task
                Case CMD_DelText
                    page.texts.Add(text)
                Case CMD_AddText
                    page.texts.Remove(text)
                Case CMD_MovText
                    text.x = undoX
                    text.y = undoY
                Case CMD_Font
                    text.SetFont(undoFont)
                    text.SetSize(undoSize)
                    text.SetDirection(undoDirection)
                    If text.selected Then
                        page.form.selectFontMenu(undoFont)
                        page.form.selectSizeMenu(undoSize)
                        page.form.selectDirectionButton(undoDirection)
                    End If

                Case CMD_EditText
                    text.SetText(undoText)
            End Select
            page.Refresh()

        End If

    End Sub
    Public Sub Redo()
        If undoBits IsNot Nothing Then
            page.buf = redoBits
            page.Refresh()
        ElseIf text IsNot Nothing Then
            Select Case task
                Case CMD_DelText
                    page.texts.Remove(text)
                Case CMD_AddText
                    page.texts.Add(text)
                Case CMD_MovText
                    text.x = redoX
                    text.y = redoY
                Case CMD_Font
                    text.SetFont(redoFont)
                    text.SetSize(redoSize)
                    text.SetDirection(redoDirection)
                    If text.selected Then
                        page.form.selectFontMenu(redoFont)
                        page.form.selectSizeMenu(redoSize)
                        page.form.selectDirectionButton(redoDirection)
                    End If
                Case CMD_EditText
                    text.SetText(redoText)
            End Select
            page.Refresh()


        End If
    End Sub


End Class
