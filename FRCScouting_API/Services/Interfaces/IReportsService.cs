using Models.Reports;

namespace FRCScouting_API.Services.Interfaces
{
    public interface IReportsService
    {
        DataReport GenerateDataReport();
    }
}
