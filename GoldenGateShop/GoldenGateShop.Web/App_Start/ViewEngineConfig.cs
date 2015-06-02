namespace GoldenGateShop.Web.App_Start
{
    using System.Web.Mvc;

    public static class ViewEngineConfig
    {
        public static void RegisterViewEngine(ViewEngineCollection engines)
        {
            engines.Clear();
            engines.Add(new RazorViewEngine());
        }
    }
}