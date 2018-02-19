<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NProduct.aspx.cs" Inherits="Shrikrishna.NProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style1">
              <!-- Horizontal Form -->
              <div class="box box-info">
                <div class="box-header with-border">
                  <h3 class="box-title">New Product</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form class="form-horizontal">
                  <div class="box-body">
                    <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Name</label>
                      <div class="col-sm-10">
                          <asp:TextBox ID="txtproductname" runat="server" class="form-control" placeholder="Enter New Product"></asp:TextBox> 
                      </div>

                        <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Product GST Type</label>
                      <div class="col-sm-10">
                          <asp:DropDownList ID="ddlpcategory" class="form-control" runat="server" palceholder="Chosse Product Category" OnSelectedIndexChanged="ddlpcategory_SelectedIndexChanged" AutoPostBack="True"  ></asp:DropDownList>
                      </div>
                    </div>

                    </div>
                      <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">HSNCODE</label>
                      <div class="col-sm-10">
                        <asp:TextBox ID="txthsncode" runat="server" class="form-control" placeholder="HSNCODE Of Product "></asp:TextBox>   
                      </div>
                    </div>

                      <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Rate</label>
                      <div class="col-sm-10">
                        <asp:TextBox ID="txtrate" runat="server" class="form-control" placeholder="Enter Rate Of Product"></asp:TextBox>   
                      </div>
                    </div>

                      <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">GST Rate</label>
                      <div class="col-sm-10">
                        <asp:TextBox ID="Txtgstrate" runat="server" class="form-control" placeholder="GST Rate Of Product"></asp:TextBox>   
                      </div>
                    </div>
                        <!--div-- class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Units</label>
                      <div class="col-sm-10">
                        <asp:TextBox ID="txtunit" runat="server" class="form-control" placeholder="Enter Unit "></asp:TextBox>   
                      </div>
                    </!--div-->
                      
                      
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
                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="GridView1_RowCommand" Width="402px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="8" >
                              <Columns>
                                  <asp:BoundField DataField="itemname" HeaderText="P. Name" />
                                  <asp:BoundField DataField="pcategory" HeaderText="P. Category" />
                                  <asp:BoundField DataField="hsncode" HeaderText="HSN CODE" />
                                  <asp:BoundField DataField="rate" HeaderText="Rate" />
                                  <asp:BoundField DataField="gstrate" HeaderText="GST Rate" />
                                  <asp:TemplateField HeaderText="Edit">
                                      <ItemTemplate>
                                         <asp:Button ID="btnedit" runat="server"  Text="Edit" CommandArgument='<%# Eval("sr") %>' CommandName="recordedit"  />
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Delete">
                                      <ItemTemplate>
                                          <asp:Button ID="btndelete" runat="server"  CssClass="col-lg-pull-4" Text="Delete" CommandArgument='<%# Eval("sr") %>' CommandName="Recorddelete" />
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
                        

                              <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                        

                             <%-- <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="GridView1_RowCommand" Width="402px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="8">
                              <Columns>
                                  <asp:BoundField DataField="pcategory" HeaderText="P. Category" />
                                  <asp:BoundField DataField="hsncode" HeaderText="HSN CODE" />
                                  <asp:BoundField DataField="rate" HeaderText="Rate" />
                                  <asp:TemplateField HeaderText="Edit">
                                      <ItemTemplate>
                                         <asp:Button ID="btnedit" runat="server" CommandArgument='<%# Eval("sr") %>'  />
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Delete">
                                      <ItemTemplate>
                                          <asp:Button ID="Button3" runat="server"  CssClass="col-lg-pull-4" Text="Delete" />
                                      </ItemTemplate>
                                  </asp:TemplateField>
                              </Columns>
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                              <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                              <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Prevoious" Position="TopAndBottom" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                              <RowStyle ForeColor="#000066" />
                              <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                          </asp:GridView>--%>
                         </center>
                      </div>
                    </div>
                  </div><!-- /.box-body -->
                </form>
              </div><!-- /.box -->
              <!-- general form elements disabled -->
           
            </div>
</asp:Content>
