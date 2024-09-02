namespace WebApplication1.全局日志.Dtos
{
    /// <summary>
    /// Apb异常
    /// </summary>
    public class AbpExceptionResult
    {
        public Error Error { get; set; }
    }

    public class Error
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 明细
        /// </summary>
        public string Details { get; set; }
    }
}
