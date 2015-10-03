<h1>Home</h1>

<?php

        $start = \Framework\ViewHelpers\DropdownViewHelper::init();

        foreach ($this->data['categories'] as $category) {
            $start->initOption()
                ->setValue($category['id    '])
                ->setInnerValue($category['name'])
                ->create();
        }

        $start->render()
?>