Public Class PatientDetails

    Dim VM As New PatientInfoViewModel

    Public Sub New(ByRef _patient As PatientList)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DataContext = VM
        VM.EPatient = _patient
    End Sub
    Private Sub cbbBloodType_Loaded(sender As Object, e As RoutedEventArgs) Handles cbbBloodType.Loaded
        cbbBloodType.Items.Add("A-")
        cbbBloodType.Items.Add("A+")
        cbbBloodType.Items.Add("AB-")
        cbbBloodType.Items.Add("AB+")
        cbbBloodType.Items.Add("B-")
        cbbBloodType.Items.Add("B+")
        cbbBloodType.Items.Add("O-")
        cbbBloodType.Items.Add("O+")
    End Sub

    Private Sub cbbBloodType_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbbBloodType.SelectionChanged
        cbbBloodType.SelectedItem.ToString()
    End Sub

End Class
