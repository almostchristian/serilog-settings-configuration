using System;

namespace Serilog.Settings.Configuration.Tests.Support
{
    public interface IAmAnInterface
    {
    }

    public abstract class AnAbstractClass
    {
    }

    public delegate string NamedStringDelegate();

    internal class ConcreteImpl : AnAbstractClass, IAmAnInterface
    {
        private ConcreteImpl()
        {
        }

        public static ConcreteImpl Instance { get; } = new ConcreteImpl();
    }

    public class ClassWithStaticAccessors
    {
        public static IAmAnInterface InterfaceProperty => ConcreteImpl.Instance;
        public static Func<string> FunctionProperty => StaticStringFunction;
        public static NamedStringDelegate DelegateProperty => StaticStringFunction;
        public static AnAbstractClass AbstractProperty => ConcreteImpl.Instance;

        public static IAmAnInterface InterfaceField = ConcreteImpl.Instance;
        public static AnAbstractClass AbstractField = ConcreteImpl.Instance;
        public static Func<string> FunctionField = StaticStringFunction;
        public static NamedStringDelegate DelegateField = StaticStringFunction;


        // ReSharper disable once UnusedMember.Local
        private static IAmAnInterface PrivateInterfaceProperty => ConcreteImpl.Instance;

#pragma warning disable 169
        private static IAmAnInterface PrivateInterfaceField = ConcreteImpl.Instance;
        private static Func<string> PrivateFunctionField = StaticStringFunction;
        private static Func<string> PrivateFunctionProperty() => StaticStringFunction;
        private static string PrivateFunction() => string.Empty;
#pragma warning restore 169
        public IAmAnInterface InstanceInterfaceProperty => ConcreteImpl.Instance;
        public IAmAnInterface InstanceInterfaceField = ConcreteImpl.Instance;

        public static bool StaticBoolFunction() => true;

        public static void StaticAction() { }

        public static void StaticAction(string value) { }

        public static string StaticStringFunction() => string.Empty;

        public static string StaticStringFunction(string value) => value;

        public static string StaticStringFunction(string value1, string value2) => value1 + value2;

        public static string StaticStringFunction<T>(string value1, T value2) => value1;

        public string InstanceFunction() => string.Empty;
    }
}
