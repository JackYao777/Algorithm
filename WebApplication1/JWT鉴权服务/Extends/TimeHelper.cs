namespace WebApplication1.JWT鉴权服务.Extends
{
    public static class TimeHelper
    {
        /// <summary>
        /// 本时区日期时间转时间戳
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns>long=Int64</returns>
        public static long ToTimestamp(this DateTime datetime)
        {
            DateTime dd = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime timeUTC = DateTime.SpecifyKind(datetime, DateTimeKind.Utc);//本地时间转成UTC时间
            TimeSpan ts = (timeUTC - dd);
            return (Int64)(ts.TotalMilliseconds);//精确到毫秒
        }
        /// <summary>
        /// 时间戳转本时区日期时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime TimestampToDateTime(this string timeStamp)
        {
            DateTime dd = DateTime.SpecifyKind(new DateTime(1970, 1, 1, 0, 0, 0, 0), DateTimeKind.Local);
            long longTimeStamp = long.Parse(timeStamp + "0000");
            TimeSpan ts = new TimeSpan(longTimeStamp);
            return dd.Add(ts);
        }

        /// <summary>  
        /// 时间戳Timestamp转换成日期  
        /// </summary>  
        /// <param name="timeStamp"></param>  
        /// <returns></returns>  
        public static DateTime GetDateTime(int timeStamp)
        {

            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = ((long)timeStamp * 10000000);
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime targetDt = dtStart.Add(toNow);

            if (string.IsNullOrEmpty(targetDt.ToString()))
            {
                targetDt = DateTime.Now;
            }
            return targetDt;
        }


        /// <summary>
        /// 获取毫米时间戳Timestamp 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long GetMillisecondsTimeStamp(DateTime dt)
        {
            DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            long timeStamp = Convert.ToInt64((dt - dateStart).TotalMilliseconds);
            return timeStamp;
        }

        /// <summary>
        /// 获取分钟时间戳Timestamp 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int GetTimeSecondsStamp(DateTime dt)
        {
            DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            int timeStamp = Convert.ToInt32((dt - dateStart).TotalSeconds);
            return timeStamp;
        }
    }
}
