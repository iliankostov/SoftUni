<h1>TODO</h1>
<ul style="list-style-type: decimal">
    <?php foreach($this->items as $item): ?>
    <h3><li><?= htmlspecialchars($item['item']) ?> <a href="\todos\delete\<?=$item['id']?>">Delete</a></li></h3>
    <?php endforeach; ?>
</ul>
<h1><a href="\todos\add">Add item</a></h1>
<h1><a href="\users\logout">Logout</a></h1>
<p><?=$this->error?></p>