Imports System.Collections.ObjectModel

Public Class PrescriptionDetails

    Inherits PropertyChanged
    Private _PrescriptionID As String
    Private _Hari As String
    Private _Disease As String
    Private _PFirstName As String
    Private _PLastName As String
    Private _DFirstName As String
    Private _DLastName As String
    Private _DFullname As String
    Private _PFullname As String



    Public Sub New(prescriptionID As String, hari As String, disease As String, pFirstName As String, pLastName As String, dFirstName As String, dLastName As String)
        _PrescriptionID = prescriptionID
        _Hari = hari
        _Disease = disease
        _PFirstName = pFirstName
        _PLastName = pLastName
        _DFirstName = dFirstName
        _DLastName = dLastName
    End Sub

    Public Property PrescriptionID As String
        Get
            Return _PrescriptionID
        End Get
        Set(value As String)
            _PrescriptionID = value
            OnPropertyChanged(NameOf(PrescriptionID))
        End Set
    End Property

    Public Property Hari As String
        Get
            Return _Hari
        End Get
        Set(value As String)
            _Hari = value
            OnPropertyChanged(NameOf(Hari))
        End Set
    End Property

    Public Property Disease As String
        Get
            Return _Disease
        End Get
        Set(value As String)
            _Disease = value
            OnPropertyChanged(NameOf(Disease))
        End Set
    End Property

    Public Property PFirstName As String
        Get
            Return _PFirstName
        End Get
        Set(value As String)
            _PFirstName = value
            OnPropertyChanged(NameOf(PFirstName))
            OnPropertyChanged(PFullname)
        End Set
    End Property

    Public Property PLastName As String
        Get
            Return _PLastName
        End Get
        Set(value As String)
            _PLastName = value
            OnPropertyChanged(NameOf(PLastName))
            OnPropertyChanged(PFullname)
        End Set
    End Property

    Public Property DFirstName As String
        Get
            Return _DFirstName
        End Get
        Set(value As String)
            _DFirstName = value
            OnPropertyChanged(NameOf(DFirstName))
            OnPropertyChanged(DFullname)
        End Set
    End Property

    Public Property DLastName As String
        Get
            Return _DLastName
        End Get
        Set(value As String)
            _DLastName = value
            OnPropertyChanged(NameOf(DLastName))
            OnPropertyChanged(DFullname)
        End Set
    End Property

    Public ReadOnly Property DFullname As String
        Get
            Return DFirstName + " " + DLastName
        End Get
    End Property

    Public ReadOnly Property PFullname As String
        Get
            Return PFirstName + " " + PLastName
        End Get
    End Property
End Class

Public Class ObservablePrescription
    Inherits ObservableCollection(Of PrescriptionDetails)
End Class
