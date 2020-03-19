Public Class AddPatientViewModel

    Inherits PropertyChanged

    Public Property NewPatients As PatientList
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
            Return NewPatients.FirstName
        End Get
        Set(value As String)
            NewPatients.FirstName = value
            OnPropertyChanged(FN)
        End Set
    End Property

    Public Property LN As String
        Get
            Return NewPatients.LastName
        End Get
        Set(value As String)
            NewPatients.LastName = value
            OnPropertyChanged(LN)
        End Set
    End Property

    Public Property ID As String
        Get
            Return NewPatients.IdentificationNumber
        End Get
        Set(value As String)
            NewPatients.IdentificationNumber = value
            OnPropertyChanged(ID)
        End Set
    End Property

    Public Property AD As String
        Get
            Return NewPatients.CurrentAddress
        End Get
        Set(value As String)
            NewPatients.CurrentAddress = value
            OnPropertyChanged(AD)
        End Set
    End Property

    Public Property CN As String
        Get
            Return NewPatients.ContactNumber
        End Get
        Set(value As String)
            NewPatients.ContactNumber = value
            OnPropertyChanged(CN)
        End Set
    End Property

    Public Property EM As String
        Get
            Return NewPatients.Email
        End Get
        Set(value As String)
            NewPatients.Email = value
            OnPropertyChanged(EM)
        End Set
    End Property

    Public Property CM As String
        Get
            Return NewPatients.Height
        End Get
        Set(value As String)
            NewPatients.Height = value
            OnPropertyChanged(CM)
        End Set
    End Property

    Public Property KG As String
        Get
            Return NewPatients.Weight
        End Get
        Set(value As String)
            NewPatients.Weight = value
            OnPropertyChanged(KG)
        End Set
    End Property

    Public Property BT As String
        Get
            Return NewPatients.BloodType
        End Get
        Set(value As String)
            NewPatients.BloodType = value
            OnPropertyChanged(BT)
        End Set
    End Property

    Public Property AL As String
        Get
            Return NewPatients.Allergies
        End Get
        Set(value As String)
            NewPatients.Allergies = value
            OnPropertyChanged(AL)
        End Set
    End Property
End Class
