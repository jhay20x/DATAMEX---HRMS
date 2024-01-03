<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeCredentialsForm
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
        Me.ECAddButton = New System.Windows.Forms.Button()
        Me.ECBackButton = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.ECMainPanel = New System.Windows.Forms.Panel()
        Me.ECEffectiveDateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ECAuthorizeTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ECReasonTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ECIncreaseTextBox = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Panel11.SuspendLayout()
        Me.ECMainPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = Global.HRM1.My.Resources.Resources.blue
        Me.Panel11.Controls.Add(Me.ECAddButton)
        Me.Panel11.Controls.Add(Me.ECBackButton)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(626, 52)
        Me.Panel11.TabIndex = 1
        '
        'ECAddButton
        '
        Me.ECAddButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ECAddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ECAddButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ECAddButton.Location = New System.Drawing.Point(516, 9)
        Me.ECAddButton.Name = "ECAddButton"
        Me.ECAddButton.Size = New System.Drawing.Size(98, 35)
        Me.ECAddButton.TabIndex = 0
        Me.ECAddButton.Text = "ADD"
        Me.ECAddButton.UseVisualStyleBackColor = True
        '
        'ECBackButton
        '
        Me.ECBackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ECBackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ECBackButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ECBackButton.Location = New System.Drawing.Point(11, 9)
        Me.ECBackButton.Name = "ECBackButton"
        Me.ECBackButton.Size = New System.Drawing.Size(98, 35)
        Me.ECBackButton.TabIndex = 1
        Me.ECBackButton.Text = "BACK"
        Me.ECBackButton.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(111, 9)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(400, 37)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "ADD EMPLOYEE CREDENTIALS"
        '
        'ECMainPanel
        '
        Me.ECMainPanel.Controls.Add(Me.ECEffectiveDateDateTimePicker)
        Me.ECMainPanel.Controls.Add(Me.Label3)
        Me.ECMainPanel.Controls.Add(Me.ECAuthorizeTextBox)
        Me.ECMainPanel.Controls.Add(Me.Label2)
        Me.ECMainPanel.Controls.Add(Me.ECReasonTextBox)
        Me.ECMainPanel.Controls.Add(Me.Label1)
        Me.ECMainPanel.Controls.Add(Me.ECIncreaseTextBox)
        Me.ECMainPanel.Controls.Add(Me.Label66)
        Me.ECMainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ECMainPanel.Location = New System.Drawing.Point(0, 52)
        Me.ECMainPanel.Name = "ECMainPanel"
        Me.ECMainPanel.Size = New System.Drawing.Size(626, 186)
        Me.ECMainPanel.TabIndex = 26
        '
        'ECEffectiveDateDateTimePicker
        '
        Me.ECEffectiveDateDateTimePicker.CustomFormat = "M/dd/yyyy"
        Me.ECEffectiveDateDateTimePicker.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ECEffectiveDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ECEffectiveDateDateTimePicker.Location = New System.Drawing.Point(199, 134)
        Me.ECEffectiveDateDateTimePicker.Name = "ECEffectiveDateDateTimePicker"
        Me.ECEffectiveDateDateTimePicker.Size = New System.Drawing.Size(125, 29)
        Me.ECEffectiveDateDateTimePicker.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(97, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 21)
        Me.Label3.TabIndex = 33
        Me.Label3.Tag = ""
        Me.Label3.Text = "Effective On:"
        '
        'ECAuthorizeTextBox
        '
        Me.ECAuthorizeTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ECAuthorizeTextBox.Location = New System.Drawing.Point(199, 97)
        Me.ECAuthorizeTextBox.Name = "ECAuthorizeTextBox"
        Me.ECAuthorizeTextBox.Size = New System.Drawing.Size(221, 29)
        Me.ECAuthorizeTextBox.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(83, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 21)
        Me.Label2.TabIndex = 32
        Me.Label2.Tag = ""
        Me.Label2.Text = "Authorized By:"
        '
        'ECReasonTextBox
        '
        Me.ECReasonTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ECReasonTextBox.Location = New System.Drawing.Point(199, 23)
        Me.ECReasonTextBox.MaxLength = 50
        Me.ECReasonTextBox.Name = "ECReasonTextBox"
        Me.ECReasonTextBox.Size = New System.Drawing.Size(221, 29)
        Me.ECReasonTextBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 21)
        Me.Label1.TabIndex = 31
        Me.Label1.Tag = ""
        Me.Label1.Text = "Description/Reason:"
        '
        'ECIncreaseTextBox
        '
        Me.ECIncreaseTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ECIncreaseTextBox.Location = New System.Drawing.Point(199, 60)
        Me.ECIncreaseTextBox.Name = "ECIncreaseTextBox"
        Me.ECIncreaseTextBox.Size = New System.Drawing.Size(221, 29)
        Me.ECIncreaseTextBox.TabIndex = 1
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(7, 63)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(186, 21)
        Me.Label66.TabIndex = 30
        Me.Label66.Tag = ""
        Me.Label66.Text = "Salary Increase/Decrease:"
        '
        'EmployeeCredentialsForm
        '
        Me.AcceptButton = Me.ECAddButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.ECBackButton
        Me.ClientSize = New System.Drawing.Size(626, 238)
        Me.Controls.Add(Me.ECMainPanel)
        Me.Controls.Add(Me.Panel11)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EmployeeCredentialsForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Employee Credentials"
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.ECMainPanel.ResumeLayout(False)
        Me.ECMainPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel11 As Panel
    Friend WithEvents ECAddButton As Button
    Friend WithEvents ECBackButton As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents ECMainPanel As Panel
    Friend WithEvents ECEffectiveDateDateTimePicker As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents ECAuthorizeTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ECReasonTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ECIncreaseTextBox As TextBox
    Friend WithEvents Label66 As Label
End Class
