Imports MaterialDesignThemes.Wpf
Public Class BillingTransition

    Dim msgQ As New SnackbarMessageQueue(TimeSpan.FromSeconds(3))

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        msgQ = MySnackbar.MessageQueue

    End Sub


    Private Sub btnSearch_Click(sender As Object, e As RoutedEventArgs) Handles btnSearch.Click
        'If IsNumeric(txtSearch.Text) Then
        If String.IsNullOrEmpty(txtSearch.Text) Then
            msgQ.Enqueue("Patient with the ID does not have and prescription!")
        Else
            Transitions.Transitioner.MoveNextCommand.Execute(Nothing, Nothing)
        End If
        'Else
        '    If String.IsNullOrEmpty(txtSearch.Text) Then
        '        msgQ.Enqueue("Patient with the name does not have and prescription!")
        '    Else
        '        Transitions.Transitioner.MoveNextCommand.Execute(Nothing, Nothing)
        '    End If

        'End If

    End Sub


End Class
