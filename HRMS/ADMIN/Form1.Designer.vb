<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.EyeButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.LoginButton = New System.Windows.Forms.Button()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HRM1.My.Resources.Resources.bg4
        Me.PictureBox1.Location = New System.Drawing.Point(0, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(760, 597)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.EyeButton)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ExitButton)
        Me.Panel1.Controls.Add(Me.ClearButton)
        Me.Panel1.Controls.Add(Me.PasswordTextBox)
        Me.Panel1.Controls.Add(Me.LoginButton)
        Me.Panel1.Controls.Add(Me.UsernameTextBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(449, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(311, 597)
        Me.Panel1.TabIndex = 7
        '
        'EyeButton
        '
        Me.EyeButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EyeButton.Location = New System.Drawing.Point(259, 277)
        Me.EyeButton.Name = "EyeButton"
        Me.EyeButton.Size = New System.Drawing.Size(38, 39)
        Me.EyeButton.TabIndex = 2
        Me.EyeButton.Text = "👁"
        Me.EyeButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(106, 319)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 21)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "PASSWORD"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(106, 253)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 21)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "USERNAME"
        '
        'ExitButton
        '
        Me.ExitButton.BackColor = System.Drawing.Color.Transparent
        Me.ExitButton.BackgroundImage = Global.HRM1.My.Resources.Resources._EXIT
        Me.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExitButton.ForeColor = System.Drawing.Color.Transparent
        Me.ExitButton.Location = New System.Drawing.Point(91, 429)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(137, 59)
        Me.ExitButton.TabIndex = 5
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'ClearButton
        '
        Me.ClearButton.BackColor = System.Drawing.Color.Transparent
        Me.ClearButton.BackgroundImage = Global.HRM1.My.Resources.Resources.clear
        Me.ClearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClearButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ClearButton.ForeColor = System.Drawing.Color.Transparent
        Me.ClearButton.Location = New System.Drawing.Point(160, 364)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(137, 59)
        Me.ClearButton.TabIndex = 4
        Me.ClearButton.UseVisualStyleBackColor = False
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Font = New System.Drawing.Font("Segoe UI Semilight", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordTextBox.Location = New System.Drawing.Point(72, 277)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(196, 39)
        Me.PasswordTextBox.TabIndex = 1
        Me.PasswordTextBox.Text = "Jhayjay"
        Me.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LoginButton
        '
        Me.LoginButton.BackColor = System.Drawing.Color.Transparent
        Me.LoginButton.BackgroundImage = Global.HRM1.My.Resources.Resources.LOG_IN
        Me.LoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoginButton.FlatAppearance.BorderSize = 0
        Me.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LoginButton.ForeColor = System.Drawing.Color.Transparent
        Me.LoginButton.Location = New System.Drawing.Point(13, 364)
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Size = New System.Drawing.Size(137, 59)
        Me.LoginButton.TabIndex = 3
        Me.LoginButton.UseVisualStyleBackColor = False
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Font = New System.Drawing.Font("Segoe UI Semilight", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameTextBox.Location = New System.Drawing.Point(57, 211)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(196, 39)
        Me.UsernameTextBox.TabIndex = 0
        Me.UsernameTextBox.Text = "Jhayjay"
        Me.UsernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(263, 65)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "WELCOME"
        '
        'Login
        '
        Me.AcceptButton = Me.LoginButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.ExitButton
        Me.ClientSize = New System.Drawing.Size(760, 586)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(776, 625)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(776, 625)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DATAMEX - HRMS "
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents EyeButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ExitButton As Button
    Friend WithEvents ClearButton As Button
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents LoginButton As Button
    Friend WithEvents UsernameTextBox As TextBox
    Friend WithEvents Label1 As Label
End Class
