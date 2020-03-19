Imports MaterialDesignThemes.Wpf
Public Class Prescription
    Private Async Sub btnAdd_Click(sender As Object, e As RoutedEventArgs) Handles btnAdd.Click
        Dim inpatient As PatientList = New PatientList()
        Dim result As Boolean = Await DialogHost.Show(New AddPrescription, "RootDialog")

    End Sub
End Class
