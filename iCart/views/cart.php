<div class="continer bg-4">
    <div class="row">

        <?php foreach ($this->data['cart'] as $product) : ?>

            <div class="col-lg-4 col-sm-6">
                <div class="panel panel-default">
                    <div class="panel-thumbnail"><img src="//placehold.it/450X250/f16251/444" class="img-responsive">
                    </div>

                    <div class="col-lg-6">
                        <div class="panel-body">
                            <p class="lead"><?= $product['name'] ?></p>

                            <p>Model: <?= $product['model'] ?></p>

                            <p>Price: <?= number_format($product['price'], 2) ?></p>
                        </div>
                    </div>
                </div>
                <!--/panel-->
            </div>
            <!--/col-->

        <?php endforeach ?>

        <div class="divider"></div>

        <!-- TODO checkout button with products -->

    </div>
    <!--/row-->
</div><!--/container-->