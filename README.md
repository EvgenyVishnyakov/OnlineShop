<div class="text" align="center">
    <h2>Онлайн магазин по продаже мебели</h2>
</div>
<h3>Краткое описание</h3>
<p><em>Онлайн магазин с возможностью просмотра имеющегося товара. Клиент может выбирать и просматривать будучи не авторизованным. Но , если он захочет что то купить, ему придется авторизоваться. Причем его выбор после авторизации, сохранится. </p>
<img src="https://github.com/user-attachments/assets/ca2907c0-4262-47ed-a176-837d4c91bd1c" />
    
<p><em>Есть возможность добавления в сравнение, избранное, корзина. </p>
<img src="https://github.com/user-attachments/assets/dd53183c-e0dc-4946-9eef-0264291cee39" />
    
<p><em>Есть возможность администрирования, добавления ролей, а также изменения статуса заказа, добавления отзыва по продукту. </p>
<p><em>Реализовано unit тестирование, а также работа с API через Swagger </p>
<img src="https://github.com/user-attachments/assets/fad00963-34be-44a1-b618-fa4d4bc4bbcb" />

<h3>Архитектурная часть</h3>
<img src="https://github.com/user-attachments/assets/a28a4009-ac47-4d9c-bfb2-3c2d3718afec" />
<p>Работа выполнена с использованием общей бибилиотеки в коде</p>
<p>При разработки данной игры я прошел несколько важных шагов в изучении языка с#</p>
<ul>
    <li>Использование знаний по ООП для разделения сущностей и логики работы кода</li>
    <li>Использвоание формата Json для сохранения результатов игры</li>
    <li>Работа с файловой системой</li>
    <li>Проверка на валидность данных, использование try catch</li>
    <li>Возможность расширения списка вопросов и ответов для разнообразия игры</li>
</ul>
<h5>Особенно хотел бы отметить код для сохрарения в формате JSON</h5>

    public static void Append(string Path, string value)
    {
        var writer = new StreamWriter(Path, true, Encoding.UTF8);
        writer.WriteLine(value);
        writer.Close();
    }

    public static void Replace(string Path, string value)
    {
        var writer = new StreamWriter(Path, false, Encoding.UTF8);
        writer.WriteLine(value);
        writer.Close();
    }

    public static string GetValue(string Path)
    {
        var reader = new StreamReader(Path, Encoding.UTF8);
        var value = reader.ReadToEnd();
        reader.Close();
        return value;
    }

    public static bool Exists(string Path)
    {
        return File.Exists(Path);
    }

    public static void Save(string path, Password password)
    {
        var jsonData = JsonConvert.SerializeObject(password, Formatting.Indented);
        Replace(path, jsonData);
    }
<h2>Немного видео из игры</h2>

<a href="https://github.com/user-attachments/assets/d20e4a77-47db-4a6b-b80a-0049d21bfd77">Скачать видео</a>
 
<div class="text" align="center">
    <h1>Спасибо за внимание!</h2>
</div>
