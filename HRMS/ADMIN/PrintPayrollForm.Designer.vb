<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintPayrollForm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PayrollEmpIDLabel = New System.Windows.Forms.Label()
        Me.PayrollPrintButton = New System.Windows.Forms.Button()
        Me.PayrollCutOffComboBox = New System.Windows.Forms.ComboBox()
        Me.PayrollTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.PayrollEmpNameComboBox = New System.Windows.Forms.ComboBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.PayrollMonthDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.PayrollYearDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.PayrollBackButton = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PayrollEmpIDLabel)
        Me.Panel1.Controls.Add(Me.PayrollPrintButton)
        Me.Panel1.Controls.Add(Me.PayrollCutOffComboBox)
        Me.Panel1.Controls.Add(Me.PayrollTypeComboBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label71)
        Me.Panel1.Controls.Add(Me.PayrollEmpNameComboBox)
        Me.Panel1.Controls.Add(Me.Label78)
        Me.Panel1.Controls.Add(Me.Label79)
        Me.Panel1.Controls.Add(Me.Label69)
        Me.Panel1.Controls.Add(Me.PayrollMonthDateTimePicker)
        Me.Panel1.Controls.Add(Me.Label72)
        Me.Panel1.Controls.Add(Me.PayrollYearDateTimePicker)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(481, 211)
        Me.Panel1.TabIndex = 44
        '
        'PayrollEmpIDLabel
        '
        Me.PayrollEmpIDLabel.AutoSize = True
        Me.PayrollEmpIDLabel.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollEmpIDLabel.Location = New System.Drawing.Point(227, 8)
        Me.PayrollEmpIDLabel.Name = "PayrollEmpIDLabel"
        Me.PayrollEmpIDLabel.Size = New System.Drawing.Size(0, 37)
        Me.PayrollEmpIDLabel.TabIndex = 49
        Me.PayrollEmpIDLabel.Tag = ""
        '
        'PayrollPrintButton
        '
        Me.PayrollPrintButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollPrintButton.Location = New System.Drawing.Point(363, 165)
        Me.PayrollPrintButton.Name = "PayrollPrintButton"
        Me.PayrollPrintButton.Size = New System.Drawing.Size(98, 29)
        Me.PayrollPrintButton.TabIndex = 48
        Me.PayrollPrintButton.Text = "Print"
        Me.PayrollPrintButton.UseVisualStyleBackColor = True
        '
        'PayrollCutOffComboBox
        '
        Me.PayrollCutOffComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PayrollCutOffComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollCutOffComboBox.FormattingEnabled = True
        Me.PayrollCutOffComboBox.Items.AddRange(New Object() {"1-15", "16-30/31"})
        Me.PayrollCutOffComboBox.Location = New System.Drawing.Point(141, 129)
        Me.PayrollCutOffComboBox.Name = "PayrollCutOffComboBox"
        Me.PayrollCutOffComboBox.Size = New System.Drawing.Size(136, 29)
        Me.PayrollCutOffComboBox.TabIndex = 47
        '
        'PayrollTypeComboBox
        '
        Me.PayrollTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PayrollTypeComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollTypeComboBox.FormattingEnabled = True
        Me.PayrollTypeComboBox.Items.AddRange(New Object() {"Semi-Monthly", "Monthly"})
        Me.PayrollTypeComboBox.Location = New System.Drawing.Point(141, 92)
        Me.PayrollTypeComboBox.Name = "PayrollTypeComboBox"
        Me.PayrollTypeComboBox.Size = New System.Drawing.Size(136, 29)
        Me.PayrollTypeComboBox.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 21)
        Me.Label1.TabIndex = 45
        Me.Label1.Tag = ""
        Me.Label1.Text = "Payroll Type:"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(25, 132)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(110, 21)
        Me.Label71.TabIndex = 44
        Me.Label71.Tag = ""
        Me.Label71.Text = "Payroll CutOff:"
        '
        'PayrollEmpNameComboBox
        '
        Me.PayrollEmpNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PayrollEmpNameComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollEmpNameComboBox.FormattingEnabled = True
        Me.PayrollEmpNameComboBox.Items.AddRange(New Object() {"Semi-Monthly", "Monthly"})
        Me.PayrollEmpNameComboBox.Location = New System.Drawing.Point(141, 55)
        Me.PayrollEmpNameComboBox.Name = "PayrollEmpNameComboBox"
        Me.PayrollEmpNameComboBox.Size = New System.Drawing.Size(210, 29)
        Me.PayrollEmpNameComboBox.TabIndex = 43
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.Location = New System.Drawing.Point(8, 58)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(127, 21)
        Me.Label78.TabIndex = 42
        Me.Label78.Tag = ""
        Me.Label78.Text = "Employee Name:"
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.Location = New System.Drawing.Point(6, 8)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(215, 37)
        Me.Label79.TabIndex = 41
        Me.Label79.Tag = ""
        Me.Label79.Text = "PRINT PAYSLIP:"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(76, 169)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(59, 21)
        Me.Label69.TabIndex = 36
        Me.Label69.Tag = ""
        Me.Label69.Text = "Month:"
        '
        'PayrollMonthDateTimePicker
        '
        Me.PayrollMonthDateTimePicker.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollMonthDateTimePicker.CustomFormat = "MMMM"
        Me.PayrollMonthDateTimePicker.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollMonthDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PayrollMonthDateTimePicker.Location = New System.Drawing.Point(141, 164)
        Me.PayrollMonthDateTimePicker.Name = "PayrollMonthDateTimePicker"
        Me.PayrollMonthDateTimePicker.ShowUpDown = True
        Me.PayrollMonthDateTimePicker.Size = New System.Drawing.Size(99, 29)
        Me.PayrollMonthDateTimePicker.TabIndex = 37
        Me.PayrollMonthDateTimePicker.Value = New Date(2023, 12, 27, 3, 29, 0, 0)
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(246, 168)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(43, 21)
        Me.Label72.TabIndex = 39
        Me.Label72.Tag = ""
        Me.Label72.Text = "Year:"
        '
        'PayrollYearDateTimePicker
        '
        Me.PayrollYearDateTimePicker.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollYearDateTimePicker.CustomFormat = "yyyy"
        Me.PayrollYearDateTimePicker.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollYearDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PayrollYearDateTimePicker.Location = New System.Drawing.Point(295, 164)
        Me.PayrollYearDateTimePicker.Name = "PayrollYearDateTimePicker"
        Me.PayrollYearDateTimePicker.ShowUpDown = True
        Me.PayrollYearDateTimePicker.Size = New System.Drawing.Size(62, 29)
        Me.PayrollYearDateTimePicker.TabIndex = 38
        Me.PayrollYearDateTimePicker.Value = New Date(2023, 12, 27, 3, 29, 0, 0)
        '
        'PayrollBackButton
        '
        Me.PayrollBackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PayrollBackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.PayrollBackButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollBackButton.Location = New System.Drawing.Point(11, 9)
        Me.PayrollBackButton.Name = "PayrollBackButton"
        Me.PayrollBackButton.Size = New System.Drawing.Size(98, 35)
        Me.PayrollBackButton.TabIndex = 1
        Me.PayrollBackButton.Text = "BACK"
        Me.PayrollBackButton.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = Global.HRM1.My.Resources.Resources.blue
        Me.Panel11.Controls.Add(Me.PayrollBackButton)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(481, 52)
        Me.Panel11.TabIndex = 43
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(111, 9)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(120, 37)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "PAYSLIP"
        '
        'PrintPayrollForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.PayrollBackButton
        Me.ClientSize = New System.Drawing.Size(481, 263)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel11)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PrintPayrollForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Payroll"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PayrollCutOffComboBox As ComboBox
    Friend WithEvents PayrollTypeComboBox As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label71 As Label
    Friend WithEvents PayrollEmpNameComboBox As ComboBox
    Friend WithEvents Label78 As Label
    Friend WithEvents Label79 As Label
    Friend WithEvents Label69 As Label
    Friend WithEvents PayrollMonthDateTimePicker As DateTimePicker
    Friend WithEvents Label72 As Label
    Friend WithEvents PayrollYearDateTimePicker As DateTimePicker
    Friend WithEvents Panel11 As Panel
    Friend WithEvents PayrollBackButton As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents PayrollPrintButton As Button
    Friend WithEvents PayrollEmpIDLabel As Label
End Class
