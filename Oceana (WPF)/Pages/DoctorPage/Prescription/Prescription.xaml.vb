Imports MaterialDesignThemes.Wpf
Public Class Prescription

    Dim _prescription As ObservablePrescription
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _prescription = Me.Resources("prescription")
        'refreshUsers()
    End Sub

    Private Async Sub btnAdd_Click(sender As Object, e As RoutedEventArgs) Handles btnAdd.Click
        Dim inpatient As PatientList = New PatientList()
        Dim result As Boolean = Await DialogHost.Show(New AddPrescription, "RootDialog")

    End Sub

    'Public Sub refreshUsers()
    '    _prescription.Clear()
    '    For Each prescription As PrescriptionDetails In gVars.Doctor.GetAllPrescription()
    '        _prescription.Add(prescription)
    '    Next
    'End Sub
End Class
