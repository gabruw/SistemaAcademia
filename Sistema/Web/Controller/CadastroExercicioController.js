$(document).ready(function(){
	/* Datatable */
	$('#TableAparelho').DataTable({
		"responsive": true,
		"select": true,
		"bJQueryUI": true,
        "sPaginationType": "full_numbers",
		"sDom": '<"search-box"r><"H"lf>t<"F"ip>',
		"oLanguage": {
            "sLengthMenu": "Mostrar _MENU_ registros por página",
            "sZeroRecords": "Nenhum registro encontrado",
            "sInfo": "Mostrando _START_ / _END_ de _TOTAL_ registro(s)",
            "sInfoEmpty": "0 registros encontrados",
            "sInfoFiltered": "(filtrado de _MAX_ registros)",
            "sSearch": "Pesquisar: ",
            "oPaginate": {
                "sFirst": "Início",
                "sPrevious": "Anterior",
                "sNext": "Próximo",
                "sLast": "Último"
            }
        },
		"aaSorting": [[0, 'desc']],
        "aoColumnDefs": [
            {"sType": "num-html", "aTargets": [0]}
 
        ]
	});
	
	/* Captura dos campos e envio */
	$("#ConfirmarCadastroAluno").click(function(){
		var Nome = $('#Nome').val();
		
		var data = new FormData();
		data.append(Nome, Nome);
		
		$.ajax({
			url: "controller/CadastroAluno",
			type: 'POST',
			dataType: 'json',
			contentType: 'application/json',
			data: data,
			beforeSend: function(){
				
			},
			success: function(result) {
				if(result == 'ERRO'){
					alert("Campos incorretos.");
				}else{
					window.location.replace("Principal.html");
				}
			}
		});
	});
});