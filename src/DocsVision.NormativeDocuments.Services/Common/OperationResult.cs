using System;

namespace DocsVision.NormativeDocuments
{
	public class OperationResult<T>
	{
		public bool IsSuccess { get; }
		public Exception Error { get; }
		public T Payload { get; }

		internal OperationResult(Exception error)
		{
			IsSuccess = false;
			Error = error;
		}

		internal OperationResult(T payload)
		{
			IsSuccess = true;
			Payload = payload;
		}
	}
}