<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="WorkShop.aspx.cs" Inherits="WorkShopSchedular.Admin.WorkShop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div BorderWidth="2">
    <table width=auto align="center" border="1" >
        
        <tr>
            <td style="text-align:right">WorkShop ID:</td>
            <td>
                <asp:TextBox ID="txtWorkShopId" runat="server"  Width="175px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">WorkShop Title:</td>
            <td>
                <asp:TextBox ID="txtWorkShopTitle" runat="server" Width="175px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">WorkShop Date:</td>
            <td>
                <asp:TextBox ID="txtWorkShopDate" runat="server"  Width="175px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="text-align:right">WorkShop Duration:</td>
            <td>
                <asp:TextBox ID="txtWorkShopDuration" runat="server" Width="175px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">WorkShop Topics:</td>
            <td>
                <asp:TextBox ID="txtWorkShopTopics" runat="server" Height="67px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
            <div>
        <table align="center">
            <tr align="center">
                <td style="text-align:left">
                    <h3 align="left">Trainers : SkillSets </h3>
                    <asp:CheckBoxList ID="ckbLTrainers" BorderWidth="1"
            BorderColor="SkyBlue"
            RepeatDirection="Horizontal" runat="server" RepeatColumns="3"></asp:CheckBoxList>
                    <asp:Button ID="btnAssignTrainer" runat="server" Text="Assign Trainer" OnClick="btnAssignTrainer_Click" />
                </td>
            </tr>
             <tr>
                 <td>
                     <asp:Label ID="lblAssignSucess" runat="server" ForeColor="Green" ></asp:Label>
                     <asp:Label ID="lblAssignFail" runat="server" ForeColor="Crimson" ></asp:Label>
                 </td>
             </tr>
             
        </table>
       
    </div>
         <tr align="center" >
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="Save"  Width="60px" OnClick="btnSave_Click"  />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="60px" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="60px" OnClick="btnDelete_Click" />
            </td>
          </tr>
        <tr align="center">
            <td>
                <asp:Label ID="lblDataSucess" runat="server" ForeColor="Green" ></asp:Label>
                <asp:Label ID="lblDataFail" runat="server" ForeColor="Crimson" ></asp:Label>
            </td>  
        </tr>
       
            
        

    </table>
        </div>

    <div>
        <table width="100%">
            <tr>
                <td>
                    <asp:GridView ID="GridView1" Width="100%" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateSelectButton="True" DataKeyNames="WorkShopId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>


</asp:Content>
