Imports System.IO
Module GlobalVars

    Const m_Pi = 3.1415926535897931
    Enum ZResTypes
        Animation = 0
        DList = 1
        Texture = 2
    End Enum
#Region "Application Variables"
    Public winh As Integer = 0
    Public winw As Integer = 0
    Public ogltop As Integer = 0
    Public oglleft As Integer
    Public DefROM As String = ""
    Public args() As String = {""}
    Public HighlightShader As String = "!!ARBfp1.0" & Environment.NewLine & _
                                       "OUTPUT FinalColor = result.color;" & Environment.NewLine & _
                                       "MOV FinalColor, {1.0,0.0,0.0,0.3};" & Environment.NewLine & _
                                       "END"
    Public HighlightProg As Integer
    Public envlightoff As Integer = 0
    Public CamXPos As Double = 0
    Public CamYPos As Double = 0
    Public CamZPos As Double = 0
    Public objectset As Integer = 0
    Public OnSceneActor As Boolean = False
    Public ActorType As Integer = 0
    Public sceneused As Boolean = False
    Public envboxoff As Integer = 0
    Public HotKeys() As Keys

#End Region
#Region "Scene Actor Variables"

    Public SelectedRoomActors As New ArrayList
    Public SelectedSceneActors As New ArrayList
    Public actornp As New ArrayList
    Public actorvp As New ArrayList
    Public actorgp As New ArrayList
    Public actornpu As New ArrayList
    Public actorvpu As New ArrayList
    Public actorgpu As New ArrayList
    Public groupcntoff As Integer = 0
    Public groupcnt As Integer = 0
    Public sceneobjset As Int32 = 0
    Public doorxoff As New ArrayList
    Public doorvar As New ArrayList
    Public doorno1 As New ArrayList
    Public scenedoorcnt As Integer = 0

#End Region
#Region "Map Actor Variables"
    Public ActorGroups As New ArrayList
    Public ActorGroupOffset
#End Region
#Region "key data handlers"
    Public PickedEntities As New PickedItems
    Public CurrentBank As Integer = 0
    Public ZFileBuffer As Byte()
    Public ExternalAnimBank As Byte()
    Public ZSceneBuffer As Byte()
    Public CommonBanks As New ObjectExchange
    Public CommonBankUse As New BankSwitch
    Public N64DList(-1) As N64DisplayList
    Public RenderToggles As New RendererOptions
    Public GLExtensions As New OpenGLExtensions
    Public WGLExtensions As New WOGLExtensions
    Public AnimParser As New ZAnimation
    Public DLParser As New F3DEX2_Parser
    Public CompileDL As New N64DlistAssembler
    Public ParseOBJ As New OBJParser
    Public LinkedCommands As New DLEdit
    Public ZAnimationCounter As New FPS
    Public Rand As New Random
    Public Interpolate As New SLERP
    Public AnimationStopWatch As New Stopwatch
#End Region
#Region "Texture Converter Class Instances"
    Public RGBA As New TextureUpscaler.RGBA
    Public CI As New TextureUpscaler.CI
    Public IA As New TextureUpscaler.IA
    Public I As New TextureUpscaler.I
#End Region
End Module

