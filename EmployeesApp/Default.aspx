<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeesApp.Default" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Work Time</title>
    <style>
        .highlight {
            background-color: #ffcccc;
        }
        .center-container {
            text-align: center; 
            margin: 20px auto; 
            max-width: 80%; 
        }
        .center-container img {
            max-width: 100%; 
            height: auto; 
            margin-top: 60px;
        }
        .center-container table {
            margin: 0 auto; 
            border-collapse: collapse; 
        }
        .center-container th, .center-container td {
            border: 1px solid #ddd; 
            padding: 8px;
            text-align: center; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="center-container">
            <asp:GridView ID="EmployeeGridView" runat="server" AutoGenerateColumns="False" OnRowDataBound="EmployeeGridView_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
                    <asp:BoundField DataField="TotalHoursWorked" HeaderText="Total Hours Worked" DataFormatString="{0:N0}" />
                </Columns>
            </asp:GridView>
            <br />
             <img src="<%= ResolveUrl("~/Charts/EmployeeWorkChart.png") %>" alt="Employee Work Chart" />
        </div>
    </form>
</body>
</html>
