Imports MaterialDesignThemes.Wpf
Public Class Prescription

    Dim _treatment As ObserveTreatment
    Dim _doctor As ObservableDoctor
    Dim _pesakit As ObservePatient
    Dim _nurse As ObservableNurse
    Dim _newTreatment As New ObservablePrescriptionTreatments
    Dim _id As New ObservableDetailsID
    Dim msgQ As New SnackbarMessageQueue(TimeSpan.FromSeconds(3))
    Dim msgQ2 As New SnackbarMessageQueue(TimeSpan.FromSeconds(3))

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _treatment = Me.Resources("Treatment")
        _doctor = Me.Resources("doctor")
        _pesakit = Me.Resources("pesakit")
        _nurse = Me.Resources("nurse")
        _newTreatment = Me.Resources("PrescriptionTreatement")
        LoadTreatment()
        LoadDoctor()
        LoadPatient()
        LoadNurse()
        msgQ = MySnackbar.MessageQueue
        msgQ2 = MySnackbarTwo.MessageQueue

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

    Public Sub LoadNurse()
        _nurse.Clear()
        For Each nur As Nurse In gVars.Doctor.GetAllNurse()
            _nurse.Add(nur)
        Next
    End Sub

    Private Sub btnNext_Click(sender As Object, e As RoutedEventArgs) Handles btnNext.Click

        If Not String.IsNullOrWhiteSpace(txtDisease.Text) And Not String.IsNullOrWhiteSpace(cbbDoctor.Text) And Not String.IsNullOrWhiteSpace(cbbPatient.Text) And Not String.IsNullOrWhiteSpace(cbbDate.Text) And Not String.IsNullOrWhiteSpace(cbbNurse.Text) Then

            Transitions.Transitioner.MoveNextCommand.Execute(Nothing, Nothing)

        Else

            msgQ.Enqueue("Please fill in all the field!")

        End If

    End Sub

    'https://stackoverflow.com/questions/42162294/c-sharp-wpf-combobox-editable-only-allow-option-from-list
    'check if the treatment selected is valid or not
    Private Sub cbbTreatment_LostFocus(sender As Object, e As RoutedEventArgs) Handles cbbTreatment.LostFocus

        Dim allowed As Boolean = False

        For Each it As Treatment In cbbTreatment.Items

            If (it.Name.ToString() = cbbTreatment.Text) Then
                allowed = True
                Exit For
            End If
        Next

        If Not allowed Then
            MessageBox.Show("Please Select a Valid Treatment!")
            txtDescription.IsEnabled = False
        Else
            txtDescription.IsEnabled = True
        End If

    End Sub

    'Enable Insert Button if textbox is not null
    Private Sub txtDescription_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtDescription.TextChanged
        Dim result As Boolean
        If Not String.IsNullOrEmpty(txtDescription.Text) Then
            btnInsert.IsEnabled = True
        Else
            result = False
        End If

    End Sub

    'Insert selected treatment and description into list
    Private Sub btnInsert_Click(sender As Object, e As RoutedEventArgs) Handles btnInsert.Click

        Dim value As String = gVars.Doctor.GetPrescriptionID + 1
        Dim i As String = gVars.Doctor.GetTreatmentID(cbbTreatment.Text)

        Dim inTreatment As New PrescriptionTreatments
        inTreatment.PrescriptionID = value
        inTreatment.TreatmentName = cbbTreatment.Text
        inTreatment.TreatmentID = i
        inTreatment.Description = txtDescription.Text
        _newTreatment.Add(inTreatment)

        cbbTreatment.SelectedIndex = -1
        txtDescription.Clear()
        btnInsert.IsEnabled = False

    End Sub

    'Remove the item in the list
    Private Sub btnRemove_Click(sender As Object, e As RoutedEventArgs) Handles btnRemove.Click
        If dgTreatment.SelectedIndex = -1 Then
            Return
        End If
        _newTreatment.RemoveAt(dgTreatment.SelectedIndex)
    End Sub

    'Save the treatment
    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs) Handles btnSave.Click
        If _newTreatment.Count = 0 Then
            msgQ.Enqueue("Please select treatment for the patient!")

        Else

            If gVars.Doctor.InsertNewPrescription(cbbPatient.Text, cbbDoctor.Text) > 0 Then
                If gVars.Doctor.AddDateAndDisease(cbbDate.SelectedDate.Value.Date.ToShortDateString, txtDisease.Text) > 0 Then
                    If gVars.Doctor.CreateNewInvoice() > 0 Then
                        If gVars.Doctor.UpdateStaffinInvoice(gVars.Doctor.GetStaffID(cbbNurse.Text)) Then
                        End If
                    End If
                End If
            End If

            For Each treatment In _newTreatment
                If gVars.Doctor.InsertIntoPrescriptionDetails(treatment.PrescriptionID, treatment.TreatmentID, treatment.Description) > 0 Then
                End If
            Next

            Dim prescriptionID As Integer = gVars.Doctor.GetPrescriptionID
            Dim invoiceID As Integer = gVars.Doctor.GetInvoiceID

            For Each id As DetailsID In gVars.Doctor.GetDetailsID(prescriptionID)
                _id.Add(id)
            Next

            For Each ids In _id
                gVars.Doctor.InsertIntoInvoiceDetails(invoiceID, ids.DID, ids.Price)
            Next

            gVars.Doctor.InsertTotalPrice(gVars.Doctor.GetTotalPrice + 30)

            DialogHost.CloseDialogCommand.Execute(Nothing, Nothing)

        End If

    End Sub


End Class