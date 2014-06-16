Imports ManagedUPnP
Imports ManagedUPnPTest
Imports System.Threading
Imports UPnP.MediaDevice
'Imports clsServices.UPnPServices

Public Class frmMain

#Region "Private Locals"

    ''' <summary>
    ''' Handles discovery of the services.
    ''' </summary>
    Private mdsServices As AutoEventedDiscoveryServices(Of Service)
    Private mdsDevices As ManagedUPnP.Devices
    Private WithEvents discovery As ManagedUPnP.Discovery
    Private WithEvents AVTransport As UPnP.MediaDevice.AVTransport
    ''' <summary>
    ''' The current UPnP info control being displayed.
    ''' </summary>
    Private miInfo As ctlUPnPInfo = Nothing

    Private trd As Thread

    Private Delegate Sub delTreeNodeUpate(a As AutoEventedDiscoveryServices(Of Service).StatusNotifyActionEventArgs)

#End Region

#Region "Form Events"
    ''' <summary>
    ''' Occurs when the main form is closing.
    ''' </summary>
    ''' <param name="sender">The sender of the event.</param>
    ''' <param name="e">The event arguments.</param>
    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Disable Managed UPnP Logging
        ManagedUPnP.Logging.Enabled = False
        'ManagedUPnP.Logging.LogLines -= New LogLinesEventHandler(AddressOf Logging_LogLines)
        RemoveHandler ManagedUPnP.Logging.LogLines, AddressOf Logging_LogLines
    End Sub

    ''' <summary>
    ''' Occurs when the form loads.
    ''' </summary>
    ''' <param name="sender">The sender of the event.</param>
    ''' <param name="e">The event arguments.</param>
    Private Sub frmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' Setup Managed UPnP Logging
        AddHandler ManagedUPnP.Logging.LogLines, AddressOf Logging_LogLines

        'ManagedUPnP.Logging.LogLines += New LogLinesEventHandler(AddressOf Logging_LogLines)
        ManagedUPnP.Logging.Enabled = True

        'trd = New Thread(AddressOf ServiceDiscovery)
        trd = New Thread(AddressOf DeviceDiscovery)
        trd.IsBackground = True
        trd.Start()

    End Sub

#End Region

    Sub DeviceDiscovery()
        mdsDevices = New ManagedUPnP.Devices
        discovery = New Discovery("urn:schemas-upnp-org:device:ZonePlayer:1", AddressFamilyFlags.IPvBoth, False)
        'mdsDevices.
        AddHandler discovery.DeviceAdded, AddressOf discovery_DeviceAdded
        discovery.Start()
        'discovery.FindDevicesAsync("urn:schemas-upnp-org:device:MediaServer:1", 5000, 100, AddressOf devices_SearchComplete, AddressFamilyFlags.IPvBoth, False)

    End Sub
    Sub ServiceDiscovery()

        ' Create discovery for all service and device types
        mdsServices = New AutoEventedDiscoveryServices(Of Service)(Nothing)
        'mdsServices = New AutoEventedDiscoveryServices(Of Service)("urn:schemas-upnp-org:device:ZonePlayer:1")


        ' Try to resolve network interfaces if OS supports it
        mdsServices.ResolveNetworkInterfaces = True

        ' Assign events
        'mdsServices.CanCreateServiceFor += New AutoEventedDiscoveryServices(Of Service).CanCreateServiceForEventHandler(AddressOf dsServices_CanCreateServiceFor)
        AddHandler mdsServices.CanCreateServiceFor, AddressOf dsServices_CanCreateServiceFor
        AddHandler mdsServices.CreateServiceFor, AddressOf dsServices_CreateServiceFor
        AddHandler mdsServices.StatusNotifyAction, AddressOf dsServices_StatusNotifyAction
        'mdsServices.CreateServiceFor += New AutoEventedDiscoveryServices(Of Service).CreateServiceForEventHandler(AddressOf dsServices_CreateServiceFor)

        'mdsServices.StatusNotifyAction += New AutoEventedDiscoveryServices(Of Service).StatusNotifyActionEventHandler(AddressOf dsServices_StatusNotifyAction)

        ' ManagedUPnP.WindowsFirewall.CheckUPnPFirewallRules(Nothing)

        ' Start async discovery
        mdsServices.ReStartAsync()
        Thread.Sleep(100)

    End Sub

    Sub treeNodeUpdate(a As AutoEventedDiscoveryServices(Of Service).StatusNotifyActionEventArgs)
        Select Case a.NotifyAction
            Case AutoDiscoveryServices(Of Service).NotifyAction.ServiceAdded
                ' A new service was found, add it
                tvUPnP.AddService(DirectCast(a.Data, Service))
                Exit Select

            Case AutoDiscoveryServices(Of Service).NotifyAction.DeviceRemoved
                ' A device has been removed, remove it and all services
                tvUPnP.RemoveDevice(DirectCast(a.Data, [String]))
                Exit Select

            Case AutoDiscoveryServices(Of Service).NotifyAction.ServiceRemoved
                ' A service was removed, remove it
                tvUPnP.RemoveService(DirectCast(a.Data, Service))
                Exit Select

            Case AutoDiscoveryServices(Of Global.ManagedUPnP.Service).NotifyAction.DeviceFound
                tvUPnP.AddDevice(DirectCast(a.Data, ManagedUPnP.Device))
                Exit Select
        End Select

    End Sub

#Region "Event Handlers"

    ''' <summary>
    ''' Occurs when a Managed UPnP log entry is raised.
    ''' </summary>
    ''' <param name="sender">The sender of the event.</param>
    ''' <param name="a">The event arguments.</param>
    Private Sub Logging_LogLines(sender As Object, a As LogLinesEventArgs)
        Dim lsDateTime As String = DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss.fff] ")
        Dim lsLineStart As String = lsDateTime & New [String](" "c, a.Indent * 4)
        txtLog.AppendLog((lsLineStart & a.Lines.Replace(vbCr & vbLf, Convert.ToString(vbCr & vbLf) & lsLineStart)) + vbCr & vbLf)
    End Sub

    ''' <summary>
    ''' Occurs when a notify action occurs for the dicovery object.
    ''' </summary>
    ''' <param name="sender">The sender of the event.</param>
    ''' <param name="a">The event arguments.</param>
    Private Sub dsServices_StatusNotifyAction(sender As Object, a As AutoEventedDiscoveryServices(Of Service).StatusNotifyActionEventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(New delTreeNodeUpate(AddressOf treeNodeUpdate), a)
        Else
            treeNodeUpdate(a)
        End If
    End Sub

    ''' <summary>
    ''' Occurs when the discovery object wants a new auto service created.
    ''' </summary>
    ''' <param name="sender">The sender of the event.</param>
    ''' <param name="a">The event arguments.</param>
    Private Sub dsServices_CreateServiceFor(sender As Object, a As AutoEventedDiscoveryServices(Of Service).CreateServiceForEventArgs)
        a.CreatedAutoService = a.Service
    End Sub

    ''' <summary>
    ''' Occurs when the discovery object needs to determine if an auto service can be created.
    ''' </summary>
    ''' <param name="sender">The sender of the event.</param>
    ''' <param name="a">The event arguments.</param>
    Private Sub dsServices_CanCreateServiceFor(sender As Object, a As AutoEventedDiscoveryServices(Of Service).CanCreateServiceForEventArgs)
        a.CanCreate = True
    End Sub

    ''' <summary>
    ''' Occurs after an item in the UPnP browser tree view is selected.
    ''' </summary>
    ''' <param name="sender">The sender of the event.</param>
    ''' <param name="e">The event arguments.</param>
    Private Sub tvUPnP_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvUPnP.AfterSelect
        ' Get the selection tree item.
        Dim liItem As IUPnPTreeItem = tvUPnP.SelectedItem

        ' Save the currently showed control
        Dim liPrev As ctlUPnPInfo = miInfo

        ' Default to no new control
        miInfo = Nothing

        Try
            ' If the new item is available
            If liItem IsNot Nothing Then
                ' Get the control
                miInfo = liItem.InfoControl

                ' If the control is available
                If miInfo IsNot Nothing Then
                    ' Dock it and add it
                    miInfo.Dock = DockStyle.Fill
                    pnlInfo.Controls.Add(miInfo)
                End If
            End If
        Finally
            ' If the old control was available
            If liPrev IsNot Nothing Then
                ' Remove it and dispose it
                pnlInfo.Controls.Remove(liPrev)
                liPrev.Dispose()
            End If
        End Try
        CheckNode()
    End Sub

#End Region


    Private Sub discovery_DeviceAdded(sender As Object, e As ManagedUPnP.DeviceAddedEventArgs) 'Handles discovery.DeviceAdded
        Dim a As New AutoEventedDiscoveryServices(Of Service).StatusNotifyActionEventArgs(AutoDiscoveryServices(Of Global.ManagedUPnP.Service).NotifyAction.DeviceFound, e.Device)
        If Me.InvokeRequired Then
            Me.Invoke(New delTreeNodeUpate(AddressOf treeNodeUpdate), a)
        Else
            treeNodeUpdate(a)
        End If
        'a.Data = sender
        'a.NotifyAction = AutoDiscoveryServices(Of Global.ManagedUPnP.Service).NotifyAction.DeviceFound


        Debug.Print("D Added")

    End Sub

    Private Shared Sub discovery_DeviceRemoved(sender As Object, e As ManagedUPnP.DeviceRemovedEventArgs) Handles discovery.DeviceRemoved
        Debug.Print("D Finished")
    End Sub

    Private Shared Sub devices_SearchComplete(devices As ManagedUPnP.Devices, searchCompleted As Boolean)
        Debug.Print("Scan Complete")
    End Sub

    Private Sub CheckNode()
        Dim obj As Object
        obj = tvUPnP.SelectedItem.LinkedObject
        If TypeOf (obj) Is ManagedUPnP.Device Then
            Dim device As Device = obj
            If device.FriendlyName.Contains("Family Room") Then
                Debug.Print("YEAH:" & device.FriendlyName)
            Else
                Debug.Print("NO")
            End If
        ElseIf TypeOf (obj) Is Service Then
            Dim service As Service = obj
            Debug.Print("SERVICE:" & service.FriendlyServiceTypeIdentifier)
            If service.Id = "urn:upnp-org:serviceId:AVTransport" Then

                Debug.Print("We have clicked on the transport service of the device")
                'Dim i As Integer
                'service.InvokeAction("GetMediaInfo", i)
                'InvokeAction<string>("GetExternalIPAddress", out lsIP);

                AVTransport = New AVTransport(service)
                AVTransport.GetPositionInfo(0)
                propGrid.SelectedObject = AVTransport
                Debug.Print(AVTransport.CurrentTrackMetaData)

                Debug.Print("Created an AVTransport Object")
            Else
                propGrid.SelectedObject = Nothing
            End If
        End If

    End Sub

    Private Sub AVTransport_LastChangeChanged(sender As Object, a As ManagedUPnP.StateVariableChangedEventArgs(Of String)) Handles AVTransport.LastChangeChanged
        'Debug.Print("LAstChangeChanged : " & a.StateVarName & "|" & a.StateVarValue)
    End Sub

    Private Sub AVTransport_StateVariableChanged(sender As Object, e As ManagedUPnP.StateVariableChangedEventArgs) Handles AVTransport.StateVariableChanged
        'Debug.Print("StateVariableChanged: " & e.StateVarName & "|" & e.StateVarValue)
    End Sub
End Class


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================





