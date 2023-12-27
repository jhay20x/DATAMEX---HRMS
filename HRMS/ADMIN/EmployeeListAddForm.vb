
Public Class EmployeeListAddForm
    Public LastEmpID As Integer
    Private Sub EmployeeListAddForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ELALastNameTextBox.Select()
    End Sub

    Private Sub ELABackButton_Click(sender As Object, e As EventArgs) Handles ELABackButton.Click
        DashBoardForm.Enabled = True
        DashBoardForm.Show()
        DashBoardForm.RefreshDetails()
        DashBoardForm.DisableButton()
        Me.Close()
    End Sub

    Public Function CheckEmployee(LName As String, FName As String)
        Dim query = "SELECT LastName, FirstName FROM Employees WHERE LastName LIKE @LastName AND FirstName LIKE @FirstName"

        Prepare(query)
        AddParam("@LastName", LName)
        AddParam("@FirstName", FName)
        ExecutePrepare()

        If Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function GetEmpID()
        Dim query = "SELECT TOP 1 ID FROM Employees ORDER BY ID DESC"

        Prepare(query)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            Return row("ID")
        Else
            Return Nothing
        End If
    End Function

    Private Sub ELAAddButton_Click(sender As Object, e As EventArgs) Handles ELAAddButton.Click
        Dim TextBoxCtrl As Control
        Dim TextCount As Integer

        For Each TextBoxCtrl In ELAFormPanel.Controls.OfType(Of TextBox)
            If TextBoxCtrl.Text = "" Then
                TextCount += 1
            End If
        Next

        For Each TextBoxCtrl In ELAFormPanel.Controls.OfType(Of ComboBox)
            If TextBoxCtrl.Text = "" Then
                TextCount += 1
            End If
        Next

        If TextCount = 0 Then
            If MsgBox("Add employee to the list?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Alert") = vbYes Then
                Dim LName As String = ELALastNameTextBox.Text
                Dim FName As String = ELAFirstNameTextBox.Text
                Dim isValid As Boolean = CheckEmployee(LName, FName)
                LastEmpID = GetEmpID()

                If Not isValid Then
                    MsgBox("Employee is already in the list.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Alert")
                Else
                    Dim Year As Integer
                    Year = Convert.ToInt32(Now.ToString("yyyy"))
                    Dim Month As Integer
                    Month = Convert.ToInt32(Now.ToString("MM"))
                    Dim Day As Integer
                    Day = Convert.ToInt32(Now.ToString("dd"))

                    Dim Datehired As String = Year & "/" & Month & "/" & Day
                    Dim Status As Integer = 1
                    Dim Department As Integer = ELADeptComboBox.SelectedIndex + 1
                    Dim query = "INSERT INTO Employees VALUES (@EmployeeID, @LastName, @FirstName, @MiddleName, @StatusID, @DepartmentID, 
                    @DateHired, @Age, @ContactNumber, @EmailAddress, @Address, @SSSNo, @PhilHealthNo, @PagIbigNo, @TIN);"

                    Prepare(query)
                    AddParam("@EmployeeID", (Year & Month & Day) & (LastEmpID + 1))
                    AddParam("@LastName", ELALastNameTextBox.Text)
                    AddParam("@FirstName", ELAFirstNameTextBox.Text)
                    AddParam("@MiddleName", ELAMiddleNameTextBox.Text)
                    AddParam("@StatusID", Status)
                    AddParam("@DepartmentID", Department)
                    AddParam("@DateHired", Datehired)
                    AddParam("@Age", ELAAgeTextBox.Text)
                    AddParam("@Address", ELAAddressTextBox.Text)
                    AddParam("@SSSNo", ELASSSTextBox.Text)
                    AddParam("@PhilHealthNo", ELAPHTextBox.Text)
                    AddParam("@PagIbigNo", ELAPITextBox.Text)
                    AddParam("@TIN", ELATINTextBox.Text)
                    AddParam("@ContactNumber", ELAContTextBox.Text)
                    AddParam("@EmailAddress", ELAEmailTextBox.Text)
                    ExecutePrepare()

                    InsertLeaveBalance((Year & Month & Day) & (LastEmpID + 1))

                    For Each ctrl In ELAFormPanel.Controls
                        If TypeOf ctrl Is TextBox Then
                            ctrl.text = ""
                        ElseIf TypeOf ctrl Is ComboBox Then
                            ctrl.selectedindex = 0
                        End If
                    Next

                    DashBoardForm.RefreshDetails()
                    DashBoardForm.DisableButton()
                    MsgBox("Employee successfully added.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
                    Me.Close()
                End If
            Else
                MsgBox("Employee not added. No changes made.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")

            End If
        Else
            MsgBox("Please complete all the fields first!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
        End If
    End Sub

    Public Sub InsertLeaveBalance(EmpID As String)
        Dim query = "INSERT INTO LeaveBalance VALUES (@EmployeeID, @Balance)"

        Prepare(query)
        AddParam("@EmployeeID", EmpID)
        AddParam("@Balance", 15)
        ExecutePrepare()
    End Sub

    Private Sub ELANameTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ELALastNameTextBox.KeyPress, ELAFirstNameTextBox.KeyPress, ELAMiddleNameTextBox.KeyPress, ELADeptComboBox.KeyPress, ELAEmailTextBox.KeyPress, ELAAddressTextBox.KeyPress
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

    Private Sub ELAAgeTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ELATINTextBox.KeyPress, ELASSSTextBox.KeyPress, ELAPHTextBox.KeyPress, ELAPITextBox.KeyPress, ELAContTextBox.KeyPress
        If (Asc(e.KeyChar) > 47 And Asc(e.KeyChar) < 58) Or Asc(e.KeyChar) < 32 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub MiddleNameCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ELAMiddleNameCheckBox.CheckedChanged
        If ELAMiddleNameCheckBox.CheckState = CheckState.Checked Then
            ELAMiddleNameTextBox.Text = "N/A"
            ELAMiddleNameTextBox.Enabled = False
        Else
            ELAMiddleNameTextBox.Text = ""
            ELAMiddleNameTextBox.Enabled = True
        End If
    End Sub

    Private Sub EmployeeListAddForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim TextBoxCtrl As Control
        Dim TextCount As Integer

        For Each TextBoxCtrl In ELAFormPanel.Controls.OfType(Of TextBox)
            If TextBoxCtrl.Text = "" Then
                TextCount += 1
            End If
        Next

        For Each TextBoxCtrl In ELAFormPanel.Controls.OfType(Of ComboBox)
            If TextBoxCtrl.Text = "" Then
                TextCount += 1
            End If
        Next

        If TextCount <> 0 Then
            DashBoardForm.Enabled = True
            DashBoardForm.Show()
            DashBoardForm.RefreshDetails()
            DashBoardForm.DisableButton()
        Else
            If MsgBox("Cancel adding employee?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                DashBoardForm.Enabled = True
                DashBoardForm.Show()
                DashBoardForm.RefreshDetails()
                DashBoardForm.DisableButton()
            End If
        End If
    End Sub
End Class