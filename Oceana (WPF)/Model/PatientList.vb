Imports System.ComponentModel
Imports System.Collections.ObjectModel
Public Class PatientList

    Inherits PropertyChanged

    Private _PatientID As String
    Private _FirstName As String
    Private _LastName As String
    Private _IdentificationNumber As String
    Private _CurrentAddress As String
    Private _ContactNumber As String
    Private _Email As String
    Private _Height As String
    Private _Weight As String
    Private _BloodType As String
    Private _Allergies As String
    Private _Fullname As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal _patientObject As Object)
        Dim x As PatientList = _patientObject
        PatientID = x.PatientID
        FirstName = x.FirstName
        LastName = x.LastName
        IdentificationNumber = x.IdentificationNumber
        ContactNumber = x.ContactNumber
        CurrentAddress = x.CurrentAddress
        Email = x.Email
        Weight = x.Weight
        Height = x.Height
        BloodType = x.BloodType
        Allergies = x.Allergies
    End Sub

    Public Sub New(ByVal __PatientID As String, ByVal __FirstName As String, ByVal __LastName As String, ByVal __IdentificationNumber As String, ByVal __CurrentAddress As String, ByVal __ContactNumber As String,
                ByVal __Email As String, ByVal __Height As String, ByVal __Weight As String, ByVal __BloodType As String, ByVal __Allergies As String)

        _PatientID = __PatientID
        _FirstName = __FirstName
        _LastName = __LastName
        _IdentificationNumber = __IdentificationNumber
        _CurrentAddress = __CurrentAddress
        _ContactNumber = __ContactNumber
        _Email = __Email
        _Height = __Height
        _Weight = __Weight
        _BloodType = __BloodType
        _Allergies = __Allergies

    End Sub

    Public Property PatientID As String
        Get
            Return _PatientID
        End Get
        Set(value As String)
            _PatientID = value
            OnPropertyChanged(NameOf(PatientID))
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

    Public Property IdentificationNumber As String
        Get
            Return _IdentificationNumber
        End Get
        Set(value As String)
            _IdentificationNumber = value
            OnPropertyChanged(NameOf(IdentificationNumber))
        End Set
    End Property

    Public Property CurrentAddress As String
        Get
            Return _CurrentAddress
        End Get
        Set(value As String)
            _CurrentAddress = value
            OnPropertyChanged(NameOf(CurrentAddress))
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

    Public Property Height As String
        Get
            Return _Height
        End Get
        Set(value As String)
            _Height = value
            OnPropertyChanged(NameOf(Height))
        End Set
    End Property

    Public Property Weight As String
        Get
            Return _Weight
        End Get
        Set(value As String)
            _Weight = value
            OnPropertyChanged(NameOf(Weight))
        End Set
    End Property

    Public Property BloodType As String
        Get
            Return _BloodType
        End Get
        Set(value As String)
            _BloodType = value
            OnPropertyChanged(NameOf(BloodType))
        End Set
    End Property

    Public Property Allergies As String
        Get
            Return _Allergies
        End Get
        Set(value As String)
            _Allergies = value
            OnPropertyChanged(NameOf(Allergies))
        End Set
    End Property

    Public ReadOnly Property Fullname As String
        Get
            Return _FirstName & " " & _LastName
        End Get
    End Property

End Class

Public Class ObservePatient
    Inherits ObservableCollection(Of PatientList)



End Class
