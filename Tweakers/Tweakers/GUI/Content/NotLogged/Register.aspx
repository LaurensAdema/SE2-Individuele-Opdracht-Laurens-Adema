<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Masterpages/NotLogged.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Tweakers.GUI.Content.NotLogged.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row" id="register">
        <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
		    <form role="form" runat="server">
			    <h2>Registreren</h2>
			    <hr class="colorgraph">
                <span runat="server" id="errorMessage" style="color:red"></span>
                <br/><br/>
			    <div class="form-group">
				    <asp:TextBox runat="server" type="text" name="display_name" id="tbUsername" class="form-control input-lg" placeholder="Gebruikersnaam" tabindex="3" required />
			    </div>
			    <div class="form-group">
				    <asp:TextBox runat="server" type="email" name="email" id="tbEmail" class="form-control input-lg" placeholder="Emailadres" tabindex="4" required />
			    </div>
			    <div class="row">
				    <div class="col-xs-12 col-sm-6 col-md-6">
					    <div class="form-group">
						    <asp:TextBox runat="server" type="password" name="password" id="tbPassword" class="form-control input-lg" placeholder="Wachtwoord" tabindex="5" required />
					    </div>
				    </div>
				    <div class="col-xs-12 col-sm-6 col-md-6">
					    <div class="form-group">
						    <asp:TextBox runat="server" type="password" name="password_confirmation" id="tbPasswordConfimation" class="form-control input-lg" placeholder="Wachtwoord opnieuw" tabindex="6" required />
					    </div>
				    </div>
			    </div>
			    <hr class="colorgraph">
                <asp:Button type="submit" runat="server" Text="Registreer" class="btn btn-primary btn-block btn-lg" tabindex="7" ID="btnRegister" OnClick="btnRegister_OnClick"/>
		    </form>
	    </div>
    </div>
</asp:Content>
