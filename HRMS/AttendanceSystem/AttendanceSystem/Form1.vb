Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim EmpID As Long = TextBox1.Text
        Dim IsValid As Boolean
        Dim IsPresent As Boolean

        IsValid = CheckEmployeeID(EmpID)
        IsPresent = CheckAttendance(EmpID)

        If IsValid Then
            MsgBox("Employee ID is Valid")
            If IsPresent Then
                MsgBox("You already have a time in record.")
                CheckForTimeOut(EmpID)
            Else
                InsertAttendance(EmpID)
            End If
        Else
            MsgBox("Employee ID is not Valid")
        End If
        ResetTextFields()
    End Sub

    Public Sub ResetTextFields()
        TextBox1.Text = ""
        TextBox1.Select()
    End Sub
End Class
