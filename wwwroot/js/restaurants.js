// ===== Restaurant Filters =====

$(function () {

    var url = "/ar/Restaurants/g/17/bujairi";

    function changeRestaurants() {
        window.location.href =
            url +
            "?cityId=" + ($('#CityId').val() || '') +
            "&zoneId=" + ($('#ZoneId').val() || '') +
            "&cuisineId=" + ($('#CuisineId').val() || '');
    }

    $('#CityId').change(function () {
        changeRestaurants();
    });

    $('#CuisineId').change(function () {
        changeRestaurants();
    });

    $('#ZoneId').change(function () {
        changeRestaurants();
    });

});


// ===== Product Impressions =====

function productImpressions() {
    if (typeof dataLayer !== "undefined") {
        dataLayer.push({
            event: 'view_item_list'
        });
    }
}

window.addEventListener("load", productImpressions);
