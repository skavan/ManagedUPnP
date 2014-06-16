Imports ManagedUPnP
Imports UPnP.MediaDevice

Public Class frmMain
    Dim WithEvents disc As UPnP.NetworkScan
    Dim WithEvents avTrans As UPnP.MediaDevice.AVTransport
    'Dim WithEvents logger As ManagedUPnP.Logging
    Private Delegate Sub delGUIUpate(obj As Object)

    Private Sub frmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Logging.Enabled = True
        'AddHandler Logging.LogLines, AddressOf logger_LogLines
        AddHandler Logging.LogLines, AddressOf logger_LogLines
        disc = New UPnP.NetworkScan("urn:schemas-upnp-org:device:ZonePlayer:1")
        lblStatus.Text = ("Searching for devices...")
        pbStatus.Style = ProgressBarStyle.Marquee
    End Sub

    Private Sub UpdateGUI(obj As Object)
        Select Case obj.GetType
            Case GetType(Device)
                Dim device As Device = DirectCast(obj, Device)
                If Not lstDevices.Items.Contains(device.FriendlyName) Then
                    lstDevices.Items.Add(device.FriendlyName)
                    lblStatus.Text = ("Added Device:" & device.UniversalProductCode)
                    pgDevice.SelectedObject = device
                Else

                End If
            Case GetType(Service)
                Dim service As Service = DirectCast(obj, Service)
                Debug.Print("Found Service:" & service.FriendlyServiceTypeIdentifier)
                If Not lstServices.Items.Contains(service.FriendlyServiceTypeIdentifier) Then
                    lstServices.Items.Add(service.FriendlyServiceTypeIdentifier)
                    lblStatus.Text = ("Added Service:" & service.Id)
                End If
                'pgServices.SelectedObject = service
                'If service.Id = "urn:upnp-org:serviceId:AVTransport" Then
                '    avTrans = New AVTransport(service)
                '    avTrans.GetPositionInfo(0)
                '    pgActions.SelectedObject = avTrans
                'End If
                'Else
                If service.Id = "urn:upnp-org:serviceId:AVTransport" Then
                    avTrans = New AVTransport(service)
                    avTrans.GetPositionInfo(0)
                    avTrans.GetMediaInfo(0)
                    pgServices.SelectedObject = service
                    pgActions.SelectedObject = avTrans

                End If
                'End If
            Case GetType(AVTransport)
                avTrans.GetPositionInfo(0)
                pgActions.SelectedObject = avTrans
                pgDetail.SelectedObject = avTrans.CurrentTrackData
            Case GetType(String)
                lblStatus.Text = (obj)
                pbStatus.Style = ProgressBarStyle.Continuous
        End Select

    End Sub

    

    Private Sub disc_DeviceChange(device As ManagedUPnP.Device) Handles disc.DeviceChange
        Me.Invoke(New delGUIUpate(AddressOf UpdateGUI), device)
        'UPdateGUI(device)
        'lstDevices.Items.Add(device.FriendlyName)
        'lblStatus.Text = ("Added Device:" & device.UniversalProductCode)
        'pgDevice.SelectedObject = device
    End Sub

    Private Sub disc_SearchChange() Handles disc.SearchChange
        Me.Invoke(New delGUIUpate(AddressOf UpdateGUI), "Search Complete")
        'UPdateGUI("Search Complete")
    End Sub

    Private Sub disc_ServiceChange(service As ManagedUPnP.Service) Handles disc.ServiceChange
        If service.Id = "urn:upnp-org:serviceId:AVTransport" Then
            Me.Invoke(New delGUIUpate(AddressOf UpdateGUI), service)
        End If

        'UPdateGUI(service)

    End Sub

    Private Sub avTrans_LastChangeChanged(sender As Object, a As ManagedUPnP.StateVariableChangedEventArgs(Of String)) Handles avTrans.LastChangeChanged
        Debug.Print("LastChangeChanged")
        Me.Invoke(New delGUIUpate(AddressOf UpdateGUI), sender)
        'Debug.Print("LAstChangeChanged in vb")
        'UpdateGUI(sender)


        'End If
    End Sub

    Private Sub avTrans_ServiceInstanceDied(sender As Object, e As ManagedUPnP.ServiceInstanceDiedEventArgs) Handles avTrans.ServiceInstanceDied

    End Sub

    Private Sub avTrans_StateVariableChanged(sender As Object, e As ManagedUPnP.StateVariableChangedEventArgs) Handles avTrans.StateVariableChanged
        Debug.Print("State Variable Changed")
    End Sub

    Private Sub logger_LogLines(sender As Object, e As LogLinesEventArgs) 'Handles logger.LogLines
        txtLog.Text = txtLog.Text & vbCrLf & Space(e.Indent * 10) & e.Lines
    End Sub
End Class
