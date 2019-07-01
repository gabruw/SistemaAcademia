$(document).ready(function () {
    $("#ProfessorTable").dataTable({
        "processing": true,
        "serverSide": true,
        "searching": false,
        "ajax": {
            "method": "POST",
            "dataType": "json",
            "url": "/Professor/GetAllProfessores",
        },
        "columns": [
            { "data": "idProfessor" },
            { "data": "crefProfessor" },
            { "data": "nomeProfessor" },
            { "data": "cpfProfessor" },
        ],
        "columnDefs": [
            { "targets": 0, "className": 'idProfessor' },
            { "targets": 1, "className": 'crefProfessor' },
            { "targets": 2, "className": 'nomeProfessor' },
            { "targets": -1, "className": 'cpfProfessor' },
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

    var table = $('#ProfessorTable').DataTable();

    $('#ProfessorTable tbody').on('click', 'tr', function () {
        if (!$(this).text().includes("Nenhum registro encontrado")) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
            }

            var idProfessor = $(this).find('td.idProfessor').text();
            $("#EditarProfessor").attr("href", "/Professor/Edit/" + idProfessor);
            $("#EditarProfessor").removeClass("isDisabled");

            $("#ExcluirProfessor").attr("href", "/Professor/Delete/" + idProfessor);
            $("#ExcluirProfessor").removeClass("isDisabled");
        }
    });

    $('#button').click(function () {
        table.row('.selected').remove().draw(false);
    });
});