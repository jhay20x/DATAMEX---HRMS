<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewPayrollsForm
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
        Me.PayrollBackButton = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PayrollYearDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.PayrollMonthDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PayrollCutOffComboBox = New System.Windows.Forms.ComboBox()
        Me.PayrollTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PayrollDeleteButton = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel11.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = Global.HRM1.My.Resources.Resources.blue
        Me.Panel11.Controls.Add(Me.PayrollBackButton)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(800, 52)
        Me.Panel11.TabIndex = 44
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
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(111, 9)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(146, 37)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "PAYROLLS"
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.Label2)
        Me.Panel17.Controls.Add(Me.PayrollYearDateTimePicker)
        Me.Panel17.Controls.Add(Me.PayrollMonthDateTimePicker)
        Me.Panel17.Controls.Add(Me.Label3)
        Me.Panel17.Controls.Add(Me.PayrollCutOffComboBox)
        Me.Panel17.Controls.Add(Me.PayrollTypeComboBox)
        Me.Panel17.Controls.Add(Me.Label79)
        Me.Panel17.Controls.Add(Me.Label4)
        Me.Panel17.Controls.Add(Me.PayrollDeleteButton)
        Me.Panel17.Controls.Add(Me.Label5)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel17.Location = New System.Drawing.Point(0, 52)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(800, 122)
        Me.Panel17.TabIndex = 58
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(437, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 21)
        Me.Label2.TabIndex = 35
        Me.Label2.Tag = ""
        Me.Label2.Text = "Year:"
        '
        'PayrollYearDateTimePicker
        '
        Me.PayrollYearDateTimePicker.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollYearDateTimePicker.CustomFormat = "yyyy"
        Me.PayrollYearDateTimePicker.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollYearDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PayrollYearDateTimePicker.Location = New System.Drawing.Point(486, 84)
        Me.PayrollYearDateTimePicker.Name = "PayrollYearDateTimePicker"
        Me.PayrollYearDateTimePicker.ShowUpDown = True
        Me.PayrollYearDateTimePicker.Size = New System.Drawing.Size(62, 29)
        Me.PayrollYearDateTimePicker.TabIndex = 34
        Me.PayrollYearDateTimePicker.Value = New Date(2023, 12, 27, 3, 29, 0, 0)
        '
        'PayrollMonthDateTimePicker
        '
        Me.PayrollMonthDateTimePicker.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollMonthDateTimePicker.CustomFormat = "MMMM"
        Me.PayrollMonthDateTimePicker.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollMonthDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PayrollMonthDateTimePicker.Location = New System.Drawing.Point(332, 84)
        Me.PayrollMonthDateTimePicker.Name = "PayrollMonthDateTimePicker"
        Me.PayrollMonthDateTimePicker.ShowUpDown = True
        Me.PayrollMonthDateTimePicker.Size = New System.Drawing.Size(99, 29)
        Me.PayrollMonthDateTimePicker.TabIndex = 33
        Me.PayrollMonthDateTimePicker.Value = New Date(2023, 12, 27, 3, 29, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(267, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 21)
        Me.Label3.TabIndex = 30
        Me.Label3.Tag = ""
        Me.Label3.Text = "Month:"
        '
        'PayrollCutOffComboBox
        '
        Me.PayrollCutOffComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PayrollCutOffComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollCutOffComboBox.FormattingEnabled = True
        Me.PayrollCutOffComboBox.Items.AddRange(New Object() {"1-15", "16-30/31"})
        Me.PayrollCutOffComboBox.Location = New System.Drawing.Point(125, 84)
        Me.PayrollCutOffComboBox.Name = "PayrollCutOffComboBox"
        Me.PayrollCutOffComboBox.Size = New System.Drawing.Size(136, 29)
        Me.PayrollCutOffComboBox.TabIndex = 28
        '
        'PayrollTypeComboBox
        '
        Me.PayrollTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PayrollTypeComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollTypeComboBox.FormattingEnabled = True
        Me.PayrollTypeComboBox.Items.AddRange(New Object() {"Semi-Monthly", "Monthly"})
        Me.PayrollTypeComboBox.Location = New System.Drawing.Point(111, 49)
        Me.PayrollTypeComboBox.Name = "PayrollTypeComboBox"
        Me.PayrollTypeComboBox.Size = New System.Drawing.Size(136, 29)
        Me.PayrollTypeComboBox.TabIndex = 27
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.Location = New System.Drawing.Point(6, 8)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(243, 37)
        Me.Label79.TabIndex = 26
        Me.Label79.Tag = ""
        Me.Label79.Text = "PAYROLL DETAILS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 21)
        Me.Label4.TabIndex = 20
        Me.Label4.Tag = ""
        Me.Label4.Text = "Payroll Type:"
        '
        'PayrollDeleteButton
        '
        Me.PayrollDeleteButton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayrollDeleteButton.Location = New System.Drawing.Point(554, 83)
        Me.PayrollDeleteButton.Name = "PayrollDeleteButton"
        Me.PayrollDeleteButton.Size = New System.Drawing.Size(110, 29)
        Me.PayrollDeleteButton.TabIndex = 16
        Me.PayrollDeleteButton.Text = "Remove Record"
        Me.PayrollDeleteButton.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 21)
        Me.Label5.TabIndex = 15
        Me.Label5.Tag = ""
        Me.Label5.Text = "Payroll CutOff:"
        '
        'ViewPayrollsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel17)
        Me.Controls.Add(Me.Panel11)
        Me.Name = "ViewPayrollsForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Payrolls"
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel11 As Panel
    Friend WithEvents PayrollBackButton As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PayrollYearDateTimePicker As DateTimePicker
    Friend WithEvents PayrollMonthDateTimePicker As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents PayrollCutOffComboBox As ComboBox
    Friend WithEvents PayrollTypeComboBox As ComboBox
    Friend WithEvents Label79 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PayrollDeleteButton As Button
    Friend WithEvents Label5 As Label
End Class
