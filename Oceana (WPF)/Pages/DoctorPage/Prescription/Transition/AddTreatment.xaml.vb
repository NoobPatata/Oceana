Public Class AddTreatment

    Dim _treatment As New ObserveTreatment

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _treatment = Me.Resources("Treatment")
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

End Class
