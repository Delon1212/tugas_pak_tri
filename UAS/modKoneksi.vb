Imports MySql.Data.MySqlClient

Module modKoneksi
    Public conn As MySqlConnection

    Public Sub BukaKoneksi()
        conn = New MySqlConnection("server=localhost;database=toko_maju_jaya;uid=root;pwd=;")
        Try
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Koneksi gagal: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub TutupKoneksi()
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
            conn.Dispose()
        End If
    End Sub
    Public Function GenerateNoFaktur() As String
        BukaKoneksi()
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            ' Fallback jika koneksi gagal
            Return "TRX" & DateTime.Now.ToString("yyyyMMdd") & "001"
        End If

        Try
            Dim tgl As String = DateTime.Now.ToString("yyyyMMdd")
            Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM transaksi WHERE no_faktur LIKE @awal", conn)
            cmd.Parameters.AddWithValue("@awal", "TRX" & tgl & "%")
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar()) + 1
            TutupKoneksi()
            Return "TRX" & tgl & count.ToString("D3")
        Catch ex As Exception
            TutupKoneksi()
            ' Fallback jika query error
            Return "TRX" & DateTime.Now.ToString("yyyyMMdd") & "001"
        End Try
    End Function
End Module