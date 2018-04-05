angular.module('BSBookstore').service('categoriaService', categoriaServiceFunction);

categoriaServiceFunction.$inject = ['restService', 'bsMessages'];

function categoriaServiceFunction(restService, bsMessages) {

    //#region Methods

    this.listar = function () {
        return restService.request('category', 'GET');
    };

    this.obter = function (id) {
        return restService.request('category/' + id, 'GET');
    };

    this.salvar = function (category, callbackSave) {
        restService.request('category', 'POST', category).then(
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
        restService.request('category/' + id, 'DELETE').then(
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