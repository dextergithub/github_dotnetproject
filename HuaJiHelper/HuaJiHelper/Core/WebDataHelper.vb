Imports Raymond.Croe.Helper
Imports Newtonsoft.Json.Linq
Imports HtmlAgilityPack

Public Class WebDataHelper

    Public Shared Function LoadHuaJiCity() As List(Of AddressInfo)

        Dim httphelper = New HttpHelper()
        Dim data As String = httphelper.SetUrl(New Uri(AppConfig.GetConfig().FileName)).GetText()
        Dim json As String = data.Trim().Replace("var districtData =", "").Trim()
        Dim jobject As JObject = Newtonsoft.Json.Linq.JObject.Parse(json)

        Dim list As List(Of AddressInfo) = New List(Of AddressInfo)

        For Each item As JProperty In jobject.Children()
            list.AddRange(GetCity(item, New AddressInfo(), 1))
        Next

        Return list

    End Function

    Private Shared Function GetCity(token As JProperty, info As AddressInfo, level As Integer) As List(Of AddressInfo)

        Dim list As List(Of AddressInfo) = New List(Of AddressInfo)

        Dim parent As AddressInfo

        Dim key As String = token.Name
        Dim name = token.Value("name")
        Dim cells As JToken = token.Value("cell")

        If level = 1 Then
            info = New AddressInfo()
            info.ProvinceCode = key
            info.Province = name
        ElseIf level = 2 Then
            info.City = name
            info.CityCode = key
        End If

        If (cells Is Nothing) Then
            parent = info.Clone()
            If level = 2 Then
                info.City = info.Province
                info.CityCode = info.ProvinceCode
            End If

            parent.DistrictCode = key
            parent.District = name
            list.Add(parent)
        ElseIf Not cells Is Nothing Then
            For Each item As JProperty In cells
                list.AddRange(GetCity(item, info, level + 1))
            Next

        End If

        Return list

    End Function


    Public Shared Function LoadStoreInfo(address As AddressInfo, pageindex As Integer, ByRef pagecount As Integer) As List(Of StoreInfo)
        ' http://shop.huaji.com/index.php?pt=&keyword=&province={0}&city={1}&town={2}&page={3}
        Dim url As String = "http://shop.huaji.com/index.php?"

        If Not address Is Nothing Then
            If Not String.IsNullOrEmpty(address.ProvinceCode) Then
                url += "province=" + address.ProvinceCode + "&"
            End If

            If Not String.IsNullOrEmpty(address.CityCode) Then
                url += "city=" + address.CityCode + "&"
            End If

            If Not String.IsNullOrEmpty(address.DistrictCode) Then
                url += "town=" + address.DistrictCode + "&"
            End If
        End If

        If (pageindex > 0) Then
            url += "page=" + pageindex.ToString() + "&"
        End If

        Dim html As String = New HttpHelper().SetUrl(New Uri(url)).GetText()

        Dim list As List(Of StoreInfo) = AnalyzingStoreList(html, pagecount)
        Return list

    End Function

    Public Shared Function AnalyzingStoreList(html As String, ByRef pagecount As Integer) As List(Of StoreInfo)

        Dim doc As New HtmlAgilityPack.HtmlDocument()
        doc.LoadHtml(html)

        Dim countNode As HtmlNode = doc.DocumentNode.SelectSingleNode("//p[@class='fl shop_page_num']")
        If (Not countNode Is Nothing And Not String.IsNullOrEmpty(countNode.InnerText)) Then
            Dim strc() As String = countNode.InnerText.Split({"/"}, StringSplitOptions.RemoveEmptyEntries)

            If (strc.Length > 1) Then
                Integer.TryParse(strc(1), pagecount)
            End If
        End If

        Dim itemnode As HtmlNodeCollection = doc.DocumentNode.SelectNodes("//div[@class='shopdel_itme shopdel_itme1']")
        Dim list As New List(Of StoreInfo)

        For Each item As HtmlNode In itemnode
            Dim info As StoreInfo = GetStoreInfo(item)
            list.Add(info)
        Next

        Return list

    End Function

    Private Shared Function GetStoreInfo(html As HtmlNode) As StoreInfo
        Dim info As New StoreInfo() With { _
        .AddressInfo = html.SelectSingleNode(".//p[@class='address']").InnerText.Replace("&nbsp;", ""), _
        .FullAddress = html.SelectSingleNode(".//div[@class='fl description']/p[@class='mt5 nowrap']/span").InnerText, _
        .Code = html.SelectSingleNode(".//p[@class='shop_hd_title fl']/a").GetAttributeValue("href", "").Replace("/", ""), _
        .MemberName = html.SelectSingleNode(".//div[@class='fl description']/p[1]").InnerText.Replace("会员名：", ""), _
        .DisplayName = html.SelectSingleNode(".//p[@class='shop_hd_title fl']/a").InnerText _
        }

        info.Level = html.SelectSingleNode(".//div[@class='fl overall']/p/a/img").GetAttributeValue("data-original", "").Split({"/", "."}, StringSplitOptions.RemoveEmptyEntries)(6)
        Dim h As New HttpHelper()
        Dim htm As String = h.SetUrl(New Uri("http://shop.huaji.com/shop_contact.php?shop_id=1199556796")).GetText()

        Dim doc As New HtmlAgilityPack.HtmlDocument
        doc.LoadHtml(htm)

        Dim datastr As String = ""
        datastr = doc.DocumentNode.SelectSingleNode(".//div[@class='general_info rel border_none']/p[3]/em").InnerText
        info.OpenDate = DateTime.Parse(datastr)
        Dim contact_inf As HtmlNodeCollection = doc.DocumentNode.SelectNodes(".//ul[@class='contact_inf']/li")
        For Each node In contact_inf

            If (node.InnerText.Contains("联 系 人：")) Then

                info.Linkman = node.InnerText.Replace("联 系 人：", "").Trim()
            ElseIf node.InnerText.Contains("QQ 号 码：") Then
                info.QQ = node.InnerText.Replace("QQ 号 码：", "").Trim()
            ElseIf node.InnerText.Contains("固定电话：") Then
                info.Tel = node.InnerText.Replace("固定电话：", "").Trim()
            ElseIf node.InnerText.Contains("手机号码：") Then
                info.CellPhone = node.InnerText.Replace("手机号码：", "").Trim()
            ElseIf node.InnerText.Contains("电子邮件：") Then
                info.Mail = node.InnerText.Replace("电子邮件：", "").Trim()
            End If

        Next
        Return info

    End Function


End Class
