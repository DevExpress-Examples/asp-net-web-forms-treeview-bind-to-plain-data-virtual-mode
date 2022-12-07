Imports System
Imports System.Data
Imports System.Collections.Generic
Imports DevExpress.Web

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Protected Sub treeView_VirtualModeCreateChildren(ByVal source As Object, ByVal e As TreeViewVirtualModeCreateChildrenEventArgs)
        Dim children As New List(Of TreeViewVirtualNode)()
        Dim nodesTable As DataTable = GetDataTable()
        For i As Integer = 0 To nodesTable.Rows.Count - 1
            Dim parentName As String = If(e.NodeName IsNot Nothing, e.NodeName.ToString(), "0")
            If nodesTable.Rows(i)("ParentID").ToString() = parentName Then
                Dim child As New TreeViewVirtualNode(nodesTable.Rows(i)("ID").ToString(), nodesTable.Rows(i)("Title").ToString())
                children.Add(child)
                child.IsLeaf = Not CBool(nodesTable.Rows(i)("HasChilds"))
            End If
        Next i
        e.Children = children
    End Sub
    Private Function GetDataTable() As DataTable

        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Title", GetType(String))
        dt.Columns.Add("ParentID", GetType(Integer))
        dt.Columns.Add("HasChilds", GetType(Boolean))

        dt.PrimaryKey = New DataColumn() { dt.Columns("ID") }

        dt.Rows.Add(1, "Nokia", 0, True)
        dt.Rows.Add(2, "N8", 1, False)
        dt.Rows.Add(3, "N91", 1, False)
        dt.Rows.Add(4, "Samsung", 0, True)
        dt.Rows.Add(5, "Corby9", 4, False)
        dt.Rows.Add(6, "Star", 0, False)

        Return dt
    End Function
End Class
