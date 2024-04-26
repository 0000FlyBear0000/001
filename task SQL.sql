//Предполагается, что есть две таблицы: Productsи Categories, а также таблица ProductCategoriesдля связи многими-ко-многим:

CREATE TABLE Products (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100)
);

CREATE TABLE Categories (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100)
);

CREATE TABLE ProductCategories (
    ProductId INT,
    CategoryId INT,
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
//Заполним таблицы данными:

INSERT INTO Products (Id, Name) VALUES (1, 'Product 1');
INSERT INTO Products (Id, Name) VALUES (2, 'Product 2');
INSERT INTO Products (Id, Name) VALUES (3, 'Product 3');

INSERT INTO Categories (Id, Name) VALUES (1, 'Category 1');
INSERT INTO Categories (Id, Name) VALUES (2, 'Category 2');

INSERT INTO ProductCategories (ProductId, CategoryId) VALUES (1, 1);
INSERT INTO ProductCategories (ProductId, CategoryId) VALUES (1, 2);
INSERT INTO ProductCategories (ProductId, CategoryId) VALUES (2, 1);
Напишем SQL-запрос для выбора всех пар «Имя проду

SELECT P.Name AS ProductName, C.Name AS CategoryName
FROM Products P
LEFT JOIN ProductCategories PC ON P.Id = PC.ProductId
LEFT JOIN Categories C ON PC.CategoryId = C.Id;
//Этот запрос возвращает все пары «Имя продукта – Название категории»,