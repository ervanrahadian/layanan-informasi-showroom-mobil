Public Class Login2

    Sub Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksi()
        cmd = New OleDb.OleDbCommand("Select * from Office where Username='" & TextBox1.Text & "' and Password='" & TextBox2.Text & "'", conn)
        dr = cmd.ExecuteReader
        If dr.Read Then
            Dim Mstr2 As New Master2()
            Mstr2.Show()
            Me.Hide()
            Call Clear()
        Else
            MsgBox("Username atau Password Salah!")
            Call Clear()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Home.Show()
        Me.Close()
    End Sub
End Class