﻿angular.module('cmsAdmin.controllers', [])
.controller('ListController', ['$scope', '$state', 'Service', function ($scope, $state, service) {

    var inline = false;
    $scope.selectedId = 3;

    $scope.isSearching = false;
    if (!$scope.PageNumber) {
        $scope.PageNumber = 0;
    }
    $scope.PageSize = 3;

    $scope.delete = function (item) {
        $scope.item = item;
        service.delete({ Id: item.Id }, function () {
            reloadData();
        });
    };

    if (inline) {
        $scope.edit = function (item) {
            $scope.selectedId = item.Id;
            console.log(item.Id);
        };
        
    } else {
        $scope.edit = function (item) {

            $state.go('edit', { Id: item.Id });

        }; 
    }
    $scope.search = function (pageNumber) {

        $scope.PageNumber = pageNumber;
        reloadData();
    };

    reloadData();

    $scope.getDisplayname = function(title) {
        return "title";
    };

    function reloadData() {

        $scope.items = service.query({
            pageNumber: $scope.PageNumber,
            pageSize: $scope.PageSize
        }, function (result) {
            $scope.items = result.Data;
            $scope.PageCount = result.PageCount;
        });
    }

}])

.controller('AddController', ['$scope', '$state', 'Service', function ($scope, $state, service) {

    $scope.item = new service();

    $scope.save = function () {
        $scope.item.$save(function () {
            $state.go('list');
        });
    };

}])

.controller('EditController', ['$scope', '$state', '$stateParams', 'Service', function ($scope, $state, $stateParams, service) {

    $scope.item = service.query({ Id: $stateParams.Id }, function (value) {
        console.log(value);
    });


    $scope.save = function () {
        $scope.item.$save(function () {
            $state.go('list');
        });
    };


}])

