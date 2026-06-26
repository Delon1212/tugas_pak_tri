Public Class frmMenuUtama
    Public Role As String

    Public Sub New(role As String)
        InitializeComponent()
        Me.Role = role
    End Sub

    Private Sub frmMenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Role = "kasir" Then
            MasterBarangToolStripMenuItem.Enabled = False
            MasterPelangganToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub BukaFormChild(form As Form)
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub MasterBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterBarangToolStripMenuItem.Click
        BukaFormChild(New frmBarang())
    End Sub

    Private Sub MasterPelangganToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterPelangganToolStripMenuItem.Click
        BukaFormChild(New frmPelanggan())
    End Sub

    Private Sub TransaksiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransaksiToolStripMenuItem.Click
        BukaFormChild(New frmTransaksi())
    End Sub

    Private Sub LaporanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanToolStripMenuItem.Click
        BukaFormChild(New frmLaporan())
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
        frmLogin.Show()
    End Sub
End Class