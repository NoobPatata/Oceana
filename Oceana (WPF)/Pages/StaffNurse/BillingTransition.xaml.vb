Imports MaterialDesignThemes.Wpf
Public Class BillingTransition

    Dim msgQ As New SnackbarMessageQueue(TimeSpan.FromSeconds(3))
    Dim msgQ2 As New SnackbarMessageQueue(TimeSpan.FromSeconds(3))
    Dim _invoice As ObservableInvoice
    Dim _nurse As ObservableNurse
    Dim _details As ObservableInvoiceDetails

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        msgQ = MySnackbar.MessageQueue
        msgQ2 = MySnackbarTwo.MessageQueue
        _nurse = Me.Resources("nurse")
        _invoice = Me.Resources("Invoice")
        _details = Me.Resources("details")
        LoadNurse()

    End Sub

    Public Sub LoadNurse()
        _nurse.Clear()
        For Each nur As Nurse In gVars.Doctor.GetAllNurse()
            _nurse.Add(nur)
        Next
    End Sub

    'Transition to next slide if the patient have any invoices
    Private Sub btnSearch_Click(sender As Object, e As RoutedEventArgs) Handles btnSearch.Click
        If Not String.IsNullOrEmpty(txtSearch.Text) Then
            If IsNumeric(txtSearch.Text) Then
                GetByID()
            Else
                GetByName()
            End If

        Else

            msgQ.Enqueue("Please input PatientID or Patient Name")

        End If

        If _invoice.Count = 0 Then
            msgQ.Enqueue("Patient do not have any invoice")
        Else
            txtSearch.Clear()
            Transitions.Transitioner.MoveNextCommand.Execute(Nothing, Nothing)
        End If

    End Sub

    'Search by patientID
    Public Sub GetByID()
        _invoice.Clear()
        For Each record As Invoice In gVars.Nurse.GetInvoiceByID(txtSearch.Text)
            _invoice.Add(record)
        Next
    End Sub

    'Search by patient name
    Public Sub GetByName()
        _invoice.Clear()
        For Each record As Invoice In gVars.Nurse.GetInvoiceByName(txtSearch.Text)
            _invoice.Add(record)
        Next
    End Sub

    'Calculate the balance 
    Private Sub txtPayment_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtPayment.TextChanged

        txtBalance.Text = Val(txtPayment.Text) - Val(txtAmount.Text)

    End Sub

    'load the information when user click the list view
    Private Sub lvInvoices_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles lvInvoices.SelectionChanged

        Dim invoice As List(Of Invoice) = Converter.SelectedItemToListOfInvoice(lvInvoices.SelectedItems)

        For Each Invoices In invoice

            _details.Clear()

            For Each info As InvoiceDetails In (gVars.Nurse.GetInvoiceDetails(Invoices.InvoiceID))
                _details.Add(info)
            Next

        Next

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.Key = Key.Enter Then
            btnSearch_Click(sender, Nothing)
        End If
    End Sub

    'update the data in the invoice
    Private Async Sub btnCheckout_Click(sender As Object, e As RoutedEventArgs) Handles btnCheckout.Click

        Dim invoice As List(Of Invoice) = Converter.SelectedItemToListOfInvoice(lvInvoices.SelectedItems)

        If txtAmount.Text > txtPayment.Text Then
            msgQ2.Enqueue("Please make sure that the payment is done!")
        Else

            For Each details In invoice

                Dim result As Boolean = Await DialogHost.Show(UpdateInvoiceDialog, "RootDialog")
                If result = True Then

                    If gVars.Nurse.UpdateInvoice(txtPayment.Text, txtBalance.Text, gVars.Doctor.GetStaffID(cbbNurse.Text), details.InvoiceID) > 0 Then
                        msgQ2.Enqueue("Succesfully update the invoice with the ID " + details.InvoiceID.ToString)
                    Else
                        msgQ2.Enqueue("Failed to update the invoice with the ID " + details.InvoiceID.ToString)
                    End If

                End If

            Next

        End If
    End Sub

End Class