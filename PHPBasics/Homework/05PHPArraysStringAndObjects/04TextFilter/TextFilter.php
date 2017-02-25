<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Text Filter</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <section>
        <form method="post">
            <textarea name="text" title="Enter text"></textarea>
            <input type="text" name="banlist" title="Enter banlist"/>
            <input type="submit" name="submit" value="Filter text"/>
        </form>
    </section>
    <section>
        <article>
            <?php
            if (isset($_POST['submit'])):
                $text = $_POST['text'];
                $banList = preg_split('/, /', $_POST['banlist']);
                foreach ($banList as $word) {
                    $asterisk = str_repeat('*', strlen($word));
                    $text = str_ireplace($word,$asterisk,$text);
                }
                ?>
                <p><?php echo htmlspecialchars($text); ?></p>
            <?php endif; ?>
        </article>
    </section>
</main>
</body>
</html>