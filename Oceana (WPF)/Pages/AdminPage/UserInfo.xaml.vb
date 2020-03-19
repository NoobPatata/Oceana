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
End Class
