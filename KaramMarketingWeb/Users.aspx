<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="KaramMarketingWeb.Users" %>
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
           .modalBackgroundforextender {
            background-color: lightgray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
          
    </style>

    <script type="text/javascript" src="/NewTable/DataTables/datatables.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#inventory').dataTable();
        });

    </script>
    
    
       
     <script type="text/javascript">
         function ShowUserCreation(ReserveID) {
             
             window.open("CreateUser.aspx?UID=" + ReserveID, "_self");
         }
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body"  runat="server">
    &nbsp;&nbsp;&nbsp;
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
                            <h5 class="m-0 text-dark">Users List</h5>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">User Details</li>
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
                               
                                 <asp:Button ID ="Create" runat="server"   CausesValidation="false" Text="Create" OnClick="Create_Click" class="btn btn-success" Width="90px"  Height="31px" />
                          </ol>
                      
                      
                      </div>
                              
                 </div>
            </div>
           <div class="table-responsive" style="overflow: auto">
                         <asp:ListView ID="lvRMGateinDetails" runat="server"  >
                            <LayoutTemplate>
                                <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                    <thead>
                                        <tr>
                                               <th>S.No
                                                </th>
                                                <th>User Name
                                                </th>
                                                <th>First Name
                                                </th>
                                                <th>Last Name
                                                </th>
                                                 <th>Role
                                                </th>
                                                <th>Email
                                                </th>
                                                <th>Phone
                                                </th>
                                                 <th>Location
                                                </th>
                                            <th>Region
                                                </th>
                                                <th>Status
                                                </th>
                                                 <th>User   
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
                                        <%-- <%# Eval("UserName") %>--%>
                                        <a href="#" id="id" onclick="ShowUserCreation('<%# Eval("UserID")%>');"><%# Eval("UserName")%></a>
                                    </td>
                                    <td>
                                        <%# Eval("FirstName") %>
                                    </td>
                                    <td>
                                        <%# Eval("LastName") %>
                                    </td>
                                     <td>
                                        <%# Eval("Role") %>
                                    </td>
                                    <td>
                                        <%# Eval("Email") %>
                                    </td>
                                    <td>
                                        <%# Eval("Phone") %>
                                    </td>
                                    <td>
                                        <%# Eval("UM_PlantName") %>
                                    </td>
                                     <td>
                                        <%# Eval("Region") %>
                                    </td>
                                    <td>
                                        <%# Eval("Status1") %>
                                    </td>
                                    <td>
                                        <%# Eval("UM_Modified_By") %>
                                    </td>
                                    <td>
                                        <%# Eval("TmeStamp") %>
                                    </td>
                 
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                          <th>S.No
                                            </th>
                                            <th>User Name
                                            </th>
                                            <th>First Name
                                            </th>
                                            <th>Last Name
                                            </th>
                                             <th>Role
                                            </th>
                                            <th>Email
                                            </th>
                                            <th>Phone
                                            </th>
                                             <th>Location
                                            </th>
                                            <th>Status
                                            </th>
                                             <th>User   
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
</asp:Content>


