<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="Shrikrishna.Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="auto-style1">
              <!-- Horizontal Form -->
              <div class="box box-info">
                <div class="box-header with-border">
                  <h3 class="box-title">Customer Details</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form class="form-horizontal">
                  <div class="box-body">
                    <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Name </label>
                      <div class="col-sm-10">
                          
                          <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Enter Name Of Customer"></asp:TextBox> 
                      </div>
                    </div>
                      <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Address</label>
                      <div class="col-sm-10">
                        <asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder="Enter Address"></asp:TextBox>   
                      </div>
                    </div>
                      <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">GST No</label>
                      <div class="col-sm-10">
                          
                       <asp:TextBox ID="Txtgstno" runat="server" class="form-control" placeholder="Enter GST No" ></asp:TextBox>   
                      </div>
                    </div>
                         <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Email</label>
                      <div class="col-sm-10">
                        <asp:TextBox ID="txtemail" runat="server" class="form-control" placeholder="Enter Email"></asp:TextBox>   
                      </div>
                    </div>
                         <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Contact</label>
                      <div class="col-sm-10">
                        <asp:TextBox ID="Txtcontact" runat="server" class="form-control" placeholder="Enter Contact"></asp:TextBox>   
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
                      <asp:Button ID="btnsave" runat="server"  class="btn btn-success" Text="Save" OnClick="Button1_Click" />
                      <asp:Button ID="btnnew" runat="server" class="btn btn-primary" Text="New" OnClick="Button2_Click" />
                   </center>
                  </div><!-- /.box-footer -->

                         <div class="box-body">
                    <div class="form-group">
                      <div class="col-sm-12" style="text-align:center">
                          <center>
                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="GridView1_RowCommand" Width="402px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="8">
                              <Columns>
                                  <asp:BoundField DataField="name" HeaderText="        NAME          " />
                                  <asp:BoundField DataField="address" HeaderText="ADDRESS" />
                                  <asp:BoundField DataField="gst_no" HeaderText="GST NO" />
                                  <asp:BoundField DataField="email" HeaderText="EMAIL" />
                                  <asp:BoundField DataField="contact" HeaderText="CONTACT" />
                                  <asp:TemplateField HeaderText="Edit">
                                      <ItemTemplate>
                                          <asp:Button ID="btnedit" runat="server" CommandArgument='<%# Eval("id") %>' Text="Edit" CommandName="recordedit" />
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Delete">
                                      <ItemTemplate>
                                          <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("id") %>' CssClass="col-lg-pull-4" Text="Delete" CommandName="recorddelete" />
                                      </ItemTemplate>
                                  </asp:TemplateField>
                              </Columns>
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                              <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                              <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prevoious" Position="TopAndBottom" Mode="NextPrevious" />
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
              </div><!-- /.box -->
              <!-- general form elements disabled -->
           
            </div>
</asp:Content>
