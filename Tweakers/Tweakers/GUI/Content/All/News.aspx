<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Masterpages/NotLogged.master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Tweakers.GUI.Content.NotLogged.News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <section id="news">
        <div class="row">
            <!-- Blog Post Content Column -->
            <div class="col-lg-8">

                <!-- Blog Post -->

                <!-- Title -->
                <span runat="server" id="titleArticle"></span>

                <!-- Author -->
                <span runat="server" id="authorArticle"></span>

                <hr>

                <!-- Date/Time -->
                <span runat="server" id="dateArticle"></span>

                <hr>

                <!-- Post Content -->
                <span runat="server" id="contentArticle"></span>

                <hr>
                <br/>
                <a>Next</a>
                <br/>
                <hr>

                <!-- Blog Comments -->
                <h3>Reacties</h3>
                <!-- Posted Comments -->
                <span runat="server" id="commentsArticle"></span>
                
                <hr class="colorgraph">

                <!-- Comments Form -->
                <div class="well">
                    <h4>Reageren:</h4>
                    <span runat="server" ID="errorMessage" style="color:red"></span>
                    <form role="form" runat="server">
                        <div class="form-group">
                            <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control" rows ="7" id="postReaction"></asp:TextBox>
                        </div>
                        <asp:Button type="submit" id="btnSubmitReaction" class="btn btn-primary" OnClick="btnSubmitReaction_OnClick">Submit</asp:Button>
                    </form>
                </div>

                <hr class="colorgraph">

            </div>

            <!-- Blog Sidebar Widgets Column -->
            <div class="col-md-4">

                <!-- Blog Categories Well -->
                <div class="well">
                    <h4>Categorieën</h4>
                    <span runat="server" id="categoryArticle"></span>
                    </div>
                    <!-- /.row -->
                </div>

                <!-- Side Widget Well -->
                <div class="well">
                    <h4>Side Widget Well</h4>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore, perspiciatis adipisci accusamus laudantium odit aliquam repellat tempore quos aspernatur vero.</p>
                </div>

            </div>

        </div>
        <!-- /.row -->
    </section>
</asp:Content>
