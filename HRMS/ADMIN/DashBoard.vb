Imports System.CodeDom
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml.Schema
Imports System.Xml.Serialization.Configuration

Public Class DashBoardForm
    Public EmpNames As New List(Of String)
    Public att As New List(Of String)
    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshTable()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles MenuHide1Button.Click, MenuHide2Button.Click, MenuHide3Button.Click, MenuHide5Button.Click, MenuHide6Button.Click, MenuHide7Button.Click
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

    Private Sub btnAtt2_Click(sender As Object, e As EventArgs) Handles btnAtt2.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "EmployeeAttendancePanel" Then
                gb.Visible = True
                gb.Enabled = True
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
        Dim query = "SELECT AttDate, CONVERT(varchar, AttendanceRecords.TimeIn, 22) AS TimeIn, CONVERT(varchar, AttendanceRecords.TimeOut, 22) AS TimeOut, TotalHours 
        FROM AttendanceRecords
		LEFT OUTER JOIN Employees
		ON AttendanceRecords.EmployeeID = Employees.EmployeeID  
        WHERE CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) LIKE @Search"

        Prepare(query)
        AddParam("@Search", "%" & ASEmployeeNamesComboBox.Text & "%")
        ExecutePrepare()

        AttendanceSheetDataGridView.DataSource = DataAsTable
        AttendanceSheetDataGridView.Sort(AttendanceSheetDataGridView.Columns(2), ListSortDirection.Descending)
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

        ATTotalLabel.Text = Total
        ATPresentLabel.Text = Present
        ATAbsentLabel.Text = Total - Present
    End Sub

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
                EmployeesDataGridView.CurrentCell = Nothing
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
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
        LRApprovedLabel.Text = ApprovedCount
        LRRejectedLabel.Text = RejectedCount
    End Sub

    Private Sub btnHol1_Click(sender As Object, e As EventArgs) Handles btnHol1.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "HolidayListPanel" Then
                gb.Visible = True
                gb.Enabled = True
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub btnPro1_Click(sender As Object, e As EventArgs) Handles btnPro1.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "ProjectsListPanel" Then
                gb.Visible = True
                gb.Enabled = True
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
    End Sub

    Private Sub btnPay1_Click(sender As Object, e As EventArgs) Handles btnPay1.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "EmployeesSalaryPanel" Then
                gb.Visible = True
                gb.Enabled = True
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
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
        Status.Status as 'StatusID', Department.Department AS 'DepartmentID', Employees.DateHired, Employees.Age, Employees.Address, Employees.SSSNo, Employees.PhilHealthNo, Employees.PagibigNo, 
        Employees.TIN, Employees.ContactNumber, Employees.EmailAddress FROM Employees 
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
End Class