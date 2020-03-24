Imports System.Globalization
Public Class InputValidationRule
    Inherits ValidationRule

    Private _errorMessage As String

    Public Property ErrorMessage As String
        Get
            Return _errorMessage
        End Get
        Set(ByVal value As String)
            _errorMessage = value
        End Set
    End Property

    Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As CultureInfo) As ValidationResult

        Dim input As String = value


        If Not IsNumeric(input) Then
            Return New ValidationResult(False, Me.ErrorMessage)
        Else
            Return New ValidationResult(True, Nothing)
        End If
    End Function


End Class

