
Imports System.Collections.ObjectModel

Public Class PrescriptionList
    Inherits PropertyChanged
    Private _PrescriptionID As String
    Private _Hari As String
    Private _PatientID As String
    Private _Disease As String
    Private _DoctorID As String
    Private _Doctor_FirstName As String
    Private _Doctor_LastName As String
    Private _Patient_FirstName As String
    Private _Patient_LastName As String
    Private _DoctorFullName As String
    Private _PatientFullName As String

    Public Sub New(prescriptionID As String, hari As String, patientID As String, disease As String, doctorID As String, doctor_FirstName As String, doctor_LastName As String, patient_FirstName As String, patient_LastName As String)
        _PrescriptionID = prescriptionID
        _Hari = hari
        _PatientID = patientID
        _Disease = disease
        _DoctorID = doctorID
        _Doctor_FirstName = doctor_FirstName
        _Doctor_LastName = doctor_LastName
        _Patient_FirstName = patient_FirstName
        _Patient_LastName = patient_LastName
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

    Public Property PatientID As String
        Get
            Return _PatientID
        End Get
        Set(value As String)
            _PatientID = value
            OnPropertyChanged(NameOf(PatientID))
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

    Public Property DoctorID As String
        Get
            Return _DoctorID
        End Get
        Set(value As String)
            _DoctorID = value
            OnPropertyChanged(NameOf(DoctorID))
        End Set
    End Property





    Public Property Doctor_FirstName As String
        Get
            Return _Doctor_FirstName
        End Get
        Set(value As String)
            _Doctor_FirstName = value
            OnPropertyChanged(NameOf(Doctor_FirstName))
            OnPropertyChanged(DoctorFullname)
        End Set
    End Property

    Public Property Doctor_LastName As String
        Get
            Return _Doctor_LastName
        End Get
        Set(value As String)
            _Doctor_LastName = value
            OnPropertyChanged(NameOf(Doctor_LastName))
            OnPropertyChanged(DoctorFullName)
        End Set
    End Property

    Public Property Patient_FirstName As String
        Get
            Return _Patient_FirstName
        End Get
        Set(value As String)
            _Patient_FirstName = value
            OnPropertyChanged(NameOf(Patient_FirstName))
            OnPropertyChanged(PatientFullName)
        End Set
    End Property

    Public Property Patient_LastName As String
        Get
            Return _Patient_LastName
        End Get
        Set(value As String)
            _Patient_LastName = value
            OnPropertyChanged(NameOf(Patient_LastName))
            OnPropertyChanged(PatientFullName)
        End Set
    End Property

    Public ReadOnly Property DoctorFullName As String
        Get
            Return _Doctor_FirstName + " " + _Doctor_LastName
        End Get

    End Property

    Public ReadOnly Property PatientFullName As String
        Get
            Return _Patient_FirstName + " " + _Patient_LastName
        End Get

    End Property
End Class
Public Class ObservePrescription
    Inherits ObservableCollection(Of PrescriptionList)
End Class