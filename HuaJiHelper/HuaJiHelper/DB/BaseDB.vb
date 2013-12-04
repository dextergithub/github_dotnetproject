Imports System.Data.SQLite
Imports Raymond.Croe.Helper
Public MustInherit Class BaseDB

    Protected SqliteConn As System.Data.SQLite.SQLiteConnection
    Protected dbfile As String = "DataBaseHuaJi.s3db"

    Shared ReadOnly Live_Task As Task
    Shared ReadOnly TaskList As System.Collections.Queue
    Public Shared Logger As New Logging.Log()
    MustOverride Sub CreateTable()
    Private _c As Boolean = False

    Private Shared Count As Integer = 0

    Shared Sub New()

        If (Live_Task Is Nothing) Then
            Live_Task = Task.Run(Sub()
                                     TryDo()
                                 End Sub)
        End If

        If (TaskList Is Nothing) Then
            TaskList = Queue.Synchronized(New Queue())
        End If

    End Sub

    Public Shared Function Exe(Of T)(method As Func(Of T)) As T
        Dim task As New Task(Of T)(Function()
                                       Return method()
                                   End Function)
        TaskList.Enqueue(task)
        Return task.Result
    End Function



    Public Sub New(Optional file As String = "")
        Count += 1
        If (String.IsNullOrEmpty(file)) Then
            file = dbfile
        End If

        If SqliteConn Is Nothing Then
            SqliteConn = New SQLiteConnection("Data Source=" + file + ";Pooling=true;FailIfMissing=False", True)
        End If
        If (_c = False) Then
            _c = True
            CreateTable()
        End If
    End Sub

    Private Shared Sub TryDo()
        While (True)
            If Live_Task.IsCanceled Or Live_Task.IsCompleted Or Live_Task.IsFaulted Then
                Return
            End If

            If (TaskList Is Nothing Or TaskList.Count = 0) Then
                Continue While
            End If
            Dim obj As Object = TaskList.Dequeue()
            If (obj Is Nothing) Then
                Continue While
            End If
            Dim t As Task = DirectCast(obj, Task)
            If (t Is Nothing) Then
                Continue While
            End If

            t.Start()
            t.Wait()
        End While
    End Sub

    Public Function ExistsTable(tbname As String) As Boolean
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
                           mycommand.CommandText = "select count(*) as c from  sqlite_master where type ='table' and name = '{0}'".ExtFormat(tbname)

                           flag = mycommand.ExecuteScalar()
                       End Using
                       mytransaction.Commit()
                   End Using
               Catch ex As Exception
                   Logger.WriteException(ex)
                   Return flag
               End Try
               Return flag
           End Function)
        Return t > 0
    End Function

    Protected Overrides Sub Finalize()
        If Count <= 1 Then
            Live_Task.Dispose()
        Else
            Count -= 1
        End If
        MyBase.Finalize()
    End Sub

End Class
