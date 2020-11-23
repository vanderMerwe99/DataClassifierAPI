<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Demo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Data Classification Application</h1>
        <p class="lead">Data Classification is a method reffered to when trying to automate the process of identifying sensitive information and yes, it can be quite as confusing as it sounds. :)
            Therefore, in this project I have tried to provide a cloud-based solution to try and automate this process as accurately as possible.
            Click on the Create Account button below to set up your account with us and get started uploading your first file.
        </p>
        <p><asp:Button ID="Createbtn" CssClass="btn" runat="server" Text="Create Account >>" OnClick="Createbtn_Click" /></p>
    </div>

    <div class="col">
        <div class="row-md-4">
            <h2>Sign In</h2>
            <p>Already have an account with us? Awesome, sign in below and let's go!</p>
            <p><asp:Button ID="SignInbtn" CssClass="btn" runat="server" Text="Sign In >>" OnClick="SignInbtn_Click" /></p>
        </div>
    </div>
</asp:Content>
