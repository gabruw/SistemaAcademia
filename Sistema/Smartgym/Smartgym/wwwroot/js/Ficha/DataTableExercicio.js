$(document).ready(function () {
    $("#ExercicioTable").dataTable({
        "processing": true,
        "serverSide": true,
        "searching": false,
        "ajax": {
            "method": "POST",
            "dataType": "json",
            "url": "/Ficha/GetAllExercicios",
        },
        "columns": [
            { "data": "idExercicio" },
            { "data": "nomeExercicio" },
            { "data": "aparelhoExercicio.nomeAparelho" },
        ],
        "columnDefs": [
            { "targets": 0, "className": 'idExercicio' },
            { "targets": 1, "className": 'nomeExercicio' },
            { "targets": -1, "className": 'nomeAparelho' },
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

                $("#ConfirmarCadastroExercicioSerie").attr("disabled", true);
                $("#ExcluirExercicio").addClass("isDisabled");
            }
            else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');

                $("#ConfirmarCadastroExercicioSerie").attr("disabled", false);
                $("#ExcluirExercicio").removeClass("isDisabled");
            }

            var idExercicio = $(this).find('td.idExercicio').text();
            $("#IdExercicio").val(idExercicio);

            var nomeExercicio = $(this).find('td.nomeExercicio').text();
            $("#NomeExercicio").val(nomeExercicio);

            $("#ExcluirExercicio").attr("href", "/Exercicio/RemoveExercicio/" + idExercicio);
            $("#ExcluirExercicio").removeClass("isDisabled");

            $("#FormCadastroExercicio").attr("action", "/Ficha/CreateExercicio/" + idExercicio);
        }
    });

    $('#button').click(function () {
        table.row('.selected').remove().draw(false);
    });
});