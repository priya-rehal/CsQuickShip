using Microsoft.AspNetCore.Mvc;


namespace Auth.Api
{
    public class ApiResponseActionResult : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(new ApiResponse());

            await objectResult.ExecuteResultAsync(context);
        }
    }

    public class ApiResponseActionResult<T> : IActionResult
    {
        private readonly T _data;

        public ApiResponseActionResult(T data)
        {
            _data = data;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(new ApiResponse<T>(_data));

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
