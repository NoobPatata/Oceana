Imports System.Collections.ObjectModel
Public Class Nurse

    Inherits PropertyChanged

    Private _NurseID As String
    Private _FirstName As String
    Private _LastName As String
    Private _Identification As String
    Private _Contact As String
    Private _Email As String
    Private _Address As String

    Public Sub New(nurseID As String, firstName As String, lastName As String, identification As String, contact As String, email As String, address As String)
        _NurseID = nurseID
        _FirstName = firstName
        _LastName = lastName
        _Identification = identification
        _Contact = contact
        _Email = email
        _Address = address
    End Sub

    Public Property NurseID As String
        Get
            Return _NurseID
        End Get
        Set(value As String)
            _NurseID = value
            OnPropertyChanged(NameOf(NurseID))
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _FirstName
        End Get
        Set(value As String)
            _FirstName = value
            OnPropertyChanged(NameOf(FirstName))
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _LastName
        End Get
        Set(value As String)
            _LastName = value
            OnPropertyChanged(NameOf(LastName))
        End Set
    End Property

    Public Property Identification As String
        Get
            Return _Identification
        End Get
        Set(value As String)
            _Identification = value
            OnPropertyChanged(NameOf(Identification))
        End Set
    End Property

    Public Property Contact As String
        Get
            Return _Contact
        End Get
        Set(value As String)
            _Contact = value
            OnPropertyChanged(NameOf(Contact))
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

    Public Property Address As String
        Get
            Return _Address
        End Get
        Set(value As String)
            _Address = value
            OnPropertyChanged(NameOf(Address))
        End Set
    End Property


End Class

Public Class ObservableNurse
    Inherits ObservableCollection(Of Nurse)
End Class


