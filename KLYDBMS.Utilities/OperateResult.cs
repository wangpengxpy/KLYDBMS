namespace KLYDBMS.Utilities
{
    public class OperateResult
    {
        private static readonly OperateResult _success = new() { Succeeded = true };

        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value>True if the operation succeeded, otherwise false.</value>
        public bool Succeeded { get; private set; }

        /// <summary>
        /// Gets or sets the code for this error.
        /// </summary>
        /// <value>
        /// The code for this error.
        /// </value>
        public int Code { get; private set; } = 200;

        /// <summary>
        /// Gets or sets the description for this error.
        /// </summary>
        /// <value>
        /// The description for this error.
        /// </value>
        public string Message { get; private set; }

        /// <summary>
        /// Returns an <see cref="OperateResult"/> indicating a successful operation.
        /// </summary>
        /// <returns>An <see cref="OperateResult"/> indicating a successful operation.</returns>
        public static OperateResult Success => _success;

        /// <summary>
        /// Creates an <see cref="OperateResult<typeparamref name="T"/>"/> indicating a successful operation.
        /// </summary>
        /// <typeparam name="T">The type of data</typeparam>
        /// <param name="data">The data return</param>
        /// <returns></returns>
        public static OperateResult<T> Successed<T>(T data)
        {
            return new OperateResult<T>
            {
                Succeeded = true,
                Data = data
            };
        }

        /// <summary>
        ///  Creates an <see cref="OperateResult"/> indicating a failed operation.
        /// </summary>
        /// <param name="message">the description for this error.</param>
        /// <returns></returns>
        public static OperateResult Failed(string message)
        {
            return new OperateResult
            {
                Succeeded = false,
                Code = 400,
                Message = message
            };
        }

        /// <summary>
        /// Creates an <see cref="OperateResult"/> indicating a failed operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static OperateResult<T> Failed<T>(string message)
        {
            return new OperateResult<T>
            {
                Succeeded = false,
                Code = 400,
                Message = message
            };
        }

        /// <summary>
        /// Creates an <see cref="OperateResult"/> indicating a failed operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static OperateResult<T> Failed<T>(T data)
        {
            return new OperateResult<T>
            {
                Succeeded = false,
                Code = 400,
                Data = data
            };
        }

        public static OperateResult FailedWithArgument(string message)
        {
            return new OperateResult
            {
                Succeeded = false,
                Code = 400,
                Message = message
            };
        }

        public static OperateResult<T> FailedWithArgument<T>(string message)
        {
            return new OperateResult<T>
            {
                Succeeded = false,
                Code = 400,
                Message = message
            };
        }

        public static OperateResult FailedWithSaveDb(string message = null)
        {
            return new OperateResult
            {
                Succeeded = false,
                Code = 400,
                Message = message ?? "Save data to database failed"
            };
        }

        public static OperateResult<T> FailedWithSaveDb<T>(string message = null)
        {
            return new OperateResult<T>
            {
                Succeeded = false,
                Code = 400,
                Message = message ?? "Save data to database failed"
            };
        }

        public override string ToString()
        {
            return Succeeded ?
                   "Succeeded" :
                   string.Format("{0} : {1},{2}", "Failed", Code, Message);
        }
    }

    public class OperateResult<T> : OperateResult
    {
        public T Data { get; set; }
    }
}
