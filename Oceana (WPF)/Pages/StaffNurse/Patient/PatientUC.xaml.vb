﻿Imports MaterialDesignThemes.Wpf
Public Class Nurse_Patient

    Dim _patient As ObservePatient
    Dim msgQ As New SnackbarMessageQueue(TimeSpan.FromSeconds(3))
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _patient = Me.Resources("patients")
        MySnackbar.MessageQueue = msgQ
        refreshPatients()
    End Sub

    Private Async Sub btnAdd_Click(sender As Object, e As RoutedEventArgs) Handles btnAdd.Click
        Dim ispatient As PatientList = New PatientList()
        Dim result As Boolean = Await DialogHost.Show(New AddPatients(ispatient), "RootDialog")
        If result = True Then
            If gVars.Nurse.InsertNewPatient(ispatient) > 0 Then
                msgQ.Enqueue("Success! New user (" + ispatient.Email + ") successfully created!")
            Else
                msgQ.Enqueue("Failure! Failed to create user (" + ispatient.Email + ")!")
            End If
        End If

        refreshPatients()
    End Sub

    Private Async Sub btnRemove_Click(sender As Object, e As RoutedEventArgs) Handles btnRemove.Click
        If dgPatient.SelectedIndex = -1 Then
            Return
        End If

        Dim result As Boolean = Await DialogHost.Show(MultiDeleteDialogBox, "RootDialog")
        Dim selectedPatient As List(Of PatientList) = Converter.SelectedItemsToListOfPatient(dgPatient.SelectedItems)
        If result = True Then

            If gVars.Nurse.RemovePatient(selectedPatient) > 0 Then
                msgQ.Enqueue("Success! " + selectedPatient.Count.ToString + " users removed!")
            Else
                msgQ.Enqueue("Failure! " + selectedPatient.Count.ToString + "users failed to be removed!")
            End If

        End If

        refreshPatients()
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As RoutedEventArgs) Handles btnEdit.Click
        If dgPatient.SelectedIndex = -1 Then
            Return
        End If
        Dim selectedpatient As PatientList = New PatientList(dgPatient.SelectedValue)
        Dim result As Boolean = Await DialogHost.Show(New PatientDetails(selectedpatient), "RootDialog")
        If result = True Then
            If gVars.Nurse.UpdatePatient(selectedpatient) > 0 Then
                msgQ.Enqueue(selectedpatient.Email + " has been successfully updated!")
            Else
                msgQ.Enqueue("Failed to update " + selectedpatient.Email + " !")
            End If
        End If
        refreshPatients()
    End Sub

    Public Sub refreshPatients()
        _patient.Clear()
        For Each Patients As PatientList In gVars.Nurse.GetAllPatients()
            _patient.Add(Patients)
        Next
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtSearch.TextChanged
        CollectionViewSource.GetDefaultView(dgPatient.ItemsSource).Refresh()
    End Sub

    Public Sub CollectionViewSource_Filter(sender As Object, e As FilterEventArgs)
        Dim p As PatientList = e.Item
        If p IsNot Nothing Then
            If (Not String.IsNullOrEmpty(txtSearch.Text)) Then
                Dim x As String = txtSearch.Text.ToLower 'change the text in txtSearch to lowercase
                If (p.PatientID.ToString.Contains(x) Or p.FirstName.ToLower.Contains(x) Or p.LastName.ToLower.Contains(x) Or p.IdentificationNumber.ToLower.Contains(x) Or
                p.Email.ToLower.Contains(x)) Then
                    e.Accepted = True
                Else
                    e.Accepted = False
                End If
            Else
                e.Accepted = True
            End If
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As RoutedEventArgs) Handles btnRefresh.Click
        refreshPatients()
    End Sub

    Private Sub dgPatient_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles dgPatient.MouseDoubleClick
        btnEdit_Click(sender, Nothing)
    End Sub
End Class
