Public Class Master2
    Private Sub Master2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GridView()
        TextBox1.Focus()
    End Sub

    Sub Clear()
        TextBox1.Text = ""
        TextBox1.Focus()
    End Sub

    Sub GridView()
        Call koneksi()
        da = New OleDb.OleDbDataAdapter("select * from Master", conn)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Me.DataGridView1.Columns(8).DefaultCellStyle.Format = "C0"
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Home.Show()
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        cmd = New OleDb.OleDbCommand("select * from Master where Merk_Mobil like '%" & TextBox1.Text & "%' OR Seri_Mobil like '%" & TextBox1.Text & "%' OR Transmisi like '%" & TextBox1.Text & "%' OR Warna like '%" & TextBox1.Text & "%' OR Negara_Asal like '%" & TextBox1.Text & "%' OR Keterangan like '%" & TextBox1.Text & "%'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            da = New OleDb.OleDbDataAdapter("select * from Master where Merk_Mobil like '%" & TextBox1.Text & "%' OR Seri_Mobil like '%" & TextBox1.Text & "%' OR Transmisi like '%" & TextBox1.Text & "%' OR Warna like '%" & TextBox1.Text & "%' OR Negara_Asal like '%" & TextBox1.Text & "%' OR Keterangan like '%" & TextBox1.Text & "%'", conn)
            ds = New DataSet
            da.Fill(ds, "cocok")
            DataGridView1.DataSource = ds.Tables("cocok")
            DataGridView1.ReadOnly = True
        Else
            MsgBox("Data Tidak Ditemukan!")
            Call Clear()
        End If
    End Sub
End Class