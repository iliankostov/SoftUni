<?php
include_once 'views/layouts/header.php';
require_once 'models/Db.php';

$error = "Please login first";

if (isset($_SESSION['username']) && isset($_SESSION['userId'])) {
    $isLogged = true;
    $error = "";
    $user_id = $_SESSION['userId'];

    if (isset($_POST['todo'])) {
        $todo_item = $_POST['todo'];
        Db::addTodoItem($user_id, $todo_item);
    }

    $todos = Db::getTodoItems($user_id);

    if (isset($_GET['user']) && isset($_GET['todo'])) {
        $user_id = $_GET['user'];
        $todo_id = $_GET['todo'];
        Db::deleteTodoItem($user_id, $todo_id);
        header("Location: list.php");
    }
}

?>

<?php if ($isLogged) : ?>
    <form method="post">
        <input type="text" name="todo" placeholder="TODO"/>
        <input type="submit" value="Add"/>
    </form>
    <?php foreach ($todos as $todo) : ?>
        <div><?= $todo['todo_item'] ?>
            <a href="list.php?user=<?= $todo['user_id'] ?>&todo=<?= $todo['id'] ?>">Delete</a>
        </div>
    <?php endforeach ?>
<?php endif; ?>
<div><?= $error ?></div>