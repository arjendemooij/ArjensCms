var pageService = angular.module('pageService', ['ngResource']);

pageService.factory('Page', ['$resource',
  function ($resource) {
      return $resource('/Admin/Page/Api/:id', { id: '@Id' }, {
          delete: {
              method: 'DELETE'
          }

      });
  }]);