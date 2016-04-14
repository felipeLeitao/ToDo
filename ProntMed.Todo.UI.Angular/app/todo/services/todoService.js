(function () {
    'use strict';

    angular.module('app').service('todoService', todoService);

    todoService.$inject = ['$http', 'url'];

    function todoService($http, url) {

        var link = url.url;

            this.Listar = function () {
                return $http({
                    method: 'GET',
                    url: link + '/Listar'
                });
            }

            this.Cadastrar = function (tarefa) {
                return $http({
                    method: 'POST',
                    url: link + '/Cadastrar',
                    data: tarefa
                });
            }

            this.Alterar = function (tarefa) {
                return $http({
                    method: 'POST',
                    url: link + '/Alterar',
                    data: tarefa
                });
            }

            this.Remover = function (codigo) {
                return $http({
                    method: 'GET',
                    url: link + '/Remover',
                    params: {id : codigo}
                });
            }

            this.Pesquisar = function (descricao) {
                return $http({
                    method: 'GET',
                    url: link + '/Pesquisar',
                    params: { descricao : descricao}
                });
            }

            this.GetByID = function (codigo) {
                return $http({
                    method: 'GET',
                    url: link + '/GetByID',
                    params: {id: codigo}
                });
            }

            this.TarefasPesquisadas = [] 
        
    }

})();