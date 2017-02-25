<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>URL Replacer</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <section>
        <form method="post">
            <textarea name="text" title="Enter text"></textarea>
            <input type="submit" name="submit" value="Replace URLs"/>
        </form>
    </section>
    <section>
        <article>
            <?php
            if (isset($_POST['submit'])):
                $text = $_POST['text'];
                $pattern = "/<a(?:\s+(?!href).)*\s+href\s*=\s*(?:'|\")*([^\'\"]+)*(?:'|\")*(?:(?!href|>).)*>([^<]*)<\/a>/";
                preg_match_all($pattern, $text, $matches);
                for ($i = 0; $i < count($matches[0]); $i++) {
                    $replacement_string = '[URL=' . $matches[1][$i] . ']' . $matches[2][$i] . '[/URL]';
                    $text = str_replace($matches[0][$i], $replacement_string, $text);
                }
            ?>
            <p><?php echo htmlspecialchars($text); ?></p>

            <?php endif; ?>
        </article>
    </section>
</main>
</body>
</html>