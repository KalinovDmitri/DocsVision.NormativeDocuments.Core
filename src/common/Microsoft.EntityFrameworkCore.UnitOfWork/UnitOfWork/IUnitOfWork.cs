using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.EntityFrameworkCore.UnitOfWork
{
	public interface IUnitOfWork
	{
		Task<TResult> ExecuteAsync<TParameter, TResult>(Func<TParameter, TResult> commands, TParameter parameter,
			CancellationToken cancellationToken = default(CancellationToken));

		Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> commands, CancellationToken cancellationToken = default(CancellationToken));

		Task<TResult> ExecuteAsync<TParameter, TResult>(Func<TParameter, Task<TResult>> commands, TParameter parameter,
			CancellationToken cancellationToken = default(CancellationToken));

		Task<TResult> ReturnAsync<TResult>(Func<Task<TResult>> commands, CancellationToken cancellationToken = default(CancellationToken));

		Task<TResult> ReturnAsync<TParameter, TResult>(Func<TParameter, Task<TResult>> commands, TParameter parameter,
			CancellationToken cancellationToken = default(CancellationToken));
	}
}