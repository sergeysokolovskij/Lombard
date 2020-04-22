using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lombard.DAL.Base
{
	public class ApplicationContext : IdentityDbContext
	{
		public ApplicationContext(DbContextOptions options) : base(options)
		{
		}


	}
}
