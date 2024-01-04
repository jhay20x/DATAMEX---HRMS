Imports System.Runtime.CompilerServices
Imports System.Security.Permissions

Public Class UsersForm
    Public EmpID As String
    Public isDone As Boolean

    Private Sub UsersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadNames()
    End Sub

    Public Sub LoadNames()
        Dim query = "SELECT CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName FROM Employees"

        Prepare(query)
        ExecutePrepare()

        MUEmpNamesComboBox.DisplayMember = "EmployeeName"
        MUEmpNamesComboBox.DataSource = DataAsTable.DefaultView
    End Sub

    Private Sub UsersForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If isDone Then
            e.Cancel = False
            DashBoardForm.Enabled = True
            DashBoardForm.DisableButton()
            DashBoardForm.RefreshDetails()
            DashBoardForm.LRRefreshButton.PerformClick()
            DashBoardForm.Show()
        Else
            If MsgBox("Are you sure to leave?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                DashBoardForm.Enabled = True
                DashBoardForm.DisableButton()
                DashBoardForm.RefreshDetails()
                DashBoardForm.LRRefreshButton.PerformClick()
                DashBoardForm.Show()
            End If
        End If
    End Sub

    Private Sub MUBackButton_Click(sender As Object, e As EventArgs) Handles MUBackButton.Click
        Me.Close()
    End Sub

    Private Sub MUUserEyeButton_Click(sender As Object, e As EventArgs) Handles MUUserEyeButton.Click
        If MUUsernameTextBox.UseSystemPasswordChar = False Then
            MUUsernameTextBox.UseSystemPasswordChar = True
        Else
            MUUsernameTextBox.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub MUPasswordEyeButton_Click(sender As Object, e As EventArgs) Handles MUPasswordEyeButton.Click
        If MUPasswordTextBox.UseSystemPasswordChar = False Then
            MUPasswordTextBox.UseSystemPasswordChar = True
        Else
            MUPasswordTextBox.UseSystemPasswordChar = False
        End If
    End Sub

    Public Sub GetUser(Name As String)
        MUUsernameTextBox.Text = ""
        MUPasswordTextBox.Text = ""
        MUIsAdminComboBox.SelectedIndex = 0

        Dim query = "SELECT EmployeeID, Username, Password, IsAdmin FROM Employees 
        WHERE CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) LIKE @EmpName"

        Prepare(query)
        AddParam("@EmpName", "%" & Name & "%")
        ExecutePrepare()

        Dim row As DataRow = DataAsTable.Rows(0)
        EmpID = row("EmployeeID")

        If Not IsDBNull(row("Username")) Then
            MUUsernameTextBox.Text = row("Username")
        End If

        If Not IsDBNull(row("Username")) Then
            MUPasswordTextBox.Text = row("Password")
        End If

        If Not IsDBNull(row("IsAdmin")) Then
            MUIsAdminComboBox.SelectedIndex = row("IsAdmin")
        Else
            MUIsAdminComboBox.SelectedIndex = 0
        End If

        'Err.Raise(1)
    End Sub

    Private Sub MUEmpNamesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MUEmpNamesComboBox.SelectedIndexChanged
        GetUser(MUEmpNamesComboBox.Text)
    End Sub

    Private Sub MUAddButton_Click(sender As Object, e As EventArgs) Handles MUAddButton.Click
        If MsgBox("Add/update user account?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.Yes Then
            If MUUsernameTextBox.Text = "" Or MUPasswordTextBox.Text = "" Then
                MsgBox("Please input the username or password first.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
            Else
                UpdateUser()

                MsgBox("Account user account has been updated successfully.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")

                MUUsernameTextBox.Text = ""
                MUPasswordTextBox.Text = ""
                GetUser(MUEmpNamesComboBox.Text)
                MUPasswordTextBox.Select()
                isDone = True
            End If
        End If
    End Sub

    Public Sub UpdateUser()
        Dim query = "UPDATE Employees SET Username=@Username, Password=@Password, IsAdmin=@IsAdmin WHERE EmployeeID=@EmpID"

        Prepare(query)
        AddParam("@Username", MUUsernameTextBox.Text)
        AddParam("@Password", MUPasswordTextBox.Text)
        If MUIsAdminComboBox.SelectedIndex = 0 Then
            AddParam("@IsAdmin", DBNull.Value)
        Else
            AddParam("@IsAdmin", 1)
        End If
        AddParam("@EmpID", EmpID)
        ExecutePrepare()
    End Sub
End Class