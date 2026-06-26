Imports MySql.Data.MySqlClient

Public Class frmPelanggan

    Private selectedID As String = ""

    Private Sub frmPelanggan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilSemua()
    End Sub

    Private Sub TampilSemua()
        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim da As New MySqlDataAdapter("SELECT * FROM pelanggan ORDER BY id_pelanggan", conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvPelanggan.DataSource = dt

            ' Atur header kolom agar lebih rapi
            With dgvPelanggan
                .Columns("id_pelanggan").HeaderText = "ID"
                .Columns("nama_pelanggan").HeaderText = "Nama Pelanggan"
                .Columns("alamat").HeaderText = "Alamat"
                .Columns("no_hp").HeaderText = "No. HP"
            End With
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try

        Bersihkan()
    End Sub
    Private Sub Bersihkan()
        txtID.Clear()
        txtNama.Clear()
        txtAlamat.Clear()
        txtNoHP.Clear()
        txtCari.Clear()
        selectedID = ""
        txtID.Focus()
    End Sub

    Private Sub dgvPelanggan_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPelanggan.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvPelanggan.Rows(e.RowIndex)
            txtID.Text = row.Cells("id_pelanggan").Value.ToString()
            txtNama.Text = row.Cells("nama_pelanggan").Value.ToString()
            txtAlamat.Text = row.Cells("alamat").Value.ToString()
            txtNoHP.Text = row.Cells("no_hp").Value.ToString()
            selectedID = txtID.Text
        End If
    End Sub
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        ' Validasi: ID tidak boleh kosong
        If String.IsNullOrWhiteSpace(txtID.Text) Then
            MessageBox.Show("ID Pelanggan harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtID.Focus()
            Exit Sub
        End If

        ' Validasi: Nama tidak boleh kosong
        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama Pelanggan harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            Exit Sub
        End If

        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            ' Cek apakah ID sudah ada
            Dim cekCmd As New MySqlCommand("SELECT COUNT(*) FROM pelanggan WHERE id_pelanggan = @id", conn)
            cekCmd.Parameters.AddWithValue("@id", txtID.Text.Trim())
            Dim count As Integer = Convert.ToInt32(cekCmd.ExecuteScalar())
            If count > 0 Then
                MessageBox.Show("ID Pelanggan sudah terdaftar! Gunakan ID lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtID.Focus()
                txtID.SelectAll()
                Exit Sub
            End If

            ' Insert data
            Dim sql As String = "INSERT INTO pelanggan VALUES(@id, @nm, @al, @hp)"
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@id", txtID.Text.Trim())
            cmd.Parameters.AddWithValue("@nm", txtNama.Text.Trim())
            cmd.Parameters.AddWithValue("@al", txtAlamat.Text.Trim())
            cmd.Parameters.AddWithValue("@hp", txtNoHP.Text.Trim())
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data pelanggan berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TampilSemua()
        Catch ex As Exception
            MessageBox.Show("Error saat menambah data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedID = "" Then
            MessageBox.Show("Pilih data yang akan diedit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama Pelanggan harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            Exit Sub
        End If

        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim sql As String = "UPDATE pelanggan SET nama_pelanggan=@nm, alamat=@al, no_hp=@hp WHERE id_pelanggan=@id"
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@id", selectedID)
            cmd.Parameters.AddWithValue("@nm", txtNama.Text.Trim())
            cmd.Parameters.AddWithValue("@al", txtAlamat.Text.Trim())
            cmd.Parameters.AddWithValue("@hp", txtNoHP.Text.Trim())
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data pelanggan berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TampilSemua()
        Catch ex As Exception
            MessageBox.Show("Error saat mengedit data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try
    End Sub
    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If selectedID = "" Then
            MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Konfirmasi
        If MessageBox.Show($"Yakin ingin menghapus pelanggan dengan ID '{selectedID}'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            ' Cek apakah pelanggan sudah memiliki transaksi
            Dim cekCmd As New MySqlCommand("SELECT COUNT(*) FROM transaksi WHERE id_pelanggan = @id", conn)
            cekCmd.Parameters.AddWithValue("@id", selectedID)
            Dim count As Integer = Convert.ToInt32(cekCmd.ExecuteScalar())
            If count > 0 Then
                MessageBox.Show("Pelanggan ini memiliki transaksi, tidak bisa dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim cmd As New MySqlCommand("DELETE FROM pelanggan WHERE id_pelanggan=@id", conn)
            cmd.Parameters.AddWithValue("@id", selectedID)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data pelanggan berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TampilSemua()
        Catch ex As Exception
            MessageBox.Show("Error saat menghapus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try
    End Sub
    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        If String.IsNullOrWhiteSpace(txtCari.Text) Then
            TampilSemua()
            Exit Sub
        End If

        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim sql As String = "SELECT * FROM pelanggan WHERE nama_pelanggan LIKE @c OR id_pelanggan LIKE @c ORDER BY id_pelanggan"
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@c", "%" & txtCari.Text.Trim() & "%")

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvPelanggan.DataSource = dt

            ' Atur header kolom
            If dt.Rows.Count > 0 Then
                With dgvPelanggan
                    .Columns("id_pelanggan").HeaderText = "ID"
                    .Columns("nama_pelanggan").HeaderText = "Nama Pelanggan"
                    .Columns("alamat").HeaderText = "Alamat"
                    .Columns("no_hp").HeaderText = "No. HP"
                End With
            End If

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Pelanggan tidak ditemukan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saat mencari: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        TampilSemua()
    End Sub
    Private Sub txtCari_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCari.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnCari.PerformClick()
        End If
    End Sub
    Private Sub txtID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtID.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNama.Focus()
        End If
    End Sub

    Private Sub txtNama_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNama.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAlamat.Focus()
        End If
    End Sub

    Private Sub txtAlamat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAlamat.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoHP.Focus()
        End If
    End Sub

    Private Sub txtNoHP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoHP.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnTambah.PerformClick()
        End If
    End Sub

End Class