<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LeaveTypeForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LTAddButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LTPaymentComboBox = New System.Windows.Forms.ComboBox()
        Me.LTTypeTextBox = New System.Windows.Forms.TextBox()
        Me.LTSaveButton = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.LeaveTypeDataGridView = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.LTBackButton = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        CType(Me.LeaveTypeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.LTAddButton)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.LTPaymentComboBox)
        Me.Panel4.Controls.Add(Me.LTTypeTextBox)
        Me.Panel4.Controls.Add(Me.LTSaveButton)
        Me.Panel4.Controls.Add(Me.Label31)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 52)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(655, 80)
        Me.Panel4.TabIndex = 32
        '
        'LTAddButton
        '
        Me.LTAddButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTAddButton.Location = New System.Drawing.Point(556, 25)
        Me.LTAddButton.Name = "LTAddButton"
        Me.LTAddButton.Size = New System.Drawing.Size(87, 31)
        Me.LTAddButton.TabIndex = 35
        Me.LTAddButton.Text = "Add"
        Me.LTAddButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(204, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 21)
        Me.Label1.TabIndex = 34
        Me.Label1.Tag = ""
        Me.Label1.Text = "Payment:"
        '
        'LTPaymentComboBox
        '
        Me.LTPaymentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LTPaymentComboBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTPaymentComboBox.FormattingEnabled = True
        Me.LTPaymentComboBox.Items.AddRange(New Object() {"Paid", "Unpaid"})
        Me.LTPaymentComboBox.Location = New System.Drawing.Point(283, 26)
        Me.LTPaymentComboBox.Name = "LTPaymentComboBox"
        Me.LTPaymentComboBox.Size = New System.Drawing.Size(111, 29)
        Me.LTPaymentComboBox.TabIndex = 33
        '
        'LTTypeTextBox
        '
        Me.LTTypeTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTTypeTextBox.Location = New System.Drawing.Point(76, 26)
        Me.LTTypeTextBox.Name = "LTTypeTextBox"
        Me.LTTypeTextBox.Size = New System.Drawing.Size(113, 29)
        Me.LTTypeTextBox.TabIndex = 32
        '
        'LTSaveButton
        '
        Me.LTSaveButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTSaveButton.Location = New System.Drawing.Point(463, 25)
        Me.LTSaveButton.Name = "LTSaveButton"
        Me.LTSaveButton.Size = New System.Drawing.Size(87, 31)
        Me.LTSaveButton.TabIndex = 24
        Me.LTSaveButton.Text = "Save"
        Me.LTSaveButton.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(25, 30)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(45, 21)
        Me.Label31.TabIndex = 3
        Me.Label31.Tag = ""
        Me.Label31.Text = "Type:"
        '
        'LeaveTypeDataGridView
        '
        Me.LeaveTypeDataGridView.AllowUserToAddRows = False
        Me.LeaveTypeDataGridView.AllowUserToDeleteRows = False
        Me.LeaveTypeDataGridView.AllowUserToResizeColumns = False
        Me.LeaveTypeDataGridView.AllowUserToResizeRows = False
        Me.LeaveTypeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.LeaveTypeDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LeaveTypeDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.LeaveTypeDataGridView.ColumnHeadersHeight = 25
        Me.LeaveTypeDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.LeaveTypeDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.LeaveTypeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LeaveTypeDataGridView.Location = New System.Drawing.Point(0, 132)
        Me.LeaveTypeDataGridView.Name = "LeaveTypeDataGridView"
        Me.LeaveTypeDataGridView.ReadOnly = True
        Me.LeaveTypeDataGridView.RowHeadersVisible = False
        Me.LeaveTypeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.LeaveTypeDataGridView.Size = New System.Drawing.Size(655, 178)
        Me.LeaveTypeDataGridView.TabIndex = 33
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "ID"
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Type"
        Me.Column2.HeaderText = "Type"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Payment"
        Me.Column3.HeaderText = "Payment"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = Global.HRM1.My.Resources.Resources.blue
        Me.Panel11.Controls.Add(Me.LTBackButton)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(655, 52)
        Me.Panel11.TabIndex = 3
        '
        'LTBackButton
        '
        Me.LTBackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LTBackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.LTBackButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTBackButton.Location = New System.Drawing.Point(11, 9)
        Me.LTBackButton.Name = "LTBackButton"
        Me.LTBackButton.Size = New System.Drawing.Size(98, 35)
        Me.LTBackButton.TabIndex = 1
        Me.LTBackButton.Text = "BACK"
        Me.LTBackButton.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(111, 9)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(166, 37)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "LEAVE TYPE"
        '
        'LeaveTypeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.LTBackButton
        Me.ClientSize = New System.Drawing.Size(655, 310)
        Me.Controls.Add(Me.LeaveTypeDataGridView)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel11)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LeaveTypeForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Leave Type"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.LeaveTypeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel11 As Panel
    Friend WithEvents LTBackButton As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LTTypeTextBox As TextBox
    Friend WithEvents LTSaveButton As Button
    Friend WithEvents Label31 As Label
    Friend WithEvents LeaveTypeDataGridView As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents LTPaymentComboBox As ComboBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents LTAddButton As Button
End Class
