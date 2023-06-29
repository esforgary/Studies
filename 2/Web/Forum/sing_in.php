<!DOCTYPE html>
<html lang="ru">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">	
	<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css">
	<link rel="stylesheet" href="css/form_style.css">
	<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js"></script>
	<title>Document</title>
</head>
<body>
   <div class="container col-xl-10 col-xxl-8 px-4 py-5 mt-5">
    <div class="row align-items-center g-lg-5 py-5">
      <div class="col-lg-7 text-center text-lg-start">
        <h1 class="display-4 fw-bold lh-1 mb-3">Войти в аккаунт</h1>
        <p class="col-lg-10 fs-4">Добро пожаловать на наш сайт. Для перехода к главному содержимому необходимо войти в учетную запись.</p>
        <p class="col-lg-10 fs-4">Если у вас еще нет учетной записи вам необходимо 
        	<a href="regestration.php" class="">зарегестрироваться</a>.</p>
      </div>
      <div class="col-md-10 mx-auto col-lg-5">
        <form action="auth.php" method="post" class="p-4 p-md-5 border rounded-3 bg-light">
          <div class="form-floating mb-3">
            <input type="email" name="email" class="form-control" id="email" placeholder="name@example.com">
            <label for="floatingInput">Ваша почта</label>
          </div>
          <div class="form-floating mb-3">
            <input type="password" name="password" class="form-control" id="password" placeholder="Password">
            <label for="floatingPassword">Ваш пароль</label>
          </div>
          <div class="checkbox mb-3">
            <label>
              <p><?php print $m;?></p>
            </label>
          </div>
          <button class="w-100 btn btn-lg btn-success" type="submit">Войти</button>
          <a href="regestration.php" class=" pt-2 pb-n5 d-block text-center">Зарегестрироваться</a>
          <hr class="my-5">
          <small class="text-muted">Нажимая «Войти», вы соглашаетесь с условиями использования.</small>
        </form>
      </div>
    </div>
  </div>
</body>
</html>