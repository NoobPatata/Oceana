Imports System.Data.OleDb

Public Class database

    Private Shared dbProvider As String = "PROVIDER= Microsoft.JET.OLEDB.4.0;"
    Private Shared dbSource As String = "Data Source = Oceana.mdb"
    Public Shared ConnectionString As String = dbProvider & dbSource


End Class

Public Class AdminDB

    'Get all the users in LoginUsers
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

    'Create new user
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

    'Remove a user
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

    'Update a user profile
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

    'Insert data into Doctor or Nurse from LoginUser
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

    'Remove the user from Doctor table also
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

    'Remove the user from Nurse table also
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

    'To check if the new user have same email as existing user
    Public Function GetUserByEmail(email As String) As LoginUsers
        Using SqlConn As New OleDbConnection(database.ConnectionString)
            Dim getUserQuery As String = "SELECT * FROM LoginUser WHERE Email = @email"
            Dim SqlCmd As New OleDbCommand(getUserQuery, SqlConn)
            SqlCmd.Parameters.AddWithValue("@email", email)
            SqlConn.Open()
            Dim reader As OleDbDataReader = SqlCmd.ExecuteReader()
            Dim selectedUser As LoginUsers = Nothing
            While reader.Read()
                selectedUser = New LoginUsers(reader("UserId"), reader("FirstName"), reader("LastName"), reader("ContactNumber").ToString, reader("Email"), reader("Username"), reader("Password"), reader("UserGroup"))
            End While
            Return selectedUser
        End Using
    End Function

    'To check if new user have the same username as existing user
    Public Function GetUserbyUsername(username As String) As LoginUsers
        Using SqlConn As New OleDbConnection(database.ConnectionString)
            Dim getUserQuery As String = "SELECT * FROM LoginUser WHERE Username = @username"
            Dim SqlCmd As New OleDbCommand(getUserQuery, SqlConn)
            SqlCmd.Parameters.AddWithValue("@username", username)
            SqlConn.Open()
            Dim reader As OleDbDataReader = SqlCmd.ExecuteReader()
            Dim selectedUser As LoginUsers = Nothing
            While reader.Read()
                selectedUser = New LoginUsers(reader("UserId"), reader("FirstName"), reader("LastName"), reader("ContactNumber").ToString, reader("Email"), reader("Username"), reader("Password"), reader("UserGroup"))
            End While
            Return selectedUser
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

    'Get the treatment ID based on the name of treatment
    Public Function GetTreatmentID(med As String)
        Dim value As String
        Dim GetTreatment As String = "SELECT TreatmentID FROM Treatment WHERE Name = @med;"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetTreatment, Conn)
            Cmd.Parameters.AddWithValue("@med", med)
            Conn.Open()
            value = Cmd.ExecuteScalar()
            Return value
        End Using
    End Function

    'Get the latest prescription ID
    Public Function GetPrescriptionID()
        Dim value As Integer
        Dim getID As String = "SELECT MAX(PrescriptionID) FROM Prescription;"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(getID, Conn)
            Conn.Open()
            value = Cmd.ExecuteScalar()
        End Using
        Return value
    End Function

    'Insert details into prescription Details
    Public Function InsertIntoPrescriptionDetails(PID As Integer, TID As Integer, Desc As String) As Integer
        Dim insertDetails As String = "INSERT INTO [Prescription Details] ( PrescriptionID , TreatmentID , Description ) values (@PID , @TID , @DESC) ;"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(insertDetails, Conn)
            Cmd.Parameters.AddWithValue("@PID", PID)
            Cmd.Parameters.AddWithValue("@TID", TID)
            Cmd.Parameters.AddWithValue("@DESC", Desc)
            Conn.Open()
            Dim i As Integer
            i = Cmd.ExecuteNonQuery()
            Return i
        End Using

    End Function

    'Get the latest invoice ID
    Public Function GetInvoiceID()
        Dim value As Integer
        Dim getID As String = "SELECT MAX([Invoice ID]) FROM Invoice;"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(getID, Conn)
            Conn.Open()
            value = Cmd.ExecuteScalar()
        End Using
        Return value
    End Function

    'Get the list of details ID in which match a prescription ID
    Public Function GetDetailsID(id As Integer) As List(Of DetailsID)
        Dim newDetailsID As New List(Of DetailsID)
        Dim getID As String = "SELECT [Prescription Details].DetailsID , Treatment.Price 
FROM [Prescription Details] INNER JOIN Treatment ON [Prescription Details].TreatmentID = Treatment.TreatmentID
WHERE ((([Prescription Details].PrescriptionID)= @ID))"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(getID, Conn)
            Cmd.Parameters.AddWithValue("@ID", id)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader
            While reader.Read()
                newDetailsID.Add(New DetailsID(reader("DetailsID"),
                                               reader("Price")))
            End While
            Return newDetailsID

        End Using

    End Function

    'Insert details into invoice details
    Public Function InsertIntoInvoiceDetails(IID As Integer, PID As Integer, RM As String) As Integer
        Dim insertDetails As String = "INSERT INTO [Invoice Details] ([InvoiceID], [DetailsID] , [Price] ) VALUES (@IID , @PID , @RM);"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(insertDetails, Conn)
            Cmd.Parameters.AddWithValue("@IID", IID)
            Cmd.Parameters.AddWithValue("@PID", PID)
            Cmd.Parameters.AddWithValue("@RM", RM)
            Conn.Open()
            Dim i As Integer
            i = Cmd.ExecuteNonQuery()
            Return i
        End Using

    End Function

    'Get the total price of the treatment
    Public Function GetTotalPrice()
        Dim value As Integer
        Dim getID As String = "SELECT Sum(Price) 
FROM [Invoice Details]
WHERE ((([Invoice Details].[InvoiceID])=(Select MAX([Invoice ID]) From Invoice)));
"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(getID, Conn)
            Conn.Open()
            value = Cmd.ExecuteScalar()
        End Using
        Return value
    End Function

    'Insert the total amount into invoice
    Public Function InsertTotalPrice(total As Integer)
        Dim value As Integer
        Dim getID As String = "UPDATE Invoice Set Amount = @total WHERE [Invoice ID] = (Select MAX([Invoice ID]) From Invoice)"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(getID, Conn)
            Cmd.Parameters.AddWithValue("@total", total)
            Conn.Open()
            value = Cmd.ExecuteScalar()
        End Using
        Return value
    End Function

End Class

Public Class StaffNurseDB

    'Create new patient
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

    'Remove Patient
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

    'Update patient information
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

    'Get a list of all Patient
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

    'Search patient invoice by ID
    Public Function GetInvoiceByID(nama As Integer)
        Dim invoice As New List(Of Invoice)
        Dim getInvoice As String = "SELECT Invoice.[Invoice ID], Nurse.FirstName, Nurse.LastName, Invoice.Amount, Invoice.Paid , Invoice.Balance
FROM (Nurse INNER JOIN Invoice ON Nurse.[Nurse ID] = Invoice.StaffID) INNER JOIN Patient ON Invoice.PatientID = Patient.PatientID
WHERE ((([Patient].[PatientID])= @ID));
"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(getInvoice, Conn)
            Cmd.Parameters.AddWithValue("@ID", nama)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader()
            While reader.Read()
                invoice.Add(New Invoice(reader("Invoice ID"),
                    reader("FirstName").ToString,
                    reader("LastName").ToString,
                    reader("Amount"),
                    reader("Paid").ToString,
                    reader("Balance").ToString))
            End While
            Return invoice
        End Using

    End Function

    'Search patient invoice by name
    Public Function GetInvoiceByName(nama As String)
        Dim invoice As New List(Of Invoice)
        Dim getInvoice As String = "SELECT Invoice.[Invoice ID], Nurse.FirstName, Nurse.LastName, Invoice.Amount, Invoice.Paid , Invoice.Balance
FROM (Nurse INNER JOIN Invoice ON Nurse.[Nurse ID] = Invoice.StaffID) INNER JOIN Patient ON Invoice.PatientID = Patient.PatientID
WHERE ((([Patient].[FirstName])= @FN) OR Patient.LastName = @LN);
"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(getInvoice, Conn)
            Cmd.Parameters.AddWithValue("@FN", nama)
            Cmd.Parameters.AddWithValue("@LN", nama)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader()
            While reader.Read()
                invoice.Add(New Invoice(reader("Invoice ID"),
                    reader("FirstName").ToString,
                    reader("LastName").ToString,
                    reader("Amount"),
                    reader("Paid").ToString,
                    reader("Balance").ToString))
            End While
            Return invoice
        End Using
    End Function

    'Get the details of invoice
    Public Function GetInvoiceDetails(id As Integer)
        Dim details As New List(Of InvoiceDetails)
        Dim GetDetails As String = "SELECT Treatment.Name, [Invoice Details].Price
FROM ([Prescription Details] INNER JOIN [Invoice Details] ON [Prescription Details].DetailsID = [Invoice Details].DetailsID) INNER JOIN Treatment ON [Prescription Details].TreatmentID = Treatment.TreatmentID WHERE [Invoice Details].[InvoiceID] = @ID;"
        Using Conn As New OleDbConnection(database.ConnectionString)
            Dim Cmd As New OleDbCommand(GetDetails, Conn)
            Cmd.Parameters.AddWithValue("@ID", id)
            Conn.Open()
            Dim reader As OleDbDataReader = Cmd.ExecuteReader
            While reader.Read()
                details.Add(New InvoiceDetails(reader("Name"), reader("Price")))
            End While
        End Using
        Return details
    End Function

    'Update the payment information
    Public Function UpdateInvoice(paid As String, balance As String, id As String) As Integer
        Using conn As New OleDbConnection(database.ConnectionString)
            conn.Open()
            Dim UpdatePayment As String =
                        "UPDATE INVOICE SET Paid = @paid , Balance = @balance Where [Invoice ID] = @ID;"
            Dim cmd As New OleDbCommand(UpdatePayment, conn)
            cmd.Parameters.AddWithValue("@paid", paid)
            cmd.Parameters.AddWithValue("@balance", balance)
            cmd.Parameters.AddWithValue("@ID", id)
            Dim i As Integer
            i = cmd.ExecuteNonQuery()
            conn.Close()
            Return i
        End Using

    End Function

    'To check if the patient have same email as existing patient
    Public Function GetPatientByEmail(email As String) As PatientList
        Using SqlConn As New OleDbConnection(database.ConnectionString)
            Dim getPatientQuery As String = "SELECT * FROM LoginUser WHERE Email = @email"
            Dim SqlCmd As New OleDbCommand(getPatientQuery, SqlConn)
            SqlCmd.Parameters.AddWithValue("@email", email)
            SqlConn.Open()
            Dim reader As OleDbDataReader = SqlCmd.ExecuteReader()
            Dim selectedpatient As PatientList = Nothing
            While reader.Read()
                selectedpatient = New PatientList(reader("PatientID"),
                    reader("FirstName"),
                    reader("LastName"),
                    reader("IdentificationNumber"),
                    reader("CurrentAddress"),
                    reader("ContactNumber"),
                    reader("Email"),
                    reader("Height"),
                    reader("Weight"),
                    reader("BloodType"),
                    reader("Allergies"))
            End While
            Return selectedpatient
        End Using
    End Function

    'To check if new have the same contact number as existing patient
    Public Function GetPatientByContactNumber(number As String) As PatientList
        Using SqlConn As New OleDbConnection(database.ConnectionString)
            Dim getPatientQuery As String = "SELECT * FROM Patient WHERE ContactNumber = @number"
            Dim SqlCmd As New OleDbCommand(getPatientQuery, SqlConn)
            SqlCmd.Parameters.AddWithValue("@number", number)
            SqlConn.Open()
            Dim reader As OleDbDataReader = SqlCmd.ExecuteReader()
            Dim selectedpatient As PatientList = Nothing
            While reader.Read()
                selectedpatient = New PatientList(reader("PatientID"),
                    reader("FirstName"),
                    reader("LastName"),
                    reader("IdentificationNumber"),
                    reader("CurrentAddress"),
                    reader("ContactNumber"),
                    reader("Email"),
                    reader("Height"),
                    reader("Weight"),
                    reader("BloodType"),
                    reader("Allergies"))
            End While
            Return selectedpatient
        End Using
    End Function

    'To check if new have the same identification as existing patient
    Public Function GetPatientByIC(ic As String) As PatientList
        Using SqlConn As New OleDbConnection(database.ConnectionString)
            Dim getPatientQuery As String = "SELECT * FROM Patient WHERE IdentificationNumber = @IC"
            Dim SqlCmd As New OleDbCommand(getPatientQuery, SqlConn)
            SqlCmd.Parameters.AddWithValue("@IC", ic)
            SqlConn.Open()
            Dim reader As OleDbDataReader = SqlCmd.ExecuteReader()
            Dim selectedpatient As PatientList = Nothing
            While reader.Read()
                selectedpatient = New PatientList(reader("PatientID"),
                    reader("FirstName"),
                    reader("LastName"),
                    reader("IdentificationNumber"),
                    reader("CurrentAddress"),
                    reader("ContactNumber"),
                    reader("Email"),
                    reader("Height"),
                    reader("Weight"),
                    reader("BloodType"),
                    reader("Allergies"))
            End While
            Return selectedpatient
        End Using
    End Function


End Class