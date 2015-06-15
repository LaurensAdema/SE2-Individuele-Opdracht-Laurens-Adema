<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Masterpages/NotLogged.master" AutoEventWireup="true" CodeBehind="NewsOverview.aspx.cs" Inherits="Tweakers.GUI.Content.NotLogged.NewsOverview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <section id="newsOverview">
        <div class="row">
            <!-- Blog Entries Column -->
            <div class="col-md-8">

                <span runat="server" id="headerNewsOverview"></span>

                <!-- Articles -->
                <span runat="server" id="newsArticles"></span>

                <!-- Pager -->
                <ul class="pager">
                    <span runat="server" id="pageTurner"></span>
                </ul>

            </div>

            <!-- Blog Sidebar Widgets Column -->
            <div class="col-md-4">

                <!-- Blog Categories Well -->
                <div class="well">
                    <h4>Blog Categories</h4>
                    <div class="row">
                        <div class="col-lg-6">
                            <ul class="list-unstyled">
                                <li><a href="#">Category Name</a>
                                </li>
                                <li><a href="#">Category Name</a>
                                </li>
                                <li><a href="#">Category Name</a>
                                </li>
                                <li><a href="#">Category Name</a>
                                </li>
                            </ul>
                        </div>
                        <!-- /.col-lg-6 -->
                        <div class="col-lg-6">
                            <ul class="list-unstyled">
                                <li><a href="#">Category Name</a>
                                </li>
                                <li><a href="#">Category Name</a>
                                </li>
                                <li><a href="#">Category Name</a>
                                </li>
                                <li><a href="#">Category Name</a>
                                </li>
                            </ul>
                        </div>
                        <!-- /.col-lg-6 -->
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

        <hr>
    </section>
</asp:Content>
