Imports System.Collections.ObjectModel

Public Class PrescriptionDetails

    Inherits PropertyChanged

    Private _hari As String
    Private _Disease As String
    Private _Description As String
    Private _Nama As String
    Private _DoctorFN As String
    Private _DoctorLN As String
    Private _PatientFN As String
    Private _PatientLN As String
    Private _DoctorFullname As String
    Private _PatientFullname As String

    Public Sub New(hari As String, disease As String, description As String, nama As String, doctorFN As String, doctorLN As String, patientFN As String, patientLN As String)
        Me.Hari = hari
        Me.Disease = disease
        Me.Description = description
        Me.Nama = nama
        Me.DoctorFN = doctorFN
        Me.DoctorLN = doctorLN
        Me.PatientFN = patientFN
        Me.PatientLN = patientLN
    End Sub

    Public Sub New(ByVal _prescriptionObject As Object)
        Dim x As PrescriptionDetails = _prescriptionObject
        Hari = x.Hari
        Disease = x.Disease
        Description = x.Description
        Nama = x.Nama
        DoctorFN = x.DoctorFN
        DoctorLN = x.DoctorLN
        PatientFN = x.PatientFN
        PatientLN = x.PatientLN
    End Sub

    Public Property Hari As String
        Get
            Return _hari
        End Get
        Set(value As String)
            _hari = value
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

    Public Property Description As String
        Get
            Return _Description
        End Get
        Set(value As String)
            _Description = value
            OnPropertyChanged(NameOf(Description))
        End Set
    End Property

    Public Property Nama As String
        Get
            Return _Nama
        End Get
        Set(value As String)
            _Nama = value
            OnPropertyChanged(NameOf(Nama))
        End Set
    End Property

    Public Property DoctorFN As String
        Get
            Return _DoctorFN
        End Get
        Set(value As String)
            _DoctorFN = value
            OnPropertyChanged(NameOf(DoctorFN))
            OnPropertyChanged(DoctorFullname)
        End Set
    End Property

    Public Property DoctorLN As String
        Get
            Return _DoctorLN
        End Get
        Set(value As String)
            _DoctorLN = value
            OnPropertyChanged(NameOf(DoctorLN))
            OnPropertyChanged(DoctorFullname)
        End Set
    End Property

    Public Property PatientFN As String
        Get
            Return _PatientFN
        End Get
        Set(value As String)
            _PatientFN = value
            OnPropertyChanged(NameOf(PatientFN))
            OnPropertyChanged(PatientFullname)
        End Set
    End Property

    Public Property PatientLN As String
        Get
            Return _PatientLN
        End Get
        Set(value As String)
            _PatientLN = value
            OnPropertyChanged(NameOf(PatientLN))
            OnPropertyChanged(PatientFullname)
        End Set
    End Property

    Public ReadOnly Property DoctorFullname As String
        Get
            Return _DoctorFN + " " + _DoctorLN
        End Get

    End Property

    Public ReadOnly Property PatientFullname As String
        Get
            Return _PatientFN + " " + _PatientLN
        End Get

    End Property
End Class

Public Class ObservablePrescription
    Inherits ObservableCollection(Of PrescriptionDetails)
End Class
