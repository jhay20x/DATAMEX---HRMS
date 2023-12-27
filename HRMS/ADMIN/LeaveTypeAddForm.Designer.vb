<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LeaveTypeAddForm
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
        Me.LTTypeTextBox = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.LTSaveButton = New System.Windows.Forms.Button()
        Me.LTPaymentComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LTTypeTextBox
        '
        Me.LTTypeTextBox.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTTypeTextBox.Location = New System.Drawing.Point(116, 36)
        Me.LTTypeTextBox.Name = "LTTypeTextBox"
        Me.LTTypeTextBox.Size = New System.Drawing.Size(205, 33)
        Me.LTTypeTextBox.TabIndex = 0
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(12, 39)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(98, 25)
        Me.Label31.TabIndex = 33
        Me.Label31.Tag = ""
        Me.Label31.Text = "New Type:"
        '
        'LTSaveButton
        '
        Me.LTSaveButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTSaveButton.Location = New System.Drawing.Point(327, 68)
        Me.LTSaveButton.Name = "LTSaveButton"
        Me.LTSaveButton.Size = New System.Drawing.Size(87, 35)
        Me.LTSaveButton.TabIndex = 2
        Me.LTSaveButton.Text = "Save"
        Me.LTSaveButton.UseVisualStyleBackColor = True
        '
        'LTPaymentComboBox
        '
        Me.LTPaymentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LTPaymentComboBox.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTPaymentComboBox.FormattingEnabled = True
        Me.LTPaymentComboBox.Items.AddRange(New Object() {"Paid", "Unpaid"})
        Me.LTPaymentComboBox.Location = New System.Drawing.Point(116, 75)
        Me.LTPaymentComboBox.Name = "LTPaymentComboBox"
        Me.LTPaymentComboBox.Size = New System.Drawing.Size(139, 33)
        Me.LTPaymentComboBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 25)
        Me.Label1.TabIndex = 37
        Me.Label1.Tag = ""
        Me.Label1.Text = "Payment:"
        '
        'LeaveTypeAddForm
        '
        Me.AcceptButton = Me.LTSaveButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(426, 144)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LTPaymentComboBox)
        Me.Controls.Add(Me.LTSaveButton)
        Me.Controls.Add(Me.LTTypeTextBox)
        Me.Controls.Add(Me.Label31)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(442, 183)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(442, 183)
        Me.Name = "LeaveTypeAddForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add New Leave Type"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LTTypeTextBox As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents LTSaveButton As Button
    Friend WithEvents LTPaymentComboBox As ComboBox
    Friend WithEvents Label1 As Label
End Class
