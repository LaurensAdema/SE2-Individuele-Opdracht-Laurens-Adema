<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Masterpages/NotLogged.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tweakers.GUI.Content.NotLogged.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <section id="login">
        <div class="container">
    	    <div class="row">
    	        <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
                    <h2>Log in</h2>
                        <hr class="colorgraph">
                        <span runat="server" id="errorMessage" style="color:red"></span>
                        <br/><br/>
                        <form runat="server" role="form" method="post">
                            <div class="form-group">
                                <label for="email" class="sr-only">Email</label>
                                <asp:TextBox runat="server" type="email" name="email" id="tbEmail" class="form-control input-lg" placeholder="Emailadres" required></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="key" class="sr-only">Password</label>
                                <asp:TextBox runat="server" type="password" name="key" id="tbPassword" class="form-control input-lg" placeholder="Wachtwoord" required></asp:TextBox>
                            </div>
                            <hr class="colorgraph">
                            <asp:Button type="submit" Text="Log in" class="btn btn-primary btn-block btn-lg" tabindex="7" ID="btLogin" runat="server" OnClick="btLogin_OnClick" /><br/>
                        </form>
                        <a href="javascript:;" class="forget" data-toggle="modal" data-target=".forget-modal">Wachtwoord vergeten?</a>
    		    </div> <!-- /.col-xs-12 -->
    	    </div> <!-- /.row -->
        </div> <!-- /.container -->
    </section>

    <div class="modal fade forget-modal" tabindex="-1" role="dialog" aria-labelledby="myForgetModalLabel" aria-hidden="true">
	    <div class="modal-dialog modal-sm">
		    <div class="modal-content">
			    <div class="modal-header">
				    <button type="button" class="close" data-dismiss="modal">
					    <span aria-hidden="true">×</span>
					    <span class="sr-only">Close</span>
				    </button>
				    <h4 class="modal-title">Wachtwoord herstellen</h4>
			    </div>
			    <div class="modal-body">
				    <p>Typ uw emailadres</p>
				    <input type="email" name="recovery-email" id="recovery-email" class="form-control" autocomplete="off">
			    </div>
			    <div class="modal-footer">
				    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
				    <button type="button" class="btn btn-custom">Herstel</button>
			    </div>
		    </div> <!-- /.modal-content -->
	    </div> <!-- /.modal-dialog -->
    </div> <!-- /.modal -->
</asp:Content>
