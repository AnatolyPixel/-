using System;
using System.Collections.Generic;

public class Заказ
{
    public int ID { get; set; }
    public Клиент Клиент { get; set; }
    public List<Продукт> Продукты { get; set; }
    public List<Платеж> Платежи { get; set; }

    public Заказ(int id, Клиент клиент)
    {
        ID = id;
        Клиент = клиент;
        Продукты = new List<Продукт>();
        Платежи = new List<Платеж>();
    }

    public decimal ПолучитьОбщуюСумму()
    {
        decimal общаяСумма = 0;
        foreach (var продукт in Продукты)
        {
            общаяСумма += продукт.Цена;
        }
        return общаяСумма;
    }

    public decimal ПолучитьСуммуОплачено()
    {
        decimal оплачено = 0;
        foreach (var платеж in Платежи)
        {
            оплачено += платеж.Сумма;
        }
        return оплачено;
    }
}
