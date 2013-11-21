Public Class Manager

    Public Shared Sub UpdateData()
        '1 UPdate Address
        '2 Update Shop
    End Sub


    Public Shared Sub UpdateAddress()
        Dim list_address As List(Of AddressInfo)
        'list_address =

    End Sub

    Public Shared Sub UpdateStore()
        Dim pagecount As Integer = 1
        Dim pageindex As Integer = 1

        Dim Totallist As New List(Of StoreInfo)
        Dim list As List(Of StoreInfo) ' = WebDataHelper.LoadStoreInfo(Nothing, pageindex, pagecount)

        Dim runTask(20) As Task(Of List(Of StoreInfo))

        While (pagecount >= pageindex)
            Dim index As Integer = Task.WaitAny(runTask)
            list = runTask(index).Result
            If (Not list Is Nothing) Then
                Totallist.AddRange(list)
                Dim t As Task = Task.Run(Sub()
                                             Totallist.AddRange(WebDataHelper.LoadStoreInfo(Nothing, pageindex, pagecount))
                                         End Sub)

                pageindex += 1
        End While

    End Sub

    Public Shared Function GetAddress() As List(Of AddressInfo)
        Dim List As List(Of AddressInfo) = New List(Of AddressInfo)


        Return List
    End Function



End Class
