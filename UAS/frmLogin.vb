Imports MySql.Data.MySqlClient

Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Clear()
        txtPassword.Clear()
        txtPassword.PasswordChar = "*"c
        lblError.Visible = False
        txtUsername.Focus()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Exit Sub
        End If

        BukaKoneksi()
        Dim query As String = "SELECT role FROM user WHERE username=@usr AND password=MD5(@pwd)"
        Dim cmd As New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@usr", txtUsername.Text.Trim())
        cmd.Parameters.AddWithValue("@pwd", txtPassword.Text.Trim())

        Try
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                Dim role As String = reader("role").ToString()
                reader.Close()
                TutupKoneksi()
                Dim menu As New frmMenuUtama(role)
                menu.Show()
                Me.Hide()
            Else
                reader.Close()
                TutupKoneksi()
                lblError.Text = "Username atau Password salah!"
                lblError.Visible = True
                txtPassword.Clear()
                txtPassword.Focus()
            End If
        Catch ex As Exception
            TutupKoneksi()
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        If MessageBox.Show("Yakin keluar?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then btnLogin.PerformClick()
    End Sub
End Class