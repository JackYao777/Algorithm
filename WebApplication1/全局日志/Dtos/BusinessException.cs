namespace WebApplication1.全局日志.Dtos
{
    public class BusinessException : Exception
    {

        /// <summary>
        /// 返回状态
        /// </summary>
        public ResultCode ResultCode { get; }

        /// <summary>
        /// 构造
        /// </summary>
        public BusinessException()
        {


        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="resultCode">返回状态</param>
        public BusinessException(string message, ResultCode resultCode = ResultCode.BusinessError) : base(message)
        {
            ResultCode = resultCode;
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="innerException">异常</param>
        public BusinessException(string? message, Exception? innerException) : base(message, innerException)
        {


        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="innerException">异常</param>
        /// <param name="resultCode">返回状态</param>
        public BusinessException(string? message, Exception? innerException, ResultCode resultCode) : base(message, innerException)
        {
            ResultCode = resultCode;
        }
    }
}
