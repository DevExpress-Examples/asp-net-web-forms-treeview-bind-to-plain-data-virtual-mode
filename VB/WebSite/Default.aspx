<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>How to bind the ASPxTreeView to plain data (Virtual mode)</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxHiddenField ID="ASPxHiddenField1" runat="server" ClientInstanceName="hidden">
        </dx:ASPxHiddenField>
        <dx:ASPxTreeView ID="treeView" runat="server" EnableCallBacks="true" 
            OnVirtualModeCreateChildren="treeView_VirtualModeCreateChildren">
        </dx:ASPxTreeView>

    </div>
    </form>
</body>
</html>