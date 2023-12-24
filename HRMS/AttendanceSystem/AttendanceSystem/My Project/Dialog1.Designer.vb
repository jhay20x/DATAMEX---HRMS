<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MessageLabel = New System.Windows.Forms.Label()
        Me.AutoCloseProgressBar = New System.Windows.Forms.ProgressBar()
        Me.ProgressBarTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'MessageLabel
        '
        Me.MessageLabel.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MessageLabel.ForeColor = System.Drawing.Color.Black
        Me.MessageLabel.Location = New System.Drawing.Point(30, 20)
        Me.MessageLabel.Name = "MessageLabel"
        Me.MessageLabel.Size = New System.Drawing.Size(456, 107)
        Me.MessageLabel.TabIndex = 4
        Me.MessageLabel.Text = "Today is:"
        '
        'AutoCloseProgressBar
        '
        Me.AutoCloseProgressBar.Location = New System.Drawing.Point(33, 139)
        Me.AutoCloseProgressBar.Maximum = 1000
        Me.AutoCloseProgressBar.Name = "AutoCloseProgressBar"
        Me.AutoCloseProgressBar.Size = New System.Drawing.Size(451, 36)
        Me.AutoCloseProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.AutoCloseProgressBar.TabIndex = 5
        '
        'ProgressBarTimer
        '
        Me.ProgressBarTimer.Enabled = True
        Me.ProgressBarTimer.Interval = 30
        '
        'MessageDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 196)
        Me.ControlBox = False
        Me.Controls.Add(Me.AutoCloseProgressBar)
        Me.Controls.Add(Me.MessageLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MessageDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Message"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MessageLabel As Label
    Friend WithEvents AutoCloseProgressBar As ProgressBar
    Friend WithEvents ProgressBarTimer As Timer
End Class
