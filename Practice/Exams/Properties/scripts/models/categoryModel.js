define(['storageService', 'constants', 'headerService', 'requestService'],
    function (storageService, constants, headerService, requestService) {

        function CategoryModel() {
            this.serviceUrl = constants.BASE_URL + 'classes/Category';
        }

        CategoryModel.prototype.getCategories = function () {
            var url = this.serviceUrl;
            var headers = headerService.get();

            return requestService.get(headers, url);
        };
        return {
            load: function () {
                return new CategoryModel();
            }
        }
    }
);
