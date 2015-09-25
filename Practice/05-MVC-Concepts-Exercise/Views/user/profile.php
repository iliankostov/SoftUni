<h1>Hello, <?= htmlspecialchars($model->getUser()->getUsername()); ?></h1>
<h3>
    Resources:
    <p>Gold: <?= $model->getUser()->getGold(); ?></p>

    <p>Food: <?= $model->getUser()->getFood(); ?> </p>

    <p><a href="buildings">Buildings</a></p>
</h3>

<form action="" method="post">
    <div>
        <input type="text" name="username" value="<?= htmlspecialchars($model->getUser()->getUsername()); ?>" placeholder="Username">
        <input type="password" name="password" placeholder="New password">
        <input type="password" name="confirmPassword" placeholder="Confirm password">
        <input type="submit" name="edit" value="Edit">
    </div>
</form>
