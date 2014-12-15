<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Coloring Texts</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <section>
        <form method="post">
            <textarea name="text" title="Enter text"></textarea>
            <input type="submit" name="submit" value="Color text"/>
        </form>
    </section>
    <section>
        <?php
        if (isset($_POST['submit'])):
            $text = $_POST['text'];
            $strArr = str_split(preg_replace("/[\s+]/", "", $text));
            foreach($strArr as $char):
                if (ord($char) % 2 == 0):
                    ?>
                <span class="red"><?php echo $char ?></span>
                <?php else: ?>
                <span class="blue"><?php echo $char ?></span>
                <?php
                endif;
            endforeach;
         endif; ?>
    </section>
</main>
</body>
</html>