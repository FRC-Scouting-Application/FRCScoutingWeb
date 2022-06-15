using FRCScouting_API.Services.Interfaces;
using Microsoft.ApplicationInsights;
using Models.Reports;

namespace FRCScouting_API.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IAppDataRepository _repository;
        private readonly TelemetryClient _telemetryClient;

        public ReportsService(IAppDataRepository repository, TelemetryClient telemetryClient)
        {
            _repository = repository;
            _telemetryClient = telemetryClient;
        }

        public DataReport? GenerateDataReport()
        {
            try
            {
                DataReport report = new()
                {
                    Events = _repository.GenerateEventsDataReport(),
                    Teams = _repository.GenerateTeamsDataReport(),
                    Matches = _repository.GenerateMatchesDataReport(),
                    Templates = _repository.GenerateTemplatesDataReport(),
                };

                return report;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }    
        }
    }
}
