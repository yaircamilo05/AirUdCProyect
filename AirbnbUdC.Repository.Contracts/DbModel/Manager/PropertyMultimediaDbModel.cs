using AirbnbUdC.Repository.Contracts.DbModel.Parameters;

namespace AirbnbUdC.Repository.Contracts.DbModel.Manager
{
    public class PropertyMultimediaDbModel
    {
        public long PropertyMultimediaId { get; set; }
        public int? MultimediaName { get; set; }
        public string MultimediaLink { get; set; }
        //public PropertyDbModel Property { get; set; }
        public MultimediaTypeDbModel MultimediaType { get; set; }
    }
}
