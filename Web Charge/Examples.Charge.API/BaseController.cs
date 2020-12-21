using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Examples.Charge.Application.Common.Messages;

namespace Examples.Charge.API
{
    public class BaseController : ControllerBase
    {
        protected new ActionResult Response(BaseResponse response)
        {
            if (response == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(response);
            }
        }

        protected new IActionResult Response(int? id = null, object response = null)
        {
            if (id == null)
            {
                return Ok(response);
            }
            else
            {
                return CreatedAtAction("Get", new { id }, response ?? new object());
            }
        }
    }
}
