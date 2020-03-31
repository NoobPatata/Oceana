Public Class UserInfoViewModel

    Inherits ValidatableObservableObject

    Public Property Info As LoginUsers
    Private _FN As String
    Private _LN As String
    Private _UN As String
    Private _PS As String
    Private _EM As String




    Public Property FN As String
        Get
            Return Info.FirstName
        End Get
        Set(value As String)
            Info.FirstName = value
            OnPropertyChanged(FN)
        End Set
    End Property

    Public Property LN As String
        Get
            Return Info.LastName
        End Get
        Set(value As String)
            Info.LastName = value
            OnPropertyChanged(LN)
        End Set
    End Property

    Public Property UN As String
        Get
            Return Info.Username
        End Get
        Set(value As String)
            Info.Username = value
            OnPropertyChanged(UN)
        End Set
    End Property

    Public Property PS As String
        Get
            Return Info.Password
        End Get
        Set(value As String)
            Info.Password = value
            OnPropertyChanged(PS)
        End Set
    End Property

    Public Property EM As String
        Get
            Return Info.Email
        End Get
        Set(value As String)
            Info.Email = value
            OnPropertyChanged(EM)
        End Set
    End Property

    Private _allFieldsFilled As Boolean
    Public ReadOnly Property AllFieldsFilled() As Boolean
        Get
            If String.IsNullOrEmpty(FN) Or String.IsNullOrEmpty(LN) Or String.IsNullOrEmpty(PS) Or String.IsNullOrEmpty(EM) Or String.IsNullOrEmpty(PS) Then
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
                ElseIf Not EM.Contains("@") Then
                    errorList.Add("Please enter a valid email!")
                ElseIf (gVars.Admin.GetUserByEmail(EM) IsNot Nothing) Then
                    errorList.Add("User with same email already exist in database!")
                End If

            Case "Username"
                If (String.IsNullOrWhiteSpace(UN)) Then
                    errorList.Add("Username cannot be empty!")
                ElseIf (gVars.Admin.GetUserbyUsername(UN) IsNot Nothing) Then
                    errorList.Add("User with the same username already exist in database!")
                End If

            Case Else


        End Select

        PropertyErrorsDictionary(propName) = errorList
        OnErrorsChanged(propName)
        OnPropertyChanged(NameOf(AllFieldsFilled))
    End Sub

End Class
