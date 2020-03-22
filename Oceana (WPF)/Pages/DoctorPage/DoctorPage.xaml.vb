Public Class DoctorPage

    Dim ucs As New UserControl

    Private Sub ListViewMenu_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ListViewMenu.SelectionChanged

        Dim ucs As New UserControl
        Dim name As String = ListViewMenu.SelectedItem.Name()

        Select Case name
            Case "Patient"
                GridMain.Children.Clear()
                ucs = New Patients
                GridMain.Children.Add(ucs)



        End Select

    End Sub

    Private Sub DoctorPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        ucs = New Patients
        GridMain.Children.Add(ucs)
    End Sub

    Private Sub btnSignOut_Click(sender As Object, e As RoutedEventArgs) Handles btnSignOut.Click
        Dim x As New MainWindow
        x.Show()
        Me.Close()
    End Sub
End Class
