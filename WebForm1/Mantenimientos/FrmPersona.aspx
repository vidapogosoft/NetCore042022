<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmPersona.aspx.cs" 
    Inherits="WebForm1.Mantenimientos.FrmPersona" Async="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>MANTENIMIENTO DE PERSONA</h2>

     <br />


    <div class="col-md-12">

        <div class="row">
             <label>Identificacion</label>
        <asp:TextBox ID="Txtidentificacion" runat="server"></asp:TextBox>
        </div>
       
        
        <div class="row">
            <label>Nombres</label>
        <asp:TextBox ID="TxtNombres" runat="server"></asp:TextBox>
        </div>
        <div class="row">
            <label>Apellidos</label>
        <asp:TextBox ID="TxtApellidos" runat="server"></asp:TextBox>
        </div>
        

        <br />


        <asp:Button runat="server" ID="BtnGrabarDatos"  Text="Grabar Datos"  Class="btn btn-success" OnClick="BtnGrabarDatos_Click"/>

        <asp:Label ID="LblMensaje" runat="server" Text="{]"></asp:Label>

    </div>

     <br />
     <br />

    <div class="col-md-12" >
        <asp:Button runat="server" ID="BtnConsulta"  Text="Actualizar Consulta"  Class="btn btn-warning" OnClick="BtnConsulta_Click"/>
    </div>
    
    <br />
    
    <div class="col-md-12">
            <asp:GridView ID="GrdPersona" runat="server" AutoGenerateColumns="true"></asp:GridView>
    </div>
    

</asp:Content>
