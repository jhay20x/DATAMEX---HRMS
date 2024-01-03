Imports System.Reflection

Module Functions
    Public TimeInCheck As TimeSpan
    Public Function CheckEmployeeID(ByVal EmpID As Long)
        Dim query = "SELECT EmployeeID FROM Employees WHERE EmployeeID = @EmployeeID"

        Prepare(query)
        AddParam("@EmployeeID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CheckTimeout(ByVal EmpID As Long)
        Dim Curdate As Date = Today
        Dim query = "SELECT TimeOut FROM AttendanceRecords WHERE EmployeeID = @EmployeeID AND AttDate = @AttDate"

        Prepare(query)
        AddParam("@EmployeeID", EmpID)
        AddParam("@AttDate", Curdate)
        ExecutePrepare()

        If IsDBNull(DataAsTable.Rows(0).Item(0)) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function CheckAttendance(ByVal EmpID As Long)
        Dim Curdate As Date = Today
        Dim query = "SELECT EmployeeID FROM AttendanceRecords WHERE EmployeeID = @EmployeeID AND AttDate = @AttDate"

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

    'Public Function GetTimeIn(ByVal EmpID As Long)
    '    Dim Curdate As Date = Today
    '    Dim query = "SELECT * FROM AttendanceRecords WHERE EmployeeID = @EmployeeID AND AttDate = @AttDate"

    '    Prepare(query)
    '    AddParam("@EmployeeID", EmpID)
    '    AddParam("@AttDate", Curdate)
    '    ExecutePrepare()

    '    If Count > 0 Then
    '        Dim row As DataRow = DataAsTable.Rows(0)

    '        Return row("TimeIn")
    '    End If
    '    Return Nothing
    'End Function

End Module
