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
