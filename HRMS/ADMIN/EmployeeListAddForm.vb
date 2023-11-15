Imports Microsoft.VisualBasic.Logging
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Text

Public Class EmployeeListAddForm
    Private Sub EmployeeListAddForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ELALastNameTextBox.Select()
    End Sub

    Private Sub EmployeeListAddForm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed, Me.Closed
        DashBoardForm.Enabled = True
        DashBoardForm.Show()
    End Sub

    Private Sub ELABackButton_Click(sender As Object, e As EventArgs) Handles ELABackButton.Click
        DashBoardForm.Enabled = True
        DashBoardForm.Show()
        Me.Close()
    End Sub

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

        If TextCount <> 0 Then
            If MsgBox("Add employee to the list?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Alert") = vbYes Then
                Dim LName As String = ELALastNameTextBox.Text
                Dim FName As String = ELAFirstNameTextBox.Text
                Dim query1 As String = "SELECT COUNT(LastName) FROM Employees WHERE LastName LIKE '%' + @LastName + '%' AND FirstName LIKE '%' + @FirstName + '%';"

                CheckEmployee(LName, FName, query1)

                If IsValid = False Then
                    MsgBox("Employee is already in the list.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Alert")
                Else
                    Dim Year As Integer
                    Year = Convert.ToInt32(Now.ToString("yyyy"))
                    Dim Month As Integer
                    Month = Convert.ToInt32(Now.ToString("MM"))
                    Dim Day As Integer
                    Day = Convert.ToInt32(Now.ToString("dd"))
                    Dim datehired As String = Year & "/" & Month & "/" & Day
                    Dim status As Integer = 1
                    Dim department As Integer = ELADeptComboBox.Text.Substring(0, 1)
                    Dim query3 As String = "INSERT INTO Employees VALUES (@EmployeeID, @LastName, @FirstName, @MiddleName, @Status, @Department, @DateHired, @Age, @Address, @SSSNo, @PhilHealthNo, @PagIbigNo, @TIN, @ContactNumber, @EmailAddress);"

                    Prepare(query3)
                    AddParameters("@EmployeeID", (Year & Month & Day) & (LastId + 1))
                    AddParameters("@LastName", ELALastNameTextBox.Text)
                    AddParameters("@FirstName", ELAFirstNameTextBox.Text)
                    AddParameters("@MiddleName", ELAMiddleNameTextBox.Text)
                    AddParameters("@Status", status)
                    AddParameters("@Department", department)
                    AddParameters("@DateHired", datehired)
                    AddParameters("@Age", ELAAgeTextBox.Text)
                    AddParameters("@Address", ELAAddressTextBox.Text)
                    AddParameters("@SSSNo", ELASSSTextBox.Text)
                    AddParameters("@PhilHealthNo", ELAPHTextBox.Text)
                    AddParameters("@PagIbigNo", ELAPITextBox.Text)
                    AddParameters("@TIN", ELATINTextBox.Text)
                    AddParameters("@ContactNumber", ELAContTextBox.Text)
                    AddParameters("@EmailAddress", ELAEmailTextBox.Text)
                    Execute()
                    Params.Clear()

                    For Each ctrl In ELAFormPanel.Controls
                        If TypeOf ctrl Is TextBox Then
                            ctrl.text = ""
                        ElseIf TypeOf ctrl Is ComboBox Then
                            ctrl.selectedindex = -1
                        End If
                    Next

                    'DashBoardForm.EmployeesTableAdapter.FillBy(DashBoardForm.HRMSDataSet.Employees)
                    DashBoardForm.RefreshTable()

                    MsgBox("Employee successfully added.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")

                    ELALastNameTextBox.Select()
                End If
            Else
                MsgBox("Employee not added. No changes made.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")

            End If
        Else
            MsgBox("Please complete all the fields first!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
        End If
    End Sub

    Private Sub ELADeptComboBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ELADeptComboBox.KeyPress
        e.Handled = True
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
        If MsgBox("Cancel adding employee?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub
End Class