

<div class="w-50 mx-auto m-4">
  <div class="info">
    <h2>Макросъёмка</h2>
    <p>Макросъёмка  — вид кино- и фотосъёмки, при котором изображаемые объекты снимаются в масштабе 1:1 или крупнее (по другой версии — в масштабе 1:1 или крупнее). Существуют разные определения термина, которые отличаются диапазоном масштабов, их объединяет то, что съёмка в масштабе 1:1 всегда считается макросъёмкой. Например, Большая российская энциклопедия даёт такое определение: «фото-, кино- и видеосъёмка, при которой масштаб получаемых оптических изображений (отношение линейных размеров изображения объекта в фокальной плоскости объектива к его реальным размерам) лежит в пределах от 1:5 до 10:1 и выше».</p>
  </div>
  <div id="carouselExampleIndicators" class="mb-5 redactor-carousel carousel slide" data-bs-ride="true">
    <div class="carousel-indicators">
      <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
      <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
      <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
    </div>
    <div class="carousel-inner">
      <div class="carousel-item active">
        <img src="img/1.jpg" class="d-block w-100" alt="...">
      </div>
      <div class="carousel-item">
        <img src="img/7.jpg" class="d-block w-100" alt="...">
      </div>
      <div class="carousel-item">
        <img src="img/8.jpg" class="d-block w-100" alt="...">
      </div>
    </div>
    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Предыдущий</span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Следующий</span>
    </button>
  </div>
  <div class="info">
    <h2>Запечатлить момент</h2>
    <p>Крутая камера в смартфоне – это средство для создания фотографий, но не гарантия их безупречности. Хотите получить от неё максимальную отдачу и собрать кучу лайков в соцсетях? Без проблем: хорошо снимать может каждый, и наши советы вам в этом помогут. Фотография – это сочетание искусства и ремесла. Если хотите достичь хороших результатов, то и развиваться нужно в двух направлениях. Во-первых, смотреть на фотографии признанных мастеров в поисках вдохновения. Во-вторых, снимать самому как можно чаще, ведь чем больше практики, тем качественнее в итоге результат.</p>
  </div>
  <div class="mt-5 d-flex">
          <?php for ($i=1 ; $i <= 3; $i++): ?>
      <div class="m-2 card">
        <img src="img/<?php echo $i + 3 ?>.jpg" class="card-img-top" alt="...">

        <div class="card-body">          
          <?php if ($i == 1): ?>
            <h5 class="card-title">Беседка</h5>
          <p class="card-text">При правильном освещении можнет выйти хорошее фото.</p> 
          <?php elseif ($i == 2): ?>
            <h5 class="card-title">Ручей</h5>
          <p class="card-text">Под правильным углом снимок смотрится эстетичнее.</p>  
          <?php elseif ($i == 3): ?>
            <h5 class="card-title">Огонёк</h5>
          <p class="card-text">При должной фотооброботке конечная картинка выглядит более привлекательно.</p> 
        <?php endif; ?>
        </div>
      </div>
    <?php endfor; ?>
  </div>
</div>
