using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.代理模式.动态代理
{
    /// <summary>
    /// 代理类
    /// </summary>
    public static class DynamicProxy
    {
        private static readonly string AssemblyName = "DynamicProxyAssembly";
        private static readonly string ModuleName = "DynamicProxyModule";
        private static readonly string TypeName = "DynamicProxy";

        /// <summary>
        /// 因为有些方法的指令是需要拆箱装箱的
        /// </summary>
        private static readonly HashSet<Type> CanBox = new HashSet<Type>
    {
        typeof(int), typeof(uint),
        typeof(short), typeof(ushort),
        typeof(long), typeof(ulong),
        typeof(float), typeof(double),
        typeof(sbyte), typeof(byte),
        typeof(char),
        typeof(decimal),
    };

        private static readonly Dictionary<Type, ProxyTypeInfo> ProxyDict = new Dictionary<Type, ProxyTypeInfo>();

        private static TypeBuilder CreateDynamicTypeBuilder(Type type, Type parent, Type[] interfaces)
        {
            if (ProxyDict.TryGetValue(type, out var info))
            {
                info.Count++;
            }
            else
            {
                ProxyDict[type] = info = new ProxyTypeInfo
                {
                    Count = 1
                };
            }

            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(AssemblyName + type.Name),
                AssemblyBuilderAccess.Run);//1:先创建个程序集
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(ModuleName + type.Name);//2:在创建个模块
            return info.TypeBuilder = moduleBuilder.DefineType(TypeName + type.Name + info.Count,
                TypeAttributes.Public | TypeAttributes.Class, parent, interfaces);//3:在创建一个类型,给类型赋予方法属性
        }

        private static void ProxyInit(Type type, TypeBuilder typeBuilder, MethodInfo[] methodInfos,
            MethodInfo handlerInvokeMethodInfo)
        {
            //定义两个字段
            var handlerFieldBuilder =
                typeBuilder.DefineField("_handler", typeof(IInvocationHandler), FieldAttributes.Private);
            var methodInfosFieldBuilder =
                typeBuilder.DefineField("_methodInfos", typeof(MethodInfo), FieldAttributes.Private);
            //定义构造函数
            var constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard,
                new[] { typeof(IInvocationHandler), typeof(MethodInfo[]) });
            var ilCtor = constructorBuilder.GetILGenerator();
            ilCtor.Emit(OpCodes.Ldarg_0);
            ilCtor.Emit(OpCodes.Call,
                    typeof(object).GetConstructor(Type.EmptyTypes) ?? throw new Exception("不可能的错误:object.GetConstructor"));
            ilCtor.Emit(OpCodes.Ldarg_0);
            ilCtor.Emit(OpCodes.Ldarg_1);
            ilCtor.Emit(OpCodes.Stfld, handlerFieldBuilder);
            ilCtor.Emit(OpCodes.Ldarg_0);
            ilCtor.Emit(OpCodes.Ldarg_2);
            ilCtor.Emit(OpCodes.Stfld, methodInfosFieldBuilder);
            ilCtor.Emit(OpCodes.Ret);

            for (var i = 0; i < methodInfos.Length; i++)
            {
                var methodInfo = methodInfos[i];
                var parameterTypes = methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
                var methodBuilder = typeBuilder.DefineMethod(methodInfo.Name,
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    methodInfo.CallingConvention, methodInfo.ReturnType, parameterTypes);
                var ilMethod = methodBuilder.GetILGenerator();
                ilMethod.Emit(OpCodes.Ldarg_0);
                ilMethod.Emit(OpCodes.Ldfld, handlerFieldBuilder);
                ilMethod.Emit(OpCodes.Ldarg_0);
                ilMethod.Emit(OpCodes.Ldarg_0);
                ilMethod.Emit(OpCodes.Ldfld, methodInfosFieldBuilder);
                ilMethod.Emit(OpCodes.Ldc_I4, i);
                ilMethod.Emit(OpCodes.Ldelem_Ref);
                ilMethod.Emit(OpCodes.Ldc_I4, parameterTypes.Length);
                ilMethod.Emit(OpCodes.Newarr, typeof(object));
                for (var j = 0; j < parameterTypes.Length; j++)
                {
                    ilMethod.Emit(OpCodes.Dup);
                    ilMethod.Emit(OpCodes.Ldc_I4_S, (short)j);
                    ilMethod.Emit(OpCodes.Ldarg_S, (short)(j + 1));
                    if (CanBox.Contains(parameterTypes[j]))
                    {
                        ilMethod.Emit(OpCodes.Box, parameterTypes[j]);
                    }

                    ilMethod.Emit(OpCodes.Stelem_Ref);
                }

                ilMethod.Emit(OpCodes.Callvirt, handlerInvokeMethodInfo);
                if (methodInfo.ReturnType != typeof(void))
                {
                    ilMethod.Emit(CanBox.Contains(methodInfo.ReturnType) ? OpCodes.Unbox_Any : OpCodes.Castclass,
                        methodInfo.ReturnType);
                }
                else
                {
                    ilMethod.Emit(OpCodes.Pop);
                }
                ilMethod.Emit(OpCodes.Ret);
            }
        }

        /// <summary>
        /// 通过接口创建动态代理
        /// </summary>
        public static T CreateProxyByInterface<T>(IInvocationHandler handler, bool userCache = true)
        {
            return (T)CreateProxyByInterface(typeof(T), handler, userCache);
        }

        public static object CreateProxyByInterface(Type type, IInvocationHandler handler, bool userCache = true)
        {
            if (!userCache || !ProxyDict.TryGetValue(type, out var info))
            {
                var handlerInvokeMethodInfo = typeof(IInvocationHandler).GetMethod("Invoke") ??
                                              throw new Exception("不可能的错误:handlerInvokeMethodInfo");
                var typeBuilder = CreateDynamicTypeBuilder(type, null, new[] { type });
                var methodInfos = type.GetMethods();
                ProxyInit(type, typeBuilder, methodInfos, handlerInvokeMethodInfo);
                info = ProxyDict[type];
                if (info.Count == 1)
                {
                    info.MethodInfos = methodInfos;
                }
            }
            //return Activator.CreateInstance(typeof(CuiHuaNiu));
            //return Activator.CreateInstance(typeof(CuiHuaNiu), handler, info.MethodInfos);
            return Activator.CreateInstance(info.TypeBuilder.CreateType(),handler,info.MethodInfos);
        }
        /// <summary>
        /// 通过类创建动态代理
        /// </summary>
        public static T CreateProxyByType<T>(IInvocationHandler handler, bool userCache = true)
        {
            return (T)CreateProxyByType(typeof(T), handler, userCache);
        }

        public static object CreateProxyByType(Type type, IInvocationHandler handler, bool userCache = true)
        {
            if (!userCache || !ProxyDict.TryGetValue(type, out var info))
            {
                var handlerInvokeMethodInfo = typeof(IInvocationHandler).GetMethod("Invoke") ??
                                              throw new Exception("不可能的错误:handlerInvokeMethodInfo");
                var typeBuilder = CreateDynamicTypeBuilder(type, type, null);
                var methodInfos = type.GetMethods().Where(methodInfo => methodInfo.IsVirtual || methodInfo.IsAbstract)
                    .ToArray();
                //ProxyInit(type, typeBuilder, methodInfos, handlerInvokeMethodInfo);
                info = ProxyDict[type];
                if (info.Count == 1)
                {
                    info.MethodInfos = methodInfos;
                }
            }

            return Activator.CreateInstance(info.TypeBuilder.CreateType(), handler, info.MethodInfos);
        }
    }
}


//Assembly assembly = Assembly.LoadFrom("MyReflecttion.dll");
//Type type = assembly.GetType("MyReflecttion.ReflectionTest");
//object oInstance = Activator.CreateInstance(type);
//MethodInfo show1 = type.GetMethod("Show1");
//show1.Invoke(oInstance, new object[] { });
//show1.Invoke(oInstance, new object[0]);
//show1.Invoke(oInstance, null);
//-----------------------------------
//C#高级--反射详解
//https://blog.51cto.com/u_4018548/6495762
//https://blog.51cto.com/u_4018548/6495762

//6、反射多种应用场景
//（1）IOC容器：反射+ 配置文件+ 工厂
//（2）MVC框架：反射调用类型方法
//（3）ORM：反射+泛型+Ado.Net
//（4）AOP：在方法的前面后面添加处理内容


//通常我们在这些场景下如身份验证、日志记录、异常获取等会使用到过滤器