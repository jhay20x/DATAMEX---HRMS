﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HolidayEditForm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.HolidayTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.HolidayDescTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.HolidayDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.HEAddButton = New System.Windows.Forms.Button()
        Me.HEBackButton = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.HolidayTypeComboBox)
        Me.Panel1.Controls.Add(Me.HolidayDescTextBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.HolidayDateTimePicker)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(526, 240)
        Me.Panel1.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(87, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 21)
        Me.Label2.TabIndex = 31
        Me.Label2.Tag = ""
        Me.Label2.Text = "Type:"
        '
        'HolidayTypeComboBox
        '
        Me.HolidayTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.HolidayTypeComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HolidayTypeComboBox.FormattingEnabled = True
        Me.HolidayTypeComboBox.Items.AddRange(New Object() {"Regular", "Special Non-Working"})
        Me.HolidayTypeComboBox.Location = New System.Drawing.Point(138, 184)
        Me.HolidayTypeComboBox.Name = "HolidayTypeComboBox"
        Me.HolidayTypeComboBox.Size = New System.Drawing.Size(150, 29)
        Me.HolidayTypeComboBox.TabIndex = 30
        '
        'HolidayDescTextBox
        '
        Me.HolidayDescTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HolidayDescTextBox.Location = New System.Drawing.Point(138, 71)
        Me.HolidayDescTextBox.Multiline = True
        Me.HolidayDescTextBox.Name = "HolidayDescTextBox"
        Me.HolidayDescTextBox.Size = New System.Drawing.Size(376, 97)
        Me.HolidayDescTextBox.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 21)
        Me.Label1.TabIndex = 28
        Me.Label1.Tag = ""
        Me.Label1.Text = "Description:"
        '
        'HolidayDateTimePicker
        '
        Me.HolidayDateTimePicker.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HolidayDateTimePicker.CustomFormat = "MMMM"
        Me.HolidayDateTimePicker.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HolidayDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.HolidayDateTimePicker.Location = New System.Drawing.Point(138, 26)
        Me.HolidayDateTimePicker.Name = "HolidayDateTimePicker"
        Me.HolidayDateTimePicker.Size = New System.Drawing.Size(132, 29)
        Me.HolidayDateTimePicker.TabIndex = 27
        Me.HolidayDateTimePicker.Value = New Date(2023, 12, 27, 3, 29, 0, 0)
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(12, 30)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(120, 21)
        Me.Label29.TabIndex = 26
        Me.Label29.Tag = ""
        Me.Label29.Text = "Date of Holiday:"
        '
        'HEAddButton
        '
        Me.HEAddButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HEAddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.HEAddButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HEAddButton.Location = New System.Drawing.Point(416, 9)
        Me.HEAddButton.Name = "HEAddButton"
        Me.HEAddButton.Size = New System.Drawing.Size(98, 35)
        Me.HEAddButton.TabIndex = 0
        Me.HEAddButton.Text = "SAVE"
        Me.HEAddButton.UseVisualStyleBackColor = True
        '
        'HEBackButton
        '
        Me.HEBackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.HEBackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.HEBackButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HEBackButton.Location = New System.Drawing.Point(11, 9)
        Me.HEBackButton.Name = "HEBackButton"
        Me.HEBackButton.Size = New System.Drawing.Size(98, 35)
        Me.HEBackButton.TabIndex = 1
        Me.HEBackButton.Text = "BACK"
        Me.HEBackButton.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = Global.HRM1.My.Resources.Resources.blue
        Me.Panel11.Controls.Add(Me.HEAddButton)
        Me.Panel11.Controls.Add(Me.HEBackButton)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(526, 52)
        Me.Panel11.TabIndex = 28
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(111, 9)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(200, 37)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "EDIT HOLIDAY"
        '
        'HolidayEditForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(526, 292)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel11)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(542, 331)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(542, 331)
        Me.Name = "HolidayEditForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Holiday"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents HolidayTypeComboBox As ComboBox
    Friend WithEvents HolidayDescTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents HolidayDateTimePicker As DateTimePicker
    Friend WithEvents Label29 As Label
    Friend WithEvents HEAddButton As Button
    Friend WithEvents HEBackButton As Button
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Label33 As Label
End Class
