<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeListAddForm
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
        Me.ELAAddButton = New System.Windows.Forms.Button()
        Me.ELABackButton = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.ELAFormPanel = New System.Windows.Forms.Panel()
        Me.ClearPhotoButton = New System.Windows.Forms.Button()
        Me.IDPhotoPictureBox = New System.Windows.Forms.PictureBox()
        Me.OpenPhotoButton = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ELAAddressTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ELAAgeTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ELAMiddleNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ELAFirstNameTextBox = New System.Windows.Forms.TextBox()
        Me.ELAContTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ELAEmailTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ELADeptComboBox = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ELAPITextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ELAPHTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ELASSSTextBox = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ELATINTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ELALastNameTextBox = New System.Windows.Forms.TextBox()
        Me.ELAMiddleNameCheckBox = New System.Windows.Forms.CheckBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel11.SuspendLayout()
        Me.ELAFormPanel.SuspendLayout()
        CType(Me.IDPhotoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = Global.HRM1.My.Resources.Resources.blue
        Me.Panel11.Controls.Add(Me.ELAAddButton)
        Me.Panel11.Controls.Add(Me.ELABackButton)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(765, 52)
        Me.Panel11.TabIndex = 0
        '
        'ELAAddButton
        '
        Me.ELAAddButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ELAAddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ELAAddButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ELAAddButton.Location = New System.Drawing.Point(655, 9)
        Me.ELAAddButton.Name = "ELAAddButton"
        Me.ELAAddButton.Size = New System.Drawing.Size(98, 35)
        Me.ELAAddButton.TabIndex = 0
        Me.ELAAddButton.Text = "ADD"
        Me.ELAAddButton.UseVisualStyleBackColor = True
        '
        'ELABackButton
        '
        Me.ELABackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ELABackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ELABackButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ELABackButton.Location = New System.Drawing.Point(11, 9)
        Me.ELABackButton.Name = "ELABackButton"
        Me.ELABackButton.Size = New System.Drawing.Size(98, 35)
        Me.ELABackButton.TabIndex = 1
        Me.ELABackButton.Text = "BACK"
        Me.ELABackButton.UseVisualStyleBackColor = True
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
        'ELAFormPanel
        '
        Me.ELAFormPanel.Controls.Add(Me.ClearPhotoButton)
        Me.ELAFormPanel.Controls.Add(Me.IDPhotoPictureBox)
        Me.ELAFormPanel.Controls.Add(Me.OpenPhotoButton)
        Me.ELAFormPanel.Controls.Add(Me.Label13)
        Me.ELAFormPanel.Controls.Add(Me.Label3)
        Me.ELAFormPanel.Controls.Add(Me.ELAAddressTextBox)
        Me.ELAFormPanel.Controls.Add(Me.Label2)
        Me.ELAFormPanel.Controls.Add(Me.ELAAgeTextBox)
        Me.ELAFormPanel.Controls.Add(Me.Label7)
        Me.ELAFormPanel.Controls.Add(Me.ELAMiddleNameTextBox)
        Me.ELAFormPanel.Controls.Add(Me.Label12)
        Me.ELAFormPanel.Controls.Add(Me.ELAFirstNameTextBox)
        Me.ELAFormPanel.Controls.Add(Me.ELAContTextBox)
        Me.ELAFormPanel.Controls.Add(Me.Label4)
        Me.ELAFormPanel.Controls.Add(Me.ELAEmailTextBox)
        Me.ELAFormPanel.Controls.Add(Me.Label5)
        Me.ELAFormPanel.Controls.Add(Me.Label6)
        Me.ELAFormPanel.Controls.Add(Me.ELADeptComboBox)
        Me.ELAFormPanel.Controls.Add(Me.Label11)
        Me.ELAFormPanel.Controls.Add(Me.ELAPITextBox)
        Me.ELAFormPanel.Controls.Add(Me.Label8)
        Me.ELAFormPanel.Controls.Add(Me.ELAPHTextBox)
        Me.ELAFormPanel.Controls.Add(Me.Label9)
        Me.ELAFormPanel.Controls.Add(Me.ELASSSTextBox)
        Me.ELAFormPanel.Controls.Add(Me.Label10)
        Me.ELAFormPanel.Controls.Add(Me.ELATINTextBox)
        Me.ELAFormPanel.Controls.Add(Me.Label1)
        Me.ELAFormPanel.Controls.Add(Me.ELALastNameTextBox)
        Me.ELAFormPanel.Controls.Add(Me.ELAMiddleNameCheckBox)
        Me.ELAFormPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ELAFormPanel.Location = New System.Drawing.Point(0, 132)
        Me.ELAFormPanel.Name = "ELAFormPanel"
        Me.ELAFormPanel.Size = New System.Drawing.Size(765, 440)
        Me.ELAFormPanel.TabIndex = 8
        '
        'ClearPhotoButton
        '
        Me.ClearPhotoButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearPhotoButton.Location = New System.Drawing.Point(474, 350)
        Me.ClearPhotoButton.Name = "ClearPhotoButton"
        Me.ClearPhotoButton.Size = New System.Drawing.Size(61, 24)
        Me.ClearPhotoButton.TabIndex = 105
        Me.ClearPhotoButton.Text = "Clear"
        Me.ClearPhotoButton.UseVisualStyleBackColor = True
        '
        'IDPhotoPictureBox
        '
        Me.IDPhotoPictureBox.BackColor = System.Drawing.Color.Gray
        Me.IDPhotoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.IDPhotoPictureBox.Location = New System.Drawing.Point(545, 292)
        Me.IDPhotoPictureBox.Name = "IDPhotoPictureBox"
        Me.IDPhotoPictureBox.Size = New System.Drawing.Size(130, 130)
        Me.IDPhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IDPhotoPictureBox.TabIndex = 104
        Me.IDPhotoPictureBox.TabStop = False
        '
        'OpenPhotoButton
        '
        Me.OpenPhotoButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenPhotoButton.Location = New System.Drawing.Point(474, 320)
        Me.OpenPhotoButton.Name = "OpenPhotoButton"
        Me.OpenPhotoButton.Size = New System.Drawing.Size(61, 24)
        Me.OpenPhotoButton.TabIndex = 103
        Me.OpenPhotoButton.Text = "Open"
        Me.OpenPhotoButton.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label13.Location = New System.Drawing.Point(478, 296)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 21)
        Me.Label13.TabIndex = 43
        Me.Label13.Tag = ""
        Me.Label13.Text = "Picture:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(470, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 21)
        Me.Label3.TabIndex = 42
        Me.Label3.Tag = ""
        Me.Label3.Text = "Address:"
        '
        'ELAAddressTextBox
        '
        Me.ELAAddressTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELAAddressTextBox.Location = New System.Drawing.Point(545, 88)
        Me.ELAAddressTextBox.MaxLength = 100
        Me.ELAAddressTextBox.Name = "ELAAddressTextBox"
        Me.ELAAddressTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELAAddressTextBox.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(499, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 21)
        Me.Label2.TabIndex = 40
        Me.Label2.Tag = ""
        Me.Label2.Text = "Age:"
        '
        'ELAAgeTextBox
        '
        Me.ELAAgeTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELAAgeTextBox.Location = New System.Drawing.Point(545, 37)
        Me.ELAAgeTextBox.MaxLength = 3
        Me.ELAAgeTextBox.Name = "ELAAgeTextBox"
        Me.ELAAgeTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELAAgeTextBox.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(28, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 21)
        Me.Label7.TabIndex = 38
        Me.Label7.Tag = ""
        Me.Label7.Text = "Middle Name:"
        '
        'ELAMiddleNameTextBox
        '
        Me.ELAMiddleNameTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELAMiddleNameTextBox.Location = New System.Drawing.Point(141, 139)
        Me.ELAMiddleNameTextBox.MaxLength = 50
        Me.ELAMiddleNameTextBox.Name = "ELAMiddleNameTextBox"
        Me.ELAMiddleNameTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELAMiddleNameTextBox.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label12.Location = New System.Drawing.Point(46, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 21)
        Me.Label12.TabIndex = 36
        Me.Label12.Tag = ""
        Me.Label12.Text = "First Name:"
        '
        'ELAFirstNameTextBox
        '
        Me.ELAFirstNameTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELAFirstNameTextBox.Location = New System.Drawing.Point(141, 88)
        Me.ELAFirstNameTextBox.MaxLength = 50
        Me.ELAFirstNameTextBox.Name = "ELAFirstNameTextBox"
        Me.ELAFirstNameTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELAFirstNameTextBox.TabIndex = 1
        '
        'ELAContTextBox
        '
        Me.ELAContTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELAContTextBox.Location = New System.Drawing.Point(545, 139)
        Me.ELAContTextBox.MaxLength = 11
        Me.ELAContTextBox.Name = "ELAContTextBox"
        Me.ELAContTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELAContTextBox.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(411, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 21)
        Me.Label4.TabIndex = 28
        Me.Label4.Tag = ""
        Me.Label4.Text = "Contact Number:"
        '
        'ELAEmailTextBox
        '
        Me.ELAEmailTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELAEmailTextBox.Location = New System.Drawing.Point(545, 190)
        Me.ELAEmailTextBox.MaxLength = 30
        Me.ELAEmailTextBox.Name = "ELAEmailTextBox"
        Me.ELAEmailTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELAEmailTextBox.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(428, 194)
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
        Me.Label6.Location = New System.Drawing.Point(443, 245)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 21)
        Me.Label6.TabIndex = 31
        Me.Label6.Tag = ""
        Me.Label6.Text = "Department:"
        '
        'ELADeptComboBox
        '
        Me.ELADeptComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ELADeptComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ELADeptComboBox.FormattingEnabled = True
        Me.ELADeptComboBox.Items.AddRange(New Object() {"1 - HM", "2 - IT", "3 - TM", "4 - History", "5 - English", "6 - Math", "7 - PE", "8 - Science", "9 - Values"})
        Me.ELADeptComboBox.Location = New System.Drawing.Point(545, 241)
        Me.ELADeptComboBox.Name = "ELADeptComboBox"
        Me.ELADeptComboBox.Size = New System.Drawing.Size(181, 29)
        Me.ELADeptComboBox.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label11.Location = New System.Drawing.Point(71, 347)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 21)
        Me.Label11.TabIndex = 26
        Me.Label11.Tag = ""
        Me.Label11.Text = "Pagibig:"
        '
        'ELAPITextBox
        '
        Me.ELAPITextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELAPITextBox.Location = New System.Drawing.Point(141, 343)
        Me.ELAPITextBox.MaxLength = 12
        Me.ELAPITextBox.Name = "ELAPITextBox"
        Me.ELAPITextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELAPITextBox.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label8.Location = New System.Drawing.Point(51, 296)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 21)
        Me.Label8.TabIndex = 24
        Me.Label8.Tag = ""
        Me.Label8.Text = "PhilHealth:"
        '
        'ELAPHTextBox
        '
        Me.ELAPHTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELAPHTextBox.Location = New System.Drawing.Point(141, 292)
        Me.ELAPHTextBox.MaxLength = 12
        Me.ELAPHTextBox.Name = "ELAPHTextBox"
        Me.ELAPHTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELAPHTextBox.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label9.Location = New System.Drawing.Point(95, 245)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 21)
        Me.Label9.TabIndex = 22
        Me.Label9.Tag = ""
        Me.Label9.Text = "SSS:"
        '
        'ELASSSTextBox
        '
        Me.ELASSSTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELASSSTextBox.Location = New System.Drawing.Point(141, 241)
        Me.ELASSSTextBox.MaxLength = 10
        Me.ELASSSTextBox.Name = "ELASSSTextBox"
        Me.ELASSSTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELASSSTextBox.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label10.Location = New System.Drawing.Point(98, 194)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 21)
        Me.Label10.TabIndex = 20
        Me.Label10.Tag = ""
        Me.Label10.Text = "TIN:"
        '
        'ELATINTextBox
        '
        Me.ELATINTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELATINTextBox.Location = New System.Drawing.Point(141, 190)
        Me.ELATINTextBox.MaxLength = 12
        Me.ELATINTextBox.Name = "ELATINTextBox"
        Me.ELATINTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELATINTextBox.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(48, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 21)
        Me.Label1.TabIndex = 5
        Me.Label1.Tag = ""
        Me.Label1.Text = "Last Name:"
        '
        'ELALastNameTextBox
        '
        Me.ELALastNameTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ELALastNameTextBox.Location = New System.Drawing.Point(141, 37)
        Me.ELALastNameTextBox.MaxLength = 50
        Me.ELALastNameTextBox.Name = "ELALastNameTextBox"
        Me.ELALastNameTextBox.Size = New System.Drawing.Size(181, 29)
        Me.ELALastNameTextBox.TabIndex = 0
        '
        'ELAMiddleNameCheckBox
        '
        Me.ELAMiddleNameCheckBox.AutoSize = True
        Me.ELAMiddleNameCheckBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ELAMiddleNameCheckBox.Location = New System.Drawing.Point(328, 141)
        Me.ELAMiddleNameCheckBox.Name = "ELAMiddleNameCheckBox"
        Me.ELAMiddleNameCheckBox.Size = New System.Drawing.Size(57, 25)
        Me.ELAMiddleNameCheckBox.TabIndex = 3
        Me.ELAMiddleNameCheckBox.Text = "N/A"
        Me.ELAMiddleNameCheckBox.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label31)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 52)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(765, 80)
        Me.Panel4.TabIndex = 29
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
        Me.Label31.Text = "ADD EMPLOYEE:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.ELAFormPanel)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel11)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(765, 572)
        Me.Panel2.TabIndex = 11
        '
        'EmployeeListAddForm
        '
        Me.AcceptButton = Me.ELAAddButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ELABackButton
        Me.ClientSize = New System.Drawing.Size(765, 572)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(781, 611)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(781, 611)
        Me.Name = "EmployeeListAddForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DATAMEX - HRMS: Employee List Add"
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.ELAFormPanel.ResumeLayout(False)
        Me.ELAFormPanel.PerformLayout()
        CType(Me.IDPhotoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel11 As Panel
    Friend WithEvents ELABackButton As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents ELAFormPanel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents ELALastNameTextBox As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ELAAddButton As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents ELAPITextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ELAPHTextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ELASSSTextBox As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ELATINTextBox As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents ELAContTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ELAEmailTextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ELADeptComboBox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ELAAddressTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ELAAgeTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ELAMiddleNameTextBox As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents ELAFirstNameTextBox As TextBox
    Friend WithEvents ELAMiddleNameCheckBox As CheckBox
    Friend WithEvents Label13 As Label
    Friend WithEvents OpenPhotoButton As Button
    Friend WithEvents IDPhotoPictureBox As PictureBox
    Friend WithEvents ClearPhotoButton As Button
End Class
