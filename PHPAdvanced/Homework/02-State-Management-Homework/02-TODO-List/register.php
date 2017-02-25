<?php
include_once 'views/layouts/header.php';
require_once 'models/Db.php';

$response = "";
if (isset($_POST['username']) && isset($_POST['password']) && isset($_POST['confirmPassword'])) {
    $username = $_POST['username'];
    $password = $_POST['password'];
    $confirmPassword = $_POST['confirmPassword'];
    if ($password !== $confirmPassword) {
        $error = "Passwords do not match ";
    } else {
        $response = Db::createUser($username, $password);
    }
}

?>
<form method="post">
    <input type="text" name="username" placeholder="Username"/>
    <input type="password" name="password" placeholder="Password"/>
    <input type="password" name="confirmPassword" placeholder="Confirm Password"/>
    <input type="submit" value="Register"/>
</form>
<div><?= $response !== "" ? $response : $error ?></div>
