Imports System.Data.SqlClient
Imports System.Net
Imports System.Security.Cryptography.X509Certificates

Module Connections
    Public EmpIdEdit As String

    Public ConnectionStr As String = "Data Source=SACRILEGIOUS\GONZALESSERVER;Initial Catalog=HRMS;Persist Security Info=True;User ID=Jhayjay;Password=Jhayjay; MultipleActiveResultSets=true"
    Public Connection As New SqlConnection(ConnectionStr)

    Public Command As SqlCommand
    Public Params As New List(Of SqlParameter)
    Public Adapter As SqlDataAdapter
    Public Data As DataTable

    Public Count As Integer
    Public CommandStr As String

    Public HasError As Boolean

    Public LastId As Integer

    Public IsValid As Boolean

    Public Sub ResetQueryValues()
        CommandStr = ""
        HasError = False
        Count = 0
        'Params = Nothing
    End Sub

    Public Sub RunQuery(q As String)
        If q = "" Then
            q = CommandStr
        End If

        ResetQueryValues()

        Try
            Connection.Open()

            Command = New SqlCommand(q, Connection)

            Params.ForEach(Sub(a) Command.Parameters.Add(a))

            Adapter = New SqlDataAdapter(Command)

            Data = New DataTable()

            Adapter.Fill(Data)

            Count = Data.Rows.Count

            If Count > 0 Then
                HasError = False
            End If
        Catch ex As Exception
            HasError = True
            MsgBox(ex.Message)
        End Try

        If Connection.State = ConnectionState.Open Then
            Connection.Close()
        End If
    End Sub

    Public Sub Prepare(q)
        CommandStr = q
    End Sub

    Public Sub Execute()
        RunQuery(CommandStr)
    End Sub

    Public Sub AddParameters(key As String, value As Object)
        Params.Add(New SqlParameter(key, value))
    End Sub

    Public Sub CheckEmployee(LName As String, FName As String, query1 As String)
        Connection.Open()

        Dim cmd As New SqlCommand(query1, Connection)

        cmd.Parameters.AddWithValue("@LastName", LName)
        cmd.Parameters.AddWithValue("@FirstName", FName)

        If cmd.ExecuteScalar <> 0 Then
            IsValid = False
        Else
            IsValid = True
        End If

        Dim query2 As String = "SELECT ID FROM Employees;"
        Dim cmd2 As New SqlCommand(query2, Connection)

        Dim sdr As SqlDataReader = cmd2.ExecuteReader

        While sdr.Read
            LastId = sdr("ID")
        End While

        MsgBox(LastId)

        Connection.Close()
    End Sub
End Module
