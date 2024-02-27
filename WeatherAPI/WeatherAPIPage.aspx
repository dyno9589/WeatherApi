<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeatherAPIPage.aspx.cs" Async="true" Inherits="WeatherAPI.WeatherAPIPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
 <h2>Weather Information</h2>
            <label for="txtCity">Enter City:</label>
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox> <br /><br />
            <asp:Button ID="btnGetWeather" runat="server" Text="Get Weather" OnClick="btnGetWeather_Click" />
            <br />
            <hr />
            <br />
            <asp:Label ID="lblWeatherInfo" runat="server" Text=""></asp:Label>
                </div>
    </form>
</body>
</html>
