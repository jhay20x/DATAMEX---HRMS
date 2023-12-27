<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LeaveBalanceForm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LBBalanceTextBox = New System.Windows.Forms.TextBox()
        Me.LBSaveButton = New System.Windows.Forms.Button()
        Me.LREmpIDLabel = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.LeaveBalanceDataGridView = New System.Windows.Forms.DataGridView()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.LBBackButton = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        CType(Me.LeaveBalanceDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.LBBalanceTextBox)
        Me.Panel4.Controls.Add(Me.LBSaveButton)
        Me.Panel4.Controls.Add(Me.LREmpIDLabel)
        Me.Panel4.Controls.Add(Me.Label31)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 52)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(655, 80)
        Me.Panel4.TabIndex = 31
        '
        'LBBalanceTextBox
        '
        Me.LBBalanceTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBBalanceTextBox.Location = New System.Drawing.Point(164, 28)
        Me.LBBalanceTextBox.Name = "LBBalanceTextBox"
        Me.LBBalanceTextBox.Size = New System.Drawing.Size(80, 29)
        Me.LBBalanceTextBox.TabIndex = 32
        '
        'LBSaveButton
        '
        Me.LBSaveButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBSaveButton.Location = New System.Drawing.Point(556, 26)
        Me.LBSaveButton.Name = "LBSaveButton"
        Me.LBSaveButton.Size = New System.Drawing.Size(87, 31)
        Me.LBSaveButton.TabIndex = 24
        Me.LBSaveButton.Text = "Save"
        Me.LBSaveButton.UseVisualStyleBackColor = True
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
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(25, 31)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(133, 21)
        Me.Label31.TabIndex = 3
        Me.Label31.Tag = ""
        Me.Label31.Text = "Available Balance:"
        '
        'LeaveBalanceDataGridView
        '
        Me.LeaveBalanceDataGridView.AllowUserToAddRows = False
        Me.LeaveBalanceDataGridView.AllowUserToDeleteRows = False
        Me.LeaveBalanceDataGridView.AllowUserToResizeColumns = False
        Me.LeaveBalanceDataGridView.AllowUserToResizeRows = False
        Me.LeaveBalanceDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.LeaveBalanceDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LeaveBalanceDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.LeaveBalanceDataGridView.ColumnHeadersHeight = 25
        Me.LeaveBalanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column9, Me.Column8, Me.Column2, Me.Column1})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.LeaveBalanceDataGridView.DefaultCellStyle = DataGridViewCellStyle4
        Me.LeaveBalanceDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LeaveBalanceDataGridView.Location = New System.Drawing.Point(0, 132)
        Me.LeaveBalanceDataGridView.Name = "LeaveBalanceDataGridView"
        Me.LeaveBalanceDataGridView.ReadOnly = True
        Me.LeaveBalanceDataGridView.RowHeadersVisible = False
        Me.LeaveBalanceDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.LeaveBalanceDataGridView.Size = New System.Drawing.Size(655, 178)
        Me.LeaveBalanceDataGridView.TabIndex = 32
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "EmployeeID"
        DataGridViewCellStyle2.NullValue = "-"
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column9.HeaderText = "Employee ID"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "EmployeeName"
        DataGridViewCellStyle3.NullValue = "-"
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column8.HeaderText = "Employee Name"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Department"
        Me.Column2.HeaderText = "Department"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "Balance"
        Me.Column1.HeaderText = "Balance"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = Global.HRM1.My.Resources.Resources.blue
        Me.Panel11.Controls.Add(Me.LBBackButton)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(655, 52)
        Me.Panel11.TabIndex = 2
        '
        'LBBackButton
        '
        Me.LBBackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LBBackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.LBBackButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBBackButton.Location = New System.Drawing.Point(11, 9)
        Me.LBBackButton.Name = "LBBackButton"
        Me.LBBackButton.Size = New System.Drawing.Size(98, 35)
        Me.LBBackButton.TabIndex = 1
        Me.LBBackButton.Text = "BACK"
        Me.LBBackButton.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(111, 9)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(224, 37)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "LEAVE BALANCE"
        '
        'LeaveBalanceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.LBBackButton
        Me.ClientSize = New System.Drawing.Size(655, 310)
        Me.Controls.Add(Me.LeaveBalanceDataGridView)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel11)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(671, 349)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(671, 349)
        Me.Name = "LeaveBalanceForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Leave Balance"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.LeaveBalanceDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel11 As Panel
    Friend WithEvents LBBackButton As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LBBalanceTextBox As TextBox
    Friend WithEvents LBSaveButton As Button
    Friend WithEvents LREmpIDLabel As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents LeaveBalanceDataGridView As DataGridView
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
