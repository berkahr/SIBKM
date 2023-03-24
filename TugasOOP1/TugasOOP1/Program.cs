// See https://aka.ms/new-console-template for more information
using System;

namespace TugasOOP1
{
    public class pasien
    {
        public string ID;
        public string Nama;
        public int Umur;
        public string Alamat;
        public virtual void DataPasien() //virtual (polomorpism) merupakan  class parent
        {
            Console.WriteLine("================================");
            Console.WriteLine("ID              :" + ID);
            Console.WriteLine("Nama            :" + Nama);
            Console.WriteLine("Umur            :" + Umur);
            Console.WriteLine("Alamat          :" + Alamat);
        }
    }
    public class DataTambahan : pasien //ini inheritance
    {
        public string Jenis;
        public override void DataPasien () //override (polomorpism) merupakan  class child
        {
            base.DataPasien();
            Console.WriteLine("Jenis Ruangan   :" + Jenis);
        }
    }   
    class Program
    {
        public static void Main(string[] args)
        {
            pasien Budi = new pasien();
            Budi.ID = "001";
            Budi.Nama = "Budi Man";
            Budi.Umur = 23;
            Budi.Alamat = "Jakarta";
           
            Budi.DataPasien();

            DataTambahan Cahyadi = new DataTambahan();
            Cahyadi.ID = "001";
            Cahyadi.Nama = "Cahyadi";
            Cahyadi.Umur = 25;
            Cahyadi.Alamat = "Jakarta";
            Cahyadi.Jenis = "Dokter Umum";
            Cahyadi.DataPasien();
        }
    }
}
 
