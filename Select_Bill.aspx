<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Select_Bill.aspx.cs" Inherits="Shrikrishna.Select_Bill" EnableEventValidation="false" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 class="box-title">Billing Section</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form class="form-horizontal">
                  <div class="box-body">
                    
                         
                         <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Enter Bill NO</label>
                      <div class="col-sm-10">
                        <asp:TextBox ID="Txtbillno" runat="server" class="form-control" placeholder="Enter BIll No"></asp:TextBox>   
                      </div>
                    </div>
                         
                      </div>
                      
    <div class="box-body">
                    <div class="form-group">
                      <div class="col-sm-12" style="text-align:center">
                         
                        <asp:Label ID="Label1" runat="server" Text="" Font-Bold="True" ForeColor="#339933"></asp:Label>
                         
                      </div>
                    </div>
                  </div><!-- /.box-body -->


                  <div class="box-footer">
                      <center>
                      <asp:Button ID="btnsave" runat="server"  class="btn btn-success" Text="Search" OnClick="Button1_Click" />
                      <asp:Button ID="Button2" runat="server" class="btn btn-danger" Text="Cancel" OnClick="Button2_Click" />
                   </center>
                  </div><!-- /.box-footer -->
                    <div class="box-body">
                    <div class="form-group">
                      <div class="col-sm-12" style="text-align:center">
                          <center>
                          
                              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="402px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="8" >
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                              <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                              <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prevoious" Position="TopAndBottom" Mode="NextPrevious" PageButtonCount="11" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                              <RowStyle ForeColor="#000066" />
                              <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                          </asp:GridView>

                              <asp:Label ID="Label2" runat="server"></asp:Label>
                        
                         </center>
                      </div>
                    </div>
                  </div><!-- /.box-body -->
    </form>
</asp:Content>
