<h1>Edit product panel</h1>
<form action="/admin/products/editpost" method="post">
    <input type="hidden" name="id" value="<?=$this->data['product']['id']?>"><br><br>
    Name: <input type="text" value="<?=$this->data['product']['name']?>" name="productname"><br><br>
    Model: <input type="text" value="<?=$this->data['product']['model']?>" name="productmodel"><br><br>
    Quantity: <input type="number" value="<?=$this->data['product']['quantity']?>" name="productquantity"><br><br>
    Price: <input type="number" value="<?=$this->data['product']['price']?>" name="productprice"><br><br>
    Category: <select name="category">
        <?php foreach($this->data['categories'] as $category): ?>
            <option value="<?= $category['id'] ?>" <?= strcmp($category['id'], $this->data['product']['categoryId']) === 0 ? 'selected="selected"' : ''  ?>><?=$category['name']?></option>
        <?php endforeach; ?>
    </select><br><br>
    <input type="submit" value="Edit">
</form>