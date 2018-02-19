<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Sale.aspx.cs" Inherits="Shrikrishna.Sale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            margin-top: 24px;
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
                          <asp:DropDownList ID="ddlname" class="form-control" runat="server" palceholder="Chosse Product Category" AutoPostBack="True" OnSelectedIndexChanged="ddlname_SelectedIndexChanged" ></asp:DropDownList>
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
                      <div>
                          <table>
                              <tr>

                              </tr>
                          </table>
                      </div>

                      <div class="box-header with-border" style="left: 0px; top: 0px">
                  <h3 class="box-title">Goods Details</h3>
                </div>
                        <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Name Of Product </label>
                      <div class="col-sm-10">
                          <asp:DropDownList ID="Ddlgoodname" class="form-control" runat="server" palceholder="Chosse Product" AutoPostBack="True" OnSelectedIndexChanged="Ddlgoodname_SelectedIndexChanged" ></asp:DropDownList>
                           
                      </div>
                    </div>
                      <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Sub Product Type </label>
                      <div class="col-sm-10">
                          <asp:DropDownList ID="ddlsubtype" class="form-control" runat="server" palceholder="Chosse Sub Product Type" AutoPostBack="True" OnSelectedIndexChanged="ddlsubtype_SelectedIndexChanged" ></asp:DropDownList>
                           
                      </div>
                    </div>
                       <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Type</label>
                      <div class="col-sm-10">
                       <asp:DropDownList ID="ddltxttype" class="form-control" runat="server" palceholder="Chosse GST Rate" AutoPostBack="True" OnSelectedIndexChanged="ddltxttype_SelectedIndexChanged" ></asp:DropDownList>
                      </div>
                    </div>
                      
                     
                         <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Rate</label>
                      <div class="col-sm-10">
                        <asp:TextBox ID="Txtrate" runat="server" class="form-control" placeholder="Enter Rate"></asp:TextBox>   
                      </div>
                    </div>
                      <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">QTY</label>
                      <div class="col-sm-10">
                        <asp:TextBox ID="Txtqty" runat="server" class="form-control" placeholder="Enter Qty"></asp:TextBox>   
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
                      <asp:Button ID="btnsave" runat="server"  class="btn btn-success" Text="ADD" OnClick="Button1_Click" />
                      <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="New" OnClick="Button2_Click" />
                   </center>
                  </div><!-- /.box-footer -->

                         <div class="box-body">
                    <div class="form-group">
                      <div class="col-sm-12" style="text-align:center">
                          <center>
                          
                              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="GridView1_RowCommand" Width="402px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="8" >
                              <Columns>
                                  <asp:BoundField DataField="id" HeaderText="Ser. No" />
                                  <asp:BoundField DataField="pname" HeaderText="P. Name" />
                                  <asp:BoundField DataField="qty" HeaderText="Qty" />
                                  <asp:BoundField DataField="unit" HeaderText="Unit" />
                                  <asp:BoundField DataField="rate" HeaderText="Rate" />
                                  <asp:BoundField DataField="total" HeaderText="Total" />
                                  <asp:TemplateField HeaderText="Edit">
                                      <ItemTemplate>
                                         <asp:Button ID="btnedit" runat="server"  Text="Edit" CommandArgument='<%# Eval("id") %>' CommandName="recordedit"  />
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Delete">
                                      <ItemTemplate>
                                          <asp:Button ID="btndelete" runat="server"  CssClass="col-lg-pull-4" Text="Delete" CommandArgument='<%# Eval("id") %>' CommandName="Recorddelete" />
                                      </ItemTemplate>
                                  </asp:TemplateField>
                              </Columns>
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
                      <div class="col-sm-12" style="text-align:right">
                        <div class="box-footer">
                      <right>
                      <asp:Button ID="btnbill" runat="server"  class="btn btn-success" Text="Save Bill" OnClick="btnbill_Click" />
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
</asp:Content>
