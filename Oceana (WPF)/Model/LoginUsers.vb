Imports System.ComponentModel
Imports System.Collections.ObjectModel
Public Class LoginUsers

    Inherits PropertyChanged


    Private _userID As String
    Private _FirstName As String
    Private _LastName As String
    Private _ContactNumber As String
    Private _Email As String
    Private _Username As String
    Private _Password As String
    Private _UserGroup As String
    Private _Fullname As String
    Private selectedValue As Object

    Public Sub New()
    End Sub

    Public Sub New(ByVal _userObject As Object)
        Dim x As LoginUsers = _userObject
        _FirstName = x.Firstname.Trim()
        _LastName = x.Lastname.Trim()
        _Username = x.Username.Trim()
        _Password = x.Password.Trim()
        _Email = x.Email.Trim()
        _userID = x.UserID
        _UserGroup = x.UserGroup
    End Sub

    Public Sub New(userID As String, firstName As String, lastName As String, password As String, email As String, userGroup As String)
        Me.UserID = userID
        Me.FirstName = firstName
        Me.LastName = lastName
        Me.Password = password
        Me.Email = email
        Me.UserGroup = userGroup
    End Sub

    Public Sub New(ByVal __UserId As String, ByVal __Firstname As String, ByVal __Lastname As String, ByVal __ContactNumber As String, ByVal __Email As String, ByVal __Username As String, ByVal __Password As String, ByVal __UserGroup As String)
        _userID = __UserId
        _FirstName = __Firstname
        _LastName = __Lastname
        _ContactNumber = __ContactNumber
        _Email = __Email
        _Username = __Username
        _Password = __Password
        _UserGroup = __UserGroup
    End Sub

    Public Property UserID As String
        Get
            Return _userID
        End Get
        Set(value As String)
            _userID = value
            OnPropertyChanged(NameOf(UserID))
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _FirstName
        End Get
        Set(value As String)
            _FirstName = value
            OnPropertyChanged(NameOf(FirstName))
            OnPropertyChanged(Fullname)
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _LastName
        End Get
        Set(value As String)
            _LastName = value
            OnPropertyChanged(NameOf(LastName))
            OnPropertyChanged(Fullname)
        End Set
    End Property

    Public Property ContactNumber As String
        Get
            Return _ContactNumber
        End Get
        Set(value As String)
            _ContactNumber = value
            OnPropertyChanged(NameOf(ContactNumber))
        End Set
    End Property

    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            _Email = value
            OnPropertyChanged(NameOf(Email))
        End Set
    End Property

    Public Property Username As String
        Get
            Return _Username
        End Get
        Set(value As String)
            _Username = value
            OnPropertyChanged(NameOf(Username))
        End Set
    End Property

    Public Property Password As String
        Get
            Return _Password
        End Get
        Set(value As String)
            _Password = value
            OnPropertyChanged(NameOf(Password))
        End Set
    End Property

    Public Property UserGroup As String
        Get
            Return _UserGroup
        End Get
        Set(value As String)
            _UserGroup = value
            OnPropertyChanged(NameOf(UserGroup))
        End Set
    End Property

    Public ReadOnly Property Fullname As String
        Get
            Return _FirstName & " " & _LastName
        End Get
    End Property
End Class

Public Class ObserveUser
    Inherits ObservableCollection(Of LoginUsers)
End Class