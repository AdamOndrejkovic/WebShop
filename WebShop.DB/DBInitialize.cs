namespace WebShop.DB
{
    public class DBInitialize
    {
        public static void InitData(WebShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            
        }
    }
}