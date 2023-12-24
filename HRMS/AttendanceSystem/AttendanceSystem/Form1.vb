Public Class MainForm
    Public EmpID As Long
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles VerifyButton.Click
        If EmpIDTextBox.Text = "" Then
            MessageDialog.Message = "Employee ID is not entered. Please try again."
            MessageDialog.Show(Me)
        Else
            EmpID = EmpIDTextBox.Text
            Dim IsValid As Boolean
            Dim IsPresent As Boolean

            IsValid = CheckEmployeeID(EmpID)
            IsPresent = CheckAttendance(EmpID)

            If IsValid Then
                If IsPresent Then
                    CheckForTimeOut(EmpID)
                Else
                    InsertAttendance(EmpID)
                End If
            Else
                MessageDialog.Message = "Scanned ID seems to be invalid. Please try again."
                MessageDialog.Show(Me)
            End If
            ResetTextFields()
        End If
    End Sub

    Public Sub CheckForTimeOut(ByVal EmpID As Long)
        Dim Curdate As TimeSpan = Date.Now.TimeOfDay
        TimeInCheck = GetTimeIn(EmpID)

        Dim ts As TimeSpan
        Dim TimeDiff As Double

        ts = Curdate - TimeInCheck

        TimeDiff = ts.TotalHours

        If CheckTimeout(EmpID) Then
            MessageDialog.Message = "You already had a Time-out record for today."
            MessageDialog.Show(Me)
        Else
            If Math.Round(TimeDiff, 2) >= 4 Then
                UpdateRecord(Math.Round(TimeDiff, 2))
                MessageDialog.Message = "Time-out has been successfully recorded. Goodbye Mr./Mrs./Ms. " & GetEmpName(EmpID)
                MessageDialog.Show(Me)
            Else
                MessageDialog.Message = "You already had a Time-in record for today."
                MessageDialog.Show(Me)
            End If
        End If
    End Sub

    Public Sub UpdateRecord(ByVal TotalHours As Double)
        Dim curdate As Date = Date.Today
        Dim curtime As Date = Date.Now
        Dim query = "UPDATE AttendanceRecords SET TimeOut=@TimeOut, TotalHours=@TotalHours WHERE EmployeeID=@EmployeeID AND AttDate=@AttDate"

        Prepare(query)
        AddParam("@TimeOut", curtime)
        AddParam("@TotalHours", TotalHours)
        AddParam("@EmployeeID", EmpID)
        AddParam("@AttDate", curdate)
        ExecutePrepare()
    End Sub

    Public Function GetEmpName(ByVal EmpID As Long)
        Dim query = "SELECT LastName, FirstName, MiddleName FROM Employees WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            Return row("LastName") & ", " & row("FirstName") & " " & row("MiddleName")
        Else
            Return Nothing
        End If
    End Function

    Public Sub InsertAttendance(ByVal EmpID As Long)
        Dim CurDate As Date = Today
        Dim Timein As Date = Now

        Dim query = "INSERT INTO AttendanceRecords (EmployeeID, AttDate, TimeIn) VALUES (@EmployeeID, @AttDate, @TimeIn)"

        Prepare(query)
        AddParam("@EmployeeID", EmpID)
        AddParam("@AttDate", CurDate)
        AddParam("@TimeIn", Timein)
        ExecutePrepare()

        MessageDialog.Message = "Time-in has been successfully recorded. Welcome Mr./Mrs./Ms. " & GetEmpName(EmpID)
        MessageDialog.Show(Me)
    End Sub

    Public Sub ResetTextFields()
        EmpIDTextBox.Text = ""
        EmpIDTextBox.Select()
    End Sub

    Private Sub DateTimeTimer_Tick(sender As Object, e As EventArgs) Handles DateTimeTimer.Tick
        Dim CurDateTime As Date = Date.Now
        DayLabel.Text = CurDateTime.ToString("dddd")
        DateTimeLabel.Text = "Date: " & CurDateTime.ToString("d") & " Time: " & CurDateTime.ToString("T")
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
