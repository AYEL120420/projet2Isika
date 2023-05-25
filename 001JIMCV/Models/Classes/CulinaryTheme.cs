using System.Collections.Generic;

namespace _001JIMCV.Models.Classes
{
    public class CulinaryTheme
    {
            public int CulinaryThemeId { get; set; }
            public string Name { get; set; }
            public List<Journey> journeys { get; set; }
        
    }
}
