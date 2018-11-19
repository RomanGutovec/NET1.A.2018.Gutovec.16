Day16
---
Разработать обобщенный класс-коллекцию [BinarySearchTree (бинарное дерево поиска)](https://github.com/RomanGutovec/NET1.A.2018.Gutovec.16/blob/master/BinaryTreeLib/BinaryTree.cs). 
Предусмотреть возможности использования подключаемого интерфейса для реализации отношения порядка. Реализовать три способа обхода дерева: прямой (preorder), поперечный (inorder), обратный (postorder): для реализации использовать блок-итератор (yield). [Протестировать](https://github.com/RomanGutovec/NET1.A.2018.Gutovec.16/blob/master/BinaryTreeLib.Tests/BinaryTreeLibTest.cs) разработанный класс, используя следующие типы:
 *  System.Int32 (использовать сравнение по умолчанию и подключаемый компаратор);
 *  System.String (использовать сравнение по умолчанию и подключаемый компаратор);
 *  пользовательский класс [Book](https://github.com/RomanGutovec/NET1.A.2018.Gutovec.16/blob/master/BinaryTreeLib.Tests/Helpers/Book.cs), для объектов которого реализовано отношения порядка (использовать сравнение по умолчанию и подключаемый компаратор);
 *  пользовательскую структуру [Point](https://github.com/RomanGutovec/NET1.A.2018.Gutovec.16/blob/master/BinaryTreeLib.Tests/Helpers/Point.cs), для объектов которого не реализовано отношения порядка (использовать подключаемый компаратор).
