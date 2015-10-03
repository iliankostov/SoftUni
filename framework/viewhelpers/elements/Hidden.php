<?php


namespace Framework\ViewHelpers\Elements;


class Hidden extends Element
{
    public function __construct()
    {
        $this->elementName = "input";
        $this->setAttribute("type", "hidden");

        return $this;
    }
}