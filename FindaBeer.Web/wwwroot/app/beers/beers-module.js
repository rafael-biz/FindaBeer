var module = angular.module('FindaBeer');

module.controller('FindaBeerListController', function FindaBeerController($scope, $http) {
    $scope.beers = null;

    $http({
        method: 'GET',
        url: '/api/beers'
    }).then(
        function(response) {
            $scope.beers = response.data;
        }
    );
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
});

module.controller('FindaBeerAddController', function FindaBeerAddController($scope, $http) {
    $scope.test = "FindaBeerAddController!";
});