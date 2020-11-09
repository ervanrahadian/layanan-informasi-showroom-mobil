Public Class Master

    Sub OffText()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        TextBox9.Enabled = False
        TextBox10.Enabled = False
        ComboBox1.Enabled = False
    End Sub

    Sub OnText()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox7.Enabled = True
        TextBox8.Enabled = True
        TextBox9.Enabled = True
        TextBox10.Enabled = True
        ComboBox1.Enabled = True
        TextBox1.Focus()
    End Sub

    Sub Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        ComboBox1.Text = ""
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
        Me.DataGridView1.Columns(8).DefaultCellStyle.Format = "N0"
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data Tidak Valid!")
            Exit Sub
        Else
            Call koneksi()
            cmd = New OleDb.OleDbCommand("Select * from Master where Kode_Mobil='" & TextBox1.Text & "'", conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                Call koneksi()
                Dim simpan As String
                simpan = "insert into Master values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "')"
                cmd = New OleDb.OleDbCommand(simpan, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Masuk")
            Else
                MsgBox("Data Ganda")
            End If
            Call OffText()
            Call Clear()
            Call GridView()
            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = True
            Button5.Enabled = False
            Button6.Enabled = False
            Button7.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("Pilih Data!")
            Exit Sub
        Else
            Call koneksi()
            cmd = New OleDb.OleDbCommand("delete from Master where Kode_Mobil='" & TextBox1.Text & "'", conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil Dihapus")
            Call OffText()
            Call Clear()
            Call GridView()
            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = True
            Button5.Enabled = False
            Button6.Enabled = False
            Button7.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call OffText()
        Call Clear()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Home.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call OnText()
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = False
        Button7.Enabled = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data Tidak Valid!")
            Exit Sub
        Else
            Call koneksi()
            cmd = New OleDb.OleDbCommand("update Master set Merk_Mobil='" & TextBox2.Text & "',Seri_Mobil='" & TextBox3.Text & "',Isi_Silinder='" & TextBox4.Text & "',Transmisi='" & ComboBox1.Text & "',Warna='" & TextBox5.Text & "',Tahun='" & TextBox6.Text & "',Negara_Asal='" & TextBox7.Text & "',Harga='" & TextBox8.Text & "',Jumlah='" & TextBox9.Text & "',Keterangan='" & TextBox10.Text & "' where Kode_Mobil='" & TextBox1.Text & "'", conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil Masuk")
        End If
        Call OffText()
        Call Clear()
        Call GridView()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = True
    End Sub

    Private Sub Master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Otomatis")
        ComboBox1.Items.Add("Manual")
        Call GridView()
        Call OffText()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = True
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        On Error Resume Next
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        TextBox8.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value
        TextBox9.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value
        TextBox10.Text = DataGridView1.Rows(e.RowIndex).Cells(10).Value
        Call OnText()
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = True
        Button7.Enabled = True
        TextBox1.Enabled = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim Prnt As New Print()
        Prnt.Show()
        Me.Close()
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        cmd = New OleDb.OleDbCommand("select * from Master where Kode_Mobil like '%" & TextBox11.Text & "%'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            da = New OleDb.OleDbDataAdapter("select * from Master where Kode_Mobil like '%" & TextBox11.Text & "%'", conn)
            ds = New DataSet
            da.Fill(ds, "cocok")
            DataGridView1.DataSource = ds.Tables("cocok")
            DataGridView1.ReadOnly = True
        Else
            MsgBox("Data Tidak Ditemukan!")
            TextBox11.Text = ""
        End If
    End Sub
End Class