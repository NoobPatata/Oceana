Imports System.Collections.ObjectModel

Public Class DetailsID

    Inherits PropertyChanged
    Private _DID As Integer
    Private v As Object



    Public Sub New(dID As Integer)
        _DID = dID
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
End Class

Public Class ObservableDetailsID
    Inherits ObservableCollection(Of DetailsID)
End Class
