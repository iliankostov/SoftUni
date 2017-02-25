<h1>Register</h1>
<form action="" method="post">
    Username: <input type="text" name="username">
    Pass: <input type="password" name="pass">
    <input type="submit" value="Register">
</form>
<h1><a href="/users/login">Login</a></h1>
<p><?= $this->error ? 'Errors: ' . $this->error : '' ?></p>