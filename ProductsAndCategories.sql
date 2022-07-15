--IDENTITY выбран для тестового примера, числовые значения визуально проще сравнивать
CREATE TABLE Products(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[ProductName] nvarchar(100) NOT NULL,
)

CREATE TABLE Categories(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[CategoryName] nvarchar(100) NOT NULL,
)

--Вопрос каскадного удаления записи в данном случае игнорируется, для этой цели можно использовать разные способы 
-- с разной степенью эффективности в зависимости от контекста использования
CREATE TABLE ProductsAndCategoriesRelationships(
	[ProductId] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	PRIMARY KEY ([ProductId], [CategoryId])
)

INSERT INTO Products (ProductName) VALUES ('p1'), ('p2'), ('p3'), ('p4')
INSERT INTO Categories (CategoryName) VALUES ('c1'), ('c2'), ('c3'), ('c4')
INSERT INTO ProductsAndCategoriesRelationships VALUES (1, 1), (1, 2), (2, 3), (3, 3)

SELECT p.ProductName, c.CategoryName FROM Products AS p WITH(nolock)
LEFT JOIN ProductsAndCategoriesRelationships AS pcr WITH(nolock) ON p.Id = pcr.ProductId
LEFT JOIN Categories AS c WITH(nolock) ON pcr.CategoryId = c.Id

--Здесь над решением особо не думал, возможно можно ещё как нибудь интересно оптимизировать
--Но в целом, в данном случае, MSSQL сам создаёт кластерные индексы по первичным ключам за счёт этого запрос уже проходит быстро