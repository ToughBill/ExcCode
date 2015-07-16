<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>List of events:</h3>
            <asp:ListBox ID="lstEvents" runat="server" Height="107px" Width="355px"></asp:ListBox>
            <br /><br />
            <h3>Controls being monitored for change events:</h3>
            <asp:TextBox ID="txt" runat="server" AutoPostBack="True" OnTextChanged="CtrlChanged"></asp:TextBox>
            <br /><br />
            <asp:CheckBox ID="chk" runat="server" AutoPostBack="True" OnCheckedChanged="CtrlChanged" />
            <br /><br />
            <asp:RadioButton ID="opt1" runat="server" AutoPostBack="True" GroupName="Sample" OnCheckedChanged="CtrlChanged" />
            <asp:RadioButton ID="opt2" runat="server" AutoPostBack="True" GroupName="Sample" OnCheckedChanged="CtrlChanged" />
            
            <br /><br />
            <asp:ListBox ID="ListBox1" runat="server">
                <asp:ListItem Selected="true">option1</asp:ListItem>
                <asp:ListItem >option2</asp:ListItem>
            </asp:ListBox>
        </div>
    </form>
    <label>Name: </label><input id="Text1" type="text" />
</body>
</html>
