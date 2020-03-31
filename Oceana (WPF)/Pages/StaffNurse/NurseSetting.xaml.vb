Public Class NurseSetting


    Dim ViewModel As New NurseSettingViewModel
    Public Sub New(ByRef info As Nurse)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ViewModel.info = info
        DataContext = ViewModel
    End Sub

    Private Sub ValidateContact()
        Task.Run(Sub() ViewModel.Validation(NameOf(ViewModel.CN), ViewModel.CN, "", "Contact"))
    End Sub

    Private Sub ValidateIdentification()
        Task.Run(Sub() ViewModel.Validation(NameOf(ViewModel.ID), ViewModel.ID, "", "Identification"))
    End Sub

    Private Sub ValidateAddress()
        Task.Run(Sub() ViewModel.Validation(NameOf(ViewModel.AD), ViewModel.AD, "", "Address"))
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtAddress.TextChanged
        ValidateAddress()
    End Sub

    Private Sub txtContact_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtContact.TextChanged
        ValidateContact()
    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtID.TextChanged
        ValidateIdentification()
    End Sub

    Private Sub txtFields_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtContact.TextChanged, txtAddress.TextChanged, txtID.TextChanged
        ViewModel.OnPropertyChanged("AllFieldsFilled")
    End Sub

End Class
