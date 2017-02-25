function decimalToHexString(number)
{
    if (number < 0)
    {
        number = 'Please enter positive number';
    }

    return number.toString(16).toUpperCase();
}

var number = Number(prompt("Enter a number"));

alert(decimalToHexString(number));
