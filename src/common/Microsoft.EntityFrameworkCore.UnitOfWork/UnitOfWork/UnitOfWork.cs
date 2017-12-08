using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Storage;

namespace Microsoft.EntityFrameworkCore.UnitOfWork
{
	internal class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
	{
		#region Fields

		private readonly IDbContextScope<TContext> _contextScope;
		#endregion

		#region Constructors

		public UnitOfWork(IDbContextScope<TContext> contextScope)
		{
			_contextScope = contextScope;
		}
		#endregion

		#region IUnitOfWork implementation

		public Task<TResult> ExecuteAsync<TParameter, TResult>(Func<TParameter, TResult> commands, TParameter parameter, CancellationToken cancellationToken)
		{
			return InternalExecuteAsync(commands, parameter, cancellationToken, true);
		}

		public Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> commands, CancellationToken cancellationToken)
		{
			return InternalExecuteAsync(commands, cancellationToken, true);
		}

		public Task<TResult> ExecuteAsync<TParameter, TResult>(Func<TParameter, Task<TResult>> commands, TParameter parameter, CancellationToken cancellationToken)
		{
			return InternalExecuteAsync(commands, parameter, cancellationToken, true);
		}

		public Task<TResult> ReturnAsync<TResult>(Func<Task<TResult>> commands, CancellationToken cancellationToken)
		{
			return InternalExecuteAsync(commands, cancellationToken, false);
		}

		public Task<TResult> ReturnAsync<TParameter, TResult>(Func<TParameter, Task<TResult>> commands, TParameter parameter, CancellationToken cancellationToken)
		{
			return InternalExecuteAsync(commands, parameter, cancellationToken, false);
		}
		#endregion

		#region Private class methods

		private async Task<TResult> InternalExecuteAsync<TResult>(Func<Task<TResult>> commands, CancellationToken cancellationToken, bool withChanges)
		{
			TResult result = default(TResult);

			DbContext context = _contextScope.GetContext();

			IDbContextTransaction transaction = null;
			try
			{
				transaction = await CreateTransactionAsync(context, cancellationToken, true);

				result = await commands.Invoke();

				if (withChanges)
				{
					await context.SaveChangesAsync(true, cancellationToken);
				}

				transaction.Commit();
			}
			catch
			{
				transaction?.Rollback();
				throw;
			}
			finally
			{
				transaction?.Dispose();
			}

			return result;
		}


		private async Task<TResult> InternalExecuteAsync<TParameter, TResult>(Func<TParameter, TResult> commands, TParameter parameter,
			CancellationToken cancellationToken, bool withChanges)
		{
			TResult result = default(TResult);

			DbContext context = _contextScope.GetContext();

			IDbContextTransaction transaction = null;
			try
			{
				transaction = await CreateTransactionAsync(context, cancellationToken, true);

				result = commands.Invoke(parameter);

				if (withChanges)
				{
					await context.SaveChangesAsync(true, cancellationToken);
				}

				transaction.Commit();
			}
			catch
			{
				transaction?.Rollback();
				throw;
			}
			finally
			{
				transaction?.Dispose();
			}

			return result;
		}

		private async Task InternalExecuteAsync<TParameter, TResult>(Func<TParameter, Task> commands, TParameter parameter,
			CancellationToken cancellationToken, bool withChanges)
		{
			DbContext context = _contextScope.GetContext();

			IDbContextTransaction transaction = null;
			try
			{
				transaction = await CreateTransactionAsync(context, cancellationToken, true);

				await commands.Invoke(parameter);

				if (withChanges)
				{
					await context.SaveChangesAsync(true, cancellationToken);
				}

				transaction.Commit();
			}
			catch
			{
				transaction?.Rollback();
				throw;
			}
			finally
			{
				transaction?.Dispose();
			}
		}

		private async Task<TResult> InternalExecuteAsync<TParameter, TResult>(Func<TParameter, Task<TResult>> commands, TParameter parameter,
			CancellationToken cancellationToken, bool withChanges)
		{
			TResult result = default(TResult);

			DbContext context = _contextScope.GetContext();

			IDbContextTransaction transaction = null;
			try
			{
				transaction = await CreateTransactionAsync(context, cancellationToken, true);

				result = await commands.Invoke(parameter);

				if (withChanges)
				{
					await context.SaveChangesAsync(true, cancellationToken);
				}

				transaction.Commit();
			}
			catch
			{
				transaction?.Rollback();
				throw;
			}
			finally
			{
				transaction?.Dispose();
			}

			return result;
		}

		private Task<IDbContextTransaction> CreateTransactionAsync(DbContext context, CancellationToken cancellationToken, bool withChanges)
		{
			context.ChangeTracker.AutoDetectChangesEnabled = withChanges;

			return context.Database.BeginTransactionAsync(cancellationToken);
		}
		#endregion
	}
}