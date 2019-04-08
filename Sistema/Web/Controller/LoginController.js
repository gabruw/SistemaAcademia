/* Captura dos campos e envio */
$(document).ready(function(){
	$("#Login").click(function(){
		var Email = $('#Email').val();
		var Password = $('#Password').val();
		
		var data = new FormData();
		data.append(Password, Password);
		data.append(Email, Email);
		
		$.ajax({
			url: "controller/Login",
			type: 'POST',
			dataType: 'json',
			contentType: 'application/json',
			data: data,
			beforeSend: function(){
				
			},
			success: function(result) {
				if(result == 'ERRO'){
					alert("Login ou senha incorretos.");
				}else{
					window.location.replace("Principal.html");
				}
			}
		});
	});
});