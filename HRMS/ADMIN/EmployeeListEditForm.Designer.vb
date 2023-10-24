<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmployeeListEditForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ELEFormPanel = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ELEEmployeeStatusComboBox = New System.Windows.Forms.ComboBox()
        Me.ELEContTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ELEEmailTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ELEDeptComboBox = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ELEPITextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ELEPHTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ELESSSTextBox = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ELETINTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ELEAddressTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ELEAgeTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ELENameTextBox = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ELEEmpIDLabel = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.ELEAddButton = New System.Windows.Forms.Button()
        Me.ELEBackButton = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.ELEFormPanel.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.ELEFormPanel)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel11)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(736, 545)
        Me.Panel2.TabIndex = 12
        '
        'ELEFormPanel
        '
        Me.ELEFormPanel.Controls.Add(Me.Label7)
        Me.ELEFormPanel.Controls.Add(Me.ELEEmployeeStatusComboBox)
        Me.ELEFormPanel.Controls.Add(Me.ELEContTextBox)
        Me.ELEFormPanel.Controls.Add(Me.Label4)
        Me.ELEFormPanel.Controls.Add(Me.ELEEmailTextBox)
        Me.ELEFormPanel.Controls.Add(Me.Label5)
        Me.ELEFormPanel.Controls.Add(Me.Label6)
        Me.ELEFormPanel.Controls.Add(Me.ELEDeptComboBox)
        Me.ELEFormPanel.Controls.Add(Me.Label11)
        Me.ELEFormPanel.Controls.Add(Me.ELEPITextBox)
        Me.ELEFormPanel.Controls.Add(Me.Label8)
        Me.ELEFormPanel.Controls.Add(Me.ELEPHTextBox)
        Me.ELEFormPanel.Controls.Add(Me.Label9)
        Me.ELEFormPanel.Controls.Add(Me.ELESSSTextBox)
        Me.ELEFormPanel.Controls.Add(Me.Label10)
        Me.ELEFormPanel.Controls.Add(Me.ELETINTextBox)
        Me.ELEFormPanel.Controls.Add(Me.Label3)
        Me.ELEFormPanel.Controls.Add(Me.ELEAddressTextBox)
        Me.ELEFormPanel.Controls.Add(Me.Label2)
        Me.ELEFormPanel.Controls.Add(Me.ELEAgeTextBox)
        Me.ELEFormPanel.Controls.Add(Me.Label1)
        Me.ELEFormPanel.Controls.Add(Me.ELENameTextBox)
        Me.ELEFormPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ELEFormPanel.Location = New System.Drawing.Point(0, 132)
        Me.ELEFormPanel.Name = "ELEFormPanel"
        Me.ELEFormPanel.Size = New System.Drawing.Size(736, 413)
        Me.ELEFormPanel.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(358, 194)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 21)
        Me.Label7.TabIndex = 33
        Me.Label7.Tag = ""
        Me.Label7.Text = "Status:"
        '
        'ELEEmployeeStatusComboBox
        '
        Me.ELEEmployeeStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ELEEmployeeStatusComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ELEEmployeeStatusComboBox.FormattingEnabled = True
        Me.ELEEmployeeStatusComboBox.Items.AddRange(New Object() {"Working", "Non-Working"})
        Me.ELEEmployeeStatusComboBox.Location = New System.Drawing.Point(492, 190)
        Me.ELEEmployeeStatusComboBox.Name = "ELEEmployeeStatusComboBox"
        Me.ELEEmployeeStatusComboBox.Size = New System.Drawing.Size(181, 29)
        Me.ELEEmployeeStatusComboBox.TabIndex = 34
        '
        'ELEContTextBox
        '
        Me.ELEContTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELEContTextBox.Location = New System.Drawing.Point(492, 37)
        Me.ELEContTextBox.MaxLength = 10
        Me.ELEContTextBox.Name = "ELEContTextBox"
        Me.ELEContTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELEContTextBox.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(358, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 21)
        Me.Label4.TabIndex = 28
        Me.Label4.Tag = ""
        Me.Label4.Text = "Contact Number:"
        '
        'ELEEmailTextBox
        '
        Me.ELEEmailTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELEEmailTextBox.Location = New System.Drawing.Point(492, 88)
        Me.ELEEmailTextBox.MaxLength = 30
        Me.ELEEmailTextBox.Name = "ELEEmailTextBox"
        Me.ELEEmailTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELEEmailTextBox.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(358, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 21)
        Me.Label5.TabIndex = 30
        Me.Label5.Tag = ""
        Me.Label5.Text = "Email Address:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(358, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 21)
        Me.Label6.TabIndex = 31
        Me.Label6.Tag = ""
        Me.Label6.Text = "Department:"
        '
        'ELEDeptComboBox
        '
        Me.ELEDeptComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ELEDeptComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ELEDeptComboBox.FormattingEnabled = True
        Me.ELEDeptComboBox.Items.AddRange(New Object() {"IT", "HM", "TM", "GP"})
        Me.ELEDeptComboBox.Location = New System.Drawing.Point(492, 139)
        Me.ELEDeptComboBox.Name = "ELEDeptComboBox"
        Me.ELEDeptComboBox.Size = New System.Drawing.Size(181, 29)
        Me.ELEDeptComboBox.TabIndex = 32
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label11.Location = New System.Drawing.Point(30, 347)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 21)
        Me.Label11.TabIndex = 26
        Me.Label11.Tag = ""
        Me.Label11.Text = "Pagibig:"
        '
        'ELEPITextBox
        '
        Me.ELEPITextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELEPITextBox.Location = New System.Drawing.Point(118, 343)
        Me.ELEPITextBox.MaxLength = 20
        Me.ELEPITextBox.Name = "ELEPITextBox"
        Me.ELEPITextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELEPITextBox.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label8.Location = New System.Drawing.Point(30, 296)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 21)
        Me.Label8.TabIndex = 24
        Me.Label8.Tag = ""
        Me.Label8.Text = "PhilHealth:"
        '
        'ELEPHTextBox
        '
        Me.ELEPHTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELEPHTextBox.Location = New System.Drawing.Point(118, 292)
        Me.ELEPHTextBox.MaxLength = 20
        Me.ELEPHTextBox.Name = "ELEPHTextBox"
        Me.ELEPHTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELEPHTextBox.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label9.Location = New System.Drawing.Point(30, 245)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 21)
        Me.Label9.TabIndex = 22
        Me.Label9.Tag = ""
        Me.Label9.Text = "SSS:"
        '
        'ELESSSTextBox
        '
        Me.ELESSSTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELESSSTextBox.Location = New System.Drawing.Point(118, 241)
        Me.ELESSSTextBox.MaxLength = 20
        Me.ELESSSTextBox.Name = "ELESSSTextBox"
        Me.ELESSSTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELESSSTextBox.TabIndex = 21
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label10.Location = New System.Drawing.Point(30, 194)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 21)
        Me.Label10.TabIndex = 20
        Me.Label10.Tag = ""
        Me.Label10.Text = "TIN:"
        '
        'ELETINTextBox
        '
        Me.ELETINTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELETINTextBox.Location = New System.Drawing.Point(118, 190)
        Me.ELETINTextBox.MaxLength = 20
        Me.ELETINTextBox.Name = "ELETINTextBox"
        Me.ELETINTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELETINTextBox.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(30, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 21)
        Me.Label3.TabIndex = 9
        Me.Label3.Tag = ""
        Me.Label3.Text = "Address:"
        '
        'ELEAddressTextBox
        '
        Me.ELEAddressTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELEAddressTextBox.Location = New System.Drawing.Point(118, 139)
        Me.ELEAddressTextBox.MaxLength = 100
        Me.ELEAddressTextBox.Name = "ELEAddressTextBox"
        Me.ELEAddressTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELEAddressTextBox.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(30, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 21)
        Me.Label2.TabIndex = 7
        Me.Label2.Tag = ""
        Me.Label2.Text = "Age:"
        '
        'ELEAgeTextBox
        '
        Me.ELEAgeTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELEAgeTextBox.Location = New System.Drawing.Point(118, 88)
        Me.ELEAgeTextBox.MaxLength = 3
        Me.ELEAgeTextBox.Name = "ELEAgeTextBox"
        Me.ELEAgeTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELEAgeTextBox.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(30, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 21)
        Me.Label1.TabIndex = 5
        Me.Label1.Tag = ""
        Me.Label1.Text = "Name:"
        '
        'ELENameTextBox
        '
        Me.ELENameTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELENameTextBox.Location = New System.Drawing.Point(118, 37)
        Me.ELENameTextBox.MaxLength = 50
        Me.ELENameTextBox.Name = "ELENameTextBox"
        Me.ELENameTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELENameTextBox.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.ELEEmpIDLabel)
        Me.Panel4.Controls.Add(Me.Label31)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 52)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(736, 80)
        Me.Panel4.TabIndex = 29
        '
        'ELEEmpIDLabel
        '
        Me.ELEEmpIDLabel.AutoSize = True
        Me.ELEEmpIDLabel.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ELEEmpIDLabel.Location = New System.Drawing.Point(246, 18)
        Me.ELEEmpIDLabel.Name = "ELEEmpIDLabel"
        Me.ELEEmpIDLabel.Size = New System.Drawing.Size(102, 37)
        Me.ELEEmpIDLabel.TabIndex = 4
        Me.ELEEmpIDLabel.Tag = ""
        Me.ELEEmpIDLabel.Text = "EmpID"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(27, 18)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(223, 37)
        Me.Label31.TabIndex = 3
        Me.Label31.Tag = ""
        Me.Label31.Text = "EDIT EMPLOYEE:"
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = Global.HRM1.My.Resources.Resources.blue
        Me.Panel11.Controls.Add(Me.ELEAddButton)
        Me.Panel11.Controls.Add(Me.ELEBackButton)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(736, 52)
        Me.Panel11.TabIndex = 0
        '
        'ELEAddButton
        '
        Me.ELEAddButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ELEAddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ELEAddButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ELEAddButton.Location = New System.Drawing.Point(626, 9)
        Me.ELEAddButton.Name = "ELEAddButton"
        Me.ELEAddButton.Size = New System.Drawing.Size(98, 35)
        Me.ELEAddButton.TabIndex = 27
        Me.ELEAddButton.Text = "UPDATE"
        Me.ELEAddButton.UseVisualStyleBackColor = True
        '
        'ELEBackButton
        '
        Me.ELEBackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ELEBackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ELEBackButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ELEBackButton.Location = New System.Drawing.Point(11, 9)
        Me.ELEBackButton.Name = "ELEBackButton"
        Me.ELEBackButton.Size = New System.Drawing.Size(98, 35)
        Me.ELEBackButton.TabIndex = 1
        Me.ELEBackButton.Text = "BACK"
        Me.ELEBackButton.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(111, 9)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(211, 37)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "EMPLOYEE LIST"
        '
        'EmployeeListEditForm
        '
        Me.AcceptButton = Me.ELEAddButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ELEBackButton
        Me.ClientSize = New System.Drawing.Size(736, 545)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(752, 584)
        Me.Name = "EmployeeListEditForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DATAMEX - HRMS: Employee List Edit"
        Me.Panel2.ResumeLayout(False)
        Me.ELEFormPanel.ResumeLayout(False)
        Me.ELEFormPanel.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents ELEFormPanel As Panel
    Friend WithEvents ELEContTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ELEEmailTextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ELEDeptComboBox As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ELEPITextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ELEPHTextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ELESSSTextBox As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ELETINTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ELEAddressTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ELEAgeTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ELENameTextBox As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label31 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents ELEAddButton As Button
    Friend WithEvents ELEBackButton As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ELEEmployeeStatusComboBox As ComboBox
    Friend WithEvents ELEEmpIDLabel As Label
End Class
