<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoadPalletAdd.aspx.cs" Inherits="KaramMarketingWeb.LoadPalletAdd" %>
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
    </style>
     <script type="text/javascript">
         //DataTables Initialization for Map Table Example
         $(document).ready(function () {
             $('#inventory').dataTable();
         });

     </script>
    <script type="text/javascript">

        function ValidateData() {
            debugger;

            var Firstname = document.getElementById("txtFName").value;
            if (Firstname == "") {
                alert("Please enter First Name.");
                document.getElementById("txtFName").focus();
                return false;
            }
            var Username = document.getElementById("txtUname").value;
            if (Username == "") {
                alert("Please enter User Name.");
                document.getElementById("txtUname").focus();
                return false;
            }
            var Password = document.getElementById("txtPswd").value;
            if (Password == "") {
                alert("Please enter Password");
                document.getElementById("txtPswd").focus();
                return false;
            }

            var Role = document.getElementById("ddlRole").value;
            if (Role == "-1") {
                alert("Please Select Role");
                document.getElementById("ddlRole").focus();
                return false;
            }
            var Status = document.getElementById("ddlStatus").value;
            if (Status == "Please Select") {
                alert("Please Select Status");
                document.getElementById("ddlStatus").focus();
                return false;
            }

        }

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
    <div class="content-header">
                <div class="container-fluid">
                    <div class="row mb-2">
                        <div class="col-sm-3">
                             <asp:Label ID="lblHeading" runat="server" Text="Load Optimisation" Font-Size="Larger" Font-Bold="true" class="m-0 text-dark"></asp:Label>
                           
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">Pack List</li>
                            </ol>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
      </div>
    <div class="content">
        <div class="container-fluid">

              <div class="row">
                  <div class="col-sm-12">
                      <div class="card" >
                               <div class="card-body"  >
                                <asp:ListView ID="lvPalletAdd" runat="server">
                                        <LayoutTemplate>
                                           <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                                <tr>
                                                    <th>
                                                        <asp:CheckBox ID="chkHeader" runat="server" OnCheckedChanged="chkHeader_CheckedChanged" AutoPostBack="true" />
                                                    </th>
                                                    <th style="width: 10px;">S.No.</th>
                                                    <th>ItemCode</th>
                                                    <th>Length</th> 
                                                    <th>Width</th>
                                                    <th>Height</th>
                                                     <th>Weight</th>
                                                    <th>Qty</th>
                                                    <th>Delete</th>
                                                </tr>
                                                <tr id="ItemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkSelect" runat="server"  />
                                                </td>
                                                <td style="text-align: center;"><%# Container.DataItemIndex + 1%></td>
                                               
                                                <td>
                                                    <asp:Label ID="lblMatcode" runat="server" Text='<%# Eval("PLB_MatCode") %>'></asp:Label>
                                                </td>
                                              
                                              
                                                <td>
                                                    <asp:Label ID="lblLength" runat="server" Text='<%# Eval("l") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblWidth" runat="server" Text='<%# Eval("w") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblHeight" runat="server" Text='<%# Eval("h") %>'></asp:Label>
                                                </td> 
                                                <td>
                                                    <asp:Label ID="lblPwt" runat="server" Text='<%# Eval("pwt") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblQty" runat="server" Text='<%# Eval("TotalCount") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                <asp:LinkButton ID="lnkclose" runat="server" ToolTip="Delete" CausesValidation="false" OnClick="lnkclose_Click"
                                                                OnClientClick="return DeleteConfirmation();">
                                                 <asp:Image ID="imgclose" runat="server" ImageUrl="~/images/DeleteIcon.png" Width="20" Height="20" alt="" />
                                                            </asp:LinkButton>
                                                     </td>

                                               
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                                <tr>
                                                    <th style="width: 10px;">S.No.</th>
                                                    <th>ItemCode</th>
                                                    <th>Length</th>
                                                    <th>Width</th>
                                                    <th>Height</th>
                                                    <th>Qty</th>
                                                    <th>Delete</th>
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

              <div class="row">
                 <div class="col-lg-12">
                                  <div class ="center">
                                      <asp:Button ID ="btnCreate" runat="server"  Text="Next" class="btn btn-success" OnClick="btnCreate_Click" OnClientClick="return ValidateData();" Width="90px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnClear" runat="server"   CausesValidation="false" Text="Clear" class="btn btn-warning" OnClick="btnClear_Click" Width="90px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnClose" runat="server"   CausesValidation="false" Text="Close" class="btn btn-danger" OnClick="btnClose_Click" Width="90px"  Height="31px" />
                                      <asp:HiddenField ID="hdnUSERID" runat="server" Value="" />
                                   </div>
                               </div>
            </div>
            
              <div ID ="panelContainer" runat="server" class="row">
                <div class="col-lg-2">
                                   <div class="form-group">

                                                <label for="Firstname">Truck type :</label>
                                             <asp:DropDownList ID ="ddlTruckType"  class="form-control"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTruckType_SelectedIndexChanged">
                                                 
                                             </asp:DropDownList>
                                  </div>
                  </div>

                 <div class="col-sm-2">
                                   <div class="form-group">
                                      <label for="Firstname">Count :</label>
                                         <input type="text" class="form-control" id="txtCount" autocomplete="off" runat="server" placeholder="Total Truck" name="Firstname" >
                                  </div>
                      
                  </div>

                  <div class="col-sm-2">
                                   <div class="form-group">
                                      <label for="Firstname">Length :</label>
                                         <input type="text" class="form-control" id="txtLength" autocomplete="off" runat="server" placeholder="Length" name="Firstname" >
                                  </div>
                      
                  </div>

                  <div class="col-sm-2">
                                   <div class="form-group">
                                      <label for="Firstname">Width :</label>
                                         <input type="text" class="form-control" id="txtWidth" autocomplete="off" runat="server" placeholder="Width" name="Firstname" >
                                  </div>
                      
                  </div>
             

                  <div class="col-sm-2">
                                   <div class="form-group">
                                      <label for="Firstname">Height :</label>
                                         <input type="text" class="form-control" id="txtHeight" autocomplete="off" runat="server" placeholder="Height" name="Firstname" >
                                  </div>
                      
                  </div>

                  <div class="col-sm-2">
                                   <div class="form-group">
                                      <label for="Firstname">Max Weight :</label>
                                         <input type="text" class="form-control" id="txtWeight" autocomplete="off" runat="server" placeholder="Truck Capacity" name="Firstname" >
                                  </div>
                      
                  </div>
                 <div class="col-lg-12">  
                               <div class="card-body">
                                  <div class ="center">
                                      <asp:Button ID ="btnTruckNext" runat="server"  Text="Next" class="btn btn-success" OnClick="btnTruckNext_Click" OnClientClick="return ValidateData();" Width="90px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnTruckClear" runat="server"   CausesValidation="false" Text="Clear" class="btn btn-warning" OnClick="btnTruckClear_Click" Width="90px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnTruckClose" runat="server"   CausesValidation="false" Text="Close" class="btn btn-danger" OnClick="btnTruckClose_Click" Width="90px"  Height="31px" />
                                      <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                                   </div>
                               </div>
                        
               
            </div>

            </div>
  
              <div class="col-lg-12">
                      <div class="card" >  
                          <div class="card-body"  >
                                <asp:ListView ID="LvTruckList" runat="server">
                                        <LayoutTemplate>
                                           <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                                <tr>
                                                    <th style="width: 10px;">S.No.</th>
                                                    <th>Truckid</th>
                                                    <%--<th>ProdCnt</th>--%> 
                                                    <th>Cargo Volume</th>
                                                    <th>Volume Percent</th>
                                                     <th>FTL/PTL</th>
                                                     
                                                </tr>
                                                <tr id="ItemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center;"><%# Container.DataItemIndex + 1%></td>
                                                <td>
                                                    <asp:Label ID="lblMatcode" runat="server" Text='<%# Eval("Truckid") %>'></asp:Label>
                                                </td>
                                                <%--<td>
                                                    <asp:Label ID="lblLength" runat="server" Text='<%# Eval("ProdCnt") %>'></asp:Label>
                                                </td>--%>
                                                 <td>
                                                    <asp:Label ID="lblWidth" runat="server" Text='<%# Eval("CargoVolume") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblHeight" runat="server" Text='<%# Eval("VolumePercent") %>'></asp:Label>
                                                </td> 
                                                 <td>
                                                    <asp:Label ID="lblLoad" runat="server" Text='<%# Eval("TruckLoad") %>'></asp:Label>
                                                </td> 
                                               
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                                <tr>
                                                     <th style="width: 10px;">S.No.</th>
                                                    <th>Truckid</th>
                                                    <th>ProdCnt</th> 
                                                    <th>Cargo Volume</th>
                                                    <th>Volume Percent</th>
                                                      <th>FTL/PTL</th>
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
         </div>

    
</asp:Content>
