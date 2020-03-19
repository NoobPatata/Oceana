Public Class AddPrescription

    Dim _treatment As ObserveTreatment

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
End Class
