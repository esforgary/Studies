<?php
	$name = $_POST['name'];
	$email = $_POST['email'];
	$pass = $_POST['password'];
	$pass2 = $_POST['password2'];

	if ($pass2 != $pass) {
		echo "Введите один и тот же пароль в оба поля для ввода пароля";
		exit();
	} else {
		$pass = $pass2;
	}

	if (mb_strlen($pass) < 8 || mb_strlen($pass) > 100) {
		echo "Пароль слишком короткий.";
	}

	$pass = md5($pass."12w5fgb877hyt54");

	$mysql = mysqli_connect('localhost', 'root', '', 'register-bd');
	$mysql -> query("INSERT INTO `users` (`name`, `email`, `password`)
					 VALUES('$name', '$email', '$pass')");

	mysqli_close($mysql);

	header('Location: index.php');
?>