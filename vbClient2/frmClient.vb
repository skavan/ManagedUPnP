Imports ManagedUPnP



Public Class frmClient
    Const DoServices As Boolean = True
    Dim WithEvents disc As ManagedUPnP.Discovery
    Dim WithEvents service As ManagedUPnP.Service
    Dim WithEvents services As ManagedUPnP.Services

    Dim deviceList As New List(Of Device)

    Dim WithEvents avTransport As UPnP.MediaDevice.AVTransport
    Private Delegate Sub delGUIUpate(obj As Object)

    Private Sub UpdateGUI(obj As Object)
        Select Case obj.GetType
            Case GetType(Device)
                Dim device As Device = DirectCast(obj, Device)
                'Dim newThread As New Threading.Thread(AddressOf AddDevices)
                'newThread.Start(device)
                AddDevices(device)
                lstDevices.DisplayMember = "FriendlyName"
                lstServices.DisplayMember = "FriendlyServiceTypeIdentifier"
                lstDevices.DataSource = deviceList
            Case GetType(UPnP.MediaDevice.AVTransport)
                pgService.SelectedObject = avTransport
                pgDetail.SelectedObject = avTransport.CurrentTrackData

        End Select
    End Sub

    Private Sub AddDevices(device As Device)

        MyDebug("Adding Device", device.FriendlyName & "[" & deviceList.Count & "]")
        deviceList.Add(device)
        If device.HasChildren Then
            For i = 0 To device.Children.Count - 1
                AddDevices(device.Children(i))
            Next
        End If
        'device.Services.Find()
        'service = device.Services.Item("urn:upnp-org:serviceId:AVTransport")
        'device.InitServices()
        MyDebug("Service Count", device.Services.Count)
        For Each svc In device.Services
            MyDebug("Registered Service", svc.FriendlyServiceTypeIdentifier)
            If svc.Id = "urn:upnp-org:serviceId:AVTransport" Then
                service = svc
                MyDebug("AVTransport Service Found", service.FriendlyServiceTypeIdentifier)
                avTransport = New UPnP.MediaDevice.AVTransport(service)
                avTransport.GetPositionInfo(0)
                avTransport.GetMediaInfo(0)
                pgService.SelectedObject = avTransport
                pgDetail.SelectedObject = avTransport.CurrentTrackData
            End If
        Next
        'If DoServices Then
        '    For i = 0 To device.Services.Count - 1
        '        If device.Services(i).Id = "urn:upnp-org:serviceId:AVTransport" Then
        '            service = device.Services(i)
        '            MyDebug("AVTransport Service Found", service.FriendlyServiceTypeIdentifier)
        '            avTransport = New UPnP.MediaDevice.AVTransport(service)
        '            avTransport.GetPositionInfo(0)
        '            avTransport.GetMediaInfo(0)
        '            pgService.SelectedObject = avTransport
        '            pgDetail.SelectedObject = avTransport.CurrentTrackData
        '        End If
        '    Next
        'End If
    End Sub
    Private Sub frmClient_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        disc.Stop()
        disc = Nothing
    End Sub

    Private Sub frmClient_Load(sender As Object, e As EventArgs) Handles Me.Load
        Logging.Enabled = True
        'AddHandler Logging.LogLines, AddressOf logger_LogLines
        AddHandler Logging.LogLines, AddressOf logger_LogLines
    End Sub


#Region "GUI Events"
    Private Sub btnDeviceScan_Click(sender As Object, e As EventArgs) Handles btnDeviceScan.Click
        NetworkScan("urn:schemas-upnp-org:device:ZonePlayer:1")
    End Sub
#End Region


#Region "Event Handling"
    Private Sub disc_DeviceAdded(sender As Object, e As DeviceAddedEventArgs) Handles disc.DeviceAdded
        MyDebug("device added. name:", e.Device.UniqueDeviceName)
        Me.Invoke(New delGUIUpate(AddressOf UpdateGUI), e.Device)
    End Sub

    Private Sub disc_DeviceRemoved(sender As Object, e As DeviceRemovedEventArgs) Handles disc.DeviceRemoved
        MyDebug("device removed. UDN:", e.UDN)
    End Sub

    Private Sub disc_SearchComplete(sender As Object, e As SearchCompleteEventArgs) Handles disc.SearchComplete
        MyDebug("search complete. name:", e.ToString)
    End Sub

    Private Sub logger_LogLines(sender As Object, e As LogLinesEventArgs) 'Handles logger.LogLines
        txtLog.Text = txtLog.Text & vbCrLf & Space(e.Indent * 10) & e.Lines
    End Sub
#End Region

    Private Sub btnServiceScan_Click(sender As Object, e As EventArgs) Handles btnServiceScan.Click
        NetworkScan("urn:schemas-upnp-org:service:AVTransport:1")
    End Sub

    Private Sub NetworkScan(urlFilter As String)
        disc = New Discovery(urlFilter, AddressFamilyFlags.IPv4, False)
        disc.Start()
    End Sub

    Private Sub lstDevices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDevices.SelectedIndexChanged
        If (lstDevices.SelectedIndex <> -1) And DoServices Then
            lstServices.DataSource = lstDevices.SelectedItem.Services
        End If

    End Sub

    Private Sub service_StateVariableChanged(sender As Object, e As StateVariableChangedEventArgs) Handles service.StateVariableChanged
        MyDebug("Service State Changed", e.StateVarName & "|" & e.StateVarValue)
    End Sub

    Private Sub btnAttachService_Click(sender As Object, e As EventArgs) Handles btnAttachService.Click

    End Sub

    Private Sub avTransport_LastChangeChanged(sender As Object, a As StateVariableChangedEventArgs(Of String)) Handles avTransport.LastChangeChanged
        MyDebug("LastChange", a.StateVarName)
        Me.Invoke(New delGUIUpate(AddressOf UpdateGUI), sender)
    End Sub
End Class
