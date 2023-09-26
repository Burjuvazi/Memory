namespace Memory.WebUI.MiddleWare
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
                _next = next;
        }
        public async Task InvokeAsync(HttpContext httpcontext)
        {
            string content = $"İstek atilan metot : { httpcontext.Request.Method}\n Yol : { httpcontext.Request.Path.Value}\n Statu Kod : {httpcontext.Response.StatusCode}\n";

            try
            {
                File.AppendAllText("Loggin.txt", content);
                await _next(httpcontext);
            }
            catch (Exception ex)
            {

                content += ex.Message;
                File.AppendAllText("Loggin.txt", content);
            }
                  
        }
    }
}
