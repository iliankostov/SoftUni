<h1>Admin Panel - Home</h1>

<h1>Add product</h1>
<form action="/admin/products/add" method="post">
    <?php
    $start = \Framework\ViewHelpers\DropdownViewHelper::init()->setAttribute("name", "category");
    foreach ($this->data['categories'] as $category) {
        $start->initOption()
            ->setValue($category['id'])
            ->setInnerValue($category['name'])
            ->create();
    }
    $start->render()
    ?>
    <input type="text" placeholder="Product name" name="productname"/>
    <input type="text" placeholder="Product model" name="productmodel"/>
    <input type="text" placeholder="Product price" name="productprice"/>
    <input type="number" placeholder="Product quantity" name="productquantity"/>
    <input type="submit" value="Add">
</form>

<h1>Manipulate products in DB</h1>
<table border="1">
    <tr>
        <th>Id</th>
        <th>Name</th>
        <th>Model</th>
        <th>Price</th>
        <th>Quantity</th>
        <th>Category</th>
        <th>Edit</th>
        <th>Delete</th>
    </tr>
    <?php foreach($this->data['products'] as $product): ?>
        <tr>
            <td><?= $product['id'] ?></td>
            <td><?= $product['name'] ?></td>
            <td><?= $product['model'] ?></td>
            <td><?= $product['price'] ?></td>
            <td><?= $product['quantity'] ?></td>
            <td><?= $product['categoryName'] ?></td>
            <td><a href="/admin/products/edit/<?=$product['id']?>">Edit</a></td>
            <td><a href="/admin/products/delete/<?=$product['id']?>">Delete</a></td>
        </tr>
    <?php endforeach;?>
</table>
