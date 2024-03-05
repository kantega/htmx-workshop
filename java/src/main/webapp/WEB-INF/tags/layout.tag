<!DOCTYPE html>
<html>
<head>
    <title>HTMX Demo</title>
    <link rel="stylesheet" href="/webjars/bootstrap/5.3.2/css/bootstrap.css"/>
    <link rel="stylesheet" href="/webjars/bootstrap-icons/1.11.1/font/bootstrap-icons.css">
    <link rel="stylesheet" href="/styles/webshop.css">

    <script src="/webjars/bootstrap/5.3.2/js/bootstrap.js"></script>
    <script src="/webjars/htmx.org/1.9.6/dist/htmx.js"></script>
</head>
<body>

<nav class="navbar navbar-expand-md navbar-dark bg-gradient mb-4" style="background-color: #1d002f;">
    <div class="container-fluid">
        <a class="navbar-brand" href="/webshop">
            <img src="/logo.svg" style="width: 150px">
        </a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarCollapse"
                aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarCollapse">
            <ul class="navbar-nav me-auto mb-2 mb-md-0">
                <li class="nav-item">
                    <a class="nav-link active" aria-current="page" href="/webshop">
                        Webshop
                    </a>
                </li>
            </ul>
        </div>
    </div>
</nav>

<div class="container">
    <jsp:doBody/>
</div>

</body>
</html>
