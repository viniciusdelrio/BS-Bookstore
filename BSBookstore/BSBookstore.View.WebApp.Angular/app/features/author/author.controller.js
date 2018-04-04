angular.module('BSBookstore').controller('autorConsultaCtrl', autorConsultaCtrlFunction);

autorConsultaCtrlFunction.$inject = ['$scope', '$state', 'autorService'];

function autorConsultaCtrlFunction($scope, $state, autorService) {

    $scope.gridConsulta = {
        name: 'gridConsulta',
        datalist: autorService.listar,
        columns: [
            { field: 'name', displayName: "Nome"}
        ],
        events: {
            showEdit: function () {
                return true;
            },
            showDelete: function () {
                return true;
            },
            onEdit: function (row) {
                $state.go('cadastro.autor', { id: row.entity.id });
            }
        },
        exclude: {
            action: autorService.excluir,
            getMessage: function (msg, entity) {
                return msg.replaceParams(["do autor {0}"]).replaceParams([entity.name]);
            }
        }

    };

};

///////////////////////////////////////////////////////////////

angular.module('BSBookstore').controller('autorCadastroCtrl', autorCadastroCtrlFunction);

autorCadastroCtrlFunction.$inject = ['$scope', 'bsMessages', 'autorService', 'model'];

function autorCadastroCtrlFunction($scope, bsMessages, autorService, model) {

    var initial = {};

    if (model) {
        $scope.model = clone(model.data);
        $scope.isEdit = true;
    } else {
        $scope.model = clone(initial);
        $scope.isEdit = false;
    }

    function callbackSave() {
        bsMessages.showSaveSuccessMessage($scope.isEdit, 'consulta.autor');
    };

    $scope.salvar = function (isValid) {
        if (isValid) {
            autorService.salvar($scope.model, callbackSave);
        }
    };

    $scope.limpar = function () {
        $scope.model = clone(initial);
    };

};