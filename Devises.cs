namespace conversion
{
    internal class Devises
    {
        public double Convertir(double valeur, string de, string vers)
        {
            if (de == "EUR" && vers == "USD")
                return valeur * 1.08;
            else if (de == "USD" && vers == "EUR")
                return valeur / 1.08;
            else if (de == "EUR" && vers == "GBP")
                return valeur * 0.86;
            else if (de == "GBP" && vers == "EUR")
                return valeur / 0.86;
            else if (de == "USD" && vers == "GBP")
                return valeur * 0.79;
            else if (de == "GBP" && vers == "USD")
                return valeur / 0.79;
            else
                return valeur;
        }
    }
}
