Public Class DashBoard
    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelAtt.Visible = False
        PanelLeave.Visible = False
    End Sub

    Private Sub btnAttendance_Click(sender As Object, e As EventArgs) Handles btnAttendance.Click
        If PanelAtt.Visible = False Then
            PanelAtt.Visible = True
        Else
            PanelAtt.Visible = False
        End If
    End Sub

    Private Sub btnLeave_Click(sender As Object, e As EventArgs) Handles btnLeave.Click
        If PanelLeave.Visible = False Then
            PanelLeave.Visible = True
        Else
            PanelLeave.Visible = False
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class