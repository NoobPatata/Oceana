Imports System.Collections.ObjectModel

Public Class Treatment
    Inherits PropertyChanged

    Private _TreatmentID As String
    Private _TreatmentType As String
    Private _Name As String
    Private _Price As Integer


    Sub New(__TreatmentID As String, __TreatmentType As String, __Name As String, __Price As Integer)
        _TreatmentID = __TreatmentID
        _TreatmentType = __TreatmentType
        _Name = __Name
        _Price = __Price
    End Sub

    Public Property TreatmentID As String
        Get
            Return _TreatmentID
        End Get
        Set(value As String)
            _TreatmentID = value
            OnPropertyChanged(NameOf(TreatmentID))
        End Set
    End Property

    Public Property TreatmentType As String
        Get
            Return _TreatmentType
        End Get
        Set(value As String)
            _TreatmentType = value
            OnPropertyChanged(NameOf(TreatmentType))
        End Set
    End Property

    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
            OnPropertyChanged(NameOf(Name))
        End Set
    End Property

    Public Property Price As Integer
        Get
            Return _Price
        End Get
        Set(value As Integer)
            _Price = value
            OnPropertyChanged(Price)
        End Set
    End Property
End Class

Public Class ObserveTreatment
    Inherits ObservableCollection(Of Treatment)
End Class
