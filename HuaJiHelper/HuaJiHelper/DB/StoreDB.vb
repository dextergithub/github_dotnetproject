Imports System.Data.SQLite
Imports Raymond.Croe.Helper

Public Class StoreDB
    Inherits BaseDB

    Public Overrides Sub CreateTable()

        If (ExistsTable("StoreInfo")) Then
            Return
        End If

        Dim t As Integer = Exe(
            Of Integer)(
            Function()
                Dim flag As Integer = 0
                Try
                    If (SqliteConn.State = ConnectionState.Closed) Then
                        SqliteConn.Open()
                    End If

                    Using mytransaction As SQLiteTransaction = Me.SqliteConn.BeginTransaction()
                        Using mycommand As SQLiteCommand = New SQLiteCommand(SqliteConn)
                            mycommand.CommandText = String.Join("", {
                                                               "CREATE TABLE [StoreInfo] ( ", _
                                                                " [Code] varCHAR(50) NOT NULL PRIMARY KEY, ", _
                                                                " [DisplayName] nvaRCHAR(50)  NULL, ", _
                                                                " [MemberName] nvarCHAR(50)  NULL, ", _
                                                                " [FullAddress] nvarCHAR(100)  NULL, ", _
                                                                " [Level] varCHAR(10)  NULL, ", _
                                                                " [AddressInfo] nvarCHAR(50)  NULL, ", _
                                                                " [QQ] vaRCHAR(50)  NULL, ", _
                                                                " [ReceiveOrderCount] inTEGER  NULL, ", _
                                                                " [SendOrderCount] intEGER  NULL, ", _
                                                                " [OpenDate] DATE  NULL, ", _
                                                                " [DistributionRange] nvarCHAR(200)  NULL, ", _
                                                                " [Linkman] nvarCHAR(10)  NULL, ", _
                                                                " [Tel] varCHAR(50)  NULL, ", _
                                                                " [CellPhone] vARCHAR(50)  NULL, ", _
                                                                " [Mail] varCHAR(50)  NULL, ", _
                                                                " [PostCode] varCHAR(10)  NULL, ", _
                                                                " [Position] varCHAR(50)  NULL,", _
                                                                " [AddressIndex] NVARCHAR(100)  NULL,", _
                                                                " [CustomStore] InTEGER DEFAULT '0' NULL", _
                                                                ")"})


                            flag = mycommand.ExecuteNonQuery()

                            mycommand.CommandText = ""
                            Dim SQL As New System.Text.StringBuilder()
                            SQL.AppendLine("CREATE UNIQUE INDEX [IDX_STOREINFO_All] ON [StoreInfo](")
                            SQL.AppendLine("[DisplayName]  ASC,")
                            SQL.AppendLine("[MemberName]  ASC,")
                            SQL.AppendLine("[AddressInfo]  ASC,")
                            SQL.AppendLine("[QQ]  ASC,")
                            SQL.AppendLine("[FullAddress]  ASC,")
                            SQL.AppendLine("[DistributionRange]  ASC,")
                            SQL.AppendLine("[Linkman]  ASC,")
                            SQL.AppendLine("[Tel]  ASC,")
                            SQL.AppendLine("[CellPhone]  ASC,")
                            SQL.AppendLine("[Mail]  ASC,")
                            SQL.AppendLine("[PostCode]  ASC,")
                            SQL.AppendLine("[AddressIndex]  ASC,")
                            SQL.AppendLine("[CustomStore]  ASC")
                            SQL.AppendLine(")")
                            flag = mycommand.ExecuteNonQuery()
                        End Using
                        mytransaction.Commit()
                    End Using
                Catch ex As Exception
                    Logger.WriteException(ex)
                    Return flag
                End Try
                Return flag
            End Function)
    End Sub

    Public Function GetStoreInfo(province As String, city As String, district As String, keyword As String) As List(Of StoreInfo)
        Dim result As New List(Of StoreInfo)

        Dim sqltxt As String = "select * from StoreInfo where 1=1 "
        Dim addinfo As String = ""

        If (Not String.IsNullOrEmpty(province)) Then
            addinfo += "%{0}%".ExtFormat(province)
        End If


        If (Not String.IsNullOrEmpty(city)) Then
            addinfo += "%{0}%".ExtFormat(city)
        End If


        If (Not String.IsNullOrEmpty(district)) Then
            addinfo += "%{0}%".ExtFormat(district)
        End If

        If (Not String.IsNullOrEmpty(addinfo)) Then
            addinfo = addinfo.Replace("'", "%").Replace("%%", "%")
            sqltxt += " and AddressIndex like '" + addinfo + "'"
        End If

        If (Not String.IsNullOrEmpty(keyword)) Then
            keyword = keyword.Replace("'", "%").Replace("%%", "%")
            sqltxt += " and (DisplayName like '{0}' ".ExtFormat(keyword)
            sqltxt += " or FullAddress like '{0}'".ExtFormat(keyword)
            sqltxt += " or MemberName like '{0}'".ExtFormat(keyword)
            sqltxt += " or QQ like '{0}'".ExtFormat(keyword)
            sqltxt += " or DistributionRange like '{0}'".ExtFormat(keyword)
            sqltxt += " or Tel like '{0}'".ExtFormat(keyword)
            sqltxt += " or CellPhone like '{0}'".ExtFormat(keyword)
            sqltxt += " or Mail like '{0}'".ExtFormat(keyword)
            sqltxt += " or Linkman like '{0}'".ExtFormat(keyword)
            sqltxt += ")"

        End If


        Using mycommand As SQLiteCommand = New SQLiteCommand(Me.SqliteConn)
            mycommand.CommandText = sqltxt
            Using sqlitedatareader As SQLiteDataReader = mycommand.ExecuteReader()
                While (sqlitedatareader.Read())
                    Dim info As New StoreInfo
                    info.AddressInfo = sqlitedatareader("AddressInfo")
                    info.CellPhone = sqlitedatareader("CellPhone")
                    info.Code = sqlitedatareader("Code")
                    info.DisplayName = sqlitedatareader("DisplayName")
                    info.DistributionRange = sqlitedatareader("DistributionRange").ToString()
                    info.FullAddress = sqlitedatareader("FullAddress")
                    info.Level = sqlitedatareader("Level")
                    info.LinkMan = sqlitedatareader("LinkMan")
                    info.Mail = sqlitedatareader("Mail")
                    info.MemberName = sqlitedatareader("MemberName")
                    info.OpenDate = sqlitedatareader("OpenDate")
                    info.Position = sqlitedatareader("Position").ToString()
                    info.PostCode = sqlitedatareader("PostCode").ToString()
                    info.QQ = sqlitedatareader("QQ")
                    info.ReceiveOrderCount = sqlitedatareader("ReceiveOrderCount")
                    info.SendOrderCount = sqlitedatareader("SendOrderCount")
                    info.Tel = sqlitedatareader("Tel")
                    result.Add(info)

                End While
            End Using
        End Using
        Return result
    End Function

    Public Function Save(list As List(Of StoreInfo), addinfo As AddressInfo) As Integer
        If (list Is Nothing Or list.Count <= 0) Then Return True

        Dim total As List(Of StoreInfo) = GetStoreInfo("", "", "", "")
        If (Not total Is Nothing) Then
            Dim i As Int16 = 0
            For Each item As StoreInfo In total

                If (list.Contains(item)) Then
                    list.Remove(item)
                Else
                    i += 1
                End If
            Next
        End If
        list = list.Distinct().ToList()
        If (list Is Nothing Or list.Count <= 0) Then
            Return True
        End If

        Dim t As Integer = Exe(
            Of Integer)(
            Function()

                Using mytransaction As SQLiteTransaction = Me.SqliteConn.BeginTransaction()
                    Using mycommand As SQLiteCommand = New SQLiteCommand(Me.SqliteConn)

                        Dim n As Int16

                        mycommand.CommandText =
                            String.Join("", {" INSERT INTO  [StoreInfo] (", _
                                                " [Code],", _
                                                " [DisplayName] ,", _
                                                " [MemberName],", _
                                                " [FullAddress] ,", _
                                                " [Level],", _
                                                " [AddressInfo],", _
                                                " [QQ],", _
                                                " [ReceiveOrderCount],", _
                                                " [SendOrderCount] ,", _
                                                " [OpenDate],", _
                                                " [DistributionRange],", _
                                                " [Linkman] ,", _
                                                " [Tel],", _
                                                " [CellPhone],", _
                                                " [Mail],", _
                                                " [PostCode] ,", _
                                                " [Position] ,", _
                                                " [AddressIndex],", _
                                                " [CustomStore] ", _
                                                " )", _
                                                "values (", _
                                                " @Code,", _
                                                " @DisplayName ,", _
                                                " @MemberName,", _
                                                " @FullAddress ,", _
                                                " @Level,", _
                                                " @AddressInfo,", _
                                                " @QQ,", _
                                                " @ReceiveOrderCount,", _
                                                " @SendOrderCount ,", _
                                                " @OpenDate,", _
                                                " @DistributionRange,", _
                                                " @Linkman ,", _
                                                " @Tel,", _
                                                " @CellPhone,", _
                                                " @Mail,", _
                                                " @PostCode ,", _
                                                " @Position ,", _
                                                " @AddressIndex,", _
                                                " @CustomStore ", _
                                                " )"})

                        mycommand.Parameters.Add("Code", DbType.String)
                        mycommand.Parameters.Add("DisplayName", DbType.String)
                        mycommand.Parameters.Add("MemberName", DbType.String)
                        mycommand.Parameters.Add("FullAddress", DbType.String)
                        mycommand.Parameters.Add("Level", DbType.String)
                        mycommand.Parameters.Add("AddressInfo", DbType.String)
                        mycommand.Parameters.Add("QQ", DbType.String)
                        mycommand.Parameters.Add("ReceiveOrderCount", DbType.Int32)
                        mycommand.Parameters.Add("SendOrderCount", DbType.Int32)
                        mycommand.Parameters.Add("OpenDate", DbType.Date)
                        mycommand.Parameters.Add("DistributionRange", DbType.String)
                        mycommand.Parameters.Add("Linkman", DbType.String)
                        mycommand.Parameters.Add("Tel", DbType.String)
                        mycommand.Parameters.Add("CellPhone", DbType.String)
                        mycommand.Parameters.Add("Mail", DbType.String)
                        mycommand.Parameters.Add("PostCode", DbType.String)
                        mycommand.Parameters.Add("Position", DbType.String)
                        mycommand.Parameters.Add("AddressIndex", DbType.String)
                        mycommand.Parameters.Add("CustomStore", DbType.String)

                        For n = 0 To list.Count - 1
                            Try
                                Dim item As StoreInfo = list(n)
                                mycommand.Parameters("Code").Value = item.Code
                                mycommand.Parameters("DisplayName").Value = item.DisplayName
                                mycommand.Parameters("MemberName").Value = item.MemberName
                                mycommand.Parameters("FullAddress").Value = item.FullAddress
                                mycommand.Parameters("Level").Value = item.Level
                                mycommand.Parameters("AddressInfo").Value = item.AddressInfo
                                mycommand.Parameters("QQ").Value = item.QQ
                                mycommand.Parameters("ReceiveOrderCount").Value = item.ReceiveOrderCount
                                mycommand.Parameters("SendOrderCount").Value = item.SendOrderCount
                                mycommand.Parameters("OpenDate").Value = item.OpenDate
                                mycommand.Parameters("DistributionRange").Value = item.DistributionRange
                                mycommand.Parameters("Linkman").Value = item.LinkMan
                                mycommand.Parameters("Tel").Value = item.Tel
                                mycommand.Parameters("CellPhone").Value = item.CellPhone
                                mycommand.Parameters("Mail").Value = item.Mail
                                mycommand.Parameters("PostCode").Value = item.PostCode
                                mycommand.Parameters("Position").Value = item.Position
                                mycommand.Parameters("AddressIndex").Value = item.AddressIndex
                                mycommand.Parameters("CustomStore").Value = item.CustomStore
                                mycommand.ExecuteNonQuery()
                            Catch ex As Exception
                                Debug.WriteLine(ex)
                                Debug.WriteLine(list(n))
                            End Try

                        Next


                    End Using
                    mytransaction.Commit()
                End Using
                Return 1

            End Function)
        Return t > 0
    End Function

End Class
