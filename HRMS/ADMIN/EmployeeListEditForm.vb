Imports System.Data.SqlClient
Imports System.Net

Public Class EmployeeListEditForm
    Private Sub EmployeeListEditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ELEEmpIDLabel.Text = EmpIdEdit
        ELELastNameTextBox.Select()

        Dim dept, status, mname As String

        Dim cmd As New SqlCommand("SELECT * FROM Employees WHERE EmployeeID = '" & EmpIdEdit & "';", Connection)

        Connection.Open()

        Dim sdr As SqlDataReader = cmd.ExecuteReader

        While sdr.Read
            ELELastNameTextBox.Text = sdr("LastName")
            ELEFirstNameTextBox.Text = sdr("FirstName")
            mname = sdr("MiddleName")
            If mname = "N/A" Then
                ELEMiddleNameCheckBox.CheckState = CheckState.Checked
                ELEMiddleNameTextBox.Text = "N/A"
                ELEMiddleNameTextBox.Enabled = False
            Else
                ELEMiddleNameCheckBox.CheckState = CheckState.Unchecked
                ELEMiddleNameTextBox.Text = mname
                ELEMiddleNameTextBox.Enabled = True
            End If
            ELEAgeTextBox.Text = sdr("Age")
            ELEAddressTextBox.Text = sdr("Address")
            ELETINTextBox.Text = sdr("TIN")
            ELESSSTextBox.Text = sdr("SSSNo")
            ELEPHTextBox.Text = sdr("PhilHealthNo")
            ELEPITextBox.Text = sdr("PagibigNo")
            ELEContTextBox.Text = sdr("ContactNumber")
            ELEEmailTextBox.Text = sdr("EmailAddress")
            dept = sdr("DepartmentID")
            If dept = 1 Then
                ELEDeptComboBox.SelectedIndex = 0
            ElseIf dept = 2 Then
                ELEDeptComboBox.SelectedIndex = 1
            ElseIf dept = 3 Then
                ELEDeptComboBox.SelectedIndex = 2
            ElseIf dept = 4 Then
                ELEDeptComboBox.SelectedIndex = 3
            ElseIf dept = 5 Then
                ELEDeptComboBox.SelectedIndex = 4
            ElseIf dept = 6 Then
                ELEDeptComboBox.SelectedIndex = 5
            ElseIf dept = 7 Then
                ELEDeptComboBox.SelectedIndex = 6
            ElseIf dept = 8 Then
                ELEDeptComboBox.SelectedIndex = 7
            ElseIf dept = 9 Then
                ELEDeptComboBox.SelectedIndex = 8
            End If
            status = sdr("StatusID")
            If status = 1 Then
                ELEEmployeeStatusComboBox.SelectedIndex = 0
            ElseIf status = 2 Then
                ELEEmployeeStatusComboBox.SelectedIndex = 1
            End If
        End While

        Connection.Close()
    End Sub

    Private Sub EmployeeListEditForm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed, Me.Closed
        DashBoardForm.Enabled = True
        DashBoardForm.Show()
        EmpIdEdit = ""
    End Sub

    Private Sub ELEBackButton_Click(sender As Object, e As EventArgs) Handles ELEBackButton.Click
        DashBoardForm.Enabled = True
        DashBoardForm.Show()
        Me.Close()
    End Sub

    Private Sub ELEAddButton_Click(sender As Object, e As EventArgs) Handles ELEAddButton.Click
        Dim TextBoxCtrl As Control
        Dim TextCount As Integer

        For Each TextBoxCtrl In ELEFormPanel.Controls.OfType(Of TextBox)
            If TextBoxCtrl.Text = "" Then
                TextCount += 1
            End If
        Next

        For Each TextBoxCtrl In ELEFormPanel.Controls.OfType(Of ComboBox)
            If TextBoxCtrl.Text = "" Then
                TextCount += 1
            End If
        Next

        If TextCount = 0 Then
            If MsgBox("Update the employee's information?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Alert") = vbYes Then
                Dim department As Integer = ELEDeptComboBox.Text.Substring(0, 1)
                Dim status As Integer = ELEEmployeeStatusComboBox.Text.Substring(0, 1)

                Dim query As String = "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName,  Department = @Department, Age = @Age, Address = @Address," _
                & "SSSNo = @SSSNo, PhilHealthNo = @PhilHealthNo, PagibigNo = @PagibigNo, TIN = @TIN, ContactNumber = @ContactNumber, EmailAddress = @EmailAddress, StatusID = @StatusID " _
                & "WHERE EmployeeId = @EmployeeID;"

                Prepare(query)
                AddParameters("@EmployeeID", EmpIdEdit)
                AddParameters("@LastName", ELELastNameTextBox.Text)
                AddParameters("@FirstName", ELEFirstNameTextBox.Text)
                AddParameters("@MiddleName", ELEMiddleNameTextBox.Text)
                AddParameters("@DepartmentID", department)
                AddParameters("@Age", ELEAgeTextBox.Text)
                AddParameters("@Address", ELEAddressTextBox.Text)
                AddParameters("@SSSNo", ELESSSTextBox.Text)
                AddParameters("@PhilHealthNo", ELEPHTextBox.Text)
                AddParameters("@PagibigNo", ELEPITextBox.Text)
                AddParameters("@TIN", ELETINTextBox.Text)
                AddParameters("@ContactNumber", ELEContTextBox.Text)
                AddParameters("@EmailAddress", ELEEmailTextBox.Text)
                AddParameters("@StatusID", status)
                Execute()
                Params.Clear()

                'DashBoardForm.EmployeesTableAdapter.FillBy(DashBoardForm.HRMSDataSet.Employees)
                DashBoardForm.RefreshTable()

                MsgBox("Employee information successfully updated.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
                ELELastNameTextBox.Select()
            Else
                MsgBox("Employee not Updated. No changes made.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")

            End If
        Else
            MsgBox("Please complete all the fields first!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
        End If
    End Sub

    Private Sub ELEMiddleNameCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ELEMiddleNameCheckBox.CheckedChanged
        If ELEMiddleNameCheckBox.CheckState = CheckState.Checked Then
            ELEMiddleNameTextBox.Text = "N/A"
            ELEMiddleNameTextBox.Enabled = False
        Else
            ELEMiddleNameTextBox.Text = ""
            ELEMiddleNameTextBox.Enabled = True
        End If
    End Sub

    Private Sub EmployeeListEditForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Cancel updating information?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub
End Class