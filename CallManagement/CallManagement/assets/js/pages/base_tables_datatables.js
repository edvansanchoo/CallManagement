/*
 *  Document   : base_tables_datatables.js
 *  Author     : Jabil UX Design
 *  Description: Custom JS code used in Tables Datatables Page
 */

var BaseTableDatatables = function() {
    // Init full DataTable, for more examples you can check out https://www.datatables.net/
    var initDataTableFull = function() {
        jQuery('.js-dataTable-full').dataTable({
            //columnDefs: [ { orderable: false, targets: [ 4 ] } ],
            pageLength: 5,
            lengthMenu: [[5, 10, 15, 20], [5, 10, 15, 20]]
        });
    };

    // Init full extra DataTable, for more examples you can check out https://www.datatables.net/
    var initDataTableFullPagination = function() {
        jQuery('.js-dataTable-full-pagination').dataTable({
            pagingType: "full_numbers",
            pageLength: 10,
            lengthMenu: [[5, 10, 15, 20, 50, 100, 500, 1000], [5, 10, 15, 20, 50, 100, 500, 1000]]
        });
    };

    var initDataTableFullPaginationMarcacao = function () {
        jQuery('.js-dataTable-full-paginationMarcacao').dataTable({
            ordering: false,
            //fixedHeader: true,
            scrollX: true,
            scrollY: "400px",
            scrollCollapse: true,
            pagingType: "full_numbers",
            pageLength: 10,
            lengthMenu: [[5, 10, 15, 20], [5, 10, 15, 20]],
            columnDefs: [
                { width: 50, targets: 0 },
                { width: 100, targets: 1 },
                { width: 10, targets: 2 },
                { width: 130, targets: 8 },
                { width: 130, targets: 9 },
                { width: 110, targets: 10 },
                { width: 120, targets: 11 }
                //{
                //    targets: 'no-sort',
                //    orderable: false
                //}
            ],
            dom: "B<'row'><'row'<'col-md-6'l><'col-md-6'f>r>t<'row'<'col-md-4'i>><'row'<'#colvis'>p>",
            buttons: [
                {
                    extend: 'excel',
                    className: 'btn btn-success'
                },
                {
                    extend: 'pdf',
                    title: 'JHR \n Relatorio De Marcacoes dos Colaboradores (' + dataAtualFormatada() + ')',
                    className: 'btn btn-primary btn_pdf',
                    customize: function (doc) {
                        var font = "8";
                        doc.content[1].table.widths =
                        [
                            '10%',
                            '20%',
                            '12%',
                            '6%',
                            '7%',
                            '7%',
                            '7%',
                            '7%',
                            '7%',
                            '7%',
                            '7%',
                            '7%'
                        ]

                        doc.styles.title = {
                            color: 'black',
                            fontSize: "12",
                            //background: 'blue',
                            alignment: 'center',
                            fontFamily: "arial"
                        }

                        doc.styles.tableHeader = {
                            color: 'white',
                            fontSize: 8,
                            fillColor: '#2d4154',
                            alignment: 'center',
                            fontFamily: "arial",
                            bold : true
                        }

                        doc.styles.tableBodyOdd = {
                            //color: 'black',
                            fontSize: font,
                            //background: 'blue',
                            alignment: 'left',
                            fontFamily: "arial"
                        }

                        doc.styles.tableBodyEven = {
                            //color: 'black',
                            fontSize: font,
                            //background: 'blue',
                            alignment: 'left',
                            fontFamily: "arial"
                        }

                        console.log(doc);

                        doc['footer'] = (function (page, pages) {
                            return {
                                columns: [
                                    //'This is your left footer column',
                                    {
                                        // This is the right column
                                        alignment: 'right',
                                        text: ['page ', { text: page.toString() }, ' of ', { text: pages.toString() }]
                                    }
                                ],
                                margin: [10, 0]
                            }
                        });
                        
                    }
                }
            ]
            
        });
    };

    var initDataTableFullPaginationHE = function () {
        jQuery('.js-dataTable-full-paginationHE').dataTable({
            scrollX: true,
            scrollY: "400px",
            scrollCollapse: true,
            pagingType: "full_numbers",
            pageLength: 10,
            lengthMenu: [[5, 10, 15, 20, 50, 100, 500, 1000], [5, 10, 15, 20, 50, 100, 500, 1000]],
            columnDefs: [
                { width: 80, targets: 0 },
                { width: 100, targets: 1 },
                { width: 80, targets: 2 },
                { width: 100, targets: 3 },
                { width: 100, targets: 4 },
                { width: 120, targets: 5 },
                { width: 100, targets: 6 },
                { width: 100, targets: 7 },
                { width: 200, targets: 8 }
            ],
            dom: "B<'row'><'row'<'col-md-6'l><'col-md-6'f>r>t<'row'<'col-md-4'i>><'row'<'#colvis'>p>",
            buttons: [
                {
                    extend: 'excel',
                    className: 'btn btn-success'
                },
                {
                    extend: 'pdf',
                    className: 'btn btn-primary btn_pdf',
                    title: 'JHR \n Relatorio Hora Extra',
                    customize: function (doc) {
                        doc.styles.title = {
                            color: 'black',
                            fontSize: '20',
                            //background: 'blue',
                            alignment: 'center'
                        }
                    }
                }
            ]
        });
    };

    var initDataTableFullPaginationRRColabMin = function () {
        jQuery('.js-dataTable-full-paginationRRColabMin').dataTable({
            pagingType: "full_numbers",
            pageLength: 10,
            lengthMenu: [[5, 10, 15, 20, 50, 100, 500, 1000], [5, 10, 15, 20, 50, 100, 500, 1000]],
            columnDefs: [
                { width: 100, targets: 0 },
                { width: 100, targets: 1 },
                { width: 100, targets: 2 },
                { width: 100, targets: 3 },
                { width: 100, targets: 4 },
                { width: 100, targets: 5 },
                { width: 100, targets: 6 },
                {
                    targets: 'no-sort',
                    orderable: false
                }
            ],
            scrollX: true,
            scrollY: "400px",
            scrollCollapse: true,
            dom: "B<'row'><'row'<'col-md-6'l><'col-md-6'f>r>t<'row'<'col-md-4'i>><'row'<'#colvis'>p>",
            buttons: [
                {
                    extend: 'excel',
                    className: 'btn btn-success'
                },
                {
                    extend: 'pdf',
                    className: 'btn btn-primary btn_pdf',
                    title: 'JHR \n Colaboradores que marcaram ponto e ainda permaneceram na empresa (minutos)',
                    customize: function (doc) {
                        doc.styles.title = {
                            color: 'black',
                            fontSize: '20',
                            //background: 'blue',
                            alignment: 'center'
                        }
                    }
                }
            ]
            
        });
    };

    var initDataTableFullPaginationRRColabAcesso = function () {
        jQuery('.js-dataTable-full-paginationRRColabAcesso').dataTable({
            scrollX: true,
            scrollY: "400px",
            scrollCollapse: true,
            dom: "B<'row'><'row'<'col-md-6'l><'col-md-6'f>r>t<'row'<'col-md-4'i>><'row'<'#colvis'>p>",
            buttons: [
                {
                    extend: 'excel',
                    className: 'btn btn-success'
                },
                {
                    extend: 'pdf',
                    className: 'btn btn-primary btn_pdf',
                    title: 'JHR \n Colaboradores que marcaram ponto e permaneceram na empresa acima de 10 horas',
                    customize: function (doc) {
                        doc.styles.title = {
                            color: 'black',
                            fontSize: '20',
                            //background: 'blue',
                            alignment: 'center'
                        }
                    }

                }
            ],
            pagingType: "full_numbers",
            pageLength: 10,
            lengthMenu: [[5, 10, 15, 20, 50, 100, 500, 1000], [5, 10, 15, 20, 50, 100, 500, 1000]],
            columnDefs: [
                { width: 100, targets: 0 },
                { width: 100, targets: 1 },
                { width: 100, targets: 2 },
                { width: 100, targets: 3 },
                { width: 100, targets: 4 },
                { width: 100, targets: 5 },
                { width: 100, targets: 6 },
                {
                    targets: 'no-sort',
                    orderable: false
                }
            ],
        });
    };

    

    var initDataTableFullPaginationRRColabPonto = function () {
        jQuery('.js-dataTable-full-paginationRRColabPonto').dataTable({
            //ordering: false,
            scrollX: true,
            scrollY: "400px",
            scrollCollapse: true,
            dom: "B<'row'><'row'<'col-md-6'l><'col-md-6'f>r>t<'row'<'col-md-4'i>><'row'<'#colvis'>p>",
            buttons: [
                {
                    extend: 'excel',
                    className: 'btn btn-success'
                },
                {
                    extend: 'pdf',
                    className: 'btn btn-primary btn_pdf',
                    title: 'JHR \n Colaboradores que possuem jornada de trabalho acima de 10 horas',
                    customize: function (doc) {
                        doc.styles.title = {
                            color: 'black',
                            fontSize: '20',
                            //background: 'blue',
                            alignment: 'center'
                        }
                    }

                }
            ],
            pagingType: "full_numbers",
            pageLength: 10,
            lengthMenu: [[5, 10, 15, 20, 50, 100, 500, 1000], [5, 10, 15, 20, 50, 100, 500, 1000]],
            columnDefs: [
                { width: 100, targets: 0 },
                { width: 100, targets: 1 },
                { width: 100, targets: 2 },
                { width: 100, targets: 3 },
                { width: 100, targets: 4 },
                { width: 100, targets: 5 },
                { width: 100, targets: 6 },
                {
                    targets: 'no-sort',
                    orderable: false
                }
            ]
        });
    };

    var initDataTableFullPaginationExcell = function () {
        jQuery('.js-dataTable-full-paginationExcell').dataTable({
            pagingType: "full_numbers",
            pageLength: 10,
            lengthMenu: [[5, 10, 15, 20, 50, 100, 500, 1000], [5, 10, 15, 20, 50, 100, 500, 1000]],
            dom: "B<'row'><'row'<'col-md-6'l><'col-md-6'f>r>t<'row'<'col-md-4'i>><'row'<'#colvis'>p>",
            buttons: [
                {
                    extend: 'excel',
                    className: 'btn btn-success',
                    exportOptions: {
                        columns: [0, 1, 2,3,4,5,6,7, 8, 9]
                    }
                }
            ]
            //columnDefs: [
            //    { targets: 8, visible: false }
            //],
        });
    };

    var initDataTableFullPaginationExcellTHE = function () {
        jQuery('.js-dataTable-full-paginationExcellTHE').dataTable({
            pagingType: "full_numbers",
            pageLength: 10,
            lengthMenu: [[5, 10, 15, 20, 50, 100, 500, 1000], [5, 10, 15, 20, 50, 100, 500, 1000]],
            dom: "B<'row'><'row'<'col-md-6'l><'col-md-6'f>r>t<'row'<'col-md-4'i>><'row'<'#colvis'>p>",
            buttons: [
                {
                    title: 'Relatorio Hora Extra',
                    extend: 'excel',
                    className: 'btn btn-success'
                }
            ]
        });
    };

    var initDataTableFullPaginationExcellSimple = function () {
        jQuery('.js-dataTable-full-paginationExcellSimple').dataTable({
            ordering: false,
            pagingType: "full_numbers",
            pageLength: 10,
            lengthMenu: [[5, 10, 15, 20, 50, 100, 500, 1000], [5, 10, 15, 20, 50, 100, 500, 1000]],
            dom: "B<'row'><'row'<'col-md-6'l><'col-md-6'f>r>t<'row'<'col-md-4'i>><'row'<'#colvis'>p>",
            buttons: [
                {
                    title: 'Relatorio',
                    extend: 'excel',
                    className: 'btn btn-success'
                }
            ]
        });
    };


    // Init simple DataTable, for more examples you can check out https://www.datatables.net/
    var initDataTableSimple = function ()
    {
        jQuery('.js-dataTable-simple').dataTable({
            columnDefs: [ { orderable: false, targets: [ 4 ] } ],
            pageLength: 10,
            lengthMenu: [[5, 10, 15, 20], [5, 10, 15, 20]],
            searching: false,
            oLanguage:
            {
                sLengthMenu: ""
            },
            dom:
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-6'i><'col-sm-6'p>>"
        });
    };

    // DataTables Bootstrap integration
    var bsDataTables = function() {
        var $DataTable = jQuery.fn.dataTable;

        // Set the defaults for DataTables init
        jQuery.extend( true, $DataTable.defaults, {
            dom:
                "<'row'<'col-sm-6'l><'col-sm-6'f>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-6'i><'col-sm-6'p>>",
            renderer: 'bootstrap',
            oLanguage: {
                sLengthMenu: "_MENU_",
                sInfo: "Showing <strong>_START_</strong>-<strong>_END_</strong> of <strong>_TOTAL_</strong>",
                oPaginate: {
                    sPrevious: '<i class="fa fa-angle-left"></i>',
                    sNext: '<i class="fa fa-angle-right"></i>'
                }
            }
        });

        // Default class modification
        jQuery.extend($DataTable.ext.classes, {
            sWrapper: "dataTables_wrapper form-inline dt-bootstrap",
            sFilterInput: "form-control",
            sLengthSelect: "form-control"
        });

        // Bootstrap paging button renderer
        $DataTable.ext.renderer.pageButton.bootstrap = function (settings, host, idx, buttons, page, pages) {
            var api     = new $DataTable.Api(settings);
            var classes = settings.oClasses;
            var lang    = settings.oLanguage.oPaginate;
            var btnDisplay, btnClass;

            var attach = function (container, buttons) {
                var i, ien, node, button;
                var clickHandler = function (e) {
                    e.preventDefault();
                    if (!jQuery(e.currentTarget).hasClass('disabled')) {
                        api.page(e.data.action).draw(false);
                    }
                };

                for (i = 0, ien = buttons.length; i < ien; i++) {
                    button = buttons[i];

                    if (jQuery.isArray(button)) {
                        attach(container, button);
                    }
                    else {
                        btnDisplay = '';
                        btnClass = '';

                        switch (button) {
                            case 'ellipsis':
                                btnDisplay = '&hellip;';
                                btnClass = 'disabled';
                                break;

                            case 'first':
                                btnDisplay = lang.sFirst;
                                btnClass = button + (page > 0 ? '' : ' disabled');
                                break;

                            case 'previous':
                                btnDisplay = lang.sPrevious;
                                btnClass = button + (page > 0 ? '' : ' disabled');
                                break;

                            case 'next':
                                btnDisplay = lang.sNext;
                                btnClass = button + (page < pages - 1 ? '' : ' disabled');
                                break;

                            case 'last':
                                btnDisplay = lang.sLast;
                                btnClass = button + (page < pages - 1 ? '' : ' disabled');
                                break;

                            default:
                                btnDisplay = button + 1;
                                btnClass = page === button ?
                                        'active' : '';
                                break;
                        }

                        if (btnDisplay) {
                            node = jQuery('<li>', {
                                'class': classes.sPageButton + ' ' + btnClass,
                                'aria-controls': settings.sTableId,
                                'tabindex': settings.iTabIndex,
                                'id': idx === 0 && typeof button === 'string' ?
                                        settings.sTableId + '_' + button :
                                        null
                            })
                            .append(jQuery('<a>', {
                                    'href': '#'
                                })
                                .html(btnDisplay)
                            )
                            .appendTo(container);

                            settings.oApi._fnBindAction(
                                node, {action: button}, clickHandler
                            );
                        }
                    }
                }
            };

            attach(
                jQuery(host).empty().html('<ul class="pagination"/>').children('ul'),
                buttons
            );
        };

        // TableTools Bootstrap compatibility - Required TableTools 2.1+
        if ($DataTable.TableTools) {
            // Set the classes that TableTools uses to something suitable for Bootstrap
            jQuery.extend(true, $DataTable.TableTools.classes, {
                "container": "DTTT btn-group",
                "buttons": {
                    "normal": "btn btn-default",
                    "disabled": "disabled"
                },
                "collection": {
                    "container": "DTTT_dropdown dropdown-menu",
                    "buttons": {
                        "normal": "",
                        "disabled": "disabled"
                    }
                },
                "print": {
                    "info": "DTTT_print_info"
                },
                "select": {
                    "row": "active"
                }
            });

            // Have the collection use a bootstrap compatible drop down
            jQuery.extend(true, $DataTable.TableTools.DEFAULTS.oTags, {
                "collection": {
                    "container": "ul",
                    "button": "li",
                    "liner": "a"
                }
            });
        }
    };

    return {
        init: function() {
            // Init Datatables
            bsDataTables();
            initDataTableSimple();
            initDataTableFull();
            initDataTableFullPagination();
            initDataTableFullPaginationMarcacao();
            initDataTableFullPaginationHE();
            initDataTableFullPaginationRRColabAcesso();
            initDataTableFullPaginationRRColabMin();
            initDataTableFullPaginationRRColabPonto();
            initDataTableFullPaginationExcell();
            initDataTableFullPaginationExcellTHE();
            initDataTableFullPaginationExcellSimple();
        }
    };
}();

function dataAtualFormatada() {
    var data = new Date();
    var dia = data.getDate();
    if (dia.toString().length == 1)
        dia = "0" + dia;
    var mes = data.getMonth() + 1;
    if (mes.toString().length == 1)
        mes = "0" + mes;
    var ano = data.getFullYear();
    return dia + "/" + mes + "/" + ano;
}

// Initialize when page loads
jQuery(function(){ BaseTableDatatables.init(); });