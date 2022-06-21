using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSDesk_CLI_API.Hubs
{
    [EnableCors("AllowAll")]
    public class AppHub : Hub
    {

    }
}
