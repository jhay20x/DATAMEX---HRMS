Public Class EmployeeListAddForm
    Private Sub EmployeeListAddForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub EmployeeListAddForm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed, Me.Closed
        DashBoardForm.Enabled = True
        DashBoardForm.Show()
    End Sub

    Private Sub ELABackButton_Click(sender As Object, e As EventArgs) Handles ELABackButton.Click
        DashBoardForm.Enabled = True
        Me.Hide()
        Me.Close()
        DashBoardForm.Show()
    End Sub
End Class