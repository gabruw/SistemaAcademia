$(document).ready(function(){
	/* Máscara dos campos */
	$('#Cep').mask('00.000-000', {reverse: true});
	
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
});