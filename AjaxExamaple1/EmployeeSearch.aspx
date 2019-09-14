<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeSearch.aspx.cs" Inherits="AjaxExamaple1.EmployeeSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>Name
                </td>
                <td>
                    <input type="text" id="txtname" onkeyup="search();" />
                </td>
            </tr>
        </table>
        <br />
        <div id="d1">

        </div>
    </form>

    <script type="text/javascript">
        function search() {
            var msg = new XMLHttpRequest();
            msg.open("GET", "Insert.aspx?opr=search&name=" + document.getElementById("txtname").value, false);
            msg.send(null);

            document.getElementById("d1").innerHTML = msg.responseText;           
        }
        if (txtname == null) {
            Error = "Data Not Found!"
        }
    </script>
</body>
</html>
