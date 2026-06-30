using Autofac;
using UniversitySystem.Core.Services;

namespace UniversitySystem.Api.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>()
                .As<IStudentService>()
                .InstancePerLifetimeScope();
        }
    }
}