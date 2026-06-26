<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBarang
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
        txtKode = New TextBox()
        txtNama = New TextBox()
        txtHargaBeli = New TextBox()
        txtHargaJual = New TextBox()
        txtStok = New TextBox()
        txtCari = New TextBox()
        dgvBarang = New DataGridView()
        btnTambah = New Button()
        btnEdit = New Button()
        btnHapus = New Button()
        btnCari = New Button()
        btnClear = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        CType(dgvBarang, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtKode
        ' 
        txtKode.Location = New Point(95, 54)
        txtKode.Name = "txtKode"
        txtKode.Size = New Size(150, 31)
        txtKode.TabIndex = 0
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(95, 94)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(150, 31)
        txtNama.TabIndex = 1
        ' 
        ' txtHargaBeli
        ' 
        txtHargaBeli.Location = New Point(473, 54)
        txtHargaBeli.Name = "txtHargaBeli"
        txtHargaBeli.Size = New Size(150, 31)
        txtHargaBeli.TabIndex = 2
        ' 
        ' txtHargaJual
        ' 
        txtHargaJual.Location = New Point(473, 134)
        txtHargaJual.Name = "txtHargaJual"
        txtHargaJual.Size = New Size(150, 31)
        txtHargaJual.TabIndex = 3
        ' 
        ' txtStok
        ' 
        txtStok.Location = New Point(94, 134)
        txtStok.Name = "txtStok"
        txtStok.Size = New Size(150, 31)
        txtStok.TabIndex = 4
        ' 
        ' txtCari
        ' 
        txtCari.Location = New Point(35, 225)
        txtCari.Name = "txtCari"
        txtCari.Size = New Size(150, 31)
        txtCari.TabIndex = 5
        ' 
        ' dgvBarang
        ' 
        dgvBarang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBarang.Location = New Point(35, 259)
        dgvBarang.Name = "dgvBarang"
        dgvBarang.RowHeadersWidth = 62
        dgvBarang.Size = New Size(758, 223)
        dgvBarang.TabIndex = 6
        ' 
        ' btnTambah
        ' 
        btnTambah.Location = New Point(35, 184)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(100, 34)
        btnTambah.TabIndex = 7
        btnTambah.Text = "Tambah"
        btnTambah.UseVisualStyleBackColor = True
        ' 
        ' btnEdit
        ' 
        btnEdit.Location = New Point(155, 184)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(100, 34)
        btnEdit.TabIndex = 8
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = True
        ' 
        ' btnHapus
        ' 
        btnHapus.Location = New Point(285, 184)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(100, 34)
        btnHapus.TabIndex = 9
        btnHapus.Text = "Hapus"
        btnHapus.UseVisualStyleBackColor = True
        ' 
        ' btnCari
        ' 
        btnCari.Location = New Point(204, 225)
        btnCari.Name = "btnCari"
        btnCari.Size = New Size(112, 34)
        btnCari.TabIndex = 10
        btnCari.Text = "Cari"
        btnCari.UseVisualStyleBackColor = True
        ' 
        ' btnClear
        ' 
        btnClear.Location = New Point(415, 184)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(100, 34)
        btnClear.TabIndex = 11
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(35, 54)
        Label1.Name = "Label1"
        Label1.Size = New Size(53, 25)
        Label1.TabIndex = 12
        Label1.Text = "Kode"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(35, 94)
        Label2.Name = "Label2"
        Label2.Size = New Size(59, 25)
        Label2.TabIndex = 13
        Label2.Text = "Nama"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(348, 54)
        Label3.Name = "Label3"
        Label3.Size = New Size(92, 25)
        Label3.TabIndex = 14
        Label3.Text = "Harga Beli"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(348, 134)
        Label4.Name = "Label4"
        Label4.Size = New Size(94, 25)
        Label4.TabIndex = 15
        Label4.Text = "Harga Jual"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(35, 134)
        Label5.Name = "Label5"
        Label5.Size = New Size(47, 25)
        Label5.TabIndex = 16
        Label5.Text = "Stok"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(227, -3)
        Label6.Name = "Label6"
        Label6.Size = New Size(319, 45)
        Label6.TabIndex = 17
        Label6.Text = "Master Data Barang"
        ' 
        ' frmBarang
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(828, 494)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnClear)
        Controls.Add(btnCari)
        Controls.Add(btnHapus)
        Controls.Add(btnEdit)
        Controls.Add(btnTambah)
        Controls.Add(dgvBarang)
        Controls.Add(txtCari)
        Controls.Add(txtStok)
        Controls.Add(txtHargaJual)
        Controls.Add(txtHargaBeli)
        Controls.Add(txtNama)
        Controls.Add(txtKode)
        Name = "frmBarang"
        Text = "Form3"
        CType(dgvBarang, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtKode As TextBox
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtHargaBeli As TextBox
    Friend WithEvents txtHargaJual As TextBox
    Friend WithEvents txtStok As TextBox
    Friend WithEvents txtCari As TextBox
    Friend WithEvents dgvBarang As DataGridView
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnCari As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
