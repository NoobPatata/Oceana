Imports System.Data.OleDb
Imports MaterialDesignThemes.Wpf
Public Class Patients

    Dim _patient As ObservePatient
    Dim _record As ObservablePrescription


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _patient = Me.Resources("patients")
        _record = Me.Resources("prescription")


    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtSearch.TextChanged
        loadRecord()
        loadPatient()
    End Sub

    Public Sub loadRecord()
        _record.Clear()
        For Each record As PrescriptionDetails In gVars.Doctor.GetPatientPrescription(txtSearch.Text)
            _record.Add(record)
        Next
    End Sub

    Private Async Sub dgRecord_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles dgRecord.MouseDoubleClick
        If dgRecord.SelectedIndex = -1 Then
            Return
        End If
        Dim selectedrecord As PrescriptionDetails = New PrescriptionDetails(dgRecord.SelectedValue)
        Await DialogHost.Show(New MedicalRecord(selectedrecord), "RootDialog")

    End Sub

    Public Sub loadPatient()
        _patient.Clear()
        For Each Patients As PatientList In gVars.Doctor.GetPatientDetails(txtSearch.Text, txtSearch.Text)
            _patient.Add(Patients)
        Next
    End Sub

    Private Async Sub btnAdd_Click(sender As Object, e As RoutedEventArgs) Handles btnAdd.Click
        Dim inpatient As PatientList = New PatientList()
        Dim result As Boolean = Await DialogHost.Show(New AddPrescription, "RootDialog")
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
End Class
