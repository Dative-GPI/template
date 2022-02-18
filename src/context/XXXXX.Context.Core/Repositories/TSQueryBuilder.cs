namespace XXXXX.Context.Core.Repositories
{
    public static class TSQueryBuilder 
    {
        public static string buidlQuery(string args)
        {
            var query = $"{args.Replace(" ", ":*&")}:*";
            return query;
        }
    }
}