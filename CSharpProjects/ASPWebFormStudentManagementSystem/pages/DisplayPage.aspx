<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayPage.aspx.cs" Inherits="ASPWebFormStudentManagementSystem.pages.DisplayPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1" runat="server"
        BorderStyle="Solid" BorderWidth="2px" 
        Height="324px" Width="1001px" BackColor="#CCCCCC"
        CssClass="accordion-collapse" ForeColor="#000066" 
        AutoGenerateColumns="False" DataKeyNames="RollNumber"
        OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating"
        OnRowCancelingEdit="GridView1_RowCancelingEdit"
        OnRowDeleting="GridView1_RowDeleting">


        <Columns>
            <asp:BoundField DataField="RollNumber" HeaderText="Roll Number" ReadOnly="true" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="DepartmentID" HeaderText="Department" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
            <asp:BoundField DataField="Address" HeaderText="DepartAddressment" />
            <asp:BoundField DataField="Age" HeaderText="Age" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" />
            <asp:BoundField DataField="AddmissionDate" HeaderText="AddmissionDate" />
            

            
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    
                    <asp:HyperLink ID="Editlink" runat="server"  
                        NavigateUrl='<%# "EditStudent.aspx?RollNumber=" + Eval("RollNumber") %>' 
                    Text="Edit" />

                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" Text="Delete"
                    OnClientClick="return confirm('Are you sure you want to delete this student?');" />
         
                </ItemTemplate>

            </asp:TemplateField>
            

            
        </Columns>

</asp:GridView>
</asp:Content>
