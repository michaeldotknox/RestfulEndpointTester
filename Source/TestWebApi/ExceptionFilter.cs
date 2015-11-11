using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace TestWebApi
{
    public class ExceptionFilter : ExceptionHandler
    {
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(new InternalServerErrorResult(context.Request));
        }
    }
}
