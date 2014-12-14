<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Modify String</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <section>
        <form method="post">
            <input type="text" name="str" title="Input String" />
            <input type="radio" name="func" value="palindrome" id="palindrome" /><label for="palindrome">Check Palindrome</label>
            <input type="radio" name="func" value="reverse" id="reverse" /><label for="reverse">Reverse String</label>
            <input type="radio" name="func" value="split" id="split" /><label for="split">Split String</label>
            <input type="radio" name="func" value="hash" id="hash" /><label for="hash">Hash String</label>
            <input type="radio" name="func" value="shuffle" id="shuffle" /><label for="shuffle">Shuffle String</label>
            <input type="submit" name="submit"/>
        </form>
    </section>
    <section>
        <?php
        if (isset($_POST['submit'], $_POST['func']) && $_POST['str'] != '') {
            $str = $_POST['str'];
            $func = $_POST['func'];
            if ($func == 'palindrome') {
                $strToLow = strtolower($str);
                $strArr = str_split($strToLow);
                $strArrRev = array_reverse($strArr);
                $strRev = implode($strArrRev);
                if ($str == $strRev) {
                    echo "$str is a palindrome!";
                } else {
                    echo "$str is not a palindrome!";
                }
            } elseif ($func == 'reverse') {
                $strArr = str_split($str);
                $strArrRev = array_reverse($strArr);
                $strToPrint = implode($strArrRev);
                echo $strToPrint;
            } elseif ($func == 'split') {
                $strArr = str_split(preg_replace("/[0-9,.!?]/", "", $str));
                $strToPrint = implode(' ', $strArr);
                echo $strToPrint;
            } elseif ($func == 'hash') {
                $strToPrint = crypt($str, '$6$rounds=5000$anexamplestringforsalt$');
                echo $strToPrint;
            } elseif ($func == 'shuffle') {
                $strArr = str_split($str);
                shuffle($strArr);
                $strToPrint = implode($strArr);
                echo $strToPrint;
            }
        }
        ?>
    </section>
</main>
</body>
</html>
