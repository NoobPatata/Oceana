Imports System.Collections.ObjectModel
Public Class PrescriptionTreatments

    Inherits PropertyChanged

    Private _PrescriptionID As Integer
    Private _TreatmentName As String
    Private _TreatmentID As Integer
    Private _Description As String

    Public Property PrescriptionID As String
        Get
            Return _PrescriptionID
        End Get
        Set(value As String)
            _PrescriptionID = value
            OnPropertyChanged(PrescriptionID)
        End Set
    End Property

    Public Property TreatmentID As Integer
        Get
            Return _TreatmentID
        End Get
        Set(value As Integer)
            _TreatmentID = value
            OnPropertyChanged(TreatmentID)
        End Set
    End Property

    Public Property Description As String
        Get
            Return _Description
        End Get
        Set(value As String)
            _Description = value
            OnPropertyChanged(NameOf(Description))
        End Set
    End Property

    Public Property TreatmentName As String
        Get
            Return _TreatmentName
        End Get
        Set(value As String)
            _TreatmentName = value
            OnPropertyChanged(NameOf(TreatmentName))
        End Set
    End Property

End Class

Public Class ObservablePrescriptionTreatments
    Inherits ObservableCollection(Of PrescriptionTreatments)
End Class