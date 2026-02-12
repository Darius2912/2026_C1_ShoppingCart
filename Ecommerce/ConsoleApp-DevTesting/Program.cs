using DataAccess.DAO;

public class Program
{
    public static void Main(string[] args)
    {
        //Prueba de funcionamiento del DAO.

        var sql=sqlDAO.GetInstance();

        var sqlOperation = new sqlOperation { ProcedureName = "CRE_USER_PR" };
        sqlOperation.AddStringParam("P_NAME ", " Dario");
        sqlOperation.AddStringParam("P_Last_Name ", " Chaves");
        sqlOperation.AddStringParam("P_Password", "1234");
        sqlOperation.AddStringParam("P_Email ", "jchavesl@ucenfotec.ac.cr");
        sqlOperation.AddDateTimeParam("P_BIRTH_DATE" , DateTime.Now);
        sqlOperation.AddStringParam("P_Status", "AC");

        try 
        { 
        sql.ExecuteProcedure(sqlOperation);
        Console.WriteLine("Procedimiento ejecutado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
}
}