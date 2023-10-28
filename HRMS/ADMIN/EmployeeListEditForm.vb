Imports System.Data.SqlClient
Imports System.Net

Public Class EmployeeListEditForm
    Private Sub EmployeeListEditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ELEEmpIDLabel.Text = EmpIdEdit
        ELENameTextBox.Select()

        Dim dept, status As String

        Dim cmd As New SqlCommand("SELECT * FROM EmployeesInformation WHERE EmployeeId = '" & EmpIdEdit & "';", Connection)

        Connection.Open()

        Dim sdr As SqlDataReader = cmd.ExecuteReader

        While sdr.Read
            ELENameTextBox.Text = sdr("EmployeeName")
            ELEAgeTextBox.Text = sdr("Age")
            ELEAddressTextBox.Text = sdr("Address")
            ELETINTextBox.Text = sdr("TIN")
            ELESSSTextBox.Text = sdr("SSSNo")
            ELEPHTextBox.Text = sdr("PhilHealthNo")
            ELEPITextBox.Text = sdr("PagibigNo")
            ELEContTextBox.Text = sdr("ContactNumber")
            ELEEmailTextBox.Text = sdr("EmailAddress")
            dept = sdr("Department")
            If dept = "IT" Then
                ELEDeptComboBox.SelectedIndex = 0
            ElseIf dept = "HM" Then
                ELEDeptComboBox.SelectedIndex = 1
            ElseIf dept = "TM" Then
                ELEDeptComboBox.SelectedIndex = 2
            ElseIf dept = "GP" Then
                ELEDeptComboBox.SelectedIndex = 3
            End If
            status = sdr("EmployeeStatus")
            If status = "Working" Then
                ELEEmployeeStatusComboBox.SelectedIndex = 0
            ElseIf status = "Non-Working" Then
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
                Dim query As String = "UPDATE EmployeesInformation SET EmployeeName = @EmployeeName,  Department = @Department, Age = @Age, Address = @Address," _
                & "SSSNo = @SSSNo, PhilHealthNo = @PhilHealthNo, PagibigNo = @PagibigNo, TIN = @TIN, ContactNumber = @ContactNumber, EmailAddress = @EmailAddress, EmployeeStatus = @EmployeeStatus " _
                & "WHERE EmployeeId = @EmployeeID;"

                Prepare(query)
                AddParameters("@EmployeeID", EmpIdEdit)
                AddParameters("@EmployeeName", ELENameTextBox.Text)
                AddParameters("@Department", ELEDeptComboBox.Text)
                AddParameters("@Age", ELEAgeTextBox.Text)
                AddParameters("@Address", ELEAddressTextBox.Text)
                AddParameters("@SSSNo", ELESSSTextBox.Text)
                AddParameters("@PhilHealthNo", ELEPHTextBox.Text)
                AddParameters("@PagibigNo", ELEPITextBox.Text)
                AddParameters("@TIN", ELETINTextBox.Text)
                AddParameters("@ContactNumber", ELEContTextBox.Text)
                AddParameters("@EmailAddress", ELEEmailTextBox.Text)
                AddParameters("@EmployeeStatus", ELEEmployeeStatusComboBox.Text)
                Execute()
                Params.Clear()

                For Each Ctrl In ELEFormPanel.Controls
                    If TypeOf Ctrl Is TextBox Then
                        Ctrl.Text = ""
                    ElseIf TypeOf Ctrl Is ComboBox Then
                        Ctrl.SelectedIndex = -1
                    End If
                Next

                DashBoardForm.EmployeesInformationTableAdapter.Fill(DashBoardForm.HRMSDataSet.EmployeesInformation)

                MsgBox("Employee information successfully updated.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
                ELENameTextBox.Select()
            Else
                MsgBox("Employee not Updated. No changes made.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")

            End If
        Else
            MsgBox("Please complete all the fields first!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
        End If
    End Sub
End Class