<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="KaramMarketingWeb.Roles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet"  href="Login/Style.css"  />
    <style>

         table.lamp th {
                color: white;
                background-color: #007B72;
                padding: 10px;
                padding-left: 10px;
                text-align: left;
                cursor: pointer;
            }
         .modalBackgroundforextender
            {
                background-color: lightgray;
                filter: alpha(opacity=80);
                opacity: 0.8;
                z-index: 10000;
            }
          
    </style>

    <script type="text/javascript" src="NewTable/DataTables/datatables.min.js"></script>

    <script type="text/javascript">
        //DataTables Initialization for Map Table Example
        $(document).ready(function () {
            $('#inventory').dataTable();
        });
    </script>
     
      
     <script type="text/javascript">
         function ShowUserCreation(ReserveID) {

             window.open("CreateROLE.aspx?UID=" + ReserveID, "_self");
         }
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body"  runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
      <div id="ErrorMsg" class="alert alert-danger alert-dismissable" style="display: none" runat="server">
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
        <strong>
            <asp:Label ID="lblMessage" runat="server" Text="Error"></asp:Label>
        </strong>
    </div>
     <div class="content-header">
                <div class="container-fluid">
                    <div class="row mb-2">
                        <div class="col-sm-6">
                            <h5 class="m-0 text-dark">Roles List</h5>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">Roles Details</li>
                            </ol>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.container-fluid -->
            </div>
       <div class="content-header">
               <%-- <div class="container-fluid">--%>
            <div class="container-fluid">
                <div class="row mb-2">
                      <div class="col-sm-12">
                          <ol style="float:right;">
                              
                                 <asp:Button ID ="Create" runat="server"   CausesValidation="false" Text="Create" class="btn btn-success" Width="90px" OnClick="Create_Click"  Height="31px" />
                          </ol>
                      
                      
                      </div>
                              
                 </div>
            </div>
           <div class="table-responsive" style="overflow: auto">
                        <asp:ListView ID="lvRoeles" runat="server"  OnItemCommand="lvRoeles_ItemCommand">
                            <LayoutTemplate>
                                <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                    <thead>
                                        <tr> <th>S.No.
                                            </th>
                                            <th>Role
                                            </th>
                                            <th>Role Description
                                            </th>
                                            <th>Time Stamp
                                            </th>
                        
                                        </tr>
                                    </thead>
                                    <tbody id="ItemPlaceholder" runat="server">
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                   <td>
                                        <%# Container.DataItemIndex + 1%>                                   
                                    </td>
                                    <td>
                                        <a href="#" id="id" onclick="ShowUserCreation('<%# Eval("Roleid")%>');"><%# Eval("Rolename")%></a>
                                      
                                    </td>
                                    <td>
                                        <asp:Label ID="lblroledes" runat="server" Text='<%#Eval("Roledescription") %>'></asp:Label>
                                    </td>

                                    <td>
                                        <%# Eval("TmeStamp") %>
                                    </td>
                 
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <table class="lamp" >
                                    <tr>
                                          <th>S.No.
                                            </th>
                                            <th>Role
                                            </th>
                                            <th>Role Description
                                            </th>
                                            <th>Time Stamp
                                            </th>
                                    </tr>
                                    <tr>
                                        <td colspan="30">No Records Found.
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:ListView>
                           



                        
                    </div>
           </div>

                   <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />

                        <%--<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" 
                            PopupControlID="pnlpopup" DropShadow="false"
                            CancelControlID="BtnClose" BackgroundCssClass="modalBackgroundforextender">
                        </asp:ModalPopupExtender>--%>


               <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="450px" Width="600px" Style="overflow: auto; display: none">
                    <table width="100%">
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="lblPopTitle" runat="server" Text="Role Details" Font-Bold="true" Font-Size="Large" ForeColor="Navy"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">&nbsp; &nbsp;&nbsp;
                                 <asp:HiddenField ID="hdnroleID" runat="server" Value="0" />
                                <asp:Label ID="lblErrorrmsgpopup" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                <asp:Label ID="Label3" runat="server" Text="Role :" Font-Bold="true"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtrolemp" runat="server" AutoCompleteType="Disabled" Width="300px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                <asp:Label ID="Label8" runat="server" Text="Role Description :" Font-Bold="true"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtroledesmp" runat="server" AutoCompleteType="Disabled" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                            </td>
                        </tr>

                        <tr>
                            <td>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                <asp:Label ID="Label5" runat="server" Text="HHT Menus :" Font-Bold="true"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chkHHTModules" runat="server" RepeatColumns="3" Width="400px" ForeColor="Navy" Font-Size="Medium"
                                    RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                <asp:Label ID="Label6" runat="server" Text="Web Menus :" Font-Bold="true"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chkWEBModules" runat="server" RepeatColumns="3" Width="400px" ForeColor="Navy" Font-Size="Medium"
                                    RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSaveRole" runat="server" Text="Save" OnClick="btnSaveRole_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BtnClose" runat="server" Text="Close" />

                            </td>
                        </tr>
                    </table>

                </asp:Panel>
</asp:Content>


