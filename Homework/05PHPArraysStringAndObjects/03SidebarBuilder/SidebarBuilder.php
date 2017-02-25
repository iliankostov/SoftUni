<?php
function buildList($str)
{
    $strArr = preg_split('/, /', $str);
    echo "<ul>";
    foreach($strArr as $listItem) {
        echo "<li><a href=''>" . htmlspecialchars($listItem) . "</a></li>";
    }
    echo "</ul>";
}
?>
<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Sidebar Builder</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <section>
        <form method="post">
            <label for="cats">Categories:</label><input type="text" name="cats" id="cats"/>
            <label for="tags">Tags:</label><input type="text" name="tags" id="tags"/>
            <label for="months">Months:</label><input type="text" name="months" id="months"/>
            <input type="submit" name="submit" value="Generate"/>
        </form>
    </section>
    <section>
        <?php
        if (isset($_POST['submit'])):
        ?>
            <aside>
                <h3>Categories</h3>
                <hr/>
                <?php buildList($_POST['cats']); ?>
            </aside>
            <aside>
                <h3>Tags</h3>
                <hr/>
                <?php buildList($_POST['tags']); ?>
            </aside>
            <aside>
                <h3>Months</h3>
                <hr/>
                <?php buildList($_POST['months']); ?>
            </aside>
        <?php endif; ?>
    </section>
</main>
</body>
</html>