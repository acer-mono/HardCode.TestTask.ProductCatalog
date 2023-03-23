﻿Постановка задачи:
Создать ASP.NET Core Web API (net core 3.1+) приложение, в котором будут реализованы следующие страницы.

1. Категории товара
2. Создание товара
3. Просмотр списка товаров
4. Просмотр товара


1. Страница категории товара.
   На странице категорий товара должен выводится список категорий, с возможностью добавлять новую или удалить существующую категорию.
   При добавлении категории нужно добавить возможность добавлять дополнительные поля для товара этой категории, например, цвет, вес, размер и т.д.

2. Страница создания товара
   На странице создания товара должна быть возможность заполнить общую информацию о товаре (фотография, название, описание, цена, категория) и указать значения для дополнительных полей, которые были созданы для выбранной категории.

3. Страница просмотра списка товара
   Вывести список товаров с фильтром по категориям и дополнительным полям

4. Просмотр выбранного товара из списка товаров

Обязательная часть включает в себя создание всего двух эндпоинтов, реализующих сохранение и получение товара. Основой целью является проверка подхода к проектированию механизма "динамических полей", которые создаются в категории, и должны заполняться и возвращаться в товаре. Предпочтительная БД - PostgreSQL.

Реализация:
Структура БД