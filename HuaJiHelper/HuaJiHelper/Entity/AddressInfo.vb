Imports Raymond.Croe.Helper

Public Class AddressInfo
    Inherits Object
    'Implements ICloneable

    Public Function Clone() As AddressInfo
        Return DirectCast(Me.MemberwiseClone(), AddressInfo)
    End Function
    Private _Province As String
    Public Property Province() As String
        Get
            Return _Province
        End Get
        Set(ByVal value As String)
            _Province = value
        End Set
    End Property

    Private _ProvinceCode As String
    Public Property ProvinceCode() As String
        Get
            Return _ProvinceCode
        End Get
        Set(ByVal value As String)
            _ProvinceCode = value
        End Set
    End Property

    Private _City As String
    Public Property City() As String
        Get
            Return _City
        End Get
        Set(ByVal value As String)
            _City = value
        End Set
    End Property


    Private _CityCode As String
    Public Property CityCode() As String
        Get
            Return _CityCode
        End Get
        Set(ByVal value As String)
            _CityCode = value
        End Set
    End Property


    Private _District As String
    Public Property District() As String
        Get
            Return _District
        End Get
        Set(ByVal value As String)
            _District = value
        End Set
    End Property

    Private _DistrictCode As String
    Public Property DistrictCode() As String
        Get
            Return _DistrictCode
        End Get
        Set(ByVal value As String)
            _DistrictCode = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return "{0}({1}),{2}({3}),{4}({5}),".ExtForamt(Province, ProvinceCode, City, CityCode, District, DistrictCode)
    End Function

End Class
