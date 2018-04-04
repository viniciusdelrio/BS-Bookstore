var EnumMessages = {
    Success: {
        RegistroAlterado: {
            title: EnumSwalTitle.Success,
            type: EnumSwalType.Success,
            growlType: EnumGrowlType.Success,
            msg: "Registro alterado com sucesso!"
        },
        RegistroCadastradoIncluirNovo: {
            title: EnumSwalTitle.Success,
            type: EnumSwalType.Success,
            growlType: EnumGrowlType.Success,
            msg: "Registro cadastrado com sucesso! Deseja realizar um novo cadastro?"
        },
        RegistroExcluido: {
            title: EnumSwalTitle.Success,
            type: EnumSwalType.Success,
            growlType: EnumGrowlType.Success,
            msg: "Registro excluído com sucesso!"
        }
    },
    Alert: {
        ConfirmaExclusao: {
            title: EnumSwalTitle.Alert,
            type: EnumSwalType.Alert,
            growlType: EnumGrowlType.Danger,
            msg: "Confirma a exclusão {0}?"
        },
        NaoExisteMetodoExclusao: {
            title: EnumSwalTitle.Alert,
            type: EnumSwalType.Alert,
            growlType: EnumGrowlType.Alert,
            msg: "Não existe método de exclusão implementado!"
        }
    },
    Error: {
        ErroAoCompletarRequisicaoWeb: {
            title: EnumSwalTitle.Error,
            type: EnumSwalType.Error,
            growlType: EnumGrowlType.Error,
            msg: "Ocorreu um erro ao realizar a requisição com o servidor!"
        }
    }
};

angular.module('BSBookstore').service('bsMessages', bsMessagesService);

bsMessagesService.$inject = ['$state', 'growlService'];

function bsMessagesService($state, growlService) {
    this.showNotify = function (msg, growlType) {
        var gType = EnumGrowlType.Danger;

        if (growlType) {
            gType = growlType;
        } else if (msg.growlType) {
            gType.msg.growlType;
        }

        growlService.growl(msg.msg, gType);
    };

    this.showMessage = function (msg, swalType, confirmFunction) {
        var sType = EnumSwalType.Error;

        if (swalType) {
            sType = swalType;
        } else if (msg.type) {
            sType = msg.type;
        }

        switch (sType) {
            case EnumSwalType.Success:
                swal(createSuccessSwal(msg.msg));
                break;

            case EnumSwalType.Alert:
                if (!confirmFunction) {
                    swal(createSwalAlert(msg.msg));
                } else {
                    swal(createSwalAlert(msg.msg), confirmFunction);
                }
                break;

            case EnumSwalType.Error:
                swal(createSwalError(msg.msg));
                break;

            case EnumSwalType.Info:
                swal(createSwalInfo(msg.msg));
                break;

            case EnumSwalType.Confirm:
                swal(createSwalConfirm(msg.msg), confirmFunction);
                break;

            default:
                swal(createSwalInfo(msg));
                break;
        }
    };

    this.showSaveSuccessMessage = function (isEdit, url) {
        if (isEdit) {
            var msg = clone(EnumMessages.Success.RegistroAlterado);
            var swalObj = createSuccessSwal(msg.msg);

            swal(swalObj, function () {
                $state.go(url);
            });
        } else {
            var msg = clone(EnumMessages.Success.RegistroCadastradoIncluirNovo);
            var swalObj = createSuccessSwal(msg.msg);

            swalObj.confirmButtonText = "SIM";
            swalObj.cancelButtonText = "NÃO";
            swalObj.showCancelButton = true;

            swal(swalObj, function (confirm) {
                if (confirm) {
                    angular.element('button:reset').trigger('click');
                } else {
                    $state.go(url);
                }
            });
        }
    };

    //#region Private Methods

    function createSuccessSwal(msg) {
        return {
            title: EnumSwalTitle.Success,
            text: msg,
            type: EnumSwalType.Success,
            showCancelButton: false,
            closeOnConfirm: true
        };
    };

    function createSwalAlert(msg) {
        return {
            title: EnumSwalTitle.Alert,
            text: msg,
            type: EnumSwalType.Alert,
            confirmButtonText: "OK",
            closeOnConfirm: true
        }
    };

    function createSwalInfo(msg) {
        return {
            title: EnumSwalTitle.Info,
            text: msg,
            type: EnumSwalType.Info,
            confirmButtonText: "OK",
            showCancelButton: false,
            closeOnConfirm: true,
            confirmButtonCollor: "#3ba2c1"
        };
    };

    function createSwalError(msg) {
        return {
            title: EnumSwalTitle.Error,
            text: msg,
            type: EnumSwalType.Error,
            confirmButtonText: "OK",
            showCancelButton: false,
            closeOnConfirm: true
        };
    };

    function createSwalConfirm(msg) {
        return {
            title: EnumSwalTitle.Alert,
            text: msg,
            type: EnumSwalType.Alert,
            confirmButtonText: "SIM",
            cancelButtonText: "NÃO",
            showCancelButton: true,
            closeOnConfirm: true,
            confirmFunction: null,
            cancelFunction: null
        };
    };

    //#endregion
};
