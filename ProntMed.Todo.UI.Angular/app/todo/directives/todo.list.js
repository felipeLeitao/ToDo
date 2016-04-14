(function () {
    'use strict';

    angular.module('app').directive('todolist', todoform);

    todoform.$inject = ["todoService"];

    function todoform(todoService) {

        var diretiva = {
            restrict: 'E',
            templateUrl: 'app/todo/views/partials/list.html',
            scope: true,
            link: link
        }

        return diretiva;

        function link(scope, element, attrs) {

            scope.remover = function (tarefa) {
                todoService.Remover(tarefa.Codigo)
                    .success(function () {
                        var index = scope.vm.tarefas.indexOf(tarefa);
                        scope.vm.tarefas.splice(index, 1);

                        alert("Tarefa removida com sucesso!");

                    }).error(function (erro) {
                        alert(erro);
                    });
            }
        }
    }
})();