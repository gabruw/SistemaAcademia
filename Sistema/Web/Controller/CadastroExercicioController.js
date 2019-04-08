$(document).ready(function(){
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