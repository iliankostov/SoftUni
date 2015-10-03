<?php /** @var Models\ViewModels\UserViewModel */ ?>
<html>
<head>
    <title>iCart - osCommerce</title>

    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">

    <link rel="stylesheet" href="/css/bootstrap.min.css">
    <link rel="stylesheet" href="/css/bootstrap-theme.min.css">
    <link rel="stylesheet" href="/css/style.css">

</head>
<body>
<div id="wrap">
    <header class="masthead">
        <div class="container">
            <div class="row">
                <div class="col-sm-6">
                    <h1><a href="/">iCart</a>

                        <p class="lead">osCommerce</p></h1>

                </div>
            </div>
        </div>
    </header>

    <!-- Fixed navbar -->
    <div class="navbar navbar-custom navbar-inverse navbar-static-top" id="nav">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>
            <div class="collapse navbar-collapse">
                <ul class="nav navbar-nav nav-justified">
                    <li><a href="/">Home</a></li>
                    <li><a href="/">Promotions</a></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Categories <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><a href="/">Laptops</a></li>
                            <li><a href="/">Notebooks</a></li>
                            <li><a href="/">Tablets</a></li>
                            <li><a href="/">Smartphones</a></li>
                            <li><a href="/">Accessoaries</a></li>
                        </ul>
                    </li>
                    <li><a href="/users/profile">Profile</a></li>
                    <li><a href="/users/logout">Logout</a></li>
                </ul>
            </div>
            <!--/.nav-collapse -->
        </div>
        <!--/.container -->
    </div>
    <!--/.navbar -->

    <section class="bg-1">
        <div class="row">
            <div class="col-lg-6 col-lg-offset-3">
                <?=
                \Framework\ViewHelpers\FormViewHelper::init()
                    ->setAction("/users/update")
                    ->setMethod("post")
                    ->setClasses("form col-lg-12 center-block")
                    ->initTextField()
                    ->setName("cash")
                    ->setClasses("form-group form-control input-lg")
                    ->setAttribute("value", $this->data->getCash())
                    ->create()
                    ->initPasswordField()
                    ->setName("oldPassword")
                    ->setClasses("form-group form-control input-lg")
                    ->setAttribute("placeholder", "Old Password")
                    ->create()
                    ->initPasswordField()
                    ->setName("newPassword")
                    ->setClasses("form-group form-control input-lg")
                    ->setAttribute("placeholder", "New Password")
                    ->create()
                    ->initPasswordField()
                    ->setName("confirmPassword")
                    ->setClasses("form-group form-control input-lg")
                    ->setAttribute("placeholder", "Old Password")
                    ->create()
                    ->initSubmit()
                    ->setClasses("btn btn-primary btn-lg btn-block")
                    ->setValue("Update")
                    ->create()
                    ->render();

                ?>
            </div>
        </div>
    </section>
</div>

<div id="footer">
    <div class="container">
        <p class="text-muted">iCart - osCommerce</p>
    </div>
</div>

<script src="/js/jquery.min.js"></script>
<script src="/js/bootstrap.min.js"></script>
<script src="/js/script.js"></script>
</body>
</html>