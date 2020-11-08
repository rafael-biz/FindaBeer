var module = angular.module('FindaBeer', ["ngRoute"]);

module.config(function($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "app/beers/beer-list.html",
            controller: "FindaBeerListController"
        })
        .when("/beers/add", {
            templateUrl: "app/beers/beer-add.html",
            controller: "FindaBeerAddController"
        })
        .when("/beers/:id", {
            templateUrl: "app/beers/beer-details.html",
            controller: "FindaBeerDetailsController"
        });
});