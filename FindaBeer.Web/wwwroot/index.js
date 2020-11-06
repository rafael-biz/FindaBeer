var module = angular.module('FindaBeer', []);

module.controller('FindaBeerController', function FindaBeerController($scope, $http) {
    $scope.test = "Hello World 2!";
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