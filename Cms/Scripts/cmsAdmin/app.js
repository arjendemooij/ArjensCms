var cmsAdmin = angular.module('cmsAdmin', [
    , 'ui.router'
    , 'ngResource'
    , 'ngRoute'
   , 'cmsAdmin.controllers'
   , 'pageService'
]);

cmsAdmin.config(function ($stateProvider) {
    $stateProvider.state('pages', {
        url: '/page/list',
        templateUrl: '/content/angular/admin/page/list.html',
        controller: 'PageListController'
    }).state('detail', {
        url: '/page/:id/detail',
        templateUrl: '/content/angular/admin/page/details.html',
        controller: 'PageDetailController'
    }).state('add', {
        url: '/page/add',
        templateUrl: '/content/angular/admin/page/add.html',
        controller: 'PageAddController'
    }).state('edit', {
        url: '/page/:id/edit',
        templateUrl: '/content/angular/admin/page/edit.html',
        controller: 'PageEditController'
    });
}).run(function ($state) {
    $state.go('pages');
});

