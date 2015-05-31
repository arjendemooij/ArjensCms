angular.module('cmsAdmin.controllers', [])
.controller('PageListController', ['$scope', 'Page', function ($scope, pageService) {
    
    $scope.delete = function (page) {
        $scope.page = page;
        page.$delete(function() {
            $scope.pages = pageService.query();
        });
        
    };

    $scope.pages = pageService.query();
}])

.controller('PageAddController', ['$scope', '$routeParams', '$state', 'Page', function ($scope, $routeParams,$state, page) {
    $scope.page = new page();
    
    console.log("saving");
    
    $scope.addPage = function () {
        $scope.page.$save(function () {
            $state.go('pages');
        });
    };

}]) 