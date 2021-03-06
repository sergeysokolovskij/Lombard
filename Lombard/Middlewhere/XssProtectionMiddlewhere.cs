﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lombard.Middlewhere
{
	public class XssProtectionMiddlewhere
	{
		private readonly RequestDelegate next;

		public XssProtectionMiddlewhere(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
			context.Response.Headers.Add("X-Xss-Protection", "1");
			context.Response.Headers.Add("X-Frame-Options", "DENY");

			await next(context);
		}
	}
}
