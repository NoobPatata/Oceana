Imports System.Data.OleDb
Public Class Patients

    Dim _patient As ObservePatient
    Dim _record As ObservePrescription


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _patient = Me.Resources("patients")
        _record = Me.Resources("prescription")



    End Sub


    Public Sub loadRecord()
        _record.Clear()
        For Each record As PrescriptionList In gVars.Doctor.GetPatientRecord(txtSearch.Text)
            _record.Add(record)
        Next
    End Sub


    Public Sub CollectionViewSource_Filter(sender As Object, e As FilterEventArgs)
        Dim p As PatientList = e.Item
        If p IsNot Nothing Then
            If (Not String.IsNullOrEmpty(txtSearch.Text)) Then
                Dim x As String = txtSearch.Text.ToLower 'change the text in txtSearch to lowercase
                If (p.PatientID.ToString.Contains(x) Or p.FirstName.ToLower.Contains(x) Or p.LastName.ToLower.Contains(x)) Then
                    e.Accepted = True
                Else
                    e.Accepted = False
                End If
            Else
                e.Accepted = True
            End If
        End If
    End Sub


    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.Key = Key.Enter Then
            _patient.Clear()
            loadRecord()
            For Each Patients As PatientList In gVars.Doctor.GetAllRecords(txtSearch.Text, txtSearch.Text)
                _patient.Add(Patients)
            Next

        End If
    End Sub

    'Private Async Sub dgPatients_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles dgPatients.MouseDoubleClick
    '    If dgPatients.SelectedIndex = -1 Then
    '        Return
    '    End If
    '    Dim selectedpatient As PatientList = New PatientList(dgPatients.SelectedValue)
    '    Await DialogHost.Show(New PatientRecords(selectedpatient), "RootDialog")
    '    refreshPatients()

    'End Sub


End Class
