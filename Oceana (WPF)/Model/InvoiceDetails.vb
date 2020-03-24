Imports System.Collections.ObjectModel

Public Class InvoiceDetails


    Inherits PropertyChanged
    Private _Nama As String
    Private _Price As Integer

    Public Sub New(nama As String, price As Integer)
        _Nama = nama
        _Price = price
    End Sub

    Public Property Nama As String
        Get
            Return _Nama
        End Get
        Set(value As String)
            _Nama = value
            OnPropertyChanged(NameOf(Nama))
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

Public Class ObservableInvoiceDetails
    Inherits ObservableCollection(Of InvoiceDetails)
End Class