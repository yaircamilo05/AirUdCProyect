using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirUdC.GUI.Models.ReportModels
{
    public class PropertiesByCitiesReportModel
    {
        public string Id { get; set; }

        public string CityId { get; set; }

        public string CityName { get; set; }

        public string Count { get; set; }
    }
}