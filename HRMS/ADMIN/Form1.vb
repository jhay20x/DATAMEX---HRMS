Public Class Login
    Private Sub EyeButton_Click(sender As Object, e As EventArgs) Handles EyeButton.Click
        If PasswordTextBox.UseSystemPasswordChar = False Then
            PasswordTextBox.UseSystemPasswordChar = True
        Else
            PasswordTextBox.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim query = "SELECT Employees.EmployeeID, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName, Username, Password, IsAdmin FROM Employees WHERE Username = @Username AND Password = @Password"

        Prepare(query)
        AddParam("@Username", UsernameTextBox.Text)
        AddParam("@Password", PasswordTextBox.Text)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            If Not IsDBNull(row("IsAdmin")) Then
                MsgBox("Welcome " & row("EmployeeName") & "!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
                DashBoardForm.WelcomeText = "WELCOME!" & Environment.NewLine & row("EmployeeName")
                DashBoardForm.Show()
                Me.Close()
            Else
                MsgBox("Welcome " & row("EmployeeName") & "!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
                EmployeeDashBoard.WelcomeText = "WELCOME!" & Environment.NewLine & row("EmployeeName")
                EmployeeDashBoard.EmpName = row("EmployeeName")
                EmployeeDashBoard.EmpID = row("EmployeeID")
                EmployeeDashBoard.Show()
                Me.Close()
                'MsgBox("Employee accounts are prohibited in accessing the system. Please use the employee portal instead.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
                'UsernameTextBox.Text = ""
                'PasswordTextBox.Text = ""
                'UsernameTextBox.Select()
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

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
