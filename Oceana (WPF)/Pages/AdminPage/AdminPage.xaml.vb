Imports MaterialDesignThemes.Wpf
Public Class AdminPage

    Dim _users As ObserveUser
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _users = Me.Resources("users")
        refreshUsers()


    End Sub

    Private Async Sub btnAdd_Click(sender As Object, e As RoutedEventArgs) Handles btnAdd.Click
        Dim newUser As LoginUsers = New LoginUsers()
        Dim result As Boolean = Await DialogHost.Show(New AddUser(newUser), "RootDialog")
        If result = True Then
            If (gVars.Admin.InsertNewUser(newUser) > 0 And gVars.Admin.InsertNewDoctor(newUser) > 0 ) Then
                MsgBox("Success! New user (" + newUser.Email + ") successfully created!")

            Else
                MsgBox("Failure! Failed to create user (" + newUser.Email + ")!")
            End If
        End If

        refreshUsers()
    End Sub

    'remove the users selected in the datagrid
    Private Sub btnRemove_Click(sender As Object, e As RoutedEventArgs) Handles btnRemove.Click
        If (dgUsers.SelectedIndex = -1) Then
            Return
        End If
        Dim selectedUsers As List(Of LoginUsers) = Converter.SelectedItemsToListOfUsers(dgUsers.SelectedItems)
        If gVars.Admin.RemoveUsers(selectedUsers) > 0 Then
            MsgBox("Success! " + selectedUsers.Count.ToString + " users removed!")
        Else
            MsgBox("Failure! " + selectedUsers.Count.ToString + "users failed to be removed!")
        End If
        refreshUsers()
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As RoutedEventArgs) Handles btnEdit.Click
        If dgUsers.SelectedIndex = -1 Then
            Return
        End If
        Dim selecteduser As LoginUsers = New LoginUsers(dgUsers.SelectedValue)
        Dim result As Boolean = Await DialogHost.Show(New UserInfo(selecteduser), "RootDialog")
        If result = True Then
            If gVars.Admin.UpdateUser(selecteduser) > 0 Then
                MsgBox(selecteduser.Email + " has been successfully updated!")
            Else
                MsgBox("Failed to update " + selecteduser.Email + " !")
            End If
        End If
        refreshUsers()
    End Sub

    Private Sub btnSignOut_Click(sender As Object, e As RoutedEventArgs) Handles btnSignOut.Click
        Dim x As New MainWindow
        x.Show()
        Me.Close()
    End Sub



    Private Sub btnRefresh_Click(sender As Object, e As RoutedEventArgs) Handles btnRefresh.Click
        refreshUsers()
    End Sub

    'clear the datagrid and add re-add the items in it
    Public Sub refreshUsers()
        _users.Clear()
        For Each user As LoginUsers In gVars.Admin.GetAllUsers()
            _users.Add(user)
        Next
    End Sub

    'filter the datagrid 
    Public Sub CollectionViewSource_Filter(sender As Object, e As FilterEventArgs)
        Dim u As LoginUsers = e.Item
        If u IsNot Nothing Then
            If (Not String.IsNullOrEmpty(txtSearch.Text)) Then
                Dim x As String = txtSearch.Text.ToLower 'change the text in txtSearch to lowercase
                If (u.UserID.ToString.Contains(x) Or u.FirstName.ToLower.Contains(x) Or u.LastName.ToLower.Contains(x) Or u.Username.ToLower.Contains(x) Or
                u.Email.ToLower.Contains(x) Or u.UserGroup.ToString.ToLower.Contains(x)) Then
                    e.Accepted = True
                Else
                    e.Accepted = False
                End If
            Else
                e.Accepted = True
            End If
        End If
    End Sub

    'refresh the datagrid according to the filter
    Private Sub txtSearch_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtSearch.TextChanged
        CollectionViewSource.GetDefaultView(dgUsers.ItemsSource).Refresh()
    End Sub

    Private Sub dgUsers_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles dgUsers.MouseDoubleClick
        btnEdit_Click(sender, Nothing)
    End Sub

End Class