$(document).ready(function () {
    $("#ExercicioTable").dataTable({
        "processing": true,
        "serverSide": true,
        "searching": false,
        "ajax": {
            "method": "POST",
            "dataType": "json",
            "url": "/Exercicio/GetAllExercicios",
        },
        "columns": [
            { "data": "idExercicio" },
            { "data": "nomeExercicio" },
            { "data": "aparelhoExercicio.nomeAparelho" },
        ],
        "columnDefs": [
            { "targets": 0, "className": 'idExercicio' },
            { "targets": 1, "className": 'nomeExercicio' },
            { "targets": -1, "className": 'aparelhoExercicio.nomeAparelho' },
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

    var table = $('#ExercicioTable').DataTable();

    $('#ExercicioTable tbody').on('click', 'tr', function () {
        if (!$(this).text().includes("Nenhum registro encontrado")) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
            }

            var idExercicio = $(this).find('td.idExercicio').text();
            $("#EditarExercicio").attr("href", "/Exercicio/Edit/" + idExercicio);
            $("#EditarExercicio").removeClass("isDisabled");

            $("#ExcluirExercicio").attr("href", "/Exercicio/Delete/" + idExercicio);
            $("#ExcluirExercicio").removeClass("isDisabled");
        }
    });

    $('#button').click(function () {
        table.row('.selected').remove().draw(false);
    });
});