Imports Raymond.Croe.Helper
Public Class StoreInfo

    Private _Code As String
    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal value As String)
            _Code = value
        End Set
    End Property

    Private _displayname As String
    Public Property DisplayName() As String
        Get
            Return _displayname
        End Get
        Set(ByVal value As String)
            _displayname = value
        End Set
    End Property

    Private _memberName As String
    Public Property MemberName() As String
        Get
            Return _memberName
        End Get
        Set(ByVal value As String)
            _memberName = value
        End Set
    End Property


    Private _fulladdress As String
    Public Property FullAddress() As String
        Get
            Return _fulladdress
        End Get
        Set(ByVal value As String)
            _fulladdress = value
        End Set
    End Property

    Private _level As String
    Public Property Level() As String
        Get
            Return _level
        End Get
        Set(ByVal value As String)
            _level = value
        End Set
    End Property

    Private _addressinfo As String
    Public Property AddressInfo() As String
        Get
            Return _addressinfo
        End Get
        Set(ByVal value As String)
            _addressinfo = value
        End Set
    End Property

    Private _qq As String
    Public Property QQ() As String
        Get
            Return _qq
        End Get
        Set(ByVal value As String)
            _qq = value
        End Set
    End Property

    Private _receiveOrderCount As Int32
    Public Property ReceiveOrderCount() As Int32
        Get
            Return _receiveOrderCount
        End Get
        Set(ByVal value As Int32)
            _receiveOrderCount = value
        End Set
    End Property


    Private _sendordercount As Integer
    Public Property SendOrderCount() As Integer
        Get
            Return _sendordercount
        End Get
        Set(ByVal value As Integer)
            _sendordercount = value
        End Set
    End Property

    Private _openDate As Date
    Public Property OpenDate() As Date
        Get
            Return _openDate
        End Get
        Set(ByVal value As Date)
            _openDate = value
        End Set
    End Property

    Private _DistributionRange As String
    Public Property DistributionRange() As String
        Get
            Return _DistributionRange
        End Get
        Set(ByVal value As String)
            _DistributionRange = value
        End Set
    End Property


    Private _linkman As String
    Public Property Linkman() As String
        Get
            Return _linkman
        End Get
        Set(ByVal value As String)
            _linkman = value
        End Set
    End Property

    Private _tel As String
    Public Property Tel() As String
        Get
            Return _tel
        End Get
        Set(ByVal value As String)
            _tel = value
        End Set
    End Property


    Private _cellphone As String
    Public Property CellPhone() As String
        Get
            Return _cellphone
        End Get
        Set(ByVal value As String)
            _cellphone = value
        End Set
    End Property

    Private _mail As String
    Public Property Mail() As String
        Get
            Return _mail
        End Get
        Set(ByVal value As String)
            _mail = value
        End Set
    End Property

    Private _postcode As String
    Public Property PostCode() As String
        Get
            Return _postcode
        End Get
        Set(ByVal value As String)
            _postcode = value
        End Set
    End Property

    Private _point As String
    Public Property Position() As String
        Get
            Return _point
        End Get
        Set(ByVal value As String)
            _point = value
            Dim p() As String = value.Split({","}, StringSplitOptions.RemoveEmptyEntries)
            If p.Length = 2 Then
                Dim x, y As Decimal
                Decimal.TryParse(p(0), x)
                Decimal.TryParse(p(1), y)
                Me.Y = y
                Me.X = x
            End If
        End Set
    End Property

    Private _x As Decimal
    Public Property X() As Decimal
        Get
            Return _x
        End Get
        Set(ByVal value As Decimal)
            _x = value
        End Set
    End Property

    Private _y As Decimal
    Public Property Y() As Decimal
        Get
            Return _y
        End Get
        Set(ByVal value As Decimal)
            _y = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return Me.ExtToJsonString()
    End Function



End Class
