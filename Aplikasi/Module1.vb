Imports System.Data.OleDb
Module Module1
    Public conn As OleDbConnection
    Public cmd As OleDbCommand
    Public ds As DataSet
    Public da As OleDbDataAdapter
    Public dr As OleDbDataReader

    Sub koneksi()
        Try
            conn = New OleDbConnection("provider = Microsoft.jet.oledb.4.0;data source=DatabaseCars.mdb")
            conn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module