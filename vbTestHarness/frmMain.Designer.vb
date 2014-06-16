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
        Me.components = New System.ComponentModel.Container()
        Me.tpInfo = New System.Windows.Forms.TabPage()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tpLog = New System.Windows.Forms.TabPage()
        Me.txtLog = New System.Windows.Forms.ctlLogBox()
        Me.tpMyData = New System.Windows.Forms.TabPage()
        Me.propGrid = New System.Windows.Forms.PropertyGrid()
        Me.ilIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.scMain = New System.Windows.Forms.SplitContainer()
        Me.tvUPnP = New ManagedUPnPTest.ctlUPnPTreeBrowser()
        Me.tpInfo.SuspendLayout()
        Me.tcMain.SuspendLayout()
        Me.tpLog.SuspendLayout()
        Me.tpMyData.SuspendLayout()
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scMain.Panel1.SuspendLayout()
        Me.scMain.Panel2.SuspendLayout()
        Me.scMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tpInfo
        '
        Me.tpInfo.Controls.Add(Me.pnlInfo)
        Me.tpInfo.Location = New System.Drawing.Point(4, 26)
        Me.tpInfo.Name = "tpInfo"
        Me.tpInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInfo.Size = New System.Drawing.Size(455, 510)
        Me.tpInfo.TabIndex = 0
        Me.tpInfo.Text = "Selected Item Info"
        Me.tpInfo.UseVisualStyleBackColor = True
        '
        'pnlInfo
        '
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInfo.Location = New System.Drawing.Point(3, 3)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(449, 504)
        Me.pnlInfo.TabIndex = 1
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.tpInfo)
        Me.tcMain.Controls.Add(Me.tpLog)
        Me.tcMain.Controls.Add(Me.tpMyData)
        Me.tcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMain.Location = New System.Drawing.Point(0, 0)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(463, 540)
        Me.tcMain.TabIndex = 1
        '
        'tpLog
        '
        Me.tpLog.Controls.Add(Me.txtLog)
        Me.tpLog.Location = New System.Drawing.Point(4, 22)
        Me.tpLog.Name = "tpLog"
        Me.tpLog.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLog.Size = New System.Drawing.Size(455, 514)
        Me.tpLog.TabIndex = 1
        Me.tpLog.Text = "UPnP Log"
        Me.tpLog.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.SystemColors.Window
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.txtLog.Location = New System.Drawing.Point(3, 3)
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.Size = New System.Drawing.Size(449, 508)
        Me.txtLog.TabIndex = 1
        Me.txtLog.Text = ""
        Me.txtLog.WordWrap = False
        '
        'tpMyData
        '
        Me.tpMyData.Controls.Add(Me.propGrid)
        Me.tpMyData.Location = New System.Drawing.Point(4, 26)
        Me.tpMyData.Name = "tpMyData"
        Me.tpMyData.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMyData.Size = New System.Drawing.Size(455, 510)
        Me.tpMyData.TabIndex = 2
        Me.tpMyData.Text = "MyData"
        Me.tpMyData.UseVisualStyleBackColor = True
        '
        'propGrid
        '
        Me.propGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.propGrid.Location = New System.Drawing.Point(3, 3)
        Me.propGrid.Name = "propGrid"
        Me.propGrid.Size = New System.Drawing.Size(449, 504)
        Me.propGrid.TabIndex = 0
        '
        'ilIcons
        '
        Me.ilIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ilIcons.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilIcons.TransparentColor = System.Drawing.Color.Transparent
        '
        'scMain
        '
        Me.scMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scMain.Location = New System.Drawing.Point(0, 0)
        Me.scMain.Name = "scMain"
        '
        'scMain.Panel1
        '
        Me.scMain.Panel1.Controls.Add(Me.tvUPnP)
        '
        'scMain.Panel2
        '
        Me.scMain.Panel2.Controls.Add(Me.tcMain)
        Me.scMain.Size = New System.Drawing.Size(743, 540)
        Me.scMain.SplitterDistance = 276
        Me.scMain.TabIndex = 3
        '
        'tvUPnP
        '
        Me.tvUPnP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvUPnP.ImageIndex = 0
        Me.tvUPnP.Location = New System.Drawing.Point(0, 0)
        Me.tvUPnP.Name = "tvUPnP"
        Me.tvUPnP.SelectedImageIndex = 0
        Me.tvUPnP.Size = New System.Drawing.Size(276, 540)
        Me.tvUPnP.TabIndex = 1
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 540)
        Me.Controls.Add(Me.scMain)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMain"
        Me.Text = "Main"
        Me.tpInfo.ResumeLayout(False)
        Me.tcMain.ResumeLayout(False)
        Me.tpLog.ResumeLayout(False)
        Me.tpMyData.ResumeLayout(False)
        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel2.ResumeLayout(False)
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tpInfo As System.Windows.Forms.TabPage
    Private WithEvents pnlInfo As System.Windows.Forms.Panel
    Private WithEvents tcMain As System.Windows.Forms.TabControl
    Private WithEvents tpLog As System.Windows.Forms.TabPage
    Private WithEvents ilIcons As System.Windows.Forms.ImageList
    Private WithEvents scMain As System.Windows.Forms.SplitContainer
    Private WithEvents txtLog As System.Windows.Forms.ctlLogBox
    Private WithEvents tvUPnP As ManagedUPnPTest.ctlUPnPTreeBrowser
    Friend WithEvents tpMyData As System.Windows.Forms.TabPage
    Friend WithEvents propGrid As System.Windows.Forms.PropertyGrid

End Class
