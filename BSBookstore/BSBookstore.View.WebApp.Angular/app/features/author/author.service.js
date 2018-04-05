angular.module('BSBookstore').service('autorService', autorServiceFunction);

autorServiceFunction.$inject = ['restService', 'bsMessages'];

function autorServiceFunction(restService, bsMessages) {

    //#region Methods

    this.listar = function () {
        return restService.request('author', 'GET');
    };

    this.obter = function (id) {
        return restService.request('author/' + id, 'GET');
    };

    this.salvar = function (author, callbackSave) {
        restService.request('author', 'POST', author).then(
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
        restService.request('author/' + id, 'DELETE').then(
            function (data) {
                if (data && data.status == EnumResponseStatus.Success) {
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