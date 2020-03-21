Public Class MedicalRecord
    Dim ViewModel As New MedicalRecordViewModel
    Public Sub New(ByRef _PDetails As MedicalRecordDetails)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ViewModel.OutDetaills = _PDetails
        DataContext = ViewModel

    End Sub
End Class
