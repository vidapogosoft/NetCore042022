<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmPersona.aspx.cs" Inherits="WebForm1.Mantenimientos.FrmPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>MANTENIMIENTO DE PERSONA</h2>

    <div class="col-md-12" >
        <asp:Button runat="server" ID="BtnConsulta"  Text="Actualizar Consulta"  Class="btn btn-warning" OnClick="BtnConsulta_Click"/>
    </div>
    
    <br />
    
    <div class="col-md-12">
            <asp:GridView ID="GrdPersona" runat="server" AutoGenerateColumns="true"></asp:GridView>
    </div>
    

</asp:Content>
