Imports System.Data.SqlClient

Module Connections
    Public con As New SqlConnection("Data Source=SACRILEGIOUS\GONZALESSERVER;Initial Catalog=HRMS;Persist Security Info=True;User ID=Jhayjay;Password=Jhayjay; MultipleActiveResultSets=true")
    Public EmpIdEdit As String
End Module
