<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.DataGridView6 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Salary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.MenuHide6Button = New System.Windows.Forms.Button()
        Me.Panel19.SuspendLayout()
        CType(Me.DataGridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel20.SuspendLayout()
        Me.Panel22.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.White
        Me.Panel19.Controls.Add(Me.DataGridView6)
        Me.Panel19.Controls.Add(Me.Panel20)
        Me.Panel19.Controls.Add(Me.Panel22)
        Me.Panel19.Enabled = False
        Me.Panel19.Location = New System.Drawing.Point(154, 29)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(802, 676)
        Me.Panel19.TabIndex = 14
        Me.Panel19.Visible = False
        '
        'DataGridView6
        '
        Me.DataGridView6.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView6.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView6.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn11, Me.Salary})
        Me.DataGridView6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView6.Location = New System.Drawing.Point(0, 93)
        Me.DataGridView6.Name = "DataGridView6"
        Me.DataGridView6.RowHeadersVisible = False
        Me.DataGridView6.Size = New System.Drawing.Size(802, 583)
        Me.DataGridView6.TabIndex = 4
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Employee Name"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Employee ID"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Email Address"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Department"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'Salary
        '
        Me.Salary.HeaderText = "Salary"
        Me.Salary.Name = "Salary"
        '
        'Panel20
        '
        Me.Panel20.Controls.Add(Me.Button16)
        Me.Panel20.Controls.Add(Me.Button13)
        Me.Panel20.Controls.Add(Me.Button14)
        Me.Panel20.Controls.Add(Me.TextBox6)
        Me.Panel20.Controls.Add(Me.Label46)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel20.Location = New System.Drawing.Point(0, 52)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(802, 41)
        Me.Panel20.TabIndex = 7
        '
        'Button16
        '
        Me.Button16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button16.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button16.Location = New System.Drawing.Point(553, 8)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(75, 25)
        Me.Button16.TabIndex = 9
        Me.Button16.Text = "ADD"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.Location = New System.Drawing.Point(715, 9)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(75, 25)
        Me.Button13.TabIndex = 8
        Me.Button13.Text = "REFRESH"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.Location = New System.Drawing.Point(634, 9)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(75, 25)
        Me.Button14.TabIndex = 7
        Me.Button14.Text = "EDIT"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(61, 9)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(210, 26)
        Me.TextBox6.TabIndex = 6
        '
        'Label46
        '
        Me.Label46.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(3, 11)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(60, 21)
        Me.Label46.TabIndex = 5
        Me.Label46.Tag = ""
        Me.Label46.Text = "Search:"
        '
        'Panel22
        '
        Me.Panel22.BackgroundImage = Global.HRM1.My.Resources.Resources.blue
        Me.Panel22.Controls.Add(Me.MenuHide6Button)
        Me.Panel22.Controls.Add(Me.Label51)
        Me.Panel22.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel22.Location = New System.Drawing.Point(0, 0)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(802, 52)
        Me.Panel22.TabIndex = 0
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(54, 9)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(274, 37)
        Me.Label51.TabIndex = 0
        Me.Label51.Text = "EMPLOYEES SALARY"
        '
        'MenuHide6Button
        '
        Me.MenuHide6Button.BackgroundImage = CType(resources.GetObject("MenuHide6Button.BackgroundImage"), System.Drawing.Image)
        Me.MenuHide6Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuHide6Button.Location = New System.Drawing.Point(7, 9)
        Me.MenuHide6Button.Name = "MenuHide6Button"
        Me.MenuHide6Button.Size = New System.Drawing.Size(41, 35)
        Me.MenuHide6Button.TabIndex = 3
        Me.MenuHide6Button.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 735)
        Me.Controls.Add(Me.Panel19)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.Panel19.ResumeLayout(False)
        CType(Me.DataGridView6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel20.ResumeLayout(False)
        Me.Panel20.PerformLayout()
        Me.Panel22.ResumeLayout(False)
        Me.Panel22.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel19 As Panel
    Friend WithEvents DataGridView6 As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents Salary As DataGridViewTextBoxColumn
    Friend WithEvents Panel20 As Panel
    Friend WithEvents Button16 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents Panel22 As Panel
    Friend WithEvents Label51 As Label
    Friend WithEvents MenuHide6Button As Button
End Class
