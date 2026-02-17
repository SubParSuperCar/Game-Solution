using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Estragonia;

internal static class AsyncEnumerableHelper
{
	public static IAsyncEnumerable<T> AsAsyncEnumerable<T>(this IEnumerable<T> enumerable)
	{
		return new EnumerableAsyncWrapper<T>(enumerable);
	}

	private sealed class EnumerableAsyncWrapper<T>(IEnumerable<T> enumerable) : IAsyncEnumerable<T>
	{
		public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
		{
			return new EnumeratorAsyncWrapper<T>(enumerable.GetEnumerator(), cancellationToken);
		}
	}

	private sealed class EnumeratorAsyncWrapper<T>(IEnumerator<T> enumerator, CancellationToken cancellationToken)
		: IAsyncEnumerator<T>
	{
		public T Current
			=> enumerator.Current;

		public ValueTask<bool> MoveNextAsync()
		{
			return cancellationToken.IsCancellationRequested
				? new ValueTask<bool>(Task.FromCanceled<bool>(cancellationToken))
				: new ValueTask<bool>(enumerator.MoveNext());
		}

		public ValueTask DisposeAsync()
		{
			enumerator.Dispose();
			return default;
		}
	}
}
