<?php
include_once 'views/layouts/header.php';
require_once 'models/Db.php';

if (isset($_POST['username']) && isset($_POST['password'])) {
    $username = $_POST['username'];
    $password = $_POST['password'];
    $isUserValid = Db::isUserValid($username, $password);

    if (!$isUserValid) {
        $response = "Unsuccessful login";
    } else {
        $_SESSION["username"] = $username;
        $_SESSION["userId"] = $isUserValid;
        $response = "Login successful";
        header("Location: list.php");
    }
}
?>

<form method="post">
    <input type="text" name="username" placeholder="Username"/>
    <input type="password" name="password" placeholder="Password"/>
    <input type="submit" value="Login"/>
</form>
<div><?= $response ?></div>
