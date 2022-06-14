namespace services
{
    interface IRestApiConector
    {
        String getAll();
        String describeDB();
        int contarRegistros();
    }
}