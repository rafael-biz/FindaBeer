var module = angular.module('FindaBeer');

module.controller('FindaBeerListController', function FindaBeerController($scope, $http, Ingredients) {
    $scope.beers = null;
    $scope.filter = {};

    $scope.ingredients = Ingredients();

    $http({
        method: 'GET',
        url: '/api/beers'
    }).then(
        function(response) {
            $scope.beers = response.data;
        }
    );

    $scope.clearClick = function() {
        $scope.filter = {};
        $scope.ingredients = Ingredients();
        $scope.searchClick();
    };

    $scope.searchClick = function() {
        var ingredients = [];
        for (var i = 0; i < $scope.ingredients.length; i++) {
            var ingredient = $scope.ingredients[i];
            if (ingredient.selected) {
                ingredients.push(ingredient.name);
            }
        }

        $scope.filter.ingredients = ingredients;
        $scope.beers = null;

        $http({
            method: 'POST',
            url: '/api/beers/filter',
            data: $scope.filter
        }).then(
            function(response) {
                $scope.beers = response.data;
            }
        );
    };

    $scope.addClick = function() {
        window.location.href = "#!beers/add";
    };
});

module.controller('FindaBeerDetailsController', function FindaBeerDetailsController($scope, $http, $routeParams) {
    $scope.beer = null;

    $scope.id = $routeParams.id;

    $http({
        method: 'GET',
        url: '/api/beers/' + $scope.id
    }).then(
        function(response) {
            $scope.beer = response.data;
        }
    );

    $scope.editClick = function() {
        window.location.href = "#!beers/" + $scope.id + "/edit";
    };

    $scope.deleteClick = function() {
        $http({
            method: 'DELETE',
            url: '/api/beers/' + $scope.id
        }).then(
            function(response) {
                window.location.href = "#";
            }
        );
    };
});

module.controller('FindaBeerEditController', function FindaBeerEditController($scope, $http, $routeParams, Ingredients) {
    $scope.id = $routeParams.id;
    $scope.ingredients = Ingredients();

    if ($scope.id) {
        $http({
            method: 'GET',
            url: '/api/beers/' + $scope.id
        }).then(
            function(response) {
                $scope.beer = response.data;

                for (var i = 0; i < $scope.beer.ingredients.length; i++) {
                    for (var j = 0; j < $scope.ingredients.length; j++) {
                        if ($scope.ingredients[j].name == $scope.beer.ingredients[i]) {
                            $scope.ingredients[j].selected = true;
                        }
                    }
                }
            }
        );
    } else {
        $scope.beer = {};
    }

    $scope.saveClick = function() {
        var ingredients = [];
        for (var i = 0; i < $scope.ingredients.length; i++) {
            var ingredient = $scope.ingredients[i];
            if (ingredient.selected) {
                ingredients.push(ingredient.name);
            }
        }

        $scope.beer.ingredients = ingredients;

        if ($scope.file) {
            $scope.beer.defaultImage = $scope.file.base64;
        }

        $http({
            method: $scope.id ? 'PUT' : 'POST',
            data: $scope.beer,
            url: $scope.id ? ('/api/beers/' + $scope.id) : ('/api/beers')
        }).then(
            function(response) {
                window.location.href = "#!beers/" + response.data.id;
            }
        );
    };
});

module.constant("Ingredients", function() {
    return [
        { name: "água" },
        { name: "açúcar de cana" },
        { name: "açúcar mascavo" },
        { name: "aveia" },
        { name: "castanha do pará" },
        { name: "corante caramelo" },
        { name: "fermento" },
        { name: "lúpulo" },
        { name: "polpa de uvaia" },
        { name: "malte" },
        { name: "malte de trigo" },
        { name: "malte de cevada" },
        { name: "mel" },
        { name: "milho" },
        { name: "rapadura" }
    ];
});