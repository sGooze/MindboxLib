/*
� ���� ������ MS SQL Server ���� �������� � ���������. ������ �������� ����� ��������������� ����� ���������, 
� ����� ��������� ����� ���� ����� ���������. �������� SQL ������ ��� ������ ���� ��� ���� �������� � ��� ���������. 
���� � �������� ��� ���������, �� ��� ��� ��� ����� ������ ����������.
*/

/*
�����������, ��� ���������� ��� �������, � ������� ���������� ��� ������� ��������� �������:
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