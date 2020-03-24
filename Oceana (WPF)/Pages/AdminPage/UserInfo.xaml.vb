Public Class UserInfo

    Dim UInfo As New UserInfoViewModel

    Public Sub New(ByRef _users As LoginUsers)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UInfo.Info = _users
        DataContext = UInfo
    End Sub
    Private Sub cbbUserGroup_Loaded(sender As Object, e As RoutedEventArgs) Handles cbbUserGroup.Loaded
        cbbUserGroup.Items.Add("Admin")
        cbbUserGroup.Items.Add("Doctor")
        cbbUserGroup.Items.Add("Nurse")
    End Sub

    Private Sub cbbUserGroup_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbbUserGroup.SelectionChanged
        cbbUserGroup.SelectedItem.ToString()
    End Sub

    Private Sub ValidateEmail()
        Task.Run(Sub() UInfo.Validation(NameOf(UInfo.EM), UInfo.EM, "", "Email"))
    End Sub

    Private Sub ValidateUsername()
        Task.Run(Sub() UInfo.Validation(NameOf(UInfo.UN), UInfo.UN, "", "Username"))
    End Sub

    Private Sub txtFields_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtFirstname.TextChanged, txtLastname.TextChanged, txtPassword.TextChanged
        UInfo.OnPropertyChanged("AllFieldsFilled")
    End Sub
    Private Sub txtEmail_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtEmail.TextChanged
        ValidateEmail()
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtUsername.TextChanged
        ValidateUsername()
    End Sub


End Class
