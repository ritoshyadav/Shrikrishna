﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BIIING.aspx.cs" Inherits="Shrikrishna.BIIING" EnableEventValidation="false" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style2 {
            height: 20px;
        }
        .auto-style4 {
            width: 182px;
        }
        .auto-style5 {
            width: 105px;
            height: 112px;
             margin-left: 5px;
         }
        .auto-style8 {
            width: 400px
        }
        .auto-style9 {
            width: 89px;
        }
         .auto-style10 {
             width: 251px;
         }
         </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script>
        
    function printpage() {
        
        window.print();

    }

    </script>
    
              <!-- Horizontal Form -->
             
              
                  <form class="form-horizontal">
                         <div class="box-body">
                    <div class="form-group">
                      <div class="col-sm-12" style="text-align:center">
                          <center>
                          
                             <asp:Panel ID="Panel1" runat="server">

                                 <table style="width:100%;" border="1">
                                     <tr>
                                         <td colspan="3"align="center" class="auto-style2"><font size="0.5"> TAX INVOICE</font></td>
                                         <caption>
                               
                                         </caption>

                                     </tr>
                                     <tr>
                                         <td colspan="3"><table style="width:100%;">
                                             <tr>
                                                 <td style="text-align:center" class="auto-style9"> &nbsp;&nbsp;<img src="dist/css/user4-160x160.jpg" alt="User Image" class="auto-style5"></td>
                                                 <td style="text-align:center"><b><h7> SHRIKRISHNA OFFSET PRINTERSS</h7></b>
                                             <br />
                                             <font size="0.5"><b>House of Professional Multicolor Printing &amp; Packaging Solutions</b><br /> Nagpur Co-Operative Housing Society Building,<br /> Gandhibagh,Nagpur[M.S] -440002<br /> Tel - 0712-2683425/26<br /> Email-Salesshreekrishna@gmail.com<br />
                                             <b>GSTIN No. - 27ADOPK0202F1ZZ</b></font></td>
                                                 <td>&nbsp;  &nbsp; &nbsp; &nbsp; &nbsp;     </td>

                                             </tr>
                                                         </table>
                                           
                                             </td>

                                     </tr>
                                     <tr>
                                         <td class="auto-style8">Bill to<br />
                                             <asp:Label ID="Label2" runat="server" Text="Label" Font-Bold="True"></asp:Label><br />
                                             <asp:Label ID="lblofficeaddress" runat="server" Text="Label"></asp:Label><br />
                                             State - <asp:Label ID="Label4" runat="server" Text="Label" Font-Bold="True"></asp:Label><br />
                                             State Code -<asp:Label ID="Label5" runat="server" Text="Label" Font-Bold="True"></asp:Label><br />
                                             <table style="width:100%;" border="1"><tr><td>GSTIN No :- <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td></tr></table>
                                         </td>
                                         <td class="auto-style8">Palce Of Supply<br />
                                             <asp:Label ID="Label6" runat="server" Text="Label" Font-Bold="True"></asp:Label><br />
                                             <asp:Label ID="lblsupplyaddress" runat="server" Text="Label"></asp:Label><br />
                                             State - <asp:Label ID="Label7" runat="server" Text="Label" Font-Bold="True"></asp:Label><br />
                                             State Code -<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label><br />
                                         </td>
                                         <td><table style="width:100%;" border="1">
                                             <tr><td class="auto-style4">Transporting;</td><td>
                                                 <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                                                 </td></tr>
                                             <tr><td class="auto-style4">LR No.</td><td>
                                                 <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                                                 </td></tr>
                                             <tr><td class="auto-style4">D.M No. </td><td>P.O No. </td></tr>
                                             <tr><td class="auto-style4"><asp:Label ID="lbldmno" runat="server" Text="Label"></asp:Label> </td><td><asp:Label ID="lblpono" runat="server"></asp:Label> </td></tr>
                                             <tr><td class="auto-style4">D.M Date </td><td>P.O Date</td></tr>
                                             <tr><td class="auto-style4"><asp:Label ID="lbldmdate" runat="server" Text="D.M Date"></asp:Label></td><td><asp:Label ID="lblpodate" runat="server" Text="    "></asp:Label> </td></tr>
                                             <tr><td class="auto-style4">INVOICE No.</td>
                                                 <td class="auto-style4" style="text-align:center">Date</td></tr>
                                             <tr><td class="auto-style4" style="text-align:center"><asp:Label ID="Label9" runat="server" Text="Label" Font-Bold="True"></asp:Label></td><td  style="text-align:center"><asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></td></tr>
                                             
                                             </table></td>

                                     </tr>
                                     

                                             
                                     <asp:GridView ID="GridView1" runat="server" Width="100%">
                                     </asp:GridView>

                                     <table border="1" style="width:100%;">
                                         <tr>
                                             <td class="auto-style15">
                                                 <font size="0.75">
                                                     Amount Chargeable(In Words)<br />
                                                     <asp:Label runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                 </font>
                                             </td>
                                             <td class="auto-style10" rowspan="6">
                                                 <br />
                                             </td>
                                             <td rowspan="6"class="auto-style10"  style="text-align:center"><font size=1>For Shrikrishna Offset Printers</font><br />
                                                 <br />
                                                 <br />
                                                 <br />
                                                 <font size=1>Authorisewd Signatory</font> </td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style10"><b><font size=1.5>Company&#39;s PAN: ADOPK0202F</font></b></td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style10" style="text-align:center"><font size=1><b>Bank Details -</b></font></td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style10"><font size=1.25><b>Bank Name - Punjab National Bank</b></font></td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style10"><font size=1.25<b>Account Number - 0353009301056713</b></font></td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style10"><font size=1.25<b>IFSC Code -PUNB0035300</b></font></td>
                                         </tr>
                                         <tr>
                                             <td colspan="3" style="text-align:right">E&amp;OE</td>
                                         </tr>
                                         <tr>
                                             <td colspan="3" style="text-align:center">
                                                 <font size="1.5">
                                                     SUBJECT TO NAGPUR JURISDICTION</font>
                                                 <br />
                                                 <font size=1>This is a Computer Genrated invoice</font> </td>
                                         </tr>
                                     </table>

                                 </table>

                             </asp:Panel>
                         </center>
                      </div>
                    </div>
                  </div><!-- /.box-body -->
                      <div class="col-sm-12" style="text-align:right">
                        <div class="box-footer">
                      <right>
                      <asp:Button ID="btnbill" runat="server"  class="btn btn-success" Text="Bill Print"  OnClick="btnbill_Click1" OnClientClick="return printpage();"/>
                                         </right>
                  </div><!-- /.box-footer -->
                          </div>
                    
            
              <!-- general form elements disabled -->
    <
           
            </form>
         
</asp:Content>
