
Imports System.Xml
Imports System.Xml.XPath

Namespace UPnP.XPath
    Friend NotInheritable Class MediaPlayerNamespaceManager
        Inherits XmlNamespaceManager
        Public Sub New(nameTable As XmlNameTable)
            MyBase.New(nameTable)
            AddNamespace("didl", "urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/")
            AddNamespace("upnp", "urn:schemas-upnp-org:metadata-1-0/upnp/")
            AddNamespace("r", "urn:schemas-rinconnetworks-com:metadata-1-0/")
            AddNamespace("avt", "urn:schemas-upnp-org:metadata-1-0/AVT/")
            AddNamespace("dc", "http://purl.org/dc/elements/1.1/")
            AddNamespace("rcs", "urn:schemas-upnp-org:metadata-1-0/RCS/")
            AddNamespace("media", "http://search.yahoo.com/mrss/")
            AddNamespace("itunes", "http://www.itunes.com/dtds/podcast-1.0.dtd")
            AddNamespace("feedburner", "http://rssnamespace.org/feedburner/ext/1.0")
        End Sub
    End Class

    Public NotInheritable Class Globals
        Private Sub New()
        End Sub
        Public Shared Table As XmlNameTable = New NameTable()
        Public Shared Manager As XmlNamespaceManager = New MediaPlayerNamespaceManager(Table)
    End Class

    Public NotInheritable Class Expressions
        Private Sub New()
        End Sub
        Public Shared ReadOnly EventElements As XPathExpression = XPathExpression.Compile("/avt:Event/avt:InstanceID[@val='0']/*", XPath.Globals.Manager)

        Public Shared ReadOnly ValueAttributes As XPathExpression = XPathExpression.Compile("@val", XPath.Globals.Manager)
        Public Shared ReadOnly ChannelAttributes As XPathExpression = XPathExpression.Compile("@channel", XPath.Globals.Manager)

        Public Shared ReadOnly RenderingChannelElements As XPathExpression = XPathExpression.Compile("/rcs:Event/rcs:InstanceID[@val='0']/rcs:*[@channel and @val]", XPath.Globals.Manager)
        Public Shared ReadOnly RenderingValueElements As XPathExpression = XPathExpression.Compile("/rcs:Event/rcs:InstanceID[@val='0']/rcs:*[not(@channel) and @val]", XPath.Globals.Manager)
        Public Shared ReadOnly RenderingNoAttributeElements As XPathExpression = XPathExpression.Compile("/rcs:Event/rcs:InstanceID[@val='0']/rcs:*[not(@*)]", XPath.Globals.Manager)

        Public Shared ReadOnly ItemsElements As XPathExpression = XPathExpression.Compile("/didl:DIDL-Lite/didl:item", XPath.Globals.Manager)
        Public Shared ReadOnly ContainerElements As XPathExpression = XPathExpression.Compile("/didl:DIDL-Lite/didl:container", XPath.Globals.Manager)

        Public Shared ReadOnly AlbumArtURI As XPathExpression = XPathExpression.Compile("/didl:DIDL-Lite/didl:item/upnp:albumArtURI", XPath.Globals.Manager)

        Public Shared ReadOnly Creator As XPathExpression = XPathExpression.Compile("/didl:DIDL-Lite/didl:item/dc:creator", XPath.Globals.Manager)
        Public Shared ReadOnly Title As XPathExpression = XPathExpression.Compile("/didl:DIDL-Lite/didl:item/dc:title", XPath.Globals.Manager)
        Public Shared ReadOnly Album As XPathExpression = XPathExpression.Compile("/didl:DIDL-Lite/didl:item/upnp:album", XPath.Globals.Manager)
        Public Shared ReadOnly TrackNum As XPathExpression = XPathExpression.Compile("/didl:DIDL-Lite/didl:item/upnp:originalTrackNumber", XPath.Globals.Manager)
        Public Shared ReadOnly AlbumArtist As XPathExpression = XPathExpression.Compile("/didl:DIDL-Lite/didl:item/r:albumArtist", XPath.Globals.Manager)
        Public Shared ReadOnly Artist As XPathExpression = XPathExpression.Compile("/didl:DIDL-Lite/didl:item/dc:creator", XPath.Globals.Manager)
        Public Shared ReadOnly FilePathURI As XPathExpression = XPathExpression.Compile("/didl:DIDL-Lite/didl:item/res", XPath.Globals.Manager)


        Public Shared ReadOnly CurrentTrackMetaData As XPathExpression = XPathExpression.Compile("/avt:Event/avt:InstanceID[@val='0']/avt:CurrentTrackMetaData", XPath.Globals.Manager)

    End Class
End Namespace
