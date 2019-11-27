namespace DataAccess.Exception
{
    public class DAOException : System.Exception 
    {
        public DAOException(string message) : base(message)
        {
        }
    }
}