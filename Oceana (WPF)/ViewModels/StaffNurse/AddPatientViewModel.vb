Public Class AddPatientViewModel

    Inherits ValidatableObservableObject

    Public Property NewPatients As PatientList
    Private _FN As String
    Private _LN As String
    Private _ID As String
    Private _AD As String
    Private _CN As String
    Private _EM As String
    Private _CM As String
    Private _KG As String
    Private _BT As String
    Private _AL As String
    Public Property FN As String
        Get
            Return NewPatients.FirstName
        End Get
        Set(value As String)
            NewPatients.FirstName = value
            OnPropertyChanged(FN)
        End Set
    End Property

    Public Property LN As String
        Get
            Return NewPatients.LastName
        End Get
        Set(value As String)
            NewPatients.LastName = value
            OnPropertyChanged(LN)
        End Set
    End Property

    Public Property ID As String
        Get
            Return NewPatients.IdentificationNumber
        End Get
        Set(value As String)
            NewPatients.IdentificationNumber = value
            OnPropertyChanged(ID)
        End Set
    End Property

    Public Property AD As String
        Get
            Return NewPatients.CurrentAddress
        End Get
        Set(value As String)
            NewPatients.CurrentAddress = value
            OnPropertyChanged(AD)
        End Set
    End Property

    Public Property CN As String
        Get
            Return NewPatients.ContactNumber
        End Get
        Set(value As String)
            NewPatients.ContactNumber = value
            OnPropertyChanged(CN)
        End Set
    End Property

    Public Property EM As String
        Get
            Return NewPatients.Email
        End Get
        Set(value As String)
            NewPatients.Email = value
            OnPropertyChanged(EM)
        End Set
    End Property

    Public Property CM As String
        Get
            Return NewPatients.Height
        End Get
        Set(value As String)
            NewPatients.Height = value
            OnPropertyChanged(CM)
        End Set
    End Property

    Public Property KG As String
        Get
            Return NewPatients.Weight
        End Get
        Set(value As String)
            NewPatients.Weight = value
            OnPropertyChanged(KG)
        End Set
    End Property

    Public Property BT As String
        Get
            Return NewPatients.BloodType
        End Get
        Set(value As String)
            NewPatients.BloodType = value
            OnPropertyChanged(BT)
        End Set
    End Property

    Public Property AL As String
        Get
            Return NewPatients.Allergies
        End Get
        Set(value As String)
            NewPatients.Allergies = value
            OnPropertyChanged(AL)
        End Set
    End Property

    Private _allFieldsFilled As Boolean
    Public ReadOnly Property AllFieldsFilled() As Boolean
        Get
            If String.IsNullOrEmpty(FN) Or String.IsNullOrEmpty(LN) Or String.IsNullOrEmpty(ID) Or String.IsNullOrEmpty(AD) Or String.IsNullOrEmpty(CN) Or String.IsNullOrEmpty(EM) Or String.IsNullOrEmpty(CM) Or String.IsNullOrEmpty(KG) Or String.IsNullOrEmpty(BT) Then
                Return False
            Else
                If HasErrors Then
                    Return False
                Else
                    Return True
                End If
            End If
        End Get
    End Property

    Public Overrides Sub Validation(propName As String, ByRef propValue As String, errContent As String, type As String)
        Dim errorList As List(Of String)
        If PropertyErrorsDictionary.TryGetValue(propName, errorList) = False Then
            errorList = New List(Of String)
        Else
            errorList.Clear()
        End If

        Select Case type

            Case "Email"
                If (String.IsNullOrWhiteSpace(EM)) Then
                    errorList.Add("Email cannot be empty!")
                ElseIf (gVars.Nurse.GetPatientByEmail(EM) IsNot Nothing) Then
                    errorList.Add("Patient with same email already exist in database!")
                End If

            Case "ContactNumber"
                If (String.IsNullOrWhiteSpace(CN)) Then
                    errorList.Add("Contact cannot be empty!")
                ElseIf (gVars.Nurse.GetPatientByContactNumber(CN) IsNot Nothing) Then
                    errorList.Add("Patient with the same contact number already exist in database!")
                End If

            Case "Identification"
                If (String.IsNullOrWhiteSpace(ID)) Then
                    errorList.Add("Identification cannot be empty!")
                ElseIf (gVars.Nurse.GetPatientByIC(ID) IsNot Nothing) Then
                    errorList.Add("Patient with the same identification number already exist in database!")
                End If

            Case Else


        End Select

        PropertyErrorsDictionary(propName) = errorList
        OnErrorsChanged(propName)
        OnPropertyChanged(NameOf(AllFieldsFilled))
    End Sub

End Class
