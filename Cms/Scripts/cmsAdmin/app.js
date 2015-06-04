﻿var cmsAdmin = angular.module('cmsAdmin', [
    , 'ui.router'
    , 'ngResource'
    , 'ngRoute'
   , 'cmsAdmin.controllers'
   , 'service'
]);

cmsAdmin.config(function ($stateProvider, $resourceProvider) {
    $resourceProvider.defaults.stripTrailingSlashes = false;

    $stateProvider.state('list', {
        url: '/' + entityName + '/list',
        templateUrl: '/content/angular/admin/' + entityName + '/list.html',
        controller: 'ListController'
    }).state('add', {
        url: '/' + entityName + '/add',
        templateUrl: '/content/angular/admin/' + entityName + '/add.html',
        controller: 'AddController'
    }).state('edit', {
        url: '/' + entityName + '/:Id/edit',
        templateUrl: '/content/angular/admin/' + entityName + '/edit.html',
        controller: 'EditController'
    });
}).run(function ($state) {
    $state.go('list');
});


cmsAdmin.directive('pager', function () {
    return {
        restrict: 'E',
        templateUrl: '/content/angular/directives/pager.html',
        controller: ['$scope', function ($scope) {
            $scope.range = function () {

                var step = 2;
                var doubleStep = step * 2;
                var start = Math.max(0, $scope.PageNumber - step);
                var end = start + 1 + doubleStep;
                if (end > $scope.PageCount) { end = $scope.PageCount; }

                var ret = [];
                for (var i = start; i != end; ++i) {
                    ret.push(i);
                }

                return ret;
            };
        }]
    }
});