namespace soyut_sinif
{
    public class NewCivic : Otomobil
    {
        public override Marka HangiMarkanınAraci()
        {
            return Marka.Honda;
        }
        public override Renk StandartRengiNe()
        {
            return Renk.Gri;
        }
    }
}