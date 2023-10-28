Imports Microsoft.VisualBasic.Logging
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Text

Public Class EmployeeListAddForm
    Private Sub EmployeeListAddForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ELANameTextBox.Select()
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

        If TextCount = 0 Then
            If MsgBox("Add employee to the list?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Alert") = vbYes Then
                Dim Name As String = ELANameTextBox.Text
                Dim query As String = "SELECT COUNT(*) FROM EmployeesInformation WHERE EmployeeName LIKE @Name + '%';"

                CheckEmployee(Name, query)

                If IsValid = False Then
                    MsgBox("Employee is already in the list.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Alert")
                Else
                    Dim datehired As Date = Now
                    Dim query2 As String = "INSERT INTO EmployeesInformation VALUES (@EmployeeName, @Department, @DateHired, @Age, @Address, @SSSNo, @PhilHealthNo, @PagibigNo, @TIN, @ContactNumber, @EmailAddress, @EmployeeStatus);"

                    Prepare(query2)
                    AddParameters("@EmployeeName", ELANameTextBox.Text)
                    AddParameters("@Department", ELADeptComboBox.Text)
                    AddParameters("@DateHired", datehired)
                    AddParameters("@Age", ELAAgeTextBox.Text)
                    AddParameters("@Address", ELAAddressTextBox.Text)
                    AddParameters("@SSSNo", ELASSSTextBox.Text)
                    AddParameters("@PhilHealthNo", ELAPHTextBox.Text)
                    AddParameters("@PagibigNo", ELAPITextBox.Text)
                    AddParameters("@TIN", ELATINTextBox.Text)
                    AddParameters("@ContactNumber", ELAContTextBox.Text)
                    AddParameters("@EmailAddress", ELAEmailTextBox.Text)
                    AddParameters("@EmployeeStatus", "Working")
                    Execute()
                    Params.Clear()

                    For Each Ctrl In ELAFormPanel.Controls
                        If TypeOf Ctrl Is TextBox Then
                            Ctrl.Text = ""
                        ElseIf TypeOf Ctrl Is ComboBox Then
                            Ctrl.SelectedIndex = -1
                        End If
                    Next

                    DashBoardForm.EmployeesInformationTableAdapter.Fill(DashBoardForm.HRMSDataSet.EmployeesInformation)

                    MsgBox("Employee successfully added.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")

                    ELANameTextBox.Select()
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

    Private Sub ELANameTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ELANameTextBox.KeyPress, ELAAddressTextBox.KeyPress, ELADeptComboBox.KeyPress, ELAEmailTextBox.KeyPress
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

    Private Sub ELAAgeTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ELAAgeTextBox.KeyPress, ELATINTextBox.KeyPress, ELASSSTextBox.KeyPress, ELAPHTextBox.KeyPress, ELAPITextBox.KeyPress, ELAContTextBox.KeyPress
        If (Asc(e.KeyChar) > 47 And Asc(e.KeyChar) < 58) Or Asc(e.KeyChar) < 32 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class