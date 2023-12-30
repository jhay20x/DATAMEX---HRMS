Imports System.Data.SqlClient

Module Connections
    Public ConnectionString As String = "Data Source=JHAYJAYGONZALES\GONZALESSERVER;Initial Catalog=HRMS;Persist Security Info=True;User ID=Jhayjay;Password=Jhayjay; MultipleActiveResultSets=true"
    'Public ConnectionString As String = "Data Source=SACRILEGIOUS\GONZALESSERVER;Initial Catalog=HRMS;Persist Security Info=True;User ID=Jhayjay;Password=Jhayjay; MultipleActiveResultSets=true"
    Public Connection As New SqlConnection(ConnectionString)

    Public Command As SqlCommand
    Public Adapter As SqlDataAdapter
    Public Data As DataSet
    Public DataAsTable As DataTable
    Public Parameters As New List(Of SqlParameter)

    Public CommandString As String
    Public ErrorMessage As String
    Public HasError As Boolean
    Public Count As Integer

    Public Sub RunQuery(ByVal query)
        If String.IsNullOrEmpty(query) Then
            query = CommandString
        End If

        ResetValues()

        Try
            Connection.Open()

            Command = New SqlCommand(query, Connection)

            Parameters.ForEach(Sub(a) Command.Parameters.Add(a))

            Parameters.Clear()

            Adapter = New SqlDataAdapter(Command)
            Data = New DataSet

            Count = Adapter.Fill(Data)

            If Data.Tables.Count Then
                DataAsTable = Data.Tables(0)
            End If

            If Count > 0 Then
                HasError = False
            End If
        Catch ex As Exception
            HasError = True
            ErrorMessage = ex.Message
            MsgBox(ErrorMessage)
        End Try

        If Connection.State = ConnectionState.Open Then
            Connection.Close()
        End If
    End Sub

    Public Sub Prepare(ByVal query)
        CommandString = query
    End Sub

    Public Sub ExecutePrepare()
        RunQuery(CommandString)
    End Sub

    Public Sub AddParam(ByVal key As String, ByVal value As Object)
        Parameters.Add(New SqlParameter(key, value))
    End Sub

    Public Sub ResetValues()
        CommandString = ""
        HasError = False
        Count = 0
    End Sub
End Module
