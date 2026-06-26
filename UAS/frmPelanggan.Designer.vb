<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPelanggan
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
        txtID = New MaskedTextBox()
        txtNama = New MaskedTextBox()
        txtAlamat = New MaskedTextBox()
        txtNoHP = New MaskedTextBox()
        txtCari = New MaskedTextBox()
        dgvPelanggan = New DataGridView()
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
        CType(dgvPelanggan, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtID
        ' 
        txtID.Location = New Point(85, 67)
        txtID.Name = "txtID"
        txtID.Size = New Size(200, 31)
        txtID.TabIndex = 0
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(85, 121)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(200, 31)
        txtNama.TabIndex = 1
        ' 
        ' txtAlamat
        ' 
        txtAlamat.Location = New Point(505, 118)
        txtAlamat.Name = "txtAlamat"
        txtAlamat.Size = New Size(200, 31)
        txtAlamat.TabIndex = 2
        ' 
        ' txtNoHP
        ' 
        txtNoHP.Location = New Point(505, 67)
        txtNoHP.Name = "txtNoHP"
        txtNoHP.Size = New Size(200, 31)
        txtNoHP.TabIndex = 3
        ' 
        ' txtCari
        ' 
        txtCari.Location = New Point(25, 451)
        txtCari.Name = "txtCari"
        txtCari.Size = New Size(200, 31)
        txtCari.TabIndex = 4
        ' 
        ' dgvPelanggan
        ' 
        dgvPelanggan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPelanggan.Location = New Point(25, 220)
        dgvPelanggan.Name = "dgvPelanggan"
        dgvPelanggan.RowHeadersWidth = 62
        dgvPelanggan.Size = New Size(774, 225)
        dgvPelanggan.TabIndex = 5
        ' 
        ' btnTambah
        ' 
        btnTambah.Location = New Point(25, 178)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(112, 34)
        btnTambah.TabIndex = 6
        btnTambah.Text = "Tambah"
        btnTambah.UseVisualStyleBackColor = True
        ' 
        ' btnEdit
        ' 
        btnEdit.Location = New Point(165, 178)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(112, 34)
        btnEdit.TabIndex = 7
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = True
        ' 
        ' btnHapus
        ' 
        btnHapus.Location = New Point(305, 178)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(112, 34)
        btnHapus.TabIndex = 8
        btnHapus.Text = "Hapus"
        btnHapus.UseVisualStyleBackColor = True
        ' 
        ' btnCari
        ' 
        btnCari.Location = New Point(237, 448)
        btnCari.Name = "btnCari"
        btnCari.Size = New Size(112, 34)
        btnCari.TabIndex = 9
        btnCari.Text = "Cari"
        btnCari.UseVisualStyleBackColor = True
        ' 
        ' btnClear
        ' 
        btnClear.Location = New Point(445, 178)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(112, 34)
        btnClear.TabIndex = 10
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(25, 67)
        Label1.Name = "Label1"
        Label1.Size = New Size(30, 25)
        Label1.TabIndex = 11
        Label1.Text = "ID"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(25, 124)
        Label2.Name = "Label2"
        Label2.Size = New Size(59, 25)
        Label2.TabIndex = 12
        Label2.Text = "Nama"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(435, 121)
        Label3.Name = "Label3"
        Label3.Size = New Size(68, 25)
        Label3.TabIndex = 13
        Label3.Text = "Alamat"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(435, 67)
        Label4.Name = "Label4"
        Label4.Size = New Size(69, 25)
        Label4.TabIndex = 14
        Label4.Text = "No. Hp"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(264, 9)
        Label5.Name = "Label5"
        Label5.Size = New Size(290, 45)
        Label5.TabIndex = 15
        Label5.Text = "Master Pelanggan"
        ' 
        ' frmPelanggan
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(828, 494)
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
        Controls.Add(dgvPelanggan)
        Controls.Add(txtCari)
        Controls.Add(txtNoHP)
        Controls.Add(txtAlamat)
        Controls.Add(txtNama)
        Controls.Add(txtID)
        Name = "frmPelanggan"
        Text = "Form4"
        CType(dgvPelanggan, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtID As MaskedTextBox
    Friend WithEvents txtNama As MaskedTextBox
    Friend WithEvents txtAlamat As MaskedTextBox
    Friend WithEvents txtNoHP As MaskedTextBox
    Friend WithEvents txtCari As MaskedTextBox
    Friend WithEvents dgvPelanggan As DataGridView
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
End Class
