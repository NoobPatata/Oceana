Imports System.Collections.ObjectModel

Public Class DetailsID

    Inherits PropertyChanged
    Private _DID As Integer
    Private _Price As String


    Public Sub New(dID As Integer, price As String)
        _DID = dID
        _Price = price
    End Sub

    Public Property DID As Integer
        Get
            Return _DID
        End Get
        Set(value As Integer)
            _DID = value
            OnPropertyChanged(DID)
        End Set
    End Property

    Public Property Price As String
        Get
            Return _Price
        End Get
        Set(value As String)
            _Price = value
            OnPropertyChanged(Price)
        End Set
    End Property
End Class

Public Class ObservableDetailsID
    Inherits ObservableCollection(Of DetailsID)
End Class
