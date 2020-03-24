Imports System.Collections.ObjectModel
Public Class Invoice

    Inherits PropertyChanged

    Dim _InvoiceID As String
    Dim _StaffFN As String
    Dim _StaffLN As String
    Dim _Amount As Integer
    Dim _Paid As Integer
    Dim _Balance As Integer
    Dim _Fullname As String
    Dim _PaymentStatus As String

    Public Sub New(invoiceID As String, staffFN As String, staffLN As String, amount As Integer, paid As Integer, balance As Integer)
        _InvoiceID = invoiceID
        _StaffFN = staffFN
        _StaffLN = staffLN
        _Amount = amount
        _Paid = paid
        _Balance = balance
    End Sub


    Public Property InvoiceID As String
        Get
            Return _InvoiceID
        End Get
        Set(value As String)
            _InvoiceID = value
            OnPropertyChanged(InvoiceID)
        End Set
    End Property

    Public Property StaffFN As String
        Get
            Return _StaffFN
        End Get
        Set(value As String)
            _StaffFN = value
            OnPropertyChanged(NameOf(StaffFN))
        End Set
    End Property

    Public Property StaffLN As String
        Get
            Return _StaffLN
        End Get
        Set(value As String)
            _StaffLN = value
            OnPropertyChanged(NameOf(StaffLN))
        End Set
    End Property

    Public ReadOnly Property PaymentStatus As String
        Get
            Dim status As String
            If _Amount > _Paid Then
                status = "Overdue"
            Else
                status = "Paid"
            End If
            Return status
        End Get

    End Property

    Public Property Amount As Integer
        Get
            Return _Amount
        End Get
        Set(value As Integer)
            _Amount = value
            OnPropertyChanged(Amount)
            OnPropertyChanged(PaymentStatus)
            OnPropertyChanged(Balance)
        End Set
    End Property

    Public Property Paid As Integer
        Get
            Return _Paid
        End Get
        Set(value As Integer)
            _Paid = value
            OnPropertyChanged(Paid)
            OnPropertyChanged(PaymentStatus)
            OnPropertyChanged(Balance)
        End Set
    End Property

    Public ReadOnly Property Fullname As String
        Get
            Return _StaffFN + " " + _StaffLN
        End Get
    End Property

    Public Property Balance As Integer
        Get
            Return _Balance
        End Get
        Set(value As Integer)
            _Balance = value
            OnPropertyChanged(Balance)

        End Set
    End Property
End Class

Public Class ObservableInvoice
    Inherits ObservableCollection(Of Invoice)
End Class
