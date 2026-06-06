namespace conversion
{
    internal class Temperature
    {
        public double Convertir(double valeur, string de, string vers)
        {
            if (de == "Celsius" && vers == "Fahrenheit")
                return valeur * 9 / 5 + 32;
            else if (de == "Fahrenheit" && vers == "Celsius")
                return (valeur - 32) * 5 / 9;
            else if (de == "Celsius" && vers == "Kelvin")
                return valeur + 273.15;
            else if (de == "Kelvin" && vers == "Celsius")
                return valeur - 273.15;
            else if (de == "Fahrenheit" && vers == "Kelvin")
                return (valeur - 32) * 5 / 9 + 273.15;
            else if (de == "Kelvin" && vers == "Fahrenheit")
                return (valeur - 273.15) * 9 / 5 + 32;
            else
                return valeur;
        }
    }
}