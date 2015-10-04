<div class="continer bg-4">
    <div class="row">

        <?php foreach ($this->data['products'] as $product) : ?>

            <div class="col-lg-4 col-sm-6">
                <div class="panel panel-default">
                    <div class="panel-thumbnail"><img src="//placehold.it/450X250/f16251/444" class="img-responsive">
                    </div>

                    <div class="col-lg-12">
                        <div class="panel-body">
                            <p class="lead"><?= htmlspecialchars($product['name']) ?></p>

                            <p>Model: <?= htmlspecialchars($product['model']) ?></p>

                            <p>Quantity: <?= htmlspecialchars($product['quantity']) ?></p>

                            <p>Price: <?= number_format($product['newprice'], 2) ?></p>

                            <?php if ($this->data['isLogged']) : ?>

                                <a class="btn btn-default text-center"
                                   href="/products/buy/<?= $product['id'] ?>/<?= $this->csrf ?>">Add to Cart</a>

                            <?php endif ?>
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