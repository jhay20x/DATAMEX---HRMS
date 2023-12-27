<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LeaveRequestViewForm
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
        Me.LRBackButton = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LRApproveButton = New System.Windows.Forms.Button()
        Me.LRRejectButton = New System.Windows.Forms.Button()
        Me.LREmpIDLabel = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.LRFormPanel = New System.Windows.Forms.Panel()
        Me.LRStatusLabel = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LRReasonLabel = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LRDepartmentLabel = New System.Windows.Forms.Label()
        Me.LREmployeeNameLabel = New System.Windows.Forms.Label()
        Me.LRDurationLabel = New System.Windows.Forms.Label()
        Me.LRDateToLabel = New System.Windows.Forms.Label()
        Me.LRDateFromLabel = New System.Windows.Forms.Label()
        Me.LRDateFiledLabel = New System.Windows.Forms.Label()
        Me.LRLeaveTypeLabel = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel11.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.LRFormPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = Global.HRM1.My.Resources.Resources.blue
        Me.Panel11.Controls.Add(Me.LRBackButton)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(765, 52)
        Me.Panel11.TabIndex = 1
        '
        'LRBackButton
        '
        Me.LRBackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LRBackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.LRBackButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LRBackButton.Location = New System.Drawing.Point(11, 9)
        Me.LRBackButton.Name = "LRBackButton"
        Me.LRBackButton.Size = New System.Drawing.Size(98, 35)
        Me.LRBackButton.TabIndex = 1
        Me.LRBackButton.Text = "BACK"
        Me.LRBackButton.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(111, 9)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(219, 37)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "LEAVE REQUEST"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.LRApproveButton)
        Me.Panel4.Controls.Add(Me.LRRejectButton)
        Me.Panel4.Controls.Add(Me.LREmpIDLabel)
        Me.Panel4.Controls.Add(Me.Label31)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 52)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(765, 80)
        Me.Panel4.TabIndex = 30
        '
        'LRApproveButton
        '
        Me.LRApproveButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LRApproveButton.Location = New System.Drawing.Point(573, 26)
        Me.LRApproveButton.Name = "LRApproveButton"
        Me.LRApproveButton.Size = New System.Drawing.Size(87, 31)
        Me.LRApproveButton.TabIndex = 24
        Me.LRApproveButton.Text = "Approve"
        Me.LRApproveButton.UseVisualStyleBackColor = True
        '
        'LRRejectButton
        '
        Me.LRRejectButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LRRejectButton.Location = New System.Drawing.Point(666, 26)
        Me.LRRejectButton.Name = "LRRejectButton"
        Me.LRRejectButton.Size = New System.Drawing.Size(87, 31)
        Me.LRRejectButton.TabIndex = 23
        Me.LRRejectButton.Text = "Reject"
        Me.LRRejectButton.UseVisualStyleBackColor = True
        '
        'LREmpIDLabel
        '
        Me.LREmpIDLabel.AutoSize = True
        Me.LREmpIDLabel.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LREmpIDLabel.Location = New System.Drawing.Point(226, 18)
        Me.LREmpIDLabel.Name = "LREmpIDLabel"
        Me.LREmpIDLabel.Size = New System.Drawing.Size(0, 37)
        Me.LREmpIDLabel.TabIndex = 4
        Me.LREmpIDLabel.Tag = ""
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(27, 20)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(193, 37)
        Me.Label31.TabIndex = 3
        Me.Label31.Tag = ""
        Me.Label31.Text = "EMPLOYEE ID:"
        '
        'LRFormPanel
        '
        Me.LRFormPanel.Controls.Add(Me.LRStatusLabel)
        Me.LRFormPanel.Controls.Add(Me.Label9)
        Me.LRFormPanel.Controls.Add(Me.LRReasonLabel)
        Me.LRFormPanel.Controls.Add(Me.Label15)
        Me.LRFormPanel.Controls.Add(Me.LRDepartmentLabel)
        Me.LRFormPanel.Controls.Add(Me.LREmployeeNameLabel)
        Me.LRFormPanel.Controls.Add(Me.LRDurationLabel)
        Me.LRFormPanel.Controls.Add(Me.LRDateToLabel)
        Me.LRFormPanel.Controls.Add(Me.LRDateFromLabel)
        Me.LRFormPanel.Controls.Add(Me.LRDateFiledLabel)
        Me.LRFormPanel.Controls.Add(Me.LRLeaveTypeLabel)
        Me.LRFormPanel.Controls.Add(Me.Label7)
        Me.LRFormPanel.Controls.Add(Me.Label6)
        Me.LRFormPanel.Controls.Add(Me.Label5)
        Me.LRFormPanel.Controls.Add(Me.Label4)
        Me.LRFormPanel.Controls.Add(Me.Label3)
        Me.LRFormPanel.Controls.Add(Me.Label2)
        Me.LRFormPanel.Controls.Add(Me.Label1)
        Me.LRFormPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LRFormPanel.Location = New System.Drawing.Point(0, 132)
        Me.LRFormPanel.Name = "LRFormPanel"
        Me.LRFormPanel.Size = New System.Drawing.Size(765, 236)
        Me.LRFormPanel.TabIndex = 31
        '
        'LRStatusLabel
        '
        Me.LRStatusLabel.AutoSize = True
        Me.LRStatusLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LRStatusLabel.Location = New System.Drawing.Point(376, 50)
        Me.LRStatusLabel.Name = "LRStatusLabel"
        Me.LRStatusLabel.Size = New System.Drawing.Size(55, 21)
        Me.LRStatusLabel.TabIndex = 25
        Me.LRStatusLabel.Tag = ""
        Me.LRStatusLabel.Text = "Status:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(315, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 21)
        Me.Label9.TabIndex = 24
        Me.Label9.Tag = ""
        Me.Label9.Text = "Status:"
        '
        'LRReasonLabel
        '
        Me.LRReasonLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LRReasonLabel.Location = New System.Drawing.Point(315, 108)
        Me.LRReasonLabel.Name = "LRReasonLabel"
        Me.LRReasonLabel.Size = New System.Drawing.Size(430, 108)
        Me.LRReasonLabel.TabIndex = 20
        Me.LRReasonLabel.Tag = ""
        Me.LRReasonLabel.Text = "Lorem Ipsum"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label15.Location = New System.Drawing.Point(315, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 21)
        Me.Label15.TabIndex = 19
        Me.Label15.Tag = ""
        Me.Label15.Text = "Reason:"
        '
        'LRDepartmentLabel
        '
        Me.LRDepartmentLabel.AutoSize = True
        Me.LRDepartmentLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LRDepartmentLabel.Location = New System.Drawing.Point(153, 50)
        Me.LRDepartmentLabel.Name = "LRDepartmentLabel"
        Me.LRDepartmentLabel.Size = New System.Drawing.Size(96, 21)
        Me.LRDepartmentLabel.TabIndex = 18
        Me.LRDepartmentLabel.Tag = ""
        Me.LRDepartmentLabel.Text = "Department:"
        '
        'LREmployeeNameLabel
        '
        Me.LREmployeeNameLabel.AutoSize = True
        Me.LREmployeeNameLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LREmployeeNameLabel.Location = New System.Drawing.Point(153, 21)
        Me.LREmployeeNameLabel.Name = "LREmployeeNameLabel"
        Me.LREmployeeNameLabel.Size = New System.Drawing.Size(127, 21)
        Me.LREmployeeNameLabel.TabIndex = 17
        Me.LREmployeeNameLabel.Tag = ""
        Me.LREmployeeNameLabel.Text = "Employee Name:"
        '
        'LRDurationLabel
        '
        Me.LRDurationLabel.AutoSize = True
        Me.LRDurationLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LRDurationLabel.Location = New System.Drawing.Point(153, 195)
        Me.LRDurationLabel.Name = "LRDurationLabel"
        Me.LRDurationLabel.Size = New System.Drawing.Size(74, 21)
        Me.LRDurationLabel.TabIndex = 16
        Me.LRDurationLabel.Tag = ""
        Me.LRDurationLabel.Text = "Duration:"
        '
        'LRDateToLabel
        '
        Me.LRDateToLabel.AutoSize = True
        Me.LRDateToLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LRDateToLabel.Location = New System.Drawing.Point(153, 166)
        Me.LRDateToLabel.Name = "LRDateToLabel"
        Me.LRDateToLabel.Size = New System.Drawing.Size(64, 21)
        Me.LRDateToLabel.TabIndex = 15
        Me.LRDateToLabel.Tag = ""
        Me.LRDateToLabel.Text = "Date To:"
        '
        'LRDateFromLabel
        '
        Me.LRDateFromLabel.AutoSize = True
        Me.LRDateFromLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LRDateFromLabel.Location = New System.Drawing.Point(153, 137)
        Me.LRDateFromLabel.Name = "LRDateFromLabel"
        Me.LRDateFromLabel.Size = New System.Drawing.Size(86, 21)
        Me.LRDateFromLabel.TabIndex = 14
        Me.LRDateFromLabel.Tag = ""
        Me.LRDateFromLabel.Text = "Date From:"
        '
        'LRDateFiledLabel
        '
        Me.LRDateFiledLabel.AutoSize = True
        Me.LRDateFiledLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LRDateFiledLabel.Location = New System.Drawing.Point(153, 108)
        Me.LRDateFiledLabel.Name = "LRDateFiledLabel"
        Me.LRDateFiledLabel.Size = New System.Drawing.Size(82, 21)
        Me.LRDateFiledLabel.TabIndex = 13
        Me.LRDateFiledLabel.Tag = ""
        Me.LRDateFiledLabel.Text = "Date Filed:"
        '
        'LRLeaveTypeLabel
        '
        Me.LRLeaveTypeLabel.AutoSize = True
        Me.LRLeaveTypeLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LRLeaveTypeLabel.Location = New System.Drawing.Point(153, 79)
        Me.LRLeaveTypeLabel.Name = "LRLeaveTypeLabel"
        Me.LRLeaveTypeLabel.Size = New System.Drawing.Size(89, 21)
        Me.LRLeaveTypeLabel.TabIndex = 12
        Me.LRLeaveTypeLabel.Tag = ""
        Me.LRLeaveTypeLabel.Text = "Leave Type:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(51, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 21)
        Me.Label7.TabIndex = 11
        Me.Label7.Tag = ""
        Me.Label7.Text = "Department:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(20, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 21)
        Me.Label6.TabIndex = 10
        Me.Label6.Tag = ""
        Me.Label6.Text = "Employee Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(73, 195)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 21)
        Me.Label5.TabIndex = 9
        Me.Label5.Tag = ""
        Me.Label5.Text = "Duration:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(83, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 21)
        Me.Label4.TabIndex = 8
        Me.Label4.Tag = ""
        Me.Label4.Text = "Date To:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(61, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 21)
        Me.Label3.TabIndex = 7
        Me.Label3.Tag = ""
        Me.Label3.Text = "Date From:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(65, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 21)
        Me.Label2.TabIndex = 6
        Me.Label2.Tag = ""
        Me.Label2.Text = "Date Filed:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(58, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 21)
        Me.Label1.TabIndex = 5
        Me.Label1.Tag = ""
        Me.Label1.Text = "Leave Type:"
        '
        'LeaveRequestViewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(765, 368)
        Me.Controls.Add(Me.LRFormPanel)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel11)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(781, 584)
        Me.MinimizeBox = False
        Me.Name = "LeaveRequestViewForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Leave Request"
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.LRFormPanel.ResumeLayout(False)
        Me.LRFormPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel11 As Panel
    Friend WithEvents LRBackButton As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label31 As Label
    Friend WithEvents LRFormPanel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LREmpIDLabel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LRDepartmentLabel As Label
    Friend WithEvents LREmployeeNameLabel As Label
    Friend WithEvents LRDurationLabel As Label
    Friend WithEvents LRDateToLabel As Label
    Friend WithEvents LRDateFromLabel As Label
    Friend WithEvents LRDateFiledLabel As Label
    Friend WithEvents LRLeaveTypeLabel As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LRReasonLabel As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents LRRejectButton As Button
    Friend WithEvents LRStatusLabel As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LRApproveButton As Button
End Class
