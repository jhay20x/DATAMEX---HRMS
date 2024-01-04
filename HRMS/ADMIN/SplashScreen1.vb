Public NotInheritable Class SplashScreen1
    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub SplashScreen1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Application.DoEvents()
        Dim sw As New Stopwatch
        sw.Start()
        Do : Loop While sw.ElapsedMilliseconds < 2000
    End Sub
End Class
