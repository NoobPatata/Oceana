Public Class AddPrescription

    Dim _treatment As ObserveTreatment
    Dim _doctor As ObservableDoctor
    Dim _pesakit As ObservePatient

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _treatment = Me.Resources("Treatment")
        _doctor = Me.Resources("doctor")
        _pesakit = Me.Resources("pesakit")
        LoadTreatment()
        LoadDoctor()
        LoadPatient()

    End Sub

    Public Sub LoadTreatment()
        For Each Treatments As Treatment In gVars.Doctor.GetAllTreatment()
            _treatment.Add(Treatments)
        Next

    End Sub

    Public Sub LoadPatient()
        _pesakit.Clear()
        For Each doc As PatientList In gVars.Nurse.GetAllPatients()
            _pesakit.Add(doc)
        Next
    End Sub

    Public Sub LoadDoctor()
        _doctor.Clear()
        For Each doc As Doctor In gVars.Doctor.GetAllDoctor()
            _doctor.Add(doc)
        Next
    End Sub

    Private Sub btn_Click(sender As Object, e As RoutedEventArgs) Handles btn.Click

        If gVars.Doctor.InsertNewPrescription(cbbPatient.Text, cbbDoctor.Text) > 0 Then
            If gVars.Doctor.AddDateAndDisease(cbdate.SelectedDate.Value.Date.ToShortDateString, txtSakit.Text) > 0 Then
                If gVars.Doctor.CreateNewInvoice() > 0 Then
                End If
            End If
        End If



    End Sub


End Class
