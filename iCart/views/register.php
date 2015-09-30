<section class="bg-1">
    <div class="row">
        <div class="col-lg-6 col-lg-offset-3">

            <?=
            Framework\ViewHelpers\FormViewHelper::init()
                ->setAction("")
                ->setMethod("post")
                ->setClasses("form col-lg-12 center-block")
                ->initEmailField()
                ->setName("email")
                ->setClasses("form-group form-control input-lg")
                ->setAttribute("placeholder", "Email")
                ->create()
                ->initPasswordField()
                ->setName("password")
                ->setClasses("form-group form-control input-lg")
                ->setAttribute("placeholder", "Password")
                ->create()
                ->initPasswordField()
                ->setName("confirm")
                ->setClasses("form-group form-control input-lg")
                ->setAttribute("placeholder", "Confirm Password")
                ->create()
                ->initSubmit()
                ->setClasses("btn btn-primary btn-lg btn-block")
                ->setValue("Register")
                ->create()
                ->render();
            ?>

        </div>
    </div>
</section>