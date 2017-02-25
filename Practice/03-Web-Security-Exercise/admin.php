<header>
    <a href="index.php">Home</a>
</header>
<br/>
<form method="post">
    <?php require_once 'translations.php'; ?>
    <?php foreach ($translations as $translation) : ?>
        <div class="source-translations">
            <?= $translation['text_' . Localization::$LANG_DEFAULT] ?>
        </div>
        <label>
            <textarea name="<?php echo 'text_bg[' . $translation['id'] . ']'; ?>" rows="5" cols="30"><?php echo $translation['text_bg']; ?></textarea>
        </label>
    <?php endforeach ?>
    <br/>
    <input type="submit" value="Save"/>
</form>