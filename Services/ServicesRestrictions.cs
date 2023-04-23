namespace Catalog.Services;

public static class ServicesRestrictions 
{

    public static bool validZones(String? data)
    {
        List<string> restriction = new List<string>();
        restriction.Add("Torrao".ToUpper());
        restriction.Add("Entre-os-rios".ToUpper());
        restriction.Add("Eja".ToUpper());
        restriction.Add("Varzea".ToUpper());
        restriction.Add("Alpendurada".ToUpper());
        restriction.Add("Jugueiros".ToUpper());
        restriction.Add("Portela".ToUpper());
        restriction.Add("Canelas".ToUpper());
        restriction.Add("Sardoura".ToUpper());
        restriction.Add("Oliveira".ToUpper());
        restriction.Add("Rio-de-moinhos".ToUpper());

        if (restriction.Contains(data!))
        {
            return true;
        }

        return false;
    }

    public static bool validProduct(String? data)
    {
        List<string> restriction = new List<string>();
        restriction.Add("Peso".ToUpper()); 
        restriction.Add("Unidade".ToUpper()); 

        if (restriction.Contains(data!))
        {
            return true;
        }

        return false;
    }


    public static bool validOrder(String? data)
    {
        List<string> restriction = new List<string>();
        restriction.Add("Entrega".ToUpper());
        restriction.Add("Levantamento em Loja".ToUpper());

        if (restriction.Contains(data!))
        {
            return true;
        }
        return false;
    }

    public static bool validClient(String? data)
    {
        List<string> restriction = new List<string>();
        restriction.Add("Distribuicao".ToUpper());
        restriction.Add("Ocasional".ToUpper());

        if (restriction.Contains(data!))
        {
            return true;
        }
        return false;
    }
}