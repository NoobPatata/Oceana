Imports MaterialDesignThemes.Wpf
Imports System.Data.OleDb
Class MainWindow

    Dim msgQ As New SnackbarMessageQueue(TimeSpan.FromSeconds(3))
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        msgQ = MySnackbar.MessageQueue
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As RoutedEventArgs) Handles btnLogin.Click

        Dim dbProvider As String = "PROVIDER= Microsoft.JET.OLEDB.4.0;"
        Dim dbSource As String = "Data Source = Oceana.mdb"
        Dim ConnectionString As String = dbProvider & dbSource

        Using conn As New OleDbConnection(ConnectionString)

            Dim loginQuery As String =
                "SELECT * FROM LoginUser WHERE Username = @User AND Password = @Password"
            Dim cmd As New OleDbCommand(loginQuery, conn)
            cmd.Parameters.AddWithValue("@User", txtUsername.Text)
            cmd.Parameters.AddWithValue("@Password", txtPassword.Password)
            conn.Open()
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    Select Case reader("UserGroup")

                        Case "Admin"
                            Dim x As New AdminPage
                            x.Show()
                            Me.Hide()

                        Case "Doctor"
                            Dim x As New DoctorPage
                            x.Show()
                            Me.Close()

                        Case "Nurse"
                            Dim x As New StaffNurse
                            x.Show()
                            Me.Close()

                    End Select
                End While
            Else
                msgQ.Enqueue("Username or Password incorrect!")
            End If
            conn.Close()
        End Using

    End Sub
End Class
