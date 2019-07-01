$(document).ready(function(){
	/* Máscara dos campos */
	$('#Cpf').mask('000.000.000-00', {reverse: true});
	$('#Cep').mask('00.000-000', {reverse: true});
	$('#Telefone').mask('00 0000-0000', {reverse: true});
	$('#Celular').mask('00 00000-0000', {reverse: true});
	
	/* Preview da imagem */
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

    /* Validação dos campos */
    $('#Senha').keyup(function () {
        var senha = $('#Senha').val().length;

        if (senha >= 5) {
            $("#ConfirmarCadastroAluno").prop("disabled", false);
        } else {
            $("#ConfirmarCadastroAluno").prop("disabled", true);
        }
    });
});