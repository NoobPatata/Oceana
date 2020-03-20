
Public Class AddUser

    Dim AddVM As New AddUserViewModel

    Public Sub New(ByRef newUser As LoginUsers)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddVM.Add = newUser
        DataContext = AddVM
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
