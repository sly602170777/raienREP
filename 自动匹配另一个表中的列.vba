Private Sub Worksheet Change Byval Target As Range)
    Dim I, count,J , LRow As Long 
    Dim c As Range
    Dim ws As Worksheet
    Set ws = Thisworkbook.worksheets("実施条件mapping")

    IRow = ws.Cells(Rows.count, "B").End(xIUp).Row
    '別列の最終行を取得します。
    For J = 3 To IRow
        'B列の3行目からB列の最終行まで繰り返します
        If count > 1 Then
            count = WorksheetFunction.CountIf(ws.Range("B:B"),ws.Cells(J, 2))
            '件数が1を超える場合は重複として判定します。
            'MSEBOX "第"＆コ&"行目の処置バターン値：&WS.CE115（3,2）.Value&"は重複されました；重複：『& count&"】件があります。"
            Exit Sub
        End If
    Next J
    For Each c In Target
    I=0
    Select Case c.Column
    Case 4 'D列
        '選択したセルは空の場合、該当行のE～G列の内容をクリアする
        If Target(1).Value = "" Then
            Cells(c.Row, c. Column + 1)=""
            Cells(c.Row, c. Column + 2) =""
            Cells(c.Row, c.Column + 3) =""
            Cells(c.Row, c. Column + 4) =""
        Else
            'MsgBox "--"& c.Value
            'スカセルロ列以外は処理しない
            'If c.Column <> [D1]. Column Then Exit Sub
            'シート「実施条件mapping」の処置バターンを取得
            Set Pattern = ws.Range("B:B").Find(c)
            If Pattern Is Nothing Then
                c.Offset(0, 1).Resize(1, 4) =""
                MsgBox "処置バターン値で"& c &"は存在しません。"
            End If
            If Not Pattern Is Nothing Then
                'シート「実施条件mapping」のC～F列内容を該当シート「page1」のE～G列にセットする
                c.Offset(I, 1).Resize(1, 4) = Pattern.Offset(0, 1).Resize(1, 4).Value
                I=I+1
            End If
        End If
    End Select
    Next c
End Sub