Imports System.Globalization
Public Class Converter

    'convert the selected items in datagrid to a list of user
    Public Shared Function SelectedItemsToListOfUsers(selectedItems As IList) As List(Of LoginUsers)
        Dim users As New List(Of LoginUsers)
        For Each user As LoginUsers In selectedItems
            users.Add(New LoginUsers(user.UserID,
                                     user.FirstName,
                                     user.LastName,
                                     user.Password,
                                     user.Email,
                                     user.UserGroup))
        Next
        Return users
    End Function

    'convert selected items in datagrid to list of patient
    Public Shared Function SelectedItemsToListOfPatient(selectedItems As IList) As List(Of PatientList)
        Dim patients As New List(Of PatientList)
        For Each patient As PatientList In selectedItems
            patients.Add(New PatientList(patient.PatientID,
                                         patient.FirstName,
                                         patient.LastName,
                                         patient.IdentificationNumber,
                                         patient.ContactNumber,
                                         patient.CurrentAddress,
                                         patient.Email,
                                         patient.Weight,
                                         patient.Height,
                                         patient.BloodType,
                                         patient.Allergies))
        Next
        Return patients
    End Function

    'convert selected items in datagrid to list of prescription
    Public Shared Function SelectedItemsToListOfPrescription(selectedItems As IList) As List(Of PrescriptionDetails)
        Dim prescriptions As New List(Of PrescriptionDetails)
        For Each prescription As PrescriptionDetails In selectedItems
            prescriptions.Add(New PrescriptionDetails(prescription.PrescriptionID, prescription.Hari, prescription.Disease, prescription.DID, prescription.PID, prescription.PFullname, prescription.PLastName, prescription.DFirstName, prescription.DLastName))
        Next
        Return prescriptions
    End Function

    'convert selected items in datagrid to list of invoice
    Public Shared Function SelectedItemToListOfInvoice(selectedItems As IList) As List(Of Invoice)
        Dim invoices As New List(Of Invoice)
        For Each invoice As Invoice In selectedItems
            invoices.Add(New Invoice(invoice.InvoiceID, invoice.StaffFN, invoice.StaffLN, invoice.Amount, invoice.Paid, invoice.Balance))
        Next
        Return invoices
    End Function


End Class

'To convert the foreground color of the payment status
Public Class ForegroundConverter

    Implements IValueConverter

    Private Function IValueConverter_Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        If CStr(value) = "Paid" Then
            Return "#00E676"
        ElseIf CStr(value) = "Overdue" Then
            Return "Red"
        End If
    End Function

    Private Function IValueConverter_ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class