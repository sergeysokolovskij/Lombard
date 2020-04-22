using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lombard.Middlewhere
{
	public static class DiExtension
	{
		public static void RegistrateMiddlewhere(this IApplicationBuilder app)
		{
			app.UseMiddleware<XssProtectionMiddlewhere>();
		}
	}
}
