<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Sentence Extractor</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <section>
        <form method="post">
            <textarea name="text" title="Enter text"></textarea>
            <input type="text" name="word" title="Enter word"/>
            <input type="submit" name="submit" value="Extract sentence"/>
        </form>
    </section>
    <section>
        <article>
            <?php
            if (isset($_POST['submit'])):
                $text = $_POST['text'];
                $word = $_POST['word'];
                preg_match_all('/[^.!?\s]{1}[^.!?]*[.?!]+/', $text, $sentences);
                foreach ($sentences[0] as $sentence):
                    $words = preg_split('/ /', $sentence);
                    if (in_array($word, $words)):
                ?>
                <p><?php echo $sentence ?></p>
            <?php   endif;
                endforeach;
            endif; ?>
        </article>
    </section>
</main>
</body>
</html>