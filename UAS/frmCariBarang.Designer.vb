<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCariBarang
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
        txtCari = New MaskedTextBox()
        txtQty = New MaskedTextBox()
        btnCari = New Button()
        btnPilih = New Button()
        dgvCari = New DataGridView()
        btnBatal = New Button()
        Label2 = New Label()
        Label3 = New Label()
        CType(dgvCari, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtCari
        ' 
        txtCari.Location = New Point(55, 64)
        txtCari.Name = "txtCari"
        txtCari.Size = New Size(200, 31)
        txtCari.TabIndex = 0
        ' 
        ' txtQty
        ' 
        txtQty.Location = New Point(115, 364)
        txtQty.Name = "txtQty"
        txtQty.Size = New Size(200, 31)
        txtQty.TabIndex = 1
        ' 
        ' btnCari
        ' 
        btnCari.Location = New Point(275, 64)
        btnCari.Name = "btnCari"
        btnCari.Size = New Size(100, 34)
        btnCari.TabIndex = 2
        btnCari.Text = "Cari"
        btnCari.UseVisualStyleBackColor = True
        ' 
        ' btnPilih
        ' 
        btnPilih.Location = New Point(115, 414)
        btnPilih.Name = "btnPilih"
        btnPilih.Size = New Size(100, 34)
        btnPilih.TabIndex = 3
        btnPilih.Text = "Pilih"
        btnPilih.UseVisualStyleBackColor = True
        ' 
        ' dgvCari
        ' 
        dgvCari.Anchor = AnchorStyles.None
        dgvCari.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCari.Location = New Point(15, 114)
        dgvCari.Name = "dgvCari"
        dgvCari.ReadOnly = True
        dgvCari.RowHeadersWidth = 62
        dgvCari.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCari.Size = New Size(800, 225)
        dgvCari.TabIndex = 4
        ' 
        ' btnBatal
        ' 
        btnBatal.AccessibleRole = AccessibleRole.None
        btnBatal.Location = New Point(214, 414)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New Size(100, 34)
        btnBatal.TabIndex = 5
        btnBatal.Text = "Batal"
        btnBatal.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(55, 364)
        Label2.Name = "Label2"
        Label2.Size = New Size(41, 25)
        Label2.TabIndex = 7
        Label2.Text = "Qty"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(325, 9)
        Label3.Name = "Label3"
        Label3.Size = New Size(232, 45)
        Label3.TabIndex = 8
        Label3.Text = "Daftar Barang"
        ' 
        ' frmCariBarang
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(828, 494)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(btnBatal)
        Controls.Add(dgvCari)
        Controls.Add(btnPilih)
        Controls.Add(btnCari)
        Controls.Add(txtQty)
        Controls.Add(txtCari)
        Name = "frmCariBarang"
        Text = "Form6"
        CType(dgvCari, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtCari As MaskedTextBox
    Friend WithEvents txtQty As MaskedTextBox
    Friend WithEvents btnCari As Button
    Friend WithEvents btnPilih As Button
    Friend WithEvents dgvCari As DataGridView
    Friend WithEvents btnBatal As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
