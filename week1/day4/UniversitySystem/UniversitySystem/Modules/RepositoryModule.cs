using Autofac;
using UniversitySystem.Data.Repositories;

namespace UniversitySystem.Api.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>()
                .As<IStudentRepository>()
                .InstancePerLifetimeScope();
        }
    }
}