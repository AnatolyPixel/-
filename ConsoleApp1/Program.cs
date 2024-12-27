using System;
using System.Collections.Generic;

public class Клиент
{
    public string Имя { get; set; }

    public Клиент(string имя)
    {
        Имя = имя;
    }
}

public class Продукт
{
    public string Название { get; set; }
    public decimal Цена { get; set; }

    public Продукт(string название, decimal цена)
    {
        Название = название;
        Цена = цена;
    }
}

public class Заказ
{
    public int ID { get; set; }
    public Клиент Клиент { get; set; }
    public List<Продукт> Продукты { get; set; }
    public List<Платеж> Платежи { get; set; }  // Добавляем платежи в заказ

    public Заказ(int id, Клиент клиент)
    {
        ID = id;
        Клиент = клиент;
        Продукты = new List<Продукт>();
        Платежи = new List<Платеж>();
    }

    public decimal ОбщаяСумма()
    {
        decimal сумма = 0;
        foreach (var продукт in Продукты)
        {
            сумма += продукт.Цена;
        }
        return сумма;
    }

    public void ДобавитьПлатеж(Платеж платеж)
    {
        Платежи.Add(платеж);
    }
}

public class Платеж
{
    public decimal Сумма { get; set; }
    public string СпособОплаты { get; set; }

    public Платеж(decimal сумма, string способОплаты)
    {
        Сумма = сумма;
        СпособОплаты = способОплаты;
    }
}

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
            Console.WriteLine($"ID заказа: {заказ.ID}, Клиент: {заказ.Клиент.Имя}, Общая сумма: {заказ.ОбщаяСумма():C}");
            Console.WriteLine("Продукты:");
            foreach (var продукт in заказ.Продукты)
            {
                Console.WriteLine($"  - {продукт.Название}: {продукт.Цена:C}");
            }

            Console.WriteLine("Платежи:");
            foreach (var платеж in заказ.Платежи)
            {
                Console.WriteLine($"  - Сумма: {платеж.Сумма:C}, Способ оплаты: {платеж.СпособОплаты}");
            }
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
            заказ.ДобавитьПлатеж(платеж);
            Console.WriteLine("Платеж успешно добавлен.");
        }
        else
        {
            Console.WriteLine("Заказ с таким ID не найден.");
        }
    }
}

class Программа
{
    static void Main(string[] args)
    {
        var менеджерЗаказов = new МенеджерЗаказов();
        int idЗаказа = 1;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Система управления заказами");
            Console.WriteLine("1. Добавить заказ");
            Console.WriteLine("2. Просмотреть все заказы");
            Console.WriteLine("3. Удалить заказ");
            Console.WriteLine("4. Добавить платеж");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите опцию: ");

            string выбор = Console.ReadLine();

            switch (выбор)
            {
                case "1":
                    ДобавитьЗаказ(менеджерЗаказов, ref idЗаказа);
                    break;

                case "2":
                    ПросмотретьВсеЗаказы(менеджерЗаказов);
                    break;

                case "3":
                    УдалитьЗаказ(менеджерЗаказов);
                    break;

                case "4":
                    ДобавитьПлатеж(менеджерЗаказов);
                    break;

                case "5":
                    Console.WriteLine("Выход...");
                    return;

                default:
                    Console.WriteLine("Неверная опция. Попробуйте снова.");
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }

    static void ДобавитьЗаказ(МенеджерЗаказов менеджерЗаказов, ref int id)
    {
        Console.Write("Введите имя клиента: ");
        string имяКлиента = Console.ReadLine();
        var клиент = new Клиент(имяКлиента);

        var заказ = new Заказ(id++, клиент);

        while (true)
        {
            Console.Write("Введите название продукта (или напишите 'готово' для завершения): ");
            string названиеПродукта = Console.ReadLine();

            if (названиеПродукта.Equals("готово", StringComparison.CurrentCultureIgnoreCase))
                break;

            Console.Write("Введите цену продукта: ");
            decimal ценаПродукта = decimal.Parse(Console.ReadLine());

            var продукт = new Продукт(названиеПродукта, ценаПродукта);
            заказ.Продукты.Add(продукт);
        }

        менеджерЗаказов.ДобавитьЗаказ(заказ);
    }

    static void ПросмотретьВсеЗаказы(МенеджерЗаказов менеджерЗаказов)
    {
        менеджерЗаказов.ПросмотретьВсеЗаказы();
    }

    static void УдалитьЗаказ(МенеджерЗаказов менеджерЗаказов)
    {
        Console.Write("Введите ID заказа для удаления: ");
        int idЗаказа = int.Parse(Console.ReadLine());
        менеджерЗаказов.УдалитьЗаказ(idЗаказа);
    }

    static void ДобавитьПлатеж(МенеджерЗаказов менеджерЗаказов)
    {
        Console.Write("Введите ID заказа для добавления платежа: ");
        int idЗаказа = int.Parse(Console.ReadLine());
        Console.Write("Введите сумму платежа: ");
        decimal суммаПлатежа = decimal.Parse(Console.ReadLine());
        Console.Write("Введите способ оплаты: ");
        string способОплаты = Console.ReadLine();

        var платеж = new Платеж(суммаПлатежа, способОплаты);
        менеджерЗаказов.ДобавитьПлатеж(idЗаказа, платеж);
    }
}
