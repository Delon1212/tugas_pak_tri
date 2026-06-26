Imports MySql.Data.MySqlClient

Public Class frmCariBarang

    Public KodeTerpilih As String = ""
    Public NamaTerpilih As String = ""
    Public HargaTerpilih As Integer = 0
    Public QtyTerpilih As Integer = 1

    Private Sub frmCariBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtQty.Text = "1"
        TampilSemuaBarang()
    End Sub
    Private Sub TampilSemuaBarang()
        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim da As New MySqlDataAdapter("SELECT kode_barang, nama_barang, harga_jual, stok FROM barang ORDER BY nama_barang", conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvCari.DataSource = dt

            ' Atur header kolom
            With dgvCari
                .Columns("kode_barang").HeaderText = "Kode"
                .Columns("nama_barang").HeaderText = "Nama Barang"
                .Columns("harga_jual").HeaderText = "Harga Jual"
                .Columns("stok").HeaderText = "Stok"
            End With
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try
    End Sub
    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        If String.IsNullOrWhiteSpace(txtCari.Text) Then
            TampilSemuaBarang()
            Exit Sub
        End If

        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim sql As String = "SELECT kode_barang, nama_barang, harga_jual, stok FROM barang WHERE nama_barang LIKE @c OR kode_barang LIKE @c ORDER BY nama_barang"
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@c", "%" & txtCari.Text.Trim() & "%")

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvCari.DataSource = dt

            If dt.Rows.Count > 0 Then
                With dgvCari
                    .Columns("kode_barang").HeaderText = "Kode"
                    .Columns("nama_barang").HeaderText = "Nama Barang"
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

    Private Sub btnPilih_Click(sender As Object, e As EventArgs) Handles btnPilih.Click
        ' Validasi 1: Apakah ada baris yang dipilih?
        If dgvCari.SelectedRows.Count = 0 Then
            MessageBox.Show("Silakan pilih barang terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim row As DataGridViewRow = dgvCari.SelectedRows(0)

        ' Validasi 2: Apakah Qty diisi angka?
        Dim qtyInput As Integer
        If Not Integer.TryParse(txtQty.Text, qtyInput) Then
            MessageBox.Show("Qty harus berupa angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQty.Focus()
            txtQty.SelectAll()
            Exit Sub
        End If

        ' Validasi 3: Qty > 0?
        If qtyInput <= 0 Then
            MessageBox.Show("Qty harus lebih dari 0!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQty.Focus()
            txtQty.SelectAll()
            Exit Sub
        End If

        ' 🔥 AMBIL DATA DENGAN AMAN (PAKAI Convert.ToString)
        Dim kode As String = Convert.ToString(row.Cells("kode_barang").Value)
        Dim nama As String = Convert.ToString(row.Cells("nama_barang").Value)
        Dim harga As Integer = Convert.ToInt32(row.Cells("harga_jual").Value)
        Dim stokTersedia As Integer = Convert.ToInt32(row.Cells("stok").Value)

        ' 🔥 VALIDASI: Pastikan kode tidak kosong
        If String.IsNullOrWhiteSpace(kode) Then
            MessageBox.Show("Kode barang tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Validasi 4: Stok cukup?
        If qtyInput > stokTersedia Then
            MessageBox.Show($"Stok tidak mencukupi! Sisa stok: {stokTersedia}", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQty.Focus()
            txtQty.SelectAll()
            Exit Sub
        End If

        ' --- Lolos semua validasi, simpan ke variabel publik ---
        KodeTerpilih = kode
        NamaTerpilih = nama
        HargaTerpilih = harga
        QtyTerpilih = qtyInput

        ' 🔥 DEBUGGING: Tampilkan data yang akan dikirim
        MessageBox.Show($"Data terpilih:{vbCrLf}Kode: {KodeTerpilih}{vbCrLf}Nama: {NamaTerpilih}{vbCrLf}Harga: {HargaTerpilih}{vbCrLf}Qty: {QtyTerpilih}", "Debug Pilih Barang")

        ' Set hasil dialog menjadi OK, tutup form
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ' =========================================================
    ' 6. TOMBOL BATAL (sudah diatur DialogResult = Cancel)
    ' =========================================================
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        ' Tidak perlu kode, karena properti DialogResult = Cancel
    End Sub

    ' =========================================================
    ' 7. SHORTCUT: ENTER di txtQty → klik Pilih
    ' =========================================================
    Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnPilih.PerformClick()
        End If
    End Sub

    ' =========================================================
    ' 8. SHORTCUT: ENTER di txtCari → klik Cari
    ' =========================================================
    Private Sub txtCari_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCari.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnCari.PerformClick()
        End If
    End Sub
End Class