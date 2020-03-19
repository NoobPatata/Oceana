Public Class UserInfoViewModel

    Inherits PropertyChanged

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

End Class
