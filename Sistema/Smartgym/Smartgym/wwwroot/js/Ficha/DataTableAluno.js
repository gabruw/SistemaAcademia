$(document).ready(function () {
    $("#FichaTable").dataTable({
        "processing": true,
        "serverSide": true,
        "searching": false,
        "ajax": {
            "method": "POST",
            "dataType": "json",
            "url": "/Ficha/GetAllFichas",
        },
        "columns": [
            { "data": "idFicha" },
            { "data": "alunoFicha.matriculaAluno" },
            { "data": "alunoFicha.nomeAluno" },
            { "data": "professorFicha.crefProfessor" },
            { "data": "professorFicha.nomeProfessor" },
        ],
        "columnDefs": [
            { "targets": 0, "className": 'idFicha' },
            { "targets": 1, "className": 'matriculaAluno' },
            { "targets": 2, "className": 'nomeAluno' },
            { "targets": 3, "className": 'crefProfessor' },
            { "targets": -1, "className": 'nomeProfessor' },
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

    var table = $('#FichaTable').DataTable();

    $('#FichaTable tbody').on('click', 'tr', function () {
        if (!$(this).text().includes("Nenhum registro encontrado")) {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
            }

            var idFicha = $(this).find('td.idFicha').text();
            $("#EditarFicha").attr("href", "/Ficha/Edit/" + idFicha);
            $("#EditarFicha").removeClass("isDisabled");

            $("#ExcluirFicha").attr("href", "/Ficha/Delete/" + idFicha);
            $("#ExcluirFicha").removeClass("isDisabled");
        }
    });

    $('#button').click(function () {
        table.row('.selected').remove().draw(false);
    });
});