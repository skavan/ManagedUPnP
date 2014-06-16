Imports ManagedUPnP
Imports System.Threading

Namespace UPnP

    Public Class NetworkScan
        ''' <summary>
        ''' Handles discovery of the services.
        ''' </summary>
        Private mdsServices As AutoEventedDiscoveryServices(Of Service)
        Public mdsDevices As ManagedUPnP.Devices
        Public lstServices As List(Of Service) = New List(Of Service)()
        Private WithEvents discovery As ManagedUPnP.Discovery
        '    Private WithEvents AVTransport As clsAVTransport.AVTransport1

        Private trd As Thread
        Private Delegate Sub delTreeNodeUpate(a As AutoEventedDiscoveryServices(Of Service).StatusNotifyActionEventArgs)

        Public Event SearchChange()
        Public Event DeviceChange(device As ManagedUPnP.Device)
        Public Event ServiceChange(service As Service)

        '// we're starting a network search for either Devices or Services that belong to devices.
        Sub New(searchURI As String)

            If searchURI.Contains("device:") Then
                '// if we're searching for device...
                mdsDevices = New ManagedUPnP.Devices
                'discovery = New Discovery("urn:schemas-upnp-org:device:ZonePlayer:1", AddressFamilyFlags.IPvBoth, False)
                discovery = New ManagedUPnP.Discovery(searchURI, AddressFamilyFlags.IPvBoth, False)
                'mdsDevices.
                AddHandler discovery.DeviceAdded, AddressOf NetworkScan_DeviceAdded
                discovery.Start()
            Else
                '// we're searching for a service
                ' Create discovery for all service and device types
                mdsServices = New AutoEventedDiscoveryServices(Of Service)(searchURI)
                'mdsServices = New AutoEventedDiscoveryServices(Of Service)("urn:schemas-upnp-org:device:ZonePlayer:1")

                ' Try to resolve network interfaces if OS supports it
                '//mdsServices.ResolveNetworkInterfaces = False

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


            End If
        End Sub

        Sub DeviceTreeUpdate(a As AutoEventedDiscoveryServices(Of Service).StatusNotifyActionEventArgs)
            Select Case a.NotifyAction
                Case AutoDiscoveryServices(Of Service).NotifyAction.ServiceAdded
                    ' A new service was found, add it
                    Dim service As Service = DirectCast(a.Data, Service)
                    Debug.Print("XXXX New Service Added: " & service.Id)
                    'tvUPnP.AddService(service)
                    Exit Select

                Case AutoDiscoveryServices(Of Service).NotifyAction.DeviceRemoved
                    ' A device has been removed, remove it and all services
                    'tvUPnP.RemoveDevice(DirectCast(a.Data, [String]))
                    Exit Select

                Case AutoDiscoveryServices(Of Service).NotifyAction.ServiceRemoved
                    ' A service was removed, remove it
                    'tvUPnP.RemoveService(DirectCast(a.Data, Service))
                    Exit Select '

                Case AutoDiscoveryServices(Of Global.ManagedUPnP.Service).NotifyAction.DeviceFound
                    Dim device As Device = DirectCast(a.Data, Device)

                    Debug.Print("XXXX New Device Added: " & device.UniqueDeviceName)
                    AddDevice(device)
                    'tvUPnP.AddDevice(DirectCast(a.Data, Device))
                    Exit Select
            End Select

        End Sub

        Sub AddDevice(device As Device)
            If Not mdsDevices.Contains(device) Then
                mdsDevices.Add(device)
            Else
                Exit Sub
            End If

            RaiseEvent DeviceChange(device)
            '// does this cause duplication? See log and analyze.
            For Each service As Service In device.Services
                If Not lstServices.Contains(service) Then
                    lstServices.Add(service)
                    RaiseEvent ServiceChange(service)
                End If
            Next
            For Each childdevice As Device In device.Children
                AddDevice(childdevice)

            Next

        End Sub

        Private Sub NetworkScan_DeviceAdded(sender As Object, e As ManagedUPnP.DeviceAddedEventArgs) Handles discovery.DeviceAdded
            Debug.Print("DEVICE Added")
            Dim a As New AutoEventedDiscoveryServices(Of Service).StatusNotifyActionEventArgs(AutoDiscoveryServices(Of Global.ManagedUPnP.Service).NotifyAction.DeviceFound, e.Device)
            DeviceTreeUpdate(a)
            'a.Data = sender
            'a.NotifyAction = AutoDiscoveryServices(Of Global.ManagedUPnP.Service).NotifyAction.DeviceFound

        End Sub

        ''' <summary>
        ''' Occurs when a notify action occurs for the dicovery object.
        ''' </summary>
        ''' <param name="sender">The sender of the event.</param>
        ''' <param name="a">The event arguments.</param>
        Private Sub dsServices_StatusNotifyAction(sender As Object, a As AutoEventedDiscoveryServices(Of Service).StatusNotifyActionEventArgs)
            Debug.Print("dsServicesLStatusNotifyAction")
            DeviceTreeUpdate(a)

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

        Private Sub discovery_SearchComplete(sender As Object, e As ManagedUPnP.SearchCompleteEventArgs) Handles discovery.SearchComplete
            RaiseEvent SearchChange()
        End Sub
    End Class
End Namespace