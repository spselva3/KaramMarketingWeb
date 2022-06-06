<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddSalesOrder.aspx.cs" Inherits="KaramMarketingWeb.AddSalesOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


       <%--<link href="FormDesign/form.css" rel="stylesheet" />--%>
   
    <style>

         table.lamp th {
                color: white;
                background-color: navy;
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
      .form-inline1 {  
          display: flex;
          flex-flow: row wrap;
          align-items: center;
        }

        .form-inline1 label {
          margin: 5px 10px 5px 0;
        }

        .form-inline1 input {
          vertical-align: middle;
          margin: 5px 10px 5px 0;
          padding: 5px;
          border: 1px solid #ddd;
        }

        .form-inline1 button {
          padding: 10px 10px;
          background-color: dodgerblue;
          border: 1px solid #ddd;
          cursor: pointer;
        }

        .form-inline1 button:hover {
        }

        @media (max-width: 500px) {
            .form-inline1 input {
                margin: 10px 0;
            }

            .form-inline1 {
                flex-direction: column;
                align-items: stretch;
            }
        }

        #pageloaddiv {
        position: fixed;
        left: 0px;
        top: 0px;
        width: 100%;
        height: 100%;
        z-index: 1000;
        background: url('pageloader.gif') no-repeat center center;
        }

    </style>

     <script type="text/javascript">
         //DataTables Initialization for Map Table Example
         $(document).ready(function () {
             $('#inventory').dataTable();
         });

     </script>

   
    <script type="text/javascript">
        $(window).load(function () {
            $("#pageloaddiv").fadeOut(2000);
        });
    </script>
 
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

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
                             <asp:Label ID="lblHeading" runat="server" Text="Add Sales Order" Font-Size="Larger" Font-Bold="true" class="m-0 text-dark"></asp:Label>
                        </div>
                    </div>
                </div>
      </div>
    <div class="content">
        <div class="container-fluid">
             <div class="row">
                 
                     <div class="col-lg-12">
                      <div class="card" >
                           <div class="card-body"  >
                                      <div class="form-inline1">
                                              <label for="Firstname">Sales Order :</label>
                                                <asp:TextBox ID="txtSalesOrder"  class="form-control" runat="server" Width="250px"></asp:TextBox>
                                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100" 
                                                CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" 
                                                ServiceMethod="GetSalesOrder" TargetControlID="txtSalesOrder">
                                                 </ajaxToolkit:AutoCompleteExtender> &nbsp;

                                                  <asp:Button ID ="btnSearchSO" runat="server"
                                                      CausesValidation="false" Text="Search"
                                                      class="btn btn-primary" OnClick="btnSearchSO_Click" 
                                                      Width="90px"  Height="36px"   />&nbsp;
                                  
                                   </div>
                               
                            </div>
                      </div>
                  </div>
               
                 <div class="col-lg-12">
                      <%--<div class="card" >  --%> 
                                 <div class="table-responsive" style="overflow: scroll; max-height:400px;">
                   
                                     <asp:ListView ID="lvProductdetails" runat="server" OnItemDataBound="lvProductdetails_ItemDataBound" >
                                        <LayoutTemplate>
                                              <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%; max-height:250px;"  id="inventory">
                                                <tr>
                                                    <th style="width: 10px;">S.No.</th>
                                                     <th>Item Code</th>
                                                    <th>Item Desc</th>
                                                    <th>Available Qty</th>
                                                    <th>Demand Qty</th>
                                                    <th>UOM</th>
                                                     <th>PackStyle</th>
                                                    <th>Status</th>
                                                </tr>
                                                <tr id="ItemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center;"><%# Container.DataItemIndex + 1%></td>
                                               <td>
                                                    <asp:Label ID="lblItemCode1" runat="server" Text='<%# Eval("SO_MatCode") %>'></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:Label ID="lblItemDesc1" runat="server" Text='<%# Eval("SO_Matdesc") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAvailableQty" runat="server" Text='<%# Eval("AvailableQty") %>'></asp:Label>
                                                </td>

                                                <td>
                                                    <asp:Label ID="lblSOQty" runat="server" Text='<%# Eval("SO_SOQuantity") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblUOM1" runat="server" Text='<%# Eval("SO_UOM") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                     <asp:Label ID="lblPackStyle" runat="server" Text='<%# Eval("SO_PackType") %>'></asp:Label>
                                                       <%--<asp:Label ID="lblPackStyle" runat="server"  Text='<%# Eval("PackStyle") %>'  Visible="false"></asp:Label>--%>
                                                       <%--<asp:DropDownList ID="dllPackStyle" runat="server" Width="100px"></asp:DropDownList>--%>

                                                 </td>
                                                 <td>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("SO_Rowstatus") %>'></asp:Label>
                                                </td>
                                                
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                     <th style="width: 10px;">S.No.</th>
                                                     <th>Item Code</th>
                                                    <th>Item Desc</th>
                                                    <th>Available Qty</th>
                                                    <th>Demand Qty</th>
                                                    <th>UOM</th>
                                                     <th>PackStyle</th>
                                                    <th>Status</th>
                                                </tr>
                                                <tr>
                                                    <td colspan="20">No Records Found.
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:ListView>
                                 </div>
                      <%--</div>--%>
                  </div>


                 <div class="col-lg-12">
                      <div class="card" >
                           <div class="card-body"  >
                                     <div class="form-inline1">
                                      <label for="Firstname">Reservation ID:</label>
                                        <asp:TextBox ID="txtReservationID" ReadOnly="true" class="form-control" runat="server" Width="250px"></asp:TextBox>
                                     
                                          <asp:Button ID ="btnGenerateReservation" runat="server"
                                              CausesValidation="false" Text="Generate Reservation ID"
                                              class="btn btn-primary"  OnClick="btnGenerateReservation_Click" 
                                              Width="190px" Height="36px" />&nbsp;

                                          <asp:Button ID ="btnUpdate" runat="server"  Text="Create Reservation" class="btn btn-success" OnClick="btnUpdate_Click"  Width="190px" Height="36px"  />&nbsp;&nbsp;
                                      <asp:Button ID ="btnClose" runat="server"   CausesValidation="false" Text="Close" class="btn btn-danger" OnClick="btnClose_Click" Width="120px"  Height="36px" />&nbsp;
                                  
                                  
                                   </div>
                               
                            </div>
                      </div>
                  </div>
             </div>
         </div>
       </div>
</asp:Content>

