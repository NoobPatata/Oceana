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

    Public Function GetAllPrescription() As List(Of PrescriptionDetails)
        Dim record As New List(Of PrescriptionDetails)
        Dim GetTreatment As String = "SELECT Prescription.Date , Prescription.Disease , [Prescription Details].Description, Treatment.Name , Doctor.FirstName , Doctor.LastName, Patient.FirstName , Patient.LastName
    FROM (((Prescription INNER JOIN [Prescription Details] ON Prescription.PrescriptionID = [Prescription Details].PrescriptionID) INNER JOIN Treatment ON [Prescription Details].TreatmentID = Treatment.TreatmentID) INNER JOIN Patient ON Prescription.PatientID = Patient.PatientID) INNER JOIN Doctor ON Prescription.DoctorID = Doctor.DoctorID;
    "
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetTreatment, Conn)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader()
            While reader.Read()
                record.Add(New PrescriptionDetails(reader("Date"), reader("Disease"), reader("Description"), reader("Name"), reader("Doctor.FirstName"), reader("Doctor.LastName"), reader("Patient.FirstName"), reader("Patient.LastName")))
            End While
            Return record
        End Using
    End Function

    Public Function GetPatientPrescription(fn As String) As List(Of PrescriptionDetails)
        Dim record As New List(Of PrescriptionDetails)
        Dim GetTreatment As String = "SELECT Prescription.Date , Prescription.Disease , [Prescription Details].Description, Treatment.Name , Doctor.FirstName , Doctor.LastName, Patient.FirstName , Patient.LastName
    FROM (((Prescription INNER JOIN [Prescription Details] ON Prescription.PrescriptionID = [Prescription Details].PrescriptionID) INNER JOIN Treatment ON [Prescription Details].TreatmentID = Treatment.TreatmentID) INNER JOIN Patient ON Prescription.PatientID = Patient.PatientID) INNER JOIN Doctor ON Prescription.DoctorID = Doctor.DoctorID WHERE Patient.FirstName = @FN OR Patient.LastName = @LN;
    "
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetTreatment, Conn)
            Cmd.Parameters.AddWithValue("@FN", fn)
            Cmd.Parameters.AddWithValue("@LN", fn)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader()
            While reader.Read()
                record.Add(New PrescriptionDetails(reader("Date"), reader("Disease"), reader("Description"), reader("Name"), reader("Doctor.FirstName"), reader("Doctor.LastName"), reader("Patient.FirstName"), reader("Patient.LastName")))
            End While
            Return record
        End Using
    End Function

    Public Function GetPatientDetails(FN As String, LN As String) As List(Of PatientList)
        Dim Patients As New List(Of PatientList)
        Dim GetPatients As String = "SELECT * FROM Patient WHERE FirstName = @FN OR LastName = @LN;"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetPatients, Conn)
            Cmd.Parameters.AddWithValue("@FN", FN)
            Cmd.Parameters.AddWithValue("@LN", LN)
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