<?php

namespace Framework\ViewHelpers\Elements;


class RadioButton extends Element
{
    public function __construct()
    {
        $this->elementName = "input";
        $this->setAttribute("type", "radio");

        return $this;
    }
}