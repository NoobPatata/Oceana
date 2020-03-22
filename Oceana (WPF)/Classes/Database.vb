Imports System.Data.OleDb
Public Class database

    Private Shared dbProvider As String = "PROVIDER= Microsoft.JET.OLEDB.4.0;"
    Private Shared dbSource As String = "Data Source = Oceana.mdb"
    Public Shared ConnectionString As String = dbProvider & dbSource


End Class

Public Class AdminDB

    Public Function GetAllUsers() As List(Of LoginUsers)
        Dim users As New List(Of LoginUsers)
        Dim GetUsers As String = "SELECT * FROM LoginUser;"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetUsers, Conn)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader()
            While reader.Read()
                users.Add(New LoginUsers(reader("UserId"), reader("FirstName"), reader("LastName"), reader("ContactNumber").ToString, reader("Email"), reader("Username"), reader("Password"), reader("UserGroup")))
            End While
            Return users
        End Using
    End Function

    Public Function InsertNewUser(user As LoginUsers) As Integer

        Using conn As New OleDbConnection(database.ConnectionString)
            conn.Open()
            Dim insertNewUserQuery As String =
                        "insert into LoginUser ([FirstName],[LastName],[Email],[Username],[Password],[UserGroup]) VALUES (@Firstname,@Lastname,@Email,@Username,@Password,@UserGroup); "
            Dim cmd As New OleDbCommand(insertNewUserQuery, conn)
            cmd.Parameters.AddWithValue("@Firstname", user.FirstName)
            cmd.Parameters.AddWithValue("@Lastname", user.LastName)
            cmd.Parameters.AddWithValue("@Email", user.Email)
            cmd.Parameters.AddWithValue("@Username", user.Username)
            cmd.Parameters.AddWithValue("@Password", user.Password)
            cmd.Parameters.AddWithValue("@UserGroup", user.UserGroup)
            Dim i As Integer = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        End Using
    End Function

    Public Function RemoveUsers(_users As List(Of LoginUsers)) As Integer
        Using conn As New OleDbConnection(database.ConnectionString)
            conn.Open()
            Dim removeUserQuery As String = "DELETE FROM LoginUser WHERE userId IN ("
            For Each user As LoginUsers In _users
                If user.UserID = _users.Last.UserID Then
                    removeUserQuery += user.UserID.ToString + ");"
                Else
                    removeUserQuery += user.UserID.ToString + ","
                End If
            Next
            Dim cmd As New OleDbCommand(removeUserQuery, conn)
            Dim i = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        End Using
    End Function

    Public Function UpdateUser(user As LoginUsers) As Integer
        Using conn As New OleDbConnection(database.ConnectionString)
            Dim updateUserQuery As String = "UPDATE LoginUser SET LoginUser.FirstName = @Firstname,  LoginUser.LastName = @Lastname, LoginUser.Username= @Username, LoginUser.Password = @Password, LoginUser.Email = @Email, LoginUser.UserGroup = @UserGroup WHERE LoginUser.UserId = @userId"
            Dim cmd As New OleDbCommand(updateUserQuery, conn)
            cmd.Parameters.AddWithValue("@Firstname", user.FirstName)
            cmd.Parameters.AddWithValue("@Lastname", user.LastName)
            cmd.Parameters.AddWithValue("@Username", user.Username)
            cmd.Parameters.AddWithValue("@Password", user.Password)
            cmd.Parameters.AddWithValue("@Email", user.Email)
            cmd.Parameters.AddWithValue("@UserGroup", user.UserGroup)
            cmd.Parameters.AddWithValue("@userId", user.UserID)
            conn.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        End Using
    End Function

    Public Function InsertNewProfile(user As LoginUsers) As Integer
        Dim i As Integer

        If user.UserGroup = "Doctor" Then

            Using conn As New OleDbConnection(database.ConnectionString)
                conn.Open()
                Dim insertNewUserDoctorQuery As String =
                        "insert into Doctor ([FirstName],[LastName],[Email],[UserID]) SELECT [FirstName],[LastName],[Email],[UserID] FROM LoginUser WHERE UserID = (Select MAX(UserID) From LoginUser);"
                Dim cmd As New OleDbCommand(insertNewUserDoctorQuery, conn)
                i = cmd.ExecuteNonQuery()
                conn.Close()
                Return i
            End Using

        ElseIf user.UserGroup = "Nurse" Then

            Using conn As New OleDbConnection(database.ConnectionString)
                conn.Open()
                Dim insertNewUserDoctorQuery As String =
                        "insert into Nurse ([FirstName],[LastName],[Email],[UserID]) SELECT [FirstName],[LastName],[Email],[UserID] FROM LoginUser WHERE UserID = (Select MAX(UserID) From LoginUser); "
                Dim cmd As New OleDbCommand(insertNewUserDoctorQuery, conn)
                i = cmd.ExecuteNonQuery()
                conn.Close()
                Return i
            End Using
        End If

        Return i

    End Function

    Public Function RemoveDoctor(_users As List(Of LoginUsers)) As Integer
        Using conn As New OleDbConnection(database.ConnectionString)
            conn.Open()
            Dim removeUserQuery As String = "DELETE FROM Doctor WHERE UserID IN ("
            For Each user As LoginUsers In _users
                If user.UserID = _users.Last.UserID Then
                    removeUserQuery += user.UserID.ToString + ");"
                Else
                    removeUserQuery += user.UserID.ToString + ","
                End If
            Next
            Dim cmd As New OleDbCommand(removeUserQuery, conn)
            Dim i = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        End Using
    End Function

    Public Function RemoveNurse(_users As List(Of LoginUsers)) As Integer
        Using conn As New OleDbConnection(database.ConnectionString)
            conn.Open()
            Dim removeNurseQuery As String = "DELETE FROM Nurse WHERE UserID IN ("
            For Each user As LoginUsers In _users
                If user.UserID = _users.Last.UserID Then
                    removeNurseQuery += user.UserID.ToString + ");"
                Else
                    removeNurseQuery += user.UserID.ToString + ","
                End If
            Next
            Dim cmd As New OleDbCommand(removeNurseQuery, conn)
            Dim i = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        End Using
    End Function

End Class

Public Class DoctorDB


    'Get Patient Past prescription by Patient Firstname or Lastname
    Public Function GetPatientPrescription(nama As String)
        Dim Prescription As New List(Of PrescriptionDetails)
        Dim GetPrescription As String = "SELECT Prescription.PrescriptionID , Prescription.Date , Prescription.Disease , Prescription.DoctorID , Prescription.PatientId , Patient.FirstName , Patient.LastName , Doctor.FirstName , Doctor.LastName
FROM (Prescription INNER JOIN Doctor ON Prescription.DoctorID = Doctor.DoctorID) INNER JOIN Patient ON Prescription.PatientID = Patient.PatientID 
WHERE Patient.FirstName = @FN OR Patient.LastName = @LN;"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetPrescription, Conn)
            Cmd.Parameters.AddWithValue("@FN", nama)
            Cmd.Parameters.AddWithValue("@LN", nama)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader()
            While reader.Read()
                Prescription.Add(New PrescriptionDetails(reader("PrescriptionID"),
                    reader("Date"),
                    reader("Disease"),
                    reader("DoctorID"),
                    reader("PatientID"),
                    reader("Patient.FirstName"),
                    reader("Patient.LastName"),
                    reader("Doctor.FirstName"),
                    reader("Doctor.LastName")))
            End While
            Return Prescription
        End Using

    End Function

    'Get Patient Past prescription by Patient ID
    Public Function GetPatientPrescriptionByID(ID As Integer)
        Dim Prescription As New List(Of PrescriptionDetails)
        Dim GetPrescription As String = "SELECT Prescription.PrescriptionID , Prescription.Date , Prescription.Disease , Prescription.DoctorID , Prescription.PatientId , Patient.FirstName , Patient.LastName , Doctor.FirstName , Doctor.LastName
FROM (Prescription INNER JOIN Doctor ON Prescription.DoctorID = Doctor.DoctorID) INNER JOIN Patient ON Prescription.PatientID = Patient.PatientID WHERE
Patient.PatientID = @ID;
"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetPrescription, Conn)
            Cmd.Parameters.AddWithValue("@ID", ID)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader()
            While reader.Read()
                Prescription.Add(New PrescriptionDetails(reader("PrescriptionID"),
                    reader("Date"),
                    reader("Disease"),
                    reader("DoctorID"),
                    reader("PatientID"),
                    reader("Patient.FirstName"),
                    reader("Patient.LastName"),
                    reader("Doctor.FirstName"),
                    reader("Doctor.LastName")))
            End While
            Return Prescription
        End Using

    End Function

    'Load the data base on Patient ID
    Public Function GetPatientByID(name As Integer) As List(Of PatientList)
        Dim Patients As New List(Of PatientList)
        Dim GetPatients As String = "SELECT * FROM Patient WHERE PatientID = @ID;"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetPatients, Conn)
            Cmd.Parameters.AddWithValue("@ID", name)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader()

            While reader.Read()
                Patients.Add(New PatientList(reader("PatientID"),
                    reader("FirstName"),
                    reader("LastName"),
                    reader("IdentificationNumber"),
                    reader("CurrentAddress"),
                    reader("ContactNumber"),
                    reader("Email"),
                    reader("Height"),
                    reader("Weight"),
                    reader("BloodType"),
                    reader("Allergies")))
            End While
            Return Patients
        End Using
    End Function

    'Load data based on Patient Firstname or Lastname
    Public Function GetPatientDetails(name As String) As List(Of PatientList)
        Dim Patients As New List(Of PatientList)
        Dim GetPatients As String = "SELECT * FROM Patient WHERE FirstName = @FN OR LastName = @LN;"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetPatients, Conn)
            Cmd.Parameters.AddWithValue("@FN", name)
            Cmd.Parameters.AddWithValue("@LN", name)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader()

            While reader.Read()
                Patients.Add(New PatientList(reader("PatientID"),
                    reader("FirstName"),
                    reader("LastName"),
                    reader("IdentificationNumber"),
                    reader("CurrentAddress"),
                    reader("ContactNumber"),
                    reader("Email"),
                    reader("Height"),
                    reader("Weight"),
                    reader("BloodType"),
                    reader("Allergies")))
            End While
            Return Patients
        End Using
    End Function

    'Get all the treatment available
    Public Function GetAllTreatment() As List(Of Treatment)
        Dim treatment As New List(Of Treatment)
        Dim GetTreatment As String = "SELECT * FROM Treatment;"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetTreatment, Conn)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader()
            While reader.Read()
                treatment.Add(New Treatment(reader("TreatmentID"), reader("TreatmentType"), reader("Name"), CInt(reader("Price"))))
            End While
            Return treatment
        End Using
    End Function

    'Get the details in each prescription
    Public Function GetPrescriptionDetails(ID As String) As List(Of MedicalRecordDetails)
        Dim Prescription As New List(Of MedicalRecordDetails)
        Dim GetPrescription As String = "SELECT Treatment.Name , [Prescription Details].Description , Doctor.FirstName + ' ' + Doctor.LastName as [Doctor Incharge]
FROM ((([Prescription Details] INNER JOIN Treatment ON [Prescription Details].TreatmentID = Treatment.TreatmentID) INNER JOIN Prescription ON [Prescription Details].PrescriptionID = Prescription.PrescriptionID) INNER JOIN Patient ON Prescription.PatientID = Patient.PatientID) INNER JOIN Doctor ON Prescription.DoctorID = Doctor.DoctorID Where Prescription.PrescriptionID = @ID;
"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetPrescription, Conn)
            Cmd.Parameters.AddWithValue("@ID", ID)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader()
            While reader.Read()
                Prescription.Add(New MedicalRecordDetails(reader("Name"),
                    reader("Description"),
                    reader("Doctor Incharge")))
            End While
            Return Prescription
        End Using

    End Function

    'Get all the doctor
    Public Function GetAllDoctor() As List(Of Doctor)
        Dim doc As New List(Of Doctor)
        Dim GetUsers As String = "SELECT * FROM Doctor;"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetUsers, Conn)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader()
            While reader.Read()
                doc.Add(New Doctor(reader("DoctorID"), reader("FirstName"), reader("LastName"), reader("IdentificationNumber"), reader("ContactNumber").ToString, reader("Email"), reader("Address")))
            End While
            Return doc
        End Using
    End Function

    'Create new prescription
    Public Function InsertNewPrescription(pesakit As String, doctor As String) As Integer
        Using conn As New OleDbConnection(database.ConnectionString)
            conn.Open()
            Dim InsertNewPrescriptionQuery As String =
                        "Insert INTO Prescription ([PatientID] , [DoctorID] ) Select PatientID , DoctorID FROM [Doctor] , [Patient] WHERE  Patient.FirstName = @patient AND Doctor.FirstName = @doctor  ;"
            Dim cmd As New OleDbCommand(InsertNewPrescriptionQuery, conn)
            cmd.Parameters.AddWithValue("@patient", pesakit)
            cmd.Parameters.AddWithValue("@doctor", doctor)
            Dim i As Integer
            i = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        End Using

    End Function

    'Insert the date and disease into prescription table
    Public Function AddDateAndDisease(hari As String, disease As String) As Integer
        Using conn As New OleDbConnection(database.ConnectionString)
            conn.Open()
            Dim InsertDateAndDisease As String =
                        "UPDATE  Prescription Set [Date] = @hari , [Disease] = @sakit WHERE PrescriptionID = (Select MAX(PrescriptionID) from Prescription)"
            Dim cmd As New OleDbCommand(InsertDateAndDisease, conn)
            cmd.Parameters.AddWithValue("@hari", hari)
            cmd.Parameters.AddWithValue("@sakit", disease)
            Dim i As Integer
            i = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        End Using

    End Function

    'Insert data into Invoice table
    Public Function CreateNewInvoice() As Integer
        Using conn As New OleDbConnection(database.ConnectionString)
            conn.Open()
            Dim InsertNewInvoice As String =
                        "INSERT INTO Invoice ([PatientID] , [Date]) Select [PatientID] , [Date]  from Prescription Where PrescriptionID = (Select MAX(PrescriptionID) from Prescription )"
            Dim cmd As New OleDbCommand(InsertNewInvoice, conn)
            Dim i As Integer
            i = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        End Using

    End Function

End Class


Public Class StaffNurseDB

    Public Function InsertNewPatient(patient As PatientList) As Integer

        Using conn As New OleDbConnection(database.ConnectionString)
            conn.Open()
            Dim insertNewUserQuery As String =
                        "insert into Patient ([FirstName],[LastName],[IdentificationNumber],[CurrentAddress],[ContactNumber],[Email],[Height],[Weight],[BloodType],[Allergies]) VALUES (@Firstname,@Lastname,@ID,@Address,@Contact,@Email,@Height,@Weight,@Blood,@Allergies); "
            Dim cmd As New OleDbCommand(insertNewUserQuery, conn)
            cmd.Parameters.AddWithValue("@Firstname", patient.FirstName)
            cmd.Parameters.AddWithValue("@Lastname", patient.LastName)
            cmd.Parameters.AddWithValue("@ID", patient.IdentificationNumber)
            cmd.Parameters.AddWithValue("@Address", patient.CurrentAddress)
            cmd.Parameters.AddWithValue("@Contact", patient.ContactNumber)
            cmd.Parameters.AddWithValue("@Email", patient.Email)
            cmd.Parameters.AddWithValue("@Height", patient.Height)
            cmd.Parameters.AddWithValue("@Weight", patient.Weight)
            cmd.Parameters.AddWithValue("@Blood", patient.BloodType)
            cmd.Parameters.AddWithValue("@Allergies", patient.Allergies)
            Dim i As Integer = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        End Using
    End Function

    Public Function RemovePatient(_patient As List(Of PatientList)) As Integer
        Using conn As New OleDbConnection(database.ConnectionString)
            conn.Open()
            Dim removeUserQuery As String = "DELETE FROM Patient WHERE PatientID IN ("
            For Each patient As PatientList In _patient
                If patient.PatientID = _patient.Last.PatientID Then
                    removeUserQuery += patient.PatientID.ToString + ");"
                Else
                    removeUserQuery += patient.PatientID.ToString + ","
                End If
            Next
            Dim cmd As New OleDbCommand(removeUserQuery, conn)
            Dim i = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        End Using
    End Function

    Public Function UpdatePatient(patient As PatientList) As Integer
        Using conn As New OleDbConnection(database.ConnectionString)
            Dim updatePatientQuery As String = "UPDATE Patient SET Patient.FirstName = @Firstname,  Patient.LastName = @Lastname, Patient.IdentificationNumber= @ID, Patient.CurrentAddress = @AD, Patient.ContactNumber = @CN, Patient.Email = @Email, Patient.Height = @Height, Patient.Weight = @Weight, Patient.BloodType = @BT, Patient.Allergies = @AL WHERE Patient.PatientID = @PID"
            Dim cmd As New OleDbCommand(updatePatientQuery, conn)
            cmd.Parameters.AddWithValue("@Firstname", patient.FirstName)
            cmd.Parameters.AddWithValue("@Lastname", patient.LastName)
            cmd.Parameters.AddWithValue("@ID", patient.IdentificationNumber)
            cmd.Parameters.AddWithValue("@AD", patient.CurrentAddress)
            cmd.Parameters.AddWithValue("@CN", patient.ContactNumber)
            cmd.Parameters.AddWithValue("@Email", patient.Email)
            cmd.Parameters.AddWithValue("@Height", patient.Height)
            cmd.Parameters.AddWithValue("@Weight", patient.Weight)
            cmd.Parameters.AddWithValue("@BT", patient.BloodType)
            cmd.Parameters.AddWithValue("@AL", patient.Allergies)
            cmd.Parameters.AddWithValue("@PID", patient.PatientID)
            conn.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        End Using
    End Function

    Public Function GetAllPatients() As List(Of PatientList)
        Dim Patients As New List(Of PatientList)
        Dim GetPatients As String = "SELECT * FROM Patient;"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetPatients, Conn)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader()
            While reader.Read()
                Patients.Add(New PatientList(reader("PatientID"),
                    reader("FirstName"),
                    reader("LastName"),
                    reader("IdentificationNumber"),
                    reader("CurrentAddress"),
                    reader("ContactNumber"),
                    reader("Email"),
                    reader("Height"),
                    reader("Weight"),
                    reader("BloodType"),
                    reader("Allergies")))
            End While
            Return Patients
        End Using
    End Function



End Class