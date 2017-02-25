<h1>Login</h1>
<form action="" method="post">
    Username: <input type="text" name="username">
    Pass: <input type="password" name="pass">
    <input type="submit" value="Login">
</form>
<h1><a href="/users/register">Register</a></h1>
<p><?= $this->error ? 'Errors: ' . $this->error : '' ?></p>