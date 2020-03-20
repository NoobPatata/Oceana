Imports System.Collections.ObjectModel

Public Class PrescriptionDetails

    Inherits PropertyChanged
    Private _PrescriptionID As String
    Private _Hari As String
    Private _Disease As String
    Private _Fullname As String

    Public Sub New(prescriptionID As String, hari As String, disease As String, fullname As String)
        _PrescriptionID = prescriptionID
        _Hari = hari
        _Disease = disease
        _Fullname = fullname
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

    Public Property Fullname As String
        Get
            Return _Fullname
        End Get
        Set(value As String)
            _Fullname = value
            OnPropertyChanged(NameOf(Fullname))
        End Set
    End Property
End Class

Public Class ObservablePrescription
    Inherits ObservableCollection(Of PrescriptionDetails)
End Class
