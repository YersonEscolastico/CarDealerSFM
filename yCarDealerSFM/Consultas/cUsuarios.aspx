<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cUsuarios.aspx.cs" Inherits="yCarDealerSFM.Consultas.cUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="panel" style = "background-color:#0094ff">
           <div class="panel-heading" style="font-family:Arial Black; text-align:center; font-size:20px;  color:Black" >Consulta de Usuarios</div>
     </div>
      <%--Entradas de las consulta--%>
        <div class="form-group">
                <div class="col-md-4">
                        <asp:DropDownList ID="FiltroDropDownList" runat="server" Class="form-control input-sm" style="font-size:medium">
                                <asp:ListItem Selected="True">Todo</asp:ListItem>
                                <asp:ListItem>UsuarioId</asp:ListItem>
                                <asp:ListItem>Nombres</asp:ListItem>
                                <asp:ListItem>Usuario</asp:ListItem>
                                <asp:ListItem>Tipo</asp:ListItem>
                                <asp:ListItem>Fecha</asp:ListItem>
                        </asp:DropDownList>
                </div>
            
                <div class="col-md-6">
                     <asp:TextBox ID="CriterioTextBox" runat="server"  class="form-control input-sm" style="font-size:medium"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click"/>
                </div>
            </div>
         <br/>
         <br/>

         <%--Fechas para consulta--%>
        <div class="form-group">
            <div class="col-md-12">
                    <label for="DesdeTextBox" class="col-md-1 control-label input-sm" style="font-size: medium">Desde</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="DesdeTextBox" TextMode="Date" runat="server" class="form-control input-sm" Style="font-size: medium" Visible="true" ></asp:TextBox>
                    </div>

                    <label for="HastaTextBox" class="col-md-1 control-label input-sm" style="font-size: medium">Hasta</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="HastaTextBox" TextMode="Date" runat="server" class="form-control input-sm" Style="font-size: medium" Visible="true" ></asp:TextBox>
                    </div>
                    <asp:CheckBox ID="FechaCheckBox" runat="server" Checked="True" Visible="False"  />
            </div>
         </div>
        <br/>
        <br/>


        <%--Grid--%>
        <div class="table-responsive">
            <asp:GridView ID="DatosGridView" runat="server" class="table table-condensed  table-responsive" CellPadding="6" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:HyperLinkField ControlStyle-ForeColor="#0094ff"
                            HeaderText="Opciones"
                            DataNavigateUrlFields="UsuarioId"
                            DataNavigateUrlFormatString="/Registros/rUsuarios.aspx?Id={0}"
                            Text="Editar">
                        </asp:HyperLinkField>
                    </Columns>
                    <HeaderStyle BackColor="#0094ff" Font-Bold="true" ForeColor="black" />
                    <RowStyle BackColor="#EFF3FB" />
            </asp:GridView>>
</div>
</asp:Content>