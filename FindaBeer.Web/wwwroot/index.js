var module = angular.module('FindaBeer', ["ngRoute", 'naif.base64']);

module.config(function($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "app/beers/beer-list.html",
            controller: "FindaBeerListController"
        })
        .when("/beers/add", {
            templateUrl: "app/beers/beer-edit.html",
            controller: "FindaBeerEditController"
        })
        .when("/beers/:id/edit", {
            templateUrl: "app/beers/beer-edit.html",
            controller: "FindaBeerEditController"
        })
        .when("/beers/:id", {
            templateUrl: "app/beers/beer-details.html",
            controller: "FindaBeerDetailsController"
        });
});