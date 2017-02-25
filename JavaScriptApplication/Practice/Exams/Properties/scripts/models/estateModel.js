define(['storageService', 'constants', 'headerService', 'requestService', 'parseService'],
    function (storageService, constants, headerService, requestService, parseService) {

        function EstateModel() {
            this.serviceUrl = constants.BASE_URL + 'classes/Estate';
        }

        EstateModel.prototype.getEstates = function () {
            var url = this.serviceUrl + '?include=category';
            var headers = headerService.get();

            return requestService.get(headers, url);
        };

        EstateModel.prototype.filterEstates = function (data) {
            var categoryPointerString = '';
            if (data.category.hasOwnProperty('objectId')) {
                categoryPointerString = ',"category":{"__type":"Pointer","className":"Category","objectId":"' + data.category.objectId + '"}';
            }
            var queryUrl = this.serviceUrl +
                '?where={"price":{"$gte":' + data.priceFrom + ',"$lte":'+ data.priceTo +'}' +
                categoryPointerString +'}&include=category';
            var headers = headerService.get();
            return requestService.get(headers, queryUrl);
        };

        EstateModel.prototype.addEstate = function (estateData) {
            var url = this.serviceUrl;
            var headers = headerService.get();
            var data = JSON.stringify(estateData);

            return requestService.post(headers, url, data);
        };

        EstateModel.prototype.editEstate = function (estateId, estateData) {
            var url = this.serviceUrl + '/' + estateId;
            var headers = headerService.get();
            var data = JSON.stringify(estateData);

            return requestService.update(headers, url, data);
        };

        EstateModel.prototype.deleteEstate = function (estateId) {
            var url = this.serviceUrl + '/' + estateId;
            var headers = headerService.get();

            return requestService.remove(headers, url);
        };

        return {
            load: function () {
                return new EstateModel();
            }
        }
    }
);
