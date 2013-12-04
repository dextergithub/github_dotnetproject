Imports Raymond.Croe.Helper

<SQLite.Table("AddressInfo")>
Public Class AddressInfo
    Inherits Object
    'Implements ICloneable

    Public Function Clone() As AddressInfo
        Return DirectCast(Me.MemberwiseClone(), AddressInfo)
    End Function
    Private _Province As String
    <SQLite.Column("Province")>
    Public Property Province() As String
        Get
            Return _Province
        End Get
        Set(ByVal value As String)
            _Province = value
        End Set
    End Property

    Private _ProvinceCode As String
    <SQLite.Column("ProvinceCode")>
    Public Property ProvinceCode() As String
        Get
            Return _ProvinceCode
        End Get
        Set(ByVal value As String)
            _ProvinceCode = value
        End Set
    End Property

    Private _City As String
    <SQLite.Column("City")>
    Public Property City() As String
        Get
            Return _City
        End Get
        Set(ByVal value As String)
            _City = value
        End Set
    End Property


    Private _CityCode As String
    <SQLite.Column("CityCode")>
    Public Property CityCode() As String
        Get
            Return _CityCode
        End Get
        Set(ByVal value As String)
            _CityCode = value
        End Set
    End Property


    Private _District As String
    <SQLite.Column("District")>
    Public Property District() As String
        Get
            Return _District
        End Get
        Set(ByVal value As String)
            _District = value
        End Set
    End Property

    Private _DistrictCode As String
    <SQLite.Column("DistrictCode")>
    Public Property DistrictCode() As String
        Get
            Return _DistrictCode
        End Get
        Set(ByVal value As String)
            _DistrictCode = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return "{0}({1}),{2}({3}),{4}({5}),".ExtFormat(Province, ProvinceCode, City, CityCode, District, DistrictCode)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return String.Compare(Me.ToString(), obj.ToString()) = 0
    End Function

End Class
