Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices.ComTypes
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class EmployeeDashBoard
    Public WelcomeText As String
    Public EmpID As String
    Public EmpName As String
    Public Password As String


    Private Sub MenuHide6Button_Click(sender As Object, e As EventArgs) Handles MenuHide6Button.Click
        Try
            If Panel1.AutoSize = True Then
                Panel1.AutoSize = False
            Else
                Panel1.AutoSize = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WelcomeLabel.Text = WelcomeText
        PanelLeave.Visible = False

        LoadHolidayDetails()
        LeaveLabel.Text = GetLeaveBalance()
        LoadPendingLeaveRequest()
        GetUpcomingProject()
        CheckPassword(Password, EmpID)
    End Sub

    Public Sub CheckPassword(Password As String, EmpID As String)
        If Password = EmpID Then
            If MsgBox("You still haven't changed your default password. Do you want to change it now?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.Yes Then
                btnPersonalInfo.PerformClick()
            End If
        End If
    End Sub

    Public Sub GetUpcomingProject()
        Dim query = "SELECT * FROM [Projects] WHERE MONTH(ProjectDateStart) >= @Month  AND DAY(ProjectDateStart) >= @Day AND YEAR(ProjectDateStart) = @Year AND ProjectStatusID = @Status"

        Prepare(query)
        AddParam("@Month", Date.Today.Month)
        AddParam("@Day", 1)
        AddParam("@Year", Date.Today.Year)
        AddParam("@Status", 1)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)
            DashOngoingLabel.Text = DataAsTable.Rows.Count
            DashProjNameLabel.Text = row("ProjectName")
            DashProjDurationLabel.Text = row("ProjectDuration") & " days."
        End If
    End Sub

    Public Sub LoadPendingLeaveRequest()
        Dim query = "SELECT COUNT(EmployeeID) AS Pending FROM LeaveRequest WHERE EmployeeID=@EmpID AND StatusID = 1"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            LeaveRequestPendingLabel.Text = row("Pending")
        End If
    End Sub

    Private Sub btnLeave_Click(sender As Object, e As EventArgs) Handles btnLeave.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "LeavePNL" Then
                gb.Visible = True
                gb.Enabled = True
                LeaveDateFromDTP.Value = Date.Today
                LeaveDateToDTP.Value = Date.Today
                PopulateLeaveType()
                GetLeaveRequests()
                LeaveBalanceLabel.Text = GetLeaveBalance()
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "DashboardPNL" Then
                gb.Visible = True
                gb.Enabled = True
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub btnAttendance_Click(sender As Object, e As EventArgs) Handles btnAttendance.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "AttendancePNL" Then
                gb.Visible = True
                gb.Enabled = True
                LoadAttendance()
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Public Sub LoadAttendance()
        Dim query = "SELECT AttDate, CONVERT(varchar, AttendanceRecords.TimeIn, 22) AS TimeIn, CONVERT(varchar, AttendanceRecords.TimeOut, 22) AS TimeOut, TotalHours, Late, OT, Undertime, HalfDay 
        FROM AttendanceRecords
        LEFT OUTER JOIN Employees
        ON AttendanceRecords.EmployeeID = Employees.EmployeeID  
        WHERE CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) LIKE @Search"

        Prepare(query)
        AddParam("@Search", "%" & EmpName & "%")
        ExecutePrepare()

        AttendanceSheetDataGridView.DataSource = DataAsTable
        AttendanceSheetDataGridView.Sort(AttendanceSheetDataGridView.Columns(0), ListSortDirection.Descending)
    End Sub

    Private Sub btnHoliday_Click(sender As Object, e As EventArgs) Handles btnHoliday.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "HolidayListPanel" Then
                gb.Visible = True
                gb.Enabled = True
                HolidayDateTimePicker.Value = Date.Today.Month & "/01/" & Date.Today.Year
                LoadHolidayDetails()
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub HolidayRefreshButton_Click(sender As Object, e As EventArgs) Handles HolidayRefreshButton.Click
        LoadHoliday(HolidayDateTimePicker.Value.Month)
        LoadHolidayDetails()
    End Sub

    Private Sub HolidaySearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles HolidaySearchTextBox.TextChanged
        If HolidaySearchTextBox.Text = "" Then
            HolidayDateTimePicker.Enabled = True
            LoadHoliday(HolidayDateTimePicker.Value.Month)
        Else
            HolidayDateTimePicker.Enabled = False

            Dim query = "SELECT HolidayDate, Description, Type FROM Holidays WHERE Description LIKE @Search ORDER BY HolidayDate"

            Prepare(query)
            AddParam("@Search", "%" & HolidaySearchTextBox.Text & "%")
            ExecutePrepare()

            HolidayDataGridView.DataSource = DataAsTable.DefaultView
        End If
    End Sub

    Private Sub HolidayDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles HolidayDateTimePicker.ValueChanged
        Dim SelectedMonth As Integer = HolidayDateTimePicker.Value.Month
        LoadHoliday(SelectedMonth)
    End Sub

    Public Sub LoadHoliday(SelectedMonth As Integer)
        Dim query = "SELECT HolidayDate, Description, Type FROM Holidays WHERE MONTH(HolidayDate) = @Month ORDER BY HolidayDate"

        Prepare(query)
        AddParam("@Month", SelectedMonth)
        ExecutePrepare()

        HolidayDataGridView.DataSource = DataAsTable.DefaultView
        Try
            HolidayDataGridView.Sort(HolidayDataGridView.Columns(0), ListSortDirection.Ascending)
        Catch ex As Exception

        End Try
        HolidayDataGridView.CurrentCell = Nothing
    End Sub

    Public Sub LoadHolidayDetails()
        Dim dayOfWeek = CInt(Date.Today.DayOfWeek)
        Dim startOfWeek = Date.Today.AddDays(-1 * dayOfWeek)
        Dim endOfWeek = Date.Today.AddDays(7 - dayOfWeek)

        Dim HolTom As Integer
        Dim HolWeek As Integer
        Dim HolMonth As Integer
        Dim RegCount As Integer
        Dim SPWCount As Integer

        Dim query = "SELECT HolidayDate, Description, Type FROM Holidays WHERE MONTH(HolidayDate) = @Month ORDER BY HolidayDate"

        Prepare(query)
        AddParam("@Month", Date.Today.Month)
        ExecutePrepare()

        If Count > 0 Then
            For Each row As DataRow In DataAsTable.Rows
                If row("HolidayDate") = Date.Today.AddDays(1) Then
                    HolTom += 1
                End If

                If row("HolidayDate") >= startOfWeek And row("HolidayDate") <= endOfWeek Then
                    HolWeek += 1
                End If

                If Convert.ToDateTime(row("HolidayDate")).ToString("MM") = Date.Today.Month Then
                    HolMonth += 1
                End If

                If row("Type") = "Regular" Then
                    RegCount += 1
                End If

                If row("Type") = "Special Non-Working" Then
                    SPWCount += 1
                End If
            Next
        End If

        HolidayMonthNameLabel.Text = Date.Today.ToString("MMMM").ToUpper
        HolidayTomLabel.Text = HolTom
        DashTomLabel.Text = HolTom
        HolidayWeekLabel.Text = HolWeek
        DashWeekLabel.Text = HolWeek
        HolidayMonthLabel.Text = HolMonth
        DashMonthLabel.Text = HolMonth
        HolidayRegularLabel.Text = RegCount
        HolidaySpecialLabel.Text = SPWCount
    End Sub

    Private Sub brnProject_Click(sender As Object, e As EventArgs) Handles brnProject.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "ProjectsListPanel" Then
                gb.Visible = True
                gb.Enabled = True
                LoadProjects(ProjectNameSearchTextBox.Text)
                LoadProjectDetails()
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Public Sub LoadProjectDetails()
        Dim PJTotal As Integer
        Dim PJOngoing As Integer
        Dim PJCompleted As Integer

        Dim query = "SELECT * FROM Projects"

        Prepare(query)
        ExecutePrepare()

        Dim row As DataRow

        For Each row In DataAsTable.Rows
            If row("ProjectStatusID") > 0 Then
                PJTotal += 1
            End If

            If row("ProjectStatusID") = 1 Then
                PJOngoing += 1
            End If

            If row("ProjectStatusID") = 2 Then
                PJCompleted += 1
            End If
        Next
        PJTotalLabel.Text = PJTotal
        PJOngoingLabel.Text = PJOngoing
        PJCompletedLabel.Text = PJCompleted
    End Sub

    Public Sub GetLeaveRequests()
        Dim query = "SELECT CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' 
        THEN '' ELSE Employees.MiddleName END) AS EmployeeName, LeaveType.Type, LeaveRequest.DateFiled, LeaveRequest.DateFrom, LeaveRequest.DateTo,
		LeaveRequest.Duration, LeaveRequest.Reason, LeaveStatus.Status, LeaveRequest.VerdictDate
        FROM LeaveRequest
        LEFT OUTER JOIN Employees
        ON LeaveRequest.EmployeeID = Employees.EmployeeID
        LEFT OUTER JOIN LeaveType
        ON LeaveRequest.LeaveTypeID = LeaveType.ID
        LEFT OUTER JOIN LeaveStatus
        ON LeaveRequest.StatusID = LeaveStatus.ID
        WHERE LeaveRequest.EmployeeID=@EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        LeaveRequestDataGridView.DataSource = DataAsTable.DefaultView
        LeaveRequestDataGridView.CurrentCell = Nothing
    End Sub

    Public Sub PopulateLeaveType()
        Dim query = "SELECT * FROM LeaveType"

        Prepare(query)
        ExecutePrepare()

        LeaveTypeCMB.MaxDropDownItems = 5
        LeaveTypeCMB.DataSource = DataAsTable.DefaultView
        LeaveTypeCMB.DisplayMember = "Type"
        LeaveTypeCMB.SelectedIndex = 0
    End Sub

    Public Function GetLeaveBalance()
        Dim query = "SELECT Balance FROM LeaveBalance WHERE EmployeeID=@EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            Return row("Balance")
        Else
            Return 0
        End If
    End Function

    Private Sub LeaveRequestRefreshButton_Click(sender As Object, e As EventArgs) Handles LeaveRequestRefreshButton.Click
        LeaveDateFromDTP.Value = Date.Today
        LeaveDateToDTP.Value = Date.Today
        PopulateLeaveType()
        GetLeaveRequests()
        LeaveBalanceLabel.Text = GetLeaveBalance()
    End Sub

    Public Function CheckIfPending() As Boolean
        Dim query = "SELECT CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' 
        THEN '' ELSE Employees.MiddleName END) AS EmployeeName, LeaveType.Type, LeaveRequest.DateFiled, LeaveRequest.DateFrom, LeaveRequest.DateTo,
		LeaveRequest.Duration, LeaveRequest.Reason, LeaveStatus.Status, LeaveRequest.VerdictDate
        FROM LeaveRequest
        LEFT OUTER JOIN Employees
        ON LeaveRequest.EmployeeID = Employees.EmployeeID
        LEFT OUTER JOIN LeaveType
        ON LeaveRequest.LeaveTypeID = LeaveType.ID
        LEFT OUTER JOIN LeaveStatus
        ON LeaveRequest.StatusID = LeaveStatus.ID
        WHERE LeaveRequest.EmployeeID=@EmpID AND LeaveStatus.Status = @LeaveStatus"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        AddParam("@LeaveStatus", "Under Review")
        ExecutePrepare()

        If Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub LeaveRequestAddButton_Click(sender As Object, e As EventArgs) Handles LeaveRequestAddButton.Click
        MsgBox(CheckIfPending)
        If CheckIfPending() Then
            MsgBox(" Request failed. You already have a pending leave request.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Alert")
        Else
            Dim LeaveBalance As Integer = LeaveBalanceLabel.Text
            Dim LeaveDays As Integer
            Dim StartDate, EndDate As Date

            StartDate = LeaveDateFromDTP.Value
            EndDate = LeaveDateToDTP.Value

            For i = StartDate.Date.Day To EndDate.Date.Day
                Dim Day As String = LeaveDateFromDTP.Value.Month & "/" & i & "/" & LeaveDateFromDTP.Value.Year
                Dim CheckDay As Date

                Date.TryParse(Day, CheckDay)

                If CheckDay.DayOfWeek <> DayOfWeek.Sunday Then
                    LeaveDays += 1
                End If
            Next

            If LeaveReasonTxt.Text <> "" Then
                If LeaveDays > LeaveBalance Then
                    MsgBox("Your leave days must not exceed you leave balance. 1 balance equates to 1 day.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Alert")
                Else
                    If MsgBox("Are you sure to proceed to file a leave request?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
                        Dim query = "INSERT INTO LeaveRequest (EmployeeID, LeaveTypeID, DateFiled, DateFrom, DateTo, Duration, Reason, StatusID, VerdictDate)
                    VALUES (@EmployeeID, @LeaveTypeID, @DateFiled, @DateFrom, @DateTo, @Duration, @Reason, @StatusID, @VerdictDate)"

                        Prepare(query)
                        AddParam("@EmployeeID", EmpID)
                        AddParam("@LeaveTypeID", LeaveTypeCMB.SelectedIndex + 1)
                        AddParam("@DateFiled", Date.Today)
                        AddParam("@DateFrom", LeaveDateFromDTP.Value)
                        AddParam("@DateTo", LeaveDateToDTP.Value)
                        AddParam("@Duration", LeaveDays)
                        AddParam("@Reason", LeaveReasonTxt.Text)
                        AddParam("@StatusID", 1)
                        AddParam("@VerdictDate", DBNull.Value)
                        ExecutePrepare()

                        For Each ctrl In Panel9.Controls
                            If TypeOf ctrl Is ComboBox Then
                                ctrl.selectedindex = 0
                            ElseIf TypeOf ctrl Is DateTimePicker Then
                                ctrl.value = Date.Today
                            End If
                        Next

                        UpdateLeaveBalance(LeaveDays)
                        LeaveReasonTxt.Text = ""
                        LeaveRequestRefreshButton.PerformClick()

                        MsgBox("Leave request successfully filed.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
                    End If
                End If
            Else
                MsgBox("The reason for the leave must be filled-up first.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Alert")
            End If
        End If
    End Sub

    Public Sub UpdateLeaveBalance(Balance As Integer)
        Dim query = "UPDATE LeaveBalance SET Balance= Balance - @Balance WHERE EmployeeID=@EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        AddParam("@Balance", Balance)
        ExecutePrepare()
    End Sub

    Public Sub LoadProjects(PJName As String)
        Dim NameSearch As String

        If ProjectNameSearchTextBox.Text = "" Then
            NameSearch = ""
        Else
            NameSearch = " WHERE Projects.ProjectName LIKE @NameSearch"
        End If

        Dim query = "SELECT Projects.ID, Projects.ProjectName, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS ProjectHead,
        Projects.ProjectDescription, Projects.ProjectDateCreation, Projects.ProjectDateStart, Projects.ProjectDateEnd, Projects.ProjectDuration, ProjectsStatus.Status
        FROM Projects
        LEFT OUTER JOIN Employees
        ON Projects.ProjectHeadID = Employees.EmployeeID
        LEFT OUTER JOIN ProjectsStatus
        ON Projects.ProjectStatusID = ProjectsStatus.ID" & NameSearch

        Prepare(query)
        If ProjectNameSearchTextBox.Text <> "" Then
            AddParam("@NameSearch", "%" & ProjectNameSearchTextBox.Text & "%")
        End If
        ExecutePrepare()

        ProjectsDataGridView.DataSource = DataAsTable.DefaultView
        ProjectsDataGridView.Sort(ProjectsDataGridView.Columns(8), ListSortDirection.Descending)
        ProjectsDataGridView.CurrentCell = Nothing
    End Sub

    Private Sub PJRefreshButton_Click(sender As Object, e As EventArgs) Handles PJRefreshButton.Click
        LoadProjects(ProjectNameSearchTextBox.Text)
        LoadProjectDetails()
    End Sub

    Private Sub ProjectNameSearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles ProjectNameSearchTextBox.TextChanged
        LoadProjects(ProjectNameSearchTextBox.Text)
    End Sub

    Private Sub EmployeeDashBoard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Are you sure to log-out/exit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.Yes Then
            e.Cancel = False
            Login.Show()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click
        Me.Close()
    End Sub

    Public Function GetPassword()
        Dim query = "SELECT Password FROM Employees WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            Return row("Password")
        Else
            Return Nothing
        End If
    End Function

    Private Sub btnPersonalInfo_Click(sender As Object, e As EventArgs) Handles btnPersonalInfo.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "AccountPNL" Then
                gb.Visible = True
                gb.Enabled = True
                AccountIDLabel.Text = EmpID
                AccountUsernameText.Text = EmpID
                AccountNameLabel.Text = EmpName
                AccountCurrentPassText.Text = GetPassword()
                AccountNewPassText.Select()
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub AccountClearButton_Click(sender As Object, e As EventArgs) Handles AccountClearButton.Click
        AccountNewPassText.Text = ""
        AccountConfirmPassText.Text = ""
        AccountNewPassText.Select()
    End Sub

    Private Sub NewPassEyeButton_Click(sender As Object, e As EventArgs) Handles NewPassEyeButton.Click
        If AccountNewPassText.UseSystemPasswordChar = False Then
            AccountNewPassText.UseSystemPasswordChar = True
        Else
            AccountNewPassText.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub NewConfirmEyeButton_Click(sender As Object, e As EventArgs) Handles NewConfirmEyeButton.Click
        If AccountConfirmPassText.UseSystemPasswordChar = False Then
            AccountConfirmPassText.UseSystemPasswordChar = True
        Else
            AccountConfirmPassText.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub AccountOKButton_Click(sender As Object, e As EventArgs) Handles AccountOKButton.Click
        If AccountCurrentPassText.Text = AccountNewPassText.Text Then
            MsgBox("Your new password cannot be the same as your old password. Please try again.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
        Else
            If AccountNewPassText.Text <> AccountConfirmPassText.Text Then
                MsgBox("Your passwords do not match. Please try again.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
            Else
                If MsgBox("Are you sure to update your password?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.Yes Then
                    Dim query = "UPDATE Employees SET Password = @Password WHERE EmployeeID = @EmpId"

                    Prepare(query)
                    AddParam("@Password", AccountNewPassText.Text)
                    AddParam("@EmpID", EmpID)
                    ExecutePrepare()

                    AccountNewPassText.Text = ""
                    AccountConfirmPassText.Text = ""

                    MsgBox("Your password has been successfully updated.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")

                    AccountNewPassText.Select()
                    AccountCurrentPassText.Text = GetPassword()
                End If
            End If
        End If
    End Sub

    Private Sub PayrollDisplayButton_Click(sender As Object, e As EventArgs) Handles PayrollDisplayButton.Click
        If CheckIfGenerated() Then
            LoadPayroll()
        Else
            MsgBox("Display failed. There's no payroll record.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
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

        Dim CutOffPeriod = PayrollMonthDateTimePicker.Value.Month & "/" & DayFrom & " - " & PayrollMonthDateTimePicker.Value.Month & "/" & DayTo & " " & PayrollYearDateTimePicker.Value.Year

        Prepare(query)
        AddParam("@EmpID", EmpID)
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

            PayrollEmpIDLabel.Text = EmpID
            PayrollEmpNameLabel.Text = EmpName
            PayrollCutOffLabel.Text = CutOffPeriod
            PayrollTotalDaysLabel.Text = Format(row("TotalWorkDays"), "##0.00") & " / " & Format(row("TotalHours"), "##0.00")
            PayrollOTHoursLabel.Text = Format(row("OTHours"), "##0.00")
            PayrollBasicPayLabel.Text = Format(row("BasicPay"), "P##,##0.00")
            PayrollTardinessLabel.Text = Format(row("Deduction_Tardiness"), "P##,##0.00")
            PayrollGrossPayLabel.Text = Format(row("GrossPay"), "P##,##0.00")
            PayrollHolidayPayLabel.Text = Format(row("HolidayPay"), "P##,##0.00")
            PayrollOTPayLabel.Text = Format(row("OTPay"), "P##,##0.00")
            PayrollSSSLabel.Text = Format(row("SSS"), "P##,##0.00")
            PayrollPHICLabel.Text = Format(row("PHIC"), "P##,##0.00")
            PayrollHDMFLabel.Text = Format(row("HDMF"), "P##,##0.00")
            PayrollTaxLabel.Text = Format(row("Tax"), "P##,##0.00")
            PayrollTotalDeductionLabel.Text = Format(row("TotalDeductions"), "P##,##0.00")
            PayrollNetPayLabel.Text = Format(row("NetPay"), "P##,##0.00")
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

    Private Sub btnPayroll_Click(sender As Object, e As EventArgs) Handles btnPayroll.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "PayrollPanel" Then
                gb.Visible = True
                gb.Enabled = True
                PayrollYearDateTimePicker.Value = Date.Today.Month & "/01/" & Date.Today.Year
                PayrollMonthDateTimePicker.Value = Date.Today.Month & "/01/" & Date.Today.Year
                PayrollTypeComboBox.SelectedIndex = 0
                PayrollCutOffComboBox.SelectedIndex = 0
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub DateTimeTimer_Tick(sender As Object, e As EventArgs) Handles DateTimeTimer.Tick
        Dim CurDateTime As Date = Date.Now
        TimeLabel.Text = CurDateTime.ToString("hh:mm:ss tt")
        DateLabel.Text = CurDateTime.ToLongDateString
    End Sub

    Private Sub DashRefreshButton_Click(sender As Object, e As EventArgs) Handles DashRefreshButton.Click
        LoadHolidayDetails()
        GetUpcomingProject()
        LeaveLabel.Text = GetLeaveBalance()
        LoadPendingLeaveRequest()
        GetUpcomingProject()
    End Sub
End Class