<?php
session_start();
?>
<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>HTML Tags Counter</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <form method="post">
        <section>
            <h1>
                <label for="tag">Enter HTML tags:</label>
            </h1>
            <input type="text" name="tag" id="tag"/>
            <input type="submit" name="submit"/>
        </section>
    </form>
    <?php
        if (isset($_POST['submit'])) {
            //tags list from: https://developer.mozilla.org/en-US/docs/Web/Guide/HTML/HTML5/HTML5_element_list
            $htmlTags = array('html', 'head', 'title', 'base', 'link', 'meta', 'style',
                'script', 'noscript', 'template', 'body', 'section', 'nav',
                'article', 'aside', 'h1', 'h2', 'h3', 'h4', 'h5', 'h6',
                'header', 'footer', 'address', 'main', 'p', 'hr', 'pre',
                'blockquote', 'ol', 'ul', 'li', 'dl', 'dt', 'figure',
                'figcaption', 'div', 'a', 'em', 'strong', 'small', 's',
                'cite', 'q', 'dfn', 'abbr', 'data', 'time', 'code', 'var',
                'samp', 'kbd', 'sub', 'sup', 'i', 'b', 'u', 'mark', 'ruby',
                'rt', 'rp', 'bdi', 'bdo', 'span', 'br', 'wbr', 'ins', 'del',
                'img', 'iframe', 'embed', 'object', 'param', 'video', 'audio',
                'source', 'track', 'canvas', 'map', 'area', 'svg', 'math',
                'table', 'caption', 'colgroup', 'col', 'tbody', 'thead',
                'tfoot', 'tr', 'td', 'th', 'form', 'fieldset', 'legend',
                'label', 'input', 'button', 'select', 'datalist', 'optgroup',
                'option', 'textarea', 'keygen', 'output', 'progress',
                'meter', 'details', 'summary', 'menuitem', 'menu');
            if (!isset($_SESSION['count'])) {
                $_SESSION['count'] = 0;
            }
            if (in_array($_POST['tag'], $htmlTags)) {
                $_SESSION['count']++;
                echo "<h2>Valid HTML tag!</h2>";
                echo "<h2>Score: " . $_SESSION['count'] . "</h2>";
            } else {
                echo "<h2>Invalid HTML Tag!</h2>";
                echo "<h2>Score: " . $_SESSION['count'] . "</h2>";
            }
        }
    ?>
</main>
</body>
</html>