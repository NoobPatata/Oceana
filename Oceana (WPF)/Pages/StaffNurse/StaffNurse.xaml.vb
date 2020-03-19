Public Class StaffNurse

    Dim ucs As New UserControl

    Private Sub ListViewMenu_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ListViewMenu.SelectionChanged

        Dim name As String = ListViewMenu.SelectedItem.Name()

        Select Case name
            Case "Patient"
                GridMain.Children.Clear()
                ucs = New Nurse_Patient
                GridMain.Children.Add(ucs)

            Case "Billing"
                GridMain.Children.Clear()


        End Select
    End Sub

    Private Sub btnSignOut_Click(sender As Object, e As RoutedEventArgs) Handles btnSignOut.Click
        Dim x As New MainWindow
        x.Show()
        Me.Close()
    End Sub

    Private Sub StaffNurse_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        ucs = New Nurse_Patient
        GridMain.Children.Add(ucs)
    End Sub
End Class
