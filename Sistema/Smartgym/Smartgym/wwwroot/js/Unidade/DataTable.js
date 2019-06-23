$(document).ready(function () {
    $("#UnidadeTable").dataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "method": "POST",
            "dataType": "json",
            "url": "/Unidade/GetAllUnidades",
        },
        "columns": [
            { "data": "idUnidade" },
            { "data": "nomeUnidade" },
        ],
        "columnDefs": [
            { "targets": 0, "className": 'idUnidade' },
            { "targets": -1, "className": 'nomeUnidade' },
        ],
        "language": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar:",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            },
        },
        "ordering": true,
        "paging": true,
        "pagingType": "full_numbers",
        "pageLength": 3
    });

    $("label").addClass("ls-label-text");
    $("td:contains('SuperSweet')").addClass("ls-label-text");
    $(".dataTables_info").addClass("ls-label-text");

    var table = $('#UnidadeTable').DataTable();

    $('#UnidadeTable tbody').on('click', 'tr', function () {
        if (!$(this).text().includes("Nenhum registro encontrado")) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
            }

            var idUnidade = $(this).find('td.idUnidade').text();
            $("#EditarUnidade").attr("href", "/Unidade/Edit/" + idUnidade);
            $("#EditarUnidade").removeClass("isDisabled");

            $("#ExcluirUnidade").attr("href", "/Unidade/Delete/" + idUnidade);
            $("#ExcluirUnidade").removeClass("isDisabled");
        }
    });

    $('#button').click(function () {
        table.row('.selected').remove().draw(false);
    });
});