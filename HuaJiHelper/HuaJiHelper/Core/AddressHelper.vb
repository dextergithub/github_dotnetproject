
Imports Raymond.Croe.Helper


Public Class AddressHelper

    Public Function LoadData()

        Dim httphelper = New HttpHelper()
        Dim data As String = httphelper.SetUrl(New Uri("")).GetText()



    End Function




End Class
