<?php
include_once 'views/layouts/header.php';

unset($_SESSION["username"]);
unset($_SESSION["userId"]);
header("Location: login.php");