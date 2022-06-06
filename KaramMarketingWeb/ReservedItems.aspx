<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReservedItems.aspx.cs" Inherits="KaramMarketingWeb.ReservedItems" %>
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
                *cursor: hand;
            }
    </style>

    <script type="text/javascript" src="NewTable/DataTables/datatables.min.js"></script>

    <script type="text/javascript">
        //DataTables Initialization for Map Table Example
        $(document).ready(function () {
            $('#inventory').dataTable();
        });

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
                            <h5 class="m-0 text-dark">Reservation List</h5>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">Reservation ID Report</li>
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
                 
            </div>
           <div class="table-responsive" style="overflow: auto">
                         <asp:ListView ID="lvRMGateinDetails" runat="server"  >
                            <LayoutTemplate>
                                <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                    <thead>
                                        <tr>
                                           <th>S.No
                                            </th>
                                             <th>Reservation ID
                                            </th>
                                            <th>Item Code
                                            </th>
                                             <th>Item Desc
                                            </th>
                                            <th>Category
                                            </th>
                                            <th>Qty
                                            </th>
                                            <th>UOM
                                            </th>
                                            <th>Pack Style
                                            </th>
                                            <th>Pack Required
                                            </th>
                                            <th>Demand Date
                                            </th>
                                             <th>Status
                                            </th>
                                             <th>User
                                            </th>
                                             <th>Timestamp
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
                                            <%# Eval("ReservationID")%>
                     
                                        </td>

                                        <td>
                                            <%# Eval("Itemcode")%>
                                        </td>
                                         <td>
                                            <%# Eval("ItemDesc")%>
                                        </td>
                                        <td>
                                            <%# Eval("Category")%>
                                        </td>
                                        <td>
                                            <%# Eval("Qty")%>
                                        </td>
                                     <td>
                                            <%# Eval("UOM")%>
                                        </td>
                                        <td>
                                            <%# Eval("PackStyle")%>
                                        </td>
                                   <td>
                                            <%# Eval("PackReq")%>
                                        </td>
                                        <td>
                                            <%# Eval("DemandDate")%>
                                        </td>
                
                                        <td>
                                            <%# Eval("ItemStatus")%>
                                        </td>
                
                                        <td>
                                            <%# Eval("ModifiedBy")%>
                        
                                        <td>
                                            <%# Eval("ModifiedDate")%>
                                        </td>
              
                 
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <th>S.No
                                            </th>
                                             <th>Reservation ID
                                            </th>
                                            <th>Item Code
                                            </th>
                                             <th>Item Desc
                                            </th>
                                            <th>Category
                                            </th>
                                            <th>Qty
                                            </th>
                                            <th>UOM
                                            </th>
                                            <th>Pack Style
                                            </th>
                                            <th>Pack Required
                                            </th>
                                            <th>Demand Date
                                            </th>
                                             <th>Status
                                            </th>
                                             <th>User
                                            </th>
                                             <th>Timestamp
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
</asp:Content>

