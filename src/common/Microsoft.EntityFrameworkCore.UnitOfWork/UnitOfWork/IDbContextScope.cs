using System;

namespace Microsoft.EntityFrameworkCore
{
	public interface IDbContextScope<TContext> where TContext : DbContext
	{

		TContext GetContext();
	}
}