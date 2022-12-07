using System;
using System.Data;
using System.Collections.Generic;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
    }
    protected void treeView_VirtualModeCreateChildren(object source, TreeViewVirtualModeCreateChildrenEventArgs e) {
        List<TreeViewVirtualNode> children = new List<TreeViewVirtualNode>();
        DataTable nodesTable = GetDataTable();
        for (int i = 0; i < nodesTable.Rows.Count; i++) {
            string parentName = e.NodeName != null ? e.NodeName.ToString() : "0";
            if (nodesTable.Rows[i]["ParentID"].ToString() == parentName) {
                TreeViewVirtualNode child = new TreeViewVirtualNode(nodesTable.Rows[i]["ID"].ToString(), nodesTable.Rows[i]["Title"].ToString());
                children.Add(child);
                child.IsLeaf = !(bool)nodesTable.Rows[i]["HasChilds"];
            }
        }
        e.Children = children;
    }
    private DataTable GetDataTable() {

        DataTable dt = new DataTable();
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("Title", typeof(string));
        dt.Columns.Add("ParentID", typeof(int));
        dt.Columns.Add("HasChilds", typeof(bool));

        dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };

        dt.Rows.Add(1, "Nokia", 0, true);
        dt.Rows.Add(2, "N8", 1, false);
        dt.Rows.Add(3, "N91", 1, false);
        dt.Rows.Add(4, "Samsung", 0, true);
        dt.Rows.Add(5, "Corby9", 4, false);
        dt.Rows.Add(6, "Star", 0, false);

        return dt;
    }
}
