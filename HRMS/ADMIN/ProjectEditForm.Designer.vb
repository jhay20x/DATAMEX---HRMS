<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProjectEditForm
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
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.PJAddButton = New System.Windows.Forms.Button()
        Me.PJBackButton = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PJDescTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PJDateEndDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PJEmployeeNamesComboBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PJNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PJDateStartDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.PJStatusComboBox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel11.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = Global.HRM1.My.Resources.Resources.blue
        Me.Panel11.Controls.Add(Me.PJAddButton)
        Me.Panel11.Controls.Add(Me.PJBackButton)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(472, 52)
        Me.Panel11.TabIndex = 28
        '
        'PJAddButton
        '
        Me.PJAddButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PJAddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PJAddButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PJAddButton.Location = New System.Drawing.Point(362, 9)
        Me.PJAddButton.Name = "PJAddButton"
        Me.PJAddButton.Size = New System.Drawing.Size(98, 35)
        Me.PJAddButton.TabIndex = 0
        Me.PJAddButton.Text = "SAVE"
        Me.PJAddButton.UseVisualStyleBackColor = True
        '
        'PJBackButton
        '
        Me.PJBackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PJBackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.PJBackButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PJBackButton.Location = New System.Drawing.Point(11, 9)
        Me.PJBackButton.Name = "PJBackButton"
        Me.PJBackButton.Size = New System.Drawing.Size(98, 35)
        Me.PJBackButton.TabIndex = 1
        Me.PJBackButton.Text = "BACK"
        Me.PJBackButton.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(111, 9)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(197, 37)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "EDIT PROJECT"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PJStatusComboBox)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.PJDescTextBox)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PJDateEndDateTimePicker)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.PJEmployeeNamesComboBox)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.PJNameTextBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PJDateStartDateTimePicker)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(472, 346)
        Me.Panel1.TabIndex = 29
        '
        'PJDescTextBox
        '
        Me.PJDescTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PJDescTextBox.Location = New System.Drawing.Point(157, 89)
        Me.PJDescTextBox.MaxLength = 200
        Me.PJDescTextBox.Multiline = True
        Me.PJDescTextBox.Name = "PJDescTextBox"
        Me.PJDescTextBox.Size = New System.Drawing.Size(303, 136)
        Me.PJDescTextBox.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 21)
        Me.Label2.TabIndex = 36
        Me.Label2.Tag = ""
        Me.Label2.Text = "Project Description:"
        '
        'PJDateEndDateTimePicker
        '
        Me.PJDateEndDateTimePicker.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PJDateEndDateTimePicker.CustomFormat = "MMMM"
        Me.PJDateEndDateTimePicker.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PJDateEndDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.PJDateEndDateTimePicker.Location = New System.Drawing.Point(157, 268)
        Me.PJDateEndDateTimePicker.Name = "PJDateEndDateTimePicker"
        Me.PJDateEndDateTimePicker.Size = New System.Drawing.Size(132, 29)
        Me.PJDateEndDateTimePicker.TabIndex = 4
        Me.PJDateEndDateTimePicker.Value = New Date(2023, 12, 27, 3, 29, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 272)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 21)
        Me.Label4.TabIndex = 34
        Me.Label4.Tag = ""
        Me.Label4.Text = "Project Date End:"
        '
        'PJEmployeeNamesComboBox
        '
        Me.PJEmployeeNamesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PJEmployeeNamesComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PJEmployeeNamesComboBox.FormattingEnabled = True
        Me.PJEmployeeNamesComboBox.Items.AddRange(New Object() {"Regular", "Special Non-Working"})
        Me.PJEmployeeNamesComboBox.Location = New System.Drawing.Point(157, 54)
        Me.PJEmployeeNamesComboBox.Name = "PJEmployeeNamesComboBox"
        Me.PJEmployeeNamesComboBox.Size = New System.Drawing.Size(303, 29)
        Me.PJEmployeeNamesComboBox.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(50, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 21)
        Me.Label3.TabIndex = 32
        Me.Label3.Tag = ""
        Me.Label3.Text = "Project Head:"
        '
        'PJNameTextBox
        '
        Me.PJNameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PJNameTextBox.Location = New System.Drawing.Point(157, 18)
        Me.PJNameTextBox.Name = "PJNameTextBox"
        Me.PJNameTextBox.Size = New System.Drawing.Size(303, 26)
        Me.PJNameTextBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 21)
        Me.Label1.TabIndex = 28
        Me.Label1.Tag = ""
        Me.Label1.Text = "Project Name:"
        '
        'PJDateStartDateTimePicker
        '
        Me.PJDateStartDateTimePicker.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PJDateStartDateTimePicker.CustomFormat = "MMMM"
        Me.PJDateStartDateTimePicker.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PJDateStartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.PJDateStartDateTimePicker.Location = New System.Drawing.Point(157, 231)
        Me.PJDateStartDateTimePicker.Name = "PJDateStartDateTimePicker"
        Me.PJDateStartDateTimePicker.Size = New System.Drawing.Size(132, 29)
        Me.PJDateStartDateTimePicker.TabIndex = 3
        Me.PJDateStartDateTimePicker.Value = New Date(2023, 12, 27, 3, 29, 0, 0)
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(18, 235)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(133, 21)
        Me.Label29.TabIndex = 26
        Me.Label29.Tag = ""
        Me.Label29.Text = "Project Date Start:"
        '
        'PJStatusComboBox
        '
        Me.PJStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PJStatusComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PJStatusComboBox.FormattingEnabled = True
        Me.PJStatusComboBox.Items.AddRange(New Object() {"Regular", "Special Non-Working"})
        Me.PJStatusComboBox.Location = New System.Drawing.Point(157, 303)
        Me.PJStatusComboBox.Name = "PJStatusComboBox"
        Me.PJStatusComboBox.Size = New System.Drawing.Size(303, 29)
        Me.PJStatusComboBox.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(50, 307)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 21)
        Me.Label5.TabIndex = 38
        Me.Label5.Tag = ""
        Me.Label5.Text = "Project Status:"
        '
        'ProjectEditForm
        '
        Me.AcceptButton = Me.PJAddButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.PJBackButton
        Me.ClientSize = New System.Drawing.Size(472, 398)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel11)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(488, 406)
        Me.Name = "ProjectEditForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Project"
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel11 As Panel
    Friend WithEvents PJAddButton As Button
    Friend WithEvents PJBackButton As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PJDescTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PJDateEndDateTimePicker As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents PJEmployeeNamesComboBox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PJNameTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PJDateStartDateTimePicker As DateTimePicker
    Friend WithEvents Label29 As Label
    Friend WithEvents PJStatusComboBox As ComboBox
    Friend WithEvents Label5 As Label
End Class
