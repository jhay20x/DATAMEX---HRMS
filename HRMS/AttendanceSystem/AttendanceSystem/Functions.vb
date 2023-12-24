Imports System.Reflection

Module Functions
    Public TimeInCheck As TimeSpan
    Public Function CheckEmployeeID(ByVal EmpID As Long)
        Dim query = "SELECT EmployeeID FROM HRMS.dbo.Employees WHERE EmployeeID = @EmployeeID"

        Prepare(query)
        AddParam("@EmployeeID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Return True
        Else
            Return False
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

        MsgBox("Attendance added Successfully")
    End Sub

    Public Function CheckAttendance(ByVal EmpID As Long)
        Dim Curdate As Date = Today
        Dim query = "SELECT EmployeeID FROM AMS.dbo.AttendanceRecords WHERE EmployeeID = @EmployeeID AND AttDate = @AttDate"

        Prepare(query)
        AddParam("@EmployeeID", EmpID)
        AddParam("@AttDate", Curdate)
        ExecutePrepare()

        If Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetTimeIn(ByVal EmpID As Long)
        Dim Curdate As Date = Today
        Dim query = "SELECT * FROM AttendanceRecords WHERE EmployeeID = @EmployeeID AND AttDate = @AttDate"

        Prepare(query)
        AddParam("@EmployeeID", EmpID)
        AddParam("@AttDate", Curdate)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)
            Dim val As New Values

            Return row("TimeIn")
        End If
        Return Nothing
    End Function

    Public Sub CheckForTimeOut(ByVal EmpID As Long)
        Dim val As New Values

        Dim Curdate As TimeSpan = Date.Now.TimeOfDay
        TimeInCheck = GetTimeIn(EmpID)
        Dim ts As TimeSpan
        Dim TimeDiff As Double

        ts = Curdate - TimeInCheck

        TimeDiff = ts.TotalHours

        MsgBox(Math.Round(TimeDiff, 2))

        If Math.Round(TimeDiff, 2) >= 4 Then
            MsgBox("Timeout YES")
        Else
            MsgBox("You already have Timein / Timeout NO")
        End If
    End Sub

End Module
