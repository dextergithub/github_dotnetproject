Imports Raymond.Croe.Helper
Imports System.Configuration



Public Class AppConfig : Inherits BaseConfig

    ' The collection (property bag) that contains 
    ' the section properties.
    Private Shared _Properties As ConfigurationPropertyCollection

    ' Internal flag to disable 
    ' property setting.
    Private Shared _ReadOnly As Boolean

    ' The FileName property.
    Private Shared _CityJSUrl As New ConfigurationProperty("CityJSUrl", GetType(String), "http://www.huaji.com/pg/js/tdist.js", ConfigurationPropertyOptions.None)

    

    ' CustomSection constructor.

    Sub New()
        ' Property initialization
        _Properties = _
        New ConfigurationPropertyCollection()

        _Properties.Add(_CityJSUrl)

    End Sub 'New
    Private Shared _appconfig As AppConfig = Nothing

    Public Shared Function GetConfig() As AppConfig
        If _appconfig Is Nothing Then
            _appconfig = New AppConfig()
        End If
        Return _appconfig

    End Function



    ' This is a key customization. 
    ' It returns the initialized property bag.
    Protected Overrides ReadOnly Property Properties() _
    As ConfigurationPropertyCollection
        Get
            Return _Properties
        End Get
    End Property



    Private Shadows ReadOnly Property IsReadOnly() As Boolean
        Get
            Return _ReadOnly
        End Get
    End Property


    ' Use this to disable property setting.
    Private Sub ThrowIfReadOnly(propertyName As String)
        If IsReadOnly Then
            Throw New ConfigurationErrorsException( _
            "The property " + propertyName + " is read only.")
        End If
    End Sub 'ThrowIfReadOnly



    ' Customizes the use of CustomSection
    ' by setting _ReadOnly to false.
    ' Remember you must use it along with ThrowIfReadOnly.
    Protected Overrides Function GetRuntimeObject() As Object
        ' To enable property setting just assign true to
        ' the following flag.
        _ReadOnly = True
        Return MyBase.GetRuntimeObject()
    End Function 'GetRuntimeObject
    ''' <summary>
    ''' JS File
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileName() As String
        Get
            Return CStr(Me("CityJSUrl"))
        End Get
        Set(ByVal value As String)
            ' With this you disable the setting.
            ' Remember that the _ReadOnly flag must
            ' be set to true in the GetRuntimeObject.
            ThrowIfReadOnly("CityJSUrl")
            Me("CityJSUrl") = value
        End Set
    End Property




End Class
