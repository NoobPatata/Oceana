Imports System.Collections.ObjectModel

Public Class MedicalRecordViewModel

    Inherits PropertyChanged
    Public Property OutDetaills As MedicalRecordDetails
    Private _Med As String
    Private _Desc As String
    Private _x As Object

    Public Property Med As String
        Get
            Return OutDetaills.Nama
        End Get
        Set(value As String)
            OutDetaills.Nama = value
            OnPropertyChanged(Med)
        End Set
    End Property

    Public Property Desc As String
        Get
            Return OutDetaills.Description
        End Get
        Set(value As String)
            OutDetaills.Description = value
            OnPropertyChanged(Desc)
        End Set
    End Property

    Public Property X As Object
        Get
            Return OutDetaills.v
        End Get
        Set(value As Object)
            OutDetaills.v = value
            OnPropertyChanged(X)
        End Set
    End Property
End Class





Public Class ObservableMedicalRecord
    Inherits ObservableCollection(Of MedicalRecordViewModel)
End Class
