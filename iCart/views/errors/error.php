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
                </ul>
            </div>
            <!--/.nav-collapse -->
        </div>
        <!--/.container -->
    </div>
    <!--/.navbar -->

    <div class="error"><?= $this->data['error'] ?></div>
</div>
<!--/wrap-->

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
