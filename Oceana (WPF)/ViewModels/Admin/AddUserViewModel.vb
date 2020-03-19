Public Class AddUserViewModel

    Inherits PropertyChanged

    Public Property Add As LoginUsers
    Private _FN As String
    Private _LN As String
    Private _UN As String
    Private _PS As String
    Private _EM As String
    Private _UG As String

    Public Property FN As String
        Get
            Return Add.FirstName
        End Get
        Set(value As String)
            Add.FirstName = value
            OnPropertyChanged(FN)
        End Set
    End Property

    Public Property LN As String
        Get
            Return Add.LastName
        End Get
        Set(value As String)
            Add.LastName = value
            OnPropertyChanged(LN)
        End Set
    End Property

    Public Property UN As String
        Get
            Return Add.Username
        End Get
        Set(value As String)
            Add.Username = value
            OnPropertyChanged(UN)
        End Set
    End Property

    Public Property PS As String
        Get
            Return Add.Password
        End Get
        Set(value As String)
            Add.Password = value
            OnPropertyChanged(PS)
        End Set
    End Property

    Public Property EM As String
        Get
            Return Add.Email
        End Get
        Set(value As String)
            Add.Email = value
            OnPropertyChanged(EM)
        End Set
    End Property

    Public Property UG As String
        Get
            Return Add.UserGroup
        End Get
        Set(value As String)
            Add.UserGroup = value
            OnPropertyChanged(UG)
        End Set
    End Property
End Class
