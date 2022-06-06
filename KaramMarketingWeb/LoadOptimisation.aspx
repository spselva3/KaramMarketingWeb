<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoadOptimisation.aspx.cs" Inherits="KaramMarketingWeb.LoadOptimisation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="LoadOptimisation/Load1.css" rel="stylesheet" />
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

    </style>
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.0.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" 
    integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous">

</script>
     <script type="text/javascript">
         //DataTables Initialization for Map Table Example
         $(document).ready(function () {
             $('#inventory').dataTable();
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
                             <asp:Label ID="lblHeading" runat="server" Text="Load Optimaisation" Font-Size="Larger" Font-Bold="true" class="m-0 text-dark"></asp:Label>
                        </div>
                    </div>
                </div>
      </div>
    <div class="content">
        <div class="container-fluid">
             <div class="row">
                  <div class="col-md-12">
            <div class="tab" role="tabpanel">
                <!-- Nav tabs -->
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#SectionProduct" aria-controls="home" role="tab" data-toggle="tab">
                       <i class="fas fa-th"></i> &nbsp; Product</a></li>
                    <li role="presentation"><a href="#Section2" aria-controls="profile" role="tab" data-toggle="tab"> 
                         <i class="fas fa-truck"></i> &nbsp; Container</a></li>
                    <li role="presentation"><a href="#Section3" aria-controls="messages" role="tab" data-toggle="tab">
                        <i class="fas fa-boxes"></i> &nbsp;Stuffing</a></li>
                </ul>
                <!-- Tab panes -->
                <div class="tab-content">
                    <div role="tabpanel"  class="tab-pane fade in active" id="SectionProduct" >
                        <h3>Product Selection</h3>
                        <p>List of Product</p>
                           <div class="table-responsive" style="overflow: scroll; height:200px;">
                   
                                    <asp:ListView ID="lvMatdetails" runat="server" >
                                        <LayoutTemplate>
                                            <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%; max-height:300px;"  id="inventory">
                                                <tr>
                                                    <th>
                                                        <asp:CheckBox ID="chkHeader" runat="server" OnCheckedChanged="chkHeader_CheckedChanged" AutoPostBack="true" />
                                                    </th>
                                                    <th style="width: 10px;">S.No.</th>
                                                    <th>Item Code</th>
                                                    <th style="display: none;">Item Desc</th>
                                                        <th>Item Desc</th>
                                                    <th>Category</th>
                                                    <th>UOM</th>
                                                   
                                                    <th>Available Qty</th>
                                                    <%-- <th>Demand Qty</th>--%>
                                                </tr>
                                                <tr id="ItemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkSelect" runat="server"   />
                                                </td>
                                                <td style="text-align: center;"><%# Container.DataItemIndex + 1%></td>
                                                <td>
                                                    <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                                </td>
                                                <td style="display: none;">
                                                    <asp:Label ID="lblItemDesc" runat="server" Visible="false" Text='<%# Eval("ItemDesc") %>'></asp:Label>
                                                </td>
                                                    <td>
                                                    <asp:Label ID="lblItemDescValue" runat="server" Text='<%# Eval("ItemDesc").ToString().Length > 45 ? 
                                                            Eval("ItemDesc").ToString().Substring(0,45) : Eval("ItemDesc") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblUOM" runat="server" Text='<%# Eval("UOM") %>'></asp:Label>
                                                </td>
                                                 
                                                <td>
                                                    <asp:Label ID="lblAvailableQty" runat="server" Text='<%# Eval("AvailableQty") %>'></asp:Label>
                                                </td>
                                                <%-- <td>
                                                    <asp:TextBox ID="txtDemand" runat="server" Text="0" Width="40px" AutoCompleteType="Disabled"
                                                                onkeypress="return validateFloatKeyPress(this, event)"></asp:TextBox>
                                                </td>--%>
                                               
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <th style="width: 10px;">S.No.</th>
                                                    <th>Item Code</th>
                                                    <th>Item Desc</th>
                                                    <th>Category</th>
                                                    <th>UOM</th>
                                                    <th>Available Qty</th>
                                                    <%--<th>Demand Qty</th>--%>
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
                    <div role="tabpanel" class="tab-pane fade" id="Section2">
                        <h3>Container Selection</h3>
                        <p>List of Containers</p>
                    </div>
                    <div role="tabpanel" class="tab-pane fade" id="Section3">
                        <h3>Stuffing Result</h3>
                        <p>Container and Product Stuffing Result</p>
                    </div>
                </div>
            </div>
        </div>
                 </div>
            </div>
    </div>
</asp:Content>
