<section class="bg-3">
    <div class="row">
        <div class="col-lg-6 col-lg-offset-3">

            <?=
            Framework\ViewHelpers\FormViewHelper::init()
                ->setAction("/users/postlogin")
                ->setMethod("post")
                ->setClasses("form col-lg-12 center-block")
                ->initTextField()
                ->setName("username")
                ->setClasses("form-group form-control input-lg")
                ->setAttribute("placeholder", "Username")
                ->create()
                ->initPasswordField()
                ->setName("password")
                ->setClasses("form-group form-control input-lg")
                ->setAttribute("placeholder", "Password")
                ->create()
                ->initSubmit()
                ->setClasses("btn btn-primary btn-lg btn-block")
                ->setValue("Login")
                ->create()
                ->render();
            ?>

        </div>
    </div>
</section>