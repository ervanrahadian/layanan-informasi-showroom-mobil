Public Class Print
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MasterTableAdapter.Fill(Me.DatabaseCarsDataSet.Master)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Mstr As New Master()
        Mstr.Show()
        Me.Close()
    End Sub
End Class