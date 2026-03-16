<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayPage.aspx.cs" Inherits="ASPWebFormStudentManagementSystem.pages.DisplayPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../style/site.css" rel="stylesheet" type="text/css" />
    
    
    <asp:Label ID="lbsearch" runat="server" Text="Search "></asp:Label>
    <asp:TextBox ID="searchBox" class="searchboxstyle" runat="server"></asp:TextBox>
    <asp:Button ID="GetDataButton" runat="server" OnClick="getdata_Click" Text="Get" />
    <br />
    <br />

    <asp:GridView ID="GridView1" CssClass="Student-grid" runat="server"
        AutoGenerateColumns="False" DataKeyNames="RollNumber">

        <Columns>
            <asp:BoundField DataField="RollNumber" HeaderText="Roll Number" ReadOnly="true" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="DepartmentID" HeaderText="Department" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
            <asp:BoundField DataField="Address" HeaderText="DepartAddressment" />
            <asp:BoundField DataField="Age" HeaderText="Age" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" />
            <asp:BoundField DataField="AddmissionDate" HeaderText="AddmissionDate" DataFormatString="{0:yyyy-MM-dd}"/>
            
 
            
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    
                    <asp:HyperLink ID="EdidLink" Text="Edit" runat="server"  CssClass="editButton"
                        NavigateUrl='<%# "~/pages/EditStudent.aspx?RollNumber=" + Eval("RollNumber") %>'>

                    </asp:HyperLink>

                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CssClass="DeleteButton" 
                    OnClientClick="return confirm('Are you sure you want to delete this student?');" OnClick="Delete_StudentInfo_Click"/>
         
                </ItemTemplate>

            </asp:TemplateField>
            
        </Columns>

</asp:GridView>
</asp:Content>
