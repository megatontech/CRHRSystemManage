﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dropdownbox_themes.aspx.cs" Inherits="FineUIPro.Examples.dropdownbox.dropdownbox_themes" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <style>
        #themecontainer {
            background: none;
            background-color: #000;
        }

            #themecontainer ul {
                list-style-type: none;
                margin: 10px 0 0;
                padding: 0;
            }

                #themecontainer ul li {
                    display: inline-block;
                    margin: 0 10px 10px;
                    border: solid 2px #000;
                    padding: 5px;
                }

                    #themecontainer ul li .title {
                        text-align: center;
                        color: #666;
                        font-size: 12px;
                    }

                    #themecontainer ul li.hover,
                    #themecontainer ul li.active {
                        border-bottom-color: #fff;
                    }

                        #themecontainer ul li.hover .title,
                        #themecontainer ul li.active .title {
                            color: #fff;
                            font-weight: bold;
                        }

                    #themecontainer ul li img {
                        width: 100px;
                    }

            #themecontainer .grouptitle {
                color: #ccc;
                font-size: 16px;
                border-bottom: solid 1px #333;
                padding: 5px;
                margin: 10px;
                margin-top: 0;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" Width="400px" EnableCollapse="true"
            ShowBorder="True" Title="自定义下拉框" ShowHeader="True">
            <Items>
                <f:DropDownBox runat="server" ID="DropDownBox1" Value="default" Text="Default" MatchFieldWidth="false">
                    <PopPanel>
                        <f:ContentPanel ID="ContentPanel1" Hidden="true" ShowHeader="false" Width="850px" Height="450px" AutoScroll="true" runat="server">
                            <div id="themecontainer">
                                <div class="grouptitle">
                                    Metro
                                </div>
                                <ul>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/default.png" alt="Default" data-value="default" /></a>
                                        <div class="title">Default</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/metro_blue.png" alt="Metro Blue" data-value="metro_blue" /></a>
                                        <div class="title">Metro Blue</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/metro_dark_blue.png" alt="Metro Dark Blue" data-value="metro_dark_blue" /></a>
                                        <div class="title">Metro Dark Blue</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/metro_gray.png" alt="Metro Gray" data-value="metro_gray" /></a>
                                        <div class="title">Metro Gray</div>
                                    </li>
                                    <li class="">
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/metro_green.png" alt="Metro Green" data-value="metro_green" /></a>
                                        <div class="title">Metro Green</div>
                                    </li>
                                    <li class="">
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/metro_orange.png" alt="Metro Orange" data-value="metro_orange" /></a>
                                        <div class="title">Metro Orange</div>
                                    </li>
                                </ul>
                                <div class="grouptitle">
                                    jQueryUI
                                </div>
                                <ul>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/black_tie.png" alt="Black Tie" data-value="black_tie" /></a>
                                        <div class="title">Black Tie</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/blitzer.png" alt="Blitzer" data-value="blitzer" /></a>
                                        <div class="title">Blitzer</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/cupertino.png" alt="Cupertino" data-value="cupertino" /></a>
                                        <div class="title">Cupertino</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/dark_hive.png" alt="Dark Hive" data-value="dark_hive" /></a>
                                        <div class="title">Dark Hive</div>
                                    </li>
                                    <li class="">
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/dot_luv.png" alt="Dot Luv" data-value="dot_luv" /></a>
                                        <div class="title">Dot Luv</div>
                                    </li>
                                    <li class="">
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/eggplant.png" alt="Eggplant" data-value="eggplant" /></a>
                                        <div class="title">Eggplant</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/excite_bike.png" alt="Excite Bike" data-value="excite_bike" /></a>
                                        <div class="title">Excite Bike</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/flick.png" alt="Flick" data-value="flick" /></a>
                                        <div class="title">Flick</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/hot_sneaks.png" alt="Hot Sneaks" data-value="hot_sneaks" /></a>
                                        <div class="title">Hot Sneaks</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/humanity.png" alt="Humanity" data-value="humanity" /></a>
                                        <div class="title">Humanity</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/le_frog.png" alt="Le Frog" data-value="le_frog" /></a>
                                        <div class="title">Le Frog</div>
                                    </li>
                                    <li class="">
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/mint_choc.png" alt="Mint Choc" data-value="mint_choc" /></a>
                                        <div class="title">Mint Choc</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/overcast.png" alt="Overcast" data-value="overcast" /></a>
                                        <div class="title">Overcast</div>
                                    </li>
                                    <li class="">
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/pepper_grinder.png" alt="Pepper Grinder" data-value="pepper_grinder" /></a>
                                        <div class="title">Pepper Grinder</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/redmond.png" alt="Redmond" data-value="redmond" /></a>
                                        <div class="title">Redmond</div>
                                    </li>
                                    <li class="">
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/smoothness.png" alt="Smoothness" data-value="smoothness" /></a>
                                        <div class="title">Smoothness</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/south_street.png" alt="South Street" data-value="south_street" /></a>
                                        <div class="title">South Street</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/start.png" alt="Start" data-value="start" /></a>
                                        <div class="title">Start</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/sunny.png" alt="Sunny" data-value="sunny" /></a>
                                        <div class="title">Sunny</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/swanky_purse.png" alt="Swanky Purse" data-value="swanky_purse" /></a>
                                        <div class="title">Swanky Purse</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/trontastic.png" alt="Trontastic" data-value="trontastic" /></a>
                                        <div class="title">Trontastic</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/ui_darkness.png" alt="UI Darkness" data-value="ui_darkness" /></a>
                                        <div class="title">UI Darkness</div>
                                    </li>
                                    <li class="">
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/ui_lightness.png" alt="UI Lightness" data-value="ui_lightness" /></a>
                                        <div class="title">UI Lightness</div>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <img src="../res/images/themes/small/vader.png" alt="Vader" data-value="vader" /></a>
                                        <div class="title">Vader</div>
                                    </li>
                                </ul>
                            </div>
                        </f:ContentPanel>
                    </PopPanel>
                    <Listeners>
                        <f:Listener Event="afterpoppanelshow" Handler="onAfterPopPanelShow" />
                    </Listeners>
                </f:DropDownBox>
                <f:Button ID="btnGetSelection" Text="获取此下拉框的选中值" runat="server" OnClick="btnGetSelection_Click">
                </f:Button>
            </Items>
        </f:SimpleForm>
        <br />
        <f:Label runat="server" ID="labResult">
        </f:Label>
    </form>
    <script>
        var ddbID = '<%= DropDownBox1.ClientID %>';
        var popPanelID = '<%= ContentPanel1.ClientID %>';

        function onAfterPopPanelShow(event) {
            var themeName = this.getValue();
            if (!themeName) {
                themeName = 'default';
            }
            $('#themecontainer li').each(function () {
                var cnode = $(this);
                if (cnode.find('img').attr('data-value') === themeName) {
                    cnode.addClass('active');
                } else {
                    cnode.removeClass('active');
                }
            });
        }


        F.ready(function () {

            $('#themecontainer li').hover(function () {
                $(this).addClass('hover');
            }, function () {
                $(this).removeClass('hover');
            }).click(function () {
                var imgNode = $(this).find('img');

                var themeName = imgNode.attr('data-value');
                var themeTitle = imgNode.attr('alt');

                // 将其赋值给下拉框
                var ddbCmp = F(ddbID);
                ddbCmp.setValue(themeName);
                ddbCmp.setText(themeTitle);

                // 隐藏弹出面板
                F(popPanelID).hide();

            });

        });
    </script>
</body>
</html>
