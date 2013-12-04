Public Class Manager

    Public Shared Sub UpdateData()
        Dim alladdress As List(Of AddressInfo) = GetAddressFromWeb()
        Dim addDB As New AddressDB()
        addDB.Save(alladdress)
        alladdress = GetAddressFromLocal()
        Dim stroeDB = New StoreDB()

        For Each addinfo As AddressInfo In alladdress
            Dim storelist As List(Of StoreInfo) = GetStoreFromWeb(addinfo)
            '/Dim storelist As List(Of StoreInfo) = DirectCast(x, List(Of StoreInfo))
            stroeDB.Save(storelist, addinfo)
        Next
    End Sub



    Public Shared Function GetStoreFromWeb(address As AddressInfo) As List(Of StoreInfo)
        Dim pagecount As Integer = 1
        Dim pageindex As Integer = 1

        Dim Totallist As New List(Of StoreInfo)
        'Totallist = ArrayList.Synchronized(Totallist)
        Dim list As List(Of StoreInfo) = WebDataHelper.LoadStoreInfo(address, pageindex, pagecount)
        Totallist.AddRange(list)
        pageindex += 1
        Dim runTask() As Task

        While (pagecount >= pageindex)

            Dim index As Integer
            Dim p_index As Integer = pageindex

            If runTask Is Nothing Then
                ReDim runTask(0)
                index = 0

            ElseIf runTask.Length > 21 Then
                index = Task.WaitAny(runTask)
            Else
                index = runTask.Length
                ReDim Preserve runTask(runTask.Length)
            End If
            runTask(index) = Task.Run(Sub()
                                          Dim lt As List(Of StoreInfo) = WebDataHelper.LoadStoreInfo(address, p_index, pagecount)
                                          If Not lt Is Nothing And lt.Count > 0 Then
                                              SyncLock Totallist
                                                  Totallist.AddRange(lt)
                                              End SyncLock
                                          End If

                                      End Sub)

            pageindex += 1
        End While
        If Not runTask Is Nothing Then
            Task.WaitAll(runTask)
        End If

        Return Totallist
    End Function

    Public Shared Function GetAddressFromWeb() As List(Of AddressInfo)
        Dim List As List(Of AddressInfo) = New List(Of AddressInfo)
        List = WebDataHelper.LoadHuaJiCity()
        Return List
    End Function

    Public Shared Function GetStoreFromLocal() As List(Of StoreInfo)
        Dim db As New StoreDB()
        Return db.GetStoreInfo("", "", "", "")
    End Function

    Public Shared Function GetAddressFromLocal() As List(Of AddressInfo)
        Dim db As New AddressDB()
        Return db.GetAddressInfo("", "", "")
    End Function



End Class
