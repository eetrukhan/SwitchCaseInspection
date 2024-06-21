using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Daemon.CSharp.Stages;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace ReSharperPlugin.CustomInspectionPlugin
{
    [ZoneDefinition]
    public interface ICustomInspectionPluginZone : IZone { }

    [RegisterConfigurableSeverity(
        SeverityId,
        CompoundItemName: null,
        Group: HighlightingGroupIds.CodeSmell,
        Title: Title,
        Description: Description,
        DefaultSeverity: Severity.WARNING)]
    [ConfigurableSeverityHighlighting(SeverityId, CSharpLanguage.Name)]
    public class SwitchCaseCountHighlighting : IHighlighting
    {
        public const string SeverityId = "SwitchCaseCountInspection";
        public const string Title = "Switch statement should have at least 3 case clauses";
        public const string Description = "This inspection enforces the use of at least 3 case clauses in switch statements to improve code readability and maintainability.";

        public SwitchCaseCountHighlighting(ITreeNode element)
        {
            Declaration = element;
        }

        public ITreeNode Declaration { get; }
        public bool IsValid() => Declaration.IsValid();
        public string ToolTip => Title;
        public string ErrorStripeToolTip => Title;
        public DocumentRange CalculateRange() => Declaration.GetDocumentRange();
    }

    [ElementProblemAnalyzer(
        typeof(ISwitchStatement),
        HighlightingTypes = new[] { typeof(SwitchCaseCountHighlighting) })] 
    public class SwitchCaseCountProblemAnalyzer : ElementProblemAnalyzer<ISwitchStatement>
    {
        protected override void Run(
            ISwitchStatement switchStatement,
            ElementProblemAnalyzerData data,
            IHighlightingConsumer consumer)
        {
            int caseCount = switchStatement.Sections.Count;
            if (caseCount < 3)
            {
                consumer.AddHighlighting(new SwitchCaseCountHighlighting(switchStatement));
            }
        }
    }
}
