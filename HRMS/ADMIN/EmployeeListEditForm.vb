Imports System.Data.SqlClient
Imports System.Net

Public Class EmployeeListEditForm
    Private Sub EmployeeListEditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ELEEmpIDLabel.Text = EmpIdEdit
        ELENameTextBox.Select()

        Dim dept, status As String

        Dim cmd As New SqlCommand("SELECT * FROM EmployeesInformation WHERE EmployeeId = '" & EmpIdEdit & "';", con)

        con.Open()

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

        con.Close()
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
                Dim EmpDept As String
                Dim EmpStat As String

                If ELEDeptComboBox.Text = "IT" Then
                    EmpDept = "IT"
                ElseIf ELEDeptComboBox.Text = "HM" Then
                    EmpDept = "HM"
                ElseIf ELEDeptComboBox.Text = "TM" Then
                    EmpDept = "TM"
                ElseIf ELEDeptComboBox.Text = "GP" Then
                    EmpDept = "GP"
                End If

                If ELEEmployeeStatusComboBox.Text = "Working" Then
                    EmpStat = "Working"
                ElseIf ELEEmployeeStatusComboBox.Text = "Non-Working" Then
                    EmpStat = "Non-Working"
                End If

                Dim cmd As New SqlCommand("UPDATE EmployeesInformation SET EmployeeName = '" & ELENameTextBox.Text & "',  Department = '" & EmpDept & "', Age = '" & ELEAgeTextBox.Text & "', Address = '" _
                & ELEAddressTextBox.Text & "', SSSNo = '" & ELESSSTextBox.Text & "', PhilHealthNo = '" & ELEPHTextBox.Text & "', PagibigNo = '" & ELEPITextBox.Text & "', TIN = '" & ELETINTextBox.Text & "', ContactNumber = '" _
                & ELEContTextBox.Text & "', EmailAddress = '" & ELEEmailTextBox.Text & "', EmployeeStatus = '" & EmpStat & "' WHERE EmployeeId = '" & EmpIdEdit & "';", con)

                con.Open()

                cmd.ExecuteNonQuery()

                DashBoardForm.Enabled = True
                DashBoardForm.Enabled = False

                con.Close()

                MsgBox("Employee successfully added.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
                ELENameTextBox.Select()
            Else
                MsgBox("Employee not added. No changes made.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")

            End If
        Else
            MsgBox("Please complete all the fields first!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
        End If
    End Sub
End Class