Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class DashBoardForm
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles MenuHide1Button.Click, MenuHide2Button.Click, MenuHide3Button.Click, MenuHide4Button.Click, MenuHide5Button.Click, MenuHide6Button.Click, MenuHide7Button.Click
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
                gb.Visible = True
                gb.Enabled = True
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
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

    Private Sub btnLev1_Click(sender As Object, e As EventArgs) Handles btnLev1.Click
        For Each gb As Panel In MainPanel.Controls.OfType(Of Panel)
            If gb.Name = "LeaveRequestPanel" Then
                gb.Visible = True
                gb.Enabled = True
            Else
                gb.Visible = False
                gb.Enabled = False
            End If
        Next
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
            Me.EmployeesDataGridView.Sort(Me.EmployeesDataGridView.Columns(5), ListSortDirection.Descending)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub DisableButton()
        EmployeesDataGridView.CurrentCell = Nothing
        EmployeeListEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit_disabled
        EmployeeListEditButton.Enabled = False
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

        Dim query = "SELECT Employees.ID, Employees.EmployeeID, Employees.LastName, Employees.FirstName, Employees.MiddleName, Status.Status as 'StatusID', 
        Department.Department AS 'DepartmentID', Employees.DateHired, Employees.Age, Employees.Address, Employees.SSSNo, Employees.PhilHealthNo, 
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
        Dim query = "SELECT Employees.ID, Employees.EmployeeID, Employees.LastName, Employees.FirstName, Employees.MiddleName, Status.Status as 'StatusID', 
        Department.Department AS 'DepartmentID', Employees.DateHired, Employees.Age, Employees.Address, Employees.SSSNo, Employees.PhilHealthNo, Employees.PagibigNo, 
        Employees.TIN, Employees.ContactNumber, Employees.EmailAddress FROM Employees 
        INNER JOIN Department 
        ON Employees.DepartmentID = Department.ID 
        INNER JOIN Status  
        ON Employees.StatusID = Status.ID"

        Prepare(query)
        ExecutePrepare()

        EmployeesDataGridView.DataSource = DataAsTable.DefaultView
        Me.EmployeesDataGridView.Sort(Me.EmployeesDataGridView.Columns(5), ListSortDirection.Descending)
    End Sub
End Class