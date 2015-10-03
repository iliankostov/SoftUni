<div class="continer bg-4">
    <div class="row">

        <?php foreach ($this->data['products'] as $product) : ?>

            <div class="col-lg-4 col-sm-6">
                <div class="panel panel-default">
                    <div class="panel-thumbnail"><img src="//placehold.it/450X250/f16251/444" class="img-responsive">
                    </div>

                    <div class="col-lg-6">
                        <div class="panel-body">
                            <p class="lead"><?= $product['name'] ?></p>

                            <p>Model: <?= $product['model'] ?></p>

                            <p>Quantity: <?= $product['quantity'] ?></p>

                            <p>Price: <?= number_format($product['price'], 2) ?></p>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <?php if($this->data['isLogged']) : ?>
                        <p>
                            <div class="btn btn-default text-center">Add to Cart</div>
                        </p>
                    <?php endif ?>
                    </div>

                </div>
                <!--/panel-->
            </div>
            <!--/col-->

        <?php endforeach ?>

    </div>
    <!--/row-->
</div><!--/container-->