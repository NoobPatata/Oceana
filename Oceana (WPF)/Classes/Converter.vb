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

End Class

