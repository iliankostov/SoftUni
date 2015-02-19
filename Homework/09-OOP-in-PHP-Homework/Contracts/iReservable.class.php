<?php
namespace Contracts;

interface iReservable {
    function addReservation($reservation);

    function removeReservation($reservation);
}