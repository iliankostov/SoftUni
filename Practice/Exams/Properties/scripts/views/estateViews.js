define(['mustache', 'sammy', 'storageService'], function (Mustache, Sammy, storageService) {
    function EstatesViews() {
        this.showEstates = showEstatesView;
        this.showAddEstateView = showAddEstateView;
        this.showEditEstateView = showEditEstateView;
        this.showDeleteEstateView = showDeleteEstateView;
    }

    function showEstatesView(selector, estateData, categoriesData) {
        var data = {
            estates: estateData['results'],
            categories: categoriesData['results']
        };
        $.get('templates/list-estates.html', function (template) {
            estateData['results'].forEach(function (object) {
                object.isEdible = true;
                var aclId = Object.keys(object['ACL'])[1];
                var userId = storageService.getUserId();
                if (aclId !== userId) {
                    object.isEdible = false;
                }
            });
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);

        }).then(function () {
            $('.edit-button').click(function () {
                var data = getElementData(this);
                Sammy(function () {
                    this.trigger('showEditEstate', data);
                })
            });

            $('.delete-button').click(function () {
                var data = getElementData(this);

                Sammy(function () {
                    this.trigger('showDeleteEstate', data);
                });
            });

            $('.filter-button').click(function () {
                var keyword = $($(this).parent()).find('#search-bar').val();
                var priceFrom = $($(this).parent()).find('#min-price').val();
                var priceTo = $($(this).parent()).find('#max-price').val();
                var categoryName = $($(this).parent()).find('#category').val();
                var categoryObject = {};
                categoriesData['results'].forEach(function (object) {
                    if (object.name === categoryName) {
                        categoryObject = object;
                    }
                });

                var filterEstateData = {
                    keyword: keyword,
                    priceFrom: priceFrom,
                    priceTo: priceTo,
                    category: categoryObject
                };

                Sammy(function () {
                    this.trigger('filterEstates', filterEstateData);
                });
            });

            // todo clear filter

        }).done();
    }

    function showAddEstateView(selector, categoriesData) {
        $.get('templates/add-estate.html', function (template) {
            var outHtml = Mustache.render(template, categoriesData);
            $(selector).html(outHtml);
        }).then(function () {
            $('#add-estate-button').click(function () {
                var categoryString = $('#category').val();
                var categoryObject = {};
                categoriesData['results'].forEach(function (object) {
                    if (object.name === categoryString) {
                        categoryObject = object;
                    }
                });
                var priceString = $('#price').val();
                var priceNumber = Number(priceString);

                var estate = {
                    name: $('#name').val(),
                    category: categoryObject,
                    price: priceNumber
                };

                Sammy(function () {
                    this.trigger('addEstate', estate);
                });

                return false;
            })
        }).done();
    }

    function showEditEstateView(selector, data) {
        $.get('templates/edit-estate.html', function (template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
        }).then(function () {
            $('#edit-estate-button').click(function () {
                var priceNumber = Number($('#price').val());
                var newEstateData = {
                    name: $('#item-name').val(),
                    price: priceNumber,
                    id: $('#edit-estate-button').attr('data-id')
                };

                Sammy(function () {
                    this.trigger('editEstate', newEstateData);
                });

                return false;
            })
        }).done();
    }

    function showDeleteEstateView(selector, data) {
        $.get('templates/delete-estate.html', function (template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
        }).then(function () {
            $('#delete-estate-button').click(function () {
                var id = $('#delete-estate-button').attr('data-id');

                Sammy(function () {
                    this.trigger('deleteEstate', id);
                });

                return false;
            })
        }).done();
    }

    function getElementData(element) {
        var name = $($(element).parent().parent().children()[0]).find('.item-name').text();
        var category = $($(element).parent().parent().children()[0]).find('.category').find('.category-name').text();
        var price = $($(element).parent().parent().children()[0]).find('.price').find('.price-number').text();
        var id = $(element).parent().parent().attr('data-id');

        return {name: name, category: category, price: price, objectId: id};
    }

    return {
        load: function () {
            return new EstatesViews();
        }
    }
});
