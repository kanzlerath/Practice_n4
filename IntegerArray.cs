public class IntegerArray
{
    private int[] array;
    public int Length => array.Length;

    // Конструктор
    public IntegerArray(int size)
    {
        if (size < 0)
        {
            throw new ArgumentException("Размер должен быть неотрицательным.");
        }
        array = new int[size];
    }

    // Индексатор
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона.");
            }
            return array[index];
        }
        set
        {
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона.");
            }
            array[index] = value;
        }
    }
}