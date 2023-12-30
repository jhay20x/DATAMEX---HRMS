Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status

Public Class EmployeeCredentialsForm
    Public EmpID As String
    Private Sub EmployeeCredentialsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ECReasonTextBox.Select()
    End Sub

    Private Sub EmployeeCredentialsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        DashBoardForm.Enabled = True
        DashBoardForm.ESIRefreshButton.PerformClick()
        DashBoardForm.Show()
    End Sub

    Private Sub ECBackButton_Click(sender As Object, e As EventArgs) Handles ECBackButton.Click
        Me.Close()
    End Sub

    Private Sub ECAddButton_Click(sender As Object, e As EventArgs) Handles ECAddButton.Click
        Dim TextBoxCtrl As Control
        Dim TextCount As Integer

        For Each TextBoxCtrl In Me.Controls.OfType(Of TextBox)
            If TextBoxCtrl.Text = "" Then
                TextCount += 1
            End If
        Next

        For Each TextBoxCtrl In Me.Controls.OfType(Of ComboBox)
            If TextBoxCtrl.Text = "" Then
                TextCount += 1
            End If
        Next

        If TextCount = 0 Then
            If CheckESI() Then
                Dim CurRate As Integer = GetRate()

                If CurRate + ECIncreaseTextBox.Text < 0 Then
                    MsgBox("Rate must not result to a non-negative number.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
                Else
                    If MsgBox("Are you sure to add the credentials and increase salary of the employee?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
                        InsertCreds()

                        If ECEffectiveDateDateTimePicker.Value.ToShortDateString = Date.Now.ToShortDateString Then
                            UpdateRate()
                        End If

                        For Each ctrl In Me.Controls
                            If TypeOf ctrl Is TextBox Then
                                ctrl.text = ""
                            ElseIf TypeOf ctrl Is DateTimePicker Then
                                ctrl.value = Date.Today
                            End If
                        Next

                        MsgBox("Operation success.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
                        Me.Close()
                    End If
                End If
            Else
                MsgBox("Please setup employee salary information first.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
            End If
        Else
            MsgBox("Please complete all fields first.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
        End If
    End Sub

    Public Function CheckESI()
        Dim query = "SELECT * FROM EmployeeSalaryInformation WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub InsertCreds()
        Dim query = "INSERT INTO EmployeesCredentials VALUES (@EmployeeID, @Description, @Increase, @AuthorizedBy, @Date, @EffectiveDate)"

        Prepare(query)
        AddParam("@EmployeeID", EmpID)
        AddParam("@Description", ECReasonTextBox.Text)
        AddParam("@Increase", ECIncreaseTextBox.Text)
        AddParam("@AuthorizedBy", ECAuthorizeTextBox.Text)
        AddParam("@Date", Date.Today)
        AddParam("@EffectiveDate", ECEffectiveDateDateTimePicker.Value)
        ExecutePrepare()
    End Sub

    Public Sub UpdateRate()
        Dim CurRate As Integer = GetRate()

        Dim query = "UPDATE EmployeeSalaryInformation SET Rate=@Rate WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@Rate", CurRate + ECIncreaseTextBox.Text)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()
    End Sub

    Public Function GetRate()
        Dim query = "SELECT Rate FROM EmployeeSalaryInformation WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)
            If IsDBNull(row("Rate")) Then
                Return ECIncreaseTextBox.Text
            Else
                Return row("Rate")
            End If
        Else
            Return ECIncreaseTextBox.Text
        End If
    End Function

    Private Sub ECIncreaseTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (Asc(e.KeyChar) > 47 And Asc(e.KeyChar) < 58) Or Asc(e.KeyChar) < 32 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub ECReasonTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
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
End Class