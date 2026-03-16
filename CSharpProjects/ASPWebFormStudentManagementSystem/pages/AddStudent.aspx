<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="ASPWebFormStudentManagementSystem.pages.AddStudent" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">

   <link href="../style/AddStudentStyle.css" rel="stylesheet" type="text/css" />

    <div class="form-Container">
        
        <asp:Label ID="pgTitle" class="pageheading" runat="server" Text="Add Student Detail" Width="449px"></asp:Label>

        <div class="form-group">
            <asp:Label ID="lbRollNumber" runat="server" Text="Roll Number" AssociatedControlID="inputRollNumber"></asp:Label>
	        <br />
			<asp:TextBox ID="inputRollNumber" TextMode="Number" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
	        <asp:Label ID="lbName" runat="server" Text="Name" AssociatedControlID="inputName"></asp:Label>
	         <br />
			 <asp:TextBox ID="inputName" runat="server"></asp:TextBox>
	     </div>
	
	    <div class="form-group">
	        <asp:Label ID="lbEmail" runat="server" Text="Email" AssociatedControlID="inputEmail"></asp:Label>
	         <br />
			 <asp:TextBox ID="inputEmail" TextMode="Email" runat="server"></asp:TextBox>
	    </div>

		<div class="form-group">
			<asp:Label ID="lbDepartment" runat="server" Text="Department" AssociatedControlID="ddlDepartment"></asp:Label>
			 <br />
			<asp:DropDownList ID="ddlDepartment"  class="styled-dropdown" runat="server">
			</asp:DropDownList>
		</div>

        
        <div class="form-group">
			<asp:Label ID="lbAddress" runat="server" Text="Address" AssociatedControlID="inputAddress"></asp:Label>
			 <br />
			<asp:TextBox ID="inputAddress" runat="server" TextMode="MultiLine" Rows="2" Columns="30"> </asp:TextBox>
		</div>

		<div class="form-group">
			<asp:Label ID="lbGender" runat="server" Text="Gender" AssociatedControlID="rblGenderList"></asp:Label>
			<br />
			<asp:RadioButtonList ID="rblGenderList" runat="server">
					<asp:ListItem class="ListItems" Text="Male" Value="Male"></asp:ListItem>
					<asp:ListItem Text="Female" Value="Female"></asp:ListItem>
			    </asp:RadioButtonList>
		</div>

        <div class="form-group">
			<asp:Label ID="lbAge" runat="server" Text="Age" AssociatedControlID="inputAge"></asp:Label>
			<br />
			<asp:TextBox ID="inputAge" TextMode="Number" runat="server"></asp:TextBox>
		</div>
		<div class="form-group">
			<asp:Label ID="lbDateOfBirth" runat="server" Text="Date of Birth" AssociatedControlID="inputDateOfBirth"></asp:Label>
			 <br />
			<asp:TextBox ID="inputDateOfBirth" runat="server" TextMode="Date"></asp:TextBox>
		</div>
	
		<div class="form-group">
			<asp:Label ID="lbPhone" runat="server" Text="Phone" AssociatedControlID="inputPhone"></asp:Label>
			 <br />
			<asp:TextBox ID="inputPhone" runat="server"></asp:TextBox>
		</div>

       

		<div class="form-group">
			<asp:Label ID="lbAdmissionDate" runat="server" Text="Admission Date" AssociatedControlID="inputAddmissionDate"></asp:Label>
			 <br />
			<asp:TextBox ID="inputAddmissionDate" runat="server" TextMode="Date"></asp:TextBox>
		</div>

		<div class="form-group">
			<asp:Button ID="AddStudBtn" class="submit-btn" runat="server" Text="Add Student" OnClick="AddStudBtn_Click"/>
		
			<asp:Button ID="CancelBtn" runat="server" class="cancel-btn" Text="Cancel" OnClick="CancelBtn_Click"/>
		</div>

    </div>

</asp:Content>


