Public Class PatientInfoViewModel
    Inherits PropertyChanged

    Public Property EPatient As PatientList
    Private _FN As String
    Private _LN As String
    Private _ID As String
    Private _AD As String
    Private _CN As String
    Private _EM As String
    Private _CM As String
    Private _KG As String
    Private _BT As String
    Private _AL As String
    Public Property FN As String
        Get
            Return EPatient.FirstName
        End Get
        Set(value As String)
            EPatient.FirstName = value
            OnPropertyChanged(FN)
        End Set
    End Property

    Public Property LN As String
        Get
            Return EPatient.LastName
        End Get
        Set(value As String)
            EPatient.LastName = value
            OnPropertyChanged(LN)
        End Set
    End Property

    Public Property ID As String
        Get
            Return EPatient.IdentificationNumber
        End Get
        Set(value As String)
            EPatient.IdentificationNumber = value
            OnPropertyChanged(ID)
        End Set
    End Property

    Public Property AD As String
        Get
            Return EPatient.CurrentAddress
        End Get
        Set(value As String)
            EPatient.CurrentAddress = value
            OnPropertyChanged(AD)
        End Set
    End Property

    Public Property CN As String
        Get
            Return EPatient.ContactNumber
        End Get
        Set(value As String)
            EPatient.ContactNumber = value
            OnPropertyChanged(CN)
        End Set
    End Property

    Public Property EM As String
        Get
            Return EPatient.Email
        End Get
        Set(value As String)
            EPatient.Email = value
            OnPropertyChanged(EM)
        End Set
    End Property

    Public Property CM As String
        Get
            Return EPatient.Height
        End Get
        Set(value As String)
            EPatient.Height = value
            OnPropertyChanged(CM)
        End Set
    End Property

    Public Property KG As String
        Get
            Return EPatient.Weight
        End Get
        Set(value As String)
            EPatient.Weight = value
            OnPropertyChanged(KG)
        End Set
    End Property

    Public Property BT As String
        Get
            Return EPatient.BloodType
        End Get
        Set(value As String)
            EPatient.BloodType = value
            OnPropertyChanged(BT)
        End Set
    End Property

    Public Property AL As String
        Get
            Return EPatient.Allergies
        End Get
        Set(value As String)
            EPatient.Allergies = value
            OnPropertyChanged(AL)
        End Set
    End Property
End Class
