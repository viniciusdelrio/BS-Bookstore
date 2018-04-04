angular.module('BSBookstore').service('livroService', livroServiceFunction);

livroServiceFunction.$inject = ['restService', 'bsMessages'];

function livroServiceFunction(restService, bsMessages) {

    //#region Methods

    this.listar = function () {
        return restService.request('book', 'GET');
    };

    this.obter = function (id) {
        return restService.request('book/' + id, 'GET');
    };

    this.salvar = function (book, callbackSave) {
        restService.request('book', 'POST', book).then(
            function (data) {
                if (data.status == EnumResponseStatus.Success) {
                    callbackSave(data);
                }
            },
            function (data) {
                bsMessages.showMessage(EnumMessages.Error.ErroAoCompletarRequisicaoWeb);
            }
        );
    };

    this.excluir = function (id, deleteSuccessCallback) {
        restService.request('book/' + id, 'DELETE').then(
            function (data) {
                if (data.status == EnumResponseStatus.Success) {
                    deleteSuccessCallback();
                }
            },
            function (data) {
                bsMessages.showMessage(EnumMessages.Error.ErroAoCompletarRequisicaoWeb);
            }
        );
    };

    //#endregion

};