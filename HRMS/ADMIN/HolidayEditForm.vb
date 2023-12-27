Public Class HolidayEditForm
    Public CurDate As Date
    Public HolidayDate As Date
    Private Sub HolidayEditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HolidayDateTimePicker.Value = Date.Today
        HolidayTypeComboBox.SelectedIndex = 0

        DisplayData()
    End Sub

    Private Sub HEBackButton_Click(sender As Object, e As EventArgs) Handles HEBackButton.Click
        Me.Close()
    End Sub

    Private Sub HolidayEditForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        DashBoardForm.Enabled = True
        DashBoardForm.DisableButton()
        DashBoardForm.Show()
    End Sub

    Private Sub HEAddButton_Click(sender As Object, e As EventArgs) Handles HEAddButton.Click
        HolidayDate = HolidayDateTimePicker.Value

        If HolidayDescTextBox.Text = "" Then
            MsgBox("Invalid input. Please try again.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
        Else
            If MsgBox("Update this holiday record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
                Dim query = "UPDATE Holidays SET HolidayDate=@HolidayDate, Description=@Description, Type=@Type WHERE HolidayDate = @CurDate"

                Prepare(query)
                AddParam("@HolidayDate", HolidayDate)
                AddParam("@Description", HolidayDescTextBox.Text)
                AddParam("@Type", HolidayTypeComboBox.Text)
                AddParam("@CurDate", CurDate)
                ExecutePrepare()

                HolidayDateTimePicker.Value = Date.Today
                HolidayDescTextBox.Text = ""
                HolidayTypeComboBox.SelectedIndex = 0
                DashBoardForm.LoadHoliday(DashBoardForm.HolidayDateTimePicker.Value.Month)
                MsgBox("Date has been successfully added as a holiday.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
                Me.Close()
            End If
        End If
    End Sub

    Public Sub DisplayData()
        Dim query = "SELECT * FROM Holidays WHERE HolidayDate = @CurDate"

        Prepare(query)
        AddParam("@Curdate", CurDate)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            HolidayDateTimePicker.Value = row("HolidayDate")
            HolidayDescTextBox.Text = row("Description")
            If row("Type") = "Regular" Then
                HolidayTypeComboBox.SelectedIndex = 0
            Else
                HolidayTypeComboBox.SelectedIndex = 1
            End If
        End If
    End Sub
End Class