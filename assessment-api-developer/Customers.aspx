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

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <!-- Include Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KyZXEJd1iN6QKhJ2dQNV1tD1TzdWy7YwDtdv0Wfjl2p0D4flf78DdwqkA3x5Ws9a" crossorigin="anonymous">

    <!-- Custom CSS -->
    <style>
        body {
            background-color: #f8f9fa; /* Light gray background */
            font-family: 'Helvetica', 'Arial', sans-serif;
            margin-top: 20px;
        }

        .navbar {
            background-color: #005a9c; /* Dark blue background */
            border-radius: 0;
            padding: 15px 0;
        }

        .navbar-brand {
            font-size: 1.9rem;
            font-weight: 600;
            color: white;
            letter-spacing: 1px;
        }

        .navbar-nav .nav-link {
            color: white;
            font-weight: 500;
            text-transform: uppercase;
        }

        .navbar-nav .nav-link:hover {
            color: #007bff;
            transition: color 0.3s ease-in-out;
        }

        .container {
            max-width: 1200px;
            margin-top: 30px;
        }

        .card {
            border: none;
            box-shadow: 0px 2px 15px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            background-color: white;
            margin-bottom: 20px;
        }

        .card-header {
            background-color: #005a9c; /* Same blue as navbar */
            color: white;
            border-radius: 10px 10px 0 0;
            padding: 15px 20px;
            font-size: 1.25rem;
        }

        .form-label {
            color: #333; /* Dark gray color for labels */
            font-size: 0.9rem;
            font-weight: 600;
        }

        .form-control {
            border-radius: 5px;
            border: 1px solid #ddd;
            box-shadow: none;
            padding: 10px;
        }

        .form-control:focus {
            border-color: #005a9c;
            box-shadow: 0 0 5px rgba(0, 90, 156, 0.5);
        }

        .btn {
            font-weight: 600;
            border-radius: 5px;
            padding: 10px 20px;
            text-transform: uppercase;
            letter-spacing: 1px;
            min-width: 120px;
        }

        .btn-primary {
            background-color: #005a9c;
            border-color: #005a9c;
            color: white;
        }

        .btn-primary:hover {
            background-color: #0069d9;
            border-color: #0062cc;
            transition: background-color 0.3s;
        }

        .btn-warning {
            background-color: #f39c12;
            border-color: #f39c12;
            color: white;
        }

        .btn-warning:hover {
            background-color: #e67e22;
            border-color: #e67e22;
            transition: background-color 0.3s;
        }

        .btn-danger {
            background-color: #e74c3c;
            border-color: #e74c3c;
            color: white;
        }

        .btn-danger:hover {
            background-color: #c0392b;
            border-color: #c0392b;
            transition: background-color 0.3s;
        }

        .text-center {
            margin-top: 30px;
        }

        .mb-4 {
            margin-bottom: 1.5rem;
        }

        .form-section {
            margin-bottom: 30px;
        }

        .mb-3 {
            margin-bottom: 1.25rem;
        }

        .row {
            margin-bottom: 20px;
        }

        .card-body {
            padding: 30px;
        }

        .card-body h3 {
            color: #005a9c;
            font-weight: bold;
            margin-bottom: 25px;
        }

        .card-body input, .card-body textarea {
            margin-top: 10px;
        }

        /* Customize Dropdown */
        .form-control-sm {
            padding: 5px 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
            </Scripts>
        </asp:ScriptManager>

        <!-- Navbar Section -->
        <nav class="navbar navbar-expand-lg navbar-dark">
            <div class="container">
                <a class="navbar-brand" runat="server" href="~/">RPM API Developer Assessment</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav ms-auto">
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

        <!-- Main Content Section -->
        <div class="container">
            <h2 class="text-center mb-4">Customer Registry</h2>

            <!-- Dropdown for selecting customers -->
            <asp:DropDownList runat="server" ID="CustomersDDL" CssClass="form-control mb-4" OnSelectedIndexChanged="CustomersDDL_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Select Customer" Value="" />
            </asp:DropDownList>

            <!-- Customer Form -->
            <div class="row">
                <!-- Customer Detail + Address Card -->
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-header">
                            <h3 class="mb-0">Customer Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <!-- Customer Name -->
                                    <div class="mb-3">
                                        <asp:Label ID="CustomerNameLabel" runat="server" Text="Name" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="CustomerName" runat="server" CssClass="form-control" placeholder="Enter customer name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCustomerName" runat="server" ControlToValidate="CustomerName" ErrorMessage="Name is required." ForeColor="Red" />
                                    </div>
                                    <!-- Customer Phone -->
                                    <div class="mb-3">
                                        <asp:Label ID="CustomerPhoneLabel" runat="server" Text="Phone" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="CustomerPhone" runat="server" CssClass="form-control" placeholder="Enter customer phone number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCustomerPhone" runat="server" ControlToValidate="CustomerPhone" ErrorMessage="Phone is required." ForeColor="Red" />
                                    </div>
                                    <!-- Customer Notes -->
                                    <div class="mb-3">
                                        <asp:Label ID="CustomerNotesLabel" runat="server" Text="Notes" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="CustomerNotes" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" placeholder="Enter any notes"></asp:TextBox>
                                    </div>
                                    <!-- Customer Email -->
                                    <div class="mb-3">
                                        <asp:Label ID="CustomerEmailLabel" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="CustomerEmail" runat="server" CssClass="form-control" placeholder="Enter customer email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCustomerEmail" runat="server" ControlToValidate="CustomerEmail" ErrorMessage="Email is required." ForeColor="Red" />
                                        <asp:RegularExpressionValidator ID="revCustomerEmail" runat="server" ControlToValidate="CustomerEmail" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ErrorMessage="Invalid email format." ForeColor="Red" />
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <!-- Customer Address -->
                                    <div class="mb-3">
                                        <asp:Label ID="CustomerAddressLabel" runat="server" Text="Address" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="CustomerAddress" runat="server" CssClass="form-control" placeholder="Enter customer address"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCustomerAddress" runat="server" ControlToValidate="CustomerAddress" ErrorMessage="Address is required." ForeColor="Red" />
                                    </div>
                                    <!-- Customer City -->
                                    <div class="mb-3">
                                        <asp:Label ID="CustomerCityLabel" runat="server" Text="City" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="CustomerCity" runat="server" CssClass="form-control" placeholder="Enter city"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCustomerCity" runat="server" ControlToValidate="CustomerCity" ErrorMessage="City is required." ForeColor="Red" />
                                    </div>

                                    <!-- Customer State -->
                                    <div class="mb-3">
                                        <asp:Label ID="CustomerStateLabel" runat="server" Text="State" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="StateDropDownList" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Select State" Value="" />
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvCustomerState" runat="server" ControlToValidate="StateDropDownList" InitialValue="" ErrorMessage="State is required." ForeColor="Red" />
                                    </div>

                                    <!-- Customer Zip Code -->
                                    <div class="mb-3">
                                        <asp:Label ID="CustomerZipLabel" runat="server" Text="Postal/Zip Code" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="CustomerZip" runat="server" CssClass="form-control" placeholder="Enter zip code"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCustomerZip" runat="server" ControlToValidate="CustomerZip" ErrorMessage="Zip code is required." ForeColor="Red" />
                                        <asp:RegularExpressionValidator ID="revCustomerZip" runat="server" ControlToValidate="CustomerZip" ValidationExpression="(^\d{5}(-\d{4})?$)|(^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$)" ErrorMessage="Invalid zip/postal code format." ForeColor="Red" />
                                    </div>

                                    <!-- Customer Country -->
                                    <div class="mb-3">
                                        <asp:Label ID="CustomerCountryLabel" runat="server" Text="Country" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="CountryDropDownList" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Select Country" Value="" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Customer Contact Details Card -->
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-header">
                            <h3 class="mb-0">Customer Contact Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="mb-3">
                                <asp:Label ID="ContactNameLabel" runat="server" Text="Contact Name" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="ContactName" runat="server" CssClass="form-control" placeholder="Enter contact name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvContactName" runat="server" ControlToValidate="ContactName" ErrorMessage="Contact Name is required." ForeColor="Red" />
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="ContactEmailLabel" runat="server" Text="Contact Email" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="ContactEmail" runat="server" CssClass="form-control" placeholder="Enter contact email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvContactEmail" runat="server" ControlToValidate="ContactEmail" ErrorMessage="Contact Email is required." ForeColor="Red" />
                                <asp:RegularExpressionValidator ID="revContactEmail" runat="server" ControlToValidate="ContactEmail" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ErrorMessage="Invalid email format." ForeColor="Red" />
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="ContactPhoneLabel" runat="server" Text="Contact Phone" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="ContactPhone" runat="server" CssClass="form-control" placeholder="Enter contact phone number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvContactPhone" runat="server" ControlToValidate="ContactPhone" ErrorMessage="Contact Phone is required." ForeColor="Red" />
                                <asp:RegularExpressionValidator ID="revContactPhone" runat="server" ControlToValidate="ContactPhone" ValidationExpression="^\+?\d{1,4}?[\d\s\-()]*\d+$" ErrorMessage="Invalid phone format." ForeColor="Red" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Action buttons -->
            <div class="text-center">
                <asp:Button ID="AddButton" runat="server" CssClass="btn btn-primary btn-md" Text="Add" OnClick="AddButton_Click" />
                <asp:Button ID="UpdateButton" runat="server" CssClass="btn btn-warning btn-md" Text="Update" OnClick="UpdateButton_Click" Visible="false" />
                <asp:Button ID="DeleteButton" runat="server" CssClass="btn btn-danger btn-md" Text="Delete" OnClick="DeleteButton_Click" Visible="false" />
            </div>
        </div>

        <!-- Include Bootstrap JS -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>
