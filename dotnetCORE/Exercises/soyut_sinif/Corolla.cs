namespace soyut_sinif
{
    public class Corolla : iOtomobil
    {
        public Marka HangiMarkanınAraci()
        {
            return Marka.Toyota;        }

        public int KacTekerlektenOlusur()
        {
            return 4;
        }

        public Renk StandartRengiNe()
        {
            return Renk.Beyaz;
        }
    }
}