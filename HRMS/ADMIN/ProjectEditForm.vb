Public Class ProjectEditForm
    Public ProjectID As Integer
    Public EmpID As String
    Private Sub ProjectAddForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateEmployeeNames()
        PopulateStatus()
        DisplayData()
    End Sub

    Public Sub DisplayData()
        Dim query = "SELECT * FROM Projects WHERE ID = @ID"

        Prepare(query)
        AddParam("@ID", ProjectID)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            PJNameTextBox.Text = row("ProjectName")
            PJEmployeeNamesComboBox.Text = GetEmpName(row("ProjectHeadID"))
            EmpID = row("ProjectHeadID")
            PJDescTextBox.Text = row("ProjectDescription")
            PJDateStartDateTimePicker.Value = row("ProjectDateStart")
            PJDateEndDateTimePicker.Value = row("ProjectDateEnd")
            PJStatusComboBox.SelectedIndex = row("ProjectStatusID") - 1
        End If
    End Sub

    Public Function GetEmpName(EmpID As String)
        Dim query = "SELECT CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName 
        FROM Employees WHERE EmployeeID = @EmpID"

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

    Public Function GetEmpID(Name As String)
        Dim query = "SELECT EmployeeID FROM Employees WHERE CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) LIKE @Name"

        Prepare(query)
        AddParam("@Name", Name)
        ExecutePrepare()

        If Count > 0 Then
            Dim row As DataRow = DataAsTable.Rows(0)

            Return row("EmployeeID")
        Else
            Return Nothing
        End If
    End Function

    Public Sub PopulateStatus()
        Dim query = "SELECT Status FROM ProjectsStatus"

        Prepare(query)
        ExecutePrepare()

        PJStatusComboBox.DisplayMember = "Status"
        PJStatusComboBox.DataSource = DataAsTable.DefaultView
        PJStatusComboBox.SelectedIndex = 0
        PJStatusComboBox.MaxDropDownItems = 5
    End Sub

    Public Sub PopulateEmployeeNames()
        Dim query = "SELECT CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS ProjectHead FROM Employees"

        Prepare(query)
        ExecutePrepare()

        PJEmployeeNamesComboBox.DisplayMember = "ProjectHead"
        PJEmployeeNamesComboBox.DataSource = DataAsTable.DefaultView
        PJEmployeeNamesComboBox.SelectedIndex = 0
        PJEmployeeNamesComboBox.MaxDropDownItems = 5
    End Sub

    Private Sub PJAddButton_Click(sender As Object, e As EventArgs) Handles PJAddButton.Click
        Dim TextBoxCtrl As Control
        Dim TextCount As Integer
        Dim Curdate As Date = Date.Today

        EmpID = GetEmpID(PJEmployeeNamesComboBox.Text)

        For Each TextBoxCtrl In Panel1.Controls.OfType(Of TextBox)
            If TextBoxCtrl.Text = "" Then
                TextCount += 1
            End If
        Next

        For Each TextBoxCtrl In Panel1.Controls.OfType(Of ComboBox)
            If TextBoxCtrl.Text = "" Then
                TextCount += 1
            End If
        Next

        If TextCount = 0 Then
            If PJDateStartDateTimePicker.Value = Curdate Or PJDateEndDateTimePicker.Value = Curdate Then
                MsgBox("Start or end date must be a day before or more from today. Please try again.", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "Alert")
            Else
                If PJDateEndDateTimePicker.Value < PJDateStartDateTimePicker.Value Then
                    MsgBox("End date must be a day before or more from the start date. Please try again.", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "Alert")
                Else
                    If MsgBox("Are you sure to save this project?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
                        Dim Status As Integer = PJStatusComboBox.SelectedIndex + 1
                        Dim duration As TimeSpan = PJDateEndDateTimePicker.Value - PJDateStartDateTimePicker.Value

                        Dim query = "UPDATE Projects SET ProjectName=@ProjectName, ProjectHeadID=@ProjectHeadID, ProjectDescription=@ProjectDescription, ProjectDateCreation=@ProjectDateCreation, 
                        ProjectDateStart=@ProjectDateStart, ProjectDateEnd=@ProjectDateEnd, ProjectDuration=@ProjectDuration, ProjectStatusID=@ProjectStatusID WHERE ID = @ID"

                        Prepare(query)
                        AddParam("@ProjectName", PJNameTextBox.Text)
                        AddParam("@ProjectHeadID", EmpID)
                        AddParam("@ProjectDescription", PJDescTextBox.Text)
                        AddParam("@ProjectDateCreation", Curdate)
                        AddParam("@ProjectDateStart", PJDateStartDateTimePicker.Value)
                        AddParam("@ProjectDateEnd", PJDateEndDateTimePicker.Value)
                        AddParam("@ProjectDuration", duration.TotalDays + 1)
                        AddParam("@ProjectStatusID", Status)
                        AddParam("@ID", ProjectID)
                        ExecutePrepare()

                        DashBoardForm.LoadProjects(DashBoardForm.ProjectNameSearchTextBox.Text)
                        DashBoardForm.LoadProjectDetails()
                        DashBoardForm.DisableButton()
                        MsgBox("A new project has been successfully added.", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "Alert")
                    End If
                End If
            End If
        Else
            MsgBox("Fill-up all the required fields first.", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "Alert")
        End If
    End Sub

    Private Sub ProjectAddForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        DashBoardForm.Enabled = True
        DashBoardForm.LoadProjects(DashBoardForm.ProjectNameSearchTextBox.Text)
        DashBoardForm.LoadProjectDetails()
        DashBoardForm.DisableButton()
        DashBoardForm.Show()
    End Sub

    Private Sub PJBackButton_Click(sender As Object, e As EventArgs) Handles PJBackButton.Click
        Me.Close()
    End Sub
End Class