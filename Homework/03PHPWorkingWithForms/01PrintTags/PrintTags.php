<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Print tags</title>
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
                echo "<ul>";
                foreach($arr as $key => $value) {
                    echo "<li>" . $key . " : " . $value . "</li>";
                }
                echo "</ul>";
            }
        ?>
</main>
</body>
</html>