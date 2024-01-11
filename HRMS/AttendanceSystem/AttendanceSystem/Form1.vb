Imports System.Net.Mail

Public Class MainForm
    Public EmpID As Long
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles VerifyButton.Click
        If EmpIDTextBox.Text = "" Then
            Me.Enabled = False
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
                    CheckForLate()
                End If
            Else
                Me.Enabled = False
                MessageDialog.Message = "Scanned ID seems to be invalid. Please try again."
                MessageDialog.Show(Me)
            End If
            ResetTextFields()
        End If
    End Sub

    Public Sub CheckForUndertime(TimeDiff As Double)
        Dim EmpWorkTimeOut As Date = GetWorkHourOut()
        Dim CurTime As Date = Date.Now
        Dim UndertimeVal As TimeSpan
        Dim UndertimeInHours As Double

        UndertimeVal = EmpWorkTimeOut - CurTime

        UndertimeInHours = Math.Round(UndertimeVal.TotalHours, 2)

        If CurTime < EmpWorkTimeOut Then
            UpdateRecord(TimeDiff, UndertimeInHours, Nothing)
        ElseIf CurTime > EmpWorkTimeOut Then
            Dim OTVal As TimeSpan
            Dim OTInHours As Double

            OTVal = CurTime - EmpWorkTimeOut

            OTInHours = Math.Round(OTVal.TotalHours, 2)

            If OTInHours >= 1 Then
                UpdateRecord(TimeDiff, Nothing, OTInHours)
            Else
                UpdateRecord(TimeDiff, Nothing, Nothing)
            End If
        Else
            UpdateRecord(TimeDiff, Nothing, Nothing)
        End If
    End Sub

    Public Function GetWorkHourOut()
        Dim query = "SELECT WorkHoursTo FROM EmployeeSalaryInformation WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            Return Convert.ToDateTime(row("WorkHoursTo").ToString).ToString("G")
        End If

        Return Nothing
    End Function

    Public Function GetBreak()
        Dim query = "SELECT [Break] FROM EmployeeSalaryInformation WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            Return row("Break")
        End If

        Return Nothing
    End Function

    Public Sub CheckForTimeOut(ByVal EmpID As Long)
        Dim Curdate As Date = Date.Now
        Dim EmpTimeIn As Date = Convert.ToDateTime(GetTimeIn(EmpID).ToString).ToString("G")

        Dim WorkHours As TimeSpan
        Dim TimeDiff As Double

        WorkHours = Curdate - EmpTimeIn

        TimeDiff = Math.Round(WorkHours.TotalHours, 5)

        If CheckTimeout(EmpID) Then
            Me.Enabled = False
            MessageDialog.Message = "You already had a Time-out record for today."
            MessageDialog.Show(Me)
        Else
            If TimeDiff >= 0.08333 Then
                CheckForUndertime(TimeDiff)
                Me.Enabled = False
                MessageDialog.Message = "Time-out has been successfully recorded. Goodbye Mr./Mrs./Ms. " & GetEmpName(EmpID)
                MessageDialog.Show(Me)
            Else
                Me.Enabled = False
                MessageDialog.Message = "You already had a Time-in record for today."
                MessageDialog.Show(Me)
            End If
        End If
    End Sub

    Public Sub UpdateRecord(ByVal WorkHours As Double, Undertime As String, OT As String)
        GetTotalWorkHours()
        Dim curdate As Date = Date.Today
        Dim curtime As Date = Date.Now
        Dim EmpWorkHours As Double
        Dim query = "UPDATE AttendanceRecords SET TimeOut=@TimeOut, TotalHours=@TotalHours, OT=@OT, Undertime=@Undertime WHERE EmployeeID=@EmployeeID AND AttDate=@AttDate"

        If WorkHours >= TotalWorkHours + TotalBreakHours Then
            EmpWorkHours = WorkHours - TotalBreakHours
        Else
            EmpWorkHours = WorkHours
        End If

        Prepare(query)
        AddParam("@TimeOut", curtime)
        AddParam("@TotalHours", Math.Round(EmpWorkHours, 2))
        If OT > 0 Then
            AddParam("@OT", OT)
        Else
            AddParam("@OT", DBNull.Value)
        End If
        If Undertime > 0 Then
            AddParam("@Undertime", Undertime)
        Else
            AddParam("@Undertime", DBNull.Value)
        End If
        AddParam("@EmployeeID", EmpID)
        AddParam("@AttDate", curdate)
        ExecutePrepare()
    End Sub

    Public TotalWorkHours As Double
    Public TotalBreakHours As Double

    Public Sub GetTotalWorkHours()
        Dim query = "SELECT Total, [Break] FROM EmployeeSalaryInformation WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            TotalWorkHours = row("Total")
            TotalBreakHours = row("Break")
        End If
    End Sub

    Public Function GetEmpName(ByVal EmpID As Long)
        Dim query = "SELECT CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName FROM Employees WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            Return row("EmployeeName")
        Else
            Return Nothing
        End If
    End Function

    Public Sub CheckForLate()
        Dim EmpTimeIn As Date = GetWorkHourIn()
        Dim CurTime As Date = Date.Now
        Dim LateVal As TimeSpan
        Dim LateInHours As Double
        Dim GracePeriodInHours As Double = 0.25

        LateVal = CurTime - EmpTimeIn

        LateInHours = Math.Round(LateVal.TotalHours, 2)

        If LateInHours >= GracePeriodInHours Then
            InsertAttendance(EmpID, LateInHours)
        Else
            InsertAttendance(EmpID, Nothing)
        End If
    End Sub

    Public Function GetWorkHourIn()
        Dim query = "SELECT WorkHoursFrom FROM EmployeeSalaryInformation WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            Return Convert.ToDateTime(row("WorkHoursFrom").ToString).ToString("G")
        End If

        Return Nothing
    End Function

    Public Sub InsertAttendance(ByVal EmpID As Long, LateInHours As String)
        Dim CurDate As Date = Today
        Dim Timein As Date = Now

        Dim query = "INSERT INTO AttendanceRecords (EmployeeID, AttDate, TimeIn, Late) VALUES (@EmployeeID, @AttDate, @TimeIn, @Late)"

        Prepare(query)
        AddParam("@EmployeeID", EmpID)
        AddParam("@AttDate", CurDate)
        AddParam("@TimeIn", Timein)
        If LateInHours > 0 Then
            AddParam("@Late", LateInHours)
        Else
            AddParam("@Late", DBNull.Value)
        End If
        ExecutePrepare()

        Me.Enabled = False
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
