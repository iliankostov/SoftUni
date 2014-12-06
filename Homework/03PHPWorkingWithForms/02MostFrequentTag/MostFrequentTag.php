<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Most Frequent Tag</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <form method="post">
        <section>
            <h1>
                <label for="tags">Enter Tags:</label>
            </h1>
            <input type="text" name="tags" id="tags"/>
            <input type="submit" name="submit"/>
        </section>
    </form>
        <?php
            if(isset($_POST['submit'])) {
                $arr = preg_split('/(, )/', $_POST['tags']);
                $arr = array_count_values($arr);
                arsort($arr);

                echo "<ul>";
                foreach($arr as $key => $value) {
                    echo "<li>" . htmlentities($key) . " : " . htmlentities($value) . " times</li>";
                }
                echo "</ul>";
                echo "<p>Most Frequent Tag is: " . htmlentities(array_keys($arr)[0]) . "</p>";
            }
        ?>
</main>
</body>
</html>