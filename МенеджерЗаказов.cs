using System;
using System.Collections.Generic;

public class МенеджерЗаказов
{
    private List<Заказ> _заказы = new List<Заказ>();

    public void ДобавитьЗаказ(Заказ заказ)
    {
        _заказы.Add(заказ);
        Console.WriteLine("Заказ успешно добавлен.");
    }

    public void ПросмотретьВсеЗаказы()
    {
        if (_заказы.Count == 0)
        {
            Console.WriteLine("Нет заказов.");
            return;
        }

        Console.WriteLine("Все заказы:");
        foreach (var заказ in _заказы)
        {
            Console.WriteLine($"ID заказа: {заказ.ID}, Клиент: {заказ.Клиент.Имя}");
            Console.WriteLine("Продукты:");
            foreach (var продукт in заказ.Продукты)
            {
                Console.WriteLine($"  - {продукт.Название}: {продукт.Цена:C}");
            }
            Console.WriteLine($"Общая сумма: {заказ.ПолучитьОбщуюСумму():C}");
            Console.WriteLine($"Оплачено: {заказ.ПолучитьСуммуОплачено():C}");
            Console.WriteLine();
        }
    }

    public void УдалитьЗаказ(int id)
    {
        var заказ = _заказы.Find(o => o.ID == id);
        if (заказ != null)
        {
            _заказы.Remove(заказ);
            Console.WriteLine("Заказ удалён.");
        }
        else
        {
            Console.WriteLine("Заказ с таким ID не найден.");
        }
    }

    public void ДобавитьПлатеж(int id, Платеж платеж)
    {
        var заказ = _заказы.Find(o => o.ID == id);
        if (заказ != null)
        {
            заказ.Платежи.Add(платеж);
            Console.WriteLine("Платеж успешно добавлен.");
        }
        else
        {
            Console.WriteLine("Заказ с таким ID не найден.");
        }
    }
}
