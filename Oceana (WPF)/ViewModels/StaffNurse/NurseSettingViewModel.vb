Public Class NurseSettingViewModel

    Inherits ValidatableObservableObject
    Public Property info As Nurse
    Private _DID As String
    Private _FN As String
    Private _LN As String
    Private _ID As String
    Private _CN As String
    Private _EM As String
    Private _AD As String

    Public Property DID As String
        Get
            Return info.NurseID
        End Get
        Set(value As String)
            info.NurseID = value
        End Set
    End Property

    Public Property FN As String
        Get
            Return info.FirstName
        End Get
        Set(value As String)
            info.FirstName = value
        End Set
    End Property

    Public Property LN As String
        Get
            Return info.LastName
        End Get
        Set(value As String)
            info.LastName = value
        End Set
    End Property

    Public Property ID As String
        Get
            Return info.Identification
        End Get
        Set(value As String)
            info.Identification = value
        End Set
    End Property

    Public Property CN As String
        Get
            Return info.Contact
        End Get
        Set(value As String)
            info.Contact = value
        End Set
    End Property

    Public Property EM As String
        Get
            Return info.Email
        End Get
        Set(value As String)
            info.Email = value
        End Set
    End Property

    Public Property AD As String
        Get
            Return info.Address
        End Get
        Set(value As String)
            info.Address = value
        End Set
    End Property

    Private _allFieldsFilled As Boolean
    Public ReadOnly Property AllFieldsFilled() As Boolean
        Get
            If String.IsNullOrEmpty(CN) Or String.IsNullOrEmpty(AD) Or String.IsNullOrEmpty(ID) Then
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
            Case "Identification"
                If (String.IsNullOrWhiteSpace(ID)) Then
                    errorList.Add("Identification Number cannot be empty!")

                End If

            Case "Contact"
                If (String.IsNullOrWhiteSpace(CN)) Then
                    errorList.Add("Contact number cannot be empty!")
                ElseIf Not IsNumeric(CN) Then
                    errorList.Add("Please enter a valid contact number!")
                End If

            Case "Address"
                If (String.IsNullOrWhiteSpace(AD)) Then
                    errorList.Add("Address cannot be empty!")
                End If

            Case Else


        End Select

        PropertyErrorsDictionary(propName) = errorList
        OnErrorsChanged(propName)
        OnPropertyChanged(NameOf(AllFieldsFilled))
    End Sub

End Class
