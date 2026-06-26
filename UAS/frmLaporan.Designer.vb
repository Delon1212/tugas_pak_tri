<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLaporan
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
        Label1 = New Label()
        dtpAwal = New DateTimePicker()
        dtpAkhir = New DateTimePicker()
        Label2 = New Label()
        Label3 = New Label()
        btnTampilkan = New Button()
        dgvLaporan = New DataGridView()
        btnCetakPDF = New Button()
        Label4 = New Label()
        CType(dgvLaporan, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(237, -1)
        Label1.Name = "Label1"
        Label1.Size = New Size(296, 45)
        Label1.TabIndex = 0
        Label1.Text = "Laporan Penjualan"
        ' 
        ' dtpAwal
        ' 
        dtpAwal.Location = New Point(35, 84)
        dtpAwal.Name = "dtpAwal"
        dtpAwal.Size = New Size(300, 31)
        dtpAwal.TabIndex = 1
        ' 
        ' dtpAkhir
        ' 
        dtpAkhir.Location = New Point(365, 84)
        dtpAkhir.Name = "dtpAkhir"
        dtpAkhir.Size = New Size(300, 31)
        dtpAkhir.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(35, 55)
        Label2.Name = "Label2"
        Label2.Size = New Size(75, 25)
        Label2.TabIndex = 3
        Label2.Text = "Periode:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(365, 55)
        Label3.Name = "Label3"
        Label3.Size = New Size(37, 25)
        Label3.TabIndex = 4
        Label3.Text = "S.d"
        ' 
        ' btnTampilkan
        ' 
        btnTampilkan.Location = New Point(695, 84)
        btnTampilkan.Name = "btnTampilkan"
        btnTampilkan.Size = New Size(100, 34)
        btnTampilkan.TabIndex = 5
        btnTampilkan.Text = "Tampilkan"
        btnTampilkan.UseVisualStyleBackColor = True
        ' 
        ' dgvLaporan
        ' 
        dgvLaporan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLaporan.Location = New Point(35, 121)
        dgvLaporan.Name = "dgvLaporan"
        dgvLaporan.RowHeadersWidth = 62
        dgvLaporan.Size = New Size(760, 301)
        dgvLaporan.TabIndex = 6
        ' 
        ' btnCetakPDF
        ' 
        btnCetakPDF.Location = New Point(205, 434)
        btnCetakPDF.Name = "btnCetakPDF"
        btnCetakPDF.Size = New Size(120, 34)
        btnCetakPDF.TabIndex = 7
        btnCetakPDF.Text = "Cetak PDF"
        btnCetakPDF.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(35, 434)
        Label4.Name = "Label4"
        Label4.Size = New Size(121, 25)
        Label4.TabIndex = 8
        Label4.Text = "Tombol Cetak"
        ' 
        ' frmLaporan
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(828, 494)
        Controls.Add(Label4)
        Controls.Add(btnCetakPDF)
        Controls.Add(dgvLaporan)
        Controls.Add(btnTampilkan)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(dtpAkhir)
        Controls.Add(dtpAwal)
        Controls.Add(Label1)
        Name = "frmLaporan"
        Text = "Form7"
        CType(dgvLaporan, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dtpAwal As DateTimePicker
    Friend WithEvents dtpAkhir As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents dgvLaporan As DataGridView
    Friend WithEvents btnCetakPDF As Button
    Friend WithEvents Label4 As Label
End Class
