<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="KaramMarketingWeb.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <%--  <a href="Pollux/PolluxTable.scss">Pollux/PolluxTable.scss</a>--%>
    <link href="W3S/w3css.css" rel="stylesheet" />
    <style type="text/css">
          .White {
            background-color: #e6e6e6;
            border: medium;
            border-color:black;
            color: black;
          }
        .Orange
        {
            background-color: darkorange;
             border-color:black;
            color: white;
        }
      .Green {
        background-color: #37e666;
         border-color:black;
        color: White;
      }
      .Red {
        background-color: red;
         border-color:black;
        color: White;
      }

      .flex-container {
          padding: 0;
          margin: 0;
          list-style: none;
          border: 1px solid silver;
          -ms-box-orient: horizontal;
          display: -webkit-box;
          display: -moz-box;
          display: -ms-flexbox;
          display: -moz-flex;
          display: -webkit-flex;
          display: flex;
        }

        .nowrap  { 
          -webkit-flex-wrap: nowrap;
          flex-wrap: nowrap;
        }

        .wrap    { 
          -webkit-flex-wrap: wrap;
          flex-wrap: wrap;
        }  
        .wrap li {
          background: azure;
        }

        .wrap-reverse         { 
          -webkit-flex-wrap: wrap-reverse;
          flex-wrap: wrap-reverse;
        }  
        .wrap-reverse li {
          background: deepskyblue;
        }

        .flex-item {
          background: blue;
          padding: 5px;
          width: 31%;
          height: 200px;
          margin: 10px;
          line-height: 100px;
          color: white;
          font-weight: bold;
          font-size: 2em;
          text-align: center;
        }

    </style>
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
     <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    
   
     
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
                        <div class="col-sm-6">
                            <h5 class="m-0 text-dark">Home</h5>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                           
                        </div>
                       
                    </div>
                </div>
            </div>
        <div class="content">
        <div class="container-fluid">
             <div class="row">
               
                  <div class="col-lg-12">
                      <div class="card">
                          
                        <ul class="flex-container wrap">
                          <li class="flex-item">
                              <i class="fa fa-truck w3-xxlarge"></i>
                                <h1> <asp:Label ID="lblDispatch" runat="server" Font-Size="24" Text="100"></asp:Label></h1>
                          </li>
                          <li class="flex-item">2</li>
                          <li class="flex-item">3</li>
                          <li class="flex-item">4</li>
                          <li class="flex-item">5</li>
                          <li class="flex-item">6</li>
                          <li class="flex-item">7</li>
                          <li class="flex-item">8</li>
                           <li class="flex-item">8</li>
                           <li class="flex-item">8</li>
                          <li class="flex-item">8</li>
                          <li class="flex-item">8</li> 
                          <li class="flex-item">8</li>
                           <li class="flex-item">9</li>
                        </ul>

                         
                      </div>
                 </div>
               
             </div>
         </div>
      
            </div>
</asp:Content>


