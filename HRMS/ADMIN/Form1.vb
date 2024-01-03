Public Class Login

    Private Sub EyeButton_Click(sender As Object, e As EventArgs) Handles EyeButton.Click
        If PasswordTextBox.PasswordChar = Nothing Then
            PasswordTextBox.PasswordChar = "*"
        Else
            PasswordTextBox.PasswordChar = ""
        End If
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim query = "SELECT CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName, Username, Password, IsAdmin FROM Employees WHERE Username = @Username AND Password = @Password"

        Prepare(query)
        AddParam("@Username", UsernameTextBox.Text)
        AddParam("@Password", PasswordTextBox.Text)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            If row("IsAdmin") = 1 Then
                MsgBox("Welcome " & row("EmployeeName") & "!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
                DashBoardForm.WelcomeText = "WELCOME!" & Environment.NewLine & row("EmployeeName")
                DashBoardForm.Show()
                Me.Close()
            Else
                MsgBox("Employee accounts are prohibited in accessing the system. Please use the employee portal instead.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
                UsernameTextBox.Text = ""
                PasswordTextBox.Text = ""
                UsernameTextBox.Select()
            End If
        Else
            MsgBox("Username or Password is incorrect. Please try again.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
            UsernameTextBox.Select()
        End If
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        UsernameTextBox.Text = ""
        PasswordTextBox.Text = ""
        UsernameTextBox.Select()
    End Sub
End Class
