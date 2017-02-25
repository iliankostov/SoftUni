<div class="continer bg-4">
    <div class="row">

        <?php foreach ($this->data['cart'] as $product) : ?>

            <div class="col-lg-4 col-sm-6">
                <div class="panel panel-default">
                    <div class="panel-thumbnail"><img src="//placehold.it/450X250/f16251/444" class="img-responsive">
                    </div>

                    <div class="col-lg-6">
                        <div class="panel-body">
                            <p class="lead"><?= htmlspecialchars($product['name']) ?></p>

                            <p>Model: <?= htmlspecialchars($product['model']) ?></p>

                            <p>Price: <?= number_format($product['price'], 2) ?></p>

                            <a class="btn btn-default text-center"
                               href="/users/removeproductfromcart/<?= $product['id'] ?>/<?= $this->csrf ?>">Remove
                                product</a>
                        </div>
                    </div>
                </div>
                <!--/panel-->
            </div>
            <!--/col-->

        <?php endforeach ?>
    </div>
    <!--/row-->
</div><!--/container-->

<div class="divider"></div>

<p style="font-size: 50px; text-align: center"><?= count($this->data['cart']) > 0 ? '<a href="/users/checkout/' . $this->csrf . '">Chekout</a></p>' : 'Yor cart is empty</p>' ?>
