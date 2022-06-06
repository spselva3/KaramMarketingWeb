<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmEmail.aspx.cs" Inherits="KaramMarketingWeb.frmEmail" %>
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

       <script type="text/javascript">
           function ShowEditEmail(Module , Name) {

               window.open("CreateEmailID.aspx?UID=" + Module + "&NAME=" + Name, "_self");
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
                            <h5 class="m-0 text-dark">Email List</h5>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">Email Report</li>
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
                         <asp:ListView ID="lvEmailDetail" runat="server"  >
                            <LayoutTemplate>
                                <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                    <thead>
                                        <tr>
                                           <th>S.No
                                            </th>
                                            <th>Module
                                            </th>
                                            <th>Name
                                            </th>
                                            <th>Mail ID
                                            </th>
                                            <th>Organisation
                                            </th>
                                            <th>Status
                                            </th>
                                            <th>Created By
                                            </th>
                                            <th>TimeStamp
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
                                            <%# Eval("MODULE")%>
                                    </td>
                                    <td>
                         
                                            <%# Eval("NAME")%>
                                    </td>
                                    <td>
                                        <a href="#" id="id1234" onclick="ShowEditEmail(' <%# Eval("MODULE")%> ','<%# Eval("NAME")%>'); ">
                         
                                        <%# Eval("EMAIL")%> 
                                    </td>
                                    <td>
                                        <%# Eval("ORGANISATION")%> 
                                    </td>
                                    <td>
                                        <%# Eval("MAilStatus")%>
                                    </td>
                                    <td>
                                        <%# Eval("USER")%>
                                    </td>
                                    <td>
                                        <%# Eval("TIMESTAMP","{0: dd MMM, yyyy hh:mm tt}")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                       <th>S.No
                                        </th>
                                        <th>Module
                                        </th>
                                        <th>Name
                                        </th>
                                        <th>Mail ID
                                        </th>
                                        <th>Organisation
                                        </th>
                                        <th>Status
                                        </th>
                                        <th>Created By
                                        </th>
                                        <th>TimeStamp
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
