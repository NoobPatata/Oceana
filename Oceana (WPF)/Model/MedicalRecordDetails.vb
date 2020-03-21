Public Class MedicalRecordDetails

    Inherits PropertyChanged

    Private _Nama As String
    Private _Description As String
    Private _DoctorIncharge As String
    Public v As Object

    'copy here . double check if need change anything 
    Public Sub New(v As Object)
        Me.v = v
    End Sub

    Public Sub New(nama As String, description As String, doctorIncharge As String)
        Me.Nama = nama
        Me.Description = description
        Me.DoctorIncharge = doctorIncharge
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

    Public Property Description As String
        Get
            Return _Description
        End Get
        Set(value As String)
            _Description = value
            OnPropertyChanged(NameOf(Description))
        End Set
    End Property

    Public Property DoctorIncharge As String
        Get
            Return _DoctorIncharge
        End Get
        Set(value As String)
            _DoctorIncharge = value
            OnPropertyChanged(NameOf(DoctorIncharge))
        End Set
    End Property

End Class
