$(document).ready(function () {
    window.alert = function () { }

    var idFicha = "";

    $("#ConfirmarCadastroFicha").click(function () {
        var idAluno = $("#Aluno").val();
        var idProfessor = $("#Professor").val();

        $.ajax({
            method: "POST",
            url: "/Ficha/Create",
            dataType: "text",
            data: {
                idAluno: idAluno,
                idProfessor: idProfessor,
            },
            success: function (result) {
                idFicha = result;

                $("#Aluno").attr("disabled", true);
                $("#Professor").attr("disabled", true);
                $("#ConfirmarCadastroFicha").attr("disabled", true);

                $("#ConfirmarCadastroSerie").attr("disabled", false);
            },
        });
    });
    
    var idSerie = "";
    var nomeSerie = "";
    var repeticoesSerie = "";
    var observacoesSerie = "";
    var tabelaExercicio = "";
    $("#ConfirmarCadastroSerie").click(function () {
        nomeSerie = $("#NomeSerie").val();
        repeticoesSerie = $("#RepeticoesSerie").val();
        observacoesSerie = $("#ObservacoesSerie").val();

        $.ajax({
            method: "POST",
            url: "/Ficha/CreateSerie",
            dataType: "text",
            data: {
                idFicha: idFicha,
                nomeSerie: nomeSerie,
                repeticoesSerie: repeticoesSerie,
                observacoesSerie: observacoesSerie,
            },
            success: function (result) {
                idSerie = result;

                $("#NomeSerie").attr("disabled", true);
                $("#RepeticoesSerie").attr("disabled", true);
                $("#ObservacoesSerie").attr("disabled", true);
                $("#ConfirmarCadastroSerie").attr("disabled", true);

                // Série
                var tabelaSerie = "<tr data-target='#ExerciciosTable" + idSerie + "' data-toggle='collapse'>";
                tabelaSerie += "<td>" + idSerie + "</td>";
                tabelaSerie += "<td>" + nomeSerie + "</td>";
                tabelaSerie += "<td>" + repeticoesSerie + "</td>";
                tabelaSerie += "</tr>";

                $("#BodySeriesTable").append(tabelaSerie);

                // Exercício
                tabelaExercicio = "<div id='ExerciciosTable" + idSerie + "' class='card-body table-responsive collapse'>";
                tabelaExercicio += "<table id='Table" + idSerie + "' class='table table-hover table-valign-middle table-bordered'>";

                tabelaExercicio += "<thead class='Thead" + idSerie + "'>";

                tabelaExercicio += "<tr>";
                tabelaExercicio += "<th>Id</th>";
                tabelaExercicio += "<th>Exercício</th>";
                tabelaExercicio += "<th>Aparelho</th>";
                tabelaExercicio += "<th>Repetições</th>";
                tabelaExercicio += "</tr>";

                tabelaExercicio += "</thead>";

                tabelaExercicio += "</table>";
                tabelaExercicio += "</div>";

                $("#ExerciciosTable").append(tabelaExercicio);
            },
        });
    });


    $("#ConfirmarCadastroExercicioSerie").click(function () {
        var idExercicio = $("#IdExercicio").val();
        var repeticoesExercicio = $("#RepeticoesExercicio").val();

        $.ajax({
            method: "POST",
            url: "/Ficha/CreateExercicio",
            dataType: "text",
            data: {
                idExercicio: idExercicio,
                idSerie: idSerie,
                repeticoesExercicio: repeticoesExercicio,
            },
            success: function (result) {
                $("#NomeSerie").attr("disabled", false);
                $("#RepeticoesSerie").attr("disabled", false);
                $("#ObservacoesSerie").attr("disabled", false);
                $("#ConfirmarCadastroSerie").attr("disabled", false);

                $.ajax({
                    method: "POST",
                    url: "/Ficha/GetAllExerciciosSerieBySerie",
                    dataType: "json",
                    data: {
                        idSerie: idSerie,
                    },
                    success: function (result) {
                        var linhasTabelaExercicio = "";

                        $(result).each(function (index, element) {
                            linhasTabelaExercicio += "<tbody>";
                            linhasTabelaExercicio += "<tr>";
                            linhasTabelaExercicio += "<td>" + element.exercicioExercicioSerie.idExercicio + "</td>";
                            linhasTabelaExercicio += "<td>" + element.exercicioExercicioSerie.nomeExercicio + "</td>";
                            linhasTabelaExercicio += "<td>" + element.exercicioExercicioSerie.aparelhoExercicio.nomeAparelho + "</td>";
                            linhasTabelaExercicio += "<td>" + element.repeticoesExercicioSerie + "</td>";
                            linhasTabelaExercicio += "</tr>";
                            linhasTabelaExercicio += "</tbody>";
                        });

                        $("#Table" + idSerie).find('tbody').each(function () {
                            alert(this.innerText);
                        });

                        $("#Table" + idSerie +" tbody").empty();
                        $(linhasTabelaExercicio).insertAfter(".Thead" + idSerie);
                    },
                });
            },
        });
    });
});