/*
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, 
в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». 
Если у продукта нет категорий, то его имя все равно должно выводиться.
*/

/*
Предположим, что существуют три таблицы, в которых определены как минимум следующие столбцы:
- Products: Id, Name
- ProductCategories: ProductId, CategoryId
- Categories: Id, Name
*/

SELECT 
	Products.Name as ProductName, 
	Categories.Name as CategoryName
FROM Products
	LEFT OUTER JOIN ProductCategories on ProductCategories.ProductId = Products.Id
	LEFT OUTER JOIN Categories on Categories.Id = ProductCategories.CategoryId