namespace LuvFinder_Blazor_WASM.Models
{
    //https://json2csharp.com/
    public class Result
    {
        public string Country { get; set; }
        public string Mfr_CommonName { get; set; }
        public int Mfr_ID { get; set; }
        public string Mfr_Name { get; set; }
        public List<VehicleType> VehicleTypes { get; set; }
    }

    public class Root
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public object SearchCriteria { get; set; }
        public List<Result> Results { get; set; }
    }

    public class VehicleType
    {
        public bool IsPrimary { get; set; }
        public string Name { get; set; }
    }
}
