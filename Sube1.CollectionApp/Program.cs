using System.Collections;

namespace Sube1.CollectionApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] dizi = { 1, 2, 3 };//array sadec int atılır ve veri sayısı bilinmelidir baştan belirtilmelidir 

            //ArrayList al = new ArrayList();//object tipinde veri tutar boyutları dinamik olarak artar 
            //int sayi1 = 5;
            //int sayi2= 6;

            //int[]array =new int[2];
            //array[0] = sayi1;
            //array[1] = sayi2;
            //Console.WriteLine(array[0] + array[1]);

            //al.Add(sayi1);//int den object e geçiş oldu arraylist e attığım için arraylist object tipinde veri tutar boxing işlemi
            //al.Add(sayi2);

            //al.Capacity = al.Count;
            //Console.WriteLine($"Capacity:{al.Capacity}\nCount:{al.Count}");
            //Console.WriteLine((int)al[0] + (int)al[1]);//direkt obejct ile işlem yapmaya çalıştığım için cast yaparım tekrardan int'e çeviririm unboxing
            //Console.ReadKey(); 

            //var d = new Deneme<int>();
            //d.value1 = 1;
            //d.value2 = 2;
            //d.Yazdır(5);

            //var d2 = new Deneme<string>();
            //d2.value1 = "2";
            //d2.Yazdır("5");

            List<int> lst = new List<int>();
            lst.Add(5);
            Dictionary<string,object> viewdata =new Dictionary<string,object>();
            //viewdata.Add("Ogrenci", );
        }
    }
    class Deneme<T> where T: struct//generic list değer tipleri:struct
    //generic constraints(where: T struct)       
    {
        public T value1;
        public T value2;

        public void Yazdır(T value)
        {
            Console.WriteLine(value);
        }
    }
}
