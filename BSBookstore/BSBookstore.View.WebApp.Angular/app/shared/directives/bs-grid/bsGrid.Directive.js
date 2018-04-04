var EnumOnOff = {
    Online: 'online',
    Offline: 'offline'
};

angular.module('BSBookstore').directive('bsGrid', bsGridDirective);

bsGridDirective.$inject = ['$timeout', 'bsMessages', 'linqHelper'];

function bsGridDirective($timeout, bsMessages, linqHelper) {
    return {
        restrict: 'E',
        scope: {
            type: '@?',
            model: '=ngModel',
            content: '='
        },
        controller: function ($scope, $element) {

            //#region Constants

            var ROW_HEIGHT = '45';

            var USE_PAGINATION = true;
            var PAGINATION_PAGE_SIZE = [10, 25, 50];
            var PAGINATION_DIRECTIVE = "ui-grid-pagination";

            var USE_FILTERING = true;

            //#endregion

            var grid = $scope.content;

            //#region Set Default Values

            grid.rowHeight = ROW_HEIGHT;

            if ($scope.type == undefined) {
                $scope.type = EnumOnOff.Online;
            }

            if (USE_PAGINATION) {
                if (!grid.pagination) {
                    grid.pagination = {};
                }

                if (!grid.pagination.pageSize) {
                    grid.pagination.pageSize = PAGINATION_PAGE_SIZE;
                }

                grid.paginationPageSizes = grid.pagination.pageSize;
            }

            grid.enableFiltering = true;

            if (grid.columns) {
                grid.columnDefs = grid.columns;

                if (grid.events && (grid.events.showEdit || grid.events.showDelete)) {
                    grid.columnDefs.unshift({
                        field: 'Id',
                        displayName: '',
                        width: grid.events.showEdit && grid.events.showDelete ? "10%" : "5%",
                        cellTemplate: "app/shared/html/grid-buttons/editAndDeleteButtons.html",
                        enableFiltering: false,
                        enableSorting: false,
                        enableHiding: false
                    });
                }
            }

            if (!grid.events) {
                grid.events = {};
            }

            if (!grid.exclude) {
                grid.exclude = {};
            }

            if (!grid.events.onDelete) {
                grid.events.onDelete = onDelete;
            }

            if (isOffline()) {
                grid.data = $scope.model;
            } else {
                update();
            }

            grid.onRegisterApi = function (gridApi) {
                grid.gridApi = gridApi;
            };

            grid.appScopeProvider = grid.events;

            //#endregion

            //#region Public Methods

            grid.setModel = function (model) {
                $timeout(function () {
                    $scope.model = model;
                    grid.gridApi.grid.options.data = linqHelper.whereWithoutDeleted($scope.model);
                }, 150);
            };

            grid.update = function () {
                update();
            };

            //#endregion

            //#region Private Methods

            function update() {
                grid.datalist().then(function (result) {
                    grid.data = result.data;

                    if (grid.gridApi) {
                        grid.gridApi.core.refresh();
                    }
                });
            };

            //#region Callbacks

            function deleteSuccessCallback() {

                $timeout(function () {

                    if (isOffline()) {
                        $scope.model.splice($scope.i, 1);
                        grid.setModel($scope.model);
                    } else {
                        grid.update();
                    }

                    var successMsg = clone(EnumMessages.Success.RegistroExcluido);
                    bsMessages.showMessage(successMsg);

                    if (grid.events && grid.events.onAfterDelete) {
                        grid.events.onAfterDelete();
                    }

                }, 100);

            };

            //#endregion

            //#region Default Events

            function onDelete(row) {
                for (var i = 0; i < row.grid.options.data.length; i++) {
                    var cData = row.grid.options.data[i];
                    if (cData.$$hashKey == row.entity.$$hashKey) {
                        if (row.entity.id) {

                            if (grid.exclude.action) {
                                var message = clone(EnumMessages.Alert.ConfirmaExclusao);
                                message.msg = grid.exclude.getMessage ? grid.exclude.getMessage(message.msg, row.entity) : (message.msg.replaceParams(['do registro']));

                                bsMessages.showMessage(message, EnumSwalType.Confirm, function () {

                                    $scope.i = i;

                                    grid.exclude.action(row.entity.id, deleteSuccessCallback);
                                });
                            } else {
                                var message = clone(EnumMessages.Alert.NaoExisteMetodoExclusao);
                                bsMessages.showMessage(message);
                            }

                        } else {

                            var message = clone(EnumMessages.Alert.ConfirmaExclusao);
                            message.msg = grid.exclude.getMessage ? grid.exclude.getMessage(message.msg, row.entity) : (message.msg.replaceParams(['do registro']));

                            bsMessages.showMessage(message, EnumSwalType.Confirm, function () {

                                var index = 0;

                                linqHelper.where($scope.model, function (w) {
                                    if (w.$$hashKey == row.entity.$$hashKey) {
                                        index = $scope.model.indexOf(w);
                                    }
                                });

                                $scope.model.splice(index, 1);
                                grid.setModel($scope.model);

                                if ($scope.grid.events.onAfterDelete) {
                                    $scope.grid.events.onAfterDelete();
                                }

                            });

                        }

                        break;
                    }
                }
            };

            //#endregion

            //#region Helpers

            function isOffline() {
                return $scope.type == EnumOnOff.Offline;
            };

            //#endregion

            //#region Create UI Grid

            function createGrid() {
                var $div = $('<div ui-grid="' + $scope.content.name + '" '
                    + 'id="' + $scope.content.name + '" '
                    + (USE_PAGINATION ? PAGINATION_DIRECTIVE : '')
                    + '></div>');

                $element.html($div);

                if (angular.element($element).injector()) {
                    angular.element($element).injector().invoke(function ($compile) {
                        var scope = angular.element($div).scope();
                        if (scope)
                            $compile($div)(scope);
                    });
                } else {
                    var scope = angular.element($div).scope();
                    if (scope)
                        $compile($div)(scope);
                }
            };

            //#endregion

            //#endregion

            createGrid();
        }
    };
}
