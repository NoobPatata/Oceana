Imports MaterialDesignThemes.Wpf
Public Class DoctorPage

    Dim ucs As New UserControl
    Dim _doc As Doctor
    Dim msgQ As New SnackbarMessageQueue(TimeSpan.FromSeconds(3))


    Public Sub New(ByRef info As Doctor)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _doc = info
        MySnackbar.MessageQueue = msgQ
    End Sub

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
        lblWelcome.Content = _doc.FirstName.ToUpper
        ucs = New Patients
        GridMain.Children.Add(ucs)
    End Sub

    Private Sub btnSignOut_Click(sender As Object, e As RoutedEventArgs) Handles btnSignOut.Click
        Dim x As New MainWindow
        x.Show()
        Me.Close()
    End Sub

    Private Async Sub btnSetting_Click(sender As Object, e As RoutedEventArgs) Handles btnSetting.Click

        Dim result As Boolean = Await DialogHost.Show(New DocSettings(_doc), "MainDialog")
        If result = True Then
            If gVars.db.UpdateDoctor(_doc) > 0 And gVars.db.UpdateDoctorContact(_doc) > 0 Then
                msgQ.Enqueue("Your information has been successfully updated!")
            Else
                msgQ.Enqueue("Failed to update your information !")
            End If
        End If

    End Sub
End Class
