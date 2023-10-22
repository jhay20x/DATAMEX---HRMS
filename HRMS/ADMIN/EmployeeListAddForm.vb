Imports Microsoft.VisualBasic.Logging
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class EmployeeListAddForm
    Private Sub EmployeeListAddForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub EmployeeListAddForm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed, Me.Closed
        DashBoardForm.Enabled = True
        DashBoardForm.Show()
    End Sub

    Private Sub ELABackButton_Click(sender As Object, e As EventArgs) Handles ELABackButton.Click
        DashBoardForm.Enabled = True
        Me.Hide()
        Me.Close()
        DashBoardForm.Show()
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

        If TextCount = 0 Then
            If MsgBox("Add employee to the list?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Alert") = vbYes Then
                Dim EmpIdSfx As String
                Dim EmpId As String
                Dim EmpDept As String

                If ELADeptComboBox.Text = "IT" Then
                    EmpDept = "IT"
                ElseIf ELADeptComboBox.Text = "HM" Then
                    EmpDept = "HM"
                ElseIf ELADeptComboBox.Text = "TM" Then
                    EmpDept = "TM"
                ElseIf ELADeptComboBox.Text = "GP" Then
                    EmpDept = "GP"
                End If

                Dim cmd1 As New SqlCommand("SELECT EmployeeID FROM EmployeesInformation WHERE EmployeeID LIKE 'DMX-VAL-%';", con)

                Dim sdr1 As SqlDataReader = cmd1.ExecuteReader

                While sdr1.Read
                    EmpIdSfx = sdr1("EmployeeID")
                End While

                EmpId = "DMX-VAL-" & (EmpIdSfx.Substring(8, 1) + 1) & "-" & EmpDept

                Dim cmd2 As New SqlCommand("INSERT INTO EmployeesInformation VALUES ('" & EmpId & "','" & ELANameTextBox.Text & "','" _
                & EmpDept & "'," & ELAAgeTextBox.Text & ",'" & ELAAddressTextBox.Text & "','" & ELASSSTextBox.Text & "','" & ELAPHTextBox.Text & "','" _
                & ELAPITextBox.Text & "','" & ELATINTextBox.Text & "','" & ELAContTextBox.Text & "','" & ELAEmailTextBox.Text & "','Working');", con)

                cmd2.ExecuteNonQuery()

                Dim Ctrl As Control
                For Each Ctrl In ELAFormPanel.Controls
                    If TypeOf Ctrl Is TextBox Then
                        Ctrl.Text = ""
                    ElseIf TypeOf Ctrl Is ComboBox Then
                        ELADeptComboBox.SelectedIndex = -1
                    End If
                Next

                MsgBox("Employee successfully added.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
                ELANameTextBox.Focus()
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
End Class