<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BIIING.aspx.cs" Inherits="Shrikrishna.BIIING" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            margin-top: 21px;
        }
        .auto-style2 {
            height: 20px;
        }
        .auto-style3 {
            width: 236px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script>
        
    function printpage() {
        
        window.print();

    }

    </script>
     <div class="auto-style1">
              <!-- Horizontal Form -->
              <div class="box box-info">
                <div class="box-header with-border">
                  
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
                                             <font size="0.5">House of Professional Multicolor Printing &amp; Packaging Solutions<br /> Nagpur Co-Operative Housing Society Building,<br /> Gandhibagh,Nagpur[M.S] -440002<br /> Tel - 0712-2683425/26<br /> Email-Salesshreekrishna@gmail.com<br />
                                             <b>GSTIN No. - 27ADOPK0202F1ZZ</b></font></td>
                                                 <td>&nbsp;  &nbsp; &nbsp; &nbsp; &nbsp;     </td>

                                             </tr>
                                                         </table>
                                           
                                             </td>

                                     </tr>
                                     <tr>
                                         <td class="auto-style8">Bill to<br />
                                             <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
                                             State - <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
                                             State Code -<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label><br />
                                             <table style="width:100%;" border="1"><tr><td>GSTIN No :- <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td></tr></table>
                                         </td>
                                         <td class="auto-style8">Palce Of Supply<br />
                                             <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label><br />
                                             State - <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label><br />
                                             State Code -<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label><br />
                                         </td>
                                         <td><table style="width:100%;" border="1">
                                             <tr><td class="auto-style4">Transporting;</td><td>&nbsp;</td></tr>
                                             <tr><td class="auto-style4">LR No.</td><td>&nbsp;</td></tr>
                                             <tr><td class="auto-style4">INVOICE No.</td>
                                                 <td class="auto-style4">Date</td></tr>
                                             <tr><td class="auto-style4"><asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></td><td><asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></td></tr>
                                             </table></td>

                                     </tr><tr>
                                     <asp:GridView ID="GridView1" runat="server" Width="100%"></asp:GridView></tr>
                                     <table style="width:100%;" border="1">
                                         <tr>
                                             <td class="auto-style4"><h7>Amount Chargeable(In Words)<br />
                                                 <asp:Label runat="server" Text="Label"></asp:Label>
                                                 </h7></td>
                                             <td rowspan="6" class="auto-style3"><br /></td>
                                             <td rowspan="6" style="text-align:center">
                                                 For Shrikrishna Offset Printers<br />
                                                 <br />
                                                 <br />
                                                 <br />
                                                 Authorisewd Signatory
                                             </td>

                                         </tr>
                                         <tr>
                                             <td class="auto-style4">Company's PAN: ADOPK0202F</td>
                                             
                                             

                                         </tr>
                                         <tr>
                                             <td class="auto-style4">Bank Details -</td>
                                            
                                             

                                         </tr>
                                         <tr>
                                             <td class="auto-style4">Bank Name - Punjab National Bank</td>
                                            
                                            

                                         </tr>
                                         <tr>
                                             <td class="auto-style4">Account Number - 0353009301056713</td>
                                            
                                             

                                         </tr>
                                         <tr>
                                             <td class="auto-style4">IFSC Code -PUNB0035300</td>
                                           
                                             

                                         </tr>
                                         <tr>
                                             <td colspan="3" style="text-align:right">E&OE</td>
                                             

                                         </tr>
                                         <tr>
                                             <td colspan="3" style="text-align:center"><h7>SUBJECT TO NAGPUR JURISDICTION</h7><br />
                                                 This is a Computer Genrated invoice
                                             </td>
                                            

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
                      <asp:Button ID="btnbill" runat="server"  class="btn btn-success" Text="Bill Print" OnClientClick="return printpage();" OnClick="btnbill_Click1" />
                                         </right>
                  </div><!-- /.box-footer -->
                          </div>
                      <div class="col-sm-12" style="text-align:center">
                         
                        <asp:Label ID="Label3" runat="server" Text="" Font-Bold="True" ForeColor="#339933"></asp:Label>
                         
                      </div>
                </form>
              </div><!-- /.box -->
              <!-- general form elements disabled -->
           
            </div>
         </div>
</asp:Content>
