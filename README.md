# DatingApp

В проекте используется Docker.

Запуск проекта в Docker.
Скачайте приложение Docker Desktop: https://docs.docker.com/desktop/install/windows-install/

Скачайте репозиторий и запустите файл DatingApp.API.sln.

---------------------------------------------------------------

# Метод #1: Запуск проекта без использования Docker

1) Установите стартап-проект DatingApp.API.
2) Запустите DatingApp.API.

Swagger будет доступен по адресу https://localhost:5001/swagger/index.html.
База данных будет создана в вашем локальном MSSQL.

![image](https://github.com/user-attachments/assets/3d56a9ef-a694-4077-bed1-f1f777850918)


# Метод #2: Запуск приложения с использованием Docker

1) Установите стартап-проект docker-compose и запустите его через Docker Compose.
2) После запуска Swagger будет доступен по адресу http://localhost:8010/swagger/index.html.

 ![image](https://github.com/user-attachments/assets/08bd68a4-c8be-4780-bb49-8222c5825092)

 
# Метод #3: Запуск приложения с использованием Docker
 
1) Откройте вкладку Developer Powershell в нижней части Visual Studio. Введите команду:
 
 для сборки:
"docker-compose build"

для запуска в приложении Docker Desktop:
"docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d"

Вы увидите экземпляры, backend и MSSQL DB. Например:

![image](https://github.com/user-attachments/assets/380874e7-bf0d-47db-8255-3286a7b9a3e3)

Swagger будет доступен по адресу http://localhost:8010/swagger/index.html.

# Итог
Приложение будет запускаться также на Docker.

База будет автоматически заполняться тестовыми данными в localDb.

Я добавил фильтрацию по возрасту, указывая не точный возраст, а интервал возрастов. Должен быть указан хотя бы один возраст.

Добавил поля для имени, фамилии и email пользователя при регистрации. Email должен быть уникальным для каждого пользователя.

В дальнейшем предлагаю добавить авторизацию и аутентификацию, используя JWT токен.



  
