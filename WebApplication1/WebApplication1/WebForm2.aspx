<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function EmpIDClientValidate(ctrl, args) {
            args.IsValid = (args.Value % 5 == 0);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Width="150px" HorizontalAlign="Left"><h3>Description</h3></asp:TableHeaderCell>
                <asp:TableHeaderCell Width="150px" HorizontalAlign="Left"><h3>Value</h3></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>Name:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>ID(multiple of 5):</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Text="*"  ControlToValidate="TextBox2" ClientValidationFunction="EmpIDClientValidate"></asp:CustomValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Day off:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="*" Type="Date" MinimumValue="2010-5-1" MaximumValue="2015-7-1" ControlToValidate="TextBox3"></asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Age(>=18):</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToValidate="TextBox4" Type="Integer" ValueToCompare="18" Operator="GreaterThanEqual"></asp:CompareValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>E-mail:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox5" ErrorMessage="RegularExpressionValidator" Text="*" ValidationExpression=".*@.{2,}\..{2,}"></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Password:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Re-enter Password:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <br /><br />
    <div>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Validators enabled" /><br />
        <asp:CheckBox ID="CheckBox2" runat="server" Text="Client side validator enabled" /><br />
        <asp:CheckBox ID="CheckBox3" runat="server" Text="Show summary" /><br />
        <asp:CheckBox ID="CheckBox4" runat="server" Text="Show message box" /><br />
    </div>
    </form>
</body>
</html>
