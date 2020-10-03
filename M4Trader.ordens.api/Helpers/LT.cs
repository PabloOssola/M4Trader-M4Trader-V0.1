using M4Trader.ordenes.server.Helpers;

namespace M4Trader.ordenes.mvc.Helpers
{
    public static class LT
    {
        public static string T(string abztract)
        {
            return LiteralesTraducidos.Instance.Translate(LiteralesTraducidos.Instance.IdiomaInicial, abztract);
        }

    }
}