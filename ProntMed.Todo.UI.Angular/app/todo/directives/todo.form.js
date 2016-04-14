(function () {
    'use strict';

    angular.module('app').directive('todoForm', todoform);

    todoform.$inject = "";

    function todoform()
    {
        return {

            restrict: 'E',
            templateUrl: 'app/todo/views/partials/form.html',
            scope: false
        }
    }


})();