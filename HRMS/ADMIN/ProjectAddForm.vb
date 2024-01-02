Imports System.Runtime.CompilerServices

Public Class ProjectAddForm
    Public isDone As Boolean
    Private Sub ProjectAddForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateEmployeeNames()
        PJDateStartDateTimePicker.Value = Date.Today
        PJDateEndDateTimePicker.Value = Date.Today
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
        Dim EmpID As String = GetEmpID(PJEmployeeNamesComboBox.Text)

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
                        Dim Status As Integer = 1
                        Dim duration As TimeSpan = PJDateEndDateTimePicker.Value - PJDateStartDateTimePicker.Value

                        Dim query = "INSERT INTO Projects (ProjectName, ProjectHeadID, ProjectDescription, ProjectDateCreation, ProjectDateStart, ProjectDateEnd, 
                        ProjectDuration, ProjectStatusID) VALUES (@ProjectName, @ProjectHeadID, @ProjectDescription, @ProjectDateCreation, @ProjectDateStart, 
                        @ProjectDateEnd, @ProjectDuration, @ProjectStatusID)"

                        Prepare(query)
                        AddParam("@ProjectName", PJNameTextBox.Text)
                        AddParam("@ProjectHeadID", EmpID)
                        AddParam("@ProjectDescription", PJDescTextBox.Text)
                        AddParam("@ProjectDateCreation", Curdate)
                        AddParam("@ProjectDateStart", PJDateStartDateTimePicker.Value)
                        AddParam("@ProjectDateEnd", PJDateEndDateTimePicker.Value)
                        AddParam("@ProjectDuration", duration.TotalDays + 1)
                        AddParam("@ProjectStatusID", Status)
                        ExecutePrepare()

                        For Each ctrl In Panel1.Controls
                            If TypeOf ctrl Is TextBox Then
                                ctrl.text = ""
                            ElseIf TypeOf ctrl Is ComboBox Then
                                ctrl.selectedindex = 0
                            ElseIf TypeOf ctrl Is DateTimePicker Then
                                ctrl.value = Date.Today
                            End If
                        Next

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

    Private Sub ProjectAddForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If isDone Then
            e.Cancel = False
            DashBoardForm.Enabled = True
            DashBoardForm.Show()
        Else
            If MsgBox("Are you sure to leave?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                DashBoardForm.Enabled = True
                DashBoardForm.Show()
            End If
        End If
    End Sub

    Private Sub PJBackButton_Click(sender As Object, e As EventArgs) Handles PJBackButton.Click
        Me.Close()
    End Sub
End Class