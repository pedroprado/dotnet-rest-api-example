using Microsoft.AspNetCore.Mvc;
using web_api_example.Contracts;

namespace web_api_example.Controllers
{
    [Route("api/logger")]
    [ApiController]
    public class LoggerController:Controller
    {
    
    private ILoggerManager _logger;

    public LoggerController(ILoggerManager looger){
        this._logger = looger;
    }
    [HttpGet]
    public IActionResult testLogger(){
        
        _logger.LogInfo("Here is info message from our values controller.");
        _logger.LogDebug("Here is debug message from our values controller.");
        _logger.LogWarn("Here is warn message from our values controller.");
        _logger.LogError("Here is error message from our values controller.");
        return new ObjectResult("value1");
     }

    }
}