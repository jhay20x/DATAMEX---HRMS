
Public Class EmployeeListEditForm
    Public EmpIdEdit As String
    Private Sub EmployeeListEditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateDept()
        PopulateStatus()
        LoadData()
    End Sub

    Public Sub PopulateDept()
        Dim query = "SELECT Department FROM Department"

        Prepare(query)
        ExecutePrepare()

        ELEDeptComboBox.DisplayMember = "Department"
        ELEDeptComboBox.DataSource = DataAsTable
        ELEDeptComboBox.SelectedIndex = -1
        ELEDeptComboBox.MaxDropDownItems = 5
    End Sub

    Public Sub PopulateStatus()
        Dim query = "SELECT Status FROM Status"

        Prepare(query)
        ExecutePrepare()

        ELEEmployeeStatusComboBox.DisplayMember = "Status"
        ELEEmployeeStatusComboBox.DataSource = DataAsTable
        ELEEmployeeStatusComboBox.SelectedIndex = -1
        ELEEmployeeStatusComboBox.MaxDropDownItems = 5
    End Sub

    Public Sub LoadData()
        ELEEmpIDLabel.Text = EmpIdEdit
        ELELastNameTextBox.Select()

        Dim query = "SELECT * FROM Employees WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpIdEdit)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            ELELastNameTextBox.Text = row("LastName")
            ELEFirstNameTextBox.Text = row("FirstName")

            If row("MiddleName") = "N/A" Then
                ELEMiddleNameCheckBox.CheckState = CheckState.Checked
                ELEMiddleNameTextBox.Text = "N/A"
                ELEMiddleNameTextBox.Enabled = False
            Else
                ELEMiddleNameCheckBox.CheckState = CheckState.Unchecked
                ELEMiddleNameTextBox.Text = row("MiddleName")
                ELEMiddleNameTextBox.Enabled = True
            End If

            ELEAgeTextBox.Text = row("Age")
            ELEAddressTextBox.Text = row("Address")
            ELETINTextBox.Text = row("TIN")
            ELESSSTextBox.Text = row("SSSNo")
            ELEPHTextBox.Text = row("PhilHealthNo")
            ELEPITextBox.Text = row("PagibigNo")
            ELEContTextBox.Text = row("ContactNumber")
            ELEEmailTextBox.Text = row("EmailAddress")
            ELEDeptComboBox.SelectedIndex = row("DepartmentID") - 1
            ELEEmployeeStatusComboBox.SelectedIndex = row("StatusID") - 1
        End If
    End Sub

    Private Sub ELEUpdateButton_Click(sender As Object, e As EventArgs) Handles ELEUpdateButton.Click
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
                Dim Department As Integer = ELEDeptComboBox.SelectedIndex + 1
                Dim Status As Integer = ELEEmployeeStatusComboBox.SelectedIndex + 1

                Dim query As String = "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName,  
                DepartmentID = @DepartmentID, Age = @Age, Address = @Address, SSSNo = @SSSNo, PhilHealthNo = @PhilHealthNo, PagibigNo = @PagibigNo, 
                TIN = @TIN, ContactNumber = @ContactNumber, EmailAddress = @EmailAddress, StatusID = @StatusID WHERE EmployeeId = @EmployeeID;"

                Prepare(query)
                AddParam("@EmployeeID", EmpIdEdit)
                AddParam("@LastName", ELELastNameTextBox.Text)
                AddParam("@FirstName", ELEFirstNameTextBox.Text)
                AddParam("@MiddleName", ELEMiddleNameTextBox.Text)
                AddParam("@StatusID", Status)
                AddParam("@DepartmentID", Department)
                AddParam("@Age", ELEAgeTextBox.Text)
                AddParam("@Address", ELEAddressTextBox.Text)
                AddParam("@SSSNo", ELESSSTextBox.Text)
                AddParam("@PhilHealthNo", ELEPHTextBox.Text)
                AddParam("@PagibigNo", ELEPITextBox.Text)
                AddParam("@TIN", ELETINTextBox.Text)
                AddParam("@ContactNumber", ELEContTextBox.Text)
                AddParam("@EmailAddress", ELEEmailTextBox.Text)
                ExecutePrepare()

                DashBoardForm.RefreshDetails()
                DashBoardForm.DisableButton()
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
        If MsgBox("Cancel updating information?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.Yes Then
            e.Cancel = False
            DashBoardForm.Enabled = True
            DashBoardForm.Show()
            DashBoardForm.RefreshDetails()
            DashBoardForm.DisableButton()
            EmpIdEdit = ""
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub ELEBackButton_Click(sender As Object, e As EventArgs) Handles ELEBackButton.Click
        DashBoardForm.Enabled = True
        DashBoardForm.Show()
        DashBoardForm.RefreshDetails()
        DashBoardForm.DisableButton()
        Me.Close()
    End Sub

    Private Sub ELANameTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ELELastNameTextBox.KeyPress, ELEFirstNameTextBox.KeyPress, ELEMiddleNameTextBox.KeyPress, ELEDeptComboBox.KeyPress, ELEEmailTextBox.KeyPress, ELEAddressTextBox.KeyPress
        If (Asc(e.KeyChar) > 32 And Asc(e.KeyChar) < 44 Or Asc(e.KeyChar) = 47) Then
            e.Handled = True
        ElseIf (Asc(e.KeyChar) > 57 And Asc(e.KeyChar) < 64) Then
            e.Handled = True
        ElseIf (Asc(e.KeyChar) > 90 And Asc(e.KeyChar) < 97) Then
            e.Handled = True
        ElseIf (Asc(e.KeyChar) > 122 And Asc(e.KeyChar) < 128) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub ELEAgeTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ELETINTextBox.KeyPress, ELESSSTextBox.KeyPress, ELEPHTextBox.KeyPress, ELEPITextBox.KeyPress, ELEContTextBox.KeyPress
        If (Asc(e.KeyChar) > 47 And Asc(e.KeyChar) < 58) Or Asc(e.KeyChar) < 32 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class