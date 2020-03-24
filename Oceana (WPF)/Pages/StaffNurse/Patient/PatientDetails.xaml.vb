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

    Private Sub ValidateEmail()
        Task.Run(Sub() VM.Validation(NameOf(VM.EM), VM.EM, "", "Email"))
    End Sub

    Private Sub ValidateContact()
        Task.Run(Sub() VM.Validation(NameOf(VM.CN), VM.CN, "", "ContactNumber"))
    End Sub

    Private Sub ValidateID()
        Task.Run(Sub() VM.Validation(NameOf(VM.ID), VM.ID, "", "Identification"))
    End Sub

    Private Sub txtFields_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtFirstName.TextChanged, txtLastName.TextChanged, txtPhone.TextChanged, txtIC.TextChanged, txtAddress.TextChanged, txtEmail.TextChanged, txtHeight.TextChanged, txtWeight.TextChanged
        VM.OnPropertyChanged("AllFieldsFilled")
    End Sub
    Private Sub txtEmail_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtEmail.TextChanged
        ValidateEmail()
    End Sub

    Private Sub txtPhone_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtPhone.TextChanged
        ValidateContact()
    End Sub

    Private Sub txtIC_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtIC.TextChanged
        ValidateID()
    End Sub

End Class
