﻿<TestFixture()> _
Public Class ProcTester

    <Test()> Public Sub TestScript()
        Dim t As New Table("dbo", "Address")
        t.Columns.Add(New Column("id", "int", False))
        t.Columns.Add(New Column("street", "varchar", 50, False))
        t.Columns.Add(New Column("city", "varchar", 50, False))
        t.Columns.Add(New Column("state", "char", 2, False))
        t.Columns.Add(New Column("zip", "char", 5, False))
        t.PrimaryKey = New PrimaryKey("PK_Address", "id")

        Dim getAddress As New Proc("dbo", "GetAddress")
        getAddress.Text = _
        "CREATE PROCEDURE [dbo].[GetAddress]" + vbCrLf _
        + "   @id int" + vbCrLf _
        + "AS" + vbCrLf _
        + "   select * from Address where id = @id" + vbCrLf

        TestHelper.ExecSql(t.Script())
        TestHelper.ExecSql(getAddress.Script)
        TestHelper.ExecSql("drop table [dbo].[Address]")
        TestHelper.ExecSql("drop procedure [dbo].[GetAddress]")
    End Sub

End Class
