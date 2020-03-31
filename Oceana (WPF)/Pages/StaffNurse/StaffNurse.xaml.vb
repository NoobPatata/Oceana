Imports MaterialDesignThemes.Wpf
Public Class StaffNurse

    Dim ucs As New UserControl
    Dim _nurse As Nurse
    Dim msgQ As New SnackbarMessageQueue(TimeSpan.FromSeconds(3))

    Public Sub New(info As Nurse)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _nurse = info
        MySnackbar.MessageQueue = msgQ

    End Sub

    Private Sub ListViewMenu_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ListViewMenu.SelectionChanged

        Dim name As String = ListViewMenu.SelectedItem.Name()

        Select Case name
            Case "Patient"
                GridMain.Children.Clear()
                ucs = New Nurse_Patient
                GridMain.Children.Add(ucs)

            Case "Billing"
                GridMain.Children.Clear()
                ucs = New BillingTransition
                GridMain.Children.Add(ucs)


        End Select
    End Sub

    Private Sub btnSignOut_Click(sender As Object, e As RoutedEventArgs) Handles btnSignOut.Click
        Dim x As New MainWindow
        x.Show()
        Me.Close()
    End Sub

    Private Sub StaffNurse_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        lblWelcome.Content = _nurse.FirstName.ToUpper
        ucs = New Nurse_Patient
        GridMain.Children.Add(ucs)
    End Sub

    Private Async Sub btnSetting_Click(sender As Object, e As RoutedEventArgs) Handles btnSetting.Click

        Dim result As Boolean = Await DialogHost.Show(New NurseSetting(_nurse), "MainDialog")
        If result = True Then
            If gVars.db.UpdateNurse(_nurse) > 0 And gVars.db.UpdateNurseContact(_nurse) > 0 Then
                msgQ.Enqueue("Your information has been successfully updated!")
            Else
                msgQ.Enqueue("Failed to update your information !")
            End If
        End If

    End Sub

End Class
