$(document).ready(function () {
    $("#AvaliacaoTable").dataTable({
        "processing": true,
        "serverSide": true,
        "searching": false,
        "ajax": {
            "method": "POST",
            "dataType": "json",
            "url": "/Avaliacao/GetAllAvaliacoes",
        },
        "columns": [
            { "data": "idAvaliacao" },
            { "data": "alunoAvaliacao.idAluno" },
            { "data": "professorAvaliacao.idProfessor" },
            { "data": "imc" },
            { "data": "percentualGordura" },
            { "data": "dataAvaliacao" },
        ],
        "columnDefs": [
            { "targets": 0, "className": 'idAvaliacao' },
            { "targets": 1, "className": 'alunoAvaliacao.idAluno' },
            { "targets": 2, "className": 'professorAvaliacao.idProfessor' },
            { "targets": 3, "className": 'imc' },
            { "targets": -1, "className": 'dataAvaliacao' },
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

    var table = $('#AvaliacaoTable').DataTable();

    $('#AvaliacaoTable tbody').on('click', 'tr', function () {
        if (!$(this).text().includes("Nenhum registro encontrado")) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
            }

            var idAvaliacao = $(this).find('td.idAvaliacao').text();
            $("#EditarAvaliacao").attr("href", "/Avaliacao/Edit/" + idAvaliacao);
            $("#EditarAvaliacao").removeClass("isDisabled");

            $("#ExcluirAvaliacao").attr("href", "/Avaliacao/Delete/" + idAvaliacao);
            $("#ExcluirAvaliacao").removeClass("isDisabled");
        }
    });

    $('#button').click(function () {
        table.row('.selected').remove().draw(false);
    });
});