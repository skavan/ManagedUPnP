<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClient
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnServiceScan = New System.Windows.Forms.Button()
        Me.btnDeviceScan = New System.Windows.Forms.Button()
        Me.tabs = New System.Windows.Forms.TabControl()
        Me.tbDevices = New System.Windows.Forms.TabPage()
        Me.contDevices = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.lstServices = New System.Windows.Forms.ListBox()
        Me.pgDevice = New System.Windows.Forms.PropertyGrid()
        Me.tbServices = New System.Windows.Forms.TabPage()
        Me.conServices = New System.Windows.Forms.SplitContainer()
        Me.pgServices = New System.Windows.Forms.PropertyGrid()
        Me.tbData = New System.Windows.Forms.TabPage()
        Me.conData = New System.Windows.Forms.SplitContainer()
        Me.pgService = New System.Windows.Forms.PropertyGrid()
        Me.pgDetail = New System.Windows.Forms.PropertyGrid()
        Me.tbLog = New System.Windows.Forms.TabPage()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.btnAttachService = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tabs.SuspendLayout()
        Me.tbDevices.SuspendLayout()
        CType(Me.contDevices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contDevices.Panel1.SuspendLayout()
        Me.contDevices.Panel2.SuspendLayout()
        Me.contDevices.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.tbServices.SuspendLayout()
        CType(Me.conServices, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 860)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1162, 28)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = False
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(945, 23)
        Me.lblStatus.Spring = True
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbStatus
        '
        Me.pbStatus.AutoSize = False
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(200, 22)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnAttachService)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnServiceScan)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnDeviceScan)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabs)
        Me.SplitContainer1.Size = New System.Drawing.Size(1162, 860)
        Me.SplitContainer1.SplitterDistance = 89
        Me.SplitContainer1.TabIndex = 4
        '
        'btnServiceScan
        '
        Me.btnServiceScan.Location = New System.Drawing.Point(772, 26)
        Me.btnServiceScan.Name = "btnServiceScan"
        Me.btnServiceScan.Size = New System.Drawing.Size(186, 42)
        Me.btnServiceScan.TabIndex = 1
        Me.btnServiceScan.Text = "Service Scan"
        Me.btnServiceScan.UseVisualStyleBackColor = True
        '
        'btnDeviceScan
        '
        Me.btnDeviceScan.Location = New System.Drawing.Point(964, 26)
        Me.btnDeviceScan.Name = "btnDeviceScan"
        Me.btnDeviceScan.Size = New System.Drawing.Size(186, 42)
        Me.btnDeviceScan.TabIndex = 0
        Me.btnDeviceScan.Text = "Device Scan"
        Me.btnDeviceScan.UseVisualStyleBackColor = True
        '
        'tabs
        '
        Me.tabs.Controls.Add(Me.tbDevices)
        Me.tabs.Controls.Add(Me.tbServices)
        Me.tabs.Controls.Add(Me.tbData)
        Me.tabs.Controls.Add(Me.tbLog)
        Me.tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs.Location = New System.Drawing.Point(0, 0)
        Me.tabs.Name = "tabs"
        Me.tabs.SelectedIndex = 0
        Me.tabs.Size = New System.Drawing.Size(1162, 767)
        Me.tabs.TabIndex = 4
        '
        'tbDevices
        '
        Me.tbDevices.Controls.Add(Me.contDevices)
        Me.tbDevices.Location = New System.Drawing.Point(4, 37)
        Me.tbDevices.Name = "tbDevices"
        Me.tbDevices.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDevices.Size = New System.Drawing.Size(1154, 726)
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
        Me.contDevices.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'contDevices.Panel2
        '
        Me.contDevices.Panel2.Controls.Add(Me.pgDevice)
        Me.contDevices.Size = New System.Drawing.Size(1148, 720)
        Me.contDevices.SplitterDistance = 380
        Me.contDevices.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.lstDevices)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.lstServices)
        Me.SplitContainer2.Size = New System.Drawing.Size(380, 720)
        Me.SplitContainer2.SplitterDistance = 316
        Me.SplitContainer2.TabIndex = 0
        '
        'lstDevices
        '
        Me.lstDevices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstDevices.FormattingEnabled = True
        Me.lstDevices.ItemHeight = 28
        Me.lstDevices.Location = New System.Drawing.Point(0, 0)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(380, 316)
        Me.lstDevices.TabIndex = 2
        '
        'lstServices
        '
        Me.lstServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstServices.FormattingEnabled = True
        Me.lstServices.ItemHeight = 28
        Me.lstServices.Location = New System.Drawing.Point(0, 0)
        Me.lstServices.Name = "lstServices"
        Me.lstServices.Size = New System.Drawing.Size(380, 400)
        Me.lstServices.TabIndex = 2
        '
        'pgDevice
        '
        Me.pgDevice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgDevice.Location = New System.Drawing.Point(0, 0)
        Me.pgDevice.Name = "pgDevice"
        Me.pgDevice.Size = New System.Drawing.Size(764, 720)
        Me.pgDevice.TabIndex = 1
        '
        'tbServices
        '
        Me.tbServices.Controls.Add(Me.conServices)
        Me.tbServices.Location = New System.Drawing.Point(4, 29)
        Me.tbServices.Name = "tbServices"
        Me.tbServices.Padding = New System.Windows.Forms.Padding(3)
        Me.tbServices.Size = New System.Drawing.Size(1154, 734)
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
        'conServices.Panel2
        '
        Me.conServices.Panel2.Controls.Add(Me.pgServices)
        Me.conServices.Size = New System.Drawing.Size(1148, 728)
        Me.conServices.SplitterDistance = 382
        Me.conServices.TabIndex = 1
        '
        'pgServices
        '
        Me.pgServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgServices.Location = New System.Drawing.Point(0, 0)
        Me.pgServices.Name = "pgServices"
        Me.pgServices.Size = New System.Drawing.Size(762, 728)
        Me.pgServices.TabIndex = 0
        '
        'tbData
        '
        Me.tbData.Controls.Add(Me.conData)
        Me.tbData.Location = New System.Drawing.Point(4, 37)
        Me.tbData.Name = "tbData"
        Me.tbData.Size = New System.Drawing.Size(1154, 726)
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
        Me.conData.Panel1.Controls.Add(Me.pgService)
        '
        'conData.Panel2
        '
        Me.conData.Panel2.Controls.Add(Me.pgDetail)
        Me.conData.Size = New System.Drawing.Size(1154, 726)
        Me.conData.SplitterDistance = 509
        Me.conData.TabIndex = 1
        '
        'pgService
        '
        Me.pgService.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgService.Location = New System.Drawing.Point(0, 0)
        Me.pgService.Name = "pgService"
        Me.pgService.Size = New System.Drawing.Size(509, 726)
        Me.pgService.TabIndex = 1
        '
        'pgDetail
        '
        Me.pgDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgDetail.Location = New System.Drawing.Point(0, 0)
        Me.pgDetail.Name = "pgDetail"
        Me.pgDetail.Size = New System.Drawing.Size(641, 726)
        Me.pgDetail.TabIndex = 2
        '
        'tbLog
        '
        Me.tbLog.Controls.Add(Me.txtLog)
        Me.tbLog.Location = New System.Drawing.Point(4, 29)
        Me.tbLog.Name = "tbLog"
        Me.tbLog.Padding = New System.Windows.Forms.Padding(3)
        Me.tbLog.Size = New System.Drawing.Size(1154, 734)
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
        Me.txtLog.Size = New System.Drawing.Size(1148, 728)
        Me.txtLog.TabIndex = 0
        '
        'btnAttachService
        '
        Me.btnAttachService.Location = New System.Drawing.Point(391, 26)
        Me.btnAttachService.Name = "btnAttachService"
        Me.btnAttachService.Size = New System.Drawing.Size(186, 42)
        Me.btnAttachService.TabIndex = 2
        Me.btnAttachService.Text = "Attach Service"
        Me.btnAttachService.UseVisualStyleBackColor = True
        '
        'frmClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1162, 888)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmClient"
        Me.Text = "Form1"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tabs.ResumeLayout(False)
        Me.tbDevices.ResumeLayout(False)
        Me.contDevices.Panel1.ResumeLayout(False)
        Me.contDevices.Panel2.ResumeLayout(False)
        CType(Me.contDevices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contDevices.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.tbServices.ResumeLayout(False)
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
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnServiceScan As System.Windows.Forms.Button
    Friend WithEvents btnDeviceScan As System.Windows.Forms.Button
    Friend WithEvents tabs As System.Windows.Forms.TabControl
    Friend WithEvents tbDevices As System.Windows.Forms.TabPage
    Friend WithEvents contDevices As System.Windows.Forms.SplitContainer
    Friend WithEvents pgDevice As System.Windows.Forms.PropertyGrid
    Friend WithEvents tbServices As System.Windows.Forms.TabPage
    Friend WithEvents conServices As System.Windows.Forms.SplitContainer
    Friend WithEvents pgServices As System.Windows.Forms.PropertyGrid
    Friend WithEvents tbData As System.Windows.Forms.TabPage
    Friend WithEvents conData As System.Windows.Forms.SplitContainer
    Friend WithEvents pgService As System.Windows.Forms.PropertyGrid
    Friend WithEvents pgDetail As System.Windows.Forms.PropertyGrid
    Friend WithEvents tbLog As System.Windows.Forms.TabPage
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents lstServices As System.Windows.Forms.ListBox
    Friend WithEvents btnAttachService As System.Windows.Forms.Button

End Class
