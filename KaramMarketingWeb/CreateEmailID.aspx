<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateEmailID.aspx.cs" Inherits="KaramMarketingWeb.CreateEmailID" %>
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
                             <asp:Label ID="lblHeading" runat="server" Text="Create Email" Font-Size="Larger" Font-Bold="true" class="m-0 text-dark"></asp:Label>
                           
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                           <%-- <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">Email Management</li>
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
                  <div class="col-lg-6">
                      <div class="card" >
                          <div class="card-header border-0">
                               <div class="card-body"  >

                                  <div class="form-group">
                                      <label for="Emailname">Module :</label>
                                        <asp:DropDownList class="form-control" ID="ddlModule" runat="server">
                                            <asp:ListItem Text="Please Select" Value="Please Select" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Reservation" Value="Reservation"></asp:ListItem>
                                            <asp:ListItem Text="Edit-Reservation" Value="Edit Reservation"></asp:ListItem>
                                            <asp:ListItem Text="Logistics" Value="Logistics"></asp:ListItem>
                                            <asp:ListItem Text="WareHouse" Value="WareHouse"></asp:ListItem>
                                            <asp:ListItem Text="Production" Value="Production"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                               
                                    <div class="form-group">
                                      <label for="Mobilename">Email:</label>
                                      <input type="text" class="form-control" id="txtEmail" autocomplete="off" runat="server" placeholder="Enter Recipient Email" name="Mobilename" >
                                    </div>

                                </div>
                           </div>
                      </div>
                      
                  </div>
                 
                  <div class="col-lg-6">
                           <div class="card">
                          <div class="card-header border-0">
                               <div class="card-body">
                                   
                                   <div class="form-group">
                                      <label for="Lastname">Name:</label>
                                      <input type="text" class="form-control" id="txtName" autocomplete="off" runat="server" placeholder="Enter Recipient Name" name="Lastname" >
                                    
                                    </div>
                                  

                                    <div class="form-group">
                                      <label for="Emailname">Status :</label>
                                        <asp:DropDownList class="form-control" ID="ddlStatus" runat="server">
                                            <asp:ListItem Text="Please Select" Value="Please Select" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="In-Active" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>


                           </div>
                      </div>
                    </div>

                 <div class="col-lg-12">
                      <div class="card" >   
                          <div class="card-header border-0">
                               <div class="card-body">
                                  <div class ="center">
                                      <asp:Button ID ="btnCreate" runat="server"  Text="Create" class="btn btn-success" OnClick="btnCreate_Click" OnClientClick="return ValidateData();" Width="90px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnClear" runat="server"   CausesValidation="false" Text="Clear" class="btn btn-warning" OnClick="btnClear_Click" Width="90px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnClose" runat="server"   CausesValidation="false" Text="Close" class="btn btn-danger" OnClick="btnClose_Click" Width="90px"  Height="31px" />
                                      <asp:HiddenField ID="hdnUSERID" runat="server" Value="" />
                                   </div>
                               </div>
                          </div>
                      </div>
                      
                  </div>
             </div>
         </div>
       </div>
</asp:Content>
