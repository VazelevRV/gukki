**Цей файл описує роботу проведену над проектом**

- Встановлений модуль Entity Framework Core
- Встановлений модуль Sqlite Provider
- Встановлений модуль ImageUploader для збереження зображень товарів з форми
- Створена JavaScript функція PassId у Views\\Home\\Index для використання у представлення Index контролеру Home
щоб передати ID для видалення продукту у модальне віконце
- Створені додаткові стилі у wwwroot\\css
- Створений каталог wwwroot\\img\\conent для збереження завантажених користувачем зображень товарів
- Створені моделі таблиці Product та контекст GukkiDbContext для зв'язку з базою даних
- Контекст доданий до сервісів Dependency Injection у Startup.cs
- Створений контролер Home з методами Index, Delete та AddOrEdit для навігаціх по сайту
- Створені представлення Index та AddOrEdit для даних сайту
- Стовера база за допомогою команд Add-Migration Initial та Update-Database (Tools-> Package Mananager Console)
- Створений логотип сайту та додаткові іконки (немає зображення, видалення, іконка вкладки)
- Змінений Views\\Shared\\_Layout.cshtml (назва сайту та панель навігацій, копірайт інформація, логотип сайту)


**Використані посилання**

- [Завантажити bootstrap](https://getbootstrap.com/)
- [Призначення значень до asp route id](https://stackoverflow.com/questions/50876529/how-to-pass-javascript-variable-value-in-asp-route-id-prefix)
- [.NET Core туторіали](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/sql?view=aspnetcore-3.1&tabs=visual-studio)
- [.NET Core завантажити](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)
- [Документація Microsoft щодо .NET Core](https://docs.microsoft.com/en-us/ef/core/)
- [MVC Asp.Net](https://stackoverflow.com/questions/19413166/mvc-get-vs-post)
- [Функції у JS](https://www.w3schools.com/js/js_functions.asp)
- [Робота з sql](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-3.1&tabs=visual-studio)
- [Конвертація зображень](https://onlineconvertfree.com/download/#6e7ace15)
- [Стилі для форм завантажень файлів](https://www.abeautifulsite.net/whipping-file-inputs-into-shape-with-bootstrap-3)
- [Вирівнювання в bootstrap](https://stackoverflow.com/questions/44389464/align-the-form-to-the-center-in-bootstrap-4)
- [Завантаження зображень у asp.net core](https://www.ttmind.com/TechPost/Images-Upload-REST-API-using-ASP-NET-Core)
- [Image Uploader](https://github.com/mbatniji/ImageUploader/blob/master/README.md)
- [Custom File Upload button](https://www.youtube.com/watch?v=SE38zdOOrAQ)

