var service = angular.module('service', ['ngResource']);

service.factory('Service', ['$resource',
  function ($resource) {
      return $resource('/Admin/' + entityName + '/Api/:id', { id: '@Id' }, {
          delete: { method: 'DELETE', isArray: false },
          query: { method: 'GET', isArray: false }
      });
  }]);