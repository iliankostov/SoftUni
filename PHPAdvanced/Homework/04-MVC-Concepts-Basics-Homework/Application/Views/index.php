<h1>TODO List</h1>
<?= $this->isLoggedIn ? '<h1><a href="\users\logout">Logout</a></h1><h1><a href="\todos">TODOs</a></h1>' : '<h1><a href="\users\login">Login</a></h1><h1><a href="\users\register"> Register</a></h1>' ?>
<?= var_dump($_SESSION)?>