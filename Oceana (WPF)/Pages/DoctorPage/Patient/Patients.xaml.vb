Imports System.Data.OleDb
Imports MaterialDesignThemes.Wpf
Public Class Patients

    Dim _patient As ObservePatient
    Dim _prescription As ObservablePrescription
    Dim msgQ As New SnackbarMessageQueue(TimeSpan.FromSeconds(3))


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _patient = Me.Resources("patients")
        _prescription = Me.Resources("prescription")
        msgQ = MySnackbar.MessageQueue

    End Sub

    'Search text box
    Private Sub txtSearch_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtSearch.TextChanged

        If IsNumeric(txtSearch.Text) Then
            loadPatientByID()
            loadRecordByID()
        Else
            loadPatient()
            loadRecord()
        End If

    End Sub

    'load patient past prescription by name
    Public Sub loadRecord()
        _prescription.Clear()
        For Each record As PrescriptionDetails In gVars.Doctor.GetPatientPrescription(txtSearch.Text)
            _prescription.Add(record)
        Next
    End Sub

    'load patient past prescription by patientID
    Public Sub loadRecordByID()
        _prescription.Clear()
        For Each record As PrescriptionDetails In gVars.Doctor.GetPatientPrescriptionByID(txtSearch.Text)
            _prescription.Add(record)
        Next
    End Sub

    'load patient details by name
    Public Sub loadPatient()
        _patient.Clear()
        For Each Patients As PatientList In gVars.Doctor.GetPatientDetails(txtSearch.Text)
            _patient.Add(Patients)
        Next
    End Sub

    'load patient details by patientID
    Public Sub loadPatientByID()
        _patient.Clear()
        For Each Patients As PatientList In gVars.Doctor.GetPatientByID(txtSearch.Text)
            _patient.Add(Patients)
        Next
    End Sub



    Private Async Sub btnAdd_Click(sender As Object, e As RoutedEventArgs) Handles btnAdd.Click

        Await DialogHost.Show(New Prescription, "RootDialog")

    End Sub

    Private Async Sub dgRecord_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles dgRecord.MouseDoubleClick

        Dim selectedUsers As List(Of PrescriptionDetails) = Converter.SelectedItemsToListOfPrescription(dgRecord.SelectedItems)
        For Each profile In selectedUsers
            Dim selected As MedicalRecordDetails
            selected = New MedicalRecordDetails(gVars.Doctor.GetPrescriptionDetails(profile.PrescriptionID))
            Dim result As Boolean = Await DialogHost.Show(New MedicalRecord(selected), "RootDialog")
        Next
    End Sub

End Class

