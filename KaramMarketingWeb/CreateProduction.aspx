<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateProduction.aspx.cs" Inherits="KaramMarketingWeb.CreateProduction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
       <%--<link href="FormDesign/form.css" rel="stylesheet" />--%>
   
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
         .chart {
  width: 100%; 
  min-height: 450px;
}
        .White {
            background-color: #e0ecff;
           
            color: black;
          }
        .Orange
        {
            background-color: darkorange;
             
            color: white;
        }
      .Green {
        background-color: #37e666;
         
        color: White;
      }
      .Red {
        background-color: red;
        
        color: White;
      }
      .center {
      display: flex;
            justify-content: center;
    }
       .TextDate {
      width :100px;
    }
    </style>
     <script type="text/javascript">
         //DataTables Initialization for Map Table Example
         $(document).ready(function () {
             $('#inventory').dataTable();
         });

     </script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div id="ErrorMsg" class="alert alert-danger alert-dismissable" style="display: none" runat="server">
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
        <strong>
            <asp:Label ID="lblMessage" runat="server" Text="Error"></asp:Label>
        </strong>
    </div>

    <div id="lblMsg" class="alert alert-success alert-dismissable" style="display: none" runat="server">
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
        <strong>
            <asp:Label ID="lblMessage1" runat="server" Text="Error"></asp:Label>
        </strong>
    </div>
    <div class="content-header">
                <div class="container-fluid">
                    <div class="row mb-2">
                        <div class="col-sm-3">
                             <asp:Label ID="lblHeading" runat="server" Text="Update Production" Font-Size="Larger" Font-Bold="true" class="m-0 text-dark"></asp:Label>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <%--<ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">Production Updation</li>
                            </ol>--%>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
      </div>
    <div class="content">
        <div class="container-fluid">
             <div class="row">
                  <div class="col-lg-4">
                      <div class="card" >
                          
                               <div class="card-body"  >

                                   <div class="form-group">
                                      <label for="Firstname">Production ID:</label>
                                          <input type="text" class="form-control" id="lblProductionID" autocomplete="off" runat="server" placeholder="" name="Firstname" >
                                     </div>

                                   <div class="form-group">
                                      <label for="Lastname">Production TDOD:</label>
                                        <input type="date" class="form-control" id="lblProdDate" autocomplete="off" runat="server" placeholder="" name="Lastname" format="dd-MM-yyyy" >
                                 </div>
                               
                                </div>
                           
                      </div>
                      
                  </div>
                 
                  <div class="col-lg-4">
                      <div class="card" >
                               <div class="card-body"  >

                                   <div class="form-group">
                                      <label for="Firstname">Sales Order:</label>
                                          <input type="text" class="form-control" id="lblSalesOrder" autocomplete="off" runat="server" placeholder="" name="Firstname" >
                                     </div>

                                   <div class="form-group">
                                      <label for="Lastname">Requested Qty:</label>
                                      <input type="text" class="form-control" id="lblReqQty" autocomplete="off" runat="server" placeholder="" name="Lastname" >
                                    </div>
                               
                                </div>
                           </div>
                      
                      
                  </div>
                  <div class="col-lg-4">
                      <div class="card" >
                          
                               <div class="card-body"  >

                                   <div class="form-group">
                                      <label for="Firstname">Status:</label>
                                          <input type="text" class="form-control" id="lblStatus" autocomplete="off" runat="server" placeholder="" name="Firstname" >
                                     </div>

                                   <div class="form-group">
                                      <label for="Lastname">Requested TDOD:</label>
                                         <input id="txtRequetsedtdod" type="text"   class="form-control"  runat="server" >
                                    </div>
                               
                                </div>
                           
                      </div>
                      
                  </div>
                     <div id="pnlRemarks" runat="server" class="col-lg-12">
                      <div class="card" >
                               <div class="card-body"  >
                                   <div class="form-group">
                                      <label for="Firstname">Remarks :</label>
                                          <asp:TextBox ID="txtRemarks"  class="form-control" runat="server"></asp:TextBox>
                                      </div>
                                </div>
                           </div>
                  </div>
                  <div class="col-lg-12">
                      <div class="card" >
                          
                               <div class="card-body"  >

                                   <div class="form-inline">
                                      <label for="Firstname">Prod TDOD :</label>

                                         <asp:TextBox ID="txtWHTDODate" TextMode="Date" runat="server"   AutoCompleteType="Disabled"></asp:TextBox>
                                                  
                                       <asp:Button ID ="btnDateUpdate" runat="server"   CausesValidation="false" Text="Update" class="btn btn-primary" OnClick="btnDateUpdate_Click" Width="90px"  Height="31px" />&nbsp;
                                   </div>

                                  
                               
                                </div>
                           
                      </div>
                      
                  </div>
              <div class="col-lg-12">
                      <div class="card" >   
                               <div class="card-body">
                                  <div class="table-responsive" style="overflow: auto">
                                       <asp:ListView ID="lvMatdetails" runat="server" OnItemDataBound="lvMatdetails_ItemDataBound">
                                        <LayoutTemplate>
                                           <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                                <tr>
                                                   <th>S.No
                                                    </th>
                                                    <th>Production ID
                                                    </th>
                                                     <th>Sales Order
                                                    </th>
                                                     <th>Item Code
                                                    </th>
                                                    <th>Item Desc
                                                    </th>
                                                    <th>Required Qty
                                                    </th>
                                                     <th>Required Date
                                                    </th>
                                                    <th>Item Status
                                                    </th>
                                                    <th>TDOD
                                                    </th>
                                                     <th>Done
                                                    </th>
                                                </tr>
                                                <tr id="ItemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                       <ItemTemplate>
                                            <tr>
                                                 <td>
                                                    <%# Container.DataItemIndex + 1%>
                                                </td>
                                             <td> <asp:Label ID="lblProductionID" runat="server" Text='<%# Eval("ProductionID") %>'></asp:Label>
                                       
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSalesOrder" runat="server" Text='<%# Eval("SalesOrder") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                      <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                        
                                                </td>
                                                <td>
                                                    <%# Eval("ItemDesc")%>
                                                </td>
                                                 <td>
                                                    <%# Eval("RequestedQty")%>
                                                </td>
                                                 <td>
                                                    <%# Eval("RequestedDate")%>
                                                </td>
                                               <td>
                                                     <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("ItemStatus") %>'></asp:Label>
                                                   
                                                </td>
                                               <td>
                                                    <asp:TextBox ID="txtWHDate" TextMode="Date" runat="server"  Width="120px" Text='<%# Eval("ProdTDOD") %>'   AutoCompleteType="Disabled"></asp:TextBox>
                                               </td>
                                                 <td>
                                                    <asp:LinkButton ID="lnkDone" runat="server" ToolTip="Done" CausesValidation="false" OnClick="lnkDone_Click" >

                                                    <asp:Button ID="imgclose" runat="server"  Text="Done" class="btn btn-success" OnClick="lnkDone_Click"   alt="" />
                                                                        </asp:LinkButton>
                                                 </td>
                                               
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <th>S.No
                                                    </th>
                                                    <th>Production ID
                                                    </th>
                                                    <th>Sales Order
                                                    </th>
                                                    <th>Item Code
                                                    </th>
                                                    <th>Item Desc
                                                    </th>
                                                    <th>Required Qty
                                                    </th>
                                                    <th>Required Date
                                                    </th>
                                                    <th>Item Status
                                                    </th>
                                                    <th>TimeStamp
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td colspan="20">No Records Found.
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:ListView>
                                </div>
                          </div>
                      </div>
                  </div>
                 <div class="col-lg-12">
                      <div class="card" >   
                          <div class="card-body">
                               <div class ="center">
                                       <asp:Button ID ="btnProduction" runat="server"  Text="Update TDOD" class="btn btn-success" OnClick="btnProduction_Click"  Width="150px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnClose" runat="server"   CausesValidation="false" Text="Close" class="btn btn-danger" OnClick="btnClose_Click" Width="90px"  Height="31px" />
                                     
                                </div>
                            </div>
                      </div>
                  </div>
             </div>
         </div>
       </div>
</asp:Content>
