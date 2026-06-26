<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransaksi
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        cboPelanggan = New ComboBox()
        txtNoFaktur = New MaskedTextBox()
        dgvDetail = New DataGridView()
        txtTotal = New TextBox()
        txtBayar = New TextBox()
        txtKembalian = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        btnTambahBarang = New Button()
        btnHapusItem = New Button()
        btnSimpan = New Button()
        Label5 = New Label()
        Label6 = New Label()
        CType(dgvDetail, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cboPelanggan
        ' 
        cboPelanggan.DropDownStyle = ComboBoxStyle.DropDownList
        cboPelanggan.FormattingEnabled = True
        cboPelanggan.Location = New Point(155, 124)
        cboPelanggan.Name = "cboPelanggan"
        cboPelanggan.Size = New Size(200, 33)
        cboPelanggan.TabIndex = 0
        ' 
        ' txtNoFaktur
        ' 
        txtNoFaktur.BackColor = SystemColors.Window
        txtNoFaktur.Location = New Point(155, 84)
        txtNoFaktur.Name = "txtNoFaktur"
        txtNoFaktur.ReadOnly = True
        txtNoFaktur.Size = New Size(200, 31)
        txtNoFaktur.TabIndex = 1
        ' 
        ' dgvDetail
        ' 
        dgvDetail.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDetail.Location = New Point(12, 173)
        dgvDetail.Name = "dgvDetail"
        dgvDetail.RowHeadersWidth = 62
        dgvDetail.Size = New Size(804, 225)
        dgvDetail.TabIndex = 2
        ' 
        ' txtTotal
        ' 
        txtTotal.BackColor = SystemColors.ControlLight
        txtTotal.Location = New Point(335, 404)
        txtTotal.Name = "txtTotal"
        txtTotal.ReadOnly = True
        txtTotal.Size = New Size(180, 31)
        txtTotal.TabIndex = 3
        txtTotal.TextAlign = HorizontalAlignment.Right
        ' 
        ' txtBayar
        ' 
        txtBayar.Location = New Point(97, 404)
        txtBayar.Name = "txtBayar"
        txtBayar.Size = New Size(180, 31)
        txtBayar.TabIndex = 4
        txtBayar.TextAlign = HorizontalAlignment.Right
        ' 
        ' txtKembalian
        ' 
        txtKembalian.BackColor = SystemColors.ControlLight
        txtKembalian.Location = New Point(615, 404)
        txtKembalian.Name = "txtKembalian"
        txtKembalian.ReadOnly = True
        txtKembalian.Size = New Size(180, 31)
        txtKembalian.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(21, 84)
        Label1.Name = "Label1"
        Label1.Size = New Size(89, 25)
        Label1.TabIndex = 6
        Label1.Text = "No Faktur"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(24, 124)
        Label2.Name = "Label2"
        Label2.Size = New Size(94, 25)
        Label2.TabIndex = 7
        Label2.Text = "Pelanggan"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(285, 404)
        Label3.Name = "Label3"
        Label3.Size = New Size(49, 25)
        Label3.TabIndex = 8
        Label3.Text = "Total"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(35, 404)
        Label4.Name = "Label4"
        Label4.Size = New Size(55, 25)
        Label4.TabIndex = 9
        Label4.Text = "Bayar"
        ' 
        ' btnTambahBarang
        ' 
        btnTambahBarang.Location = New Point(155, 444)
        btnTambahBarang.Name = "btnTambahBarang"
        btnTambahBarang.Size = New Size(100, 34)
        btnTambahBarang.TabIndex = 10
        btnTambahBarang.Text = "+ Tambah Barang"
        btnTambahBarang.UseVisualStyleBackColor = True
        ' 
        ' btnHapusItem
        ' 
        btnHapusItem.Location = New Point(35, 444)
        btnHapusItem.Name = "btnHapusItem"
        btnHapusItem.Size = New Size(100, 34)
        btnHapusItem.TabIndex = 11
        btnHapusItem.Text = "Hapus Item"
        btnHapusItem.UseVisualStyleBackColor = True
        ' 
        ' btnSimpan
        ' 
        btnSimpan.Location = New Point(275, 444)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(100, 34)
        btnSimpan.TabIndex = 12
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(515, 404)
        Label5.Name = "Label5"
        Label5.Size = New Size(94, 25)
        Label5.TabIndex = 13
        Label5.Text = "Kembalian"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.Black
        Label6.Location = New Point(320, 1)
        Label6.Name = "Label6"
        Label6.Size = New Size(158, 45)
        Label6.TabIndex = 14
        Label6.Text = "Transaksi"
        ' 
        ' frmTransaksi
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(828, 494)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(btnSimpan)
        Controls.Add(btnHapusItem)
        Controls.Add(btnTambahBarang)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtKembalian)
        Controls.Add(txtBayar)
        Controls.Add(txtTotal)
        Controls.Add(dgvDetail)
        Controls.Add(txtNoFaktur)
        Controls.Add(cboPelanggan)
        Name = "frmTransaksi"
        Text = "Form5"
        CType(dgvDetail, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cboPelanggan As ComboBox
    Friend WithEvents txtNoFaktur As MaskedTextBox
    Friend WithEvents dgvDetail As DataGridView
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents txtBayar As TextBox
    Friend WithEvents txtKembalian As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnTambahBarang As Button
    Friend WithEvents btnHapusItem As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
