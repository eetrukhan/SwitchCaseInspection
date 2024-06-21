using System.Threading;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Feature.Services;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TestFramework;
using JetBrains.TestFramework.Application.Zones;
using NUnit.Framework;

[assembly: Apartment(ApartmentState.STA)]

namespace ReSharperPlugin.SwitchCaseInspection.Tests
{
    /*
    [ZoneDefinition]
    public class SwitchCaseInspectionTestEnvironmentZone : ITestsEnvZone, IRequire<PsiFeatureTestZone>, IRequire<ISwitchCaseInspectionZone> { }

    [ZoneMarker]
    public class ZoneMarker : IRequire<ICodeEditingZone>, IRequire<ILanguageCSharpZone>, IRequire<SwitchCaseInspectionTestEnvironmentZone> { }

    [SetUpFixture]
    public class SwitchCaseInspectionTestsAssembly : ExtensionTestEnvironmentAssembly<SwitchCaseInspectionTestEnvironmentZone> { }
    */
}
