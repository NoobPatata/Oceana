Public Class MedicalRecord

    Dim ViewModel As New MedicalRecordViewModel

    Public Sub New(ByRef _record As PrescriptionDetails)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DataContext = ViewModel
        ViewModel.inRecord = _record
    End Sub
End Class
