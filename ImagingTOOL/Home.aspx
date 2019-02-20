<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="hometest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main-content">
         <!-- BEGIN PAGE CONTAINER-->
         <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->   
            <div class="row-fluid">
               <div class="span12">
                  
                  <h3 class="page-title">
                      Home 
                  </h3>
                   
               </div>
            </div>
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row-fluid">
                <div class="span12 sortable">
                    <!-- BEGIN SAMPLE FORMPORTLET-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4>Home Page</h4>
                                        <span class="tools">
                                        <a href="javascript:;" class="icon-chevron-down"></a>
                                        <a href="javascript:;" class="icon-remove"></a>
                                        </span>
                        </div>
                        <div class="widget-body">
                            <!-- BEGIN FORM-->
                            <form action="#" class="form-horizontal">
                             <div class="row-fluid">
                   <div class="span12">
                       <!-- BEGIN CUSTOM BUTTONS WITH ICONS PORTLET-->
                      
                       <div class="row-fluid">
                           <a href="#" class="icon-btn span2">
                               <i class="icon-indent-right"></i>
                               <div>Purchase Order</div>
                               <span class="badge badge-important">2</span>
                           </a>
                           <a href="#" class="icon-btn span2">
                               <i class="icon-barcode"></i>
                               <div>Purchase Invoice</div>
                               <span class="badge badge-success">4</span>
                           </a>
                           <a href="#" class="icon-btn span2">
                               <i class="icon-bar-chart"></i>
                               <div>Purchase/Inward Register</div>
                           </a>
                           <a href="#" class="icon-btn span2">
                               <i class="icon-sitemap"></i>
                               <div>Sales Order</div>
                           </a>
                           <a href="#" class="icon-btn span2">
                               <i class="icon-check-empty"></i>
                               <div>Sales Manager Checking</div>
                               <span class="badge badge-success">4</span>
                           </a>
                           <a href="#" class="icon-btn span2">
                               <i class="icon-tags"></i>
                               <div>Sales Register</div>
                               <span class="badge badge-info">12</span>
                           </a>
                       </div>
                       <div class="row-fluid">
                           <a href="#" class="icon-btn span2">
                               <i class="icon-bullhorn"></i>
                               <div>Agewise Receivables</div>
                               <span class="badge badge-important">3</span>
                           </a>
                           <a href="#" class="icon-btn span2">
                               <i class="icon-map-marker"></i>
                               <div>Delivery Challan</div>
                           </a>

                           <a href="#" class="icon-btn span2">
                               <i class="icon-money"></i>
                               <div>Sales Order Register Report</div>
                              
                           </a>
                           <a href="ReportAR.aspx" class="icon-btn span2">
                               <i class="icon-thumbs-up"></i>
                               <div>AR(Agewise Receivables) Report</div>
                               <span class="badge badge-info">2</span>
                           </a>
                           <a href="#" class="icon-btn span2">
                               <i class="icon-cloud"></i>
                               <div>Statutoy Form Report</div>
                               <span class="badge badge-important">2</span>
                           </a>
                           <a href="#" class="icon-btn span2">
                               <i class="icon-globe"></i>
                               <div>Stock Statement Report</div>
                           </a>
                       </div>
                       <div class="row-fluid">
                           
                           <a href="#" class="icon-btn span2">
                               <i class="icon-columns"></i>
                               <div>Purchase Order Register Report</div>
                               <span class="badge badge-info">221</span>
                           </a>
                           <a href="#" class="icon-btn span2">
                               <i class="icon-wrench"></i>
                               <div>Orders Pending Supplier Report</div>
                           </a>
                           <a href="#" class="icon-btn span2">
                               <i class="icon-magic"></i>
                               <div>Purchase Register Report</div>
                           </a>
                           <a href="#" class="icon-btn span2">
                               <i class="icon-credit-card"></i>
                               <div>Discrepancy Report</div>
                           </a>
                       </div>
                       <!-- END CUSTOM BUTTONS WITH ICONS PORTLET-->
                   </div>
                   <span class="space20">&nbsp;</span>
               </div>
                            </form>
                            <!-- END FORM-->
                            <br />
                          
                         
                        </div>
                    </div>
                    <!-- END SAMPLE FORM PORTLET-->
                </div>
            </div>

            <!-- END PAGE CONTENT-->         
         </div>
         <!-- END PAGE CONTAINER-->
      </div>

      


 
</asp:Content>

