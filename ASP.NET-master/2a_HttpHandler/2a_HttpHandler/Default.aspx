<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>HTTP Handlers</title>

    <script type="text/javascript">
        var xmlRequest;

        function CreateXMLHttpRequest() {
            try {
                xmlRequest = new XMLHttpRequest();
            }
            catch (err) {
                xmlRequest = new ActiveXObject("Microsoft.XMLHTTP");
            }
        }

        function CallServerForUpdate() {
            var txt1 = document.getElementById("x");
            var txt2 = document.getElementById("y");

            var url = "CalculatorHandler.ashx?value1=" +
              txt1.value + "&value2=" + txt2.value;
            xmlRequest.open("GET", url);
            xmlRequest.onreadystatechange = ApplyUpdate;
            xmlRequest.send(null);
        }

        function ApplyUpdate() {
            // Проверить успешность получения ответа
            if (xmlRequest.readyState == 4) {
                if (xmlRequest.status == 200) {
                    var lbl = document.getElementById("lblResponse");

                    var response = xmlRequest.responseText;

                    if (response == "-") {
                        lbl.innerHTML = "Incorrect values.";
                    }
                    else {
                        var responseStrings = response.split(" ");
                        lbl.innerHTML = "X + Y = " +
                          responseStrings;
                    }
                }
            }
        }
    </script>

</head>
<body onload="CreateXMLHttpRequest();">
    <form id="form1" runat="server">

        <asp:Button ID="GetButton" runat="server" OnClick="GetButton_Click" Text="GET" Height="24px" Width="81px" />
        <asp:Button ID="PostButton" runat="server" OnClick="PostButton_Click" Text="POST" Height="24px" Width="81px" />
        <asp:Button ID="PutButton" runat="server" OnClick="PutButton_Click" Text="PUT" Height="24px" Width="81px" />
        <asp:Button ID="Get403" runat="server" OnClick="Get403_Click" Text="GET(403)" Height="24px" Width="81px" />

        <div>
            <br />
            <br />
            X: 
            <asp:TextBox ID="x" runat="server" onKeyUp="CallServerForUpdate();"></asp:TextBox><br />
            Y: 
            <asp:TextBox ID="y" runat="server" onKeyUp="CallServerForUpdate();"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblResponse" runat="server" text="X + Y = " Font-Bold="True" Font-Names="Verdana" Font-Size="Small">
            </asp:Label>
        </div>
        <%--<p>-----------------------------------------------------------------------------------------------------------------</p>
        <asp:Button ID="Buttonget" runat="server" OnClick="GetQueryButton_Click" Text="GET" Height="24px" Width="81px" />
        <asp:Button ID="Button1" runat="server" OnClick="PostQueryButton_Click" Text="POST" Height="24px" Width="81px" />
        <asp:Button ID="Button2" runat="server" OnClick="PutQueryButton_Click" Text="PUT" Height="24px" Width="81px" />--%>

    </form>
</body>
</html>
