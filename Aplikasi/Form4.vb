Public Class Home
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Label1.Left >= Me.Width Then
            Label1.Left = -Label1.Width
        Else
            Label1.Left = Label1.Left + 50
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Label2.Left >= Me.Width Then
            Label2.Left = -Label2.Width
        Else
            Label2.Left = Label2.Left + 50
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Lgn As New Login()
        Lgn.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Abt As New About()
        Abt.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Lgn2 As New Login2()
        Lgn2.Show()
        Me.Hide()
    End Sub
End Class