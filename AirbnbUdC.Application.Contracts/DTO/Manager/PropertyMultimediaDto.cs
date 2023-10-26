using AirbnbUdC.Application.Contracts.DTO.Parameters;

namespace AirbnbUdC.Application.Contracts.DTO.Manager
{
    public class PropertyMultimediaDto
    {
        public long PropertyMultimediaId { get; set; }
        public int? MultimediaName { get; set; }
        public string MultimediaLink { get; set; }
        //public PropertyDto Property { get; set; }
        public MultimediaTypeDto MultimediaType { get; set; }
    }
}
