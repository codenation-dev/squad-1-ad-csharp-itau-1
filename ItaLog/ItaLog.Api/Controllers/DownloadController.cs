using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ItaLog.Api.ViewModels.Log;
using ItaLog.Data.Extensions;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItaLog.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        private readonly ILogPage _repo;
        private readonly IMapper _mapper;

        public DownloadController(ILogPage repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns csv of logs
        /// </summary>
        /// <param name="orderBy">Options: 'eventscount' or 'level'</param>
        /// <response code="200">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        [HttpGet("Logs/Csv")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        public IActionResult GetLogs(
             [FromQuery] PageFilter pageFilter,
             [FromQuery] LogFilter logFilter,
             [FromQuery] string orderBy = "")
        {
            var logs = _mapper.Map<IEnumerable<LogFileViewModel>>(_repo.GetPage(logFilter, pageFilter, orderBy).Results);
            var memoryStream = logs.ToCsv(true).ToMemoryStream();
            return new FileStreamResult(memoryStream, "text/plain") { FileDownloadName = "export_" + DateTime.Now + ".csv" };
        }
    }
}