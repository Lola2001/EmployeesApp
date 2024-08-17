<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeesApp.Default" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Work Time</title>
    <style>
        .highlight {
            background-color: #ffcccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="EmployeeGridView" runat="server" AutoGenerateColumns="False" OnRowDataBound="EmployeeGridView_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
                    <asp:BoundField DataField="TotalHoursWorked" HeaderText="Total Hours Worked" DataFormatString="{0:N0}" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
