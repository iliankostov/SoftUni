define(['storageService'], function (storageService) {
    var parseService = {};

    parseService.createCategoryPointer = function (categoryId) {
        return {
            __type: 'Pointer',
            className: 'Category',
            objectId: categoryId
        }
    };

    parseService.createAuthorPointer = function () {
        return {
            __type: 'Pointer',
            className: '_User',
            objectId: storageService.getUserId()
        }
    };

    parseService.createACL  = function () {
        var userId = storageService.getUserId();
        var acl = {};
        acl[userId] = {"write": true, "read": true};
        acl['*'] = {"read": true};
        return acl;
    };

    return parseService;
});
