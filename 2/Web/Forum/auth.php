<?php 
	$email = $_POST['email'];
	$pass = $_POST['password'];

	$pass = md5($pass."12w5fgb877hyt54");

	$mysql = mysqli_connect('localhost', 'root', '', 'register-bd');
	
	$result = $mysql -> query("SELECT * FROM `users`
		                       WHERE `email` = '$email' AND `password` = '$pass'");
	$user = $result->fetch_assoc();
	if(count($user) == 0) {
		print "Пользователь не найден";
		exit();
	}

	setcookie('user', $user['name'], time() + 3600, "/");
	
	mysqli_close($mysql);

	header('Location: index.php');
?>