using product.model2.Helper;

namespace product.model2.Helpers
{
    public class Helper : IHelper // interface yi enjekte ettik
    {
        public string ToUpper(string text)
        {
            return text.ToUpper();
        }
    }
}
