using System.Reflection;
using WebApplication1.IOC容器.Attributes;
using WebApplication1.IOC容器.Dto;
using WebApplication1.IOC容器.IServices;

namespace WebApplication1.IOC容器.Services
{
    /// <summary>
    /// 实现Container
    /// </summary>
    public class JackIOCContainer : IJackIOCContainer
    {
        private Dictionary<string, IOCContainerRegistModel> _tianYaContainerDictionary = new Dictionary<string, IOCContainerRegistModel>();

        /// <summary>
        /// 保存常量的值
        /// </summary>
        private Dictionary<string, object[]> _tianYaContainerValueDictionary = new Dictionary<string, object[]>();//保存常量的值：


        /// <summary>
        /// 作用域单例的对象
        /// </summary>
        private Dictionary<string, object> _tianYaContainerScopeDictionary = new Dictionary<string, object>(); // 保存作用域单例的对象

        #region 构造函数

        /// <summary>
        /// 无参构造行数
        /// </summary>
        public JackIOCContainer()
        {

        }
        public IJackIOCContainer CreateChildContainer()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 主要在创建子容器的时候使用
        /// </summary>
        private JackIOCContainer(Dictionary<string, IOCContainerRegistModel> tianYaContainerDictionary,
            Dictionary<string, object[]> tianYaContainerValueDictionary, Dictionary<string, object> tianYaContainerScopeDictionary)
        {
            this._tianYaContainerDictionary = tianYaContainerDictionary;
            this._tianYaContainerValueDictionary = tianYaContainerValueDictionary;
            this._tianYaContainerScopeDictionary = tianYaContainerScopeDictionary;
        }

        #endregion 构造函数

        /// <summary>
        /// 获取键
        /// </summary>
        private string GetKey(string fullName, string shortName) => $"{fullName}___{shortName}";

        public void Register<TFrom, TTo>(string shortName = null, object[] paraList = null, LifetimeType lifetimeType = LifetimeType.Transient) where TTo : TFrom
        {
            _tianYaContainerDictionary.Add(this.GetKey(typeof(TFrom).FullName, shortName), new IOCContainerRegistModel()
            {
                Lifetime = lifetimeType,
                TargetType = typeof(TTo)
            });

            if (paraList != null && paraList.Length > 0)
            {
                this._tianYaContainerValueDictionary.Add(this.GetKey(typeof(TFrom).FullName, shortName), paraList);
            }
        }

        public TFrom Resolve<TFrom>(string shortName = null)
        {
            return (TFrom)ResolveObject(typeof(TFrom), shortName);
        }

        /// <summary>
        /// 递归--可以完成不限层级的对象创建
        /// </summary>
        private object ResolveObject(Type abstractType, string shortName = null)
        {
            string key = this.GetKey(abstractType.FullName, shortName);
            var model = _tianYaContainerDictionary[key];

            #region 生命周期

            switch (model.Lifetime)
            {
                case LifetimeType.Transient:
                    Console.WriteLine("Transient Do Nothing Before");
                    break;
                case LifetimeType.Singleton:
                    if (model.SingletonInstance == null)
                    {
                        break;
                    }
                    else
                    {
                        return model.SingletonInstance;
                    }
                case LifetimeType.Scope:
                    if (this._tianYaContainerScopeDictionary.ContainsKey(key))
                    {
                        return this._tianYaContainerScopeDictionary[key];
                    }
                    else
                    {
                        break;
                    }
                default:
                    break;
            }

            #endregion 生命周期

            Type type = model.TargetType;

            #region 选择合适的构造函数

            ConstructorInfo ctor = null;
            //标记特性
            ctor = type.GetConstructors().FirstOrDefault(c => c.IsDefined(typeof(ConstructorInjectionAttribute), true));
            if (ctor == null)
            {
                //参数个数最多
                ctor = type.GetConstructors().OrderByDescending(c => c.GetParameters().Length).First();
            }
            //ctor = type.GetConstructors()[0]; //直接第一个

            #endregion 选择合适的构造函数

            #region 准备构造函数的参数

            List<object> paraList = new List<object>();
            object[] paraConstant = this._tianYaContainerValueDictionary.ContainsKey(key) ? this._tianYaContainerValueDictionary[key] : null; //常量找出来
            int iIndex = 0;
            foreach (var para in ctor.GetParameters())
            {
                if (para.IsDefined(typeof(ParameterConstantAttribute), true))
                {
                    paraList.Add(paraConstant[iIndex]);
                    iIndex++;
                }
                else
                {
                    Type paraType = para.ParameterType; //获取参数的类型
                    string paraShortName = this.GetShortName(para);
                    object paraInstance = this.ResolveObject(paraType, paraShortName);
                    paraList.Add(paraInstance);
                }
            }

            #endregion 准备构造函数的参数

            object oInstance = null;
            oInstance = Activator.CreateInstance(type, paraList.ToArray()); //创建对象，完成构造函数的注入

            #region 属性注入

            foreach (var prop in type.GetProperties().Where(p => p.IsDefined(typeof(PropertyInjectionAttribute), true)))
            {
                Type propType = prop.PropertyType;
                string paraShortName = this.GetShortName(prop);
                object propInstance = this.ResolveObject(propType, paraShortName);
                prop.SetValue(oInstance, propInstance);
            }

            #endregion 属性注入

            #region 方法注入 

            foreach (var method in type.GetMethods().Where(m => m.IsDefined(typeof(MethodInjectionAttribute), true)))
            {
                List<object> paraInjectionList = new List<object>();
                foreach (var para in method.GetParameters())
                {
                    Type paraType = para.ParameterType;//获取参数的类型 IUserDAL
                    string paraShortName = this.GetShortName(para);
                    object paraInstance = this.ResolveObject(paraType, paraShortName);
                    paraInjectionList.Add(paraInstance);
                }
                method.Invoke(oInstance, paraInjectionList.ToArray());
            }

            #endregion 方法注入

            #region 生命周期

            switch (model.Lifetime)
            {
                case LifetimeType.Transient:
                    Console.WriteLine("Transient Do Nothing After");
                    break;
                case LifetimeType.Singleton:
                    model.SingletonInstance = oInstance;
                    break;
                case LifetimeType.Scope:
                    this._tianYaContainerScopeDictionary[key] = oInstance;
                    break;
                default:
                    break;
            }

            #endregion 生命周期

            //return oInstance.AOP(abstractType); //AOP扩展
            return oInstance;
        }

        /// <summary>
        /// 获取简称（别名）
        /// </summary>
        private string GetShortName(ICustomAttributeProvider provider)
        {
            if (provider.IsDefined(typeof(ParameterShortNameAttribute), true))
            {
                var attribute = (ParameterShortNameAttribute)(provider.GetCustomAttributes(typeof(ParameterShortNameAttribute), true)[0]);
                return attribute.ShortName;
            }
            else
            {
                return null;
            }
        }


    }
}
