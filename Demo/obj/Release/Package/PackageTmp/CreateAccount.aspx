<%@ Page Async="true" Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="Demo.Contact" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="col">
            <div class="row-md-4" style="text-align:center">
                <h2>Create Account</h2>
                <div class="input-container">
                    <asp:Label ID="lblEmail" CssClass="lbl" runat="server">Email Address:</asp:Label>
                    <br />
                    <asp:TextBox ID="txtEmail" CssClass="input" runat="server"></asp:TextBox>
                </div>
                <div class="input-container">
                    <asp:Label ID="Label1" CssClass="lbl" runat="server">Password:</asp:Label>
                    <br />
                    <asp:TextBox ID="txtPass" CssClass="input" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="input-container">
                    <asp:Label ID="Label2" runat="server">Confirm Password:</asp:Label>
                    <br />
                    <asp:TextBox ID="txtCnfPass" CssClass="input" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button ID="btnLogin" CssClass="btn" runat="server" Text="Create" OnClick="btnLogin_Click" />
            </div>
        </div>
    </div>
</asp:Content>
