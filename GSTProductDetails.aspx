<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GSTProductDetails.aspx.cs" Inherits="Shrikrishna.GSTdetails" %>
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
                  <h3 class="box-title">Types Details Of Product</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form class="form-horizontal">
                  <div class="box-body">
                    <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Type Name</label>
                      <div class="col-sm-10">
                      <asp:TextBox ID="txtTypename" runat="server" class="form-control" placeholder="Enter Type Name" ></asp:TextBox>
                      </div>
                    </div>
                      <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label"> HSNCODE</label>
                      <div class="col-sm-10">
                          <asp:TextBox ID="txthsncode" runat="server" class="form-control" placeholder="Enter HSNCODE" ></asp:TextBox>
                      </div>
                    </div>
                       <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label"> GST Rate</label>
                      <div class="col-sm-10">
                          <asp:TextBox ID="txtgstrate" runat="server" class="form-control" placeholder="Enter GST Rate" ></asp:TextBox>
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
                      <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="New" OnClick="Button2_Click" />
                   </center>
                  </div><!-- /.box-footer -->

                         <div class="box-body">
                    <div class="form-group">
                      <div class="col-sm-12" style="text-align:center">
                          <center>
                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="GridView1_RowCommand" Width="402px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="8" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                              <Columns>
                                  <asp:BoundField DataField="Type" HeaderText="Type " />
                                  <asp:BoundField DataField="Hsncode" HeaderText="HSNCODE" />
                                  <asp:BoundField DataField="Gstrate" HeaderText="GST Rate" />
                                  <asp:TemplateField HeaderText="Edit">
                                      <ItemTemplate>
                                          <asp:Button ID="btnedit" runat="server" CommandArgument='<%# Eval("Id") %>' Text="Edit" CommandName="recordedit" />
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Delete">
                                      <ItemTemplate>
                                          <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("Id") %>' CssClass="col-lg-pull-4" Text="Delete" CommandName="recorddelete" />
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

