namespace WebApplication1.全局日志.Dtos
{
    /// <summary>
    /// 返回状态
    /// </summary>
    public enum ResultCode
    {
        /// <summary>
        /// 
        /// 成功
        /// </summary>
        Success = 200,
        /// <summary>
        /// 失败
        /// </summary>
        Fail = -200,
        /// <summary>
        /// 请求参数错误
        /// </summary>
        ReqRaramError = 400,
        /// <summary>
        /// 请求地址不存在
        /// </summary>
        NotFound404 = 404,
        /// <summary>
        /// 请求方法不支持
        /// </summary>
        NotFoundMethod = 405,
        /// <summary>
        /// 实体不存在
        /// </summary>
        NotFoundEntity = 401,
        /// <summary>
        /// 无权限
        /// </summary>
        NoPermission = 403,
        /// <summary>
        /// 认证失败
        /// </summary>
        TokenInvalid = 404,
        /// <summary>
        /// 服务器内部错误
        /// </summary>
        ServerInternalError = 500,
        /// <summary>
        /// 业务逻辑错误
        /// </summary>
        BusinessError = 501,
    }
}
