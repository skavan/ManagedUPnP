Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Threading
Imports System.ComponentModel
Imports ManagedUPnP
Imports System.Diagnostics.CodeAnalysis
Imports System.Xml.XPath
Imports System.IO

Namespace UPnP
    Namespace MediaDevice

        Public Class TrackData
            Property Artist As String
            Property Album As String
            Property AlbumArtist As String
            Property Title As String
            Property Year As String
            Property TrackNumber As String
            Property AlbumTrackCount As String
            Property AlbumArtURI As String
            Property AlbumArtURL As String
            Property FilePathURI As String
            Property FilePath As String
            Public Parent As AVTransport

            'Private _deviceURL As String
            Private _trackMetaData As XPathNavigator
            Private _missingAlbumArtPath As String = "http://www.kavan.us/musicweb/images/No-album-art300x300.jpg"

            Public ReadOnly Property DocumentURL() As String
                Get
                    Return Parent.DocumentURL
                End Get
            End Property



            Public Sub New(_parent As AVTransport)
                Parent = _parent
            End Sub

            Public Property TrackMetaData() As XPathNavigator
                Get
                    Return _trackMetaData
                End Get
                '// When this propetry is set, it will automagically fill in the data!
                Set(ByVal value As XPathNavigator)
                    ParseTrackMetaData(value, DocumentURL)
                End Set
            End Property


            Public Sub ParseTrackMetaData(metadata As XPathNavigator, deviceURL As String)
                If metadata Is Nothing Then Exit Sub

                _trackMetaData = metadata
                Artist = metadata.SelectSingleNode(XPath.Expressions.Artist).Value
                Title = metadata.SelectSingleNode(XPath.Expressions.Title).Value
                AlbumArtURI = metadata.SelectSingleNode(XPath.Expressions.AlbumArtURI).Value
                AlbumArtURL = CreateAlbumArtURI(metadata)
                TrackNumber = metadata.SelectSingleNode(XPath.Expressions.TrackNum).Value
                AlbumArtist = metadata.SelectSingleNode(XPath.Expressions.AlbumArtist).Value
                Album = metadata.SelectSingleNode(XPath.Expressions.Album).Value
                FilePathURI = Parent.CurrentTrackURI
                Dim testURI As New Uri(FilePathURI)

                FilePath = String.Format("//{0}{1}", testURI.Host, testURI.LocalPath)
                Debug.Print("Network Filepath: " & FilePath)
            End Sub

            Public Sub ParseTrackMetaData(metadata As String, deviceURL As String)
                If metadata = "" Then Exit Sub
                Dim doc As New XPathDocument(New StringReader(metadata))
                Dim nav As XPathNavigator = doc.CreateNavigator
                ParseTrackMetaData(nav, deviceURL)
            End Sub

            Private Function CreateAlbumArtURI(trackdata As XPathNavigator) As String

                If AlbumArtURI = "" Then
                    Return _missingAlbumArtPath
                Else

                    Dim art As String = AlbumArtURI
                    Dim baseUri As Uri = New Uri(DocumentURL)
                    Dim path As String = art.Substring(0, art.IndexOf("?"c))
                    Dim qs As String = art.Substring(art.IndexOf("?"c))
                    Dim builder As New UriBuilder(baseUri.Scheme, baseUri.Host, baseUri.Port, path, qs)
                    Return builder.Uri.OriginalString
                End If

            End Function

            Private Function CreateFilePath() As String
                'Dim _trackURI = New Uri()
                Return ""
            End Function



            '//   		art	"/getaa?u=x-file-cifs%3a%2f%2fZEUS%2fMusic%2fMaster%2520Compressed%2fMy%2520Compressed%2520Files%2fColdplay%2fGhost%2520Stories%2520%255b%2bdigital%2520booklet%255d%2f01-03-%2520Ink.mp3&v=27"
            '// +		trackpath	{http://192.168.1.167:1400/xml/device_description.xml}	System.Uri

            '// 		"http://192.168.1.167:1400/getaa?u=x-file-cifs%3a%2f%2fZEUS%2fMusic%2fMaster%2520Compressed%2fMy%2520Compressed%2520Files%2fColdplay%2fGhost%2520Stories%2520%255b%2bdigital%2520booklet%255d%2f01-03-%2520Ink.mp3&v=27"	String

        End Class

        ''' <summary>
        ''' Encapsulates a specific Service class for the AVTransport1 (urn:schemas-upnp-org:service:AVTransport:1) service.
        ''' </summary>
        Public Class AVTransport
            Inherits Service
            'Public mediaInfo As New MediaInfo
            'Public positionInfo As New PositionInfo


#Region "Protected Constants"

            Private Dim _documentURL As String
            ''' <summary>
            ''' The string value for the allowed value STOPPED of the TransportState state variable.
            ''' </summary>
            Protected Const csAllowedVal_TransportState_STOPPED As String = "STOPPED"

            ''' <summary>
            ''' The string value for the allowed value PLAYING of the TransportState state variable.
            ''' </summary>
            Protected Const csAllowedVal_TransportState_PLAYING As String = "PLAYING"

            ''' <summary>
            ''' The string value for the allowed value PAUSED_PLAYBACK of the TransportState state variable.
            ''' </summary>
            Protected Const csAllowedVal_TransportState_PAUSEDPLAYBACK As String = "PAUSED_PLAYBACK"

            ''' <summary>
            ''' The string value for the allowed value TRANSITIONING of the TransportState state variable.
            ''' </summary>
            Protected Const csAllowedVal_TransportState_TRANSITIONING As String = "TRANSITIONING"

            ''' <summary>
            ''' The name for the TransportState state variable.
            ''' </summary>
            Protected Const csStateVar_TransportState As String = "TransportState"

            ''' <summary>
            ''' The name for the TransportStatus state variable.
            ''' </summary>
            Protected Const csStateVar_TransportStatus As String = "TransportStatus"

            ''' <summary>
            ''' The name for the TransportErrorDescription state variable.
            ''' </summary>
            Protected Const csStateVar_TransportErrorDescription As String = "TransportErrorDescription"

            ''' <summary>
            ''' The name for the TransportErrorURI state variable.
            ''' </summary>
            Protected Const csStateVar_TransportErrorURI As String = "TransportErrorURI"

            ''' <summary>
            ''' The name for the TransportErrorHttpCode state variable.
            ''' </summary>
            Protected Const csStateVar_TransportErrorHttpCode As String = "TransportErrorHttpCode"

            ''' <summary>
            ''' The name for the TransportErrorHttpHeaders state variable.
            ''' </summary>
            Protected Const csStateVar_TransportErrorHttpHeaders As String = "TransportErrorHttpHeaders"

            ''' <summary>
            ''' The name for the PlaybackStorageMedium state variable.
            ''' </summary>
            Protected Const csStateVar_PlaybackStorageMedium As String = "PlaybackStorageMedium"

            ''' <summary>
            ''' The name for the RecordStorageMedium state variable.
            ''' </summary>
            Protected Const csStateVar_RecordStorageMedium As String = "RecordStorageMedium"

            ''' <summary>
            ''' The name for the PossiblePlaybackStorageMedia state variable.
            ''' </summary>
            Protected Const csStateVar_PossiblePlaybackStorageMedia As String = "PossiblePlaybackStorageMedia"

            ''' <summary>
            ''' The name for the PossibleRecordStorageMedia state variable.
            ''' </summary>
            Protected Const csStateVar_PossibleRecordStorageMedia As String = "PossibleRecordStorageMedia"

            ''' <summary>
            ''' The name for the CurrentPlayMode state variable.
            ''' </summary>
            Protected Const csStateVar_CurrentPlayMode As String = "CurrentPlayMode"

            ''' <summary>
            ''' The name for the CurrentCrossfadeMode state variable.
            ''' </summary>
            Protected Const csStateVar_CurrentCrossfadeMode As String = "CurrentCrossfadeMode"

            ''' <summary>
            ''' The name for the TransportPlaySpeed state variable.
            ''' </summary>
            Protected Const csStateVar_TransportPlaySpeed As String = "TransportPlaySpeed"

            ''' <summary>
            ''' The name for the RecordMediumWriteStatus state variable.
            ''' </summary>
            Protected Const csStateVar_RecordMediumWriteStatus As String = "RecordMediumWriteStatus"

            ''' <summary>
            ''' The name for the CurrentRecordQualityMode state variable.
            ''' </summary>
            Protected Const csStateVar_CurrentRecordQualityMode As String = "CurrentRecordQualityMode"

            ''' <summary>
            ''' The name for the PossibleRecordQualityModes state variable.
            ''' </summary>
            Protected Const csStateVar_PossibleRecordQualityModes As String = "PossibleRecordQualityModes"

            ''' <summary>
            ''' The name for the NumberOfTracks state variable.
            ''' </summary>
            Protected Const csStateVar_NumberOfTracks As String = "NumberOfTracks"

            ''' <summary>
            ''' The name for the CurrentTrack state variable.
            ''' </summary>
            Protected Const csStateVar_CurrentTrack As String = "CurrentTrack"

            ''' <summary>
            ''' The name for the CurrentSection state variable.
            ''' </summary>
            Protected Const csStateVar_CurrentSection As String = "CurrentSection"

            ''' <summary>
            ''' The name for the CurrentTrackDuration state variable.
            ''' </summary>
            Protected Const csStateVar_CurrentTrackDuration As String = "CurrentTrackDuration"

            ''' <summary>
            ''' The name for the CurrentMediaDuration state variable.
            ''' </summary>
            Protected Const csStateVar_CurrentMediaDuration As String = "CurrentMediaDuration"

            ''' <summary>
            ''' The name for the CurrentTrackMetaData state variable.
            ''' </summary>
            Protected Const csStateVar_CurrentTrackMetaData As String = "CurrentTrackMetaData"

            ''' <summary>
            ''' The name for the CurrentTrackURI state variable.
            ''' </summary>
            Protected Const csStateVar_CurrentTrackURI As String = "CurrentTrackURI"

            ''' <summary>
            ''' The name for the AVTransportURI state variable.
            ''' </summary>
            Protected Const csStateVar_AVTransportURI As String = "AVTransportURI"

            ''' <summary>
            ''' The name for the AVTransportURIMetaData state variable.
            ''' </summary>
            Protected Const csStateVar_AVTransportURIMetaData As String = "AVTransportURIMetaData"

            ''' <summary>
            ''' The name for the NextAVTransportURI state variable.
            ''' </summary>
            Protected Const csStateVar_NextAVTransportURI As String = "NextAVTransportURI"

            ''' <summary>
            ''' The name for the NextAVTransportURIMetaData state variable.
            ''' </summary>
            Protected Const csStateVar_NextAVTransportURIMetaData As String = "NextAVTransportURIMetaData"

            ''' <summary>
            ''' The name for the RelativeTimePosition state variable.
            ''' </summary>
            Protected Const csStateVar_RelativeTimePosition As String = "RelativeTimePosition"

            ''' <summary>
            ''' The name for the AbsoluteTimePosition state variable.
            ''' </summary>
            Protected Const csStateVar_AbsoluteTimePosition As String = "AbsoluteTimePosition"

            ''' <summary>
            ''' The name for the RelativeCounterPosition state variable.
            ''' </summary>
            Protected Const csStateVar_RelativeCounterPosition As String = "RelativeCounterPosition"

            ''' <summary>
            ''' The name for the AbsoluteCounterPosition state variable.
            ''' </summary>
            Protected Const csStateVar_AbsoluteCounterPosition As String = "AbsoluteCounterPosition"

            ''' <summary>
            ''' The name for the CurrentTransportActions state variable.
            ''' </summary>
            Protected Const csStateVar_CurrentTransportActions As String = "CurrentTransportActions"

            ''' <summary>
            ''' The name for the SleepTimerGeneration state variable.
            ''' </summary>
            Protected Const csStateVar_SleepTimerGeneration As String = "SleepTimerGeneration"

            ''' <summary>
            ''' The name for the SnoozeRunning state variable.
            ''' </summary>
            Protected Const csStateVar_SnoozeRunning As String = "SnoozeRunning"

            ''' <summary>
            ''' The name for the AlarmRunning state variable.
            ''' </summary>
            Protected Const csStateVar_AlarmRunning As String = "AlarmRunning"

            ''' <summary>
            ''' The name for the AlarmIDRunning state variable.
            ''' </summary>
            Protected Const csStateVar_AlarmIDRunning As String = "AlarmIDRunning"

            ''' <summary>
            ''' The name for the AlarmLoggedStartTime state variable.
            ''' </summary>
            Protected Const csStateVar_AlarmLoggedStartTime As String = "AlarmLoggedStartTime"

            ''' <summary>
            ''' The name for the RestartPending state variable.
            ''' </summary>
            Protected Const csStateVar_RestartPending As String = "RestartPending"

            ''' <summary>
            ''' The name for the LastChange state variable.
            ''' </summary>
            Protected Const csStateVar_LastChange As String = "LastChange"

            ''' <summary>
            ''' The name for the NextTrackMetaData state variable.
            ''' </summary>
            Protected Const csStateVar_NextTrackMetaData As String = "NextTrackMetaData"

            ''' <summary>
            ''' The name for the NextTrackURI state variable.
            ''' </summary>
            Protected Const csStateVar_NextTrackURI As String = "NextTrackURI"

            ''' <summary>
            ''' The name for the EnqueuedTransportURIMetaData state variable.
            ''' </summary>
            Protected Const csStateVar_EnqueuedTransportURIMetaData As String = "EnqueuedTransportURIMetaData"

            ''' <summary>
            ''' The name for the EnqueuedTransportURI state variable.
            ''' </summary>
            Protected Const csStateVar_EnqueuedTransportURI As String = "EnqueuedTransportURI"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_SeekMode state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPESeekMode As String = "A_ARG_TYPE_SeekMode"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_SeekTarget state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPESeekTarget As String = "A_ARG_TYPE_SeekTarget"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_InstanceID state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEInstanceID As String = "A_ARG_TYPE_InstanceID"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_MemberList state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEMemberList As String = "A_ARG_TYPE_MemberList"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_TransportSettings state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPETransportSettings As String = "A_ARG_TYPE_TransportSettings"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_CurrentAVTransportURI state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPECurrentAVTransportURI As String = "A_ARG_TYPE_CurrentAVTransportURI"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_SourceState state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPESourceState As String = "A_ARG_TYPE_SourceState"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_Queue state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEQueue As String = "A_ARG_TYPE_Queue"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_MemberID state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEMemberID As String = "A_ARG_TYPE_MemberID"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_URI state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEURI As String = "A_ARG_TYPE_URI"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_LIST_URI state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPELISTURI As String = "A_ARG_TYPE_LIST_URI"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_URIMetaData state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEURIMetaData As String = "A_ARG_TYPE_URIMetaData"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_LIST_URIMetaData state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPELISTURIMetaData As String = "A_ARG_TYPE_LIST_URIMetaData"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_ObjectID state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEObjectID As String = "A_ARG_TYPE_ObjectID"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_GroupID state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEGroupID As String = "A_ARG_TYPE_GroupID"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_TrackNumber state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPETrackNumber As String = "A_ARG_TYPE_TrackNumber"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_NumTracks state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPENumTracks As String = "A_ARG_TYPE_NumTracks"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_NumTracksChange state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPENumTracksChange As String = "A_ARG_TYPE_NumTracksChange"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_EnqueueAsNext state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEEnqueueAsNext As String = "A_ARG_TYPE_EnqueueAsNext"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_SavedQueueTitle state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPESavedQueueTitle As String = "A_ARG_TYPE_SavedQueueTitle"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_ResumePlayback state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEResumePlayback As String = "A_ARG_TYPE_ResumePlayback"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_ISO8601Time state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEISO8601Time As String = "A_ARG_TYPE_ISO8601Time"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_AlarmVolume state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEAlarmVolume As String = "A_ARG_TYPE_AlarmVolume"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_AlarmIncludeLinkedZones state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEAlarmIncludeLinkedZones As String = "A_ARG_TYPE_AlarmIncludeLinkedZones"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_ResetVolumeAfter state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEResetVolumeAfter As String = "A_ARG_TYPE_ResetVolumeAfter"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_SleepTimerState state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPESleepTimerState As String = "A_ARG_TYPE_SleepTimerState"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_AlarmState state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEAlarmState As String = "A_ARG_TYPE_AlarmState"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_StreamRestartState state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPEStreamRestartState As String = "A_ARG_TYPE_StreamRestartState"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_RejoinGroup state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPERejoinGroup As String = "A_ARG_TYPE_RejoinGroup"

            ''' <summary>
            ''' The name for the QueueUpdateID state variable.
            ''' </summary>
            Protected Const csStateVar_QueueUpdateID As String = "QueueUpdateID"

            ''' <summary>
            ''' The name for the A_ARG_TYPE_TrackList state variable.
            ''' </summary>
            Protected Const csStateVar_AARGTYPETrackList As String = "A_ARG_TYPE_TrackList"

            ''' <summary>
            ''' The string value for the allowed value NONE of the PlaybackStorageMedium state variable.
            ''' </summary>
            Protected Const csAllowedVal_PlaybackStorageMedium_NONE As String = "NONE"

            ''' <summary>
            ''' The string value for the allowed value NETWORK of the PlaybackStorageMedium state variable.
            ''' </summary>
            Protected Const csAllowedVal_PlaybackStorageMedium_NETWORK As String = "NETWORK"

            ''' <summary>
            ''' The string value for the allowed value NONE of the RecordStorageMedium state variable.
            ''' </summary>
            Protected Const csAllowedVal_RecordStorageMedium_NONE As String = "NONE"

            ''' <summary>
            ''' The string value for the allowed value NORMAL of the CurrentPlayMode state variable.
            ''' </summary>
            Protected Const csAllowedVal_CurrentPlayMode_NORMAL As String = "NORMAL"

            ''' <summary>
            ''' The string value for the allowed value REPEAT_ALL of the CurrentPlayMode state variable.
            ''' </summary>
            Protected Const csAllowedVal_CurrentPlayMode_REPEATALL As String = "REPEAT_ALL"

            ''' <summary>
            ''' The string value for the allowed value SHUFFLE_NOREPEAT of the CurrentPlayMode state variable.
            ''' </summary>
            Protected Const csAllowedVal_CurrentPlayMode_SHUFFLENOREPEAT As String = "SHUFFLE_NOREPEAT"

            ''' <summary>
            ''' The string value for the allowed value SHUFFLE of the CurrentPlayMode state variable.
            ''' </summary>
            Protected Const csAllowedVal_CurrentPlayMode_SHUFFLE As String = "SHUFFLE"

            ''' <summary>
            ''' The string value for the allowed value 1 of the TransportPlaySpeed state variable.
            ''' </summary>
            Protected Const csAllowedVal_TransportPlaySpeed__1 As String = "1"

            ''' <summary>
            ''' The string value for the allowed value TRACK_NR of the A_ARG_TYPE_SeekMode state variable.
            ''' </summary>
            Protected Const csAllowedVal_AARGTYPESeekMode_TRACKNR As String = "TRACK_NR"

            ''' <summary>
            ''' The string value for the allowed value REL_TIME of the A_ARG_TYPE_SeekMode state variable.
            ''' </summary>
            Protected Const csAllowedVal_AARGTYPESeekMode_RELTIME As String = "REL_TIME"

            ''' <summary>
            ''' The string value for the allowed value SECTION of the A_ARG_TYPE_SeekMode state variable.
            ''' </summary>
            Protected Const csAllowedVal_AARGTYPESeekMode_SECTION As String = "SECTION"

            ''' <summary>
            ''' The name for the SetAVTransportURI action.
            ''' </summary>
            Protected Const csAction_SetAVTransportURI As String = "SetAVTransportURI"

            ''' <summary>
            ''' The name for the SetNextAVTransportURI action.
            ''' </summary>
            Protected Const csAction_SetNextAVTransportURI As String = "SetNextAVTransportURI"

            ''' <summary>
            ''' The name for the AddURIToQueue action.
            ''' </summary>
            Protected Const csAction_AddURIToQueue As String = "AddURIToQueue"

            ''' <summary>
            ''' The name for the AddMultipleURIsToQueue action.
            ''' </summary>
            Protected Const csAction_AddMultipleURIsToQueue As String = "AddMultipleURIsToQueue"

            ''' <summary>
            ''' The name for the ReorderTracksInQueue action.
            ''' </summary>
            Protected Const csAction_ReorderTracksInQueue As String = "ReorderTracksInQueue"

            ''' <summary>
            ''' The name for the RemoveTrackFromQueue action.
            ''' </summary>
            Protected Const csAction_RemoveTrackFromQueue As String = "RemoveTrackFromQueue"

            ''' <summary>
            ''' The name for the RemoveTrackRangeFromQueue action.
            ''' </summary>
            Protected Const csAction_RemoveTrackRangeFromQueue As String = "RemoveTrackRangeFromQueue"

            ''' <summary>
            ''' The name for the RemoveAllTracksFromQueue action.
            ''' </summary>
            Protected Const csAction_RemoveAllTracksFromQueue As String = "RemoveAllTracksFromQueue"

            ''' <summary>
            ''' The name for the SaveQueue action.
            ''' </summary>
            Protected Const csAction_SaveQueue As String = "SaveQueue"

            ''' <summary>
            ''' The name for the BackupQueue action.
            ''' </summary>
            Protected Const csAction_BackupQueue As String = "BackupQueue"

            ''' <summary>
            ''' The name for the CreateSavedQueue action.
            ''' </summary>
            Protected Const csAction_CreateSavedQueue As String = "CreateSavedQueue"

            ''' <summary>
            ''' The name for the AddURIToSavedQueue action.
            ''' </summary>
            Protected Const csAction_AddURIToSavedQueue As String = "AddURIToSavedQueue"

            ''' <summary>
            ''' The name for the ReorderTracksInSavedQueue action.
            ''' </summary>
            Protected Const csAction_ReorderTracksInSavedQueue As String = "ReorderTracksInSavedQueue"

            ''' <summary>
            ''' The name for the GetMediaInfo action.
            ''' </summary>
            Protected Const csAction_GetMediaInfo As String = "GetMediaInfo"

            ''' <summary>
            ''' The name for the GetTransportInfo action.
            ''' </summary>
            Protected Const csAction_GetTransportInfo As String = "GetTransportInfo"

            ''' <summary>
            ''' The name for the GetPositionInfo action.
            ''' </summary>
            Protected Const csAction_GetPositionInfo As String = "GetPositionInfo"

            ''' <summary>
            ''' The name for the GetDeviceCapabilities action.
            ''' </summary>
            Protected Const csAction_GetDeviceCapabilities As String = "GetDeviceCapabilities"

            ''' <summary>
            ''' The name for the GetTransportSettings action.
            ''' </summary>
            Protected Const csAction_GetTransportSettings As String = "GetTransportSettings"

            ''' <summary>
            ''' The name for the GetCrossfadeMode action.
            ''' </summary>
            Protected Const csAction_GetCrossfadeMode As String = "GetCrossfadeMode"

            ''' <summary>
            ''' The name for the Stop action.
            ''' </summary>
            Protected Const csAction_Stop As String = "Stop"

            ''' <summary>
            ''' The name for the Play action.
            ''' </summary>
            Protected Const csAction_Play As String = "Play"

            ''' <summary>
            ''' The name for the Pause action.
            ''' </summary>
            Protected Const csAction_Pause As String = "Pause"

            ''' <summary>
            ''' The name for the Seek action.
            ''' </summary>
            Protected Const csAction_Seek As String = "Seek"

            ''' <summary>
            ''' The name for the Next action.
            ''' </summary>
            Protected Const csAction_Next As String = "Next"

            ''' <summary>
            ''' The name for the NextProgrammedRadioTracks action.
            ''' </summary>
            Protected Const csAction_NextProgrammedRadioTracks As String = "NextProgrammedRadioTracks"

            ''' <summary>
            ''' The name for the Previous action.
            ''' </summary>
            Protected Const csAction_Previous As String = "Previous"

            ''' <summary>
            ''' The name for the NextSection action.
            ''' </summary>
            Protected Const csAction_NextSection As String = "NextSection"

            ''' <summary>
            ''' The name for the PreviousSection action.
            ''' </summary>
            Protected Const csAction_PreviousSection As String = "PreviousSection"

            ''' <summary>
            ''' The name for the SetPlayMode action.
            ''' </summary>
            Protected Const csAction_SetPlayMode As String = "SetPlayMode"

            ''' <summary>
            ''' The name for the SetCrossfadeMode action.
            ''' </summary>
            Protected Const csAction_SetCrossfadeMode As String = "SetCrossfadeMode"

            ''' <summary>
            ''' The name for the NotifyDeletedURI action.
            ''' </summary>
            Protected Const csAction_NotifyDeletedURI As String = "NotifyDeletedURI"

            ''' <summary>
            ''' The name for the GetCurrentTransportActions action.
            ''' </summary>
            Protected Const csAction_GetCurrentTransportActions As String = "GetCurrentTransportActions"

            ''' <summary>
            ''' The name for the BecomeCoordinatorOfStandaloneGroup action.
            ''' </summary>
            Protected Const csAction_BecomeCoordinatorOfStandaloneGroup As String = "BecomeCoordinatorOfStandaloneGroup"

            ''' <summary>
            ''' The name for the DelegateGroupCoordinationTo action.
            ''' </summary>
            Protected Const csAction_DelegateGroupCoordinationTo As String = "DelegateGroupCoordinationTo"

            ''' <summary>
            ''' The name for the BecomeGroupCoordinator action.
            ''' </summary>
            Protected Const csAction_BecomeGroupCoordinator As String = "BecomeGroupCoordinator"

            ''' <summary>
            ''' The name for the BecomeGroupCoordinatorAndSource action.
            ''' </summary>
            Protected Const csAction_BecomeGroupCoordinatorAndSource As String = "BecomeGroupCoordinatorAndSource"

            ''' <summary>
            ''' The name for the ChangeCoordinator action.
            ''' </summary>
            Protected Const csAction_ChangeCoordinator As String = "ChangeCoordinator"

            ''' <summary>
            ''' The name for the ChangeTransportSettings action.
            ''' </summary>
            Protected Const csAction_ChangeTransportSettings As String = "ChangeTransportSettings"

            ''' <summary>
            ''' The name for the ConfigureSleepTimer action.
            ''' </summary>
            Protected Const csAction_ConfigureSleepTimer As String = "ConfigureSleepTimer"

            ''' <summary>
            ''' The name for the GetRemainingSleepTimerDuration action.
            ''' </summary>
            Protected Const csAction_GetRemainingSleepTimerDuration As String = "GetRemainingSleepTimerDuration"

            ''' <summary>
            ''' The name for the RunAlarm action.
            ''' </summary>
            Protected Const csAction_RunAlarm As String = "RunAlarm"

            ''' <summary>
            ''' The name for the StartAutoplay action.
            ''' </summary>
            Protected Const csAction_StartAutoplay As String = "StartAutoplay"

            ''' <summary>
            ''' The name for the GetRunningAlarmProperties action.
            ''' </summary>
            Protected Const csAction_GetRunningAlarmProperties As String = "GetRunningAlarmProperties"

            ''' <summary>
            ''' The name for the SnoozeAlarm action.
            ''' </summary>
            Protected Const csAction_SnoozeAlarm As String = "SnoozeAlarm"

#End Region

#Region "Public Constants"

            ''' <summary>
            ''' The service type identifier for the AVTransport1 service.
            ''' </summary>
            Public Const ServiceType As String = "urn:schemas-upnp-org:service:AVTransport:1"

#End Region

#Region "Enumerations"

            ''' <summary>
            ''' The enumeration type to hold a value for the TransportState state variable.
            ''' </summary>
            Public Enum TransportStateEnum

                ''' <summary>
                ''' The TransportState state var 'STOPPED' value.
                ''' </summary>
                STOPPED

                ''' <summary>
                ''' The TransportState state var 'PLAYING' value.
                ''' </summary>
                PLAYING

                ''' <summary>
                ''' The TransportState state var 'PAUSEDPLAYBACK' value.
                ''' </summary>
                PAUSEDPLAYBACK

                ''' <summary>
                ''' The TransportState state var 'TRANSITIONING' value.
                ''' </summary>
                TRANSITIONING

                ''' <summary>
                ''' Value describing an invalid or unknown TransportState value.
                ''' </summary>
                _Unknown
            End Enum

            ''' <summary>
            ''' The enumeration type to hold a value for the PlaybackStorageMedium state variable.
            ''' </summary>
            Public Enum PlaybackStorageMediumEnum

                ''' <summary>
                ''' The PlaybackStorageMedium state var 'NONE' value.
                ''' </summary>
                NONE

                ''' <summary>
                ''' The PlaybackStorageMedium state var 'NETWORK' value.
                ''' </summary>
                NETWORK

                ''' <summary>
                ''' Value describing an invalid or unknown PlaybackStorageMedium value.
                ''' </summary>
                _Unknown
            End Enum

            ''' <summary>
            ''' The enumeration type to hold a value for the RecordStorageMedium state variable.
            ''' </summary>
            Public Enum RecordStorageMediumEnum

                ''' <summary>
                ''' The RecordStorageMedium state var 'NONE' value.
                ''' </summary>
                NONE

                ''' <summary>
                ''' Value describing an invalid or unknown RecordStorageMedium value.
                ''' </summary>
                _Unknown
            End Enum

            ''' <summary>
            ''' The enumeration type to hold a value for the CurrentPlayMode state variable.
            ''' </summary>
            Public Enum CurrentPlayModeEnum

                ''' <summary>
                ''' The CurrentPlayMode state var 'NORMAL' value.
                ''' </summary>
                NORMAL

                ''' <summary>
                ''' The CurrentPlayMode state var 'REPEATALL' value.
                ''' </summary>
                REPEATALL

                ''' <summary>
                ''' The CurrentPlayMode state var 'SHUFFLENOREPEAT' value.
                ''' </summary>
                SHUFFLENOREPEAT

                ''' <summary>
                ''' The CurrentPlayMode state var 'SHUFFLE' value.
                ''' </summary>
                SHUFFLE

                ''' <summary>
                ''' Value describing an invalid or unknown CurrentPlayMode value.
                ''' </summary>
                _Unknown
            End Enum

            ''' <summary>
            ''' The enumeration type to hold a value for the TransportPlaySpeed state variable.
            ''' </summary>
            Public Enum TransportPlaySpeedEnum

                ''' <summary>
                ''' The TransportPlaySpeed state var '_1' value.
                ''' </summary>
                _1

                ''' <summary>
                ''' Value describing an invalid or unknown TransportPlaySpeed value.
                ''' </summary>
                _Unknown
            End Enum

            ''' <summary>
            ''' The enumeration type to hold a value for the AARGTYPESeekMode state variable.
            ''' </summary>
            Public Enum AARGTYPESeekModeEnum

                ''' <summary>
                ''' The AARGTYPESeekMode state var 'TRACKNR' value.
                ''' </summary>
                TRACKNR

                ''' <summary>
                ''' The AARGTYPESeekMode state var 'RELTIME' value.
                ''' </summary>
                RELTIME

                ''' <summary>
                ''' The AARGTYPESeekMode state var 'SECTION' value.
                ''' </summary>
                SECTION

                ''' <summary>
                ''' Value describing an invalid or unknown AARGTYPESeekMode value.
                ''' </summary>
                _Unknown
            End Enum

#End Region

#Region "Initialisation"

            ''' <summary>
            ''' Creates a new instance of the AVTransport1 service from a base service.
            ''' </summary>
            ''' <param name="service">The base service to create the AVTransport1 service from.</param>
            Public Sub New(service As Service)
                MyBase.New(service)
                _service = service

                '// create a current and next track data class and inject a copy of Me so that we can walk up from the TrackData class to its parent AVTransport
                CurrentTrackData = New TrackData(Me)
                NextTrackData = New TrackData(Me)
                
                If Not CanAccess(service) Then
                    Throw New NotSupportedException()
                End If
            End Sub

#End Region

#Region "Public Static Methods"

            ''' <summary>
            ''' Determines if a service is compatible with this service class.
            ''' </summary>
            ''' <param name="service">The base service to test for compatibility with.</param>
            ''' <returns>True if the service type is compatible, false otherwise.</returns>
            Public Shared Function CompatibleWith(service As Service) As Boolean
                Return service.ServiceTypeIdentifier = ServiceType
            End Function

            ''' <summary>
            ''' Returns AVTransport1 objects for each compatible service in a collection of Services as an array.
            ''' </summary>
            ''' <param name="services">The base services to create the AVTransport1 object for.</param>
            ''' <returns>An array of AVTransport1 objects containing the newly created services.</returns>
            Public Shared Function FromServices(services As ManagedUPnP.Services) As AVTransport()
                Dim lalReturn As New ArrayList()

                For Each lsService As Service In services
                    If lsService IsNot Nothing AndAlso CompatibleWith(lsService) Then
                        lalReturn.Add(New AVTransport(lsService))
                    End If
                Next

                Return DirectCast(lalReturn.ToArray(GetType(AVTransport)), AVTransport())
            End Function

            ''' <summary>
            ''' Returns AVTransport1 objects for each compatible service found in a devices child services.
            ''' </summary>
            ''' <param name="baseDevice">The base device to consider.</param>
            ''' <param name="includingChildDevices">True to search all child devices recursively, false to use direct children only.</param>
            ''' <returns>An array of AVTransport1 objects containing the newly created services.</returns>
            Public Shared Function SearchAndCreate(baseDevice As ManagedUPnP.Device, includingChildDevices As Boolean) As AVTransport()
                Return FromServices(New ManagedUPnP.Services(baseDevice, ServiceType, includingChildDevices))
            End Function

            ''' <summary>
            ''' Returns AVTransport1 objects for each compatible services discovered in a synchronous manner.
            ''' </summary>
            ''' <returns>An array of AVTransport1 objects containing the newly created services.</returns>
            Public Shared Function DiscoverAndCreate() As AVTransport()
                Return FromServices(ManagedUPnP.Discovery.FindServices(ServiceType))
            End Function

#End Region

#Region "Event Handlers"

            ''' <summary>
            ''' Occurs when the service notifies that the LastChange state variable has changed its value.
            ''' </summary>
            Public Event LastChangeChanged As StateVariableChangedEventHandler(Of String)


#End Region

#Region "Event Callers"

            ''' <summary>
            ''' Raises the LastChangeChanged event.
            ''' </summary>
            ''' <param name="e">The event arguments.</param>
            Protected Overridable Sub OnLastChangeChanged(e As StateVariableChangedEventArgs(Of String))
                Debug.Print("AVTransport1: LastChangeChanged: " + e.StateVarName + "|") '+ e.StateVarValue
                Dim doc As New XPathDocument(New StringReader(e.StateVarValue))
                Dim nav As XPathNavigator = doc.CreateNavigator
                'Dim currentTrackMetadata As XPathNavigator = nav.SelectSingleNode(XPath.Expressions.CurrentTrackMetaData)
                'If Not currentTrackMetadata Is Nothing Then
                '    CurrentTrackData.TrackMetaData = currentTrackMetadata

                '    Dim val As XPathNavigator = currentTrackMetadata.SelectSingleNode(UPnP.XPath.Expressions.ValueAttributes)
                '    Debug.Print(currentTrackMetadata.Name & " | " & val.Value)
                'End If
                Dim nodeName As String

                For Each node As XPathNavigator In nav.Select(UPnP.XPath.Expressions.EventElements)
                    Dim val As XPathNavigator = node.SelectSingleNode(UPnP.XPath.Expressions.ValueAttributes)
                    Debug.Print(node.Name & " | " & val.InnerXml)
                    Select Case node.Name
                        Case "CurrentTrackMetaData", "r:NextTrackMetaData"



                            Dim metaData As XPathNavigator = New XPathDocument(New StringReader(val.InnerXml)).CreateNavigator
                            If Not metaData Is Nothing Then
                                If node.Name = "CurrentTrackMetaData" Then
                                    CurrentTrackData.ParseTrackMetaData(metaData, DocumentURL)
                                    'CurrentTrackData.TrackMetaData = metaData
                                    Debug.Print("Current Track Meta Data Extracted")
                                Else
                                    NextTrackData.ParseTrackMetaData(metaData, DocumentURL)
                                    'NextTrackMetaData.TrackMetaData = metaData
                                    Debug.Print("NEXT Track Meta Data Extracted")
                                End If
                                '// is this where this should go? should be moved into timer fnction!
                                GetPositionInfo(0)

                            End If

                        Case Else
                            Try
                                If val.Value <> "NOT_IMPLEMENTED" Then
                                    If node.Name.StartsWith("r:") Then
                                        nodeName = node.Name.Remove(0, 2)
                                    Else
                                        nodeName = node.Name
                                    End If
                                    CallByName(Me, nodeName, CallType.Set, val.Value)
                                End If

                            Catch ex As Exception
                                Debug.Print(String.Format("ERROR SETTING PROPERTY: {0} to {1} EX:{2}", node.Name, val.Value, ex.Message))

                            End Try
                            '

                    End Select

                Next



                RaiseEvent LastChangeChanged(Me, e)
            End Sub

            ''' <summary>
            ''' Raises the StateVariableChanged event.
            ''' </summary>
            ''' <param name="a">The event arguments.</param>
            Protected Overrides Sub OnStateVariableChanged(a As StateVariableChangedEventArgs)
                Try
                    ' Determine state variable that is changing
                    Debug.Print("AVTransport1: OnstateVariable: " + a.StateVarName)
                    Select Case a.StateVarName

                        Case csStateVar_LastChange
                            ' Raise the event for the LastChange state variable
                            OnLastChangeChanged( _
                             New StateVariableChangedEventArgs(Of String)( _
                              csStateVar_LastChange, _
                              DirectCast(a.StateVarValue, String)))
                            Exit Select

                        Case Else
                            Exit Select

                    End Select
                Catch
                End Try

                MyBase.OnStateVariableChanged(a)
            End Sub

            ''' <summary>
            ''' Raises the ServiceInstanceDied event.
            ''' </summary>
            ''' <param name="e">The event arguments.</param>
            Private Sub AVTransport1_ServiceInstanceDied(sender As Object, e As ManagedUPnP.ServiceInstanceDiedEventArgs) Handles Me.ServiceInstanceDied
                Debug.Print("AVTransport1: ServiceInstanceDied: " + e.ToString)
                'RaiseEvent 
            End Sub

#End Region

#Region "Protected Methods"

            ''' <summary>
            ''' Parses a string value from the TransportState state var and returns the enumeration value for it.
            ''' </summary>
            ''' <param name="value">The string value to parse.</param>
            ''' <returns>The parsed value or TransportStateEnum._Unknown if not parsable.</returns>
            Protected Function ParseTransportState(value As String) As TransportStateEnum
                Select Case value
                    Case csAllowedVal_TransportState_STOPPED
                        Return TransportStateEnum.STOPPED
                    Case csAllowedVal_TransportState_PLAYING
                        Return TransportStateEnum.PLAYING
                    Case csAllowedVal_TransportState_PAUSEDPLAYBACK
                        Return TransportStateEnum.PAUSEDPLAYBACK
                    Case csAllowedVal_TransportState_TRANSITIONING
                        Return TransportStateEnum.TRANSITIONING
                    Case Else
                        Return TransportStateEnum._Unknown

                End Select
            End Function

            ''' <summary>
            ''' Gets the string value for the TransportState state var from its enumeration value.
            ''' </summary>
            ''' <param name="value">The enumeration value to get the string value for.</param>
            ''' <returns>The string value for the enumeration, or string.empty if TransportStateEnum._Unknown or out of range.</returns>
            Protected Function ToStringTransportState(value As TransportStateEnum) As String
                Select Case value
                    Case TransportStateEnum.STOPPED
                        Return csAllowedVal_TransportState_STOPPED
                    Case TransportStateEnum.PLAYING
                        Return csAllowedVal_TransportState_PLAYING
                    Case TransportStateEnum.PAUSEDPLAYBACK
                        Return csAllowedVal_TransportState_PAUSEDPLAYBACK
                    Case TransportStateEnum.TRANSITIONING
                        Return csAllowedVal_TransportState_TRANSITIONING
                    Case Else
                        Return String.Empty

                End Select
            End Function

            ''' <summary>
            ''' Parses a string value from the PlaybackStorageMedium state var and returns the enumeration value for it.
            ''' </summary>
            ''' <param name="value">The string value to parse.</param>
            ''' <returns>The parsed value or PlaybackStorageMediumEnum._Unknown if not parsable.</returns>
            Protected Function ParsePlaybackStorageMedium(value As String) As PlaybackStorageMediumEnum
                Select Case value
                    Case csAllowedVal_PlaybackStorageMedium_NONE
                        Return PlaybackStorageMediumEnum.NONE
                    Case csAllowedVal_PlaybackStorageMedium_NETWORK
                        Return PlaybackStorageMediumEnum.NETWORK
                    Case Else
                        Return PlaybackStorageMediumEnum._Unknown

                End Select
            End Function

            ''' <summary>
            ''' Gets the string value for the PlaybackStorageMedium state var from its enumeration value.
            ''' </summary>
            ''' <param name="value">The enumeration value to get the string value for.</param>
            ''' <returns>The string value for the enumeration, or string.empty if PlaybackStorageMediumEnum._Unknown or out of range.</returns>
            Protected Function ToStringPlaybackStorageMedium(value As PlaybackStorageMediumEnum) As String
                Select Case value
                    Case PlaybackStorageMediumEnum.NONE
                        Return csAllowedVal_PlaybackStorageMedium_NONE
                    Case PlaybackStorageMediumEnum.NETWORK
                        Return csAllowedVal_PlaybackStorageMedium_NETWORK
                    Case Else
                        Return String.Empty

                End Select
            End Function

            ''' <summary>
            ''' Parses a string value from the RecordStorageMedium state var and returns the enumeration value for it.
            ''' </summary>
            ''' <param name="value">The string value to parse.</param>
            ''' <returns>The parsed value or RecordStorageMediumEnum._Unknown if not parsable.</returns>
            Protected Function ParseRecordStorageMedium(value As String) As RecordStorageMediumEnum
                Select Case value
                    Case csAllowedVal_RecordStorageMedium_NONE
                        Return RecordStorageMediumEnum.NONE
                    Case Else
                        Return RecordStorageMediumEnum._Unknown

                End Select
            End Function

            ''' <summary>
            ''' Gets the string value for the RecordStorageMedium state var from its enumeration value.
            ''' </summary>
            ''' <param name="value">The enumeration value to get the string value for.</param>
            ''' <returns>The string value for the enumeration, or string.empty if RecordStorageMediumEnum._Unknown or out of range.</returns>
            Protected Function ToStringRecordStorageMedium(value As RecordStorageMediumEnum) As String
                Select Case value
                    Case RecordStorageMediumEnum.NONE
                        Return csAllowedVal_RecordStorageMedium_NONE
                    Case Else
                        Return String.Empty

                End Select
            End Function

            ''' <summary>
            ''' Parses a string value from the CurrentPlayMode state var and returns the enumeration value for it.
            ''' </summary>
            ''' <param name="value">The string value to parse.</param>
            ''' <returns>The parsed value or CurrentPlayModeEnum._Unknown if not parsable.</returns>
            Protected Function ParseCurrentPlayMode(value As String) As CurrentPlayModeEnum
                Select Case value
                    Case csAllowedVal_CurrentPlayMode_NORMAL
                        Return CurrentPlayModeEnum.NORMAL
                    Case csAllowedVal_CurrentPlayMode_REPEATALL
                        Return CurrentPlayModeEnum.REPEATALL
                    Case csAllowedVal_CurrentPlayMode_SHUFFLENOREPEAT
                        Return CurrentPlayModeEnum.SHUFFLENOREPEAT
                    Case csAllowedVal_CurrentPlayMode_SHUFFLE
                        Return CurrentPlayModeEnum.SHUFFLE
                    Case Else
                        Return CurrentPlayModeEnum._Unknown

                End Select
            End Function

            ''' <summary>
            ''' Gets the string value for the CurrentPlayMode state var from its enumeration value.
            ''' </summary>
            ''' <param name="value">The enumeration value to get the string value for.</param>
            ''' <returns>The string value for the enumeration, or string.empty if CurrentPlayModeEnum._Unknown or out of range.</returns>
            Protected Function ToStringCurrentPlayMode(value As CurrentPlayModeEnum) As String
                Select Case value
                    Case CurrentPlayModeEnum.NORMAL
                        Return csAllowedVal_CurrentPlayMode_NORMAL
                    Case CurrentPlayModeEnum.REPEATALL
                        Return csAllowedVal_CurrentPlayMode_REPEATALL
                    Case CurrentPlayModeEnum.SHUFFLENOREPEAT
                        Return csAllowedVal_CurrentPlayMode_SHUFFLENOREPEAT
                    Case CurrentPlayModeEnum.SHUFFLE
                        Return csAllowedVal_CurrentPlayMode_SHUFFLE
                    Case Else
                        Return String.Empty

                End Select
            End Function

            ''' <summary>
            ''' Parses a string value from the TransportPlaySpeed state var and returns the enumeration value for it.
            ''' </summary>
            ''' <param name="value">The string value to parse.</param>
            ''' <returns>The parsed value or TransportPlaySpeedEnum._Unknown if not parsable.</returns>
            Protected Function ParseTransportPlaySpeed(value As String) As TransportPlaySpeedEnum
                Select Case value
                    Case csAllowedVal_TransportPlaySpeed__1
                        Return TransportPlaySpeedEnum._1
                    Case Else
                        Return TransportPlaySpeedEnum._Unknown

                End Select
            End Function

            ''' <summary>
            ''' Gets the string value for the TransportPlaySpeed state var from its enumeration value.
            ''' </summary>
            ''' <param name="value">The enumeration value to get the string value for.</param>
            ''' <returns>The string value for the enumeration, or string.empty if TransportPlaySpeedEnum._Unknown or out of range.</returns>
            Protected Function ToStringTransportPlaySpeed(value As TransportPlaySpeedEnum) As String
                Select Case value
                    Case TransportPlaySpeedEnum._1
                        Return csAllowedVal_TransportPlaySpeed__1
                    Case Else
                        Return String.Empty

                End Select
            End Function

            ''' <summary>
            ''' Parses a string value from the AARGTYPESeekMode state var and returns the enumeration value for it.
            ''' </summary>
            ''' <param name="value">The string value to parse.</param>
            ''' <returns>The parsed value or AARGTYPESeekModeEnum._Unknown if not parsable.</returns>
            Protected Function ParseAARGTYPESeekMode(value As String) As AARGTYPESeekModeEnum
                Select Case value
                    Case csAllowedVal_AARGTYPESeekMode_TRACKNR
                        Return AARGTYPESeekModeEnum.TRACKNR
                    Case csAllowedVal_AARGTYPESeekMode_RELTIME
                        Return AARGTYPESeekModeEnum.RELTIME
                    Case csAllowedVal_AARGTYPESeekMode_SECTION
                        Return AARGTYPESeekModeEnum.SECTION
                    Case Else
                        Return AARGTYPESeekModeEnum._Unknown

                End Select
            End Function

            ''' <summary>
            ''' Gets the string value for the AARGTYPESeekMode state var from its enumeration value.
            ''' </summary>
            ''' <param name="value">The enumeration value to get the string value for.</param>
            ''' <returns>The string value for the enumeration, or string.empty if AARGTYPESeekModeEnum._Unknown or out of range.</returns>
            Protected Function ToStringAARGTYPESeekMode(value As AARGTYPESeekModeEnum) As String
                Select Case value
                    Case AARGTYPESeekModeEnum.TRACKNR
                        Return csAllowedVal_AARGTYPESeekMode_TRACKNR
                    Case AARGTYPESeekModeEnum.RELTIME
                        Return csAllowedVal_AARGTYPESeekMode_RELTIME
                    Case AARGTYPESeekModeEnum.SECTION
                        Return csAllowedVal_AARGTYPESeekMode_SECTION
                    Case Else
                        Return String.Empty

                End Select
            End Function

#End Region

#Region "UPnP Data Request Functions"

            ''' <summary>
            ''' Executes the GetMediaInfo action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            Public Sub GetMediaInfo(instanceID As UInt32)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                Dim loOut() As Object = InvokeAction(csAction_GetMediaInfo, loIn)

                NumberOfTracks = DirectCast(loOut(0), UInt32)
                CurrentMediaDuration = DirectCast(loOut(1), String)
                AVTransportURI = DirectCast(loOut(2), String)
                AVTransportURIMetaData = DirectCast(loOut(3), String)
                NextAVTransportURI = DirectCast(loOut(4), String)
                NextAVTransportURIMetaData = DirectCast(loOut(5), String)
                PlaybackStorageMedium = ParsePlaybackStorageMedium(DirectCast(loOut(6), String))
                RecordStorageMedium = ParseRecordStorageMedium(DirectCast(loOut(7), String))
                RecordMediumWriteStatus = DirectCast(loOut(8), String)
            End Sub

            Public Sub GetMediaInfoOLD(instanceID As UInt32, ByRef nrTracks As UInt32, ByRef mediaDuration As String, ByRef currentURI As String, ByRef currentURIMetaData As String, ByRef nextURI As String, ByRef nextURIMetaData As String, ByRef playMedium As PlaybackStorageMediumEnum, ByRef recordMedium As RecordStorageMediumEnum, ByRef writeStatus As String)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                Dim loOut() As Object = InvokeAction(csAction_GetMediaInfo, loIn)

                nrTracks = DirectCast(loOut(0), UInt32)
                mediaDuration = DirectCast(loOut(1), String)
                currentURI = DirectCast(loOut(2), String)
                currentURIMetaData = DirectCast(loOut(3), String)
                nextURI = DirectCast(loOut(4), String)
                nextURIMetaData = DirectCast(loOut(5), String)
                playMedium = ParsePlaybackStorageMedium(DirectCast(loOut(6), String))
                recordMedium = ParseRecordStorageMedium(DirectCast(loOut(7), String))
                writeStatus = DirectCast(loOut(8), String)
            End Sub



            ''' <summary>
            ''' Executes the GetPositionInfo action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            Public Sub GetPositionInfo(instanceID As UInt32)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                Dim loOut() As Object = InvokeAction(csAction_GetPositionInfo, loIn)

                CurrentTrack = DirectCast(loOut(0), UInt32)
                CurrentTrackDuration = DirectCast(loOut(1), String)
                CurrentTrackMetaData = DirectCast(loOut(2), String)
                CurrentTrackURI = DirectCast(loOut(3), String)
                RelativeTimePosition = DirectCast(loOut(4), String)
                AbsoluteTimePosition = DirectCast(loOut(5), String)
                RelativeCounterPosition = DirectCast(loOut(6), Int32)
                AbsoluteCounterPosition = DirectCast(loOut(7), Int32)
                'Dim a As New StateVariableChangedEventArgs(Of String)("LastChangeX", CurrentTrackMetaData)
                'OnLastChangeChanged(a)
                Me.CurrentTrackData.ParseTrackMetaData(CurrentTrackMetaData, DocumentURL)
                'Me.CurrentTrackData.TrackMetaData = CurrentTrackMetaData
            End Sub

            ''' <summary>
            ''' Executes the GetTransportInfo action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            ''' <param name="currentTransportState">Out value for the CurrentTransportState action parameter.</param>
            ''' <param name="currentTransportStatus">Out value for the CurrentTransportStatus action parameter.</param>
            ''' <param name="currentSpeed">Out value for the CurrentSpeed action parameter.</param>
            Public Sub GetTransportInfo(instanceID As UInt32, ByRef currentTransportState As TransportStateEnum, ByRef currentTransportStatus As String, ByRef currentSpeed As TransportPlaySpeedEnum)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                Dim loOut() As Object = InvokeAction(csAction_GetTransportInfo, loIn)

                TransportState = DirectCast(loOut(0), String)
                TransportStatus = DirectCast(loOut(1), String)
                TransportPlaySpeed = DirectCast(loOut(2), String)
                iTransportState = ParseTransportState(TransportState)
                iTransportPlaySpeed = ParseTransportPlaySpeed(TransportPlaySpeed)
            End Sub

            Public Sub GetTransportInfoOLD(instanceID As UInt32, ByRef currentTransportState As TransportStateEnum, ByRef currentTransportStatus As String, ByRef currentSpeed As TransportPlaySpeedEnum)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                Dim loOut() As Object = InvokeAction(csAction_GetTransportInfo, loIn)

                currentTransportState = ParseTransportState(DirectCast(loOut(0), String))
                currentTransportStatus = DirectCast(loOut(1), String)
                currentSpeed = ParseTransportPlaySpeed(DirectCast(loOut(2), String))
            End Sub

            ''' <summary>
            ''' Executes the GetDeviceCapabilities action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            ''' <param name="playMedia">Out value for the PlayMedia action parameter.</param>
            ''' <param name="recMedia">Out value for the RecMedia action parameter.</param>
            ''' <param name="recQualityModes">Out value for the RecQualityModes action parameter.</param>
            Public Sub GetDeviceCapabilities(instanceID As UInt32, ByRef playMedia As String, ByRef recMedia As String, ByRef recQualityModes As String)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                Dim loOut() As Object = InvokeAction(csAction_GetDeviceCapabilities, loIn)

                playMedia = DirectCast(loOut(0), String)
                recMedia = DirectCast(loOut(1), String)
                recQualityModes = DirectCast(loOut(2), String)
            End Sub

            ''' <summary>
            ''' Executes the GetTransportSettings action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            Public Sub GetTransportSettings(instanceID As UInt32)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                Dim loOut() As Object = InvokeAction(csAction_GetTransportSettings, loIn)

                CurrentPlayMode = DirectCast(loOut(0), String)
                iCurrentPlayMode = ParseCurrentPlayMode(CurrentPlayMode)
                '//CurrentRe = DirectCast(loOut(1), String)
            End Sub

            ''' <summary>
            ''' Executes the GetCrossfadeMode action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            ''' <returns>Out value for the CrossfadeMode action parameter.</returns>
            Public Function GetCrossfadeMode(instanceID As UInt32) As Boolean
                Dim loIn(0) As Object

                loIn(0) = instanceID
                Dim loOut() As Object = InvokeAction(csAction_GetCrossfadeMode, loIn)

                Return DirectCast(loOut(0), Boolean)
            End Function

#End Region

#Region "Actions"

            ''' <summary>
            ''' Executes the Stop action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            Public Sub [Stop](instanceID As UInt32)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                InvokeAction(csAction_Stop, loIn)

            End Sub

            ''' <summary>
            ''' Executes the Play action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            ''' <param name="speed">In value for the Speed action parameter.</param>
            Public Sub Play(instanceID As UInt32, speed As TransportPlaySpeedEnum)
                Dim loIn(1) As Object

                loIn(0) = instanceID
                loIn(1) = ToStringTransportPlaySpeed(speed)
                InvokeAction(csAction_Play, loIn)

            End Sub

            ''' <summary>
            ''' Executes the Pause action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            Public Sub Pause(instanceID As UInt32)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                InvokeAction(csAction_Pause, loIn)

            End Sub

            ''' <summary>
            ''' Executes the Seek action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            ''' <param name="unit">In value for the Unit action parameter.</param>
            ''' <param name="target">In value for the Target action parameter.</param>
            Public Sub Seek(instanceID As UInt32, unit As AARGTYPESeekModeEnum, target As String)
                Dim loIn(2) As Object

                loIn(0) = instanceID
                loIn(1) = ToStringAARGTYPESeekMode(unit)
                loIn(2) = target
                InvokeAction(csAction_Seek, loIn)

            End Sub

            ''' <summary>
            ''' Executes the Next action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            Public Sub [Next](instanceID As UInt32)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                InvokeAction(csAction_Next, loIn)

            End Sub

            ''' <summary>
            ''' Executes the NextProgrammedRadioTracks action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            Public Sub NextProgrammedRadioTracks(instanceID As UInt32)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                InvokeAction(csAction_NextProgrammedRadioTracks, loIn)

            End Sub

            ''' <summary>
            ''' Executes the Previous action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            Public Sub Previous(instanceID As UInt32)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                InvokeAction(csAction_Previous, loIn)

            End Sub

            ''' <summary>
            ''' Executes the NextSection action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            Public Sub NextSection(instanceID As UInt32)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                InvokeAction(csAction_NextSection, loIn)

            End Sub

            ''' <summary>
            ''' Executes the PreviousSection action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            Public Sub PreviousSection(instanceID As UInt32)
                Dim loIn(0) As Object

                loIn(0) = instanceID
                InvokeAction(csAction_PreviousSection, loIn)

            End Sub

            ''' <summary>
            ''' Executes the SetPlayMode action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            ''' <param name="newPlayMode">In value for the NewPlayMode action parameter. Default value of NORMAL.</param>
            Public Sub SetPlayMode(instanceID As UInt32, newPlayMode As CurrentPlayModeEnum)
                Dim loIn(1) As Object

                loIn(0) = instanceID
                loIn(1) = ToStringCurrentPlayMode(newPlayMode)
                InvokeAction(csAction_SetPlayMode, loIn)

            End Sub

            ''' <summary>
            ''' Executes the SetCrossfadeMode action.
            ''' </summary>
            ''' <param name="instanceID">In value for the InstanceID action parameter.</param>
            ''' <param name="crossfadeMode">In value for the CrossfadeMode action parameter.</param>
            Public Sub SetCrossfadeMode(instanceID As UInt32, crossfadeMode As Boolean)
                Dim loIn(1) As Object

                loIn(0) = instanceID
                loIn(1) = crossfadeMode
                InvokeAction(csAction_SetCrossfadeMode, loIn)

            End Sub

#End Region

#Region "Public Properties"
            Property TransportState As String
            Property iTransportState As TransportStateEnum
            Property TransportPlaySpeed As String
            Property iTransportPlaySpeed As TransportPlaySpeedEnum
            Property TransportStatus As String
            Property CurrentTransportActions As String



            Property PlaybackStorageMedium As String
            Property iPlaybackStorageMedium As PlaybackStorageMediumEnum
            Property RecordStorageMedium As String
            Property iRecordStorageMedium As RecordStorageMediumEnum

            Property CurrentPlayMode As String
            Property iCurrentPlayMode As CurrentPlayModeEnum
            Property CurrentCrossfadeMode As Boolean

            Property NumberOfTracks As Integer
            Property CurrentTrack As Integer
            Property CurrentSection As Integer
            Property CurrentTrackDuration As String
            Property CurrentMediaDuration As String
            Property CurrentTrackMetaData As String
            Property CurrentTrackURI As String
            Property CurrentTrackData As TrackData

            Property AVTransportURI As String
            Property AVTransportURIMetaData As String
            Property NextAVTransportURI As String
            Property NextAVTransportURIMetaData As String
            Property NextTrackURI As String
            Property NextTrackData As TrackData
            Property EnqueuedTransportURI As String
            Property EnqueuedTransportURIMetaData As String


            Property RelativeTimePosition As String
            Property AbsoluteTimePosition As String
            Property RelativeCounterPosition As Integer
            Property AbsoluteCounterPosition As Integer
            Property RecordMediumWriteStatus As String
            Property LastChange As String

            Private _service As Service

            Public ReadOnly Property DocumentURL() As String
                Get
                    Return _service.Device.DocumentURL
                End Get
            End Property


#End Region

            Private Shared Function CreateUri(uri As String) As Uri
                If [String].IsNullOrEmpty(uri) Then
                    Return Nothing
                End If

                Return New Uri(uri)
            End Function


        End Class

    End Namespace
End Namespace