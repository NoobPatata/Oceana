Imports MaterialDesignThemes.Wpf
Public Class AddPrescription

    Dim _treatment As ObserveTreatment
    Dim _doctor As ObservableDoctor
    Dim _pesakit As ObservePatient
    Dim msgQ As New SnackbarMessageQueue(TimeSpan.FromSeconds(3))

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
        msgQ = MySnackbar.MessageQueue

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

    Private Sub btnNext_Click(sender As Object, e As RoutedEventArgs) Handles btnNext.Click

        If Not String.IsNullOrWhiteSpace(txtDisease.Text) And Not String.IsNullOrWhiteSpace(cbbDoctor.Text) And Not String.IsNullOrWhiteSpace(cbbPatient.Text) And Not String.IsNullOrWhiteSpace(cbbDate.Text) Then

            Transitions.Transitioner.MoveNextCommand.Execute(Nothing, Nothing)

            If gVars.Doctor.InsertNewPrescription(cbbPatient.Text, cbbDoctor.Text) > 0 Then
                If gVars.Doctor.AddDateAndDisease(cbbDate.SelectedDate.Value.Date.ToShortDateString, txtDisease.Text) > 0 Then
                    If gVars.Doctor.CreateNewInvoice() > 0 Then
                    End If
                End If
            End If

        Else

            msgQ.Enqueue("Please fill in all the field!")

        End If



    End Sub


End Class