namespace ARABYTAK.APIS.DTOs
{
    public class DealershipDto
    {
       
        
            public string Name { get; set; }
            public int? Phone1 { get; set; }
            public int? Phone2 { get; set; }
            public int? Phone3 { get; set; }
            public int? WhatsApp1 { get; set; }
            public string? Facebook { get; set; }
            public string? Instagram { get; set; }
            public List<string> Branches { get; set; } 
        
    }
}
