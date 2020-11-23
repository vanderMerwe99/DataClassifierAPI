<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Demo.Dashboard" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="col">
            <div class="row-md-4" style="text-align: center">
                <h2>Welcome, User!</h2>
                <div>
                    <asp:Label ID="Label4" runat="server" Text="Select this radiobutton if you would like to upload a copy of the file to the server."></asp:Label>
                </div>
                <div class="input-container">
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="" />
                </div>
                <div class="input-container">
                    <asp:Label ID="Label3" runat="server" Text="Please enter a valid number that will be used to identify your document in the database."></asp:Label>
                </div>
                <div  class="input-container">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </div>
                <div class="input-container">
                    <asp:Label ID="Label1" CssClass="lbl" runat="server">Click the button below to choose a data file for classification.</asp:Label>
                </div>
                <div class="input-container" style="width: 30%; margin-left: 42.5%; margin-right: 40%">
                    <asp:FileUpload ID="FileUpload1" CssClass="lbl" runat="server" Height="30px" />
                </div>
                <div class="input-container">
                    <asp:Label ID="Label5" runat="server" Text="When you have chosen a file click on the Submit button to see the the information that has been classified."></asp:Label>
                </div>
                <div class="input-container">
                    <asp:TextBox ID="TextBox1" CssClass="box" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="input-container">
                    <asp:Label ID="Label2" CssClass="lbl" runat="server">
                        The window right above this text will be used to display the information that was classified from your data file.<br/>
                        You can manually change the data if something has been incorrectly classified by changing the values displayed in the window.<br/>
                        Each line in the window will be treated as a key:value pair when uploading to the database.<br/>
                        Eg. Name: Name_In_File.<br />
                        When you are satisfied with the classified information click the Upload button to store the information in the database.<br/>
                    </asp:Label>
                </div>
                <asp:Button ID="btnLogin" CssClass="btn" runat="server" Text="Submit" OnClick="btnLogin_Click" />
                <asp:Button ID="btnUpload" CssClass="btn" runat="server" Text="Upload" OnClick="btnUpload_Click" Enabled="False" />
            </div>
        </div>
    </div>
</asp:Content>
