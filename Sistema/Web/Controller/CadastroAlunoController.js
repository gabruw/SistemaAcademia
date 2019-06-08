$(document).ready(function(){
	/* Máscara dos campos */
	$('#Cpf').mask('000.000.000-00', {reverse: true});
	$('#DataNascimento').mask('00/00/00', {reverse: true});
	$('#Rg').mask('00-00.000.000', {reverse: true});
	$('#Telefone').mask('(00)0000-0000', {reverse: true});
	$('#Celular').mask('(00)00000-0000', {reverse: true});
	
	/* Preview da Imagem */
	function PreviewImagem(input) {
		var Imagem = input.files[0];
		if (Imagem != null) {
			var reader = new FileReader();
			
			reader.onload = function(e) {
				$('#ImagemPreview').attr('src', e.target.result);
			}
			
			reader.readAsDataURL(Imagem);
		}
	}

	$("#ImagemPerfil").change(function() {
		PreviewImagem(this);
	});
	
	/* Captura dos campos e envio */
	$("#ConfirmarCadastroAluno").click(function(){
		var NomeCompleto = $('#NomeCompleto').val();
		var Email = $('#Email').val();
		var Rua = $('#Rua').val();
		var Bairro = $('#Bairro').val();
		var Numero = $('#Numero').val();
		var Complemento = $('#Complemento').val();
		var Telefone = $('#Telefone').val();
		var Celular = $('#Celular').val();
		var Sexo = $('input:radio[name=Sexo]:checked').val();
		var DataNascimento = $('#DataNascimento').val();
		var Cpf = $('#Cpf').val();
		var Rg = $('#Rg').val();
		var ImagemPerfil = $('#ImagemPreview').attr("src");
		
		var data = new FormData();
		data.append(NomeCompleto, NomeCompleto);
		data.append(Email, Email);
		data.append(Rua, Rua);
		data.append(Bairro, Bairro);
		data.append(Numero, Numero);
		data.append(Complemento, Complemento);
		data.append(Telefone, Telefone);
		data.append(Celular, Celular);
		data.append(Sexo, Sexo);
		data.append(DataNascimento, DataNascimento);
		data.append(Cpf, Cpf);
		data.append(Rg, Rg);
		data.append(ImagemPerfil, ImagemPerfil);
		
		$.ajax({
			url: "http://localhost:8080/aluno",
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