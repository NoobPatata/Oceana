﻿
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


    Private Sub ValidateEmail()
        Task.Run(Sub() AddVM.Validation(NameOf(AddVM.EM), AddVM.EM, "", "Email"))
    End Sub

    Private Sub ValidateUsername()
        Task.Run(Sub() AddVM.Validation(NameOf(AddVM.UN), AddVM.UN, "", "Username"))
    End Sub

    Private Sub txtFields_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtFirstname.TextChanged, txtLastname.TextChanged, txtPassword.TextChanged
        AddVM.OnPropertyChanged("AllFieldsFilled")
    End Sub
    Private Sub txtEmail_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtEmail.TextChanged
        ValidateEmail()
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtUsername.TextChanged
        ValidateUsername()
    End Sub

End Class
