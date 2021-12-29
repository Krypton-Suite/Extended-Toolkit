namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
	internal class ReportBuilder
    {
        private readonly ExceptionReportInfo _info;
        private readonly IAssemblyDigger _assemblyDigger;
        private readonly IStackTraceMaker _stackTraceMaker;
        private readonly ISysInfoResultMapper _sysInfoMapper;

        public ReportBuilder(ExceptionReportInfo info,
            IAssemblyDigger assemblyDigger,
            IStackTraceMaker stackTraceMaker,
            ISysInfoResultMapper sysInfoMapper)
        {
            _info = info;
            _assemblyDigger = assemblyDigger;
            _stackTraceMaker = stackTraceMaker;
            _sysInfoMapper = sysInfoMapper;
        }

        public string Report()
        {
            var renderer = new TemplateRenderer(this.ReportModel());
            return _info.ReportCustomTemplate.IsEmpty()
                ? renderer.RenderPreset(_info.ReportTemplateFormat)
                : renderer.RenderCustom(_info.ReportCustomTemplate);
        }

        public ReportModel ReportModel()
        {
            return new ReportModel
            {
                App = new App
                {
                    Title = _info.TitleText,
                    Name = _info.AppName,
                    Version = _info.AppVersion,
                    Region = _info.RegionInfo,
                    User = _info.UserName,
                    AssemblyRefs = _assemblyDigger.GetAssemblyRefs()
                },
                SystemInfo = _sysInfoMapper.SysInfoString(),
                Error = new Error
                {
                    Exception = _info.MainException,
                    Explanation = _info.UserExplanation,
                    When = _info.ExceptionDate,
                    FullStackTrace = _stackTraceMaker.FullStackTrace()
                }
            };
        }
    }
}