Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports MessagingToolkit.QRCode.Codec

Public Class DashBoardForm
    Public WelcomeText As String

    Public EmpNames As New List(Of String)
    Public EmployeeID As New List(Of String)
    Public DepartmentID As New List(Of String)
    Public att As New List(Of String)

    Public DeleteDate As Date
    Public DeleteProjectID
    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WelcomeLabel.Text = WelcomeText
        RefreshTable()
        LoadAttendanceDetails()
        LoadLeaveRequestDetails()
        LoadHolidayDetails()
        GetUpcomingProject()
        CheckLeave()
    End Sub

    Private Sub DashUpdateTimer_Tick(sender As Object, e As EventArgs) Handles DashUpdateTimer.Tick
        LoadAttendanceDetails()
        LoadLeaveRequestDetails()
        LoadHolidayDetails()
        GetUpcomingProject()
    End Sub

    Public Sub CheckLeave()
        Dim query = "SELECT EmployeeID, DateFrom, DateTo FROM LeaveRequest WHERE StatusID = 2"

        Prepare(query)
        ExecutePrepare()

        For Each row As DataRow In DataAsTable.Rows
            If row("DateTo") < Date.Today Then
                UpdateLeave(row("EmployeeID"), DBNull.Value)
            End If

            If row("DateFrom") >= Date.Today Then
                UpdateLeave(row("EmployeeID"), 1)
            End If
        Next
    End Sub

    Public Sub UpdateLeave(EmpID As String, val As Object)
        Dim query = "UPDATE Employees SET OnLeaveID = @Val WHERE EmployeeID = @EmpID"

        Prepare(query)
        If val > 0 Then
            AddParam("@Val", val)
        Else
            AddParam("@Val", DBNull.Value)
        End If
        AddParam("@EmpID", EmpID)
        ExecutePrepare()
    End Sub

    Private Sub btnAttendance_Click(sender As Object, e As EventArgs) Handles btnAttendance.Click
        For Each gb As Panel In SideBarPanel.Controls.OfType(Of Panel)
            If gb.Name = "PanelAtt" And gb.Visible = False Then
                gb.Visible = True
            Else
                gb.Visible = False
            End If
        Next
    End Sub

    Private Sub btnLeave_Click(sender As Object, e As EventArgs) Handles btnLeave.Click
        For Each gb As Panel In SideBarPanel.Controls.OfType(Of Panel)
            If gb.Name = "PanelLeave" And gb.Visible = False Then
                gb.Visible = True
            Else
                gb.Visible = False
            End If
        Next
    End Sub

    Private Sub btnHoliday_Click(sender As Object, e As EventArgs) Handles btnHoliday.Click
        For Each gb As Panel In SideBarPanel.Controls.OfType(Of Panel)
            If gb.Name = "PanelHoliday" And gb.Visible = False Then
                gb.Visible = True
            Else
                gb.Visible = False
            End If
        Next
    End Sub

    Private Sub brnProject_Click(sender As Object, e As EventArgs) Handles brnProject.Click
        For Each gb As Panel In SideBarPanel.Controls.OfType(Of Panel)
            If gb.Name = "PanelProject" And gb.Visible = False Then
                gb.Visible = True
            Else
                gb.Visible = False
            End If
        Next
    End Sub

    Private Sub btnPayroll_Click(sender As Object, e As EventArgs) Handles btnPayroll.Click
        For Each gb As Panel In SideBarPanel.Controls.OfType(Of Panel)
            If gb.Name = "PanelPayroll" And gb.Visible = False Then
                gb.Visible = True
            Else
                gb.Visible = False
            End If
        Next
    End Sub

    Private Sub btnEmployee_Click(sender As Object, e As EventArgs) Handles btnEmployee.Click
        For Each gb As Panel In SideBarPanel.Controls.OfType(Of Panel)
            If gb.Name = "PanelEmployee" And gb.Visible = False Then
                gb.Visible = True
            Else
                gb.Visible = False
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles MenuHide1Button.Click, MenuHide2Button.Click, MenuHide3Button.Click, MenuHide5Button.Click, MenuHide6Button.Click, MenuHide7Button.Click,
    MenuHide8Button.Click, MenuHide9Button.Click, MenuHide10Button.Click, MenuHide11Button.Click, MenuHide12Button.Click
        Try
            If Panel1.AutoSize = True Then
                Panel1.AutoSize = False
            Else
                Panel1.AutoSize = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAtt1_Click(sender As Object, e As EventArgs) Handles btnAtt1.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "AttendanceTodayPanel" Then
                LoadAttendanceToday()
                LoadAttendanceDetails()
                gb.Visible = True
                gb.Enabled = True
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Public Sub HidePanel(PanelName As String)
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = PanelName Then
                LoadAttendanceToday()
                LoadAttendanceDetails()
                gb.Visible = True
                gb.Enabled = True
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub btnAtt2_Click(sender As Object, e As EventArgs) Handles btnAtt2.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "EmployeeAttendancePanel" Then
                gb.Visible = True
                gb.Enabled = True
                EmployeeAttendanceDateTimePicker.Value = Date.Today.Month & "/01/" & Date.Today.Year
                LoadEmployeeAttendace()
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub EARefreshButton_Click(sender As Object, e As EventArgs) Handles EARefreshButton.Click
        LoadEmployeeAttendace()
    End Sub

    Private Sub EmployeeAttendanceDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles EmployeeAttendanceDateTimePicker.ValueChanged
        LoadEmployeeAttendace()
    End Sub

    Public Sub LoadEmployeeAttendace()
        Dim EAMonth As Integer = EmployeeAttendanceDateTimePicker.Value.Month
        Dim EAYear As Integer = EmployeeAttendanceDateTimePicker.Value.Year
        Dim DatesInAMonth As Integer = Date.DaysInMonth(EAYear, EAMonth)

        Dim dgv As DataGridView = EmployeeAttendanceDataGridView
        dgv.Rows.Clear()
        dgv.Columns.Clear()

        Dim Empcol As New DataGridViewTextBoxColumn With {
            .HeaderText = "Employee Name",
            .DataPropertyName = "EmployeeName",
            .Frozen = True
        }
        dgv.Columns.Add(Empcol)

        Dim NullVal As New DataGridViewCellStyle With {
            .NullValue = "-"
        }

        For i = 1 To DatesInAMonth
            Dim Datecol As New DataGridViewTextBoxColumn With {
                .HeaderText = i,
                .DataPropertyName = i,
                .DefaultCellStyle = NullVal
            }
            dgv.Columns.Add(Datecol)
        Next

        Dim query = "SELECT AttendanceRecords.ID, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName, 
        AttendanceRecords.AttDate, CONVERT(varchar, AttendanceRecords.TimeIn, 22) AS TimeIn, CONVERT(varchar, AttendanceRecords.TimeOut, 22) AS TimeOut, 
        AttendanceRecords.TotalHours 
        FROM AttendanceRecords
        LEFT OUTER JOIN Employees
        ON AttendanceRecords.EmployeeID = Employees.EmployeeID  
        WHERE MONTH(AttDate) = @Month AND YEAR(AttDate) = @Year"

        Prepare(query)
        AddParam("@Month", EAMonth)
        AddParam("@Year", EAYear)
        ExecutePrepare()

        For i = 0 To DataAsTable.Rows.Count - 1
            Dim row As DataRow = DataAsTable.Rows(i)

            If EmpNames.Contains(row("EmployeeName").ToString) Then

            Else
                EmpNames.Add(row("EmployeeName"))
            End If
        Next

        GetAttendance(DatesInAMonth, EAMonth, EAYear)
    End Sub

    Public Sub GetAttendance(DatesInAMonth As Integer, EAMonth As Integer, EAYear As Integer)
        For i = 0 To EmpNames.Count - 1
            Dim query = "SELECT AttendanceRecords.ID, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName, 
            AttendanceRecords.AttDate, CONVERT(varchar, AttendanceRecords.TimeIn, 22) AS TimeIn, CONVERT(varchar, AttendanceRecords.TimeOut, 22) AS TimeOut, 
            AttendanceRecords.TotalHours 
            FROM AttendanceRecords
            LEFT OUTER JOIN Employees
            ON AttendanceRecords.EmployeeID = Employees.EmployeeID  
            WHERE MONTH(AttDate) = @Month AND YEAR(AttDate) = @Year AND CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) LIKE @Search"
            Dim EmployeeName As String = EmpNames.Item(i)


            Prepare(query)
            AddParam("@Month", EAMonth)
            AddParam("@Year", EAYear)
            AddParam("@Search", EmployeeName)
            ExecutePrepare()

            Dim dgv As DataGridView = EmployeeAttendanceDataGridView
            For Each row As DataRow In DataAsTable.Rows
                att.Add(row("EmployeeName"))
                If EmployeeName = row("EmployeeName") Then
                    For a = 1 To DatesInAMonth
                        If row("AttDate") = EAMonth & "/" & a & "/" & EAYear Then
                            att.Add("-")
                            'att.Add("✖")

                            If att(a) = "-" Then
                                att.Item(a) = "✔"
                            End If
                        Else
                            att.Add("-")
                        End If
                    Next
                End If
            Next
            dgv.Rows.Add(att.ToArray)
            att.Clear()
        Next
        EmpNames.Clear()
    End Sub

    Private Sub btnAtt3_Click(sender As Object, e As EventArgs) Handles btnAtt3.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "AttendanceSheetPanel" Then
                gb.Visible = True
                gb.Enabled = True
                PopulateEmployeeNames()
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub ASEmployeeNamesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ASEmployeeNamesComboBox.SelectedIndexChanged
        Dim query = "SELECT AttDate, CONVERT(varchar, AttendanceRecords.TimeIn, 22) AS TimeIn, CONVERT(varchar, AttendanceRecords.TimeOut, 22) AS TimeOut, TotalHours, Late, OT, Undertime, HalfDay 
        FROM AttendanceRecords
        LEFT OUTER JOIN Employees
        ON AttendanceRecords.EmployeeID = Employees.EmployeeID  
        WHERE CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) LIKE @Search"

        Prepare(query)
        AddParam("@Search", "%" & ASEmployeeNamesComboBox.Text & "%")
        ExecutePrepare()

        AttendanceSheetDataGridView.DataSource = DataAsTable
        AttendanceSheetDataGridView.Sort(AttendanceSheetDataGridView.Columns(0), ListSortDirection.Descending)
    End Sub

    Public Sub PopulateEmployeeNames()
        Dim query = "SELECT CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName 
        FROM Employees"

        Prepare(query)
        ExecutePrepare()

        ASEmployeeNamesComboBox.MaxDropDownItems = 5
        ASEmployeeNamesComboBox.DataSource = DataAsTable
        ASEmployeeNamesComboBox.DisplayMember = "EmployeeName"
        ASEmployeeNamesComboBox.SelectedIndex = 0
    End Sub

    Public Sub LoadAttendanceDetails()
        Dim Total As Integer = GetTotalEmployee()
        Dim Present As Integer = GetPresentEmployee()
        Dim OnLeave As Integer = GetOnLeaveEmployee()

        ATTotalLabel.Text = Total
        DashTotalLabel.Text = Total
        ATPresentLabel.Text = Present
        DashPresentLabel.Text = Present
        ATAbsentLabel.Text = Total - (Present + OnLeave)
        DashAbsentLabel.Text = Total - (Present + OnLeave)
        ATLeaveLabel.Text = OnLeave
        DashLeaveLabel.Text = OnLeave
    End Sub

    Public Function GetOnLeaveEmployee()
        Dim query = "SELECT COUNT(OnLeaveID) AS LeaveCount FROM Employees"

        Prepare(query)
        ExecutePrepare()

        If Not DataAsTable.Rows(0).IsNull(0) Then
            Return DataAsTable.Rows(0).Item(0)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetTotalEmployee()
        Dim query = "SELECT COUNT(EmployeeID) AS EmployeeCount FROM Employees"

        Prepare(query)
        ExecutePrepare()

        If Not DataAsTable.Rows(0).IsNull(0) Then
            Return DataAsTable.Rows(0).Item(0)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetPresentEmployee()
        Dim query = "SELECT COUNT(EmployeeID) AS EmployeeCount FROM AttendanceRecords WHERE AttDate = @AttDate"
        Dim Curdate As Date = Date.Today

        Prepare(query)
        AddParam("@AttDate", Curdate)
        ExecutePrepare()

        If Not DataAsTable.Rows(0).IsNull(0) Then
            Return DataAsTable.Rows(0).Item(0)
        Else
            Return Nothing
        End If
    End Function

    Public Sub LoadAttendanceToday()
        Dim query = "SELECT AttendanceRecords.ID, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName, 
        AttendanceRecords.AttDate, CONVERT(varchar, AttendanceRecords.TimeIn, 22) AS TimeIn, CONVERT(varchar, AttendanceRecords.TimeOut, 22) AS TimeOut, 
        AttendanceRecords.TotalHours 
        FROM AttendanceRecords
        LEFT OUTER JOIN Employees
        ON AttendanceRecords.EmployeeID = Employees.EmployeeID  
        WHERE AttDate = @AttDate"
        Dim Curdate As Date = Date.Today

        Prepare(query)
        AddParam("@AttDate", Curdate)
        ExecutePrepare()

        AttendanceTodayDataGridView.DataSource = DataAsTable
        AttendanceTodayDataGridView.Sort(AttendanceTodayDataGridView.Columns(2), ListSortDirection.Descending)
    End Sub

    Private Sub AttendanceSearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles AttendanceSearchTextBox.TextChanged
        If AttendanceSearchTextBox.Text = "" Then
            LoadAttendanceToday()
        Else
            Dim Curdate As Date = Date.Today
            Dim query = "SELECT AttendanceRecords.ID, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName, 
            AttendanceRecords.AttDate, CONVERT(varchar, AttendanceRecords.TimeIn, 22) AS TimeIn, CONVERT(varchar, AttendanceRecords.TimeOut, 22) AS TimeOut, 
            AttendanceRecords.TotalHours 
            FROM AttendanceRecords 
            LEFT OUTER JOIN Employees
            ON AttendanceRecords.EmployeeID = Employees.EmployeeID
            WHERE AttDate = @AttDate AND (Employees.LastName LIKE @Search OR Employees.FirstName LIKE @Search OR Employees.MiddleName LIKE @Search)"

            Prepare(query)
            AddParam("@AttDate", Curdate)
            AddParam("@Search", "%" & AttendanceSearchTextBox.Text & "%")
            ExecutePrepare()

            AttendanceTodayDataGridView.DataSource = DataAsTable
            AttendanceTodayDataGridView.Sort(AttendanceTodayDataGridView.Columns(2), ListSortDirection.Descending)
        End If
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "DashboardPanel" Then
                gb.Visible = True
                gb.Enabled = True
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub btnEm1_Click(sender As Object, e As EventArgs) Handles btnEm1.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "EmployeeAllPanel" Then
                gb.Visible = True
                gb.Enabled = True
                RefreshDetails()
                EmployeesDataGridView.CurrentCell = Nothing
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub btnEm2_Click(sender As Object, e As EventArgs) Handles btnEm2.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "EmployeesSalaryInformationPanel" Then
                gb.Visible = True
                gb.Enabled = True
                PopulateSalaryType()
                PopulateESIEmpNames()
                ESIBreakTextBox.Text = 1
                UpdateValues()
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub ESIWorkFromDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles ESIWorkFromDateTimePicker.ValueChanged
        UpdateValues()
    End Sub

    Private Sub ESIWorkToDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles ESIWorkToDateTimePicker.ValueChanged
        UpdateValues()
    End Sub

    Private Sub ESIBreakTextBox_TextChanged(sender As Object, e As EventArgs) Handles ESIBreakTextBox.TextChanged
        UpdateValues()
    End Sub

    Private Sub ESIRefreshButton_Click(sender As Object, e As EventArgs) Handles ESIRefreshButton.Click
        Dim lastindex As Integer = ESIEmpNamesComboBox.SelectedIndex

        PopulateSalaryType()
        PopulateESIEmpNames()
        ESIEmpIDLabel.Text = EmployeeID.Item(ESIEmpNamesComboBox.SelectedIndex)
        ESIDepartmentLabel.Text = DepartmentID.Item(ESIEmpNamesComboBox.SelectedIndex)
        DisplayESI()
        DisplayCreds()

        ESIEmpNamesComboBox.SelectedIndex = lastindex
    End Sub

    Public Sub UpdateValues()
        If ESIBreakTextBox.Text = "" Then

        Else
            ESIWorkTotalTextBox.Text = 0

            Dim Total As Integer = DateDiff(DateInterval.Hour, ESIWorkFromDateTimePicker.Value, ESIWorkToDateTimePicker.Value) - ESIBreakTextBox.Text

            If ESIWorkTotalTextBox.Text < 0 Then
                MsgBox("Work hours must be a non-negative number.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
            End If

            ESIWorkTotalTextBox.Text = Total
        End If
    End Sub

    Private Sub ESISaveButton_Click(sender As Object, e As EventArgs) Handles ESISaveButton.Click
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
                If MsgBox("Are you sure to update the salary information of the employee?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
                    UpdateValues()
                    UpdateESI()

                    For Each ctrl In Panel11.Controls
                        If TypeOf ctrl Is TextBox Then
                            ctrl.text = 0
                            If ctrl.tag = "Break" Then
                                ctrl.text = 1
                            End If
                        ElseIf TypeOf ctrl Is DateTimePicker Then
                            ctrl.value = Date.Today & " " & ctrl.tag
                        ElseIf TypeOf ctrl Is ComboBox Then
                            ctrl.selectedindex = 0
                        End If
                    Next

                    Dim lastindex As Integer = ESIEmpNamesComboBox.SelectedIndex
                    PopulateESIEmpNames()
                    ESIEmpNamesComboBox.SelectedIndex = lastindex

                    MsgBox("Employee salary information successfully updated.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
                End If
            Else
                If MsgBox("Are you sure to add the salary information of the employee?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
                    InsertESI()
                    UpdateValues()

                    For Each ctrl In Panel11.Controls
                        If TypeOf ctrl Is TextBox Then
                            ctrl.text = 0
                            If ctrl.tag = "Break" Then
                                ctrl.text = 1
                            End If
                        ElseIf TypeOf ctrl Is DateTimePicker Then
                            ctrl.value = Date.Today & " " & ctrl.tag
                        ElseIf TypeOf ctrl Is ComboBox Then
                            ctrl.selectedindex = 0
                        End If
                    Next

                    Dim lastindex As Integer = ESIEmpNamesComboBox.SelectedIndex
                    PopulateESIEmpNames()
                    ESIEmpNamesComboBox.SelectedIndex = lastindex

                    MsgBox("Employee salary information successfully added.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
                End If
            End If
        End If
    End Sub

    Public Sub InsertESI()
        Dim query = "INSERT INTO EmployeeSalaryInformation (EmployeeID, SalaryTypeID, WorkHoursFrom, WorkHoursTo, Total, [Break]) VALUES (@EmployeeID, @SalaryTypeID, @WorkHoursFrom, @WorkHoursTo, @Total, @Break)"

        Prepare(query)
        AddParam("@EmployeeID", EmployeeID.Item(ESIEmpNamesComboBox.SelectedIndex))
        AddParam("@SalaryTypeID", ESISalaryTypeComboBox.SelectedIndex + 1)
        AddParam("@WorkHoursFrom", ESIWorkFromDateTimePicker.Value)
        AddParam("@WorkHoursTo", ESIWorkToDateTimePicker.Value)
        AddParam("@Total", ESIWorkTotalTextBox.Text)
        AddParam("@Break", ESIBreakTextBox.Text)
        ExecutePrepare()
    End Sub

    Public Sub UpdateESI()
        Dim query = "UPDATE EmployeeSalaryInformation SET SalaryTypeID=@SalaryTypeID, WorkHoursFrom=@WorkHoursFrom, WorkHoursTo=@WorkHoursTo, Total=@Total, [Break]=@Break WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@SalaryTypeID", ESISalaryTypeComboBox.SelectedIndex + 1)
        AddParam("@WorkHoursFrom", ESIWorkFromDateTimePicker.Value)
        AddParam("@WorkHoursTo", ESIWorkToDateTimePicker.Value)
        AddParam("@Total", ESIWorkTotalTextBox.Text)
        AddParam("@Break", ESIBreakTextBox.Text)
        AddParam("@EmpID", EmployeeID.Item(ESIEmpNamesComboBox.SelectedIndex))
        ExecutePrepare()
    End Sub

    Public Function CheckESI()
        Dim query = "SELECT * FROM EmployeeSalaryInformation WHERE EmployeeID = @EmpID"
        Prepare(query)
        AddParam("@EmpID", EmployeeID.Item(ESIEmpNamesComboBox.SelectedIndex))
        ExecutePrepare()

        If Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub EDIAddCredentialsButton_Click(sender As Object, e As EventArgs) Handles EDIAddCredentialsButton.Click
        Me.Enabled = False
        EmployeeCredentialsForm.EmpID = EmployeeID.Item(ESIEmpNamesComboBox.SelectedIndex)
        EmployeeCredentialsForm.Show(Me)
    End Sub

    Public Sub DisplayCreds()
        Dim query = "SELECT Description, Increase, AuthorizedBy, Date, EffectiveDate FROM EmployeesCredentials WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmployeeID.Item(ESIEmpNamesComboBox.SelectedIndex))
        ExecutePrepare()

        If Count > 0 Then
            ESICredentialsDataGridView.DataSource = DataAsTable.DefaultView
        Else
            ESICredentialsDataGridView.DataSource = Nothing
        End If
    End Sub

    Public Sub DisplayESI()
        Dim query = "SELECT * FROM EmployeeSalaryInformation WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmployeeID.Item(ESIEmpNamesComboBox.SelectedIndex))
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            Dim WorkFrom As String = Date.Today & " " & row("WorkHoursFrom").ToString
            Dim WorkTo As String = Date.Today & " " & row("WorkHoursTo").ToString

            ESIEmpIDLabel.ForeColor = Color.Green
            ESISalaryTypeComboBox.SelectedIndex = row("SalaryTypeID") - 1
            If IsDBNull(row("Rate")) Then
                ESIRateTextBox.Text = 0
            Else
                ESIRateTextBox.Text = row("Rate")
            End If
            Date.TryParse(WorkFrom, ESIWorkFromDateTimePicker.Value)
            Date.TryParse(WorkTo, ESIWorkToDateTimePicker.Value)
            ESIWorkTotalTextBox.Text = row("Total")
            ESIBreakTextBox.Text = row("Break")
        Else
            ESIEmpIDLabel.ForeColor = Color.Red
            ESISalaryTypeComboBox.SelectedIndex = 0
            ESIRateTextBox.Text = 0
            ESIWorkFromDateTimePicker.Value = Date.Today & " 08:00:00 AM"
            ESIWorkToDateTimePicker.Value = Date.Today & " 05:00:00 PM"
            ESIBreakTextBox.Text = 1
            ESIWorkTotalTextBox.Text = DateDiff(DateInterval.Hour, ESIWorkFromDateTimePicker.Value, ESIWorkToDateTimePicker.Value) - ESIBreakTextBox.Text
        End If
    End Sub

    Public Sub PopulateESIEmpNames()
        EmployeeID.Clear()
        DepartmentID.Clear()

        Dim query = "SELECT Employees.EmployeeID, Department.Department, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName
        FROM Employees
        LEFT OUTER JOIN Department
        ON Employees.DepartmentID = Department.ID"

        Prepare(query)
        ExecutePrepare()

        For Each row As DataRow In DataAsTable.Rows
            EmployeeID.Add(row("EmployeeID"))
            DepartmentID.Add(row("Department"))
        Next

        ESIEmpNamesComboBox.DisplayMember = "EmployeeName"
        ESIEmpNamesComboBox.DataSource = DataAsTable
        ESIEmpNamesComboBox.SelectedIndex = 0
        ESIEmpNamesComboBox.MaxDropDownItems = 5
    End Sub

    Private Sub ESIEmpNamesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ESIEmpNamesComboBox.SelectedIndexChanged
        ESIEmpIDLabel.Text = EmployeeID.Item(ESIEmpNamesComboBox.SelectedIndex)
        ESIDepartmentLabel.Text = DepartmentID.Item(ESIEmpNamesComboBox.SelectedIndex)
        DisplayESI()
        DisplayCreds()
    End Sub

    Public Sub PopulateSalaryType()
        Dim query = "SELECT Type FROM SalaryType"

        Prepare(query)
        ExecutePrepare()

        ESISalaryTypeComboBox.DisplayMember = "Type"
        ESISalaryTypeComboBox.DataSource = DataAsTable
        ESISalaryTypeComboBox.SelectedIndex = 0
        ESISalaryTypeComboBox.MaxDropDownItems = 5
    End Sub

    Private Sub btnLev3_Click(sender As Object, e As EventArgs) Handles btnLev3.Click
        Me.Enabled = False
        LeaveTypeForm.Show(Me)
    End Sub

    Private Sub btnLev2_Click(sender As Object, e As EventArgs) Handles btnLev2.Click
        Me.Enabled = False
        LeaveBalanceForm.Show(Me)
    End Sub

    Private Sub btnLev1_Click(sender As Object, e As EventArgs) Handles btnLev1.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "LeaveRequestPanel" Then
                gb.Visible = True
                gb.Enabled = True
                PopulateLeaveTypes()
                LoadLeaveRequestDetails()
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub LeaveRequestDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles LeaveRequestDataGridView.CellClick
        If My.Computer.Keyboard.ShiftKeyDown Then
            LeaveRequestDataGridView.CurrentCell = Nothing
            LRViewRequestButton.BackgroundImage = HRM1.My.Resources.Resources.View_disabled
            LRViewRequestButton.Enabled = False

        Else
            Try
                LRViewRequestButton.BackgroundImage = HRM1.My.Resources.Resources.View
                LRViewRequestButton.Enabled = True

                Dim index As Integer
                index = e.RowIndex

                Dim selectedrow As DataGridViewRow
                selectedrow = LeaveRequestDataGridView.Rows(index)
                LeaveRequestViewForm.EmpIdEdit = selectedrow.Cells(0).Value
                LeaveRequestViewForm.DateFiled = selectedrow.Cells(3).Value
                LeaveRequestViewForm.Status = selectedrow.Cells(4).Value
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub LRViewRequestButton_Click(sender As Object, e As EventArgs) Handles LRViewRequestButton.Click
        Me.Enabled = False
        LeaveRequestViewForm.Show(Me)
    End Sub

    Private Sub LRRefreshButton_Click(sender As Object, e As EventArgs) Handles LRRefreshButton.Click
        PopulateLeaveTypes()
        LoadLeaveRequestDetails()
        LoadLeaveRequestFiltered()
    End Sub

    Private Sub LRShowAllCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles LRShowAllCheckBox.CheckedChanged
        If LRShowAllCheckBox.CheckState = CheckState.Checked Then
            LRStatusComboBox.Enabled = False
            LoadLeaveRequestFiltered()
        Else
            LRStatusComboBox.Enabled = True
            LoadLeaveRequestFiltered()
        End If
    End Sub

    Private Sub LRSearchNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles LRSearchNameTextBox.TextChanged
        LoadLeaveRequestFiltered()
    End Sub

    Public Sub LoadLeaveRequestFiltered()
        Dim Searchquery As String
        Dim Filterquery As String

        If LRSearchNameTextBox.Text <> "" Then
            If LRStatusComboBox.Enabled = True Then
                Searchquery = " AND CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) LIKE @EmpName"
            Else
                Searchquery = " WHERE CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) LIKE @EmpName"
            End If
        Else
            Searchquery = ""
        End If

        If LRStatusComboBox.Enabled = True Then
            Filterquery = " WHERE LeaveStatus.ID = @Status"
        Else
            Filterquery = ""
        End If

        Dim query = "SELECT LeaveRequest.EmployeeID, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' 
        THEN '' ELSE Employees.MiddleName END) AS EmployeeName, LeaveType.Type, LeaveRequest.DateFiled, LeaveStatus.Status, LeaveRequest.VerdictDate
        FROM LeaveRequest
        LEFT OUTER JOIN Employees
        ON LeaveRequest.EmployeeID = Employees.EmployeeID
        LEFT OUTER JOIN LeaveType
        ON LeaveRequest.LeaveTypeID = LeaveType.ID
        LEFT OUTER JOIN LeaveStatus
        ON LeaveRequest.StatusID = LeaveStatus.ID" & Filterquery & Searchquery
        Dim Status = LRStatusComboBox.SelectedIndex + 1

        Prepare(query)
        AddParam("@Status", Status)
        If LRSearchNameTextBox.Text <> "" Then
            AddParam("@EmpName", "%" & LRSearchNameTextBox.Text & "%")
        End If
        ExecutePrepare()

        LeaveRequestDataGridView.DataSource = DataAsTable
        LeaveRequestDataGridView.CurrentCell = Nothing
        LRViewRequestButton.BackgroundImage = HRM1.My.Resources.Resources.View_disabled
        LRViewRequestButton.Enabled = False
    End Sub

    Private Sub LRStatusComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LRStatusComboBox.SelectedIndexChanged
        LoadLeaveRequestFiltered()
    End Sub

    Public Sub PopulateLeaveTypes()
        Dim query = "SELECT Status FROM LeaveStatus"

        Prepare(query)
        ExecutePrepare()

        LRStatusComboBox.MaxDropDownItems = 5
        LRStatusComboBox.DataSource = DataAsTable
        LRStatusComboBox.DisplayMember = "Status"
        LRStatusComboBox.SelectedIndex = 0
    End Sub

    Public Sub LoadLeaveRequestDetails()
        Dim URCount As Integer
        Dim ApprovedCount As Integer
        Dim RejectedCount As Integer

        Dim query = "SELECT StatusID FROM LeaveRequest"

        Prepare(query)
        ExecutePrepare()

        If Count > 0 Then
            For Each row As DataRow In DataAsTable.Rows
                If row("StatusID") = 1 Then
                    URCount += 1
                End If

                If row("StatusID") = 2 Then
                    ApprovedCount += 1
                End If

                If row("StatusID") = 3 Then
                    RejectedCount += 1
                End If
            Next
        End If

        LRUnderReviewLabel.Text = URCount
        DashURLabel.Text = URCount
        LRApprovedLabel.Text = ApprovedCount
        DashApprovedLabel.Text = ApprovedCount
        LRRejectedLabel.Text = RejectedCount
        DashRejectedLabel.Text = RejectedCount
    End Sub

    Private Sub btnHol1_Click(sender As Object, e As EventArgs) Handles btnHol1.Click
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

    Private Sub HolidayDeleteButton_Click(sender As Object, e As EventArgs) Handles HolidayDeleteButton.Click
        If MsgBox("Are you sure to delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
            Dim query = "DELETE FROM Holidays WHERE HolidayDate = @HolidayDate"

            Prepare(query)
            AddParam("@HolidayDate", DeleteDate)
            ExecutePrepare()

            LoadHoliday(HolidayDateTimePicker.Value.Month)
            MsgBox("Record successfully deleted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "Alert")
            DisableButton()
        End If
    End Sub

    Private Sub HolidayDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles HolidayDataGridView.CellClick
        If My.Computer.Keyboard.ShiftKeyDown Then
            HolidayDataGridView.CurrentCell = Nothing
            HolidayEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit_disabled
            HolidayEditButton.Enabled = False
            HolidayDeleteButton.BackgroundImage = HRM1.My.Resources.Resources.delete_disabled
            HolidayDeleteButton.Enabled = False

        Else
            Try
                HolidayEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit
                HolidayEditButton.Enabled = True
                HolidayDeleteButton.BackgroundImage = HRM1.My.Resources.Resources.delete
                HolidayDeleteButton.Enabled = True

                Dim index As Integer
                index = e.RowIndex

                Dim selectedrow As DataGridViewRow
                selectedrow = HolidayDataGridView.Rows(index)
                DeleteDate = selectedrow.Cells(0).Value
                HolidayEditForm.CurDate = selectedrow.Cells(0).Value
            Catch ex As Exception

            End Try
        End If
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

    Private Sub HolidayEditButton_Click(sender As Object, e As EventArgs) Handles HolidayEditButton.Click
        Me.Enabled = False
        HolidayEditForm.Show(Me)
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

    Private Sub HolidayAddButton_Click(sender As Object, e As EventArgs) Handles HolidayAddButton.Click
        Me.Enabled = False
        HolidayAddForm.Show(Me)
    End Sub

    Private Sub btnPro1_Click(sender As Object, e As EventArgs) Handles btnPro1.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "ProjectsListPanel" Then
                gb.Visible = True
                gb.Enabled = True
                'LoadProjects(ProjectNameSearchTextBox.Text)
                LoadProjectDetails()
                DisableButton()
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
        DashOngoingLabel.Text = PJOngoing
        PJCompletedLabel.Text = PJCompleted
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

    Private Sub PJEditButton_Click(sender As Object, e As EventArgs) Handles PJEditButton.Click
        Me.Enabled = False
        ProjectEditForm.Show(Me)
    End Sub

    Private Sub PJAddButton_Click(sender As Object, e As EventArgs) Handles PJAddButton.Click
        Me.Enabled = False
        ProjectAddForm.Show(Me)
    End Sub

    Private Sub ProjectNameSearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles ProjectNameSearchTextBox.TextChanged
        'LoadProjects(ProjectNameSearchTextBox.Text)
    End Sub

    Private Sub ProjectsDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ProjectsDataGridView.CellClick
        If My.Computer.Keyboard.ShiftKeyDown Then
            ProjectsDataGridView.CurrentCell = Nothing
            PJEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit_disabled
            PJEditButton.Enabled = False
            PJDeleteButton.BackgroundImage = HRM1.My.Resources.Resources.delete_disabled
            PJDeleteButton.Enabled = False

        Else
            Try
                PJEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit
                PJEditButton.Enabled = True
                PJDeleteButton.BackgroundImage = HRM1.My.Resources.Resources.delete
                PJDeleteButton.Enabled = True

                Dim index As Integer
                index = e.RowIndex

                Dim selectedrow As DataGridViewRow
                selectedrow = ProjectsDataGridView.Rows(index)
                DeleteProjectID = selectedrow.Cells(0).Value
                ProjectEditForm.ProjectID = selectedrow.Cells(0).Value
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub PJRefreshButton_Click(sender As Object, e As EventArgs) Handles PJRefreshButton.Click
        'LoadProjects(ProjectNameSearchTextBox.Text)
        LoadProjectDetails()
        DisableButton()
    End Sub

    Private Sub PJDeleteButton_Click(sender As Object, e As EventArgs) Handles PJDeleteButton.Click
        If MsgBox("Are you sure to delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
            Dim query = "DELETE FROM Projects WHERE ID = @ID"

            Prepare(query)
            AddParam("@ID", DeleteProjectID)
            ExecutePrepare()

            'LoadProjects(ProjectNameSearchTextBox.Text)
            DisableButton()
            MsgBox("Record successfully deleted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "Alert")
        End If
    End Sub

    Private Sub ProjectsAllCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ProjectsAllCheckBox.CheckedChanged
        If ProjectsAllCheckBox.CheckState = CheckState.Checked Then
            ProjectsFilterComboBox.Enabled = False
            LoadProjects(ProjectNameSearchTextBox.Text, Nothing)
        Else
            ProjectsFilterComboBox.Enabled = True
            LoadProjects(ProjectNameSearchTextBox.Text, ProjectsFilterComboBox.SelectedIndex + 1)
        End If
    End Sub

    Public Sub LoadProjects(PJName As String, Dept As String)
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

    Private Sub btnPay1_Click(sender As Object, e As EventArgs) Handles btnPay1.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "EmployeeSalaryPanel" Then
                gb.Visible = True
                gb.Enabled = True
                ESPayrollTypeComboBox.SelectedIndex = 0
                ESCutOffComboBox.SelectedIndex = 0
                ESYearDateTimePicker.Value = Date.Today.Month & "/01/" & Date.Today.Year
                ESMonthDateTimePicker.Value = Date.Today.Month & "/01/" & Date.Today.Year
                GetSSS()
                GetPagIbig()
                GetTax()
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub ESGenerateButton_Click(sender As Object, e As EventArgs) Handles ESGenerateButton.Click
        If ESSalaryDataGridView.Rows.Count > 0 Then
            ESSalaryDataGridView.Rows.Clear()
        End If

        PopulateHolidays(ESMonthDateTimePicker.Value.Month)
        GetAllAttendanceRecords()
        ESSaveButton.Enabled = True
    End Sub

    Public Sub CheckForNoTimeInAndOut(Month As Integer, Year As Integer, Day As Integer)
        Dim query = "SELECT * FROM AttendanceRecords WHERE (TimeIn IS NULL OR TimeOut IS NULL) AND MONTH(Attdate) = @Month AND YEAR(Attdate) = @Year AND DAY(AttDate) <= @Day"

        Prepare(query)
        AddParam("@Month", Month)
        AddParam("@Year", Year)
        AddParam("@Day", Day)
        ExecutePrepare()

        For Each row As DataRow In DataAsTable.Rows
            SetHalfDay(row("EmployeeID"), row("ID"), Month, Year)
        Next
    End Sub

    Public Sub SetHalfDay(EmpID As String, ID As Integer, Month As Integer, Year As Integer)
        Dim query = "UPDATE AttendanceRecords SET HalfDay = 1 WHERE ID = @ID AND EmployeeID = @EmpID AND MONTH(Attdate) = @Month AND YEAR(Attdate) = @Year"

        Prepare(query)
        AddParam("@ID", ID)
        AddParam("@EmpID", EmpID)
        AddParam("@Month", Month)
        AddParam("@Year", Year)
        ExecutePrepare()
    End Sub

    Public Sub GetAllAttendanceRecords()
        Dim PayrollType As String
        Dim CutOff As String
        Dim FixedRate As Double

        Dim StartDate As Date
        Dim EndDate As Date
        Dim WorkDays As Integer
        Dim DaysInAMonth As Integer = Date.DaysInMonth(ESYearDateTimePicker.Value.Year, ESMonthDateTimePicker.Value.Month)

        If ESPayrollTypeComboBox.SelectedIndex = 0 Then
            FixedRate = 2
            If ESCutOffComboBox.SelectedIndex = 0 Then
                PayrollType = ESPayrollTypeComboBox.Text
                CutOff = ESCutOffComboBox.Text

                StartDate = ESMonthDateTimePicker.Value.Month & "/01/" & ESYearDateTimePicker.Value.Year
                EndDate = ESMonthDateTimePicker.Value.Month & "/15/" & ESYearDateTimePicker.Value.Year

                For i = StartDate.Date.Day To EndDate.Date.Day
                    Dim Day As String = ESMonthDateTimePicker.Value.Month & "/" & i & "/" & ESYearDateTimePicker.Value.Year
                    Dim CheckDay As Date

                    Date.TryParse(Day, CheckDay)

                    If CheckDay.DayOfWeek <> DayOfWeek.Sunday Then
                        WorkDays += 1
                    End If
                Next
            Else
                PayrollType = ESPayrollTypeComboBox.Text
                CutOff = ESCutOffComboBox.Text

                StartDate = ESMonthDateTimePicker.Value.Month & "/16/" & ESYearDateTimePicker.Value.Year
                EndDate = ESMonthDateTimePicker.Value.Month & "/" & DaysInAMonth & "/" & ESYearDateTimePicker.Value.Year

                For i = StartDate.Date.Day To EndDate.Date.Day
                    Dim Day As String = ESMonthDateTimePicker.Value.Month & "/" & i & "/" & ESYearDateTimePicker.Value.Year
                    Dim CheckDay As Date

                    Date.TryParse(Day, CheckDay)

                    If CheckDay.DayOfWeek <> DayOfWeek.Sunday Then
                        WorkDays += 1
                    End If
                Next
            End If
        Else
            FixedRate = 1
            StartDate = ESMonthDateTimePicker.Value.Month & "/01/" & ESYearDateTimePicker.Value.Year
            EndDate = ESMonthDateTimePicker.Value.Month & "/" & DaysInAMonth & "/" & ESYearDateTimePicker.Value.Year

            PayrollType = ESPayrollTypeComboBox.Text
            CutOff = StartDate.Day & "-" & EndDate.Day

            For i = StartDate.Date.Day To EndDate.Date.Day
                Dim Day As String = ESMonthDateTimePicker.Value.Month & "/" & i & "/" & ESYearDateTimePicker.Value.Year
                Dim CheckDay As Date

                Date.TryParse(Day, CheckDay)

                If CheckDay.DayOfWeek <> DayOfWeek.Sunday Then
                    WorkDays += 1
                End If
            Next
        End If

        CheckForNoTimeInAndOut(ESMonthDateTimePicker.Value.Month, ESYearDateTimePicker.Value.Year, EndDate.Day)

        Dim query = "SELECT EmployeeSalaryInformation.EmployeeID, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName 
        FROM EmployeeSalaryInformation
        LEFT OUTER JOIN Employees
        ON EmployeeSalaryInformation.EmployeeID = Employees.EmployeeID"

        Prepare(query)
        ExecutePrepare()

        For Each row As DataRow In DataAsTable.Rows
            CalculateWorkHours(row("EmployeeID"), row("EmployeeName"), PayrollType, CutOff, FixedRate, StartDate, EndDate, ESMonthDateTimePicker.Value.Month, ESYearDateTimePicker.Value.Year, WorkDays)
        Next
    End Sub

    Public Sub CalculateWorkHours(EmployeeID As String, EmpName As String, PayrollType As String, CutOff As String, FixedRate As Double, StartDate As Date, EndDate As Date, Month As Integer, Year As Integer, WorkDays As Integer)
        Dim WorkHours As Double = GetWorkHours(EmployeeID)
        Dim TotalHours As Double
        Dim OT As Double
        Dim OTRate As Double
        Dim Late As Double
        Dim UnderTime As Double
        Dim HalfDay As Double
        Dim TotalWorkDays As Double
        Dim Rate As Double = GetRate(EmployeeID)
        Dim BasicPay, NetPay, OTPay, HolidayPay, GrossPay, TaxableIncome As Double
        Dim SalaryType As Integer
        Dim HolidayRate, HolidayInstance, HolidayHours As Double
        Dim IsHoliday As Boolean
        Dim TotalDeductions As Double
        Dim TardinessAmount, SSS, PhilHealth, PagIbig, Tax As Double

        Dim query = "SELECT AttendanceRecords.ID, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName, 
        AttendanceRecords.AttDate, AttendanceRecords.TimeIn, AttendanceRecords.TimeOut, AttendanceRecords.TotalHours,
        AttendanceRecords.OT, AttendanceRecords.Late, AttendanceRecords.Undertime, AttendanceRecords.HalfDay, EmployeeSalaryInformation.SalaryTypeID 
        FROM AttendanceRecords 
        LEFT OUTER JOIN EmployeeSalaryInformation
        ON AttendanceRecords.EmployeeID = EmployeeSalaryInformation.EmployeeID
        LEFT OUTER JOIN Employees
        ON AttendanceRecords.EmployeeID = Employees.EmployeeID
        WHERE MONTH(AttendanceRecords.AttDate) = @Month AND YEAR(AttendanceRecords.AttDate) = @Year AND AttendanceRecords.EmployeeID = @EmpID AND (DAY(AttendanceRecords.AttDate) >= @DayFrom and DAY(AttendanceRecords.AttDate) <= @DayTo)"

        Prepare(query)
        AddParam("@Month", Month)
        AddParam("@Year", Year)
        AddParam("@DayFrom", StartDate.Day)
        AddParam("@DayTo", EndDate.Day)
        AddParam("@EmpID", EmployeeID)
        ExecutePrepare()

        For Each row As DataRow In DataAsTable.Rows
            If HolidaysDates.Contains(Convert.ToDateTime(row("AttDate")).ToString("MM/dd")) Then
                Dim index As Integer = HolidaysDates.IndexOf(Convert.ToDateTime(row("AttDate")).ToString("MM/dd"))

                HolidayInstance += 1
                IsHoliday = True
                HolidayRate = HolidaysPercent.Item(index)
            Else
                HolidayRate = 1
                IsHoliday = False
            End If

            If Not IsDBNull(row("HalfDay")) Then
                TotalWorkDays += 0.5
                HalfDay += WorkHours / 2
            Else
                TotalWorkDays += 1
            End If

            If row("SalaryTypeID") = 1 Then
                SalaryType = 1

                If Not IsDBNull(row("HalfDay")) Then
                    TotalHours += WorkHours / 2

                    If IsHoliday Then
                        HolidayPay += (WorkHours / 2 * (Rate * HolidayRate)) - (Rate * (WorkHours / 2))
                        HolidayHours = WorkHours / 2 * (Rate * HolidayRate)
                    End If
                Else
                    If Not IsDBNull(row("TotalHours")) Then
                        If row("TotalHours") > WorkHours Then
                            TotalHours += WorkHours

                            If Not IsDBNull(row("Late")) Then
                                Late += row("Late")
                                TotalHours -= Late
                            End If

                            If Not IsDBNull(row("Undertime")) Then
                                UnderTime += row("Undertime")
                                TotalHours -= UnderTime
                            End If
                        Else
                            TotalHours += row("TotalHours")

                            If Not IsDBNull(row("Late")) Then
                                Late += row("Late")
                            End If

                            If Not IsDBNull(row("Undertime")) Then
                                UnderTime += row("Undertime")
                            End If
                        End If

                        If IsHoliday Then
                            HolidayPay += (WorkHours * (Rate * HolidayRate)) - (Rate * WorkHours)
                            HolidayHours = WorkHours * (Rate * HolidayRate)
                        End If
                    End If
                End If
            End If

            If row("SalaryTypeID") = 2 Then
                SalaryType = 2

                If Not IsDBNull(row("HalfDay")) Then
                    TotalHours += WorkHours / 2

                    If IsHoliday Then
                        HolidayPay += (WorkHours * HolidayRate) * (Rate / WorkHours)
                    End If
                Else
                    If Not IsDBNull(row("TotalHours")) Then
                        If row("TotalHours") > WorkHours Then
                            TotalHours += WorkHours

                            If Not IsDBNull(row("Late")) Then
                                Late += row("Late")
                                TotalHours -= Late
                            End If

                            If Not IsDBNull(row("Undertime")) Then
                                UnderTime += row("Undertime")
                                TotalHours -= UnderTime
                            End If
                        Else
                            TotalHours += row("TotalHours")

                            If Not IsDBNull(row("Late")) Then
                                Late += row("Late")
                            End If

                            If Not IsDBNull(row("Undertime")) Then
                                UnderTime += row("Undertime")
                            End If
                        End If

                        If Not IsDBNull(row("OT")) Then
                            Dim OTHour = row("OT").ToString.Split(New Char() {"."c})
                            Dim CurOt As Double

                            If OTHour(0) > 0 Then
                                CurOt = OTHour(0)
                                If OTHour(1) >= 50 Then
                                    CurOt += "." & OTHour(1)
                                End If
                            Else
                                If OTHour(1) >= 50 Then
                                    CurOt += "." & OTHour(1)
                                End If
                            End If

                            If IsHoliday Then
                                OTRate = 1.3
                            Else
                                OTRate = 1.25
                            End If

                            OT += CurOt
                            OTPay = Rate / WorkHours * HolidayRate * OTRate * OT
                        End If

                        If IsHoliday Then
                            HolidayPay += WorkHours * HolidayRate * (Rate / WorkHours)
                        End If
                    End If
                End If
            End If

            If row("SalaryTypeID") = 3 Then
                SalaryType = 3

                If Not IsDBNull(row("HalfDay")) Then
                    TotalHours += WorkHours / 2

                    If IsHoliday Then
                        HolidayPay += WorkHours * HolidayRate * (Rate / 2 / WorkDays / WorkHours * HolidayRate) / 2
                    End If
                Else
                    If Not IsDBNull(row("TotalHours")) Then
                        If row("TotalHours") > WorkHours Then
                            TotalHours += WorkHours

                            If Not IsDBNull(row("Late")) Then
                                Late += row("Late")
                                TotalHours -= Late
                            End If

                            If Not IsDBNull(row("Undertime")) Then
                                UnderTime += row("Undertime")
                                TotalHours -= UnderTime
                            End If
                        Else
                            TotalHours += row("TotalHours")

                            If Not IsDBNull(row("Late")) Then
                                Late += row("Late")
                            End If

                            If Not IsDBNull(row("Undertime")) Then
                                UnderTime += row("Undertime")
                            End If
                        End If

                        If Not IsDBNull(row("OT")) Then
                            Dim OTHour = row("OT").ToString.Split(New Char() {"."c})
                            Dim CurOt As Double

                            If OTHour(0) > 0 Then
                                CurOt = OTHour(0)
                                If OTHour(1) >= 50 Then
                                    CurOt += "." & OTHour(1)
                                End If
                            Else
                                If OTHour(1) >= 50 Then
                                    CurOt += "." & OTHour(1)
                                End If
                            End If

                            If IsHoliday Then
                                OTRate = 1.3
                            Else
                                OTRate = 1.25
                            End If

                            OT = CurOt
                            OTPay += Rate / FixedRate / WorkDays / WorkHours * HolidayRate * OTRate * OT
                        End If

                        If IsHoliday Then
                            HolidayPay += (Rate / 2 / WorkDays * HolidayRate) - (Rate / 2 / WorkDays)
                        End If
                    End If
                End If
            End If
        Next
        If SalaryType = 1 Then
            BasicPay = WorkHours * WorkDays * Rate
            GrossPay = BasicPay + HolidayPay

            TardinessAmount = (HalfDay + Late + UnderTime) * Rate
            SSS = GetSSSDeduction(GrossPay, FixedRate)
            PhilHealth = GetPhilHealthDeduction(GrossPay, FixedRate)
            PagIbig = GetPagIbigDeduction(GrossPay, FixedRate)
            TaxableIncome = GrossPay - (TardinessAmount + SSS + PhilHealth + PagIbig)
            Tax = GetTaxDeduction(TaxableIncome, FixedRate)
            TotalDeductions = TardinessAmount + SSS + PhilHealth + PagIbig + Tax

            NetPay = TaxableIncome - Tax

            ESSalaryDataGridView.Rows.Add(EmployeeID, EmpName, PayrollType, CutOff, WorkDays, TotalWorkDays, TotalHours, BasicPay.ToString("##,###.00"), HalfDay + Late + UnderTime, OT.ToString("##,###.00"), OTPay.ToString("##,###.00"), HolidayInstance, HolidayPay.ToString("##,###.00"), GrossPay.ToString("##,###.00"), TardinessAmount.ToString("##,##0.00"), SSS.ToString("##,###.00"), PhilHealth.ToString("##,###.00"), PagIbig.ToString("##,###.00"), TaxableIncome.ToString("##,###.00"), Tax.ToString("##,##0.00"), TotalDeductions.ToString("##,###.00"), NetPay.ToString("##,###.00"))
        ElseIf SalaryType = 2 Then
            BasicPay = WorkDays * Rate
            GrossPay = BasicPay + OTPay + HolidayPay
            'NetPay = (TotalHours - Late + UnderTime) * (Rate / WorkHours) + OTPay + HolidayPay

            TardinessAmount = (HalfDay + Late + UnderTime) * (Rate / WorkHours)
            SSS = GetSSSDeduction(GrossPay, FixedRate)
            PhilHealth = GetPhilHealthDeduction(GrossPay, FixedRate)
            PagIbig = GetPagIbigDeduction(GrossPay, FixedRate)
            TaxableIncome = GrossPay - (TardinessAmount + SSS + PhilHealth + PagIbig)
            Tax = GetTaxDeduction(TaxableIncome, FixedRate)
            TotalDeductions = TardinessAmount + SSS + PhilHealth + PagIbig + Tax

            NetPay = TaxableIncome - Tax

            ESSalaryDataGridView.Rows.Add(EmployeeID, EmpName, PayrollType, CutOff, WorkDays, TotalWorkDays, TotalHours, BasicPay.ToString("##,###.00"), HalfDay + Late + UnderTime, OT.ToString("##,###.00"), OTPay.ToString("##,###.00"), HolidayInstance, HolidayPay.ToString("##,###.00"), GrossPay.ToString("##,###.00"), TardinessAmount.ToString("##,##0.00"), SSS.ToString("##,###.00"), PhilHealth.ToString("##,###.00"), PagIbig.ToString("##,###.00"), TaxableIncome.ToString("##,###.00"), Tax.ToString("##,##0.00"), TotalDeductions.ToString("##,###.00"), NetPay.ToString("##,###.00"))
        Else
            BasicPay = Rate / FixedRate
            GrossPay = BasicPay + OTPay + HolidayPay
            'NetPay = Rate / FixedRate / WorkDays / WorkHours * TotalHours + OTPay + HolidayPay

            TardinessAmount = (HalfDay + Late + UnderTime) * Rate / FixedRate
            SSS = GetSSSDeduction(GrossPay, FixedRate)
            PhilHealth = GetPhilHealthDeduction(GrossPay, FixedRate)
            PagIbig = GetPagIbigDeduction(GrossPay, FixedRate)
            TaxableIncome = GrossPay - (TardinessAmount + SSS + PhilHealth + PagIbig)
            Tax = GetTaxDeduction(TaxableIncome, FixedRate)
            TotalDeductions = TardinessAmount + SSS + PhilHealth + PagIbig + Tax

            NetPay = TaxableIncome - Tax

            ESSalaryDataGridView.Rows.Add(EmployeeID, EmpName, PayrollType, CutOff, WorkDays, TotalWorkDays, TotalHours, BasicPay.ToString("##,###.00"), HalfDay + Late + UnderTime, OT.ToString("##,###.00"), OTPay.ToString("##,###.00"), HolidayInstance, HolidayPay.ToString("##,###.00"), GrossPay.ToString("##,###.00"), TardinessAmount.ToString("##,##0.00"), SSS.ToString("##,###.00"), PhilHealth.ToString("##,###.00"), PagIbig.ToString("##,###.00"), TaxableIncome.ToString("##,###.00"), Tax.ToString("##,##0.00"), TotalDeductions.ToString("##,###.00"), NetPay.ToString("##,###.00"))
        End If
    End Sub


    Public HolidaysDates As New List(Of Date)
    Public HolidaysPercent As New List(Of Double)

    Public SSSRangeFrom As New List(Of Double)
    Public SSSRangeTo As New List(Of Double)
    Public SSSDeductions As New List(Of Double)

    Public PagIbigRangeFrom As New List(Of Double)
    Public PagIbigRangeTo As New List(Of Double)
    Public PagIbigDeductions As New List(Of Double)

    Public TaxRangeFrom As New List(Of Double)
    Public TaxRangeTo As New List(Of Double)
    Public TaxDeductionValue As New List(Of Double)
    Public TaxDeductionPercentage As New List(Of Double)
    Public TaxDeductionOver As New List(Of Double)

    Public Function GetTaxDeduction(TaxableIncome As Double, FixedRate As Double) As Double
        For i = 0 To TaxDeductionValue.Count - 1
            If TaxableIncome >= TaxRangeFrom.Item(i) And TaxableIncome <= TaxRangeTo.Item(i) Then
                Return ((TaxableIncome - TaxDeductionOver.Item(i)) * TaxDeductionPercentage(i)) + TaxDeductionValue(i)
            End If
        Next

        Return Nothing
    End Function

    Public Function GetPagIbigDeduction(GrossPay As Double, FixedRate As Double) As Double
        For i = 0 To PagIbigDeductions.Count - 1
            If GrossPay * FixedRate >= PagIbigRangeFrom.Item(i) And GrossPay * FixedRate <= PagIbigRangeTo.Item(i) Then
                Return GrossPay * PagIbigDeductions.Item(i) / FixedRate
            Else
                Return PagIbigDeductions.Last / FixedRate
            End If
        Next

        Return Nothing
    End Function

    Public Function GetPhilHealthDeduction(GrossPay As Double, FixedRate As Double) As Double
        Dim PH As Double = GetPhilHealth()

        Return GrossPay * PH / FixedRate
    End Function

    Public Function GetSSSDeduction(GrossPay As Double, FixedRate As Double) As Double
        If GrossPay * FixedRate >= SSSRangeFrom.Item(0) And GrossPay * FixedRate <= SSSRangeTo.Item(0) Then
            Return SSSDeductions.Item(0) / FixedRate
        ElseIf GrossPay * FixedRate >= SSSRangeFrom.Last Then
            Return SSSDeductions.Last / FixedRate
        Else
            For i = 1 To SSSDeductions.Count - 1
                If GrossPay * FixedRate >= SSSRangeFrom.Item(i) And GrossPay * FixedRate <= SSSRangeTo.Item(i) Then
                    Return SSSDeductions.Item(i) / FixedRate
                End If
            Next
        End If
        Return Nothing
    End Function

    Public Sub GetTax()
        TaxRangeFrom.Clear()
        TaxRangeTo.Clear()
        TaxDeductionValue.Clear()
        TaxDeductionPercentage.Clear()
        TaxDeductionOver.Clear()

        Dim query = "SELECT * FROM WithholdingTaxDeductions"

        Prepare(query)
        ExecutePrepare()

        For Each row As DataRow In DataAsTable.Rows
            TaxRangeFrom.Add(row("RangeFrom"))
            TaxRangeTo.Add(row("RangeTo"))
            TaxDeductionValue.Add(row("DeductionValue"))
            TaxDeductionPercentage.Add(row("DeductionPercentage"))
            TaxDeductionOver.Add(row("DeductionOver"))
        Next
    End Sub

    Public Sub GetPagIbig()
        PagIbigRangeFrom.Clear()
        PagIbigRangeTo.Clear()
        PagIbigDeductions.Clear()

        Dim query = "SELECT * FROM PagIbigDeductions"

        Prepare(query)
        ExecutePrepare()

        For Each row As DataRow In DataAsTable.Rows
            PagIbigRangeFrom.Add(row("RangeFrom"))
            PagIbigRangeTo.Add(row("RangeTo"))
            PagIbigDeductions.Add(row("Deduction"))
        Next
    End Sub

    Public Function GetPhilHealth() As Double
        Dim query = "SELECT * FROM PhilHealthDeductions"

        Prepare(query)
        ExecutePrepare()

        Dim row As DataRow = DataAsTable.Rows(0)

        Return row("Deduction")
    End Function

    Public Sub GetSSS()
        SSSRangeFrom.Clear()
        SSSRangeTo.Clear()
        SSSDeductions.Clear()

        Dim query = "SELECT * FROM SSSDeductions"

        Prepare(query)
        ExecutePrepare()

        For Each row As DataRow In DataAsTable.Rows
            SSSRangeFrom.Add(row("RangeFrom"))
            SSSRangeTo.Add(row("RangeTo"))
            SSSDeductions.Add(row("Deduction"))
        Next
    End Sub

    Public Sub PopulateHolidays(Month As Integer)
        HolidaysDates.Clear()
        HolidaysPercent.Clear()
        Dim query = "SELECT * FROM Holidays WHERE MONTH(HolidayDate) = @Month"

        Prepare(query)
        AddParam("@Month", Month)
        ExecutePrepare()

        For Each row As DataRow In DataAsTable.Rows
            HolidaysDates.Add(Convert.ToDateTime(row("HolidayDate")).ToString("MM/dd"))

            If row("Type") = "Regular" Then
                HolidaysPercent.Add(2)
            Else
                HolidaysPercent.Add(1.3)
            End If
        Next
    End Sub

    Public Function GetRate(EmpID As String)
        Dim query = "SELECT Rate FROM EmployeeSalaryInformation WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            Return row("Rate")
        End If

        Return Nothing
    End Function

    Public Function GetWorkHours(EmpID As String)
        Dim query = "SELECT Total FROM EmployeeSalaryInformation WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpID)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            Return row("Total")
        End If

        Return Nothing
    End Function

    Private Sub ESPayrollTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ESPayrollTypeComboBox.SelectedIndexChanged
        If ESPayrollTypeComboBox.Text = "Monthly" Then
            ESCutOffComboBox.Enabled = False
        Else
            ESCutOffComboBox.Enabled = True
            ESCutOffComboBox.SelectedIndex = 0
        End If
        ESSaveButton.Enabled = False
    End Sub

    Private Sub EmployeeListAddButton_Click(sender As Object, e As EventArgs) Handles EmployeeListAddButton.Click
        Me.Enabled = False
        EmployeeListAddForm.Show(Me)
    End Sub

    Public Sub RefreshDetails()
        Dim TotalEmp As Integer
        Dim WorkingEmp As Integer
        Dim NonWorkingEmp As Integer

        Dim query = "SELECT StatusID FROM Employees"

        Prepare(query)
        ExecutePrepare()

        If Count > 0 Then
            For Each row As DataRow In DataAsTable.Rows
                If row("StatusID") > 0 Then
                    TotalEmp += 1
                End If

                If row("StatusID") = 1 Then
                    WorkingEmp += 1
                End If

                If row("StatusID") = 2 Then
                    NonWorkingEmp += 1
                End If
            Next
        End If

        ELTotalLabel.Text = TotalEmp
        ELWorkingLabel.Text = WorkingEmp
        ELNWorkingLabel.Text = NonWorkingEmp

        Try
            RefreshTable()
            Me.EmployeesDataGridView.Sort(Me.EmployeesDataGridView.Columns(3), ListSortDirection.Descending)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub DisableButton()
        EmployeesDataGridView.CurrentCell = Nothing
        EmployeeListEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit_disabled
        EmployeeListEditButton.Enabled = False

        LeaveRequestDataGridView.CurrentCell = Nothing
        LRViewRequestButton.BackgroundImage = HRM1.My.Resources.Resources.View_disabled
        LRViewRequestButton.Enabled = False

        HolidayDataGridView.CurrentCell = Nothing
        HolidayEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit_disabled
        HolidayEditButton.Enabled = False
        HolidayDeleteButton.BackgroundImage = HRM1.My.Resources.Resources.delete_disabled
        HolidayDeleteButton.Enabled = False

        ProjectsDataGridView.CurrentCell = Nothing
        PJEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit_disabled
        PJEditButton.Enabled = False
        PJDeleteButton.BackgroundImage = HRM1.My.Resources.Resources.delete_disabled
        PJDeleteButton.Enabled = False
    End Sub

    Private Sub EmployeesDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles EmployeesDataGridView.CellClick
        If My.Computer.Keyboard.ShiftKeyDown Then
            EmployeesDataGridView.CurrentCell = Nothing
            EmployeeListEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit_disabled
            EmployeeListEditButton.Enabled = False

        Else
            Try
                EmployeeListEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit
                EmployeeListEditButton.Enabled = True

                Dim index As Integer
                index = e.RowIndex

                Dim selectedrow As DataGridViewRow
                selectedrow = EmployeesDataGridView.Rows(index)
                EmployeeListEditForm.EmpIdEdit = selectedrow.Cells(1).Value
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub EmployeeListEditButton_Click(sender As Object, e As EventArgs) Handles EmployeeListEditButton.Click
        Me.Enabled = False
        EmployeeListEditForm.Show(Me)
    End Sub

    Private Sub EmployeeListUpdateButton_Click(sender As Object, e As EventArgs) Handles EmployeeListUpdateButton.Click
        RefreshDetails()
        DisableButton()
    End Sub

    Private Sub EmployeeNameSearchBoxTextBox_TextChanged(sender As Object, e As EventArgs) Handles EmployeeNameSearchBoxTextBox.TextChanged
        Dim Name As String = EmployeeNameSearchBoxTextBox.Text

        Dim query = "SELECT Employees.ID, Employees.EmployeeID, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName, 
        Status.Status as 'StatusID', Department.Department AS 'DepartmentID', Employees.DateHired, Employees.Age, Employees.Address, Employees.SSSNo, Employees.PhilHealthNo, 
        Employees.PagibigNo, Employees.TIN, Employees.ContactNumber, Employees.EmailAddress FROM Employees 
        INNER JOIN Department 
        ON Employees.DepartmentID = Department.ID 
        INNER JOIN Status 
        ON Employees.StatusID = Status.ID
        WHERE FirstName LIKE @Name OR LastName LIKE @Name OR MiddleName LIKE @Name;"

        Prepare(query)
        AddParam("@Name", "%" + Name + "%")
        ExecutePrepare()

        EmployeesDataGridView.DataSource = DataAsTable.DefaultView
    End Sub

    Private Sub EmployeeNameSearchBoxTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmployeeNameSearchBoxTextBox.KeyPress
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
    Public Sub RefreshTable()
        Dim query = "SELECT Employees.ID, Employees.EmployeeID, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName, 
        Status.Status as 'StatusID', Department.Department AS 'DepartmentID', Employees.DateHired, Employees.Age, Employees.Address, Employees.ContactNumber, Employees.EmailAddress, Employees.SSSNo, Employees.PhilHealthNo, Employees.PagibigNo, 
        Employees.TIN, Employees.Photo FROM Employees 
        INNER JOIN Department 
        ON Employees.DepartmentID = Department.ID 
        INNER JOIN Status  
        ON Employees.StatusID = Status.ID"

        Prepare(query)
        ExecutePrepare()

        EmployeesDataGridView.DataSource = DataAsTable.DefaultView
        Me.EmployeesDataGridView.Sort(Me.EmployeesDataGridView.Columns(3), ListSortDirection.Descending)
    End Sub

    Private Sub AttendanceTodayRefreshButton_Click(sender As Object, e As EventArgs) Handles AttendanceTodayRefreshButton.Click
        AttendanceSearchTextBox.Text = ""
        LoadAttendanceToday()
        LoadAttendanceDetails()
        AttendanceTodayDataGridView.CurrentCell = Nothing
    End Sub

    Private Sub DashBoardForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Are you sure to log-out/exit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.Yes Then
            e.Cancel = False
            Login.Show()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub DateTimeTimer_Tick(sender As Object, e As EventArgs) Handles DateTimeTimer.Tick
        Dim CurDateTime As Date = Date.Now
        TimeLabel.Text = CurDateTime.ToString("hh:mm:ss tt")
        DateLabel.Text = CurDateTime.ToLongDateString
    End Sub

    Private Sub ESClearButton_Click(sender As Object, e As EventArgs) Handles ESClearButton.Click
        ESSalaryDataGridView.Rows.Clear()
        ESSaveButton.Enabled = False
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Me.Close()
    End Sub

    Public Function CheckIfGenerated() As Boolean
        Dim query = "SELECT * FROM EmployeeSalary WHERE (MONTH(DateFrom) = @MonthFrom AND DAY(DateFrom) = @DayFrom  AND YEAR(DateFrom) = @YearFrom) AND (MONTH(DateTo) = @MonthTo AND DAY(DateTo) = @DayTo  AND YEAR(DateTo) = @YearTo)"
        Dim DayFrom, DayTo As Integer

        If ESPayrollTypeComboBox.SelectedIndex = 0 Then
            If ESCutOffComboBox.SelectedIndex = 0 Then
                DayFrom = "1"
                DayTo = "15"
            Else
                DayFrom = "16"
                DayTo = Date.DaysInMonth(ESYearDateTimePicker.Value.Year, ESMonthDateTimePicker.Value.Month)
            End If
        Else
            DayFrom = "1"
            DayTo = Date.DaysInMonth(ESYearDateTimePicker.Value.Year, ESMonthDateTimePicker.Value.Month)
        End If

        Prepare(query)
        AddParam("@MonthFrom", ESMonthDateTimePicker.Value.Month)
        AddParam("@DayFrom", DayFrom)
        AddParam("@YearFrom", ESYearDateTimePicker.Value.Year)
        AddParam("@MonthTo", ESMonthDateTimePicker.Value.Month)
        AddParam("@DayTo", DayTo)
        AddParam("@YearTo", ESYearDateTimePicker.Value.Year)
        ExecutePrepare()

        If Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub ESSaveButton_Click(sender As Object, e As EventArgs) Handles ESSaveButton.Click
        If Not CheckIfGenerated() Then
            Try
                ResetValues()

                Dim DayFrom As String
                Dim DayTo As String

                If ESPayrollTypeComboBox.SelectedIndex = 0 Then
                    If ESCutOffComboBox.SelectedIndex = 0 Then
                        DayFrom = "1"
                        DayTo = "15"
                    Else
                        DayFrom = "16"
                        DayTo = Date.DaysInMonth(ESYearDateTimePicker.Value.Year, ESMonthDateTimePicker.Value.Month)
                    End If
                Else
                    DayFrom = "1"
                    DayTo = Date.DaysInMonth(ESYearDateTimePicker.Value.Year, ESMonthDateTimePicker.Value.Month)
                End If

                Dim DateFrom As Date
                Date.TryParse(ESYearDateTimePicker.Value.Year & "-" & ESMonthDateTimePicker.Value.Month & "-" & DayFrom & "  00:00:00", DateFrom)
                Dim DateTo As Date
                Date.TryParse(ESYearDateTimePicker.Value.Year & "-" & ESMonthDateTimePicker.Value.Month & "-" & DayTo & "  00:00:00", DateTo)

                Connection.Open()

                Dim query = "INSERT INTO EmployeeSalary (EmployeeID, DateFrom, DateTo, PayrollType, CutOff, WorkDays, TotalWorkDays, TotalHours, BasicPay, Tardiness, OTHours, OTPay, 
                Holiday, HolidayPay, GrossPay, Deduction_Tardiness, SSS, PHIC, HDMF, TaxableIncome, Tax, TotalDeductions, NetPay)
                VALUES (@EmployeeID, @DateFrom, @DateTo, @PayrollType, @CutOff, @WorkDays, @TotalWorkDays, @TotalHours, @BasicPay, @Tardiness, @OTHours, @OTPay, 
                @Holiday, @HolidayPay, @GrossPay, @Deduction_Tardiness, @SSS, @PHIC, @HDMF, @TaxableIncome, @Tax, @TotalDeductions, @NetPay)"

                Command = New SqlCommand(query, Connection)

                Command.Parameters.Add("@EmployeeID", SqlDbType.BigInt)
                Command.Parameters.Add("@DateFrom", SqlDbType.Date)
                Command.Parameters.Add("@DateTo", SqlDbType.Date)
                Command.Parameters.Add("@PayrollType", SqlDbType.VarChar)
                Command.Parameters.Add("@CutOff", SqlDbType.VarChar)
                Command.Parameters.Add("@WorkDays", SqlDbType.Float)
                Command.Parameters.Add("@TotalWorkDays", SqlDbType.Float)
                Command.Parameters.Add("@TotalHours", SqlDbType.Float)
                Command.Parameters.Add("@BasicPay", SqlDbType.Float)
                Command.Parameters.Add("@Tardiness", SqlDbType.Float)
                Command.Parameters.Add("@OTHours", SqlDbType.Float)
                Command.Parameters.Add("@OTPay", SqlDbType.Float)
                Command.Parameters.Add("@Holiday", SqlDbType.Float)
                Command.Parameters.Add("@HolidayPay", SqlDbType.Float)
                Command.Parameters.Add("@GrossPay", SqlDbType.Float)
                Command.Parameters.Add("@Deduction_Tardiness", SqlDbType.Float)
                Command.Parameters.Add("@SSS", SqlDbType.Float)
                Command.Parameters.Add("@PHIC", SqlDbType.Float)
                Command.Parameters.Add("@HDMF", SqlDbType.Float)
                Command.Parameters.Add("@TaxableIncome", SqlDbType.Float)
                Command.Parameters.Add("@Tax", SqlDbType.Float)
                Command.Parameters.Add("@TotalDeductions", SqlDbType.Float)
                Command.Parameters.Add("@NetPay", SqlDbType.Float)

                For i = 0 To ESSalaryDataGridView.Rows.Count - 1
                    Command.Parameters(0).Value = ESSalaryDataGridView.Rows(i).Cells(0).Value
                    Command.Parameters(1).Value = DateFrom
                    Command.Parameters(2).Value = DateTo
                    Command.Parameters(3).Value = ESSalaryDataGridView.Rows(i).Cells(2).Value
                    Command.Parameters(4).Value = ESSalaryDataGridView.Rows(i).Cells(3).Value
                    Command.Parameters(5).Value = ESSalaryDataGridView.Rows(i).Cells(4).Value
                    Command.Parameters(6).Value = ESSalaryDataGridView.Rows(i).Cells(5).Value
                    Command.Parameters(7).Value = ESSalaryDataGridView.Rows(i).Cells(6).Value
                    Command.Parameters(8).Value = ESSalaryDataGridView.Rows(i).Cells(7).Value
                    Command.Parameters(9).Value = ESSalaryDataGridView.Rows(i).Cells(8).Value
                    Command.Parameters(10).Value = ESSalaryDataGridView.Rows(i).Cells(9).Value
                    Command.Parameters(11).Value = ESSalaryDataGridView.Rows(i).Cells(10).Value
                    Command.Parameters(12).Value = ESSalaryDataGridView.Rows(i).Cells(11).Value
                    Command.Parameters(13).Value = ESSalaryDataGridView.Rows(i).Cells(12).Value
                    Command.Parameters(14).Value = ESSalaryDataGridView.Rows(i).Cells(13).Value
                    Command.Parameters(15).Value = ESSalaryDataGridView.Rows(i).Cells(14).Value
                    Command.Parameters(16).Value = ESSalaryDataGridView.Rows(i).Cells(15).Value
                    Command.Parameters(17).Value = ESSalaryDataGridView.Rows(i).Cells(16).Value
                    Command.Parameters(18).Value = ESSalaryDataGridView.Rows(i).Cells(17).Value
                    Command.Parameters(19).Value = ESSalaryDataGridView.Rows(i).Cells(18).Value
                    Command.Parameters(20).Value = ESSalaryDataGridView.Rows(i).Cells(19).Value
                    Command.Parameters(21).Value = ESSalaryDataGridView.Rows(i).Cells(20).Value
                    Command.Parameters(22).Value = ESSalaryDataGridView.Rows(i).Cells(21).Value
                    Command.ExecuteNonQuery()
                Next

                Parameters.Clear()

                Adapter = New SqlDataAdapter(Command)
                Data = New DataSet

                Connection.Close()
                MsgBox("Saved successfully.")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("Payroll for this cutoff has already been generated and saved.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
                Connection.Close()
            End Try
        Else
            MsgBox("Payroll for this cutoff has already been generated and saved.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Alert")
        End If
    End Sub

    Private Sub ManageUsersButton_Click(sender As Object, e As EventArgs) Handles ManageUsersButton.Click
        Me.Enabled = False
        UsersForm.Show(Me)
    End Sub

    Private Sub DashRefreshButton_Click(sender As Object, e As EventArgs) Handles DashRefreshButton.Click
        LoadAttendanceDetails()
        LoadLeaveRequestDetails()
        LoadHolidayDetails()
        GetUpcomingProject()
    End Sub

    Private Sub btnEm3_Click(sender As Object, e As EventArgs) Handles btnEm3.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "EmployeeIDGenPanel" Then
                gb.Visible = True
                gb.Enabled = True
                GetNames()
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Public Sub GetNames()
        Dim query = "SELECT CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName
        FROM Employees
        LEFT OUTER JOIN Department
        ON Employees.DepartmentID = Department.ID"

        Prepare(query)
        ExecutePrepare()

        IDEmpNamesComboBox.DisplayMember = "EmployeeName"
        IDEmpNamesComboBox.DataSource = DataAsTable
        IDEmpNamesComboBox.SelectedIndex = 0
        IDEmpNamesComboBox.MaxDropDownItems = 5
    End Sub

    Public Sub LoadID()
        Try
            Dim query = "SELECT EmployeeID, Photo FROM Employees 
            WHERE CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) LIKE @Name"

            Prepare(query)
            AddParam("@Name", "%" & IDEmpNamesComboBox.Text & "%")
            ExecutePrepare()

            If Count > 0 Then
                Dim row As DataRow = DataAsTable.Rows(0)

                IDNameLabel.Text = "Name: " & IDEmpNamesComboBox.Text
                If Not IsDBNull(row("Photo")) Then
                    GetPhoto(row("Photo"))
                End If
                GenQR(row("EmployeeID"))
            End If
        Catch ex As Exception
            MsgBox("ID is Loading...", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
        End Try
    End Sub

    Public Sub GetPhoto(Photo As Byte())
        Try
            Dim imageData As Byte() = Photo

            Using ms As New MemoryStream(imageData, 0, imageData.Length)
                ms.Write(imageData, 0, imageData.Length)
                IDPhotoPictureBox.Image = Image.FromStream(ms, True)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub GenQR(EmpID As String)
        Dim encode As New QRCodeEncoder With {
            .QRCodeVersion = 1,
            .QRCodeScale = 150
        }
        Dim qrImage As Bitmap = encode.Encode(EmpID)
        IDQRPictureBox.Image = qrImage
    End Sub

    Public Sub GenID()
        Dim originalImage = IDPhotoPictureBox.Image

        Dim croppedImage As New Bitmap(originalImage.Width, originalImage.Height)

        Using g = Graphics.FromImage(croppedImage)
            Dim path As New GraphicsPath

            path.AddEllipse(0, 0, croppedImage.Width, croppedImage.Height)

            Dim reg As New Region(path)

            g.Clip = reg
            g.DrawImage(originalImage, Point.Empty)
        End Using

        IDPhotoPictureBox.Image = croppedImage
    End Sub

    Private Sub IDEmpNamesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles IDEmpNamesComboBox.SelectedIndexChanged
        LoadID()
        GenID()
    End Sub

    Private Sub GuardianTextBox_MouseClick(sender As Object, e As MouseEventArgs) Handles IDGuardianTextBox.MouseClick
        IDGuardianTextBox.SelectAll()
    End Sub

    Private Sub IDAddressTextBox_MouseClick(sender As Object, e As MouseEventArgs) Handles IDAddressTextBox.MouseClick
        IDAddressTextBox.SelectAll()
    End Sub

    Private Sub IDContactTextBox_MouseClick(sender As Object, e As MouseEventArgs) Handles IDContactTextBox.MouseClick
        IDContactTextBox.SelectAll()
    End Sub

    Private ppd As New PrintPreviewDialog
    Private bitmap As Bitmap

    Private Sub IDPrintButton_Click(sender As Object, e As EventArgs) Handles IDPrintButton.Click
        Try
            Dim bmp As New Bitmap(CInt(IDPanel.Width), CInt(IDPanel.Height))
            IDPanel.DrawToBitmap(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height))

            Dim bmp2 As New Bitmap(bmp.Width, bmp.Height)
            bmp2.SetResolution(180, 180)
            Dim gr As Graphics = Graphics.FromImage(bmp2)
            gr.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
            gr.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            gr.PixelOffsetMode = PixelOffsetMode.HighQuality
            gr.DrawImage(bmp, New Rectangle(0, 0, bmp2.Width, bmp2.Height))

            bitmap = bmp2
            ppd.Document = IDPrintDocument
            ppd.Document.DocumentName = IDEmpNamesComboBox.Text
            ppd.PrintPreviewControl.Zoom = 1
            ppd.Width = 1280
            ppd.Height = 720
            ppd.StartPosition = FormStartPosition.CenterScreen
            ppd.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IDPrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles IDPrintDocument.PrintPage
        e.Graphics.DrawImage(bitmap, 50, 50)
        e.Graphics.PageUnit = GraphicsUnit.Pixel
    End Sub

    Private Sub ESViewPayrollsButton_Click(sender As Object, e As EventArgs)
        Me.Enabled = False
        PrintPayrollForm.Show(Me)
    End Sub

    Private Sub btnPay2_Click(sender As Object, e As EventArgs) Handles btnPay2.Click
        Me.Enabled = False
        PrintPayrollForm.Show(Me)
    End Sub

    Private Sub ESRemovePayrollButton_Click(sender As Object, e As EventArgs) Handles ESRemovePayrollButton.Click
        If CheckIfGenerated() Then
            If MsgBox("Are you sure to remove this payroll record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
                Dim query = "DELETE FROM EmployeeSalary WHERE PayrollType = @PayrollType AND CutOff = @CutOff AND (MONTH(DateFrom) = @MonthFrom AND DAY(DateFrom) = @DayFrom  AND YEAR(DateFrom) = @YearFrom) AND (MONTH(DateTo) = @MonthTo AND DAY(DateTo) = @DayTo  AND YEAR(DateTo) = @YearTo)"
                Dim DayFrom, DayTo As Integer
                Dim CutOff As String

                If ESPayrollTypeComboBox.SelectedIndex = 0 Then
                    If ESCutOffComboBox.SelectedIndex = 0 Then
                        DayFrom = "1"
                        DayTo = "15"
                        CutOff = ESCutOffComboBox.Text
                    Else
                        DayFrom = "16"
                        DayTo = Date.DaysInMonth(ESYearDateTimePicker.Value.Year, ESMonthDateTimePicker.Value.Month)
                        CutOff = ESCutOffComboBox.Text
                    End If
                Else
                    DayFrom = "1"
                    DayTo = Date.DaysInMonth(ESYearDateTimePicker.Value.Year, ESMonthDateTimePicker.Value.Month)
                    CutOff = "1-" & DayTo
                End If

                Prepare(query)
                AddParam("@PayrollType", ESPayrollTypeComboBox.Text)
                AddParam("@CutOff", CutOff)
                AddParam("@MonthFrom", ESMonthDateTimePicker.Value.Month)
                AddParam("@DayFrom", DayFrom)
                AddParam("@YearFrom", ESYearDateTimePicker.Value.Year)
                AddParam("@MonthTo", ESMonthDateTimePicker.Value.Month)
                AddParam("@DayTo", DayTo)
                AddParam("@YearTo", ESYearDateTimePicker.Value.Year)
                ExecutePrepare()

                ESClearButton.PerformClick()
                MsgBox("Payroll record successfully removed", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
            End If
        Else
            MsgBox("Remove failed. There's no payroll record.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
        End If
    End Sub

    Private Sub ESCutOffComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ESCutOffComboBox.SelectedIndexChanged
        ESSaveButton.Enabled = False
    End Sub

    Private Sub ESMonthDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles ESMonthDateTimePicker.ValueChanged
        ESSaveButton.Enabled = False
    End Sub

    Private Sub ESYearDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles ESYearDateTimePicker.ValueChanged
        ESSaveButton.Enabled = False
    End Sub
End Class