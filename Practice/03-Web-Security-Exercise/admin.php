<form action="index.php" method="post">
    <?php require_once 'translations.php';?>
    <?php foreach ($translations as $translation) :?>
        <div class="source-translations">
            <?= $translation['text_'.Localization::$LANG_DEFAULT]?>
        </div>
        <label>
            <textarea name="text_bg[<?= array_search($translation, $translations)?>]" rows="5" cols="30"><?= $translation['text_'.Localization::LANG_BG] ?></textarea>
        </label>
    <?php endforeach ?>
    <br/>
    <input type="submit" value="Save"/>
</form>