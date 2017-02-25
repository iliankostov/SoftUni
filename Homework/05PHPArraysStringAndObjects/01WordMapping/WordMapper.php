<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Word Mapping</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <section>
        <form method="post">
            <textarea name="text" title="Enter text"></textarea>
            <input type="submit" name="submit" value="Count words"/>
        </form>
    </section>
    <section>
        <table>
            <?php
            if (isset($_POST['submit'])):
                $text = $_POST['text'];
                $caseInText = strtolower($text);
                $words = str_word_count($caseInText, 2);
                $wordsCount = array_count_values($words);
                foreach ($wordsCount as $key => $value):
            ?>
            <tr>
                <td><?php echo htmlspecialchars($key); ?></td>
                <td><?php echo htmlspecialchars($value); ?></td>
            </tr>
            <?php
                endforeach;
            endif;
            ?>
        </table>
    </section>
</main>
</body>
</html>