# Partial_Static_QueryType

## HotChocolateResolvers.735550c.g.cs

```csharp
// <auto-generated/>

#nullable enable
#pragma warning disable

using System;
using System.Runtime.CompilerServices;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Execution.Configuration;
using HotChocolate.Internal;

namespace TestNamespace
{
    internal static class QueryResolvers
    {
        private static readonly object _sync = new object();
        private static bool _bindingsInitialized;
        private readonly static global::HotChocolate.Internal.IParameterBinding[] _args_Query_GetTest = new global::HotChocolate.Internal.IParameterBinding[1];

        public static void InitializeBindings(global::HotChocolate.Internal.IParameterBindingResolver bindingResolver)
        {
            if (!_bindingsInitialized)
            {
                lock (_sync)
                {
                    if (!_bindingsInitialized)
                    {
                        const global::System.Reflection.BindingFlags bindingFlags =
                            global::System.Reflection.BindingFlags.Public
                                | global::System.Reflection.BindingFlags.NonPublic
                                | global::System.Reflection.BindingFlags.Static;

                        var type = typeof(global::TestNamespace.Query);
                        global::System.Reflection.MethodInfo resolver = default!;
                        global::System.Reflection.ParameterInfo[] parameters = default!;
                        _bindingsInitialized = true;

                        resolver = type.GetMethod(
                            "GetTest",
                            bindingFlags,
                            new global::System.Type[]
                            {
                                typeof(string)
                            })!;
                        parameters = resolver.GetParameters();
                        _args_Query_GetTest[0] = bindingResolver.GetBinding(parameters[0]);
                    }
                }
            }
        }

        public static HotChocolate.Resolvers.FieldResolverDelegates Query_GetTest()
        {
            if(!_bindingsInitialized)
            {
                throw new global::System.InvalidOperationException("The bindings must be initialized before the resolvers can be created.");
            }

            var isPure = _args_Query_GetTest[0].IsPure;

            return isPure
                ? new global::HotChocolate.Resolvers.FieldResolverDelegates(pureResolver: Query_GetTest_Resolver)
                : new global::HotChocolate.Resolvers.FieldResolverDelegates(resolver: c => new(Query_GetTest_Resolver(c)));
        }

        private static global::System.Object? Query_GetTest_Resolver(global::HotChocolate.Resolvers.IResolverContext context)
        {
            var args0 = _args_Query_GetTest[0].Execute<string>(context);
            var result = global::TestNamespace.Query.GetTest(args0);
            return result;
        }
    }
}


```

## HotChocolateTypeModule.735550c.g.cs

```csharp
// <auto-generated/>

#nullable enable
#pragma warning disable

using System;
using System.Runtime.CompilerServices;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Execution.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class TestsTypesRequestExecutorBuilderExtensions
    {
        public static IRequestExecutorBuilder AddTestsTypes(this IRequestExecutorBuilder builder)
        {
            builder.ConfigureDescriptorContext(ctx => ctx.TypeConfiguration.TryAdd(
                "Tests::TestNamespace.Query",
                global::HotChocolate.Types.OperationTypeNames.Query,
                () => global::TestNamespace.Query.Initialize));
            builder.ConfigureSchema(
                b => b.TryAddRootType(
                    () => new global::HotChocolate.Types.ObjectType(
                        d => d.Name(global::HotChocolate.Types.OperationTypeNames.Query)),
                    HotChocolate.Language.OperationType.Query));
            return builder;
        }
    }
}

```

## HotChocolateTypes.735550c.g.cs

```csharp
// <auto-generated/>

#nullable enable
#pragma warning disable

using System;
using System.Runtime.CompilerServices;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestNamespace
{
public static partial class Query
{
    internal static void Initialize(global::HotChocolate.Types.IObjectTypeDescriptor descriptor)
    {
        const global::System.Reflection.BindingFlags bindingFlags =
            global::System.Reflection.BindingFlags.Public
                | global::System.Reflection.BindingFlags.NonPublic
                | global::System.Reflection.BindingFlags.Static;

        var thisType = typeof(global::TestNamespace.Query);
        var bindingResolver = descriptor.Extend().Context.ParameterBindingResolver;
        global::TestNamespace.QueryResolvers.InitializeBindings(bindingResolver);

        descriptor
            .Field(thisType.GetMember("GetTest", bindingFlags)[0])
            .ExtendWith(c =>
            {
                c.Definition.SetSourceGeneratorFlags();
                c.Definition.Resolvers = global::TestNamespace.QueryResolvers.Query_GetTest();
            });

        Configure(descriptor);
    }

    static partial void Configure(global::HotChocolate.Types.IObjectTypeDescriptor descriptor);
}
}


```

