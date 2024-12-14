<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerForm.aspx.cs" Inherits="assessment_platform_developer.Customers" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> RPM API Developer Assessment</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
            </Scripts>
        </asp:ScriptManager>

        <!-- Navbar Section -->
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark">
            <div class="container body-content">
                <a class="navbar-brand" runat="server" href="~/">RPM API Developer Assessment</a>
                <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Toggle navigation" aria-controls="navbarSupportedContent" 
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <a class="nav-link" runat="server" href="~/">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" runat="server" href="~/Customers">Customers</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <!-- Form Section -->
        <div class="container body-content">
            <h2>Customer Registry</h2>

            <!-- Dropdown for selecting customers -->
            <asp:DropDownList runat="server" ID="CustomersDDL" CssClass="form-control" AutoPostBack="true">
                <asp:ListItem Text="Select Customer" Value="" />
            </asp:DropDownList>
        </div>

        <div class="container body-content">
            <div class="card">
                <div class="card-body">
                    <div class="row justify-content-center">
                        <div class="col-md-6">
                            <h3>Add Customer</h3>

                            <!-- Customer Details Form -->
                            <div class="form-group">
                                <asp:Label ID="CustomerNameLabel" runat="server" Text="Name" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="CustomerName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="CustomerAddressLabel" runat="server" Text="Address" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="CustomerAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="CustomerEmailLabel" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="CustomerEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="CustomerPhoneLabel" runat="server" Text="Phone" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="CustomerPhone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="CustomerCityLabel" runat="server" Text="City" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="CustomerCity" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="CustomerStateLabel" runat="server" Text="State" CssClass="form-label"></asp:Label>
                                <asp:DropDownList ID="StateDropDownList" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Select State" Value="" />
                                    
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="CustomerZipLabel" runat="server" Text="Postal/Zip Code" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="CustomerZip" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="CustomerCountryLabel" runat="server" Text="Country" CssClass="form-label"></asp:Label>
                                <asp:DropDownList ID="CountryDropDownList" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Select Country" Value="" />
                                 
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="CustomerNotesLabel" runat="server" Text="Notes" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="CustomerNotes" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <!-- Customer Contact Details -->
                            <h3>Customer Contact Details</h3>

                            <div class="form-group">
                                <asp:Label ID="ContactNameLabel" runat="server" Text="Contact Name" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="ContactName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="ContactEmailLabel" runat="server" Text="Contact Email" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="ContactEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="ContactPhoneLabel" runat="server" Text="Contact Phone" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="ContactPhone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <!-- Action buttons -->
                            <div class="form-group">
                                <asp:Button ID="AddButton" runat="server" CssClass="btn btn-primary btn-md" Text="Add" OnClick="AddButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
