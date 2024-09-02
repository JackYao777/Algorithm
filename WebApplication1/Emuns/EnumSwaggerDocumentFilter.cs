using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;
using System.Reflection;

namespace WebApplication1.Emuns
{
    /// <summary>
    /// Swagger显示枚举过滤器
    /// </summary>
    public class EnumSwaggerDocumentFilter : ISchemaFilter
    {

        #region 劫持
        /// <summary>
        /// 劫持
        /// </summary>
        /// <param name="schema">提要</param>
        /// <param name="context">过滤器上下文</param>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                foreach (var name in Enum.GetNames(context.Type).ToList())
                {
                    string value = $"{System.Convert.ToInt64(Enum.Parse(context.Type, name))}= {ToDescription(context.Type, name)}";
                    schema.Enum.Add(new OpenApiString(value));
                }
            }

        }
        #endregion

        #region 显示枚举
        /// <summary>
        /// 显示枚举
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        private string ToDescription(Type type, string enumValue)
        {
            FieldInfo? field = Enum.Parse(type, enumValue).GetType().GetField(enumValue);
            if (field != null)
            {
                //获取描述属性
                object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                //当描述属性没有时，直接返回名称
                if (objs == null || objs.Length == 0)
                {
                    return enumValue;
                }
                DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
                return descriptionAttribute.Description;
            }
            else
            {
                return enumValue;
            }
        }
        #endregion
    }
}
