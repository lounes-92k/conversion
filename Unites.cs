namespace conversion
{
    internal class Unites
    {
        public double Convertir(double valeur, string de, string vers)
        {
            if (de == "Km" && vers == "Miles")
                return valeur * 0.621371;
            else if (de == "Miles" && vers == "Km")
                return valeur * 1.60934;
            else if (de == "Kg" && vers == "Livres")
                return valeur * 2.20462;
            else if (de == "Livres" && vers == "Kg")
                return valeur / 2.20462;
            else
                return valeur;
        }
    }
}
