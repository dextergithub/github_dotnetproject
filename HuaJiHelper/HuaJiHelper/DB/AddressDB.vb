Imports System.Data.SQLite
Imports Raymond.Croe.Helper

Public Class AddressDB
    Inherits BaseDB

    Public Overrides Sub CreateTable()

        If (ExistsTable("AddressInfo")) Then
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
                                                                "CREATE TABLE [AddressInfo] ( ", _
                                                                "[Province] NVARCHAR(50)  NULL, ", _
                                                                "[ProvinceCode] nvaRCHAR(50)  NULL, ", _
                                                                "[City] nvarchar(50)  NULL, ", _
                                                                "[CityCode] nvarchar(50)  NULL, ", _
                                                                "[District] NvarCHAR(50)  NULL, ", _
                                                                "[DistrictCode] varCHAR(50)  NULL, ", _
                                                                "PRIMARY KEY ([ProvinceCode],[CityCode],[DistrictCode])", _
                                                                ")"})


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

    Public Function Save(list As List(Of AddressInfo)) As Boolean

        If (list Is Nothing Or list.Count <= 0) Then Return True

        Dim total As List(Of AddressInfo) = GetAddressInfo("", "", "")
        If (Not total Is Nothing) Then
            Dim i As Int16 = 0
            For Each item As AddressInfo In total

                If (list.Contains(item)) Then
                    list.Remove(item)
                Else
                    i += 1
                End If
            Next
        End If

        If (list Is Nothing Or list.Count <= 0) Then
            Return True
        End If

        Dim t As Integer = Exe(
            Of Integer)(
            Function()

                    Using mytransaction As SQLiteTransaction = Me.SqliteConn.BeginTransaction()
                        Using mycommand As SQLiteCommand = New SQLiteCommand(Me.SqliteConn)

                            Dim n As Int16

                            mycommand.CommandText = "INSERT INTO [AddressInfo] ([Province],[ProvinceCode],[City],[CityCode],[District],[DistrictCode]) VALUES(?,?,?,?,?,?)"
                            mycommand.Parameters.Add("Province", DbType.String)
                            mycommand.Parameters.Add("ProvinceCode", DbType.String)
                            mycommand.Parameters.Add("City", DbType.String)
                            mycommand.Parameters.Add("CityCode", DbType.String)
                            mycommand.Parameters.Add("District", DbType.String)
                            mycommand.Parameters.Add("DistrictCode", DbType.String)
                            For n = 0 To list.Count - 1
                                Dim item As AddressInfo = list(n)
                                mycommand.Parameters("Province").Value = item.Province
                                mycommand.Parameters("ProvinceCode").Value = item.ProvinceCode
                                mycommand.Parameters("City").Value = item.City
                                mycommand.Parameters("CityCode").Value = item.CityCode
                                mycommand.Parameters("District").Value = item.District
                                mycommand.Parameters("DistrictCode").Value = item.DistrictCode
                                mycommand.ExecuteNonQuery()
                            Next


                        End Using
                        mytransaction.Commit()
                    End Using
                    Return 1

                End Function)
        Return t > 0

    End Function

    Public Function GetAddressInfo(provincecode As String, citycode As String, districtcode As String) As List(Of AddressInfo)
        Dim result As New List(Of AddressInfo)

        Dim sqltxt As String = "select * from AddressInfo where 1=1 "

        If (Not String.IsNullOrEmpty(provincecode)) Then
            sqltxt += " and provinceCode='{0}'".ExtFormat(provincecode)
        End If


        If (Not String.IsNullOrEmpty(citycode)) Then
            sqltxt += " and cityCode='{0}'".ExtFormat(citycode)
        End If


        If (Not String.IsNullOrEmpty(districtcode)) Then
            sqltxt += " and districtCode='{0}'".ExtFormat(districtcode)
        End If

        Using mycommand As SQLiteCommand = New SQLiteCommand(Me.SqliteConn)
            mycommand.CommandText = sqltxt
            Using sqlitedatareader As SQLiteDataReader = mycommand.ExecuteReader()
                While (sqlitedatareader.Read())
                    Dim info As New AddressInfo With
                        {.Province = sqlitedatareader("Province"), _
                         .ProvinceCode = sqlitedatareader("ProvinceCode"), _
                         .City = sqlitedatareader("City"), _
                         .CityCode = sqlitedatareader("CityCode"), _
                         .District = sqlitedatareader("District"), _
                         .DistrictCode = sqlitedatareader("DistrictCode")}
                    result.Add(info)

                End While
            End Using
        End Using
        Return result
    End Function

End Class

