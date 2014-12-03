<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Get Form Data</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<form method="post">
    <input type="text" name="name" placeholder="Name" />
    <input type="text" name="age" placeholder="Age" />
    <div>
        <input type="radio" name="gender" value="male" id="male" />
        <label for="male">Male</label>
    </div>
    <div>
        <input type="radio" name="gender" value="female" id="female"/>
        <label for="female">Female</label>
    </div>
    <input type="submit" name="submit"/>
</form>

<?php
if (isset($_POST['submit'])) {
    $name = $_POST['name'];
    $age = $_POST['age'];
    $gender = $_POST['gender'];

    echo 'My name is ' . htmlentities($name) . '. I am ' . htmlentities($age) . ' years old. I am ' . htmlentities($gender) . '.';
}
?>

</body>
</html>
