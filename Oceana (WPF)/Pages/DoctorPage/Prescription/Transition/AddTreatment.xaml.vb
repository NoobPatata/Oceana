Public Class AddTreatment

    Dim _treatment As New ObserveTreatment
    Dim _newTreatment As New ObservablePrescriptionTreatments
    Dim _id As New ObservableDetailsID

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _treatment = Me.Resources("Treatment")
        _newTreatment = Me.Resources("PrescriptionTreatement")
        LoadTreatment()
    End Sub

    Public Sub LoadTreatment()
        For Each Treatments As Treatment In gVars.Doctor.GetAllTreatment()
            _treatment.Add(Treatments)
        Next
    End Sub

    'https://stackoverflow.com/questions/42162294/c-sharp-wpf-combobox-editable-only-allow-option-from-list
    'check if the treatment selected is valid or not
    Private Sub cbbTreatment_LostFocus(sender As Object, e As RoutedEventArgs) Handles cbbTreatment.LostFocus
        Dim allowed As Boolean = False

        For Each it As Treatment In cbbTreatment.Items

            If it.Name.ToString() = cbbTreatment.Text Then
                allowed = True
                Exit For
            End If
        Next

        If Not allowed Then
            MessageBox.Show("Please Select a Valid Treatment!")
        Else

        End If
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As RoutedEventArgs) Handles btnInsert.Click

        Dim value As String = gVars.Doctor.GetPrescriptionID
        Dim i As String = gVars.Doctor.GetTreatmentID(cbbTreatment.Text)

        Dim inTreatment As New PrescriptionTreatments
        inTreatment.PrescriptionID = value
        inTreatment.TreatmentName = cbbTreatment.Text
        inTreatment.TreatmentID = i
        inTreatment.Description = txtDescription.Text
        _newTreatment.Add(inTreatment)

        cbbTreatment.SelectedIndex = -1
        txtDescription.Clear()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs) Handles btnSave.Click

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
            gVars.Doctor.InsertIntoInvoiceDetails(invoiceID, ids.DID)
        Next
    End Sub
End Class
