<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbStatus = New System.Windows.Forms.ToolStripProgressBar()
        Me.tabs = New System.Windows.Forms.TabControl()
        Me.tbDevices = New System.Windows.Forms.TabPage()
        Me.contDevices = New System.Windows.Forms.SplitContainer()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.pgDevice = New System.Windows.Forms.PropertyGrid()
        Me.tbServices = New System.Windows.Forms.TabPage()
        Me.conServices = New System.Windows.Forms.SplitContainer()
        Me.lstServices = New System.Windows.Forms.ListBox()
        Me.pgServices = New System.Windows.Forms.PropertyGrid()
        Me.tbData = New System.Windows.Forms.TabPage()
        Me.conData = New System.Windows.Forms.SplitContainer()
        Me.pgActions = New System.Windows.Forms.PropertyGrid()
        Me.pgDetail = New System.Windows.Forms.PropertyGrid()
        Me.tbLog = New System.Windows.Forms.TabPage()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.StatusStrip1.SuspendLayout()
        Me.tabs.SuspendLayout()
        Me.tbDevices.SuspendLayout()
        CType(Me.contDevices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contDevices.Panel1.SuspendLayout()
        Me.contDevices.Panel2.SuspendLayout()
        Me.contDevices.SuspendLayout()
        Me.tbServices.SuspendLayout()
        CType(Me.conServices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.conServices.Panel1.SuspendLayout()
        Me.conServices.Panel2.SuspendLayout()
        Me.conServices.SuspendLayout()
        Me.tbData.SuspendLayout()
        CType(Me.conData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.conData.Panel1.SuspendLayout()
        Me.conData.Panel2.SuspendLayout()
        Me.conData.SuspendLayout()
        Me.tbLog.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.pbStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 590)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(750, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = False
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(533, 17)
        Me.lblStatus.Spring = True
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbStatus
        '
        Me.pbStatus.AutoSize = False
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(200, 16)
        '
        'tabs
        '
        Me.tabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabs.Controls.Add(Me.tbDevices)
        Me.tabs.Controls.Add(Me.tbServices)
        Me.tabs.Controls.Add(Me.tbData)
        Me.tabs.Controls.Add(Me.tbLog)
        Me.tabs.Location = New System.Drawing.Point(3, 3)
        Me.tabs.Name = "tabs"
        Me.tabs.SelectedIndex = 0
        Me.tabs.Size = New System.Drawing.Size(747, 585)
        Me.tabs.TabIndex = 3
        '
        'tbDevices
        '
        Me.tbDevices.Controls.Add(Me.contDevices)
        Me.tbDevices.Location = New System.Drawing.Point(4, 37)
        Me.tbDevices.Name = "tbDevices"
        Me.tbDevices.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDevices.Size = New System.Drawing.Size(739, 544)
        Me.tbDevices.TabIndex = 0
        Me.tbDevices.Text = "Devices"
        Me.tbDevices.UseVisualStyleBackColor = True
        '
        'contDevices
        '
        Me.contDevices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contDevices.Location = New System.Drawing.Point(3, 3)
        Me.contDevices.Name = "contDevices"
        '
        'contDevices.Panel1
        '
        Me.contDevices.Panel1.Controls.Add(Me.lstDevices)
        '
        'contDevices.Panel2
        '
        Me.contDevices.Panel2.Controls.Add(Me.pgDevice)
        Me.contDevices.Size = New System.Drawing.Size(733, 538)
        Me.contDevices.SplitterDistance = 243
        Me.contDevices.TabIndex = 0
        '
        'lstDevices
        '
        Me.lstDevices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstDevices.FormattingEnabled = True
        Me.lstDevices.ItemHeight = 28
        Me.lstDevices.Location = New System.Drawing.Point(0, 0)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(243, 538)
        Me.lstDevices.TabIndex = 1
        '
        'pgDevice
        '
        Me.pgDevice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgDevice.Location = New System.Drawing.Point(0, 0)
        Me.pgDevice.Name = "pgDevice"
        Me.pgDevice.Size = New System.Drawing.Size(486, 538)
        Me.pgDevice.TabIndex = 1
        '
        'tbServices
        '
        Me.tbServices.Controls.Add(Me.conServices)
        Me.tbServices.Location = New System.Drawing.Point(4, 37)
        Me.tbServices.Name = "tbServices"
        Me.tbServices.Padding = New System.Windows.Forms.Padding(3)
        Me.tbServices.Size = New System.Drawing.Size(739, 544)
        Me.tbServices.TabIndex = 1
        Me.tbServices.Text = "Services"
        Me.tbServices.UseVisualStyleBackColor = True
        '
        'conServices
        '
        Me.conServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.conServices.Location = New System.Drawing.Point(3, 3)
        Me.conServices.Name = "conServices"
        '
        'conServices.Panel1
        '
        Me.conServices.Panel1.Controls.Add(Me.lstServices)
        '
        'conServices.Panel2
        '
        Me.conServices.Panel2.Controls.Add(Me.pgServices)
        Me.conServices.Size = New System.Drawing.Size(733, 538)
        Me.conServices.SplitterDistance = 244
        Me.conServices.TabIndex = 1
        '
        'lstServices
        '
        Me.lstServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstServices.FormattingEnabled = True
        Me.lstServices.ItemHeight = 28
        Me.lstServices.Location = New System.Drawing.Point(0, 0)
        Me.lstServices.Name = "lstServices"
        Me.lstServices.Size = New System.Drawing.Size(244, 538)
        Me.lstServices.TabIndex = 0
        '
        'pgServices
        '
        Me.pgServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgServices.Location = New System.Drawing.Point(0, 0)
        Me.pgServices.Name = "pgServices"
        Me.pgServices.Size = New System.Drawing.Size(485, 538)
        Me.pgServices.TabIndex = 0
        '
        'tbData
        '
        Me.tbData.Controls.Add(Me.conData)
        Me.tbData.Location = New System.Drawing.Point(4, 37)
        Me.tbData.Name = "tbData"
        Me.tbData.Size = New System.Drawing.Size(739, 544)
        Me.tbData.TabIndex = 2
        Me.tbData.Text = "Data"
        Me.tbData.UseVisualStyleBackColor = True
        '
        'conData
        '
        Me.conData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.conData.Location = New System.Drawing.Point(0, 0)
        Me.conData.Name = "conData"
        '
        'conData.Panel1
        '
        Me.conData.Panel1.Controls.Add(Me.pgActions)
        '
        'conData.Panel2
        '
        Me.conData.Panel2.Controls.Add(Me.pgDetail)
        Me.conData.Size = New System.Drawing.Size(739, 544)
        Me.conData.SplitterDistance = 326
        Me.conData.TabIndex = 1
        '
        'pgActions
        '
        Me.pgActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgActions.Location = New System.Drawing.Point(0, 0)
        Me.pgActions.Name = "pgActions"
        Me.pgActions.Size = New System.Drawing.Size(326, 544)
        Me.pgActions.TabIndex = 1
        '
        'pgDetail
        '
        Me.pgDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgDetail.Location = New System.Drawing.Point(0, 0)
        Me.pgDetail.Name = "pgDetail"
        Me.pgDetail.Size = New System.Drawing.Size(409, 544)
        Me.pgDetail.TabIndex = 2
        '
        'tbLog
        '
        Me.tbLog.Controls.Add(Me.txtLog)
        Me.tbLog.Location = New System.Drawing.Point(4, 37)
        Me.tbLog.Name = "tbLog"
        Me.tbLog.Padding = New System.Windows.Forms.Padding(3)
        Me.tbLog.Size = New System.Drawing.Size(739, 544)
        Me.tbLog.TabIndex = 3
        Me.tbLog.Text = "Log"
        Me.tbLog.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Location = New System.Drawing.Point(3, 3)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(733, 538)
        Me.txtLog.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 612)
        Me.Controls.Add(Me.tabs)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmMain"
        Me.Text = "UPnP Browser"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tabs.ResumeLayout(False)
        Me.tbDevices.ResumeLayout(False)
        Me.contDevices.Panel1.ResumeLayout(False)
        Me.contDevices.Panel2.ResumeLayout(False)
        CType(Me.contDevices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contDevices.ResumeLayout(False)
        Me.tbServices.ResumeLayout(False)
        Me.conServices.Panel1.ResumeLayout(False)
        Me.conServices.Panel2.ResumeLayout(False)
        CType(Me.conServices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.conServices.ResumeLayout(False)
        Me.tbData.ResumeLayout(False)
        Me.conData.Panel1.ResumeLayout(False)
        Me.conData.Panel2.ResumeLayout(False)
        CType(Me.conData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.conData.ResumeLayout(False)
        Me.tbLog.ResumeLayout(False)
        Me.tbLog.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pbStatus As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tabs As System.Windows.Forms.TabControl
    Friend WithEvents tbDevices As System.Windows.Forms.TabPage
    Friend WithEvents contDevices As System.Windows.Forms.SplitContainer
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents pgDevice As System.Windows.Forms.PropertyGrid
    Friend WithEvents tbServices As System.Windows.Forms.TabPage
    Friend WithEvents conServices As System.Windows.Forms.SplitContainer
    Friend WithEvents lstServices As System.Windows.Forms.ListBox
    Friend WithEvents pgServices As System.Windows.Forms.PropertyGrid
    Friend WithEvents tbData As System.Windows.Forms.TabPage
    Friend WithEvents conData As System.Windows.Forms.SplitContainer
    Friend WithEvents pgActions As System.Windows.Forms.PropertyGrid
    Friend WithEvents pgDetail As System.Windows.Forms.PropertyGrid
    Friend WithEvents tbLog As System.Windows.Forms.TabPage
    Friend WithEvents txtLog As System.Windows.Forms.TextBox

End Class
