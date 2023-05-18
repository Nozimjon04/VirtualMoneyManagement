using UserWebApi.Service.Exceptions;

namespace UserWebApi.Middlewares
{
	
	public class ExceptionHandlerMiddleWare
	{
		private readonly RequestDelegate next;
		public ExceptionHandlerMiddleWare(RequestDelegate next)
		{
			this.next = next;
			
		}
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await this.next(context);
			}
			catch (CustomException ex)
			{
				context.Response.StatusCode = ex.Code;
				await context.Response.WriteAsJsonAsync(new
				{
					code = ex.Code,
					message = ex.Message,
				});
			}
			catch (Exception ex)
			{
				context.Response.StatusCode = 500;
				await context.Response.WriteAsJsonAsync(new
				{
					code = 500,
					message = ex.Message,
				});
			}

		}
	}
}

