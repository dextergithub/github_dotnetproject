Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        ' WebDataHelper.LoadHuaJiCity()
        Dim c As Integer
        WebDataHelper.LoadStoreInfo(Nothing, 1, c)

    End Sub
End Class
