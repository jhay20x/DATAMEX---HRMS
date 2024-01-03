<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UsersForm
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
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.MUAddButton = New System.Windows.Forms.Button()
        Me.MUBackButton = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.MUEmpNamesComboBox = New System.Windows.Forms.ComboBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.MUUsernameTextBox = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.MUPasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MUUserEyeButton = New System.Windows.Forms.Button()
        Me.MUPasswordEyeButton = New System.Windows.Forms.Button()
        Me.MUIsAdminComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = Global.HRM1.My.Resources.Resources.blue
        Me.Panel11.Controls.Add(Me.MUAddButton)
        Me.Panel11.Controls.Add(Me.MUBackButton)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(467, 52)
        Me.Panel11.TabIndex = 1
        '
        'MUAddButton
        '
        Me.MUAddButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MUAddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MUAddButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MUAddButton.Location = New System.Drawing.Point(357, 9)
        Me.MUAddButton.Name = "MUAddButton"
        Me.MUAddButton.Size = New System.Drawing.Size(98, 35)
        Me.MUAddButton.TabIndex = 0
        Me.MUAddButton.Text = "SAVE"
        Me.MUAddButton.UseVisualStyleBackColor = True
        '
        'MUBackButton
        '
        Me.MUBackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MUBackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.MUBackButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MUBackButton.Location = New System.Drawing.Point(11, 9)
        Me.MUBackButton.Name = "MUBackButton"
        Me.MUBackButton.Size = New System.Drawing.Size(98, 35)
        Me.MUBackButton.TabIndex = 1
        Me.MUBackButton.Text = "BACK"
        Me.MUBackButton.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(111, 9)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(224, 37)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "MANAGE USERS"
        '
        'MUEmpNamesComboBox
        '
        Me.MUEmpNamesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MUEmpNamesComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MUEmpNamesComboBox.FormattingEnabled = True
        Me.MUEmpNamesComboBox.Items.AddRange(New Object() {"Semi-Monthly", "Monthly"})
        Me.MUEmpNamesComboBox.Location = New System.Drawing.Point(146, 71)
        Me.MUEmpNamesComboBox.Name = "MUEmpNamesComboBox"
        Me.MUEmpNamesComboBox.Size = New System.Drawing.Size(220, 29)
        Me.MUEmpNamesComboBox.TabIndex = 0
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.Location = New System.Drawing.Point(13, 74)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(127, 21)
        Me.Label78.TabIndex = 28
        Me.Label78.Tag = ""
        Me.Label78.Text = "Employee Name:"
        '
        'MUUsernameTextBox
        '
        Me.MUUsernameTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MUUsernameTextBox.Location = New System.Drawing.Point(146, 106)
        Me.MUUsernameTextBox.Name = "MUUsernameTextBox"
        Me.MUUsernameTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.MUUsernameTextBox.Size = New System.Drawing.Size(168, 29)
        Me.MUUsernameTextBox.TabIndex = 1
        Me.MUUsernameTextBox.Tag = "Break"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(56, 109)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 21)
        Me.Label16.TabIndex = 30
        Me.Label16.Tag = ""
        Me.Label16.Text = "Username:"
        '
        'MUPasswordTextBox
        '
        Me.MUPasswordTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MUPasswordTextBox.Location = New System.Drawing.Point(146, 141)
        Me.MUPasswordTextBox.Name = "MUPasswordTextBox"
        Me.MUPasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.MUPasswordTextBox.Size = New System.Drawing.Size(168, 29)
        Me.MUPasswordTextBox.TabIndex = 3
        Me.MUPasswordTextBox.Tag = "Break"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(61, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 21)
        Me.Label1.TabIndex = 32
        Me.Label1.Tag = ""
        Me.Label1.Text = "Password:"
        '
        'MUUserEyeButton
        '
        Me.MUUserEyeButton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MUUserEyeButton.Location = New System.Drawing.Point(320, 106)
        Me.MUUserEyeButton.Name = "MUUserEyeButton"
        Me.MUUserEyeButton.Size = New System.Drawing.Size(33, 29)
        Me.MUUserEyeButton.TabIndex = 2
        Me.MUUserEyeButton.Text = "👁"
        Me.MUUserEyeButton.UseVisualStyleBackColor = True
        '
        'MUPasswordEyeButton
        '
        Me.MUPasswordEyeButton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MUPasswordEyeButton.Location = New System.Drawing.Point(320, 141)
        Me.MUPasswordEyeButton.Name = "MUPasswordEyeButton"
        Me.MUPasswordEyeButton.Size = New System.Drawing.Size(33, 29)
        Me.MUPasswordEyeButton.TabIndex = 4
        Me.MUPasswordEyeButton.Text = "👁"
        Me.MUPasswordEyeButton.UseVisualStyleBackColor = True
        '
        'MUIsAdminComboBox
        '
        Me.MUIsAdminComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MUIsAdminComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MUIsAdminComboBox.FormattingEnabled = True
        Me.MUIsAdminComboBox.Items.AddRange(New Object() {"No", "Yes"})
        Me.MUIsAdminComboBox.Location = New System.Drawing.Point(146, 176)
        Me.MUIsAdminComboBox.Name = "MUIsAdminComboBox"
        Me.MUIsAdminComboBox.Size = New System.Drawing.Size(168, 29)
        Me.MUIsAdminComboBox.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(66, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 21)
        Me.Label2.TabIndex = 36
        Me.Label2.Tag = ""
        Me.Label2.Text = "Is Admin:"
        '
        'UsersForm
        '
        Me.AcceptButton = Me.MUAddButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.MUBackButton
        Me.ClientSize = New System.Drawing.Size(467, 223)
        Me.Controls.Add(Me.MUIsAdminComboBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MUPasswordEyeButton)
        Me.Controls.Add(Me.MUUserEyeButton)
        Me.Controls.Add(Me.MUPasswordTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MUUsernameTextBox)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.MUEmpNamesComboBox)
        Me.Controls.Add(Me.Label78)
        Me.Controls.Add(Me.Panel11)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UsersForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Users"
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel11 As Panel
    Friend WithEvents MUAddButton As Button
    Friend WithEvents MUBackButton As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents MUEmpNamesComboBox As ComboBox
    Friend WithEvents Label78 As Label
    Friend WithEvents MUUsernameTextBox As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents MUPasswordTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents MUUserEyeButton As Button
    Friend WithEvents MUPasswordEyeButton As Button
    Friend WithEvents MUIsAdminComboBox As ComboBox
    Friend WithEvents Label2 As Label
End Class
