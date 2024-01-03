Public Class HolidayAddForm
    Public HolidayDate As Date
    Private Sub HolidayAddForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HolidayDateTimePicker.Value = Date.Today
        HolidayTypeComboBox.SelectedIndex = 0
    End Sub

    Private Sub HABackButton_Click(sender As Object, e As EventArgs) Handles HABackButton.Click
        Me.Close()
    End Sub

    Private Sub HolidayAddForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        DashBoardForm.Enabled = True
        DashBoardForm.DisableButton()
        DashBoardForm.Show()
    End Sub

    Private Sub HAAddButton_Click(sender As Object, e As EventArgs) Handles HAAddButton.Click
        HolidayDate = HolidayDateTimePicker.Value

        If HolidayDescTextBox.Text = "" Then
            MsgBox("Invalid input. Please try again.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
        Else
            If CheckHoliday() Then
                MsgBox("Date is already set as a holiday. Please select different a date.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
            Else
                If MsgBox("Add date as a holiday?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
                    Dim query = "INSERT INTO Holidays VALUES (@HolidayDate, @Description, @Type)"

                    Prepare(query)
                    AddParam("@HolidayDate", HolidayDate)
                    AddParam("@Description", HolidayDescTextBox.Text)
                    AddParam("@Type", HolidayTypeComboBox.Text)
                    ExecutePrepare()

                    HolidayDateTimePicker.Value = Date.Today
                    HolidayDescTextBox.Text = ""
                    HolidayTypeComboBox.SelectedIndex = 0
                    DashBoardForm.LoadHoliday(DashBoardForm.HolidayDateTimePicker.Value.Month)
                    MsgBox("Date has been successfully added as a holiday.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
                End If
            End If
        End If
    End Sub

    Public Function CheckHoliday()
        Dim query = "SELECT HolidayDate FROM Holidays WHERE HolidayDate = @HolidayDate"
        HolidayDate = HolidayDateTimePicker.Value

        Prepare(query)
        AddParam("@HolidayDate", HolidayDate)
        ExecutePrepare()

        If Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class