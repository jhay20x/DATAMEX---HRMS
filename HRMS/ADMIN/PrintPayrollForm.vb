
Imports System.Drawing.Printing
Imports Microsoft
Imports System.Security.Policy

Public Class PrintPayrollForm
    Public CutOffPeriod As String
    Public EmpName As String
    Public EmployeeID As String
    Public TotalHours As String
    Public OTHours As String
    Public BasicPay As String
    Public GrossPay As String
    Public OTPay As String
    Public NetPay As String
    Public HolidayPay As String
    Public Tardiness As String
    Public SSS As String
    Public PHIC As String
    Public HDMF As String
    Public Tax As String
    Public TotalDeduction As String

    Public WithEvents PD As New PrintDocument
    Public PPD As New PrintPreviewDialog
    Public longpaper As Integer

    Private Sub PayrollBackButton_Click(sender As Object, e As EventArgs) Handles PayrollBackButton.Click
        Me.Close()
    End Sub

    Private Sub PayrollPrintButton_Click(sender As Object, e As EventArgs) Handles PayrollPrintButton.Click
        'Changelongpaper()
        If CheckIfGenerated() Then
            LoadPayroll()
            PPD.Document = PD
            PPD.StartPosition = FormStartPosition.CenterScreen
            PPD.Height = 350
            PPD.Width = 900
            PPD.ShowDialog()
        Else
            MsgBox("Print failed. There's no payroll record.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
        End If
    End Sub

    Public Sub LoadPayroll()
        Dim query = "SELECT EmployeeSalary.EmployeeID, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName,
        EmployeeSalary.TotalWorkDays, EmployeeSalary.TotalHours, EmployeeSalary.OTHours, EmployeeSalary.BasicPay, EmployeeSalary.Deduction_Tardiness, EmployeeSalary.GrossPay, EmployeeSalary.OTPay, EmployeeSalary.HolidayPay, 
        EmployeeSalary.SSS, EmployeeSalary.PHIC, EmployeeSalary.HDMF, EmployeeSalary.Tax, EmployeeSalary.TotalDeductions, EmployeeSalary.NetPay
        FROM EmployeeSalary 
        LEFT OUTER JOIN Employees
        ON EmployeeSalary.EmployeeID = Employees.EmployeeID
        WHERE EmployeeSalary.EmployeeID = @EmpID AND PayrollType = @PayrollType AND CutOff = @CutOff AND (MONTH(DateFrom) = @MonthFrom AND DAY(DateFrom) = @DayFrom  AND YEAR(DateFrom) = @YearFrom) AND (MONTH(DateTo) = @MonthTo AND DAY(DateTo) = @DayTo  AND YEAR(DateTo) = @YearTo)"

        Dim DayFrom, DayTo As Integer
        Dim CutOff As String

        If PayrollTypeComboBox.SelectedIndex = 0 Then
            If PayrollCutOffComboBox.SelectedIndex = 0 Then
                DayFrom = "1"
                DayTo = "15"
                CutOff = PayrollCutOffComboBox.Text
            Else
                DayFrom = "16"
                DayTo = Date.DaysInMonth(PayrollYearDateTimePicker.Value.Year, PayrollMonthDateTimePicker.Value.Month)
                CutOff = PayrollCutOffComboBox.Text
            End If
        Else
            DayFrom = "1"
            DayTo = Date.DaysInMonth(PayrollYearDateTimePicker.Value.Year, PayrollMonthDateTimePicker.Value.Month)
            CutOff = "1-" & DayTo
        End If

        CutOffPeriod = PayrollMonthDateTimePicker.Value.Month & "/" & DayFrom & " - " & PayrollMonthDateTimePicker.Value.Month & "/" & DayTo & " " & PayrollYearDateTimePicker.Value.Year

        Prepare(query)
        AddParam("@EmpID", EmpID.Item(PayrollEmpNameComboBox.SelectedIndex))
        AddParam("@PayrollType", PayrollTypeComboBox.Text)
        AddParam("@CutOff", CutOff)
        AddParam("@MonthFrom", PayrollMonthDateTimePicker.Value.Month)
        AddParam("@DayFrom", DayFrom)
        AddParam("@YearFrom", PayrollYearDateTimePicker.Value.Year)
        AddParam("@MonthTo", PayrollMonthDateTimePicker.Value.Month)
        AddParam("@DayTo", DayTo)
        AddParam("@YearTo", PayrollYearDateTimePicker.Value.Year)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            EmpName = row("EmployeeName")
            EmployeeID = row("EmployeeID")
            TotalHours = Format(row("TotalWorkDays"), "##0.00") & " / " & Format(row("TotalHours"), "##0.00")
            OTHours = Format(row("OTHours"), "##0.00")
            BasicPay = Format(row("BasicPay"), "P##,##0.00")
            Tardiness = Format(row("Deduction_Tardiness"), "P##,##0.00")
            GrossPay = Format(row("GrossPay"), "P##,##0.00")
            HolidayPay = Format(row("HolidayPay"), "P##,##0.00")
            OTPay = Format(row("OTPay"), "P##,##0.00")
            SSS = Format(row("SSS"), "P##,##0.00")
            PHIC = Format(row("PHIC"), "P##,##0.00")
            HDMF = Format(row("HDMF"), "P##,##0.00")
            Tax = Format(row("Tax"), "P##,##0.00")
            TotalDeduction = Format(row("TotalDeductions"), "P##,##0.00")
            NetPay = Format(row("NetPay"), "P##,##0.00")
        End If
    End Sub

    Public Function CheckIfGenerated() As Boolean
        Dim query = "SELECT * FROM EmployeeSalary WHERE (MONTH(DateFrom) = @MonthFrom AND DAY(DateFrom) = @DayFrom  AND YEAR(DateFrom) = @YearFrom) AND (MONTH(DateTo) = @MonthTo AND DAY(DateTo) = @DayTo  AND YEAR(DateTo) = @YearTo)"
        Dim DayFrom, DayTo As Integer

        If PayrollTypeComboBox.SelectedIndex = 0 Then
            If PayrollCutOffComboBox.SelectedIndex = 0 Then
                DayFrom = "1"
                DayTo = "15"
            Else
                DayFrom = "16"
                DayTo = Date.DaysInMonth(PayrollYearDateTimePicker.Value.Year, PayrollMonthDateTimePicker.Value.Month)
            End If
        Else
            DayFrom = "1"
            DayTo = Date.DaysInMonth(PayrollYearDateTimePicker.Value.Year, PayrollMonthDateTimePicker.Value.Month)
        End If

        Prepare(query)
        AddParam("@MonthFrom", PayrollMonthDateTimePicker.Value.Month)
        AddParam("@DayFrom", DayFrom)
        AddParam("@YearFrom", PayrollYearDateTimePicker.Value.Year)
        AddParam("@MonthTo", PayrollMonthDateTimePicker.Value.Month)
        AddParam("@DayTo", DayTo)
        AddParam("@YearTo", PayrollYearDateTimePicker.Value.Year)
        ExecutePrepare()

        If Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint
        'pagesetup.PaperSize = New PaperSize("Custom", 250, 500) 'fixed size
        'pagesetup.PaperSize = New PaperSize("Custom", 250, longpaper)

        Dim pagesetup As New PageSettings With {
            .PaperSize = New PaperSize("Custom", 600, 200)
        }
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f6 As New Font("Segoe UI", 6, FontStyle.Regular)
        Dim f6b As New Font("Segoe UI", 6, FontStyle.Bold)
        Dim f8 As New Font("Segoe UI", 8, FontStyle.Regular)
        Dim f8b As New Font("Segoe UI", 8, FontStyle.Bold)
        Dim f10 As New Font("Segoe UI", 10, FontStyle.Regular)
        Dim f10b As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim f14 As New Font("Segoe UI", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        'font alignment
        Dim left As New StringFormat
        Dim right As New StringFormat
        Dim center As New StringFormat

        left.Alignment = StringAlignment.Near
        right.Alignment = StringAlignment.Far
        center.Alignment = StringAlignment.Center

        Dim line As String
        line = "============================================================================="

        Dim blackPen As New Pen(Color.Black, 2)

        Dim x As Single = 5.0F
        Dim y As Single = 5.0F
        Dim width As Single = 590.0F
        Dim height As Single = 190.0F

        e.Graphics.DrawRectangle(blackPen, x, y, width, height)

        'range from top
        e.Graphics.DrawString("DATAMEX COLLEGE OF SAINT ADELINE INC", f10b, Brushes.Black, 10, 10, left)
        e.Graphics.DrawString("CUTOFF PERIOD: " & CutOffPeriod, f10b, Brushes.Black, 370, 10, left)

        e.Graphics.DrawString("Employee Name:", f8b, Brushes.Black, 10, 35, left)
        e.Graphics.DrawString(EmpName, f8, Brushes.Black, 130, 35, left)

        e.Graphics.DrawString("Total Days/Hours:", f8b, Brushes.Black, 300, 35, left)
        e.Graphics.DrawString(TotalHours, f8, Brushes.Black, 425, 35, left)

        e.Graphics.DrawString("ID No.:", f8b, Brushes.Black, 10, 47, left)
        e.Graphics.DrawString(EmployeeID, f8, Brushes.Black, 130, 47, left)

        e.Graphics.DrawString("Overtime Hours:", f8b, Brushes.Black, 300, 47, left)
        e.Graphics.DrawString(OTHours, f8, Brushes.Black, 425, 47, left)

        e.Graphics.DrawString(line, f8, Brushes.Black, centermargin, 62, center)

        e.Graphics.DrawString("Basic Pay:", f8b, Brushes.Black, 10, 77)
        e.Graphics.DrawString(BasicPay, f8, Brushes.Black, 130, 77)

        e.Graphics.DrawString("LATE/UT/ABSENT:", f8b, Brushes.Black, 10, 89)
        e.Graphics.DrawString(Tardiness, f8, Brushes.Black, 130, 89)

        e.Graphics.DrawString("SSS:", f8b, Brushes.Black, 300, 77)
        e.Graphics.DrawString(SSS, f8, Brushes.Black, 375, 77)

        e.Graphics.DrawString("Overtime Pay:", f8b, Brushes.Black, 10, 101)
        e.Graphics.DrawString(OTPay, f8, Brushes.Black, 130, 101)

        e.Graphics.DrawString("PHIC:", f8b, Brushes.Black, 300, 89)
        e.Graphics.DrawString(PHIC, f8, Brushes.Black, 375, 89)

        e.Graphics.DrawString("Holiday Pay:", f8b, Brushes.Black, 10, 113)
        e.Graphics.DrawString(HolidayPay, f8, Brushes.Black, 130, 113)

        e.Graphics.DrawString("HDMF:", f8b, Brushes.Black, 300, 101)
        e.Graphics.DrawString(HDMF, f8, Brushes.Black, 375, 101)

        e.Graphics.DrawString("Gross Pay:", f8b, Brushes.Black, 10, 125)
        e.Graphics.DrawString(GrossPay, f8, Brushes.Black, 130, 125)

        e.Graphics.DrawString("Tax:", f8b, Brushes.Black, 300, 113)
        e.Graphics.DrawString(Tax, f8, Brushes.Black, 375, 113)

        e.Graphics.DrawString(line, f8, Brushes.Black, centermargin, 140, center)

        e.Graphics.DrawString("TOTAL DEDUCTION:", f8b, Brushes.Black, 10, 155)
        e.Graphics.DrawString(TotalDeduction, f8, Brushes.Black, 130, 155)

        e.Graphics.DrawString("NET PAY:", f8b, Brushes.Black, 10, 167)
        e.Graphics.DrawString(NetPay, f8, Brushes.Black, 130, 167)
    End Sub

    Private Sub PrintPayrollForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PayrollYearDateTimePicker.Value = Date.Today.Month & "/01/" & Date.Today.Year
        PayrollMonthDateTimePicker.Value = Date.Today.Month & "/01/" & Date.Today.Year
        PayrollTypeComboBox.SelectedIndex = 0
        PayrollCutOffComboBox.SelectedIndex = 0
        GetNames()
    End Sub

    Public EmpID As New List(Of String)

    Public Sub GetNames()
        Dim query = "SELECT EmployeeID, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName
        FROM Employees"

        Prepare(query)
        ExecutePrepare()

        For Each row As DataRow In DataAsTable.Rows
            EmpID.Add(row("EmployeeID"))
        Next

        PayrollEmpNameComboBox.DisplayMember = "EmployeeName"
        PayrollEmpNameComboBox.DataSource = DataAsTable
        PayrollEmpNameComboBox.SelectedIndex = 0
        PayrollEmpNameComboBox.MaxDropDownItems = 5
    End Sub

    Private Sub PrintPayrollForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        DashBoardForm.Enabled = True
        DashBoardForm.Show()
    End Sub

    Private Sub PayrollEmpNameComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PayrollEmpNameComboBox.SelectedIndexChanged
        PayrollEmpIDLabel.Text = EmpID.Item(PayrollEmpNameComboBox.SelectedIndex)
    End Sub
End Class