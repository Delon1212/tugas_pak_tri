Imports MySql.Data.MySqlClient

Public Class frmBarang
    ' Variabel untuk menyimpan kode barang yang sedang dipilih di grid
    Private selectedKode As String = ""
    Private Sub frmBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilSemua()
    End Sub
    Private Sub TampilSemua()
        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim da As New MySqlDataAdapter("SELECT * FROM barang ORDER BY kode_barang", conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvBarang.DataSource = dt

            ' Atur header kolom agar lebih rapi
            With dgvBarang
                .Columns("kode_barang").HeaderText = "Kode"
                .Columns("nama_barang").HeaderText = "Nama Barang"
                .Columns("harga_beli").HeaderText = "Harga Beli"
                .Columns("harga_jual").HeaderText = "Harga Jual"
                .Columns("stok").HeaderText = "Stok"
            End With
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try

        Bersihkan()
    End Sub
    Private Sub Bersihkan()
        txtKode.Clear()
        txtNama.Clear()
        txtHargaBeli.Clear()
        txtHargaJual.Clear()
        txtStok.Clear()
        txtCari.Clear()
        selectedKode = ""
        txtKode.Focus()
    End Sub
    Private Sub dgvBarang_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBarang.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvBarang.Rows(e.RowIndex)
            txtKode.Text = row.Cells("kode_barang").Value.ToString()
            txtNama.Text = row.Cells("nama_barang").Value.ToString()
            txtHargaBeli.Text = row.Cells("harga_beli").Value.ToString()
            txtHargaJual.Text = row.Cells("harga_jual").Value.ToString()
            txtStok.Text = row.Cells("stok").Value.ToString()
            selectedKode = txtKode.Text
        End If
    End Sub
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        ' Validasi: Kode tidak boleh kosong
        If String.IsNullOrWhiteSpace(txtKode.Text) Then
            MessageBox.Show("Kode Barang harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtKode.Focus()
            Exit Sub
        End If

        ' Validasi: Nama tidak boleh kosong
        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama Barang harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            Exit Sub
        End If

        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim sql As String = "INSERT INTO barang (kode_barang, nama_barang, harga_beli, harga_jual, stok) VALUES (@kd, @nm, @hb, @hj, @stk)"
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@kd", txtKode.Text.Trim())
            cmd.Parameters.AddWithValue("@nm", txtNama.Text.Trim())
            cmd.Parameters.AddWithValue("@hb", Val(txtHargaBeli.Text))
            cmd.Parameters.AddWithValue("@hj", Val(txtHargaJual.Text))
            cmd.Parameters.AddWithValue("@stk", Val(txtStok.Text))

            cmd.ExecuteNonQuery()
            MessageBox.Show("Data barang berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error saat menambah data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try

        TampilSemua()
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedKode = "" Then
            MessageBox.Show("Pilih data yang akan diedit dari tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validasi: Nama tidak boleh kosong
        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama Barang harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            Exit Sub
        End If

        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim sql As String = "UPDATE barang SET nama_barang=@nm, harga_beli=@hb, harga_jual=@hj, stok=@stk WHERE kode_barang=@kd"
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@kd", selectedKode)
            cmd.Parameters.AddWithValue("@nm", txtNama.Text.Trim())
            cmd.Parameters.AddWithValue("@hb", Val(txtHargaBeli.Text))
            cmd.Parameters.AddWithValue("@hj", Val(txtHargaJual.Text))
            cmd.Parameters.AddWithValue("@stk", Val(txtStok.Text))

            cmd.ExecuteNonQuery()
            MessageBox.Show("Data barang berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error saat mengupdate data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try

        TampilSemua()
    End Sub
    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If selectedKode = "" Then
            MessageBox.Show("Pilih data yang akan dihapus dari tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Konfirmasi hapus
        If MessageBox.Show($"Yakin ingin menghapus barang dengan kode {selectedKode}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim sql As String = "DELETE FROM barang WHERE kode_barang=@kd"
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@kd", selectedKode)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Data barang berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error saat menghapus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try

        TampilSemua()
    End Sub
    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        ' Jika keyword kosong, tampilkan semua data
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
            Dim sql As String = "SELECT * FROM barang WHERE kode_barang LIKE @c OR nama_barang LIKE @c ORDER BY kode_barang"
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@c", "%" & txtCari.Text.Trim() & "%")

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvBarang.DataSource = dt

            ' Atur header kolom
            If dt.Rows.Count > 0 Then
                With dgvBarang
                    .Columns("kode_barang").HeaderText = "Kode"
                    .Columns("nama_barang").HeaderText = "Nama Barang"
                    .Columns("harga_beli").HeaderText = "Harga Beli"
                    .Columns("harga_jual").HeaderText = "Harga Jual"
                    .Columns("stok").HeaderText = "Stok"
                End With
            End If

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Barang tidak ditemukan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Private Sub txtKode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKode.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNama.Focus()
        End If
    End Sub

    Private Sub txtNama_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNama.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtHargaBeli.Focus()
        End If
    End Sub

    Private Sub txtHargaBeli_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHargaBeli.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtHargaJual.Focus()
        End If
    End Sub

    Private Sub txtHargaJual_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHargaJual.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStok.Focus()
        End If
    End Sub

    Private Sub txtStok_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStok.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Jika di Stok, fokus ke tombol Tambah (atau biarkan saja)
            btnTambah.Focus()
        End If
    End Sub
End Class