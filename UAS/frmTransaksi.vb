Imports MySql.Data.MySqlClient

Public Class frmTransaksi
    Private total As Integer = 0

    Private Sub frmTransaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNoFaktur.Text = GenerateNoFaktur()
        LoadPelanggan()
        dgvDetail.Columns.Clear()
        dgvDetail.Columns.Add("Kode", "Kode Barang")
        dgvDetail.Columns.Add("Nama", "Nama Barang")
        dgvDetail.Columns.Add("Qty", "Qty")
        dgvDetail.Columns.Add("Harga", "Harga")
        dgvDetail.Columns.Add("Subtotal", "Subtotal")
        dgvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        ' 🔥 PASTIKAN TIDAK ADA BARIS KOSONG OTOMATIS
        dgvDetail.AllowUserToAddRows = False
        txtTotal.Text = "0"
        txtBayar.Text = "0"
        txtKembalian.Text = "0"
    End Sub

    Private Sub LoadPelanggan()
        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim da As New MySqlDataAdapter("SELECT id_pelanggan, nama_pelanggan FROM pelanggan ORDER BY nama_pelanggan", conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            cboPelanggan.DataSource = dt
            cboPelanggan.DisplayMember = "nama_pelanggan"
            cboPelanggan.ValueMember = "id_pelanggan"
        Catch ex As Exception
            MessageBox.Show("Error loading pelanggan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try
    End Sub

    Private Sub btnTambahBarang_Click(sender As Object, e As EventArgs) Handles btnTambahBarang.Click
        Dim frmCari As New frmCariBarang()
        If frmCari.ShowDialog() = DialogResult.OK Then
            TambahItemKeGrid(frmCari.KodeTerpilih, frmCari.NamaTerpilih, frmCari.HargaTerpilih, frmCari.QtyTerpilih)
        End If
    End Sub

    Private Sub TambahItemKeGrid(kode As String, nama As String, harga As Integer, qty As Integer)
        If String.IsNullOrWhiteSpace(kode) Then
            MessageBox.Show("Kode barang tidak valid! Silakan pilih ulang.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If qty <= 0 Then
            MessageBox.Show("Qty harus lebih dari 0!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Cek apakah kode sudah ada di grid
        For Each row As DataGridViewRow In dgvDetail.Rows
            If Convert.ToString(row.Cells("Kode").Value) = kode Then
                Dim qtyLama As Integer = Val(row.Cells("Qty").Value)
                row.Cells("Qty").Value = qtyLama + qty
                row.Cells("Subtotal").Value = (qtyLama + qty) * harga
                HitungTotal()
                Return
            End If
        Next

        ' Tambahkan baris baru
        dgvDetail.Rows.Add(kode, nama, qty, harga, qty * harga)
        HitungTotal()
    End Sub

    ' =========================================================
    ' 🔥 PERBAIKAN: HITUNG TOTAL DENGAN MELEWATI BARIS KOSONG
    ' =========================================================
    Private Sub HitungTotal()
        total = 0
        For Each row As DataGridViewRow In dgvDetail.Rows
            ' Lewati jika baris kosong atau belum diisi
            If row.IsNewRow Then Continue For
            Dim nilaiSubtotal As String = Convert.ToString(row.Cells("Subtotal").Value)
            If Not String.IsNullOrEmpty(nilaiSubtotal) Then
                total += Val(nilaiSubtotal)
            End If
        Next
        txtTotal.Text = total.ToString("N0")
        HitungKembalian()
    End Sub

    Private Sub txtBayar_TextChanged(sender As Object, e As EventArgs) Handles txtBayar.TextChanged
        HitungKembalian()
    End Sub

    Private Sub HitungKembalian()
        If String.IsNullOrWhiteSpace(txtBayar.Text) Then txtBayar.Text = "0"
        Dim bayar As Integer = Val(txtBayar.Text)
        Dim kembalian As Integer = If(bayar >= total, bayar - total, 0)
        txtKembalian.Text = kembalian.ToString("N0")
    End Sub

    Private Sub btnHapusItem_Click(sender As Object, e As EventArgs) Handles btnHapusItem.Click
        If dgvDetail.SelectedRows.Count > 0 Then
            dgvDetail.Rows.Remove(dgvDetail.SelectedRows(0))
            HitungTotal()
        Else
            MessageBox.Show("Pilih baris yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        ' Validasi 1: Apakah ada barang?
        If dgvDetail.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada barang dalam transaksi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 🔥 Validasi tambahan: Cek apakah ada baris kosong
        Dim barisKosong As Boolean = False
        For Each row As DataGridViewRow In dgvDetail.Rows
            If row.IsNewRow Then Continue For
            Dim kode As String = Convert.ToString(row.Cells("Kode").Value)
            If String.IsNullOrWhiteSpace(kode) Then
                barisKosong = True
                Exit For
            End If
        Next
        If barisKosong Then
            MessageBox.Show("Ada baris kosong di daftar barang! Hapus baris kosong tersebut.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validasi 2: Pelanggan dipilih?
        If cboPelanggan.SelectedValue Is Nothing OrElse String.IsNullOrWhiteSpace(cboPelanggan.SelectedValue.ToString()) Then
            MessageBox.Show("Pilih pelanggan terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPelanggan.Focus()
            Exit Sub
        End If

        ' Validasi 3: Bayar cukup?
        Dim bayar As Integer = Val(txtBayar.Text)
        If bayar < total Then
            MessageBox.Show("Uang bayar kurang! Total: " & total.ToString("N0"), "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBayar.Focus()
            txtBayar.SelectAll()
            Exit Sub
        End If

        ' DEBUGGING (Opsional, bisa dihapus setelah testing)
        Dim debugMsg As String = ""
        debugMsg &= "No Faktur: " & txtNoFaktur.Text & vbCrLf
        debugMsg &= "Pelanggan ID: " & cboPelanggan.SelectedValue.ToString() & vbCrLf
        debugMsg &= "Total: " & total.ToString() & vbCrLf
        debugMsg &= "Bayar: " & bayar.ToString() & vbCrLf
        debugMsg &= "Kembalian: " & txtKembalian.Text & vbCrLf
        debugMsg &= "Jumlah Item: " & dgvDetail.Rows.Count & vbCrLf & vbCrLf & "--- Detail Item ---" & vbCrLf
        For Each row As DataGridViewRow In dgvDetail.Rows
            If row.IsNewRow Then Continue For
            Dim kode As String = Convert.ToString(row.Cells("Kode").Value)
            Dim qty As String = Convert.ToString(row.Cells("Qty").Value)
            Dim harga As String = Convert.ToString(row.Cells("Harga").Value)
            debugMsg &= "Kode: " & kode & ", Qty: " & qty & ", Harga: " & harga & vbCrLf
        Next
        MessageBox.Show(debugMsg, "Debug Data Transaksi", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' PROSES SIMPAN
        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim trans As MySqlTransaction = conn.BeginTransaction()

        Try
            ' Header
            Dim sqlHeader As String = "INSERT INTO transaksi (no_faktur, tgl_transaksi, id_pelanggan, total, bayar, kembalian) VALUES (@no, @tgl, @pel, @tot, @bay, @kem)"
            Dim cmdHeader As New MySqlCommand(sqlHeader, conn, trans)
            cmdHeader.Parameters.AddWithValue("@no", txtNoFaktur.Text)
            cmdHeader.Parameters.AddWithValue("@tgl", DateTime.Now)
            cmdHeader.Parameters.AddWithValue("@pel", cboPelanggan.SelectedValue.ToString())
            cmdHeader.Parameters.AddWithValue("@tot", total)
            cmdHeader.Parameters.AddWithValue("@bay", bayar)
            cmdHeader.Parameters.AddWithValue("@kem", Val(txtKembalian.Text))
            cmdHeader.ExecuteNonQuery()

            ' Detail & Update Stok
            For Each row As DataGridViewRow In dgvDetail.Rows
                If row.IsNewRow Then Continue For
                Dim kode As String = Convert.ToString(row.Cells("Kode").Value)
                ' 🔥 Lewati jika kode kosong (sudah divalidasi di atas, tapi untuk amannya)
                If String.IsNullOrWhiteSpace(kode) Then Continue For

                Dim qty As Integer = Val(row.Cells("Qty").Value)
                Dim harga As Integer = Val(row.Cells("Harga").Value)
                Dim subTotal As Integer = qty * harga

                ' Insert Detail
                Dim sqlDetail As String = "INSERT INTO detail_transaksi (no_faktur, kode_barang, qty, harga_satuan, subtotal) VALUES (@no, @kd, @q, @h, @sub)"
                Dim cmdDetail As New MySqlCommand(sqlDetail, conn, trans)
                cmdDetail.Parameters.AddWithValue("@no", txtNoFaktur.Text)
                cmdDetail.Parameters.AddWithValue("@kd", kode)
                cmdDetail.Parameters.AddWithValue("@q", qty)
                cmdDetail.Parameters.AddWithValue("@h", harga)
                cmdDetail.Parameters.AddWithValue("@sub", subTotal)
                cmdDetail.ExecuteNonQuery()

                ' Update Stok
                Dim sqlStok As String = "UPDATE barang SET stok = stok - @q WHERE kode_barang = @kd"
                Dim cmdStok As New MySqlCommand(sqlStok, conn, trans)
                cmdStok.Parameters.AddWithValue("@q", qty)
                cmdStok.Parameters.AddWithValue("@kd", kode)
                cmdStok.ExecuteNonQuery()
            Next

            trans.Commit()
            MessageBox.Show("Transaksi berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TutupKoneksi()
            BersihkanTransaksi()

        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TutupKoneksi()
        End Try
    End Sub

    Private Sub BersihkanTransaksi()
        txtNoFaktur.Text = GenerateNoFaktur()
        dgvDetail.Rows.Clear()
        txtTotal.Text = "0"
        txtBayar.Text = "0"
        txtKembalian.Text = "0"
        total = 0
        cboPelanggan.SelectedIndex = -1
        txtBayar.Focus()
    End Sub

    Private Sub txtBayar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBayar.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSimpan.PerformClick()
        End If
    End Sub

    Private Sub txtNoFaktur_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoFaktur.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboPelanggan.Focus()
        End If
    End Sub

    Private Sub txtBayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBayar.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
End Class