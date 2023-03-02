namespace MvcCoreSession.Controllers
{
    public class ClassTestHttpAccessor
    {
        private IHttpContextAccessor contextAccessor;

        public ClassTestHttpAccessor(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public void Metodo1()
        {
            this.contextAccessor.HttpContext.Session.SetString("KEY", "VALUE");
        }
    }
}
