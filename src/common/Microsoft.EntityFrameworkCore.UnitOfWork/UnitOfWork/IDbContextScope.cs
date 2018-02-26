using System;

namespace Microsoft.EntityFrameworkCore.UnitOfWork
{
	public interface IDbContextScope
	{

		DbContext GetContext();
	}
}