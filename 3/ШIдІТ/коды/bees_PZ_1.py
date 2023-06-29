import turtle
import random

# создаем окно для отрисовки
wn = turtle.Screen()
wn.bgcolor("white")
wn.title("Пчелы и цветы")

# создаем квадраты пчелиных сот
squares = []
for i in range(20):
    square = turtle.Turtle()
    square.shape("square")
    square.color("grey")
    square.penup()
    x = -190 + (i % 5) * 40
    y = -190 + (i // 5) * 40
    square.goto(x, y)
    squares.append(square)

# создаем зеленые цветы
flowers = []
for i in range(15):
    flower = turtle.Turtle()
    flower.shape("circle")
    flower.color("green")
    flower.penup()
    x = random.randint(50, 200)
    y = random.randint(50, 200)
    flower.goto(x, y)
    flowers.append(flower)

# создаем оранжевую пчелу
bee = turtle.Turtle()
bee.shape("circle")
bee.color("orange")
bee.penup()

# функция для изменения цвета цветка
def change_color(flower):
    flower.color("grey")
    wn.ontimer(lambda: flower.color("green"), 1500)

# функция для окрашивания квадрата соты в желтый цвет
def color_square(square):
    square.color("yellow")

# функция для проверки, все ли квадраты стали желтыми
def all_yellow():
    for square in squares:
        if square.color()[0] != "yellow":
            return False
    return True

# основной цикл программы
while True:
    # пчела летит к случайному цветку
    flower = random.choice(flowers)
    bee.goto(flower.position())
    bee.pendown()
    bee.penup()
    # пчела стоит на цветке от 1 до 3 секунд
    time_to_wait = random.randint(1, 1)
    wn.ontimer(lambda: change_color(flower), 1)
    # пчела летит к пчелиным сотам
    bee.goto(-190, -190)
    for square in squares:
        if square.color()[0] == "grey":
            color_square(square)
            break
    # проверяем, все ли квадраты стали желтыми
    if all_yellow():
        # если все квадраты желтые, то перекрашиваем их в серый
        for square in squares:
            square.color("grey")