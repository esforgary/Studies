import tkinter as tk
from tkinter import messagebox

# Базовый класс (Component)
class UserModel:
    def __init__(self):
        self.username = ""
        self.email = ""

    def display_user(self):
        return "Имя пользователя: {}\nEmail пользователя: {}".format(self.username, self.email)

# Декоратор (Decorator)
class UserModelDecorator(UserModel):
    def __init__(self, user_model):
        self._user_model = user_model

    def display_user(self):
        return self._user_model.display_user()

    def display_user_with_age(self, age):
        return "{}\nВозраст пользователя: {} года(лет)".format(self._user_model.display_user(), age)

# Представление (View)
class UserView:
    def __init__(self, root):
        self.root = root
        self.username_label = tk.Label(root, text="Имя пользователя:")
        self.username_label.pack()
        self.username_entry = tk.Entry(root)
        self.username_entry.pack()
        self.email_label = tk.Label(root, text="Email пользователя:")
        self.email_label.pack()
        self.email_entry = tk.Entry(root)
        self.email_entry.pack()
        self.age_label = tk.Label(root, text="Возраст пользователя:")
        self.age_label.pack()
        self.age_entry = tk.Entry(root)
        self.age_entry.pack()
        self.display_button = tk.Button(root, text="Отобразить", command=self.display_user)
        self.display_button.pack()

    def display_user(self):
        username = self.username_entry.get()
        email = self.email_entry.get()
        age = self.age_entry.get()
        # Проверяем, что введенное значение возраста является целым числом
        if age.isdigit():
            user_model = UserModel()
            user_model.username = username
            user_model.email = email
            # Декорируем объект UserModel, добавляя возраст
            user_model_with_age = UserModelDecorator(user_model)
            message = user_model_with_age.display_user_with_age(age)
            self.show_message(message)
        else:
            self.show_message("Ошибка: Возраст должен быть целым числом!")

    def show_message(self, message):
        messagebox.showinfo("Пользовательская информация", message)

# Контроллер (Controller)
class UserController:
    def __init__(self, model, view):
        self.model = model
        self.view = view

# Использование паттерна Модель-Представление-Контроллер (MVC)
# Создаем корневое окно для графического интерфейса
root = tk.Tk()
root.title("Пример MVC с Tkinter")
# Создаем объект представления
user_view = UserView(root)
# Создаем объект контроллера
user_controller = UserController(None, user_view)

# Запускаем графический интерфейс
root.mainloop()