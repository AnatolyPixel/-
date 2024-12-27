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
