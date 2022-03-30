using System;

namespace Decorator_With_CustomFluentBuilder
{
    public static class ConsultantDecoratorBuilderExtension
    {
        public static TEmployeeDecorator DecorateAs<TEmployeeDecorator>(this Consultant c, Action<TEmployeeDecorator> typeInitializer)
            where TEmployeeDecorator : EmployeeDecorator, new()
        {
            var decorator = new TEmployeeDecorator();
            decorator.SetEmployee(c);

            typeInitializer(decorator);
            return decorator;
        }
    }
}