Imports MySql.Data.MySqlClient
Imports QuestPDF.Fluent
Imports QuestPDF.Helpers
Imports QuestPDF.Infrastructure
Imports System.IO
Imports System.Diagnostics

Public Class frmLaporan
    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Gagal terhubung ke database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim sql As String = "SELECT t.no_faktur, t.tgl_transaksi, p.nama_pelanggan, t.total " &
                                "FROM transaksi t JOIN pelanggan p ON t.id_pelanggan = p.id_pelanggan " &
                                "WHERE DATE(t.tgl_transaksi) BETWEEN @awal AND @akhir ORDER BY t.tgl_transaksi"
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@awal", dtpAwal.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@akhir", dtpAkhir.Value.ToString("yyyy-MM-dd"))

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvLaporan.DataSource = dt

            ' Atur header kolom agar rapi
            If dt.Rows.Count > 0 Then
                With dgvLaporan
                    .Columns("no_faktur").HeaderText = "No Faktur"
                    .Columns("tgl_transaksi").HeaderText = "Tanggal"
                    .Columns("nama_pelanggan").HeaderText = "Pelanggan"
                    .Columns("total").HeaderText = "Total (Rp)"
                End With
            End If

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Tidak ada data pada periode tersebut!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TutupKoneksi()
        End Try
    End Sub

    Private Sub btnCetakPDF_Click(sender As Object, e As EventArgs) Handles btnCetakPDF.Click
        ' Validasi: Apakah ada data?
        If dgvLaporan.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk dicetak. Tampilkan data terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        QuestPDF.Settings.License = LicenseType.Community

        Dim doc = Document.Create(
            Sub(container)
                container.Page(
                    Sub(page)
                        ' --- Ukuran & Margin ---
                        page.Size(PageSizes.A4)
                        page.Margin(2, Unit.Centimetre)
                        page.PageColor(Colors.White)

                        page.Header().
                            Text("LAPORAN PENJUALAN TOKO MAJU JAYA").
                            Bold().
                            FontSize(20).
                            FontColor(Colors.Blue.Darken2).
                            AlignCenter()

                        page.Content().
                            PaddingVertical(1, Unit.Centimetre).
                            Column(
                                Sub(col)
                                    col.Spacing(10)

                                    ' --- Informasi Periode ---
                                    col.Item().
                                        Text($"Periode: {dtpAwal.Value:dd MMMM yyyy} s.d {dtpAkhir.Value:dd MMMM yyyy}").
                                        FontSize(12).
                                        AlignCenter()

                                    ' --- Tanggal Cetak ---
                                    col.Item().
                                        Text($"Tanggal Cetak: {DateTime.Now:dd MMM yyyy HH:mm}").
                                        FontSize(10).
                                        FontColor(Colors.Grey.Darken1).
                                        AlignCenter()

                                    ' --- TABEL DATA PENJUALAN ---
                                    col.Item().
                                        Table(
                                            Sub(table)
                                                ' 1. Definisi Lebar Kolom
                                                table.ColumnsDefinition(
                                                    Sub(cols)
                                                        cols.RelativeColumn(1)   ' No Faktur
                                                        cols.RelativeColumn(2)   ' Tanggal
                                                        cols.RelativeColumn(3)   ' Pelanggan
                                                        cols.RelativeColumn(2)   ' Total
                                                    End Sub)

                                                ' 2. Header Tabel (Judul Kolom)
                                                table.Header(
                                                    Sub(header)
                                                        header.Cell().Text("No Faktur").Bold().FontSize(10)
                                                        header.Cell().Text("Tanggal").Bold().FontSize(10)
                                                        header.Cell().Text("Pelanggan").Bold().FontSize(10)
                                                        header.Cell().Text("Total (Rp)").Bold().FontSize(10).AlignRight()
                                                    End Sub)

                                                ' 3. Isi Data dari DataGridView
                                                For Each row As DataGridViewRow In dgvLaporan.Rows
                                                    If row.IsNewRow Then Continue For

                                                    Dim noFaktur As String = Convert.ToString(row.Cells("no_faktur").Value)
                                                    Dim tgl As String = Convert.ToDateTime(row.Cells("tgl_transaksi").Value).ToString("dd/MM/yyyy")
                                                    Dim pelanggan As String = Convert.ToString(row.Cells("nama_pelanggan").Value)
                                                    Dim total As String = Convert.ToInt32(row.Cells("total").Value).ToString("N0")

                                                    table.Cell().Text(noFaktur).FontSize(9)
                                                    table.Cell().Text(tgl).FontSize(9)
                                                    table.Cell().Text(pelanggan).FontSize(9)
                                                    table.Cell().Text(total).FontSize(9).AlignRight()
                                                Next
                                            End Sub)
                                End Sub)
                        page.Footer().
                            AlignCenter().
                            Text(
                                Sub(txt)
                                    txt.Span("Halaman ")
                                    txt.CurrentPageNumber()
                                End Sub)
                    End Sub)
            End Sub)
        Using sfd As New SaveFileDialog()
            sfd.Filter = "PDF File|*.pdf"
            sfd.FileName = $"Laporan_Penjualan_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    ' Simpan PDF
                    doc.GeneratePdf(sfd.FileName)
                    MessageBox.Show($"Laporan PDF berhasil disimpan di:{Environment.NewLine}{sfd.FileName}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' 🔥 Buka PDF otomatis dengan aplikasi default (AMAN)
                    Try
                        Dim psi As New ProcessStartInfo()
                        psi.FileName = sfd.FileName
                        psi.UseShellExecute = True   ' ← PERBAIKAN UTAMA
                        Process.Start(psi)
                    Catch ex As Exception
                        ' Jika gagal membuka, abaikan saja (PDF tetap tersimpan)
                        MessageBox.Show("PDF berhasil disimpan, tetapi tidak bisa dibuka otomatis. Buka file secara manual.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try

                Catch ex As Exception
                    MessageBox.Show("Error saat menyimpan PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub
End Class