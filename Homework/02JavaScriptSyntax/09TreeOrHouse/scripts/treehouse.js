function treeHouseCompare(arr) {
    var houseArea = Math.pow(arr[0], 2) + (0.5 * arr[0] * 2 / 3 * arr[0]);
    var treeArea = arr[1] * arr[1] / 3 + Math.PI * Math.pow(2/3 * arr[1], 2);
    if (houseArea > treeArea) {
        return console.log('house/%d', houseArea.toFixed(2));
    } else {
        return console.log('tree/%d', treeArea.toFixed(2));
    }
}

treeHouseCompare([3, 2]);
treeHouseCompare([3, 3]);
treeHouseCompare([4, 5]);